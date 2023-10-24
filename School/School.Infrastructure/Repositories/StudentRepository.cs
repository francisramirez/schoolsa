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
    public class StudentRepository : BaseRepository<Student> ,IStudentRepository
    {
        private readonly SchoolContext context;

        public StudentRepository(SchoolContext context): base(context)
        {
            this.context = context;
        }

        public override void Save(Student entity)
        {
            context.Students.Add(entity);
            context.SaveChanges();
        }
        public override void Update(Student entity)
        {
            var studentToUpdate = base.GetEntity(entity.Id);

            studentToUpdate.FirstName = entity.FirstName;
            studentToUpdate.LastName = entity.LastName;
            studentToUpdate.EnrollmentDate = entity.EnrollmentDate;
            studentToUpdate.ModifyDate = entity.ModifyDate;
            studentToUpdate.UserMod = entity.UserMod;

            context.Students.Update(studentToUpdate);
            context.SaveChanges();

        }
        public override void Remove(Student entity)
        {
            var studentToRemove = base.GetEntity(entity.Id);

            studentToRemove.Id = entity.Id;
            studentToRemove.Deleted = entity.Deleted;
            studentToRemove.DeletedDate = entity.DeletedDate;
            studentToRemove.UserDeleted = entity.UserDeleted;

            this.context.Students.Update(studentToRemove);
            this.context.SaveChanges();

        }

        public override List<Student> GetEntities()
        {
            return this.context.Students.Where(st => !st.Deleted)
                                        .OrderByDescending(st => st.CreationDate)
                                        .ToList();
        }
    }


   

}
