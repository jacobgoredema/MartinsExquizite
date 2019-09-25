using MartinsExquizite.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MartinsExquizite.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View(new ContactUsVm());
        }

        [HttpPost]
        public ActionResult Contact(ContactUsVm vm)
        {
            if (ModelState.IsValid)
            {
                vm.SendMail();
                ViewBag.Message = vm.Message;

                return RedirectToAction("Success", "Home");
            }
            return View(vm);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}