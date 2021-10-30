using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazonia.DAL.Utils
{
    public static class Exemplo
    {
        public static string ObterValorDoConfig(string chave)
        {
            var valorDaChave = ConfigurationManager.AppSettings[chave];
            return valorDaChave;
        }
    }
}
