using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class AccountManagementController : Controller
    {
        // GET: AccountManagementController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountManagementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountManagementController/Create
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

        // GET: AccountManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountManagementController/Edit/5
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

        // GET: AccountManagementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountManagementController/Delete/5
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
