using FluentValidation;
using TaskManager_Application.Application.Common.Mapping;
using TaskManager_Application.Application.Common.Validations;
using TaskManager_Domain.Domain.Entites;
using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;
using TaskManager_Infastructure.Infastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<IValidator<Comment>, CommentValidator>();
builder.Services.AddScoped<IValidator<Layer>, LayerValidator>();
builder.Services.AddScoped<IValidator<Notification>, NotificationValidator>();
builder.Services.AddScoped<IValidator<Project>, ProjectValidator>();
builder.Services.AddScoped<IValidator<TaskManager_Domain.Domain.Entites.Task>, TaskValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();

var app = builder.Build();

using(var db = new AppDBContext())
{
    db.Database.EnsureCreated();
}
app.Run();
    