using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Modelo
{
    public class Cliente: Entidade
    {

        

        [Required]
        [MinLength(5), MaxLength(255)]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [MinLength(9),MaxLength(9)]
        public string NumeroIdentificacaoFiscal { get; set; }

        public virtual Morada Morada { get; set; }



        [NotMapped]
        public int Idade => DateTime.Now.Year - DataNascimento.Year;
    }
}
