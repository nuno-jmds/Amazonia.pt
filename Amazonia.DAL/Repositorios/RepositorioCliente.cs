using System;
using System.Collections.Generic;
using System.Linq;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Infraestrutura;

namespace Amazonia.DAL.Repositorio
{




    public class RepositorioCliente : IRepositorio<Cliente>
    {

        private readonly List<Cliente> ListaClientes;
        public RepositorioCliente()
        {
            ListaClientes = new List<Cliente>();
            var joao = new Cliente();
            joao.Nome = "João";
            joao.DataNascimento = new System.DateTime(1984, 05, 29);

            var maria = new Cliente { Nome = "Maria", DataNascimento = new System.DateTime(1950, 01, 01) };
            var marta = new Cliente { Nome = "Marta", DataNascimento = new DateTime(2021, 01, 02) };



            ListaClientes.Add(joao);
            ListaClientes.Add(maria);
            ListaClientes.Add(marta);


        }

        public void Criar(Cliente obj)
        {
            ListaClientes.Add(obj);
        }

        public Cliente Atualizar(string nomeAntigo, string nomeNovo)
        {
            var clienteTemporario = ObterPorNome(nomeAntigo);
            clienteTemporario.Nome = nomeNovo;

            return clienteTemporario;
        }
        public Cliente ObterPorNome(string Nome)
        {
            System.Console.WriteLine("ObterPorNome:");
            var resultado = ListaClientes
            .Where(x => x.Nome == Nome)
            .OrderByDescending(x => x.Idade)
            .FirstOrDefault();
            return resultado;
        }
        public List<Cliente> ObterTodos()
        {
            return ListaClientes;
        }
        public void Apagar(Cliente obj)
        {
            try
            {
                if (obj == null)
                    throw new ArgumentNullException("Ops");
                else
                    System.Console.WriteLine("Valor do objeto [" + obj + "]");

                System.Console.WriteLine("Cliente a apagar: " + obj);
                ListaClientes.Remove(obj);
            }
            catch
            {
                System.Console.WriteLine("Ops, não conheço essa pessoa");
            }

        }





        //Obter pro filtros

        public List<Cliente> ObterTodosQueComecemPor(string comeco)
        {
            var resultado = ListaClientes.Where(x => x.Nome.StartsWith(comeco)).ToList();
            return resultado;

        }

        public List<Cliente> ObterTodosQueTenhamPeloMenos18Anos()
        {
            System.Console.WriteLine("ObterTodosQueTenhamPeloMenos18Anos");
            var resultado = ListaClientes.Where(x => x.Idade >= 18).ToList();
            return resultado;

        }

        public List<Cliente> ObterTodosQueTenhamPeloMenos18AnosEComecePor(string letra)
        {
            System.Console.WriteLine("ObterTodosQueTenhamPeloMenos18AnosEComecePor");
            var resultado = ListaClientes.Where(x => x.Idade >= 18 && x.Nome.StartsWith(letra)).ToList();
            //var resultado = ListaCliente.Where(x => x.Idade >= 18).Where(x => x.Nome.StartsWith(letra)).ToList()
            return resultado;

        }

        public List<string> ObterNomeTodosQueTenhamPeloMenos18AnosEComecePor(string letra)
        {

            var resultado = ListaClientes //conjunto pesquisa
            .Where(x => x.Idade >= 18 && x.Nome.StartsWith(letra)) //filtro
            .Select(x => x.Nome.ToUpper()) //Saida
            .ToList();
            return resultado;
        }

        public static void GerarRelatorio()
        {
            IImpressora impressora= new ImpressoraPapel();
            impressora.Imprimir();
        }
    }


}