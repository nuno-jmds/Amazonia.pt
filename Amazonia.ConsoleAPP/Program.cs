using System;
using Amazonia.DAL;
using Amazonia.DAL.Repositorio;


namespace Amazonia.ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Consulta do DB");

            var repo = new RepositorioCliente();
            var listaClientes = repo.ObterTodos();

            foreach (var item in listaClientes)
            {
                Console.WriteLine(item);
            }

            do
            {

                var novoCliente = new Cliente();
                Console.WriteLine("Nome");
                novoCliente.Nome = Console.ReadLine();

                repo.Criar(novoCliente);
            } while (Console.ReadKey().Key != ConsoleKey.Tab);

            var listaClientesNovosEAntigos = repo.ObterTodos();
            foreach (var item in listaClientesNovosEAntigos)
            {
                Console.WriteLine(item);



            }

        }
    }
}
