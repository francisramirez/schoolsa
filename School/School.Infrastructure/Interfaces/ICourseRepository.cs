using System.Collections.Generic;
using School.Domain.Entities;
using School.Domain.Repository;


namespace School.Infrastructure.Interfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        List<Course> GetCoursesByDepartmentId(int departmentId);
    }
}
