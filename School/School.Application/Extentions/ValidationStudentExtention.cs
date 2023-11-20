

using Microsoft.Extensions.Configuration;
using School.Application.Core;
using School.Application.Dtos.Student;
using School.Application.Excepctions;

namespace School.Application.Extentions
{
    public static class ValidationStudentExtention
    {
        public static ServiceResult IsStudentValid(this StudentDtoBase dtoBase, IConfiguration configuration) 
        {

            ServiceResult serviceResult = new ServiceResult();

            if (string.IsNullOrEmpty(dtoBase.FirstName))
                throw new StudentServiceException(configuration["MensajeValidaciones:estudianteNombreRequerido"]);


            if (dtoBase.FirstName.Length > 50)
                throw new StudentServiceException(configuration["MensajeValidaciones:estudianteNombreLongitud"]);

            if (string.IsNullOrEmpty(dtoBase.LastName))
                throw new StudentServiceException(configuration["MensajeValidaciones:estudianteApellidoRequerido"]);

            if (dtoBase.LastName.Length > 50)
                throw new StudentServiceException(configuration["MensajeValidaciones:estudianteApellidoLongitud"]);

            if (!dtoBase.EnrollmentDate.HasValue)
                throw new StudentServiceException(configuration["MensajeValidaciones:estudianteEnrollmentDateRequerido"]);



            return serviceResult;
        }
    }
}
