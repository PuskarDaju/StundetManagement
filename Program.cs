using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentManagement.Data;

var builder = WebApplication.CreateBuilder(args);


// ✅ 1. Add MVC services
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
var connectionString = "server=127.0.0.1;port=8889;database=studentdb;user=root;password=root";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

// ✅ 2. Enable static files and routing
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();