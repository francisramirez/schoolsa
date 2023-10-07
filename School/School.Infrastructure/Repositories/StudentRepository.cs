using Microsoft.EntityFrameworkCore.Internal;
using School.Domain.Entities;
using School.Domain.Repository;
using School.Infrastructure.Context;
using School.Infrastructure.Core;
using School.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace School.Infrastructure.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly SchoolContext context;

        public StudentRepository(SchoolContext context) : base(context)
        {
            this.context = context;
        }


    }
}
