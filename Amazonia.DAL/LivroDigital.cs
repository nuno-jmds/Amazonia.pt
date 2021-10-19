namespace Amazonia.DAL
{
    public class LivroDigital : Livro
    {
        public int TamanhoEmMB { get; set; }
        public string FormatoFicheiro { get; set; } //pdf, doc, epub

        public string InformacoesLicenca { get; set; }

        public override decimal ObterPreco()
        {
            return base.ObterPreco() * 0.9M;
        }

    }
}