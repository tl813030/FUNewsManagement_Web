using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class NewsTagLinkManagementController : Controller
    {
        // GET: NewsTagLinkManagementController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewsTagLinkManagementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsTagLinkManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsTagLinkManagementController/Create
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

        // GET: NewsTagLinkManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsTagLinkManagementController/Edit/5
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

        // GET: NewsTagLinkManagementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsTagLinkManagementController/Delete/5
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
