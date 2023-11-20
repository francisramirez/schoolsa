using Microsoft.AspNetCore.Mvc;
using School.Application.Contracts;

namespace School.MinimalApi.Modules
{
    public static class StudentModule
    {
        public static void AddStudentsEndPoints(this IEndpointRouteBuilder endpointRoute) 
        {
            endpointRoute.MapGet("/student/get", (IStudentService studentService) =>
            {
                var result = studentService.GetAll();

                return Results.Ok(result);

            }).WithName("GetStudents");

            endpointRoute.MapGet("/student/getbyid", (IStudentService studentService, [FromForm] int Id) => {

                var result = studentService.GetById(Id);

                if (!result.Success)
                    return Results.BadRequest(result);
                else
                    return Results.Ok(result);

            });
        }
    }
}
