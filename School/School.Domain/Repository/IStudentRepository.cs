using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace School.Domain.Repository
{
    public interface IStudentRepository
    {
        void Save(Student student);

        void Update(Student student);
        void Remove(Student student);
        List<Student> GetStudents();
        Student GetStudent(int Id);
        bool Exists(Expression<Func<Student, bool>> filter);

    }
}
