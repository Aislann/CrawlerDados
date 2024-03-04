using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrawlerDados.Models;
using CrawlerDados.Utils;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite o email(outlook) que será enviado as informações: ");
        string respostaEmail = Console.ReadLine().Trim().ToUpper();
        Console.Write("Deseja enviar uma mensagem pelo WhatsApp? (S/N): ");
        string resposta = Console.ReadLine().Trim().ToUpper();
        Informations informations = new Informations();

        informations.Email = respostaEmail;

        if (resposta == "S")
        {
            Console.Write("Digite o numero ao qual será enviado a mensagem, nesse exato modelo(5579999999999): ");
            string respostaTelefone = Console.ReadLine().Trim().ToUpper();
            informations.Telefone = respostaTelefone;
        }
        // Definir o intervalo de tempo para 5 minutos (300.000 milissegundos)
        int intervalo = 60000;

        // Criar um temporizador que dispara a cada 5 minutos
        Timer timer = new Timer(VerificaProduto.VerificarNovoProduto, null, 0, intervalo);

        // Manter a aplicação rodando
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}