using CrawlerDados.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDados.Data
{
    // Classe de contexto do banco de dados
    public class LogContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=PC03LAB2509\\SENAI; Initial Catalog=WebScraping; User Id=sa; Password=senai.123;");
            optionsBuilder.UseSqlServer("Data source=DESKTOP-CK9G4U8\\SQLEXPRESS; Initial Catalog=WebScraping; Trusted_Connection=TRUE;");
            //optionsBuilder.UseSqlServer(
            //    @"Data Source=SQL9001.site4now.net;" +
            //    "Initial Catalog=db_aa5b20_apialmoxarifado;" +
            //    "User id=db_aa5b20_apialmoxarifado_admin;" +
            //    "Password=master@123"
            //    );

        }
    }
}
