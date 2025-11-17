using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Common.HashHelper;
using TaskManager_Application.Application.Common.JWT.JWTService;
using TaskManager_Application.Application.Common.Mapping;
using TaskManager_Application.Application.Common.Validations;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.Repositories;

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
AuthBuilder.AddPolicy("UserOnly", policy => policy.RequireRole("User"));
AuthBuilder.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));

//JWT Service
builder.Services.AddScoped<IJwtService, JwtService>(); 

//Repositories
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ILayerRepository, LayerRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

//HashPassword
builder.Services.AddScoped<IHashPassword, HashPasswordService>();

//Mapping
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
    