
using School.Domain.Entities;
using School.Infrastructure.Context;
using School.Infrastructure.Core;
using School.Infrastructure.Interfaces;
using School.Infrastructure.Models;
using System.Collections.Generic;
using System.Linq;

namespace School.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly SchoolContext context;

        public CourseRepository(SchoolContext context): base(context)
        {
            this.context = context;
        }

        public CourseDeparmentModel GetCourseDeparment(int Id)
        {
            return this.GetCoursesDeparments().SingleOrDefault(co => co.CourseId == Id);
        }

        public List<Course> GetCoursesByDepartment(int departmentId)
        {
            return this.context.Courses.Where(cd => cd.DepartmentID == departmentId 
                                              && !cd.Deleted).ToList();
        }

        public List<CourseDeparmentModel> GetCoursesByDepartmentId(int departmentId)
        {
            throw new System.NotImplementedException();
        }

        public List<CourseDeparmentModel> GetCoursesDeparments()
        {
          
            var courses = (from co in this.GetEntities()
                           join depto in this.context.Departments on co.DepartmentID equals depto.DepartmentID
                           where !co.Deleted
                           select new CourseDeparmentModel()
                           {
                               CourseId = co.CourseID,
                               Credits = co.Credits,
                               Title = co.Title,
                               DepartmentId = co.DepartmentID,
                               Department = depto.Name,
                               CreationDate = co.CreationDate
                           }).ToList();


            return courses;
        }

        public override List<Course> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }

        public override void Save(Course entity)
        {
            base.Save(entity);
            this.context.SaveChanges();
        }
        public override void Update(Course entity)
        {

            Course course = this.GetEntity(entity.CourseID);

            course.Title = entity.Title;
            course.Credits = entity.Credits;
            course.DepartmentID = entity.DepartmentID;
            course.ModifyDate = entity.ModifyDate;
            course.UserMod = entity.UserMod;


            this.context.Courses.Update(course);
            this.context.SaveChanges();
        }

        public override void Remove(Course entity)
        {
            Course course = this.GetEntity(entity.CourseID);

            course.CourseID = entity.CourseID;
            course.Deleted = entity.Deleted;
            course.DeletedDate = entity.DeletedDate;
            course.UserDeleted = entity.UserDeleted;

            this.context.Courses.Update(course);

            this.context.SaveChanges();



        }


    }
}
