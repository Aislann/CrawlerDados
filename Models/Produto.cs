using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDados.Models
{
    // Classe para representar um produto
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double valor { get; set; }
        public string urlProduto { get; set; }
    }
}
