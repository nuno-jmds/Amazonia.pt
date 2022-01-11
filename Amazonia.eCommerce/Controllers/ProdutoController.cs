using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.eCommerce.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.valor = 10;
            return View();
        }

        public IActionResult Listar()
        {

            ViewBag.valor = 10;
            return View();
        }
    }
}
