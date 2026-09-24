using System;

public class Partida
{
    public Equipe Equipe1 { get; set; }
    public Equipe Equipe2 { get; set; }
    public string Modalidade { get; set; }
    public int PlacarEquipe1 { get; set; }
    public int PlacarEquipe2 { get; set; }

    public Partida(Equipe equipe1, Equipe equipe2, string modalidade)
    {
        Equipe1 = equipe1;
        Equipe2 = equipe2;
        Modalidade = modalidade;
        PlacarEquipe1 = 0;
        PlacarEquipe2 = 0;
    }

    public void ExibirPartida()
    {
        Console.WriteLine("===== PARTIDA =====");
        Console.WriteLine($"Equipe 1: {Equipe1.Nome}");
        Console.WriteLine($"Equipe 2: {Equipe2.Nome}");
        Console.WriteLine($"Modalidade: {Modalidade}");
        Console.WriteLine($"Placar: {PlacarEquipe1} x {PlacarEquipe2}");
    }
}