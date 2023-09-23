using School.Domain.Entities;
using School.Domain.Repository;
using System;
using System.Collections.Generic;

namespace School.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository()
        {

        }
        public Student GetStudent(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudents()
        {
            throw new NotImplementedException();
        }

        public void Remove(Student student)
        {
            throw new NotImplementedException();
        }

        public void Save(Student student)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
