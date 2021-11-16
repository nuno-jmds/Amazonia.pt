using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Modelo
{
    public class Morada : Entidade
    {
        [Required]
        public string Distrito { get; set; }
        [Required]
        public string Concelho { get; set; }
        [Required]
        public string Localidade { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        [MinLength(7), MaxLength(7)]
        public string CodigoPostal { get; set; }
    }
}
