namespace Amazonia.DAL{
    class LivroImpresso:Livro
{
    public int QuantidadeDePaginas { get; set; }

    public Dimensoes Dimensoes { get; set; }
}}