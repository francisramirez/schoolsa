

using School.Domain.Entities;
using School.Infrastructure.Interfaces;
using System.Collections.Generic;

namespace School.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            throw new System.NotImplementedException();
        }

        public List<Course> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Course GetEntity(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Course entity)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Course entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Course entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
