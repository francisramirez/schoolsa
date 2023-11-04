using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Context;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repositories;
using School.Ioc.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Contexto //

builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));


builder.Services.AddStudentDependecy();

builder.Services.AddCourseDependecy();



builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
