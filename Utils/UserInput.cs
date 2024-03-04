using System;

public static class UserInput
{
    public static bool ObterRespostaEnvioWhatsApp()
    {
        Console.Write("Deseja enviar uma mensagem pelo WhatsApp? (S/N): ");
        string resposta = Console.ReadLine().Trim().ToUpper();
        return resposta == "S";
    }
}
