using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Amazonia.eCommerce.Logging
{
    public class LoggerCustomizado : ILogger
    {
        public void Log(string logData)
        {
            var _fileName = "D:/Projetos/Amazonia.pt/LogsTest/log.txt";
            File.AppendAllText(_fileName,logData);
        }
    }
}
