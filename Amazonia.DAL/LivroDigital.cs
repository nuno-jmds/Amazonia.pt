namespace Amazonia.DAL{
    class LivroDigital : Livro
{
    public int TamanhoEmMB { get; set; }
    public string FormatoFicheiro { get; set; } //pdf, doc, epub

    public string InformacoesLicenca { get; set; }

}}