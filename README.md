# Liga da Turma

Aplicação de console desenvolvida em C#/.NET para gerenciamento de equipes, partidas, resultados e informações de um festival esportivo escolar.

## Funcionalidades

- Cadastro, consulta, alteração e exclusão de equipes
- Registro de partidas entre equipes cadastradas
- Seleção da modalidade da partida
- Registro e alteração de resultados
- Consulta do histórico de partidas
- Exclusão de partidas
- Cadastro e consulta dos dados do festival
- Geração de convite do festival
- Geração de cartões de resultado
- Identificação do vencedor ou empate
- Validação de entradas inválidas
- Suporte às modalidades Futsal, Voleibol, Basquete e Beisebol

## Tecnologias utilizadas

- C#
- .NET
- Aplicação de console
- Programação Orientada a Objetos (POO)

## Como executar

### Pré-requisito

É necessário ter o .NET SDK instalado no computador.

### Execução

1. Clone o repositório ou baixe os arquivos do projeto.

2. Abra o terminal na pasta do projeto.

3. Compile o projeto:

dotnet build

4. Execute a aplicação:

dotnet run

Após a execução, o menu principal será exibido no terminal.

## Conceitos de POO

### Encapsulamento

O encapsulamento é utilizado para proteger os dados das classes e controlar como eles podem ser alterados.

Na classe `Equipe`, por exemplo, a propriedade `Nome` possui `private set`, impedindo que seu valor seja alterado diretamente de fora da classe. A alteração é realizada por meio do método `AlterarNome()`.

### Abstração

A classe `Partida` é abstrata e representa as características e comportamentos comuns a todas as partidas.

Ela define informações como equipes, modalidade, placar e resultado, enquanto os comportamentos específicos são implementados pelas classes de cada modalidade.

### Herança

As classes `PartidaFutsal`, `PartidaVoleibol`, `PartidaBasquete` e `PartidaBeisebol` herdam características e comportamentos da classe `Partida`.

Dessa forma, as classes específicas podem reutilizar a estrutura comum definida na classe base.

### Polimorfismo

O polimorfismo permite que o sistema trabalhe com diferentes tipos de partida utilizando uma referência do tipo `Partida`.

As classes de cada modalidade possuem suas próprias implementações do método `ObterResultado()`, permitindo que o comportamento seja definido de acordo com o tipo da partida.

### Interface

A interface `IPublicidade` define o método `GerarTexto()`, estabelecendo um contrato para as classes que precisam gerar textos de divulgação.

Ela é utilizada na geração do convite do festival e dos cartões de resultado das partidas.

## Estrutura principal

- `Program.cs` — inicia a aplicação e cria o sistema e o menu.
- `Menu.cs` — controla as opções e a interação com o usuário.
- `Sistema.cs` — gerencia equipes, partidas e dados do festival.
- `Equipe.cs` — representa uma equipe cadastrada.
- `Partida.cs` — classe abstrata que define a estrutura comum das partidas.
- `PartidaFutsal.cs` — representa partidas de futsal.
- `PartidaVoleibol.cs` — representa partidas de voleibol.
- `PartidaBasquete.cs` — representa partidas de basquete.
- `PartidaBeisebol.cs` — representa partidas de beisebol.
- `Festival.cs` — representa os dados do festival e gera o convite.
- `IPublicidade.cs` — define o contrato para geração de textos de divulgação.

## Integrantes

- Caio Carniel Pouzada
- Arthur Werlang