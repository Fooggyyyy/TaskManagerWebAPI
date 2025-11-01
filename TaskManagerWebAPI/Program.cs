using TaskManager_Infastructure.Infastructure.DataBase;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

using(var db = new AppDBContext())
{
    db.Database.EnsureCreated();
}
app.Run();
    