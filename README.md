# aspnet-fundamentals

Uma visão geral sobre o ASP.NET Razor Pages - Balta.io

`dotnet --version`
7.0.203

`dotnet new web -o MyRazorApp`


Toda aplicação de padrão .NET conterá um Program.cs, que é o ponto de partida da aplicação

No caso do ASP.NET, teremos um `builder`, que é o construtor, onde inicializaremos uma aplicação

Em seguida teremos uma instância do builder, que será responsável por criar a instância do servidor

E para executar nossa aplicação um `app.Run()`, que estará executando no servidor, ouvindo determinada porta, o que nos possibilitará fazer requisições HTTP para esse servidor, que nos devolverá determinada informação, que pode ser um HTML, CSS, JavaScript, JSON e outros tipos de arquivos.

Como criamos o projeto através do SDK .NET pelo comando `dotnet new web`, o arquivo `.csproj` usará o `Microsoft.NET.Sdk.Web`, o que já trará automaticamente toda a SDK Web do .NET, então temos todos os recursos do ASP.NET e do Blazor em nossa aplicação. 

A aplicação já vem construída por padrão, então já conseguimos debugar e visualizar uma string printada no nosso navegador, sem uso de Razor, sem renderização, apenas um print. 


## Razor

Razor é um Motor de Visualização (View Engine)

Sempre que quisermos servir qualquer conteúdo HTML no .NET, devemos utilizar um motor de visualização, que é responsável por manipular qualquer informação, gerar o HTML, CSS ou JS e entregar o output desse item para a tela. 

Razor, então, é o item que possibilita a interpolação entre C# e HTML, por exemplo. Através do Razor nós conseguimos criar arquivos que possuem HTML e C# integrados, ou seja podemos trabalhar com programação dentro de HTML.

O Razor possui dois tipos de extensões para o mesmo tipo de código: `.cshtml` e `.razor`

Utilizando ASP.NET MVC (Model View Controller), as views também utilizam Razor como View Engine, por ser um padrão .NET

## Razor Pages

Razor Pages é uma forma de estruturar uma aplicação web, diferente do MVC que é uma forma arquitetural.

O Razor Pages é um formato muito mais simples de criar aplicações web, que não exige tanto do entendimento de arquitetura para estruturar páginas e que também não necessita do entendimento das Models, Views e Controllers