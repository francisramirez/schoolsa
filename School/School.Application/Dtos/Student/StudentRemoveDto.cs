using System;
using School.Application.Dtos.Base;

namespace School.Application.Dtos.Student
{
    public class StudentDtoRemove : DtoBase
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
