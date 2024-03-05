using CrawlerDados.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Net.Http;
using CrawlerDados.Models;


namespace CrawlerDados.Send
{

    public static class SendZap
    {
        public static async Task EnviarZap(string nomeProdutoMagalu, string nomeProdutoMercado, decimal precoProdutoMercadoLivre, decimal precoProdutoMagazineLuiza, string melhorCompra, string urlProduto, int idProduto, string numTelefone , string NomeProduto)
        {

                using (HttpClient client = new HttpClient())
                {
                    // URL da API
                    string apiUrl = "https://app.whatsgw.com.br/api/WhatsGw/Send";

                    // Dados da solicitação
                    string apiKey = "977bf93d-d4c5-47af-bd6e-f27d08f6c30a";
                    string phoneNumber = "5579988566494";
                    string contactPhoneNumber = Program.Telefone;
                    string messageCustomId = "yoursoftwareid";
                    string messageType = "text";
                    string messageBody = $"Benchmarking: {NomeProduto}\n" +
                               $"\n" +
                               $"*Mercado Livre*\n" +
                               $"Produto: {nomeProdutoMercado}\n" +
                               $"Preço: R${precoProdutoMercadoLivre}\n" +
                               $"\n" +
                               $"*Magazine Luiza*\n" +
                               $"Produto: {nomeProdutoMagalu}" +
                               $"\nPreço: R${precoProdutoMagazineLuiza}\n" +
                               $"\n" +
                               "*Melhor compra:*" +
                               $"\n{melhorCompra} - {urlProduto}\n" +
                               $"\n" +
                               $"0000001177\n" +
                               $"Usuário: AislanOliveira";

                    string checkStatus = "1";

                    // Criar objeto de dados em formato JSON
                    string jsonData = $"{{\"apikey\":\"{apiKey}\",\"phone_number\":\"{phoneNumber}\",\"contact_phone_number\":\"{contactPhoneNumber}\",\"message_custom_id\":\"{messageCustomId}\",\"message_type\":\"{messageType}\",\"message_body\":\"{messageBody}\",\"check_status\":\"{checkStatus}\"}}";

                    // Criar conteúdo da solicitação
                    StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Enviar solicitação POST
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    // Lidar com a resposta
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        LogManager.RegistrarLog("0000001177", "AislanOliveira", DateTime.Now, "Envio - Whatsapp", "Sucesso", idProduto);
                        Console.WriteLine($"Mensagem enviada com sucesso! ");
                        
                    }
                    else
                    {
                    Console.WriteLine($"A mensagem não foi enviada para o whatsapp!");
                    Console.WriteLine($"Erro: {response.StatusCode}");
                    }
                }
            }


            
        }
    }
