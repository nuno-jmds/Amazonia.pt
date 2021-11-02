using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Desconto
{
    public interface IDesconto
    {
        decimal Aplicar(decimal valorSemDesconto);
    }
}
