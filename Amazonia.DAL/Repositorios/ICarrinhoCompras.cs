using System.Collections.Generic;
using Amazonia.DAL.Desconto;

namespace Amazonia.DAL.Repositorio
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco();
        //comentado só para guardar histórico
        //decimal AplicarDesconto(decimal valorDesconto);

        decimal AplicarDesconto(IDesconto tipoDeDesconto);
    }
}