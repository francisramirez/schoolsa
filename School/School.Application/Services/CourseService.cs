﻿
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using School.Application.Contracts;
using School.Application.Core;
using School.Application.Dtos.Course;
using School.Application.Excepctions;
using School.Domain.Entities;
using School.Infrastructure.Interfaces;
using School.Application.Extentions;

namespace School.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly ILogger<CourseService> logger;
        private readonly IConfiguration configuration;

        public CourseService(ICourseRepository courseRepository,
                             ILogger<CourseService> logger, IConfiguration configuration)
        {
            this.courseRepository = courseRepository;
            this.logger = logger;
            this.configuration = configuration;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.courseRepository.GetCoursesDeparments();
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo los cursos.";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = this.courseRepository.GetCourseDeparment(Id);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error obteniendo el curso";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }


        public ServiceResult Remove(CourseDtoRemove dtoRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Course course = new Course()
                {
                    CourseID = dtoRemove.CourseID,
                    Deleted = dtoRemove.Deleted,
                    UserDeleted = dtoRemove.ChangeUser,
                    DeletedDate = dtoRemove.ChangeDate
                };

                this.courseRepository.Remove(course);

                result.Message = "El curso fue removido correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error removiendo el curso";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Save(CourseDtoAdd dtoAdd)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                var validresult = dtoAdd.IsCourseValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }

                Course course = new Course()
                {
                    Title = dtoAdd.Title,
                    Credits = dtoAdd.Credits,
                    DepartmentID = dtoAdd.DepartmentId,
                    CreationDate = dtoAdd.ChangeDate,
                    CreationUser = dtoAdd.ChangeUser
                };

                this.courseRepository.Save(course);

                result.Message = "El curso fue guardado correctamente.";
            }
            catch (CourseServiceException cex) 
            {
                result.Success = false;
                result.Message = cex.Message;
                this.logger.LogError($"{result.Message}", cex.ToString());
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error guardando el curso";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }

        public ServiceResult Update(CourseDtoUpdate dtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var validresult = dtoUpdate.IsCourseValid(this.configuration);

                if (!validresult.Success)
                {
                    result.Message = validresult.Message;
                    result.Success = validresult.Success;
                    return result;
                }


                Course course = new Course()
                {
                    CourseID = dtoUpdate.CourseID,
                    Credits = dtoUpdate.Credits,
                    DepartmentID = dtoUpdate.DepartmentId,
                    ModifyDate = dtoUpdate.ChangeDate,
                    UserMod = dtoUpdate.ChangeUser,
                    Title = dtoUpdate.Title
                };

                this.courseRepository.Update(course);

                result.Message = "El curso fue actualizado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Error actualizando el curso";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }

            return result;
        }
    }
}
