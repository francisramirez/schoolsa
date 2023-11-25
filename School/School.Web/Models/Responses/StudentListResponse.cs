namespace School.Web.Models.Responses
{
    public class StudentListResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<StudentViewResult> data { get; set; }
    }
    public class StudentViewResult
    {
        public int studentId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime enrollmentDate { get; set; }
        public DateTime creationDate { get; set; }
    }
}
