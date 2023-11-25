namespace School.Web.Models.Responses
{
    public class BaseResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }
}
