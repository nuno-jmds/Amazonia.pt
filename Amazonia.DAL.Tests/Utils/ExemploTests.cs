using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Utils.Tests
{
    [TestClass()]
    public class ExemploTests
    {
        [TestMethod()]
        public void ObterValorDoConfigTest()
        {

            var valorObtidoPeloMetodo = Exemplo.ObterValorDoConfig("chaveExemplo");
     
            Console.WriteLine($"valor obtido pelo método: {valorObtidoPeloMetodo}");

            Assert.AreEqual(valorObtidoPeloMetodo, "batatas do console.APP");
        }
    }
}