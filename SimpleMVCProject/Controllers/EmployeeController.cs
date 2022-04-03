using SimpleMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult GetAll()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(EmployeeModel employeeModel)
        //{
        //    ViewBag.Message =$"{employeeModel.EmployeeId} was added with the gender of {employeeModel.Gender} live in {employeeModel.HomeAddress.City}";
        //    return View();
        //}

        [HttpPost]
        public ActionResult Create(IList<string> EmployeeId, IList<string> FirstName)
        {
            ViewBag.Message = EmployeeId.Count();
            return View();
        }
    }
}