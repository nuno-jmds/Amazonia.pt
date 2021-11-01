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
        public void ObterPrecoTest()
        {
            var revista = new LivrosPeriodicos();
            revista.Nome = "primeira revista";
            revista.DataLancamento = new DateTime(2019,10,30);
            revista.Preco = 100;
            var preco=revista.ObterPreco();
            Assert.AreEqual(preco,90M);
        }
    }
}