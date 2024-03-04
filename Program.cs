using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CrawlerDados.Data;
using CrawlerDados.Utils;
using CrawlerDados.Models;
using Microsoft.VisualBasic;

class Program
{
    public static string? Email;
    public static string? Telefone;
    public static string? Verificar;    
    static void Main(string[] args)
    {
        Console.Write("Digite o destinatario outlook(exemplo@outlook.com) que será enviado as informações: ");
        Email = Console.ReadLine().Trim().ToUpper();

        Console.Write("Deseja enviar uma mensagem pelo WhatsApp? (S/N): ");
        Verificar = Console.ReadLine().Trim().ToUpper();

        if (Verificar == "S")
        {
            Console.Write("Digite o numero ao qual será enviado a mensagem, nesse exato modelo(5579999999999): ");
            Telefone = Console.ReadLine().Trim().ToUpper();
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