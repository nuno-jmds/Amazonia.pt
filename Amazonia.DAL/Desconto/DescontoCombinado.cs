using Amazonia.DAL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Desconto
{
    public class DescontoCombinado : IDesconto
    {
        public decimal PercentualDesconto { get; set; }
        public int LivrosDigitais { get; set; }

        public int LivrosImpressos { get; set; }

        public List<Livro> LivrosCarrinho { get; set; }
        /// <summary>
        /// Desconto Combinado= Se tiver pelo menos 2 livros do tipo digital e tiver pelo menos 1 livro impresso =>aplicar desconto
        /// </summary>
        /// <param name="valorSemDesconto"></param>
        /// <returns></returns>
        public decimal Aplicar(decimal valorSemDesconto)
        {
            var qtdLivrosImpressos = LivrosCarrinho.Where(x => x.GetType() == typeof(LivroImpresso)).Count();
            var qtdLivrosDigitais = LivrosCarrinho.Where(x => x.GetType() == typeof(LivroDigital)).Count();

            if (qtdLivrosDigitais < LivrosDigitais || qtdLivrosImpressos < LivrosImpressos) 
            
            {
                PercentualDesconto = 0;
            }
            
            
            var result = valorSemDesconto * (1 - PercentualDesconto * 0.01M);
            return result;
        }
    }
}
