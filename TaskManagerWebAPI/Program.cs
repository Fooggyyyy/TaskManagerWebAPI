using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Common.HashHelper;
using TaskManager_Application.Application.Common.JWT.JWTService;
using TaskManager_Application.Application.Common.Mapping;
using TaskManager_Application.Application.Common.Validations;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;
using TaskManager_Application.Application.Events.Querys.Handlers.CommentHandlers;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;
using TaskManager_Infastructure.Infastructure.Repositories;
using TaskManager_WebAPI.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);
var AuthBuilder = builder.Services.AddAuthorizationBuilder();
var JwtSetting = builder.Configuration.GetSection("jwt");
var JwtKey = Encoding.UTF8.GetBytes(JwtSetting.Key);

//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = JwtSetting["Issuer"],
        ValidAudience = JwtSetting["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(JwtKey)
    };
});


//Authorization
AuthBuilder.AddPolicy("DeveloperOnly", policy => policy.RequireRole("Developer"));
AuthBuilder.AddPolicy("ProjectManagerOnly", policy => policy.RequireRole("ProjectManager"));
AuthBuilder.AddPolicy("Client", policy => policy.RequireRole("Client"));
AuthBuilder.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));


//JWT Service
builder.Services.AddScoped<IJwtService, JwtService>();

//DataBase
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies());

//Repositories
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ILayerRepository, LayerRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

//AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile(new CommentProfile());
    cfg.AddProfile(new LayerProfile());
    cfg.AddProfile(new NotificationProfile());
    cfg.AddProfile(new ProjectProfile());
    cfg.AddProfile(new TaskProfile());
    cfg.AddProfile(new UserProfile());
});

//FluentValidation
builder.Services.AddScoped<IValidator<CommentDTO>, CommentValidator>();
builder.Services.AddScoped<IValidator<LayerDTO>, LayerValidator>();
builder.Services.AddScoped<IValidator<NotificationDTO>, NotificationValidator>();
builder.Services.AddScoped<IValidator<ProjectDTO>, ProjectValidator>();
builder.Services.AddScoped<IValidator<TaskDTO>, TaskValidator>();
builder.Services.AddScoped<IValidator<UserDTO>, UserValidator>();
builder.Services.AddScoped<IValidator<ResetPasswordUserCommand>, PasswordValidator>();

//MediatR
builder.Services.AddMediatR(cfg =>  cfg.RegisterServicesFromAssemblies(typeof(GetAllCommentsQueryHandler).Assembly) );

//HashPassword
builder.Services.AddScoped<IHashPassword, HashPasswordService>();

//Mapping
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
    