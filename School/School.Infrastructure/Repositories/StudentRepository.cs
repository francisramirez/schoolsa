using Microsoft.EntityFrameworkCore.Internal;
using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace School.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext context;

        public StudentRepository(SchoolContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<Student, bool>> filter)
        {
            return this.context.Students.Any(filter);
        }

        public Student GetStudent(int Id)
        {
            return this.context.Students.Find(Id);
        }

        public List<Student> GetStudents()
        {
            return this.context.Students.Where(st => !st.Deleted).ToList();
        }

        public void Remove(Student student)
        {
             this.context.Students.Remove(student);
        }

        public void Save(Student student)
        {
            this.context.Students.Add(student);
        }

        public void Update(Student student)
        {
            this.context.Students.Update(student);
        }
    }
   
}
