using School.Domain.Entities;
using System.Collections.Generic;


namespace School.Domain.Repository
{
    public interface ICourseRepository
    {
        void Save(Course student);

        void Update(Course student);
        void Remove(Course student);
        List<Course> GetCourses();
        Course GetCourse(int Id);
    }
}
