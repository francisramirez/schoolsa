

using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace School.Infrastructure.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly SchoolContext context;

        public InstructorRepository(SchoolContext context)
        {
            this.context = context;
        }    
        public Instructor GetInstructor(int Id)
        {

            return this.context.Instructors.Find(Id);
        }

        public List<Instructor> GetInstructors()
        {
            return this.context.Instructors.ToList();
        }

        public void Remove(Instructor instructor)
        {
            this.context.Remove(instructor);
        }

        public void Save(Instructor instructor)
        {
            this.context.Instructors.Add(instructor);
        }

        public void Update(Instructor instructor)
        {
            this.context.Update(instructor);
        }
    }
}
