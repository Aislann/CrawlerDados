using CrawlerDados.Data;
using CrawlerDados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDados.Utils
{
    class LogManager
    {
        // Método para registrar um log no banco de dados
        public static void RegistrarLog(string codRob, string usuRob, DateTime dateLog, string processo, string infLog, int idProd)
        {
            using (var context = new LogContext())
            {
                var log = new Log
                {
                    CodRob = codRob,
                    UsuRob = usuRob,
                    DateLog = dateLog,
                    Processo = processo,
                    InfLog = infLog,
                    IdProd = idProd
                };
                context.Logs.Add(log);
                context.SaveChanges();
            }
        }
    }
}
