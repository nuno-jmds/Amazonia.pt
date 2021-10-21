using System;
namespace Amazonia.DAL.Entidades
{
    public abstract class Entidade
    {
        public Guid Identificador { get; }

        public string Nome { get; set; }


        public Entidade()
        {
            Identificador = Guid.NewGuid();
        }

        public Entidade(string nome)
        {
            Identificador = Guid.NewGuid();
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} => Identificador: {Identificador}";
        }

    }
}
