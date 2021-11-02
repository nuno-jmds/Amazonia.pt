using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades.Tests
{
    [TestClass()]
    public class LivrosPeriodicosTests
    {
        
        [TestMethod()]
        public void ObterPrecoMenosde30diasTest()
        {
            var revista = new LivrosPeriodicos();
            revista.Nome = "primeira revista";
            revista.DataLancamento = new DateTime(2021,10,30);
            revista.Preco = 100;
            var preco=revista.ObterPreco();
            Assert.AreEqual(preco,100M);
        }

        [TestMethod()]
        public void ObterPrecoMaisde30diasTest()
        {
            var revista = new LivrosPeriodicos();
            revista.Nome = "primeira revista";
            revista.DataLancamento = new DateTime(2021, 9, 20);
            revista.Preco = 100;
            var preco = revista.ObterPreco();
            Assert.AreEqual(preco, 80M);
        }

        [TestMethod()]
        public void ObterPrecoMaisde60diasTest()
        {
            var revista = new LivrosPeriodicos();
            revista.Nome = "primeira revista";
            revista.DataLancamento = DateTime.Today.AddDays(-65);
            revista.Preco = 100;
            var preco = revista.ObterPreco();
            Assert.AreEqual(preco, 50M);
        }
    }
}