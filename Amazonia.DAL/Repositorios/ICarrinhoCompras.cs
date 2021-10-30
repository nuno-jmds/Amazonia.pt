using System.Collections.Generic;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorio
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco();

        decimal AplicarDesconto(decimal valorDesconto);
    }
}