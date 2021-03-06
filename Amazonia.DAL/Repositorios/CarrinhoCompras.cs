using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Desconto;
using Amazonia.DAL.Modelo;
using Amazonia.DAL.Repositorio;
using Amazonia.DAL.Repositorios;

namespace Amazonia.DAL.Repositorios
{
    public class CarrinhoCompras : ICarrinhoCompras
    {
        public Cliente Cliente { get; set; }
        public List<Livro> Livros { get; set; }
        
        //comentado apenas para ver o exemplo
        //public decimal AplicarDesconto(decimal valorDesconto)
        //{
        //    var fatorDesconto = 1 - valorDesconto * 0.01M;
        //    var valorCalculado = CalcularPreco();
        //    return valorCalculado * fatorDesconto;

        //}

        public decimal AplicarDesconto(IDesconto tipoDeDesconto)
        {
            var valorCalculado = Livros.Sum(x => x.ObterPreco());
            var valorComDesconto = tipoDeDesconto.Aplicar(valorCalculado);
            return valorComDesconto;

        }
        /// <summary>
        /// Calcula o preço total dos livros que estão no carro de compras
        /// </summary>
        /// <returns></returns>
        public decimal CalcularPreco()
        {
            

            #region Exemplo
            ////Opção1
            //foreach(var item in livros)
            //{
            //    valorCalculado +=  item.ObterPreco()

            //}
            ////Opção1
            //foreach (var item in livros)
            //{
            //    valorCalculado =valorCalculado+ item.ObterPreco()

            //}
            #endregion
            //Opção3
            var valorCalculado = Livros.Sum(x=>x.ObterPreco());



            return valorCalculado;
        }
    }
}
