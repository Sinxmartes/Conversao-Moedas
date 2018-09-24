using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Front_Conversao.Models;
using Conversao.Controllers;
using Conversao.Models;

namespace Front_Conversao.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ConversaoViewModel model = new ConversaoViewModel();
            model.CurrenciesList = new ConversionController().currenciesList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(ConversaoViewModel model, string de, string para, string valor)
        {
            var retorno = new ConversionController().currencyConversion(de, para, Convert.ToDouble(valor));
            model.CurrenciesList = new ConversionController().currenciesList();
            TempData["resultado"] = retorno;
            return View(model);
        }
    }
}
