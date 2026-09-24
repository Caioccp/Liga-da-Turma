using System;

public class Menu
{
    public void Exibir()
    {
        int opcao;

        do
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║              LIGA DA TURMA               ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("║ 1 - Cadastrar equipes                    ║");
            Console.WriteLine("║ 2 - Consultar equipes                    ║");
            Console.WriteLine("║ 3 - Registrar partida                    ║");
            Console.WriteLine("║ 4 - Consultar histórico                  ║");
            Console.WriteLine("║ 5 - Cadastrar festival                   ║");
            Console.WriteLine("║ 6 - Gerar convite do festival            ║");
            Console.WriteLine("║ 7 - Gerar cartão de resultado            ║");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("║ 0 - Sair                                 ║");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════════════════════════════════════════╝");

            Console.ResetColor();

            Console.Write("\nEscolha uma opção: ");

            string? entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out opcao))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOpção inválida!");
                Console.ResetColor();

                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();

                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarEquipes();
                    break;

                case 2:
                    ConsultarEquipes();
                    break;

                case 3:
                    RegistrarPartida();
                    break;

                case 4:
                    ConsultarHistorico();
                    break;

                case 5:
                    CadastrarFestival();
                    break;

                case 6:
                    GerarConvite();
                    break;

                case 7:
                    GerarCartaoResultado();
                    break;

                case 0:
                    Console.WriteLine("\nEncerrando o programa...");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nOpção inválida!");
                    Console.ResetColor();

                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                    break;
            }

        } while (opcao != 0);
    }

    void CadastrarEquipes()
    {
        Console.Clear();

        Console.WriteLine("===== CADASTRAR EQUIPES =====\n");
        Console.WriteLine("Aqui ficará o cadastro das equipes.");

        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }

    void ConsultarEquipes()
    {
        Console.Clear();

        Console.WriteLine("===== EQUIPES CADASTRADAS =====\n");
        Console.WriteLine("Aqui aparecerão as equipes cadastradas.");

        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }

    void RegistrarPartida()
    {
        Console.Clear();

        Console.WriteLine("===== REGISTRAR PARTIDA =====\n");
        Console.WriteLine("Aqui será feito o registro das partidas.");
        Console.WriteLine("Modalidades: Futsal e eSports.");

        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }

    void ConsultarHistorico()
    {
        Console.Clear();

        Console.WriteLine("===== HISTÓRICO DE PARTIDAS =====\n");
        Console.WriteLine("Aqui aparecerão todas as partidas registradas.");

        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }

    void CadastrarFestival()
    {
        Console.Clear();

        Console.WriteLine("===== CADASTRAR FESTIVAL =====\n");

        Console.WriteLine("Aqui serão cadastrados:");
        Console.WriteLine("- Nome do festival");
        Console.WriteLine("- Local");
        Console.WriteLine("- Data");
        Console.WriteLine("- Horário");

        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }

    void GerarConvite()
    {
        Console.Clear();

        Console.WriteLine("===== CONVITE DO FESTIVAL =====\n");
        Console.WriteLine("Aqui será gerado o convite textual.");

        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }

    void GerarCartaoResultado()
    {
        Console.Clear();

        Console.WriteLine("===== CARTÃO DE RESULTADO =====\n");
        Console.WriteLine("Aqui será gerado o cartão de resultado da partida.");

        Console.WriteLine("\nPressione ENTER para voltar...");
        Console.ReadLine();
    }
}