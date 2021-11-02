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
        public LivrosPeriodicos()
        {
            if (DataLancamento == new DateTime())
            {
                DataLancamento = DateTime.Today;
            }
        }
        
        public DateTime DataLancamento { get; set; }


        public override decimal ObterPreco() {

            var precoBase = base.ObterPreco();
            var promocaoAtiva = Boolean.Parse(Exemplo.ObterValorDoConfig("ativarPromocoes"));
            if (promocaoAtiva)
            { 
            
            var valorMinimoDesconto = Decimal.Parse(Exemplo.ObterValorDoConfig("descontoMinimoLivroPeriodico"));
            var minimoDiasParaDesconto = Int32.Parse(Exemplo.ObterValorDoConfig("minimoDiasLancamento"));
           


            var diasDesdeLancamento=(DateTime.Today - DataLancamento).Days;
            
            if (diasDesdeLancamento >= minimoDiasParaDesconto) 
            {
                    var valorMaximoDesconto = Decimal.Parse(Exemplo.ObterValorDoConfig("descontoMaximoLivroPeriodico"));
                    var maximoDiasParaDesconto = Int32.Parse(Exemplo.ObterValorDoConfig("maximoDiasLancamento"));
                    
                    //mais de 60 dias
                    if (diasDesdeLancamento >= maximoDiasParaDesconto)
                {
                    var valorDesconto = precoBase * (1 - valorMaximoDesconto * 0.01M);
                    return valorDesconto;
                }
                var valor= precoBase * (1 - valorMinimoDesconto * 0.01M);
                return valor;
            }
            }

            return precoBase;
        }
    }
}
