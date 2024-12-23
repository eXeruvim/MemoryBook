using MemoryBook.Data;
using MemoryBook.Models;
using MemoryBook.Repositories;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddScoped(typeof(IRepository<>), typeof(RepositoryImpl<>));


builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = null;
    options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(2);
    options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}



// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Настройка маршрута для контроллера обратной связи
app.MapControllerRoute(
    name: "Feedback",
    pattern: "Feedback",
    defaults: new { controller = "Feedback", action = "Index" });

// Маршрут для контроллера редколлегии
app.MapControllerRoute(
    name: "editor",
    pattern: "editor",
    defaults: new { controller = "Editor", action = "Index" });

// Маршрут для контроллера галереи
app.MapControllerRoute(
    name: "gallery",
    pattern: "gallery/{action=Index}/{category?}",
    defaults: new { controller = "Gallery" });

// Маршрут для контроллера о проекте
app.MapControllerRoute(
    name: "about",
    pattern: "about/{action=Index}/{category?}",
    defaults: new { controller = "About", action = "Index" });

// Маршрут для контроллера для героев
app.MapControllerRoute(
    name: "heroes",
    pattern: "heroes/{action}",
    defaults: new { controller = "Heroes" });

// Маршрут для контроллера поиска
app.MapControllerRoute(
    name: "people_search",
    pattern: "people_search/{action=Index}/{category?}",
    defaults: new { controller = "PeopleSearch", action = "Index" });

// Маршрут для контроллера для героев
app.MapControllerRoute(
    name: "memory",
    pattern: "memory/{action}",
    defaults: new { controller = "Memory" });

app.Run();
