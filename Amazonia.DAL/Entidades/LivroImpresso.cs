namespace Amazonia.DAL.Entidades
{
    public class LivroImpresso : Livro
    {
        public int QuantidadeDePaginas { get; set; }

        public Dimensoes Dimensoes { get; set; }

        public override string ToString()
        {
            return @$"Livro Impresso: {
                Nome} ";
        }
    }
}