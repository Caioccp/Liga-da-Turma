using System.Collections.Generic;

public class Sistema
{

    private int proximoIdPartida = 1;

    public List<Equipe> Equipes { get; } = new List<Equipe>();

    public List<Partida> Partidas { get; } = new List<Partida>();

    public Festival? Festival { get; private set; }

    public int GerarIdPartida()
    {
        return proximoIdPartida++;
    }

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

    public void DefinirFestival(Festival festival)
    {
        Festival = festival;
    }
}