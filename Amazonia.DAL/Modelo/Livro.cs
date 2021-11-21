using System.ComponentModel.DataAnnotations;

namespace Amazonia.DAL.Modelo
{
    public abstract class Livro : Entidade
    {
        [Required]
        [Range(0,1000)]
        public decimal Preco {protected get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        [MaxLength(255)]
        public string Autor { get; set; }
        public Idioma Idioma { get; set; }

        public string TipoDeLivro { get; set; }

        public virtual decimal ObterPreco()
        {
            return Preco;
        }

    }
}