using Amazonia.DAL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Entidades
{
    public class LivrosPeriodicos:Livro
    {
        public DateTime DataLancamento { get; set; }


        public override decimal ObterPreco() {

            var precoBase = base.ObterPreco();
            var valorDesconto = Decimal.Parse(Exemplo.ObterValorDoConfig("descontoLivroPeriodico"));
            var diasParaDesconto = Int32.Parse(Exemplo.ObterValorDoConfig("diasLancamento"));
            

            var diasDesdeLancamento=(DateTime.Today - DataLancamento).Days;
            
            if (diasDesdeLancamento >= diasParaDesconto) 
            {
                var valor= precoBase * (1 - valorDesconto * 0.01M);
                return valor;
            }
            

            return precoBase;
        }
    }
}
