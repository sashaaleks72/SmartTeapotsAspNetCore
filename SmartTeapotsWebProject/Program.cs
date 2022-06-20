using SmartTeapotsWebProject.Data.Interfaces;
using SmartTeapotsWebProject.Data.Mocks;
using SmartTeapotsWebProject.Data.Repository;
using SmartTeapotsWebProject.Data.DBContexts;
using SmartTeapotsWebProject.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connConfig = new ConnectionConfig("dbconfig.json", $"{builder.Environment.ContentRootPath}\\Configs").Build();

builder.Services.AddTransient<IAllSmartTeapots, SmartTeapotRepository>();
builder.Services.AddDbContext<SmartTeapotsDbContext>(options => options.UseSqlServer(connConfig.GetConnectionString("DefaultConnection")));
builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseMvcWithDefaultRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
