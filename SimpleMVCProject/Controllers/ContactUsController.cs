using SimpleMVCProject.Models;
using SimpleMVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCProject.Controllers
{
    public class ContactUsController : Controller
    {
        private POSDBContext posDBContext;

        public ContactUsController()
        {
            posDBContext = new POSDBContext();
        }


        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactUsViewModel contactUsViewModel)
        {
            ContactUsModel contactUsModel = new ContactUsModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = contactUsViewModel.Name,
                Email = contactUsViewModel.Email,
                Message = contactUsViewModel.Message
            };
            posDBContext.ContactUs.Add(contactUsModel);
            int result = posDBContext.SaveChanges();
            if (result > 0)
            {
                ViewBag.result = "Send successfully.";
            }
            else
            {
                ViewBag.result = "Send failed.";
            }

            return View();
        }
    }
}