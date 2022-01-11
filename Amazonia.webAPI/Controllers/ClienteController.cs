
using Amazonia.DAL.Modelo;
using Amazonia.DAL.Repositorio;
using Amazonia.webAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.webAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        readonly RepositorioCliente repo;
        public ClienteController()
        {
            repo = new RepositorioCliente();
        }
          /// <summary>
        /// Listagem de Clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Cliente> GetClientes()
        {
            return repo.ObterTodos();
        }

        /// <summary>
        /// Obtem Cliente Especifico pelo nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("{nome}")]
        public Cliente GetClientePorNome(string nome)
        {
            return repo.ObterPorNome(nome);
        }

        [HttpGet]
        [Route("api/[controller]/ObterClientes")]
        public Dictionary<string, int> ObterQuantidadeClientesNovo()
        {
            var result = new Dictionary<string, int> {

                {"Domingo",10 },
                 {"Segunda",05 }
            };


                return result;
        }


        [HttpPost]
        public Guid PostClienteNovo(string nome, DateTime dataNascimento, string nif)
        {
            var clienteNovo = new Cliente
            {
                Nome = nome,
                DataNascimento = dataNascimento,
                NumeroIdentificacaoFiscal = nif
            };

            repo.Criar(clienteNovo);
            return clienteNovo.Id;
        }

        [HttpDelete]
        public bool DeleteClientePorNome(string nome)
        {
            var cli = repo.ObterPorNome(nome);
            if (cli == null)
            {
                return false;
            }

            repo.Apagar(cli);
            return true;
        }

        [HttpPut]
        public bool UpdateClientePorNome(string nome, ClienteDto dadosNovos)
        {
            var cli = repo.ObterPorNome(nome);
            if (cli == null)
            {
                return false;
            }

            repo.Atualizar(nome, dadosNovos.Nome);
            return true;
        }

    }


}
