

using System;

namespace School.Application.Dtos.Student
{
    public class StudentDtoGetAll
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
