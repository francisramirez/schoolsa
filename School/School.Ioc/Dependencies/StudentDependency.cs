

using Microsoft.Extensions.DependencyInjection;
using School.Application.Contracts;
using School.Application.Services;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repositories;

namespace School.Ioc.Dependencies
{
    public static class StudentDependency
    {
        public static void AddStudentDependecy(this IServiceCollection service) 
        {
            service.AddScoped<IStudentRepository, StudentRepository>();
            service.AddTransient<IStudentService, StudentService>();
        }
    }
}
