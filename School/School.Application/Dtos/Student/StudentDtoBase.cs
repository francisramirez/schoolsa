using School.Application.Dtos.Base;
using System;

namespace School.Application.Dtos.Student
{
    public abstract class StudentDtoBase : DtoBase
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? EnrollmentDate { get; set; }

    }
}
