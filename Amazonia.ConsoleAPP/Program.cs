using System;
using System.Configuration;
using Amazonia.DAL.Repositorio;


namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            var chaveExemplo = ConfigurationManager.AppSettings["chaveExemplo"];

            var usarRegraNovaStr = ConfigurationManager.AppSettings["regraNovaAtiva"];
            var usarRegraNova = Convert.ToBoolean(usarRegraNovaStr);

            //FeatureFlags
            if (usarRegraNova)
            {
                ListarClientes();
            }
            else
            {
                ListarLivros();
            }


        }

        public static void ListarLivros()
        {
            var repoLivros = new RepositorioLivro();
            var listaLivros = repoLivros.ObterTodos();
            foreach (var item in listaLivros)
            {
                Console.WriteLine(item);
            }
        }

        public static void ListarClientes()
        {
            var repo = new RepositorioCliente();
            var listaClientes = repo.ObterTodos();
            foreach (var item in listaClientes)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Consulta lista com M");
            var listaClientesM = repo.ObterTodosQueComecemPor("M");
            foreach (var item in listaClientesM)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Consulta lista com maiores de 18");
            var listaClientes18 = repo.ObterTodosQueTenhamPeloMenos18Anos();
            foreach (var item in listaClientes18)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Obter por nome");
            var joao = repo.ObterPorNome("João");
            var clienteNovo = repo.Atualizar(joao.Nome, "Joao da Silva");
            System.Console.WriteLine(clienteNovo);

            var listagemTotal = repo.ObterTodos();
            Console.WriteLine($"Data Base contem {listagemTotal.Count} clientes");

            repo.Apagar(joao);

            var listagemTotal2 = repo.ObterTodos();
            Console.WriteLine($"Data Base contem {listagemTotal2.Count} clientes");

            // do
            // {

            //     var novoCliente = new Cliente();
            //     Console.WriteLine("Nome:");

            //     novoCliente.Nome = Console.ReadLine();

            //     repo.Criar(novoCliente);


            // } while (Console.ReadKey().Key != ConsoleKey.Tab);




            // var listaClientesNovosEAntigos = repo.ObterTodos();
            // foreach (var item in listaClientesNovosEAntigos)
            // {
            //     Console.WriteLine(item);



            // }

        }
    }
}
