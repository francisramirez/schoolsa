using Microsoft.EntityFrameworkCore;
using School.Domain.Repository;
using School.Infrastructure.Context;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Contexto //

builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));


// Repositories //

builder.Services.AddTransient<IInstructorRepository, InstructorRepository>();

// App Services //




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
