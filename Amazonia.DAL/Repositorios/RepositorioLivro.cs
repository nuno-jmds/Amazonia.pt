

using System;
using System.Collections.Generic;
using System.Linq;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorio
{
    public class RepositorioLivro : IRepositorio<Livro>
    {

        private List<Livro> ListaLivros;

        public RepositorioLivro()
        {
            ListaLivros = new List<Livro>();
            var livro1 = new LivroDigital();
            livro1.Nome = "Práticas de Python";
            livro1.TamanhoEmMB = 20;
            ListaLivros.Add(livro1);
        }

        public void Criar(Livro obj)
        {
            ListaLivros.Add(obj);
        }

        public Livro Atualizar(string nomeAntigo, string nomeNovo)
        {
            var livroTemporario = ObterPorNome(nomeAntigo);
            livroTemporario.Nome = nomeNovo;
            return livroTemporario;
        }

        public Livro ObterPorNome(string Nome)
        {
            System.Console.WriteLine("ObterPorNome:");
            var resultado = ListaLivros
            .Where(x => x.Nome == Nome)
            .OrderByDescending(x => x.Nome)
            .FirstOrDefault(); ;
            return resultado;
        }

        public List<Livro> ObterTodos()
        {
            return ListaLivros;
        }

        public void Apagar(Livro obj)
        {
            try
            {
                if (obj == null)
                    throw new Exception("Ops");
                else
                    System.Console.WriteLine("Valor do objeto [" + obj + "]");
                System.Console.WriteLine("Cliente a apagar: " + obj);
                ListaLivros.Remove(obj);
            }
            catch
            {
                System.Console.WriteLine("Ops, não conheço esse Livro");
            }
        }
    }

}
