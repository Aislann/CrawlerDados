using CrawlerDados.Models;
using CrawlerDados.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

public static class SendEmail
{

    public static void EnviarEmail(string nomeProdutoMagalu, string nomeProdutoMercado, decimal precoProdutoMercadoLivre, decimal precoProdutoMagazineLuiza, string melhorCompra, string urlProduto, int idProduto, Informations informations)
    {

        // Configurações do servidor SMTP do Gmail
        string smtpServer = "smtp-mail.outlook.com"; // Servidor SMTP do Gmail
        int porta = 587; // Porta SMTP do Gmail para TLS/STARTTLS
        string remetente = "aislanfake@outlook.com"; // Seu endereço de e-mail do Gmail
        string senha = "senhateste1"; // Sua senha do Gmail

        // Configurar cliente SMTP
        using (SmtpClient client = new SmtpClient(smtpServer, porta))
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(remetente, senha);
            client.EnableSsl = true; // Habilitar SSL/TLS

            // Construir mensagem de e-mail
            MailMessage mensagem = new MailMessage(remetente, informations.Email)
            {
                Subject = "Resultado da comparação de preços",
                Body = $"Mercado Livre\n" +
                       $"Produto: {nomeProdutoMercado}\n" +
                       $"Preço: R${precoProdutoMercadoLivre}\n" +
                       $"\n" +
                       $"Magazine Luiza\n" +
                       $"Produto: {nomeProdutoMagalu}" +
                       $"\nPreço: R${precoProdutoMagazineLuiza}\n" +
                       $"\n" +
                       "Melhor compra:" +
                       $"\n{melhorCompra} - {urlProduto}"
            };

            // Enviar e-mail
            client.Send(mensagem);

            Console.WriteLine(precoProdutoMercadoLivre);
            Console.WriteLine(precoProdutoMagazineLuiza);
            LogManager.RegistrarLog("0000001177", "AislanOliveira", DateTime.Now, "Envio - Email", "Sucesso", idProduto);
        }
    }
}