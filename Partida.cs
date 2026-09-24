using System;

public class Partida
{
    public Equipe Equipe1 { get; private set; }
    public Equipe Equipe2 { get; private set; }

    public string Modalidade { get; private set; }

    public int PlacarEquipe1 { get; private set; }
    public int PlacarEquipe2 { get; private set; }

    public Partida(Equipe equipe1, Equipe equipe2, string modalidade)
    {
        Equipe1 = equipe1;
        Equipe2 = equipe2;

        // Só permite modalidades cadastradas
        if (modalidade != "Futsal" &&
            modalidade != "Voleibol" &&
            modalidade != "Basquete" &&
            modalidade != "Beisebol")
        {
            throw new ArgumentException("Modalidade inválida.");
        }

        Modalidade = modalidade;

        PlacarEquipe1 = 0;
        PlacarEquipe2 = 0;
    }

    public void RegistrarResultado(int placarEquipe1, int placarEquipe2)
    {
        if (placarEquipe1 < 0 || placarEquipe2 < 0)
        {
            throw new ArgumentException("O placar não pode ser negativo.");
        }

        PlacarEquipe1 = placarEquipe1;
        PlacarEquipe2 = placarEquipe2;
    }

    public void AlterarResultado(int novoPlacar1, int novoPlacar2)
    {
        if (novoPlacar1 < 0 || novoPlacar2 < 0)
        {
            throw new ArgumentException("O placar não pode ser negativo.");
        }

        PlacarEquipe1 = novoPlacar1;
        PlacarEquipe2 = novoPlacar2;
    }

    public void ExibirPartida()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("           PARTIDA");
        Console.WriteLine("=================================");
        Console.WriteLine($"Equipe 1: {Equipe1.Nome}");
        Console.WriteLine($"Equipe 2: {Equipe2.Nome}");
        Console.WriteLine($"Modalidade: {Modalidade}");
        Console.WriteLine($"Placar: {PlacarEquipe1} x {PlacarEquipe2}");
        Console.WriteLine("=================================");
    }
}