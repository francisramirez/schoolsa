
using School.Domain.Entities;

using School.Infrastructure.Context;
using School.Infrastructure.Core;
using School.Infrastructure.Interfaces;


namespace School.Infrastructure.Repositories
{
    public class InstructorRepository   : BaseRepository<Instructor>, IInstructorRepository
    {

        public InstructorRepository(SchoolContext context) : base(context)
        {

        }
       
    }
}
