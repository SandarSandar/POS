using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleMVCProject.Controllers
{
    public class ConverterController : Controller
    {
        // GET: Converter
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string selectOneCurrency, int txtAmount)
        {
           if (string.IsNullOrEmpty(selectOneCurrency))
            {
                ViewBag.CurrencyResult = "Please slect one currency to convert";
                return View();
            }

            double result = 0.0;
           switch (selectOneCurrency)
            {
                case "USD": result = txtAmount * 1950; break;
                case "SGD": result = txtAmount * 1300; break;
                case "BAHT": result = txtAmount * 45; break;
            }
            ViewBag.SelectedCurrency = selectOneCurrency;
            ViewBag.Amount = txtAmount;
            ViewBag.CurrencyResult = result;
            return View();
        }

    }
}