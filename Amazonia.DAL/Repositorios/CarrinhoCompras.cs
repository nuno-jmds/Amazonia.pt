using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Entidades;
using Amazonia.DAL.Repositorio;
using Amazonia.DAL.Repositorios;

namespace Amazonia.DAL.Repositorios
{
    public class CarrinhoCompras : ICarrinhoCompras
    {
        public Cliente Cliente { get; set; }
        public List<Livro> Livros { get; set; }
        
        
        public decimal AplicarDesconto(decimal valorDesconto)
        {
            var fatorDesconto = 1 - valorDesconto * 0.1M;
            var valorCalculado = CalcularPreco();
            return valorCalculado * fatorDesconto;

        }

        public decimal CalcularPreco()
        {
            

            #region Exemplo
            ////Opção1
            //foreach(var item in livros)
            //{
            //    valorCalculado +=  item.ObterPreco();

            //}
            ////Opção1
            //foreach (var item in livros)
            //{
            //    valorCalculado =valorCalculado+ item.ObterPreco();

            //}
            #endregion
            //Opção3
            var valorCalculado = Livros.Sum(x=>x.ObterPreco());



            return valorCalculado;
        }
    }
}
