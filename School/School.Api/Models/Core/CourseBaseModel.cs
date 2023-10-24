namespace School.Api.Models.Core
{
    public class CourseBaseModel : ModelBase
    {
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
    }
}
