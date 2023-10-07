
using School.Domain.Entities;
using School.Infrastructure.Context;
using School.Infrastructure.Core;
using School.Infrastructure.Interfaces;
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

        public List<Course> GetCoursesByDepartment(int departmentId)
        {
            return this.context.Courses.Where(cd => cd.DepartmentID == departmentId 
                                              && !cd.Deleted).ToList();
        }
        public override List<Course> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Deleted).ToList();
        }
    }
}
