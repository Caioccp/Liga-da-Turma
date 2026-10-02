# Liga da Turma

Aplicação de console desenvolvida em C#/.NET para organização de campeonatos e partidas do festival da escola.

## Funcionalidades

- Cadastro, consulta, alteração e exclusão de equipes
- Registro, consulta, alteração e exclusão de partidas
- Cadastro e consulta do festival
- Geração de convite do festival
- Geração de cartões de resultado

## Como executar

Abra o terminal na pasta do projeto e execute:

dotnet build

dotnet run

## Conceitos de POO

### Encapsulamento

Utilizado para proteger os dados das classes. Na classe Equipe, por exemplo, a propriedade Nome possui private set e sua alteração é feita pelo método AlterarNome().

### Abstração

A classe Partida é abstrata e define comportamentos que são implementados pelas classes específicas de cada modalidade.

### Herança

As classes PartidaFutsal, PartidaVoleibol, PartidaBasquete e PartidaBeisebol herdam características da classe Partida.

### Polimorfismo

O sistema utiliza uma variável do tipo Partida para trabalhar com objetos das classes derivadas. O método ObterResultado() possui implementações nas diferentes classes de partida.

### Interface

A interface IPublicidade define o método GerarTexto(), utilizado para gerar textos de divulgação, como o convite do festival e os cartões de resultado.

## Integrantes

- Caio Carniel Pouzada
- Arthur werlang