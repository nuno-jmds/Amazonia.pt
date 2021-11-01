using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorios.Tests
{
    [TestClass()]
    public class CarrinhoComprasTests
    {
        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosImpressosTest()
        {
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 40, Nome = "Impresso1" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 100;

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert
            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisTest()
        {
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroDigital { Preco = 10, Nome = "Digital1" });
            livrosFake.Add(new LivroDigital { Preco = 20, Nome = "Digital1" });
            livrosFake.Add(new LivroDigital { Preco = 30, Nome = "Digital1" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 60 * 0.9M;

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert
            Assert.AreEqual(valorEsperado, valorObtido);
        }
        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisEImpressoTest()
        {
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroDigital { Preco = 10, Nome = "Digital1" });
            livrosFake.Add(new LivroDigital { Preco = 20, Nome = "Digital1" });
            livrosFake.Add(new LivroDigital { Preco = 30, Nome = "Digital1" });
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso1" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 60 * 0.9M + 60;

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert
            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void AplicarDescontoTest()
        {
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroDigital { Preco = 10, Nome = "Digital1" });
            livrosFake.Add(new LivroDigital { Preco = 20, Nome = "Digital1" });
            livrosFake.Add(new LivroDigital { Preco = 30, Nome = "Digital1" });
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso1" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();
            
            var valorDesconto = 50;
            var valorEsperado = (60 * 0.9M + 60)*(1-valorDesconto*0.01M);

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.AplicarDesconto(valorDesconto);

            //assert
            Assert.AreEqual(valorEsperado, valorObtido);
        }
    }
}