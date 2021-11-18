using System.ComponentModel.DataAnnotations;

namespace Amazonia.DAL.Modelo
{
    public class LivroDigital : Livro
    {
        public int TamanhoEmMB { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(5)]
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