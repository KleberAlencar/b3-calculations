A aplicação foi desenvolvida em inglês, tentando representar cada item de forma direta e pode ser necessário alguma alteração.

Para organizar o código, a aplicação foi dividida em duas partes, back-end e front-end.

Este código foi escrito para atender as demandas do desafio e poderá ser realizado refactoring caso surja necessidade. 

1. back-end
Api desenvolvido em .Net 7 utilizando de forma simplificada padrão CQRS, design pattern Mediator, Data Annotations, Sqlite database, EF Core, etc.

A execução do back-end deverá ser realizada da seguinte forma:

- Abrir o código no Visual Studio Code
- Em Terminal -> Novo Terminal 
- Digitar cd back-end/src
- Executar comando < dotnet restore >
- Digitar cd Calculation.Api
- Executar o comando < dotnet build >
- Executar o comando < dotnet watch run > (passo anterior pode ser substituído por este)
- Aplicação deverá abrir via swagger no link http://localhost:5000/swagger/index.html

2. front-end

Com o back-end em execução o front-end poderá ser inicializado da seguinte forma:

- Abrir o código no Visual Studio Code
- Em Terminal -> Novo Terminal 
- Digitar cd front-end/src
- Executar comando < dotnet restore >

# CalculationApp

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 12.2.18.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.