using System.Collections.Generic;
using Amazonia.DAL.Entidades;

namespace Amazonia.DAL.Repositorio
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco(List<Livro> livros);

        decimal AplicarDesconto(int valorDesconto);
    }
}