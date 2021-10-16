public abstract class Livro
{
    public string Nome { get; set; }
    public string TipoPublicacao { get; set; }

    public decimal Preco { get; set; }

    public string Descricao { get; set; }

    public string Autor { get; set; }
    public Idioma Idioma { get; set; }
}