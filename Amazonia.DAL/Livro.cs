namespace Amazonia.DAL{
    public abstract class Livro
{
    public string Nome { get; set; }
    public decimal Preco { get; set; }

    public string Descricao { get; set; }

    public string Autor { get; set; }
    private Idioma Idioma { get; set; }
}
}