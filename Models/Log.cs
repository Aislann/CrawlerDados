﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDados.Models
{
    // Classe de modelo para os logs
    public class Log
    {
        [Key]
        public int IdLog { get; set; }
        public string CodRob { get; set; }
        public string UsuRob { get; set; }
        public DateTime DateLog { get; set; }
        public string Processo { get; set; }
        public string InfLog { get; set; }
        public int IdProd { get; set; }

        //public int iDlOG { get; set; }

        //public string CodigoRobo { get; set; }

        //public string UsuarioRobo { get; set; }

        //public DateTime DateLog { get; set; }

        //public string Etapa { get; set; }

        //public string InformacaoLog { get; set; }

        //public int? idProdutoAPI { get; set; }
    }
}
