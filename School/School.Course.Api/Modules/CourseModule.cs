using Carter;
using School.Application.Contracts;
 

namespace School.Rest.Api.Modules
{
    public class CourseModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("course/getAll", (ICourseService courseService) =>
            {
                var result = courseService.GetAll();

                if (!result.Success)
                    return Results.BadRequest(result);
                else
                    return Results.Ok(result);

            });
        }

        
    }
}
