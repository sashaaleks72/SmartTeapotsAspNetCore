using SmartTeapotsWebProject.Data.Interfaces;
using SmartTeapotsWebProject.Data.Mocks;
using SmartTeapotsWebProject.Data.Repository;
using SmartTeapotsWebProject.Data.DBContexts;
using SmartTeapotsWebProject.Configs;
using Microsoft.EntityFrameworkCore;
using SmartTeapotsWebProject.Data.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
var connConfig = new ConnectionConfig("dbconfig.json", $"{builder.Environment.ContentRootPath}\\Configs").Build();

builder.Services.AddTransient<IAllSmartTeapots, SmartTeapotRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();
builder.Services.AddDbContext<SmartTeapotsDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connConfig.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 5;
    options.Password.RequireUppercase = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SmartTeapotsDbContext>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();
builder.Services.AddScoped(c => Cart.GetCart(c));
builder.Services.AddMemoryCache();
builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseMvcWithDefaultRoute();
app.UseMvc(routes => routes.MapRoute(name: "default", template: "{controller-Home}/{action-Index}/{id?}"));

app.Run();
