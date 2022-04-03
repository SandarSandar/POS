using SimpleMVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult GetAll()
        {
            ProductModel productModel = new ProductModel()
            {
                ProductId = 101,
                ProductName = "HP",
                UnitPrice = 1000000
                
            };
            ViewData["ProductData"] = productModel;
            return View("List");
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel productModel)
        {
            string productStatus = $"{productModel.ProductId} is created";
            ViewBag.Message = productStatus;
            TempData["ProductIdForDashboard"] = productStatus;
            return View();
        }
    }
}