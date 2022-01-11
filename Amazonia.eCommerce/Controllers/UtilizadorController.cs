using Amazonia.eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.eCommerce.Controllers
{
    public class UtilizadorController : Controller
    {
        private readonly List<Utilizador> utilizadores;

        public UtilizadorController()
        {
            utilizadores = new List<Utilizador> {
        new Utilizador{ Id=Guid.NewGuid(),Login="joao.santos",Nome="João da Silva",PalavraPasse="c0e1cc7528f15445848a2d0bc6f58302"},
            new Utilizador{ Id=Guid.NewGuid(),Login="joao.Vitor",Nome="João Vitor",PalavraPasse="edccb47b1fef3426883aea5cd62f69b7"},
        };
        
        
        }


        public IActionResult CriarUtilizador()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CriarUtilizador(Utilizador utilizador)
        {

            utilizadores.Add(utilizador);
            return View(utilizador);
        }

        private string ObterHashMD5(string palavraPasse)
        {
            var result = new StringBuilder();
            using (var md5Hash = MD5.Create())
            {
                byte[] data =md5Hash.ComputeHash(Encoding.UTF8.GetBytes(palavraPasse));
                result = new StringBuilder(data.Length * 2);

                for(int i=0;i<data.Length;i++)
                {
                    result.Append(data[i].ToString("x2"));

                }

                return result.ToString();
            };

        }

        private bool ValidarLoginSenha(string login, string password)
        {

            var hashCalculado = "";
            var utilizador = utilizadores.FirstOrDefault(x => x.Login == login && x.PalavraPasse == hashCalculado);

            if (utilizador == null)
                return false;

            HttpContext.Response.Cookies.Append("NomeUtilizador", utilizador.Nome);
            return true;
        }

        [HttpGet]
        [Route("EfetuarLogin")]
        public IActionResult EfetuarLogin(string login,string password)
        {

            var resultado = ValidarLoginSenha(login, password);
            return View(resultado);
        }



        //Crud
        [HttpGet]
        public IActionResult ListagemDeUtilizadores()
        {

            return View(utilizadores);
                }


    }                                                                                                                                                                                                                                                    
}
