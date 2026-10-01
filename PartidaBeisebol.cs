public class PartidaBeisebol : Partida
{
    public PartidaBeisebol(
        int id,
        Equipe equipe1,
        Equipe equipe2)
        : base(id, equipe1, equipe2, "Beisebol")
    {
    }

    public override string ObterResultado()
    {
        if (!ResultadoRegistrado)
        {
            return "Resultado ainda não registrado.";
        }

        if (PlacarEquipe1 > PlacarEquipe2)
        {
            return $"{Equipe1.Nome} venceu";
        }

        if (PlacarEquipe2 > PlacarEquipe1)
        {
            return $"{Equipe2.Nome} venceu";
        }

        return "Empate";
    }
}