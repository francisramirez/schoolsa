using School.Api.Models.Core;

namespace School.Api.Models.Modules.Student
{
    public abstract class StudentBaseModel : ModelBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }

    }
}
