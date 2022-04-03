using SimpleMVCProject.Models;
using SimpleMVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCProject.Controllers
{
    public class TownshipController : Controller
    {
        POSDBContext posDBContext;

        public TownshipController()
        {
            posDBContext = new POSDBContext();
        }

        // GET: Township
        public ActionResult List()
        {
            List<TownshipViewModel> townshipViewModels = (from t in posDBContext.Townships
                                                          join c in posDBContext.Cities on t.CityId equals c.Id
                                                          select new TownshipViewModel
                                                          {
                                                              Id = t.Id,
                                                              Name = t.Name,
                                                              ZipCode = t.ZipCode,
                                                              CityId = t.CityId,
                                                              CityName = c.Name
                                                          }).ToList();
            return View(townshipViewModels);
        }

        public ActionResult Entry()
        {
            List<CityViewModel> cityList = posDBContext.Cities.Select(x => new CityViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return View(cityList);
        }

        [HttpPost]
        public ActionResult Entry(TownshipViewModel townshipViewModel)
        {
            TownshipModel townshipModel = new TownshipModel()
            {
                Id = Guid.NewGuid().ToString(),
                Name = townshipViewModel.Name,
                ZipCode = townshipViewModel.ZipCode,
                CityId = townshipViewModel.CityId
            };
            posDBContext.Townships.Add(townshipModel);
            int result = posDBContext.SaveChanges();
            if (result > 0)
            {
                return RedirectToAction("List");
            }
            return View();
        }
    }
}