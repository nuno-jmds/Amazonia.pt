using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Infraestrutura
{
    public class AmazoniaException:Exception
    {

        public AmazoniaException(string tipoErro)
        {
            var path = @"D:\Projetos\Amazonia.pt\";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            var log = $"{DateTime.Now} :: {tipoErro}";

            File.WriteAllText(@"log.txt",log);
        }
    }
}
