

using School.Domain.Entities;
using School.Domain.Repository;
using System.Collections.Generic;

namespace School.Infrastructure.Interfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        List<Course> GetCoursesByDepartmentId(int departmentId);
    }
}
