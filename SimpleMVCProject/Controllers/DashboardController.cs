using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCProject.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int firstNum, int secondNum)
        {
            ViewBag.AddResult = firstNum + secondNum;
            return View();
        }


        [ActionName("getSimple")]
        public ActionResult Hi()
        {
            return View("Simple");
        }


        [ActionName("getSimple2")]
        public ActionResult Hi(int firstNum, int secondNum)
        {
            ViewBag.AddResult = firstNum + secondNum;
            return View("Simple");
        }
    }
}