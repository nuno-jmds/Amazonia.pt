using System.ComponentModel.DataAnnotations;

namespace Amazonia.DAL.Modelo
{ 
    public class AudioLivro : Livro
    {
        [Required]
        [MinLength(3)]
        [MaxLength(5)]
        public string FormatoFicheiro { get; set; }

        [Range(1,6000)]
        public int? DuracaoEmMinutos { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Formato Ficheiro: {FormatoFicheiro} => DuracaoLivro: {DuracaoEmMinutos}";
        }
    }
}