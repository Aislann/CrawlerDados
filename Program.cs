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

class Program
{
    static void Main(string[] args)
    {
        // Definir o intervalo de tempo para 5 minutos (300.000 milissegundos)
        int intervalo = 60000;

        // Criar um temporizador que dispara a cada 5 minutos
        Timer timer = new Timer(VerificaProduto.VerificarNovoProduto, null, 0, intervalo);

        // Manter a aplicação rodando
        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}