using Carter;
using Microsoft.EntityFrameworkCore;
using School.Infrastructure.Context;
using School.Ioc.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Agregar dependencia del contexto //

builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));


//Dependecias del modulo de estudiantes //
builder.Services.AddStudentDependecy();


//Dependencias del modulo de cursos //
builder.Services.AddCourseDependecy();


builder.Services.AddCarter();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();

app.Run();

