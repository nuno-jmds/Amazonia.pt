using System.Collections.Generic;
using Amazonia.DAL.Desconto;

namespace Amazonia.DAL.Repositorio
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco();
        //comentado s� para guardar hist�rico
        //decimal AplicarDesconto(decimal valorDesconto);

        decimal AplicarDesconto(IDesconto tipoDeDesconto);
    }
}