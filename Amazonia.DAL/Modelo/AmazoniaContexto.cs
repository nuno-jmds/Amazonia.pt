using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Modelo
{
    public class AmazoniaContexto:DbContext
    {


        public DbSet<Morada> Moradas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<AudioLivro> AudioLivros { get; set; }

        public DbSet<LivroDigital> LivroDigitals { get; set; }

        public DbSet<LivroPeriodico> LivroPeriodicos { get; set; }

        public DbSet<LivroImpresso> LivroImpressos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            var connectionString = @$"Server=(LocalDB)\MSSQLLocalDB;Database=Amazonia.pt;Trusted_Connection=True;";
            options.UseSqlServer(connectionString);
        }

        public DbSet<Venda> Vendas { get; set; }

        //Exemplo SQLITE
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{

        //    var connectionString = @$"Data Source=D:\Projetos\Amazonia.pt\Amazonia.DAL\DataBase.db";
        //    options.UseSqlite(connectionString);
        //}

    }
}
