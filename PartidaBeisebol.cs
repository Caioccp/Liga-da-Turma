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

    public string GerarTexto()
    {
        return $"🏆 {Equipe1.Nome} x {Equipe2.Nome}\n" +
           $"Modalidade: {Modalidade}\n" +
           $"Placar: {PlacarEquipe1} x {PlacarEquipe2}\n" +
           $"Resultado: {ObterResultado()}";
    }
}