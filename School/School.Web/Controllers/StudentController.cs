using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Application.Contracts;
using School.Application.Core;
using School.Application.Dtos.Student;

namespace School.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var result = this.studentService.GetAll();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return View(result.Data);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var result = this.studentService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            return View(result.Data);
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
            ServiceResult result = new ServiceResult();

            try
            {

                result = this.studentService.Save(studentDtoAdd);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = this.studentService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var datos = (StudentDtoGetAll)result.Data;

            StudentDtoUpdate studentDto = new StudentDtoUpdate()
            {
                Id = datos.StudentId,
                EnrollmentDate = datos.EnrollmentDate,
                FirstName = datos.FirstName,
                LastName = datos.LastName
            };

            return View(studentDto);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentDtoUpdate studentDtoUpdate)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result = this.studentService.Update(studentDtoUpdate);

                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = result.Message;
                return View();
            }
        }


    }
}
