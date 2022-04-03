using SimpleMVCProject.Models;
using SimpleMVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCProject.Controllers
{
    public class CityController : Controller
    {
        private POSDBContext posDBContext;

        public CityController()
        {
            posDBContext = new POSDBContext();
        }

        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CityViewModel cityViewModel)
        {
            CityModel cityModel = new CityModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = cityViewModel.Name
            };
            posDBContext.Cities.Add(cityModel);
            posDBContext.SaveChanges();
            return View();
        }
    }
}