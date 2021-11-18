

using System;
using System.Collections.Generic;
using System.Linq;
using Amazonia.DAL.Infraestrutura;
using Amazonia.DAL.Modelo;

namespace Amazonia.DAL.Repositorio
{
    public class RepositorioLivro : IRepositorio<Livro>
    {

        private readonly List<Livro> ListaLivros;

        public RepositorioLivro()
        {
            ListaLivros = new List<Livro>();
            var livro1 = new LivroDigital();
            livro1.Nome = "Práticas de Python";
            livro1.TamanhoEmMB = 20;
            ListaLivros.Add(livro1);
            var lotrImp = new LivroImpresso
            {
                Nome = "O Senhor dos Aneis",
                Autor = "J.R.R. Tolkien"
            };
            ListaLivros.Add(lotrImp);

            var lotrAud = new AudioLivro
            {
                Nome = "O Senhor dos Aneis",
                Autor = "J.R.R. Tolkien",
                DuracaoEmMinutos = 6,
                FormatoFicheiro = "mp3"
            };
            ListaLivros.Add(lotrAud);

            var lotrEbook = new LivroDigital
            {
                Nome = "O Senhor dos Aneis",
                Autor = "J.R.R. Tolkien",
                InformacoesLicenca = "1234567",
                FormatoFicheiro = "PDF",
                TamanhoEmMB = 20
            };
            ListaLivros.Add(lotrEbook);

            var hpImp = new LivroImpresso
            {
                Nome = "Harry Potter",
                Autor = "JK"
            };
            ListaLivros.Add(hpImp);
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
            .FirstOrDefault();
            return resultado;
        }

        public List<Livro> ObterTodos()
        {
            return ListaLivros;
        }

        public void Apagar(Livro obj)
        {
            if (!ListaLivros.Remove(obj))
                {
                    throw new AmazoniaException("Falha ao apagar Livro");
                }
        }
    }

}
