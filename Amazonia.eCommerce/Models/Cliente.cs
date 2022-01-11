using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.eCommerce.Models
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        [MinLength(4)]
        [Display(Name="Nome Do Cliente")]
        public string Nome { get; set; }
        [Required]
        [MinLength(5), MaxLength(255)]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [MinLength(8), MaxLength(32)]
        public string Password { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [MinLength(9), MaxLength(9)]
        public string NumeroIdentificacaoFiscal { get; set; }

        [NotMapped]
        public int Idade => DateTime.Now.Year - DataNascimento.Year;

    }
}
