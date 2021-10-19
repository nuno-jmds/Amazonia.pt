using System;
using System.Collections.Generic;
namespace Amazonia.DAL.Repositorio
{




    public class RepositorioCliente : IRepositorio<Cliente>
    {

        private List<Cliente> ListaCliente;
        public RepositorioCliente()
        {
            ListaCliente = new List<Cliente>();
            var joao = new Cliente();
            joao.Nome = "João";
            joao.DataNascimento = new System.DateTime(1984, 05, 29);

            var maria = new Cliente { Nome = "Maria", DataNascimento = new System.DateTime(1950, 01, 01) };
            var marta = new Cliente { Nome = "Marta", DataNascimento = new DateTime(2021, 01, 02) };

            ListaCliente.Add(joao);
            ListaCliente.Add(maria);
            ListaCliente.Add(marta);


        }
        public void Apagar(Cliente obj)
        {
            throw new System.NotImplementedException();
        }

        public Cliente Atualizar(Cliente obj)
        {
            throw new System.NotImplementedException();
        }

        public void Criar(Cliente obj)
        {
            throw new System.NotImplementedException();
        }

        public Cliente ObterPorNome(string Nome)
        {
            throw new System.NotImplementedException();
        }

        public List<Cliente> ObterTodos()
        {
            return ListaCliente;
        }
    }


}