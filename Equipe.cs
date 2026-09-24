using System;

public class Equipe
{
    public string Nome { get; private set; }

    public Equipe(string nome)
    {
        Nome = nome;
    }

    public void AlterarNome(string novoNome)
    {
        Nome = novoNome;
    }

    public void ExibirEquipe()
    {
        Console.WriteLine($"Equipe: {Nome}");
    }
}