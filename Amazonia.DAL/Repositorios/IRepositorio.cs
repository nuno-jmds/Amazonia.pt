using System.Collections.Generic;

namespace Amazonia.DAL.Repositorio
{

    interface IRepositorio<T>
    {
        void Criar(T obj);

        T ObterPorNome(string Nome);

        List<T> ObterTodos();

        T Atualizar(T obj);

        void Apagar(T obj);
    }




}