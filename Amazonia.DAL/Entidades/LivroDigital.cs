namespace Amazonia.DAL.Entidades
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

        public override string ToString()
        {
            return $"Livro Digital: {base.ToString()} => Tamanho em MB: {TamanhoEmMB} ";
        }

    }
}