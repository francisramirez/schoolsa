using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace School.Web.Controllers
{
    public class StudentWithHttpClientController : Controller
    {
        // GET: StudentWithHttpClientController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StudentWithHttpClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentWithHttpClientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentWithHttpClientController/Create
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

        // GET: StudentWithHttpClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentWithHttpClientController/Edit/5
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

        // GET: StudentWithHttpClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentWithHttpClientController/Delete/5
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
