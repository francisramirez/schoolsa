

using School.Application.Dtos.Base;
 

namespace School.Application.Dtos.Course
{
    public class CourseDtoRemove : DtoBase
    {
        public int CourseID { get; set; }
        public bool Deleted { get; set; }

    }
}
