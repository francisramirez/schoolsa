

using School.Domain.Core;
using System;

namespace School.Domain.Entities
{
    public class Student : Person
    {
        public DateTime? EnrollmentDate { get; set; }
    }
}
