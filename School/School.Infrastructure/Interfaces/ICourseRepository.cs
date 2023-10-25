using System.Collections.Generic;
using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Models;

namespace School.Infrastructure.Interfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        List<CourseDeparmentModel> GetCoursesByDepartmentId(int departmentId);
        List<CourseDeparmentModel> GetCoursesDeparments();

        CourseDeparmentModel GetCourseDeparment(int Id);

    }
}
