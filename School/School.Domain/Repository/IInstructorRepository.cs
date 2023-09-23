using School.Domain.Entities;

using System.Collections.Generic;

namespace School.Domain.Repository
{
    public interface IInstructorRepository
    {
        void Save(Instructor student);

        void Update(Instructor student);
        void Remove(Instructor student);
        List<Instructor> GetInstructors();
        Instructor GetInstructor (int Id);
    }
}
