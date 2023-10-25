

using School.Application.Dtos.Base;

namespace School.Application.Dtos.Course
{
    public class CourseDtoBase : DtoBase
    {
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

    }
}
