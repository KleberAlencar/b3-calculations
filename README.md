# Calculation-App
Desafio do cálculo do CDB

![]front-end/src/Calculation-App/src/assets/Screenshot_UI.png

# Considerações
A aplicação foi desenvolvida em inglês, tentando representar cada item de forma direta e pode ser necessário alguma alteração.

Para organizar o código, a aplicação foi dividida em duas partes, back-end e front-end.

Este código foi escrito para atender as demandas do desafio e poderá ser realizado refactoring caso surja necessidade. 

# back-end
Api desenvolvido em .Net 7 utilizando de forma simplificada padrão CQRS, design pattern Mediator, conceitos Clean Architecture, Data Annotations, Sqlite database, EF Core, etc.

A execução do back-end deverá ser realizada da seguinte forma:

- Abrir o código no Visual Studio Code
- Em Terminal -> Novo Terminal 
- Digitar cd back-end/src
- Executar comando < dotnet restore >
- Digitar cd Calculation.Api
- Executar o comando < dotnet build >
- Executar o comando < dotnet watch run > (passo anterior pode ser substituído por este)
- Aplicação deverá abrir via swagger no link `http://localhost:5000/swagger/index.html`

Com intuito de padronizar as chamadas, os métodos que começam com Get (ex.: GetCdbCalculation) retornam uma única entidade, já os que começam com Search (ex.: SearchTaxDiscounts) retornam uma lista de entidades.

Os testes deverão ser realizados dentro da pasta back-end/src/Calculation.Tests.
- Executar testes utilizando o comando < dotnet test >

# front-end
Com o back-end em execução o front-end poderá ser inicializado da seguinte forma:

- Abrir o código no Visual Studio Code
- Em Terminal -> Novo Terminal 
- Digitar cd front-end/src
- Executar comando < npm start >
- Caso aplicação não inicie, navegar até o link `http://localhost:4200/`

Os testes deverão ser realizados dentro da pasta front-end/src/Calculation-App.
- Executar testes utilizando o comando < npm test >
- Para validar cobertura utilizar comando < ng test --code-coverage >

Atenção: Apenas para agilidade, foram realizados testes somente na pasta "services", outras pastas podem ser testadas no futuro.