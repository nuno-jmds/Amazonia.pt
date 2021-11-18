using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amazonia.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Modelo;

namespace Amazonia.DAL.Entidades.Tests
{
    [TestClass()]
    public class ClienteTests
    {
        [TestMethod()]
        public void NifEstaValidoTest()
        {

            ////Arrange
            //var cliente = new Cliente();
            //cliente.NumeroIdentificacaoFiscal = "248129554";
            ////Act
            //var nifValido = cliente.NifEstaValido();
            ////Assert
            //Assert.IsTrue(nifValido);
        }

        [TestMethod()]
        public void DeveInvalidarNifMaiorQue9Digitos ()
        {

            ////Arrange
            //var cliente = new Cliente();
            //cliente.NumeroIdentificacaoFiscal = "2481295542";
            ////Act
            //var nifInValido = !cliente.NifEstaValido();
            ////Assert
            //Assert.IsTrue(nifInValido);
        }
        [TestMethod()]
        public void DeveInvalidarNifMenorQue9Digitos()
        {

            ////Arrange
            //var cliente = new Cliente();
            //cliente.NumeroIdentificacaoFiscal = "24812955";
            ////Act
            //var nifInValido = !cliente.NifEstaValido();
            ////Assert
            //Assert.IsTrue(nifInValido);
        }

        [TestMethod()]
        public void DeveInvalidarNifNumerosIguais()
        {

            ////Arrange
            //var cliente = new Cliente();
            //cliente.NumeroIdentificacaoFiscal = "111111111";
            ////Act
            //var nifInValido = !cliente.NifEstaValido();
            ////Assert
            //Assert.IsTrue(nifInValido);
            throw new NotImplementedException("Falta Corrigir");
        }
    }
}