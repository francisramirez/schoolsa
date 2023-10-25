
using System;

namespace School.Application.Dtos.Course
{
    public class CourseDtoGet
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public string? Department { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
