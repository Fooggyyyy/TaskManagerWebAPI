using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using TaskManager_Application.Application.Common.DTOs;
using TaskManager_Application.Application.Common.HashHelper;
using TaskManager_Application.Application.Common.JWT.JWTService;
using TaskManager_Application.Application.Common.Mapping;
using TaskManager_Application.Application.Common.Validations;
using TaskManager_Application.Application.Events.Commands.Commands.CommentCommands;
using TaskManager_Application.Application.Events.Commands.Commands.LayerCommands;
using TaskManager_Application.Application.Events.Commands.Commands.NotificationCommands;
using TaskManager_Application.Application.Events.Commands.Commands.ProjectCommands;
using TaskManager_Application.Application.Events.Commands.Commands.TaskCommands;
using TaskManager_Application.Application.Events.Commands.Commands.UserCommands;
using TaskManager_Application.Application.Events.Querys.Handlers.CommentHandlers;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;
using TaskManager_Infastructure.Infastructure.Repositories;
using TaskManager_WebAPI.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);
var AuthBuilder = builder.Services.AddAuthorizationBuilder();
var JwtSetting = builder.Configuration.GetSection("Jwt");
var jwtKeyString = JwtSetting["Key"];

if (string.IsNullOrEmpty(jwtKeyString))
    throw new InvalidOperationException("JWT Key is not configured in appsettings.json. Please set 'Jwt:Key' in appsettings.json with at least 32 characters.");

if (jwtKeyString.Length < 32)
    throw new InvalidOperationException($"JWT Key must be at least 32 characters long for HS256 algorithm. Current length: {jwtKeyString.Length}. Please update 'Jwt:Key' in appsettings.json");

var JwtKey = Encoding.UTF8.GetBytes(jwtKeyString);

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
builder.Services.AddScoped<IValidator<UpdateTaskCommand>, UpdateTaskCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateProjectCommand>, UpdateProjectCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateLayerCommand>, UpdateLayerCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateCommentCommand>, UpdateCommentCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateUserCommand>, UpdateUserCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateNotificationCommand>, UpdateNotificationCommandValidator>();

//MediatR
builder.Services.AddMediatR(cfg =>  cfg.RegisterServicesFromAssemblies(typeof(GetAllCommentsQueryHandler).Assembly) );

//HashPassword
builder.Services.AddScoped<IHashPassword, HashPasswordService>();

//Mapping
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "¬ведите ваш JWT токен"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
    