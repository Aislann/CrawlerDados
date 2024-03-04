﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrawlerDados.Models;

namespace CrawlerDados.Utils
{
    class VerificaProduto
    {
        // Lista para armazenar produtos já verificados
        static List<Produto> produtosVerificados = new List<Produto>();
        public static void VerificarNovoProduto(object state)
        {
            Informations informations = new Informations();

            Console.Write("Digite o destinatario outlook(exemplo@outlook.com) que será enviado as informações: ");
            string respostaEmail = Console.ReadLine().Trim().ToUpper();
            informations.Email = respostaEmail;

            string username = "11164448";
            string senha = "60-dayfreetrial";
            string url = "http://regymatrix-001-site1.ktempurl.com/api/v1/produto/getall";

            //Console.Write("Deseja enviar uma mensagem pelo WhatsApp? (S/N): ");
            //string resposta = Console.ReadLine().Trim().ToUpper();

                Console.Write("Digite o numero ao qual será enviado a mensagem, nesse exato modelo(5579999999999): ");
                string respostaTelefone = Console.ReadLine().Trim().ToUpper();
                informations.Telefone = respostaTelefone;


            Benchmarking benchmarking = new Benchmarking();
            try
            {
                ApiClient apiClient = new ApiClient(username, senha);
                string responseData = apiClient.GetApiResponse(url).Result;

                // Processar os dados da resposta
                List<Produto> novosProdutos = ProdutoManager.ObterNovosProdutos(responseData);
                foreach (Produto produto in novosProdutos)
                {
                    if (!produtosVerificados.Exists(p => p.Id == produto.Id))
                    {
                        // Se é um novo produto, faça algo com ele
                        Console.WriteLine($"Novo produto encontrado: ID {produto.Id}, Nome: {produto.Nome}");
                        // Adicionar o produto à lista de produtos verificados
                        produtosVerificados.Add(produto);

                        

                        // Registra um log no banco de dados apenas se o produto for novo
                        if (!ProdutoManager.ProdutoJaRegistrado(produto.Id))
                        {
                            LogManager.RegistrarLog("0000001177", "AislanOliveira", DateTime.Now, "Consultar Dados - Verificação", "Sucesso", produto.Id);

                            MercadoLivreScraper mercadoLivreScraper = new MercadoLivreScraper();
                            MagazineLuizaScraper magazineLuizaScraper = new MagazineLuizaScraper();

                            // Obter preço da Magazine Luiza
                            var precoMagazineLuiza = magazineLuizaScraper.ObterPreco(produto.Nome, produto.Id);
                            // Obter preço do Mercado Livre
                            var precoMercadoLivre = mercadoLivreScraper.ObterPreco(produto.Nome, produto.Id);

                            Benchmarking.CompararValores(precoMagazineLuiza, precoMercadoLivre, produto.Id, produto.Nome, informations);

                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                // Imprimir mensagem de erro caso ocorra uma exceção
                Console.WriteLine($"Erro ao fazer a requisição: {ex.Message}");
            }

            
        }
    }
}
