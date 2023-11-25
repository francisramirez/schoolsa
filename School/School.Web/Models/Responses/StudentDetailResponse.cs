namespace School.Web.Models.Responses
{
    public class StudentDetailResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public StudentViewResult data { get; set; }
    }
}
