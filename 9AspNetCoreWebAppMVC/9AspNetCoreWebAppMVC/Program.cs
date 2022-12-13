using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _9AspNetCoreWebAppMVC.Data;
using _9AspNetCoreWebAppMVC.SeedData;
using _9AspNetCoreWebAppMVC.Models;
using _9AspNetCoreWebAppMVC.Data.Services;

var builder = WebApplication.CreateBuilder(args);
//DbContext Configurations

builder.Services.AddDbContext<_9AspNetCoreWebAppMVCContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("_9AspNetCoreWebAppMVCContext") ?? throw new InvalidOperationException("Connection string '_9AspNetCoreWebAppMVCContext' not found.")));
//Services configuration
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IGropsService, GroupsService>();
builder.Services.AddScoped<ICoursesService, CoursesService>();

//builder.Services.AddDbContext<AppDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

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
    pattern: "{controller=Courses}/{action=Index}/{id?}");

app.Run();
