using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WasteManagement.Facade;
using WasteManagement.Models;
using WasteManagement.Observers;
using WasteManagement.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options
    .UseSqlServer("Server=(LocalDb)\\localhost;" +
                    "Database=WasteManagement;" +
                    "User Id=sa;" +
                    "Password=123;"));
builder.Services.AddScoped<IRepository<WasteBin>, WasteBinRepository>();
builder.Services.AddScoped<IRepository<WasteCollection>, RouteRepository>();
builder.Services.AddScoped<WasteBinSubject>();
builder.Services.AddScoped<IObserver, WasteStateObserver>();
builder.Services.AddScoped<WasteManagementFacade>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
