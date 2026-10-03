public class PartidaVoleibol : Partida
{
    public PartidaVoleibol(
        int id,
        Equipe equipe1,
        Equipe equipe2)
        : base(id, equipe1, equipe2, "Voleibol")
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

    public override string GerarTexto()
    {
        string equipe1 = Equipe1.Nome;
        string equipe2 = Equipe2.Nome;

        if (ResultadoRegistrado)
        {
            if (PlacarEquipe1 > PlacarEquipe2)
            {
                equipe1 = $"🏆 {equipe1}";
            }
            else if (PlacarEquipe2 > PlacarEquipe1)
            {
                equipe2 = $"🏆 {equipe2}";
            }
        }

        return $"{equipe1} x {equipe2}\n" +
               $"Modalidade: {Modalidade}\n" +
               $"Placar: {PlacarEquipe1} x {PlacarEquipe2}\n" +
               $"Resultado: {ObterResultado()}";
    }
}