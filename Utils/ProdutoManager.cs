using CrawlerDados.Data;
using CrawlerDados.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDados.Utils
{
    class ProdutoManager
    {
        // Método para processar os dados da resposta e obter produtos
        public static List<Produto> ObterNovosProdutos(string responseData)
        {
            // Desserializar os dados da resposta para uma lista de produtos
            List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(responseData);
            return produtos;
        }

        // Método para verificar se o produto já foi registrado no banco de dados
        public static bool ProdutoJaRegistrado(int idProduto)
        {
            using (var context = new LogContext())
            {
                return context.Logs.Any(log => log.IdProd == idProduto);
            }
        }
    }
}
