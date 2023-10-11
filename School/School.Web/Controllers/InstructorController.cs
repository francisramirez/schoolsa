using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Repository;

namespace School.Web.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository instructorRepository;

        public InstructorController(IInstructorRepository instructorRepository)
        {
            this.instructorRepository = instructorRepository;
        }
        // GET: InstructorController
        public ActionResult Index()
        {
            var instructors = this.instructorRepository.GetInstructors();
            return View(instructors);
        }

        // GET: InstructorController/Details/5
        public ActionResult Details(int id)
        {
            var instructor = this.instructorRepository.GetInstructor(id);
            return View(instructor);
            
        }

        // GET: InstructorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InstructorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InstructorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
