using Amazonia.DAL.Modelo;
using Amazonia.webAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.webAPI.Conversores
{
    public class LivroAdapter
    {


        public static LivroDto ConverterLivroEmDto(Livro livro)
        {
            var dto = new LivroDto
            {

                Id = livro.Id,
                Autor = livro.Autor,
                Nome = livro.Nome,
                Formato = livro.TipoDeLivro
            };

            dto.Idioma = livro.Idioma switch
            {
                DAL.Idioma.Portugues => "Português",
                DAL.Idioma.Espanhol => "Espanhol",
                DAL.Idioma.Ingles => "Inglês",
                _ => "Português"

            };







            return dto;


        }


    }
}
