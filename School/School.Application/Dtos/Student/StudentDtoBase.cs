using School.Application.Dtos.Base;

namespace School.Application.Dtos.Student
{
    public abstract class StudentDtoBase : DtoBase
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
    }
}
