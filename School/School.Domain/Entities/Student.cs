

using School.Domain.Core;
using System;

namespace School.Domain.Entities
{
    public class Student : Person
    {
        public int Id { get; set; }
        
        public DateTime? EnrollmentDate { get; set; }
    }
}
