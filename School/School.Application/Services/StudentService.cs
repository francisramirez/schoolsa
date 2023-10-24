using Microsoft.Extensions.Logging;
using School.Application.Contracts;
using School.Application.Core;
using School.Application.Dtos.Student;
using School.Infrastructure.Interfaces;
using System.Linq;
using System;
using School.Domain.Entities;
using School.Application.Response;

namespace School.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly ILogger<StudentService> logger;

        public StudentService(IStudentRepository studentRepository,
                              ILogger<StudentService> logger)
        {
            this.studentRepository = studentRepository;
            this.logger = logger;
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
          //  ServiceResult result = new ServiceResult();
            StudentResponse result = new StudentResponse();

            try
            {
                Student student = new Student()
                {
                    CreationDate = dtoAdd.ChangeDate,
                    CreationUser = dtoAdd.ChangeUser,
                    EnrollmentDate = dtoAdd.EnrollmentDate,
                    FirstName = dtoAdd.FirstName,
                    LastName = dtoAdd.LastName
                };

                this.studentRepository.Save(student);

                result.Message = "El estudiante fue creado correctamente.";
                result.StudentId = student.Id;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error guardando el estudiante.";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult Update(StudentDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {

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
