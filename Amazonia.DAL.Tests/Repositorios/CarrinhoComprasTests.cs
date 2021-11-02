using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Desconto;
using System.Configuration;

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
        [Ignore]
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
            var valorObtido = carrinho.AplicarDesconto(null); //null adicionado para guardar o exemplo

            //assert
            Assert.AreEqual(valorEsperado, valorObtido);
        }

        [TestMethod()]
        public void AplicarDescontoPercentualTest()
        {
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 60, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 40, Nome = "Impresso1" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorDesconto = 20;
            var valorEsperado = 80M;

            IDesconto desconto = new DescontoPercentual { PercentualDesconto = 20 };

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.AplicarDesconto(desconto); 

            //assert
            Assert.AreEqual(valorEsperado, valorObtido);
        }

       

        [TestMethod()]
        public void AplicarDescontoPercentualECombinadoPorConfigTest()
        {
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroImpresso { Preco = 60, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 40, Nome = "Impresso1" });
            livrosFake.Add(new LivroDigital { Preco = 100, Nome = "Digital01" });

            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            IDesconto desconto;

            var condicao = ConfigurationManager.AppSettings["RegraDescontoValida"]=="Percentual"; //introdução à inversão de dependencia
            if(condicao)
            {
                desconto = new DescontoPercentual
                {
                    PercentualDesconto = 10
                };

            }
            else
            {
                desconto = new DescontoCombinado
                {
                    PercentualDesconto = 20,
                    LivrosCarrinho = livrosFake,
                    LivrosDigitais = 1,
                    LivrosImpressos = 2

                };
            }


            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.AplicarDesconto(desconto);

            //assert
            if (condicao)
            {

                Assert.AreEqual(171M, valorObtido);
            }
            else
            {
                Assert.AreEqual(152M, valorObtido);
            }
            
        }

        [TestMethod()]
        public void CalcularPrecoCarrinhoLivrosDigitaisEImpressoEPeriodicoTest()
        {
            var livrosFake = new List<Livro>();
            livrosFake.Add(new LivroDigital { Preco = 10, Nome = "Digital1" });
            livrosFake.Add(new LivroDigital { Preco = 20, Nome = "Digital1" });
            livrosFake.Add(new LivroDigital { Preco = 30, Nome = "Digital1" });
            livrosFake.Add(new LivroImpresso { Preco = 10, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 20, Nome = "Impresso1" });
            livrosFake.Add(new LivroImpresso { Preco = 30, Nome = "Impresso1" });
            livrosFake.Add(new LivrosPeriodicos { Preco = 100, Nome = "Periodico1", DataLancamento=DateTime.Today.AddDays(-90) });
            livrosFake.Add(new LivrosPeriodicos { Preco = 100, Nome = "Periodico2", });
            var clienteFake = new Cliente();
            var carrinho = new CarrinhoCompras();

            var valorEsperado = 60 * 0.9M + 60+50+100;

            //act
            carrinho.Cliente = clienteFake;
            carrinho.Livros = livrosFake;
            var valorObtido = carrinho.CalcularPreco();

            //assert
            Assert.AreEqual(valorEsperado, valorObtido);
        }



    }
}