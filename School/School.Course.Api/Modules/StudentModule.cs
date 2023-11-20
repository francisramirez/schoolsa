using Carter;
using Microsoft.AspNetCore.Mvc;
using School.Application.Contracts;

namespace School.Rest.Api.Modules
{
    public class StudentModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/student/get", (IStudentService studentService) =>
            {
                var result = studentService.GetAll();

                return Results.Ok(result);

            }).WithName("GetStudents");

            app.MapGet("/student/getbyid", (IStudentService studentService, [FromForm] int Id) => {

                var result = studentService.GetById(Id);

                if (!result.Success)
                    return Results.BadRequest(result);
                else
                    return Results.Ok(result);

            }).WithName("GetStudentById");

        }
    }
}
