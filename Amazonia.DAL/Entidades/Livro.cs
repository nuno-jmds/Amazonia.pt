namespace Amazonia.DAL.Entidades
{
    public abstract class Livro : Entidade
    {
        public decimal Preco { get; set; }

        public string Descricao { get; set; }

        public string Autor { get; set; }
        private Idioma Idioma { get; set; }

        public virtual decimal ObterPreco()
        {
            return Preco;
        }
    }
}