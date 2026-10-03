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
            Console.WriteLine("║              LIGA DA TURMA               ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("║ 1 - Cadastrar equipe(s)                  ║");
            Console.WriteLine("║ 2 - Consultar equipe(s)                  ║");
            Console.WriteLine("║ 3 - Alterar equipe(s)                    ║");
            Console.WriteLine("║ 4 - Excluir equipe(s)                    ║");
            Console.WriteLine("║ 5 - Registrar partida(s)                 ║");
            Console.WriteLine("║ 6 - Consultar partida(s)                 ║");
            Console.WriteLine("║ 7 - Excluir partida(s)                   ║");
            Console.WriteLine("║ 8 - Alterar resultado(s)                 ║");
            Console.WriteLine("║ 9 - Cadastrar festival(is)               ║");
            Console.WriteLine("║ 10 - Consultar festival(is)              ║");
            Console.WriteLine("║ 11 - Gerar convite(s) do festival(is)    ║");
            Console.WriteLine("║ 12 - Gerar cartão(ões) de resultado(is)  ║");


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
                opcao = -1;
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
                    ExcluirPartida();
                    break;

                case 8:
                    AlterarResultado();
                    break;

                case 9:
                    CadastrarFestival();
                    break;

                case 10:
                    ConsultarFestival();
                    break;

                case 11:
                    GerarConviteFestival();
                    break;

                case 12:
                    GerarCartaoResultado();
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

            bool nomeJaExiste = sistema.Equipes.Any(e =>
            e.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (nomeJaExiste)
            {
            Console.WriteLine("Já existe uma equipe com esse nome.\n");
            continue;
            }

            Equipe equipe = new Equipe(nome);

            sistema.AdicionarEquipe(equipe);

            Console.WriteLine($"\nEquipe '{nome}' cadastrada com sucesso!\n");

            while (true)
            {
                Console.Write("Deseja cadastrar outra equipe? (S/N): ");
                string resposta = (Console.ReadLine() ?? "").ToUpper();

                if (resposta == "S")
                {
                    break;
                }

                if (resposta == "N")
                {
                    Pausar();
                    return;
                }

                Console.WriteLine("Opção inválida. Digite S ou N.\n");
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

        Console.WriteLine("\n0 - Voltar");

        int numero;

        while (true)
        {
            Console.Write("\nDigite o número da equipe que deseja alterar: ");

            if (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.WriteLine("Número inválido. Digite novamente.");
                continue;
            }

            if (numero == 0)
            {
                return;
            }

            if (numero < 1 || numero > sistema.Equipes.Count)
            {
                Console.WriteLine("Equipe não encontrada. Digite novamente.");
                continue;
            }

            break;
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

        while (true)
        {
            ConsultarEquipesSemPausa();

            Console.WriteLine("\n0 - Voltar");

            int numero;

            while (true)
            {
                Console.Write("\nDigite o número da equipe que deseja excluir: ");

                if (!int.TryParse(Console.ReadLine(), out numero))
                {
                    Console.WriteLine("Número inválido. Digite novamente.");
                    continue;
                }

                if (numero == 0)
                {
                    return;
                }

                if (numero < 1 || numero > sistema.Equipes.Count)
                {
                    Console.WriteLine("Equipe não encontrada. Digite novamente.");
                    continue;
                }

                break;
            }

            Equipe equipe = sistema.Equipes[numero - 1];

            while (true)
            {
                Console.Write($"Tem certeza que deseja excluir '{equipe.Nome}'? (S/N): ");

                string resposta = (Console.ReadLine() ?? "").ToUpper();

                if (resposta == "S")
                {
                    sistema.RemoverEquipe(equipe);

                    Console.WriteLine("\nEquipe excluída com sucesso!");
                    Pausar();

                    Console.Clear();

                    Console.WriteLine("===== EXCLUIR EQUIPE =====\n");

                    break;
                }

                if (resposta == "N")
                {
                    Console.WriteLine("\nExclusão cancelada.");
                    Pausar();

                    Console.Clear();

                    Console.WriteLine("===== EXCLUIR EQUIPE =====\n");

                    break;
                }

                Console.WriteLine("Opção inválida. Digite S ou N.\n");
            }

            if (sistema.Equipes.Count == 0)
            {
                Console.WriteLine("\nNenhuma equipe cadastrada.");
                Pausar();
                return;
            }
        }
    }

    private void RegistrarPartida()
    {
        while (true)
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

            int numero1;

            while (true)
            {
                Console.Write("\nNúmero da primeira equipe: ");

                if (!int.TryParse(Console.ReadLine(), out numero1))
                {
                    Console.WriteLine("Número inválido. Digite novamente.");
                    continue;
                }

                if (numero1 == 0)
                {
                    return;
                }

                if (numero1 < 1 || numero1 > sistema.Equipes.Count)
                {
                    Console.WriteLine("Equipe não encontrada. Digite novamente.");
                    continue;
                }

                break;
            }

            int numero2;

            while (true)
            {
                Console.Write("Número da segunda equipe: ");

                if (!int.TryParse(Console.ReadLine(), out numero2))
                {
                    Console.WriteLine("Número inválido. Digite novamente.");
                    continue;
                }

                if (numero2 == 0)
                {
                    return;
                }

                if (numero2 < 1 || numero2 > sistema.Equipes.Count)
                {
                    Console.WriteLine("Equipe não encontrada. Digite novamente.");
                    continue;
                }

                if (numero1 == numero2)
                {
                    Console.WriteLine("Uma equipe não pode jogar contra ela mesma.");
                    continue;
                }

                break;
            }

            Equipe equipe1 = sistema.Equipes[numero1 - 1];
            Equipe equipe2 = sistema.Equipes[numero2 - 1];

            Console.Clear();

            Console.WriteLine("===== ESCOLHER MODALIDADE =====\n");

            Console.WriteLine("1 - Futsal");
            Console.WriteLine("2 - Voleibol");
            Console.WriteLine("3 - Basquete");
            Console.WriteLine("4 - Beisebol");
            Console.WriteLine("0 - Cancelar");

            string modalidade;

            while (true)
            {
                Console.Write("\nEscolha a modalidade: ");

                string opcaoModalidade = Console.ReadLine() ?? "";

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
                        return;

                    default:
                        Console.WriteLine("Modalidade inválida. Digite novamente.");
                        continue;
                }

                break;
            }

            int id = sistema.GerarIdPartida();

            Partida partida;

            if (modalidade == "Futsal")
            {
                partida = new PartidaFutsal(id, equipe1, equipe2);
            }
            else if (modalidade == "Voleibol")
            {
                partida = new PartidaVoleibol(id, equipe1, equipe2);
            }
            else if (modalidade == "Basquete")
            {
                partida = new PartidaBasquete(id, equipe1, equipe2);
            }
            else
            {
                partida = new PartidaBeisebol(id, equipe1, equipe2);
            }

            sistema.AdicionarPartida(partida);

            Console.WriteLine($"\nPartida de {modalidade} cadastrada com sucesso!");

            while (true)
            {
                Console.Write("\nDeseja registrar o resultado agora? (S/N): ");

                string resposta = (Console.ReadLine() ?? "").ToUpper();

                if (resposta == "S")
                {
                    RegistrarResultadoDaPartida(partida);
                    break;
                }

                if (resposta == "N")
                {
                    break;
                }

                Console.WriteLine("Opção inválida. Digite S ou N.");
            }

            Console.WriteLine("\nPressione Enter para cadastrar outra partida.");
            Console.WriteLine("Digite 0 para voltar ao menu.");

            string continuar = Console.ReadLine() ?? "";

            if (continuar == "0")
            {
                return;
            }
        }
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

        while (true)
        {
            Console.Clear();

            Console.WriteLine("===== ALTERAR RESULTADO =====\n");

            for (int i = 0; i < sistema.Partidas.Count; i++)
            {
                Partida partida = sistema.Partidas[i];

                string resultado;

                if (partida.ResultadoRegistrado)
                {
                    resultado = $"{partida.PlacarEquipe1} x {partida.PlacarEquipe2}";
                }
                else
                {
                    resultado = "(Resultado ainda não registrado)";
                }

                Console.WriteLine(
                    $"ID {partida.Id} - {partida.Equipe1.Nome} " +
                    $"{resultado} " +
                    $"{partida.Equipe2.Nome} " +
                    $"({partida.Modalidade})"
                );
            }

            Console.WriteLine("\n0 - Cancelar");

            Console.Write("\nDigite o ID da partida: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("\nID inválido. Digite novamente.");
                Pausar();
                continue;
            }

            if (id == 0)
            {
                return;
            }

            Partida? partidaSelecionada = null;

            for (int i = 0; i < sistema.Partidas.Count; i++)
            {
                if (sistema.Partidas[i].Id == id)
                {
                    partidaSelecionada = sistema.Partidas[i];
                    break;
                }
            }

            if (partidaSelecionada == null)
            {
                Console.WriteLine("\nPartida não encontrada. Digite novamente.");
                Pausar();
                continue;
            }

            RegistrarResultadoDaPartida(partidaSelecionada);

            Console.WriteLine("\nResultado alterado com sucesso!");
            Pausar();
        }
    }

    private void RegistrarResultadoDaPartida(Partida partida)
    {
        Console.WriteLine("\n===== RESULTADO =====");

        int placar1;

        while (true)
        {
            Console.Write($"Placar de {partida.Equipe1.Nome}: ");

            if (!int.TryParse(Console.ReadLine(), out placar1))
            {
                Console.WriteLine("Placar inválido. Digite novamente.");
            continue;
            }

            if (placar1 < 0)
            {
                Console.WriteLine("O placar não pode ser negativo. Digite novamente.");
                continue;
            }

            break;
        }

        int placar2;

        while (true)
        {
            Console.Write($"Placar de {partida.Equipe2.Nome}: ");

            if (!int.TryParse(Console.ReadLine(), out placar2))
            {
                Console.WriteLine("Placar inválido. Digite novamente.");
                continue;
            }

            if (placar2 < 0)
            {
                Console.WriteLine("O placar não pode ser negativo. Digite novamente.");
                continue;
            }

            break;
        }

        partida.AlterarResultado(placar1, placar2);

    }

    private void ExcluirPartida()
    {
        while (true)
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

                string resultado;

                if (partida.ResultadoRegistrado)
                {
                    resultado = $"{partida.PlacarEquipe1} x {partida.PlacarEquipe2}";
                }
                else
                {
                    resultado = "(Resultado ainda não registrado)";
                }

                Console.WriteLine(
                    $"ID {partida.Id} - {partida.Equipe1.Nome} " +
                    $"{resultado} " +
                    $"{partida.Equipe2.Nome} " +
                    $"({partida.Modalidade})"
                );
            }

            Console.WriteLine("\n0 - Voltar");

            int id;

            while (true)
            {
                Console.Write("\nDigite o ID da partida que deseja excluir: ");

                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("ID inválido. Digite novamente.");
                    continue;
                }

                if (id == 0)
                {
                    return;
                }

                break;
            }

            Partida? partidaSelecionada = null;

            for (int i = 0; i < sistema.Partidas.Count; i++)
            {
                if (sistema.Partidas[i].Id == id)
                {
                    partidaSelecionada = sistema.Partidas[i];
                    break;
                }
            }

            if (partidaSelecionada == null)
            {
                Console.WriteLine("Partida não encontrada. Digite novamente.");
                Pausar();
                continue;
            }

            Console.WriteLine(
                $"\nPartida: {partidaSelecionada.Equipe1.Nome} " +
                $"x {partidaSelecionada.Equipe2.Nome}"
            );

            while (true)
            {
                Console.Write("Tem certeza que deseja excluir? (S/N): ");

                string resposta = (Console.ReadLine() ?? "").ToUpper();

                if (resposta == "S")
                {
                    sistema.RemoverPartida(partidaSelecionada);

                    Console.WriteLine("\nPartida excluída com sucesso!");
                    Pausar();

                    break;
                }

                if (resposta == "N")
                {
                    Console.WriteLine("\nExclusão cancelada.");
                    Pausar();

                    break;
                }

                Console.WriteLine("Opção inválida. Digite S ou N.");
            }
        }
    }

    private void CadastrarFestival()
    {
        Console.Clear();

        Console.WriteLine("===== CADASTRAR FESTIVAL =====\n");

        Console.Write("Nome do festival: ");
        string nome = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("\nO nome não pode ficar vazio.");
            Pausar();
            return;
        }

        Console.Write("Local: ");
        string local = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(local))
        {
            Console.WriteLine("\nO local não pode ficar vazio.");
            Pausar();
            return;
        }

        string data;

        while (true)
        {
            Console.Write("Data (dd/MM/yyyy): ");
            data = Console.ReadLine() ?? "";

            if (DateTime.TryParseExact(
                data,
                "dd/MM/yyyy",
                null,
                System.Globalization.DateTimeStyles.None,
                out _))
            {
                break;
            }

            Console.WriteLine("Data inválida. Use o formato dd/MM/yyyy.\n");
        }

        string horario;

        while (true)
        {
            Console.Write("Horário (HH:mm): ");
            horario = Console.ReadLine() ?? "";

            if (DateTime.TryParseExact(
                horario,
                "HH:mm",
                null,
                System.Globalization.DateTimeStyles.None,
                out _))
            {
                break;
            }

            Console.WriteLine("Horário inválido. Use o formato HH:mm.\n");
        }

        Festival festival = new Festival(nome, local, data, horario);

        sistema.DefinirFestival(festival);

        Console.WriteLine("\nFestival cadastrado com sucesso!");

        Pausar();
    }

    private void ConsultarFestival()
    {
        Console.Clear();

        Console.WriteLine("===== FESTIVAL =====\n");

        if (sistema.Festival == null)
        {
            Console.WriteLine("Nenhum festival cadastrado.");
            Pausar();
            return;
        }

        sistema.Festival.ExibirFestival();

        Pausar();
    }

    private void GerarConviteFestival()
    {
        Console.Clear();

        Console.WriteLine("=================================");
        Console.WriteLine("          CONVITE");
        Console.WriteLine("=================================");

        if (sistema.Festival == null)
        {
            Console.WriteLine("Nenhum festival cadastrado.");
            Pausar();
            return;
        }

        Festival festival = sistema.Festival;

        Console.WriteLine();
        Console.WriteLine(festival.GerarTexto());
        Console.WriteLine();
        Console.WriteLine("Venha participar da Liga da Turma!");
        Console.WriteLine("=================================");

        Pausar();
    }

    private void GerarCartaoResultado()
    {
        Console.Clear();

        Console.WriteLine("=================================");
     Console.WriteLine("      CARTÃO DE RESULTADO");
        Console.WriteLine("=================================");

        if (sistema.Partidas.Count == 0)
        {
            Console.WriteLine("Nenhuma partida cadastrada.");
            Pausar();
            return;
        }

        Console.WriteLine("\nPartidas disponíveis:\n");

        foreach (Partida partida in sistema.Partidas)
        {
            Console.WriteLine(
                $"ID: {partida.Id} | " +
                $"{partida.Equipe1.Nome} x {partida.Equipe2.Nome} | " +
                $"{partida.Modalidade}"
            );
            
            Console.WriteLine(partida.ObterResultado());
        }

        Console.Write("\nDigite o ID da partida: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("\nID inválido.");
            Pausar();
            return;
        }

        Partida? partidaSelecionada = null;

        foreach (Partida partida in sistema.Partidas)
        {
            if (partida.Id == id)
            {
                partidaSelecionada = partida;
                break;
            }
        }

        if (partidaSelecionada == null)
        {
            Console.WriteLine("\nPartida não encontrada.");
            Pausar();
            return;
        }

        Console.Clear();

        Console.WriteLine("=================================");
        Console.WriteLine("      CARTÃO DE RESULTADO");
        Console.WriteLine("=================================");
        Console.WriteLine($"ID da partida: {partidaSelecionada.Id}");
        Console.WriteLine();
        Console.WriteLine(partidaSelecionada.GerarTexto());
        Console.WriteLine("=================================");

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