using Amazonia.DAL.Modelo;
using Amazonia.DAL.Repositorio;
using Amazonia.webAPI.Conversores;
using Amazonia.webAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        AmazoniaContexto ctx;
        public LivroController()
        {
            ctx = new AmazoniaContexto();
        }




        


        [HttpGet]

        public DataTableResponse GetLivros() 
        {
            var livros = ctx.Livros.ToList();

            //Forma antiga
            var livrosDto = new List<LivroDto>();

            foreach (var item in livros)
            {
                var dtoTemp = LivroAdapter.ConverterLivroEmDto(item);
                livrosDto.Add(dtoTemp);
            }

            //Com LINQ - Também funciona
            //var livrosDto =  livros.Select(x => new List<LivroDto>
            //{
            //    new LivroDto
            //    {
            //        Autor = x.Autor,
            //        Id = x.Id,
            //        Formato = x.TipoPorEscrito,
            //        Nome = x.Nome,
            //        QuantidadeEmEstoque = new Random().Next(),
            //        Idioma = LivroAdapter.ObterIdiomaLivro(x.Idioma)
            //    }
            //});

            //TODO: No futuro trocar para Automapper

            return new DataTableResponse
            {
                RecordsTotal = livros.Count,
                RecordsFiltered = 10,
                Data = livrosDto.ToArray()

            };
        }

        [HttpPost]
        public Livro PostLivroNovo(LivroDto livro)
        {
            Console.WriteLine("Entrei");
            Livro livroNovo = new LivroImpresso();
            switch (livro.TipoLivro)
            {
                case EnumTipoLivro.LivroImpresso:
                    livroNovo = new LivroImpresso();
                    break;
                case EnumTipoLivro.LivroDigital:
                    livroNovo = new LivroDigital();
                    break;
                case EnumTipoLivro.AudioLivro:
                    livroNovo = new AudioLivro();
                    break;
            }

            livroNovo.Nome = livro.Nome;
            livroNovo.Autor = livro.Autor;
            livroNovo.Descricao = livro.Descricao;

            ctx.Livros.Add(livroNovo);
            ctx.SaveChanges();
            return ctx.Livros.FirstOrDefault(x => x.Id == livroNovo.Id);
        }
        [HttpGet("{id}")]
        public Livro GetLivro(Guid id)
        {
            return ctx.Livros.FirstOrDefault(x => x.Id == id);
        }


        [HttpDelete]
        public bool DeleteLivro(Guid id)
        {
            var livro = ctx.Livros.FirstOrDefault(x => x.Id == id);
            if (livro == null)
            {
                return false;
            }

            ctx.Livros.Remove(livro);
            ctx.SaveChanges();
            return true;
        }

        [HttpPut]
        public bool UpdateLivro(Guid id, LivroDto dadosLivro)
        {
            var livro = ctx.Livros.FirstOrDefault(x => x.Id == id);
            if (livro == null)
            {
                return false;
            }

            livro.Nome = dadosLivro.Nome;
            livro.Autor = dadosLivro.Autor;
            livro.Descricao = dadosLivro.Descricao;

            ctx.SaveChanges();
            return true;
        }


    }



}

