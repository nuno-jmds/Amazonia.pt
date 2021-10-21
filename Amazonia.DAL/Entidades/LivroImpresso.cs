namespace Amazonia.DAL.Entidades
{
    public class LivroImpresso : Livro
    {
        public int QuantidadeDePaginas { get; set; }

        public Dimensoes Dimensoes { get; set; }
    }
}