using Amazonia.DAL.Entidades;
using Amazonia.DAL.Repositorio;
using Amazonia.DAL.Infraestrutura;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amazonia.DAL.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DeveCriarUmObjetoDoTipoRepositorioLivro()
        {

                //Arrange
                RepositorioLivro repositorio;
                //Act
                repositorio = new RepositorioLivro();
                //Assert
                Assert.IsNotNull(repositorio);

        }

        [TestMethod]
        public void DeveCriarUmaListaDeLivrosNoObjetoDoTipoRepositorioLivro()
        {

            //Arrange
            RepositorioLivro repositorio;
            List<Livro> livros;
            var minElementos = 1;
            //Act
            repositorio = new RepositorioLivro();
            livros=repositorio.ObterTodos();
            var quantidadeDeLivrosNoRepositorio = livros.Count;
            //Assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            Assert.IsTrue(quantidadeDeLivrosNoRepositorio >= minElementos);

        }

        [TestMethod]
        public void DeveCriarUmaListaDeLivrosNoObjetoDoTipoRepositorioLivroComFalha()
        {

            //Arrange
            RepositorioLivro repositorio;
            List<Livro> livros;
            var quantidadeElementos = 5;
            //Act
            repositorio = new RepositorioLivro();
            livros = repositorio.ObterTodos();
            var quantidadeDeLivrosNoRepositorio = livros.Count;
            //Assert
            Assert.IsNotNull(repositorio);
            Assert.IsNotNull(livros);
            Assert.IsTrue(quantidadeDeLivrosNoRepositorio == quantidadeElementos);

        }


        [TestMethod]
        public void DeveApagarUmLivroDaLista()

        {
            var repo = new RepositorioLivro();
            var livros = repo.ObterTodos();
            var livroAApagar = livros.FirstOrDefault();

            //action
            var livrosInicialmente = livros.Count;
            repo.Apagar(livroAApagar);
            var livrosDepooisDeApagar = livros.Count;

            //assert
            Assert.IsTrue(livrosInicialmente > livrosDepooisDeApagar);


        }

#if !DEBUG
        [Ignore]
#endif
        [TestMethod]
        [ExpectedException(typeof(AmazoniaException))]
        public void DeveGerarExceptionQuandoTentarApagarLivroInexistente()

        {
            var repo = new RepositorioLivro();
            var livros = repo.ObterTodos();
            var livroInexistente=new LivroDigital();
           

            //action
            var livrosInicialmente = livros.Count;
            repo.Apagar(livroInexistente);
            var livrosDepooisDeApagar = livros.Count;

            //assert
            Assert.IsTrue(livrosInicialmente > livrosDepooisDeApagar);

        }

    }
}
