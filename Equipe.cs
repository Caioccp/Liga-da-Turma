using System;

public class Equipe
{
    public string Nome { get; set; }

    public Equipe(string nome)
    {
        Nome = nome;
    }

    public void ExibirEquipe()
    {
        Console.WriteLine($"Equipe: {Nome}");
    }
}