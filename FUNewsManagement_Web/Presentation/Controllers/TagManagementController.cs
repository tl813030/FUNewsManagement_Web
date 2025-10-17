using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class TagManagementController : Controller
    {
        // GET: TagManagementController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TagManagementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TagManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagManagementController/Create
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

        // GET: TagManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TagManagementController/Edit/5
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

        // GET: TagManagementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TagManagementController/Delete/5
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
