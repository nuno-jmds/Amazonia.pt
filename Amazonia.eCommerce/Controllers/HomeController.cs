using Amazonia.eCommerce.Models;
using Amazonia.eCommerceRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.eCommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ListagemProdutos()
        {
            var prod = new List<Product> { new Product { Id = 1, Name = "exemplo" } };
            return View(prod);
        }


        public ContentResult Message()
        {
            return Content("Exemplo");
        }

        public IActionResult Demonstracao()
        {
            ViewBag.PrecoDosProdutos = new Dictionary<string, double>();
            ViewBag.PrecoDosProdutos.Add("Arroz", 12.2d);
            ViewBag.PrecoDosProdutos.Add("Feijao", 5.2d);
            ViewBag.PrecoDosProdutos.Add("Milho", 3.2d);

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
