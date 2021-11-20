using System;
using System.Configuration;
using System.Linq;
using Amazonia.DAL.Modelo;
using Amazonia.DAL.Repositorio;
using Amazonia.DAL.Utils;
using Microsoft.EntityFrameworkCore;

namespace Amazonia.ConsoleAPP
{
    static class Program
    {
        static void Main(string[] args)
        {
            var ctx = new AmazoniaContexto();

            PlayGroundLinq(ctx);



  /*
            CRUD(ctx);


          
            //Ler valores de ficheiro de configuração
            var valorObtidoPeloMetodo = AppConfig.ObterValorDoConfig("chaveExemplo");
            var chaveExemplo = ConfigurationManager.AppSettings["chaveExemplo"];
            Console.WriteLine($"valor obtido pelo método: {valorObtidoPeloMetodo} valor lido diretamente: {chaveExemplo}");

            var usarRegraNovaStr = ConfigurationManager.AppSettings["regraNovaAtiva"];
            var usarRegraNova = Convert.ToBoolean(usarRegraNovaStr);




            Revista();

            //FeatureFlags
            if (usarRegraNova)
            {
                ListarClientes();
            }
            else
            {
                ListarLivros();
            }

            var valorObtidoPeloMetodo2 = AppConfig.ObterValorDoConfig("diasLancamento");
            Console.WriteLine(valorObtidoPeloMetodo2);
            */
        }

        private static void PlayGroundLinq(AmazoniaContexto ctx)
        {
            //ExemploSelect Fluent API - 4.5 (2008)
            //Select * from tabela
            /*
            var livros = ctx.Livros.Where(livro=>livro.Nome.StartsWith('H')).ToList();

            var senhorDosAneisOuHarryPotter = ctx.Livros.Where(livro => livro.Nome.StartsWith("h") || livro.Nome.StartsWith("l")).ToList();

            var senhorDosAneisOuHarryPotter2 = 
                ctx.Livros.Where(livro => livro.Nome.StartsWith("h") 
                || livro.Nome.StartsWith("l"))
                .ToList();

            throw new NotImplementedException();
    */
            // CriacaoNovosClientes(ctx);

            // ProjecaoDadosEspecificos(ctx);


            var clientesQueMoramNoPorto = from c in ctx.Clientes
                                          join m in ctx.Moradas
                                          on c.Morada.Id equals m.Id
                                          where m.Localidade == "Porto"
                                          select new
                                          {
                                              c.Nome,
                                              m.Endereco
                                          };

            var clienteQueMoramNoPortoFluentAPI = ctx.Clientes.Where(cliente => cliente.Morada.Localidade == "Porto")
                .Select(cliente => new
                {
                    NomeExemplo=cliente.Nome,
                    MoradaExemplo=cliente.Morada.Endereco
                });
            foreach (var item in clienteQueMoramNoPortoFluentAPI)
            {
                Console.WriteLine($"Nome Cliente: {item.NomeExemplo}");
                Console.WriteLine($"Morada Cliente {item.MoradaExemplo}");
            }


            var clienteQueMoramNoPortoSQLRaw = ctx.Clientes
                .FromSqlRaw("SELECT c.* " +
                            "FROM clientes c" +
                            "LEFT JOIN moradas m on c.moradaId=m.id" +
                            "WHERE m.localidade='PORTO'");




            Console.WriteLine();

        }

        private static void ProjecaoDadosEspecificos(AmazoniaContexto ctx)
        {
            var clientesQueMoramNoPorto = ctx.Clientes.Where(cliente => cliente.Morada.Distrito == "Porto").ToList();
            var dadosEspecificos = clientesQueMoramNoPorto.Select(cliente => new
            {
                cliente.Nome,
                cliente.NumeroIdentificacaoFiscal
            });

            var dadosEspecificosModificado = clientesQueMoramNoPorto.Select(cliente => new
            {
                NomeEmMaisculo = cliente.Nome.ToUpper(),
                NNIF = cliente.NumeroIdentificacaoFiscal
            });
        }

        private static void CriacaoNovosClientes(AmazoniaContexto ctx)
        {
            for (int i = 1; i < 10; i++)
            {
                var clienteNovo = new Cliente
                {
                    DataNascimento = new DateTime(1991, i, i + 5),
                    Nome = "João da Silva-" + i,
                    NumeroIdentificacaoFiscal = "12345678" + i,
                    Username = "joao.silva",
                    Password = "asd112",
                    Morada = new Morada
                    {
                        CodigoPostal = "370021" + i,
                        Distrito = "Porto",
                        Concelho = "Lisboa",
                        Localidade = "Lisboa",
                        Endereco = "Rua das Casa nr" + i,
                        Nome = "Morada Principal"
                    }
                };


                ctx.Clientes.Add(clienteNovo);
            }

            ctx.SaveChanges();
        }

