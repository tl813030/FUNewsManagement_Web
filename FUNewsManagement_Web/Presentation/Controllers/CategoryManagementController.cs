using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CategoryManagementController : Controller
    {
        // GET: CategoryManagementController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoryManagementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryManagementController/Create
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

        // GET: CategoryManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryManagementController/Edit/5
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

        // GET: CategoryManagementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryManagementController/Delete/5
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
