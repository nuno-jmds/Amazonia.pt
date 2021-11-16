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
    }
}
