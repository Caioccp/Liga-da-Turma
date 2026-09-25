using System;

public class Menu
{
    private Sistema sistema;

    public Menu(Sistema sistema)
    {
        this.sistema = sistema;
    }

    public void Exibir()
    {
        int opcao;

        do
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║              LIGA DA TURMA              ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("║ 1 - Cadastrar equipe                     ║");
            Console.WriteLine("║ 2 - Consultar equipes                    ║");
            Console.WriteLine("║ 3 - Alterar equipe                       ║");
            Console.WriteLine("║ 4 - Excluir equipe                       ║");
            Console.WriteLine("║ 5 - Registrar partida                    ║");
            Console.WriteLine("║ 6 - Consultar partidas                   ║");
            Console.WriteLine("║ 7 - Alterar resultado                    ║");
            Console.WriteLine("║ 8 - Excluir partida                      ║");

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("║ 0 - Sair                                 ║");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("╚══════════════════════════════════════════╝");

            Console.ResetColor();

            Console.Write("\nEscolha uma opção: ");

            string entrada = Console.ReadLine() ?? "";

            if (!int.TryParse(entrada, out opcao))
            {
                Console.WriteLine("\nOpção inválida!");
                Pausar();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    CadastrarEquipe();
                    break;

                case 2:
                    ConsultarEquipes();
                    break;

                case 3:
                    AlterarEquipe();
                    break;

                case 4:
                    ExcluirEquipe();
                    break;

                case 5:
                    RegistrarPartida();
                    break;

                case 6:
                    ConsultarPartidas();
                    break;

                case 7:
                    AlterarResultado();
                    break;

                case 8:
                    ExcluirPartida();
                    break;

                case 0:
                    Console.WriteLine("\nEncerrando o programa...");
                    break;

                default:
                    Console.WriteLine("\nOpção inválida!");
                    Pausar();
                    break;
            }

        } while (opcao != 0);
    }

    private void CadastrarEquipe()
    {
        Console.Clear();

        Console.WriteLine("===== CADASTRAR EQUIPES =====\n");

        Console.WriteLine("Digite 0 a qualquer momento para cancelar.\n");

        while (true)
        {
            Console.Write("Nome da equipe: ");

            string nome = Console.ReadLine() ?? "";

            if (nome == "0")
            {
                Console.WriteLine("\nCadastro cancelado.");
                Pausar();
                return;
            }

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("O nome não pode ficar vazio.\n");
                continue;
            }

            Equipe equipe = new Equipe(nome);

            sistema.AdicionarEquipe(equipe);

            Console.WriteLine($"\nEquipe '{nome}' cadastrada com sucesso!\n");

            Console.Write("Deseja cadastrar outra equipe? (S/N): ");
            string resposta = Console.ReadLine() ?? "";

            if (resposta.ToUpper() != "S")
            {
                break;
            }
        }

        Pausar();
    }

    private void ConsultarEquipes()
    {
        Console.Clear();

        Console.WriteLine("===== EQUIPES CADASTRADAS =====\n");

        if (sistema.Equipes.Count == 0)
        {
            Console.WriteLine("Nenhuma equipe cadastrada.");
            Pausar();
            return;
        }

        for (int i = 0; i < sistema.Equipes.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {sistema.Equipes[i].Nome}");
        }

        Pausar();
    }

    private void AlterarEquipe()
    {
        Console.Clear();

        Console.WriteLine("===== ALTERAR EQUIPE =====\n");

        if (sistema.Equipes.Count == 0)
        {
            Console.WriteLine("Nenhuma equipe cadastrada.");
            Pausar();
            return;
        }

        ConsultarEquipesSemPausa();

        Console.Write("\nDigite o número da equipe que deseja alterar: ");

        if (!int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.WriteLine("Número inválido.");
            Pausar();
            return;
        }

        if (numero < 1 || numero > sistema.Equipes.Count)
        {
            Console.WriteLine("Equipe não encontrada.");
            Pausar();
            return;
        }

        Equipe equipe = sistema.Equipes[numero - 1];

        Console.Write($"\nNovo nome para '{equipe.Nome}': ");

        string novoNome = Console.ReadLine() ?? "";

        if (novoNome == "0")
        {
            Console.WriteLine("\nAlteração cancelada.");
            Pausar();
            return;
        }

        if (string.IsNullOrWhiteSpace(novoNome))
        {
            Console.WriteLine("O nome não pode ficar vazio.");
            Pausar();
            return;
        }

        equipe.AlterarNome(novoNome);

        Console.WriteLine("\nEquipe alterada com sucesso!");

        Pausar();
    }

    private void ExcluirEquipe()
    {
        Console.Clear();

        Console.WriteLine("===== EXCLUIR EQUIPE =====\n");

        if (sistema.Equipes.Count == 0)
        {
            Console.WriteLine("Nenhuma equipe cadastrada.");
            Pausar();
            return;
        }

        ConsultarEquipesSemPausa();

        Console.Write("\nDigite o número da equipe que deseja excluir: ");

        if (!int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.WriteLine("Número inválido.");
            Pausar();
            return;
        }

        if (numero < 1 || numero > sistema.Equipes.Count)
        {
            Console.WriteLine("Equipe não encontrada.");
            Pausar();
            return;
        }

        Equipe equipe = sistema.Equipes[numero - 1];

        Console.Write($"Tem certeza que deseja excluir '{equipe.Nome}'? (S/N): ");

        string resposta = Console.ReadLine() ?? "";

        if (resposta.ToUpper() != "S")
        {
            Console.WriteLine("\nExclusão cancelada.");
            Pausar();
            return;
        }

        sistema.RemoverEquipe(equipe);

        Console.WriteLine("\nEquipe excluída com sucesso!");

        Pausar();
    }

    private void RegistrarPartida()
    {
        Console.Clear();

        Console.WriteLine("===== REGISTRAR PARTIDA =====\n");

        if (sistema.Equipes.Count < 2)
        {
            Console.WriteLine("É necessário ter pelo menos 2 equipes cadastradas.");
            Pausar();
            return;
        }

        ConsultarEquipesSemPausa();

        Console.WriteLine("\nDigite 0 para cancelar.");

        Console.Write("\nNúmero da primeira equipe: ");

        if (!int.TryParse(Console.ReadLine(), out int numero1))
        {
            Console.WriteLine("Número inválido.");
            Pausar();
            return;
        }

        if (numero1 == 0)
        {
            Console.WriteLine("Cadastro da partida cancelado.");
            Pausar();
            return;
        }

        if (numero1 < 1 || numero1 > sistema.Equipes.Count)
        {
            Console.WriteLine("Equipe não encontrada.");
            Pausar();
            return;
        }

        Console.Write("Número da segunda equipe: ");

        if (!int.TryParse(Console.ReadLine(), out int numero2))
        {
            Console.WriteLine("Número inválido.");
            Pausar();
            return;
        }

        if (numero2 == 0)
        {
            Console.WriteLine("Cadastro da partida cancelado.");
            Pausar();
            return;
        }

        if (numero2 < 1 || numero2 > sistema.Equipes.Count)
        {
            Console.WriteLine("Equipe não encontrada.");
            Pausar();
            return;
        }

        if (numero1 == numero2)
        {
            Console.WriteLine("Uma equipe não pode jogar contra ela mesma.");
            Pausar();
            return;
        }

        Equipe equipe1 = sistema.Equipes[numero1 - 1];
        Equipe equipe2 = sistema.Equipes[numero2 - 1];

        // ESCOLHA DA MODALIDADE
        Console.Clear();

        Console.WriteLine("===== ESCOLHER MODALIDADE =====\n");

        Console.WriteLine("1 - Futsal");
        Console.WriteLine("2 - Voleibol");
        Console.WriteLine("3 - Basquete");
        Console.WriteLine("4 - Beisebol");
        Console.WriteLine("0 - Cancelar");

        Console.Write("\nEscolha a modalidade: ");

        string opcaoModalidade = Console.ReadLine() ?? "";

        string modalidade;

        switch (opcaoModalidade)
        {
            case "1":
                modalidade = "Futsal";
                break;

            case "2":
                modalidade = "Voleibol";
                break;

            case "3":
                modalidade = "Basquete";
                break;

            case "4":
                modalidade = "Beisebol";
                break;

            case "0":
                Console.WriteLine("\nCadastro da partida cancelado.");
                Pausar();
                return;

            default:
                Console.WriteLine("\nModalidade inválida.");
                Pausar();
                return;
        }

        int id = sistema.GerarIdPartida();
    
        Partida partida = new Partida(id, equipe1, equipe2, modalidade);

        sistema.AdicionarPartida(partida);

        Console.WriteLine($"\nPartida de {modalidade} cadastrada com sucesso!");

        Console.Write("\nDeseja registrar o resultado agora? (S/N): ");

        string resposta = Console.ReadLine() ?? "";

        if (resposta.ToUpper() == "S")
        {
            RegistrarResultadoDaPartida(partida);
        }

        Pausar();
    }

    private void ConsultarPartidas()
    {
        Console.Clear();

        Console.WriteLine("===== PARTIDAS CADASTRADAS =====\n");

        if (sistema.Partidas.Count == 0)
        {
            Console.WriteLine("Nenhuma partida cadastrada.");
            Pausar();
            return;
        }

        for (int i = 0; i < sistema.Partidas.Count; i++)
        {
            sistema.Partidas[i].ExibirPartida();

            Console.WriteLine();
        }

        Pausar();
    }

    private void AlterarResultado()
    {
        Console.Clear();

        Console.WriteLine("===== ALTERAR RESULTADO =====\n");

        if (sistema.Partidas.Count == 0)
        {
            Console.WriteLine("Nenhuma partida cadastrada.");
            Pausar();
            return;
        }

        for (int i = 0; i < sistema.Partidas.Count; i++)
        {
            Partida partida = sistema.Partidas[i];

            Console.WriteLine(
                $"{i + 1} - {partida.Equipe1.Nome} " +
                $"{partida.PlacarEquipe1} x {partida.PlacarEquipe2} " +
                $"{partida.Equipe2.Nome} " +
                $"({partida.Modalidade})"
            );
        }

        Console.Write("\nDigite o número da partida: ");

        if (!int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.WriteLine("Número inválido.");
            Pausar();
            return;
        }

        if (numero < 1 || numero > sistema.Partidas.Count)
        {
            Console.WriteLine("Partida não encontrada.");
            Pausar();
            return;
        }

        Partida partidaSelecionada = sistema.Partidas[numero - 1];

        RegistrarResultadoDaPartida(partidaSelecionada);

        Pausar();
    }

    private void RegistrarResultadoDaPartida(Partida partida)
    {
        Console.WriteLine("\n===== RESULTADO =====");

        Console.Write($"Placar de {partida.Equipe1.Nome}: ");

        if (!int.TryParse(Console.ReadLine(), out int placar1))
        {
            Console.WriteLine("Placar inválido.");
            return;
        }

        Console.Write($"Placar de {partida.Equipe2.Nome}: ");

        if (!int.TryParse(Console.ReadLine(), out int placar2))
        {
            Console.WriteLine("Placar inválido.");
            return;
        }

        if (placar1 < 0 || placar2 < 0)
        {
            Console.WriteLine("O placar não pode ser negativo.");
            return;
        }

        partida.AlterarResultado(placar1, placar2);

        Console.WriteLine("\nResultado registrado com sucesso!");
    }

    private void ExcluirPartida()
    {
        Console.Clear();

        Console.WriteLine("===== EXCLUIR PARTIDA =====\n");

        if (sistema.Partidas.Count == 0)
        {
            Console.WriteLine("Nenhuma partida cadastrada.");
            Pausar();
            return;
        }

        for (int i = 0; i < sistema.Partidas.Count; i++)
        {
            Partida partida = sistema.Partidas[i];

            Console.WriteLine(
                $"{i + 1} - {partida.Equipe1.Nome} " +
                $"{partida.PlacarEquipe1} x {partida.PlacarEquipe2} " +
                $"{partida.Equipe2.Nome} " +
                $"({partida.Modalidade})"
            );
        }

        Console.Write("\nDigite o número da partida que deseja excluir: ");

        if (!int.TryParse(Console.ReadLine(), out int numero))
        {
            Console.WriteLine("Número inválido.");
            Pausar();
            return;
        }

        if (numero < 1 || numero > sistema.Partidas.Count)
        {
            Console.WriteLine("Partida não encontrada.");
            Pausar();
            return;
        }

        Partida partidaSelecionada = sistema.Partidas[numero - 1];

        Console.WriteLine(
            $"\nPartida: {partidaSelecionada.Equipe1.Nome} " +
            $"x {partidaSelecionada.Equipe2.Nome}"
        );

        Console.Write("Tem certeza que deseja excluir? (S/N): ");

        string resposta = Console.ReadLine() ?? "";

        if (resposta.ToUpper() != "S")
        {
            Console.WriteLine("\nExclusão cancelada.");
            Pausar();
            return;
        }

        sistema.RemoverPartida(partidaSelecionada);

        Console.WriteLine("\nPartida excluída com sucesso!");

        Pausar();
    }

    private void ConsultarEquipesSemPausa()
    {
        Console.WriteLine("===== EQUIPES =====\n");

        for (int i = 0; i < sistema.Equipes.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {sistema.Equipes[i].Nome}");
        }
    }

    private void Pausar()
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }
}