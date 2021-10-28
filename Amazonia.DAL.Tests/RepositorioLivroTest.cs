using Amazonia.DAL.Entidades;
using Amazonia.DAL.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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


        }

        [TestMethod]
        public void DeveGerarExceptionQuandoTentarApagarLivroInexistente()

        { 
        
        
        }

    }
}
