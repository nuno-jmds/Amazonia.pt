using System.Collections.Generic;
using Amazonia.DAL.Desconto;
using Amazonia.DAL.Entidades;

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