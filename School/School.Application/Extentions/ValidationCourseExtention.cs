using Microsoft.Extensions.Configuration;
using School.Application.Core;
using School.Application.Dtos.Course;
using School.Application.Excepctions;

namespace School.Application.Extentions
{
    public static class ValidationCourseExtention
    {
        public static ServiceResult IsCourseValid(this CourseDtoBase courseDto, IConfiguration configuration) 
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(courseDto.Title))
                throw new CourseServiceException(configuration["MensajeValidaciones:cursoTitleRequerido"]);


            if (courseDto.Title.Length > 100)
                throw new CourseServiceException(configuration["MensajeValidaciones:cursoTitleLongitud"]);

            
            return result;
        }
    }
}
