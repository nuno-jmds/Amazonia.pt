using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazonia.DAL.Desconto;
using Amazonia.DAL.Desconto;

namespace Amazonia.DAL.Desconto
{
    public class DescontoPercentual : IDesconto
    {
        public decimal PercentualDesconto { get; set; }
 /// <summary>
 /// Aplica desconto ao valor total
 /// </summary>
 /// <param name="valorSemDesconto"></param>
 /// <returns></returns>
        decimal IDesconto.Aplicar(decimal valorSemDesconto)
        {
            var result = valorSemDesconto * (1 - PercentualDesconto * 0.01M);
            return result;
        }
    }
}
