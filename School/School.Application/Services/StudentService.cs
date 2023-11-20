using Microsoft.Extensions.Logging;
using School.Application.Contracts;
using School.Application.Core;
using School.Application.Dtos.Student;
using School.Infrastructure.Interfaces;
using System.Linq;
using System;
using School.Domain.Entities;
using School.Application.Response;
using Microsoft.Extensions.Configuration;
using School.Application.Excepctions;
using School.Application.Extentions;
namespace School.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly ILogger<StudentService> logger;
        private readonly IConfiguration configuration;

        public StudentService(IStudentRepository studentRepository,
                              ILogger<StudentService> logger,
                              IConfiguration configuration)
        {
            this.studentRepository = studentRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var students = this.studentRepository.GetEntities()
                                                 .Select(st =>
                                                          new StudentDtoGetAll()
                                                          {
                                                              CreationDate = st.CreationDate,
                                                              EnrollmentDate = st.EnrollmentDate,
                                                              FirstName = st.FirstName,
                                                              LastName = st.LastName,
                                                              StudentId = st.Id

                                                          });


                result.Data = students;


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error obteniendo los estudiantes.";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var student = this.studentRepository.GetEntity(Id);

                StudentDtoGetAll studentModel = new StudentDtoGetAll()
                {
                    CreationDate = student.CreationDate,
                    EnrollmentDate = student.EnrollmentDate,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    StudentId = student.Id
                };

                result.Data = studentModel;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error obteniendo el estudiante.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult Remove(StudentDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Student student = new Student()
                {
                    Id = dtoRemove.Id,
                    Deleted = dtoRemove.Deleted,
                    DeletedDate = dtoRemove.ChangeDate,
                    UserDeleted = dtoRemove.ChangeUser
                };

                this.studentRepository.Remove(student);

                result.Message = "El estudiante fue removido.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error removiendo el estudiante.";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult Save(StudentDtoAdd dtoAdd)
        {

            StudentResponse result = new StudentResponse();

            try
            {
                var validResult = dtoAdd.IsStudentValid(this.configuration);


                if (!validResult.Success)
                {
                    result.Success = validResult.Success;
                    result.Message = validResult.Message;
                    return result;
                }


                Student student = new Student()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    CreationUser = dtoAdd.ChangeUser,
                    EnrollmentDate = dtoAdd.EnrollmentDate,
                    FirstName = dtoAdd.FirstName,
                    LastName = dtoAdd.LastName
                };

                this.studentRepository.Save(student);

                result.Message = this.configuration["MensajesEstdianteSuccess:AddSuccessMessage"];
                result.StudentId = student.Id;
            }
            catch (StudentServiceException ssex)
            {
                result.Success = false;
                result.Message = ssex.Message;
                this.logger.LogError(result.Message, ssex.ToString());

            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = this.configuration["MensajesEstdianteSuccess:AddErrorMessage"];
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(StudentDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                var validResult = dtoUpdate.IsStudentValid(this.configuration);


                if (!validResult.Success)
                {
                    result.Success = validResult.Success;
                    result.Message = validResult.Message;
                    return result;
                }


                Student student = new Student()
                {
                    Id = dtoUpdate.Id,
                    EnrollmentDate = dtoUpdate.EnrollmentDate,
                    FirstName = dtoUpdate.FirstName,
                    LastName = dtoUpdate.LastName,
                    ModifyDate = dtoUpdate.ChangeDate,
                    UserMod = dtoUpdate.ChangeUser
                };

                this.studentRepository.Update(student);

                result.Message = "El estudiante fue actualizado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error actualizando el estudiante.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
