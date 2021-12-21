using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.webAPI.DTO
{
    public class LivroDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Formato { get; set; }

        public string Idioma { get; set; }

        public int QuantidadeEmEstoque { get; set; }
        public string Descricao { get; set; }
        
        public EnumTipoLivro TipoLivro { get; set; } //TODO: Resolver depois
    }
}