        private static void CRUD(AmazoniaContexto ctx)
        {
            //Create
            //AdicionarClientes(ctx);
            AdicionarLivros(ctx);
            //Read
            var livroEscolhido = ctx.Livros.FirstOrDefault(x => x.Nome.StartsWith("Harry"));
            Console.WriteLine(livroEscolhido);
            //Read
            var primeiroLivroDigital = ctx.LivroDigitals.FirstOrDefault(x => x.TamanhoEmMB == 0);
            Console.WriteLine(primeiroLivroDigital);
            //Update
            primeiroLivroDigital.FormatoFicheiro = "PPP";
            ctx.SaveChanges();

            //Delete
            var primeiroLivroImpresso = ctx.LivroImpressos.FirstOrDefault();
            ctx.LivroImpressos.Remove(primeiroLivroImpresso);
            ctx.SaveChanges();
        }

        private static void AdicionarLivros(AmazoniaContexto ctx)
        {
            var livroDigital = new LivroDigital
            {
                Nome = "Harry Potter",
                Autor = "JK",
                Descricao = "Livro HP",
                FormatoFicheiro = "PDF",
                Idioma = DAL.Idioma.Portugues,
                InformacoesLicenca = "",
                Preco = 100

            };
            var livroAudio = new AudioLivro
            {
                Nome = "Harry Potter 2",
                Autor = "JK",
                Descricao = "Livro HP",
                FormatoFicheiro = "WMA",
                Idioma = DAL.Idioma.Portugues,
                Preco = 100

            };
            var livroImpresso = new LivroImpresso
            {
                Nome = "Harry Potter Impresso",
                Autor = "JK",
                Descricao = "Livro harry potter",
                Idioma = DAL.Idioma.Portugues,
                Preco = 100,
                Altura = 10,
                Largura = 10,
                Profundidade = 10
            };

            ctx.Add(livroImpresso);

            ctx.Add(livroAudio);
            ctx.Add(livroDigital);

            ctx.Add(livroImpresso);

            ctx.Add(livroAudio);
            ctx.Add(livroDigital);

            ctx.Add(livroImpresso);

            ctx.Add(livroAudio);
            ctx.Add(livroDigital);
            ctx.SaveChanges();
        }

        private static void AdicionarClientes(AmazoniaContexto ctx)
        {
            ctx.Clientes.Add(new DAL.Modelo.Cliente
            {
                Username = "Nuno33",
                DataNascimento = new DateTime(1021, 12, 21),
                Nome = "Nuno ",
                NumeroIdentificacaoFiscal = "215214512",
                Password = "senha"
            });
            ctx.SaveChanges();
        }

        public static void Revista() 
        {

            var revista = new LivroPeriodico();
            revista.Nome = "primeira revista";
            revista.DataLancamento = new DateTime(2019, 10, 30);
            revista.Preco = 100;
            var preco = revista.ObterPreco();

            Console.WriteLine($"Preço da Revista: {preco}");
        }
        /// <summary>
        /// Lista Livros
        /// </summary>
        public static void ListarLivros()
        {
            var repoLivros = new RepositorioLivro();
            var listaLivros = repoLivros.ObterTodos();
            foreach (var item in listaLivros)
            {
                Console.WriteLine(item);
            }
        }

        public static void ListarClientes()
        {
            var repo = new RepositorioCliente();
            var listaClientes = repo.ObterTodos();
            foreach (var item in listaClientes)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Consulta lista com M");
            var listaClientesM = repo.ObterTodosQueComecemPor("M");
            foreach (var item in listaClientesM)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Consulta lista com maiores de 18");
            var listaClientes18 = repo.ObterTodosQueTenhamPeloMenos18Anos();
            foreach (var item in listaClientes18)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Obter por nome");
            var joao = repo.ObterPorNome("João");
            var clienteNovo = repo.Atualizar(joao.Nome, "Joao da Silva");
            System.Console.WriteLine(clienteNovo);

            var listagemTotal = repo.ObterTodos();
            Console.WriteLine($"Data Base contem {listagemTotal.Count} clientes");

            repo.Apagar(joao);

            var listagemTotal2 = repo.ObterTodos();
            Console.WriteLine($"Data Base contem {listagemTotal2.Count} clientes");

        }
    }
}
