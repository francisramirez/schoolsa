

using Microsoft.Extensions.DependencyInjection;
using School.Application.Contracts;
using School.Application.Services;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Repositories;

namespace School.Ioc.Dependencies
{
    public static class CourseDependency
    {
        public static void AddCourseDependecy(this IServiceCollection service)
        {
            service.AddScoped<ICourseRepository, CourseRepository>();
            service.AddTransient<ICourseService, CourseService>();
        }
    }
}
