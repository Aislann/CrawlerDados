﻿using CrawlerDados.Models;
using CrawlerDados.Send;
using CrawlerDados.Utils;

public class Benchmarking
{

    public static void CompararValores(ProdutoScraper precoMagazineLuiza, ProdutoScraper precoMercadoLivre, int idProduto, string NomeProduto)
    {

        char[] charRemove = { 'R', '$', ' ' };
        // Converte as strings para decimal
        var precoMagaluvar = precoMagazineLuiza.Preco.Trim(charRemove);
        var precoMercadovar = precoMercadoLivre.Preco.Trim(charRemove);

        decimal precoMagalu;
        decimal precoMercado;

        decimal.TryParse(precoMagaluvar, out precoMagalu);
        decimal.TryParse(precoMercadovar, out precoMercado);

        // Valores convertidos com sucesso
        Console.WriteLine($"Valor Magazine Luiza: {precoMagalu}");
        Console.WriteLine($"Valor Mercado Livre: {precoMercado}\n");

        if (precoMagalu < precoMercado)
        {
            LogManager.RegistrarLog("0000001177", "AislanOliveira", DateTime.Now, "Menor Valor - Magazine Luiza", "Sucesso", idProduto);
            //Enviar email com o resultado da comparação
            SendEmail.EnviarEmail(precoMagazineLuiza.Titulo, precoMercadoLivre.Titulo, precoMercado, precoMagalu, "Magazine Luiza", precoMagazineLuiza.Url, idProduto, EnderecoEmail: Program.Email, NomeProduto);
            SendZap.EnviarZap(precoMagazineLuiza.Titulo, precoMercadoLivre.Titulo, precoMercado, precoMagalu, "Magazine Luiza", precoMagazineLuiza.Url, idProduto, numTelefone: Program.Telefone, NomeProduto);
        }
        else if (precoMercado < precoMagalu)
        {
            LogManager.RegistrarLog("0000001177", "AislanOliveira", DateTime.Now, "Menor Valor - Mercado Livre", "Sucesso", idProduto);
            SendEmail.EnviarEmail(precoMagazineLuiza.Titulo, precoMercadoLivre.Titulo, precoMercado, precoMagalu, "Mercado Livre", precoMercadoLivre.Url,idProduto, EnderecoEmail: Program.Email, NomeProduto);
            SendZap.EnviarZap(precoMagazineLuiza.Titulo, precoMercadoLivre.Titulo, precoMercado, precoMagalu, "Mercado Livre", precoMagazineLuiza.Url, idProduto, Program.Telefone, NomeProduto);
        }
    } 

    }






