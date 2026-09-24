using System.Collections.Generic;

public class Sistema
{
    public List<Equipe> Equipes { get; } = new List<Equipe>();

    public List<Partida> Partidas { get; } = new List<Partida>();

    public void AdicionarEquipe(Equipe equipe)
    {
        Equipes.Add(equipe);
    }

    public void RemoverEquipe(Equipe equipe)
    {
        Equipes.Remove(equipe);
    }

    public void AdicionarPartida(Partida partida)
    {
        Partidas.Add(partida);
    }

    public void RemoverPartida(Partida partida)
    {
        Partidas.Remove(partida);
    }
}