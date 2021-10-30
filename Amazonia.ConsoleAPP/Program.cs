using System;
using System.Configuration;
using Amazonia.DAL.Repositorio;
using Amazonia.DAL.Utils;


namespace Amazonia.ConsoleAPP
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Ler valores de ficheiro de configuração
            var valorObtidoPeloMetodo = Exemplo.ObterValorDoConfig("chaveExemplo");
            var chaveExemplo = ConfigurationManager.AppSettings["chaveExemplo"];
            Console.WriteLine($"valor obtido pelo método: {valorObtidoPeloMetodo} valor lido diretamente: {chaveExemplo}");

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


        /// <summary>
        /// Lista Livros
        /// </summary>
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

        }
    }
}
