using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    public class LivroImpresso : Livro
    {

        public LivroImpresso()
        {
            TipoDeLivro = "Livro Impresso";
        }
        public int QuantidadeDePaginas { get; set; }

        ///Dimens?es em centimetros
        [Required]
        [Range(1, 100)]
        public float Largura { get; set; }
        [Required]
        [Range(1, 100)]
        public float Altura { get; set; }
        [Required]
        [Range(1, 100)]
        public float Profundidade { get; set; }
        ///Peso em gramas
        [Required]
        [Range(50, 10000)]
        public float Peso { get; set; }

        [NotMapped]
        public float Volume => Largura * Altura * Profundidade;

        public float ObterVolume()
        {
            return Largura * Altura * Profundidade;
        }

        public override string ToString()
        {
            return @$"Livro Impresso: {
                Nome} ";
        }
    }
}