using Amazonia.DAL.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.eCommerce.Controllers
{
    public class LivroController : Controller
    {
        List<Livro> livros;
        // GET: LivroController
        public ActionResult Index()
        {
            var livros = new List<Livro>();
            return View(livros);
        }

        // GET: LivroController/Details/5
        public ActionResult Details(Guid id)
        {
            var livro = livros.FirstOrDefault(x => x.Id == id);
            return View(livro);
        }

    }
}
