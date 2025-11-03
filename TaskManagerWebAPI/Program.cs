using TaskManager_Domain.Domain.Intrefaces.ClassRepository;
using TaskManager_Infastructure.Infastructure.DataBase;
using TaskManager_Infastructure.Infastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//DataBase
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

var app = builder.Build();

using(var db = new AppDBContext())
{
    db.Database.EnsureCreated();
}
app.Run();
    