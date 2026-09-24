using System;

public class Festival
{
    public string Nome { get; private set; }
    public string Local { get; private set; }
    public string Data { get; private set; }
    public string Horario { get; private set; }

    public Festival(string nome, string local, string data, string horario)
    {
        Nome = nome;
        Local = local;
        Data = data;
        Horario = horario;
    }

    public void AlterarDados(
        string nome,
        string local,
        string data,
        string horario)
    {
        Nome = nome;
        Local = local;
        Data = data;
        Horario = horario;
    }

    public void ExibirFestival()
    {
        Console.WriteLine("===== FESTIVAL =====");
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Local: {Local}");
        Console.WriteLine($"Data: {Data}");
        Console.WriteLine($"Horário: {Horario}");
    }
}