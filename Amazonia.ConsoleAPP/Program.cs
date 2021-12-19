using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
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
            //LeituraFicheiroDeConfiguracao();

            var ctx = new AmazoniaContexto();

            FluentApiExamples(ctx);

            LinqExamples(ctx);

            //SqlRowExamples(ctx);

            #region Ações de Crud
            //Create
            //CriacaoNovosClientes(ctx,100);
            //CriacaoNovosLivros(ctx,50);

            //Read
            //LeituraDeClientesEMoradas(ctx);
            //LeituraDeLivros(ctx);

            //Update
            //AtualizarBaseDeDados(ctx);

            //Delete
            //DeleteClienteDaBaseDeDados(ctx);
            #endregion

            /*
            //chamada à API
            HttpClient client = new HttpClient();
            var resultado = client.GetAsync("https://localhost:44392/api/Cliente").Result;
            Console.WriteLine(resultado.Content.ReadAsStringAsync());
            */
        }

        private static void LeituraFicheiroDeConfiguracao()
        {
            //Ler valores de ficheiro de configuração
            var valorObtidoPeloMetodo = AppConfig.ObterValorDoConfig("chaveExemplo");
            var chaveExemplo = ConfigurationManager.AppSettings["chaveExemplo"];
            Console.WriteLine($"valor obtido pelo método: {valorObtidoPeloMetodo} valor lido diretamente: {chaveExemplo}");

            var usarRegraNovaStr = ConfigurationManager.AppSettings["regraNovaAtiva"];
            var usarRegraNova = Convert.ToBoolean(usarRegraNovaStr);

            //FeatureFlags
            if (usarRegraNova)
            {
                Console.WriteLine("usarRegraNova True");
            }
            else
            {
                Console.WriteLine("usarRegraNova False");
            }

            var valorObtidoPeloMetodo2 = AppConfig.ObterValorDoConfig("diasLancamento");
            Console.WriteLine(valorObtidoPeloMetodo2);
        }


        private static void FluentApiExamples(AmazoniaContexto ctx)
        {
            var clienteQueMoramNoPortoFluentAPI = ctx.Clientes.Where(cliente => cliente.Morada.Localidade == "Porto")
                    .Select(cliente => new
                    {
                        NomeExemplo = cliente.Nome,
                        MoradaExemplo = cliente.Morada.Endereco
                    });
            foreach (var item in clienteQueMoramNoPortoFluentAPI)
            {
                //Console.WriteLine($"Nome Cliente: {item.NomeExemplo}");
                //Console.WriteLine($"Morada Cliente {item.MoradaExemplo}");
            }

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


            ///#########################################################################################################################################
            /// 
            var contagemGeral = ctx.Livros.Count();

            ///#########################################################################################################################################
            /// 
            var contagemAgrupadoPorNome = ctx.Livros
                .AsEnumerable()
                .GroupBy(livro=>livro.Nome)
                .Select(x=>new {
                NomeLivro=x.FirstOrDefault().Nome,
                Contagem=x.Count()
                });
            foreach (var livros in contagemAgrupadoPorNome)
            {

                //Console.WriteLine($"grupos { livros.Contagem  }   { livros.NomeLivro  }   " );
            }

            ///#########################################################################################################################################
            /// 
            var contagemAgrupadoPorNomeEAutor = ctx.Livros
                .AsEnumerable()
                .GroupBy(livro => new{ livro.Nome, livro.Autor})
                .Select(x => new {
                    NomeLivro = x.FirstOrDefault().Nome,
                    Contagem = x.Count(),

                    NomeAutor= x.FirstOrDefault().Autor

                });
            foreach (var livros in contagemAgrupadoPorNomeEAutor)
            {

                //Console.WriteLine($"grupos { livros.Contagem  }   { livros.NomeLivro  }  { livros.NomeAutor  } ");
            }

            ///#########################################################################################################################################

            var somatorioVolumeDosLivros = ctx.LivroImpressos
                .AsEnumerable()
                .GroupBy(livro =>  livro.Nome)
                .Select(x => new {
                    NomeLivro = x.FirstOrDefault().Nome,
                    Somatorio = x.Sum(x=>x.ObterVolume()),
                    Media=x.Average(x=>x.ObterVolume())

                });
            foreach (var livros in somatorioVolumeDosLivros)
            {

                //Console.WriteLine($"grupos { livros.Somatorio  }   { livros.NomeLivro  }  ");
            }

        }
        private static void LinqExamples(AmazoniaContexto ctx) 
        {
            ///#########################################################################################################################################
            /// 
            //IQueryable Cliente
            var todosOsClientes = from cliente in ctx.Clientes
                                  select cliente;
            ///#########################################################################################################################################
            /// 
            //IQueryable Cliente
            var todosOsClientesDoPorto = from cliente in ctx.Clientes
                                         where cliente.Morada.Distrito == "Porto"
                                         select cliente;
            ///#########################################################################################################################################
            /// 
            //IQueryable Cliente
            var todosOsClientesDoPortoOuLisboa  = from cliente in ctx.Clientes
                                         where (cliente.Morada.Distrito == "Porto"
                                         || cliente.Morada.Distrito=="Lisboa")
                                         select cliente;
            ///#########################################################################################################################################
            /// 
            //IQueryable Cliente
            var todosOsClientesOrdenadosPorNome = from cliente in ctx.Clientes
                                                  orderby cliente.Nome ascending
                                                  select cliente;
            ///#########################################################################################################################################
            /// 
            // queryCustomersByCity is an IEnumerable<IGrouping<string, Customer>>
            var GrupoClientePorCidade = ctx.Clientes.Include(cliente => cliente.Morada).AsEnumerable().GroupBy(cliente=>cliente.Morada.Distrito);
            
            var GrupoClientePorCidade1 = from cliente in ctx.Clientes
                                        group  cliente  by cliente.Password;

            foreach (var group in GrupoClientePorCidade)
            {

                //Console.WriteLine($"{group.Key} - {group.Count()}");
            }

            ///#########################################################################################################################################
            /// 
            ////IQueryable Cliente
            var clientesQueMoramNoPorto = from cliente in ctx.Clientes
                                          join morada in ctx.Moradas
                                          on cliente.Morada.Id equals morada.Id
                                          where morada.Localidade == "Porto"
                                          select new
                                          {
                                              cliente.Nome,
                                              morada.Endereco
                                          };

            foreach (var cliente in clientesQueMoramNoPorto)
            {

                //Console.WriteLine($"{cliente.Nome} - {cliente.Endereco}");

            }

            ///#########################################################################################################################################
            /// 
            ////IQueryable Cliente
            var clientesQueNasceramEm2000 = from cliente in ctx.Clientes
                                          join morada in ctx.Moradas
                                          on cliente.Morada.Id equals morada.Id
                                          where cliente.DataNascimento > new DateTime(2000,01,01) && cliente.DataNascimento < new DateTime(2000, 12, 31)
                                            select new
                                          {
                                              cliente.Nome,
                                              morada.Endereco,
                                              cliente.DataNascimento
                                          };

            foreach (var cliente in clientesQueNasceramEm2000)
            {

               // Console.WriteLine($"{cliente.Nome}      - {cliente.Endereco}        -{cliente.DataNascimento} ");

            }

            ///#########################################################################################################################################
            /// 
            var livrosPeriodicos = from Livros in ctx.LivroPeriodicos
                                   select Livros;
            foreach (var livro in livrosPeriodicos)
            {

                // Console.WriteLine($"{livro.Nome}      - {livro.TipoDeLivro}        -{livro.Idioma} ");

            }



        }

        private static void SqlRowExamples(AmazoniaContexto ctx)
        {

            //Com BUG
            var clienteQueMoramNoPortoSQLRaw = ctx.Clientes.FromSqlRaw("SELECT * " +
                                "FROM Clientes" +
                                "LEFT JOIN Moradas on Clientes.MoradaId=Moradas.Id" +
                                "WHERE Moradas.Localidade='PORTO'");

            foreach(var cliente in clienteQueMoramNoPortoSQLRaw)
            {
                Console.WriteLine(cliente.Nome);

            }
           
        }

        //Ações de CRUD
        #region Ações de CRUD

        //Create
        #region Criação De Dados Na Base De Dados
        private static void CriacaoNovosClientes(AmazoniaContexto ctx,int quantidade)
        {

            var NomesProprios = new List<string> {"Ana","Maria","Joana","Adriana","João","Pedro","Vitor","Ricardo","André","Liliana","Catarina","Miguel","Francisco","Vitória" };
            var Sobrenomes = new List<string> { "Marques", "Alves", "Antunes", "Saraiva", "Costa", "Vitorino", "Santos", "Pereira", "Oliveira", "Castanheira" };
            var Distritos = new List<string> { "Aveiro","Lisboa","Porto","Viseu","Algarve","Coimbra","Leiria","Vila Real","Bragança"};
            

            for (int i = 1; i < quantidade; i++)
            {

                var primeiroNome = NomesProprios[new Random().Next(NomesProprios.Count)];
                var segundoNome = Sobrenomes[new Random().Next(Sobrenomes.Count)];
                var cidade = Distritos[new Random().Next(Distritos.Count)];
                var clienteNovo = new Cliente
                {
                    DataNascimento = new DateTime(new Random().Next(1950, 2015), new Random().Next(1, 12), new Random().Next(1, 28)),
                    Nome = $"{primeiroNome} {segundoNome}",
                    NumeroIdentificacaoFiscal = $"{new Random().Next(200000000, 299999999)}",
                    Username = $"{primeiroNome}.{segundoNome}",
                    Password = "password",
                    Morada = new Morada
                    {
                        CodigoPostal = "3700111",
                        Distrito = $"{cidade}",
                        Concelho = $"{cidade}",
                        Localidade = $"{cidade}",
                        Endereco = "Rua nr" + i,
                        Nome = "Morada Principal"
                    }
                };

                ctx.Clientes.Add(clienteNovo);
            }

            ctx.SaveChanges();
        }

        private static void CriacaoNovosLivros(AmazoniaContexto ctx, int quantidade)
        {
            var nomes = new List<string> { "Dom Casmurro", "O Bandolim do Capitão Corelli", "O Conde de Monte Cristo", "Um estudo em vermelho", "O Processo", "Cem anos de solidão", "O Coração das Trevas", "Eu, Robô", "O Senhor dos Anéis", "Gerra e Paz" };
            var autores = new List<string> { "Leo Tolstói", "J.R.R. Tolkien", "Isaac Asimov", "Joseph Conrad", "Gabriel García Márquez", "Franz Kafka", "Arthur Conan Doyle", "Alexandre Dumas", "Louis de Bernières", "Machado de Assis", "Antoine de Saint-Exupéry" };

            for (var i = 0; i < quantidade; i++)
            {
                var livroDigital = new LivroDigital
                {
                    Nome = nomes[new Random().Next(nomes.Count)],
                    Autor = autores[new Random().Next(autores.Count)],
                    Descricao = "Livro Digital",
                    FormatoFicheiro = "PDF",
                    Idioma = DAL.Idioma.Portugues,
                    InformacoesLicenca = "Sem informação",
                    Preco = new Random().Next(30, 100)

                };
                var livroAudio = new AudioLivro
                {
                    Nome = nomes[new Random().Next(nomes.Count)],
                    Autor = autores[new Random().Next(autores.Count)],
                    Descricao = "Audio Livro",
                    FormatoFicheiro = "WMA",
                    Idioma = DAL.Idioma.Portugues,
                    Preco = new Random().Next(25, 90)

                };
                var livroImpresso = new LivroImpresso
                {
                    Nome = nomes[new Random().Next(nomes.Count)],
                    Autor = autores[new Random().Next(autores.Count)],
                    Descricao = "Livro Impresso",
                    Idioma = DAL.Idioma.Portugues,
                    Preco = new Random().Next(35, 100),
                    Altura = new Random().Next(15, 20),
                    Largura = new Random().Next(10, 15),
                    Profundidade = new Random().Next(5, 15)
                };

                var livroPeriodico = new LivroPeriodico
                {
                    Nome = nomes[new Random().Next(nomes.Count)],
                    Autor = autores[new Random().Next(autores.Count)],
                    Descricao = "Revista",
                    Idioma = DAL.Idioma.Portugues,
                    Preco = new Random().Next(35, 100),
                    DataLancamento = new DateTime(new Random().Next(1950, 2015), new Random().Next(1, 12), new Random().Next(1, 28))
                };
                ctx.Add(livroAudio);
                ctx.Add(livroDigital);
                ctx.Add(livroImpresso);
                ctx.Add(livroPeriodico);
            }
            ctx.SaveChanges();
        }
        #endregion

        //Read
        #region Leitura de Dados da Base de Dados
        private static void LeituraDeClientesEMoradas(AmazoniaContexto ctx)
        {
            //Load Client + Morada
            var listaDeClientes = ctx.Clientes.Include(cliente=>cliente.Morada);
            foreach (var cliente in listaDeClientes)
            {
                //Console.WriteLine($"Nome do Cliente: {cliente.Nome} \n Morada do Cliente: {cliente.Morada.Distrito}");
            } 
        }

        private static void LeituraDeLivros(AmazoniaContexto ctx)
        {
            //Load Livros
            var listaDeLivros = ctx.Livros;
            foreach (var livro in listaDeLivros)
            {
                //Console.WriteLine($"Nome do Livro: {livro.Nome}\n Tipo de Livro: {livro.GetType()}");
            }

            //Load Livros Digitais
            var listaDeLivrosDigitais = ctx.Livros.Where( livro=> livro.TipoDeLivro == "Livro Digital" );
            foreach (var livro in listaDeLivrosDigitais)
            {
                //Console.WriteLine($"Nome do Livro: {livro.Nome}\n Tipo de Livro: {livro.GetType()}");
            }
            //Load Livros Digitais
            var listaDeLivrosAudio = ctx.AudioLivros.Where(livro => livro.Autor.StartsWith("Ant"));
            foreach (var livro in listaDeLivrosAudio)
            {
                Console.WriteLine($"Nome do Livro: {livro.Nome}\n Tipo de Livro: {livro.GetType()}");
            }
        }
        #endregion

        //Update
        #region Update de Dados na Base de Dados
        private static void AtualizarBaseDeDados(AmazoniaContexto ctx)
        {

            //Load Client + Morada
            var listaDeClientes = ctx.Clientes.Where(cliente=>cliente.Nome.StartsWith("A"));
            foreach (var cliente in listaDeClientes)
            {
                Console.WriteLine($"Nome do Cliente: {cliente.Nome} Password:{cliente.Password}");
                //Alterar password
                cliente.Password = "alterada";
            }
            //Guardar alterações
            ctx.SaveChanges();
        }
        #endregion

        //Delete
        #region Delete de Dados na Base de Dados
        private static void DeleteClienteDaBaseDeDados(AmazoniaContexto ctx)
        {

            //Load Client
            var listaDeClientes = ctx.Clientes.Where(cliente => cliente.Nome.StartsWith("Joana"));
            foreach (var cliente in listaDeClientes)
            {
                Console.WriteLine($"Nome do Cliente: {cliente.Nome}");
            }
            ctx.Clientes.Remove(listaDeClientes.FirstOrDefault());
            ctx.SaveChanges();
        }
        #endregion
        #endregion
    }
}