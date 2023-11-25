using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using School.Application.Contracts;
using School.Application.Core;
using School.Application.Dtos.Student;
using School.Web.Models.Responses;

namespace School.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        HttpClientHandler clientHandler = new HttpClientHandler();

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            StudentListResponse studentList = new StudentListResponse();


            using (var client = new HttpClient(this.clientHandler))
            {
                using (var response = client.GetAsync("http://localhost:5214/api/Student/GetStudents").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        studentList = JsonConvert.DeserializeObject<StudentListResponse>(apiResponse);

                        if (!studentList.success)
                        {
                            ViewBag.Message = studentList.message;
                            return View();
                        }


                    }
                    else
                    {
                        studentList.message = "Error conectandose al api.";
                        studentList.success = false;
                        ViewBag.Message = studentList.message;
                        return View();
                    }
                }
            }

            return View(studentList.data);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {

            StudentDetailResponse studentDetailResponse = new StudentDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5214/api/Student/GetStudent?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        studentDetailResponse = JsonConvert.DeserializeObject<StudentDetailResponse>(apiResponse);

                        if (!studentDetailResponse.success)
                            ViewBag.Message = studentDetailResponse.message;
                        

                    }
                }
            }


            return View(studentDetailResponse.data);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDtoAdd studentDtoAdd)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5214/api/Student/SaveStudent";

                    studentDtoAdd.ChangeDate = DateTime.Now;
                    studentDtoAdd.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(studentDtoAdd), System.Text.Encoding.UTF8, "application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }

                        }
                        else
                        {
                            baseResponse.message = "Error conectandose al api.";
                            baseResponse.success = false;
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            StudentDetailResponse studentDetailResponse = new StudentDetailResponse();


            using (var client = new HttpClient(this.clientHandler))
            {

                var url = $"http://localhost:5214/api/Student/GetStudent?id={id}";

                using (var response = client.GetAsync(url).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        studentDetailResponse = JsonConvert.DeserializeObject<StudentDetailResponse>(apiResponse);

                    }
                }
            }


            return View(studentDetailResponse.data);
        }


        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentDtoUpdate studentDtoUpdate)
        {
            BaseResponse baseResponse = new BaseResponse();

            try
            {

                using (var client = new HttpClient(this.clientHandler))
                {

                    var url = $"http://localhost:5214/api/Student/UpdateStudent";

                    studentDtoUpdate.ChangeDate = DateTime.Now;
                    studentDtoUpdate.ChangeUser = 1;

                    StringContent content = new StringContent(JsonConvert.SerializeObject(studentDtoUpdate), System.Text.Encoding.UTF8,"application/json");

                    using (var response = client.PostAsync(url, content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            baseResponse = JsonConvert.DeserializeObject<BaseResponse>(apiResponse);

                            if (!baseResponse.success)
                            {
                                ViewBag.Message = baseResponse.message;
                                return View();
                            }

                        }
                        else
                        {
                            ViewBag.Message = baseResponse.message;
                            return View();
                        }
                    }
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = baseResponse.message;
                return View();
            }
        }


    }
}
