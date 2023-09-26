using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace School.Domain.Repository
{
    public interface IInstructorRepository
    {
        void Save(Instructor student);

        void Update(Instructor student);
        void Remove(Instructor student);
        List<Instructor> GetInstructors();
        Instructor GetInstructor (int Id);

        bool Exists(Expression<Func<Instructor, bool>> filter);
    }
}
