using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {

        public class Vendas
        {
            public string quantidade { get; set; }
        }


        [HttpGet]
        public Vendas GetNumeroVendas()
        {
            var Vendas = new Vendas();
            Vendas.quantidade = "50";
            Console.WriteLine("Estou aqui");
            return Vendas ;
        }
    }
}
