

using System;

namespace School.Application.Dtos.Student
{
    public class StudentDtoUpdate : StudentDtoBase
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
