using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.eCommerce.Models
{
    public class Utilizador
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string PalavraPasse { get; set; }

        public byte[] Avatar { get; set; }

    }
}
