using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentMVCProject.Controllers
{
    public class CurrencyConverterController : Controller
    {
        // GET: CurrencyConverter
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.GreetingMessage = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpPost]
        public ActionResult Converter(string selectFromCurrency, string selectToCurrency, int txtAmount)
        {
            double result = 0.0;
            if (string.IsNullOrEmpty(selectFromCurrency))
            {
                ViewBag.ReturnMessage = "Please select one source currency.";
            }
            else if (string.IsNullOrEmpty(selectToCurrency))
            {
                ViewBag.ReturnMessage = "Please select one destination currency.";
            }
            else
            {            
                switch (selectFromCurrency)
                {
                    case "USD":
                        if (selectToCurrency.Equals("BAHT"))
                        {
                            result = txtAmount * 32.97;
                        }
                        else if (selectToCurrency.Equals("MMK"))
                        {
                            result = txtAmount * 1770;
                        }
                        else if (selectToCurrency.Equals("SGD"))
                        {
                            result = txtAmount * 1.35;
                        }
                        else if (selectToCurrency.Equals("USD"))
                        {
                            result = txtAmount * 1;
                        }
                        break;
                    case "SGD":
                        if (selectToCurrency.Equals("BAHT"))
                        {
                            result = txtAmount * 24.50;
                        }
                        else if (selectToCurrency.Equals("MMK"))
                        {
                            result = txtAmount * 1321.59;
                        }
                        else if (selectToCurrency.Equals("USD"))
                        {
                            result = txtAmount * 0.74;
                        }
                        else if (selectToCurrency.Equals("SGD"))
                        {
                            result = txtAmount * 1;
                        }
                        break;
                    case "MMK":
                        if (selectToCurrency.Equals("BAHT"))
                        {
                            result = txtAmount * 0.019;
                        }
                        else if (selectToCurrency.Equals("SGD"))
                        {
                            result = txtAmount * 0.00076;
                        }
                        else if (selectToCurrency.Equals("USD"))
                        {
                            result = txtAmount * 0.00056;
                        }
                        else if (selectToCurrency.Equals("MMK"))
                        {
                            result = txtAmount * 1;
                        }
                        break;
                    case "BAHT":
                        if (selectToCurrency.Equals("MMK"))
                        {
                            result = txtAmount * 53.94;
                        }
                        else if (selectToCurrency.Equals("SGD"))
                        {
                            result = txtAmount * 0.041;
                        }
                        else if (selectToCurrency.Equals("USD"))
                        {
                            result = txtAmount * 0.030;
                        }
                        else if (selectToCurrency.Equals("BAHT"))
                        {
                            result = txtAmount * 1;
                        }
                        break;
                }
                ViewBag.SelectedFromCurrency = selectFromCurrency.ToString();
                ViewBag.SelectedToCurrency = selectToCurrency.ToString();
                ViewBag.Amount = txtAmount;
                ViewBag.CurrencyResult = result.ToString();
            }
            
            return View("Index");
        }

    }
}