# aspnet-fundamentals

Uma visão geral sobre o ASP.NET Razor Pages - Balta.io

`dotnet sdk check`
SDKs do .NET:
Versão       Status
------------------------
7.0.203      Atualizado.

Runtimes do .NET:
Nome                              Versão      Status
---------------------------------------------------------
Microsoft.AspNetCore.App          6.0.16      Atualizado.
Microsoft.NETCore.App             6.0.16      Atualizado.
Microsoft.WindowsDesktop.App      6.0.16      Atualizado.
Microsoft.AspNetCore.App          7.0.5       Atualizado.
Microsoft.NETCore.App             7.0.5       Atualizado.
Microsoft.WindowsDesktop.App      7.0.5       Atualizado.

`dotnet --version`
7.0.203

Criar nova aplicação
`dotnet new web -o MyRazorApp`

* Documentação dotnet sdk
https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet

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

Razor Pages é uma forma de estruturar uma aplicação web feita em ASP.NET, diferente do ASP.NET MVC que é uma forma arquitetural que já traz uma estruturação de pastas, separando Models, Views e Controllers.

O Razor Pages é um formato muito mais simples de criar aplicações web, que não exige tanto do entendimento de arquitetura para estruturar páginas e que também não necessita do entendimento das Models, Views e Controllers


### Observação sobre CSS

O ASP.NET independe de framework CSS. Por padrão, uma aplicação ASP.NET recomenda a utilização do Bootstrap, porém podemos utilizar qualquer outro framework ou até mesmo não utilizar um framework CSS, que isso não fará diferença para a construção da aplicação. 


## Continuação Razor Pages

Para trabalhar com Razor Pages dentro do ambiente ASP.NET, nós devemos adicioná-lo ao ambiente de desenvolvimento.
Através do construtor da aplicação `builder` iremos adicionar suporte a Razor Pages em nossa aplicação
```csharp
`builder.Services.AddRazorPages();`
```
essa semântica funciona para qualquer aplicação .NET, por exemplo:
```csharp
AddServerSideBlazor()
AddControllers()
```

MapGet é apenas um endpoint base trazido na criação da aplicação para que ela não fique vazia, que pode ser removido e recriado ou reutilizado
```csharp
app.MapGet("/", () => "Hello World!");
```
tendo em vista que `"/"` representa a página inicial da aplicação 

Utilizaremos algumas configurações para que a aplicação fique acessível pelo browser

```csharp
app.UseHttpsRedirection()
```
Por mais que nossa aplicação, nesse momento, esteja rodando localmente, ela irá funcionar via HTTPS e não HTTP. 

```csharp
app.UseStaticFiles()
```
Arquivos estáticos (statics), em ASP.NET, são servidos sempre dentro de uma pasta chamada de `wwwroot`, é possível especificar um outro nome de pasta, mas `wwwroot` é padrão Web. 
Arquivos estáticos são CSS, JavaScripts, imagens e até mesmo arquivos JSON. Então, se desejamos acessar esse tipo de arquivo dentro de nossa aplicação, precisaremos inserí-los em subpastas dentro da pasta `wwwroot`.


```csharp
app.UseRouting();
app.MapRazorPages();
```
Essas duas linhas de código servem para auxiliar no mapeamento das páginas.
Teremos suporte para criar URLs customizadas para nossas páginas e para criar e nomear uma simples página que será encontrada automaticamente pela aplicação.

A partir deste momento a aplicação já está pronta para rodar, já que o ASP.NET traz muita coisa de fábrica, facilitando na criação inicial da aplicação.

Todas as páginas Razor, por padrão, deverão ficar dentro de um diretório `Pages`.

### Arquivos Razor Pages

Um Razor Pages é dividido em dois arquivos, um arquivo `.cshtml`e um arquivo `.cshtml.cs`

Apesar de parecer um pouco confuso e dos arquivos no explorer da IDE estarem aninhados, eles não são arquivos aninhados, é apenas um agrupamento para facilitar a visualização. 

A questão de termos dois arquivos facilita na separação de funções.

O arquivo `cshtml`, como comentado anteriormente é uma junção de um arquivo C# com um arquivo HTML, onde temos uma sintaxe de programação do ambiente ASP.NET.
O `cshtml.cs` é uma class C#, complementar ao arquivo `cshtml`, essa classe herda de PageModel que serve como modelo para essa página que nós vamos exibir. 
Essa classe suporta os dois métodos a baixo:
```csharp
OnGet()
OnPost()
```
O `OnGet()` será executado sempre que nossa página for renderizada, sempre que fizermos um Get para nossa página e sempre que fizermos um Post para nossa página, o método OnPost() será ativado.

Existem muitas funcionalidades C# presentes dentro de Razor, porém não são todas. Devemos sempre utilizar as chaves ao abrir e fechar um loop, ou uma declaração condicional. Porém, podemos mesclar quase livremente o código C# com o código HTML

```csharp
    <div>
        @for(int i = 0; i < 10; i++)
        {
            <p> Item <text> @i </text> Hello </p>
        }
    </div>
```

Uma página Razor sempre irá começar, obrigatoriamente, com um `@page`, isso porque, além de páginas, nós podemos criar componentes com Razor e componentes não possuem a diretiva `@page`.

Os arquivos `.cshtml` e `.cshtml.cs` são unidos dentro do arquivo `.cshtml` através do `@model`

```csharp
@model MyRazorApp.Pages.indexModel
```
Nosso model é MyRazorApp, que está utilizando o namespace Pages e o modelo index, que está dentro desta pasta.

### O que aconteceu até aqui

Nossa aplicação .NET está rodando no localhost, em uma porta específica, nós fazemos uma requisição para a nossa aplicação que está rodando, que irá bater na parte de rotas do ASP.NET e irá fazer a seguinte pergunta: Qual é a página inicial que eu chamo?
O Razor irá procurar dentro da pasta Pages se existe algum arquivo nomeado como `index`, caso haja, o Razor irá acessar acessar o item Get() do Model (classe C#, arquivo `.cshtml.cs`) e irá dar sequência, indo ao arquivo `.cshtml` que é a Página.
Chegando na página, o modelo `@model` será definido, o conteúdo HTML e qualquer conteúdo C# dentro do arquivo será gerado no servidor e renderizado na tela do usuário.

### SEO - Searc Engine Optimization

O Razor Pages é extremamente útil para o motor de pesquisa do google, pois o html gerado é extremamente bem indexado e isso reflete em bons resultados de busca.

### Server-side

Razor Pages funciona do lado do servidor, o que traz uma performance muito maior para a aplicação e implica que o conteúdo HTML é retornado pelo servidor. Então as regras de negócio, interações com banco de dados e outras possíveis questões sensíveis do site são ocultadas do conteúdo que está sendo gerado para o usuário final, este irá receber apenas o HTML final que foi requisitado ao acessar uma aplicação feita com Razor Pages. 
Isso implica em uma segurança muito maior, obrigando qualquer tipo de invasor a invadir o servidor onde a aplicação está hospedada para poder capturar dados sensíveis à aplicação. 

Por ser uma aplicação server-side, as interações com o usuário são muito mais complexas de serem realizadas, requerindo, em muitos dos casos, a utilização de JavaScript para poder realizar alterações de estado.

## Page Model

O Page Model, herdado pela nossa classe C# (Model) permite que manipulemos listas, acessemos o banco de dados e executemos inúmeras outras funcionalidades de C# dentro da Model criada para a Página, pois estamos rodando no lado do servidor.

Em algumas aplicações podemos ter uma replicação de código através de bibliotecas. Por exemplo uma aplicação que possui uma API que usa um trecho de código e um site que usa o mesmo trecho de código. Ou seja, uma aplicação ASP.NET, com Razor e uma Web API utilizando o mesmo trecho de código através de uma Class Library.

Essa reutilização de códigos através de referenciamento de bibliotecas é uma das grandes vantagens providas pelo ecossistema .NET, seja essa biblioteda do pacote NuGet ou de qualquer outro local. 

### Settings

O modelo de projeto Razor Pages possui o arquivo `appsettings.json` que é o arquivo que contém as configurações da aplicação ASP.NET

Através deste arquivo, podemos nos conectar ao banco de dados criando Connection Strings diretamente no arquivo de configurações e implementar outras configurações na nossa aplicação.

### C#

Podemos criar uma classe muito mais enxuta, em C#, utilizando `record`

```csharp
public record Category(int Id, string Title, decimal Price);
```

Dessa forma, omitimos algumas questões que são tidas como complicadas na hora de criar uma classe.

No exemplo a seguir, iremos simular que estamos indo ao banco de dados buscar algumas categorias através da classe `Category`. 

Deveremos criar uma propriedade List<Category>. Como já sabemos o tipo da List que estamos criando, no caso <Category>, podemos inicializar essa List de forma anônima 
```csharp
public List<Category> Categories { get; set; } = new();
```
Devemos sempre inicializar as listas, pois, se não inicializarmos e tentarmos adicionar um item nessa lista, que é um tipo de referência, ela sempre virá como nula e isso ocasionará uma Null Reference Exception.

Atualizamos nossa classe Index para que fique da seguinte forma:
```csharp
public List<Category> Categories { get; set; } = new(); 

public async Task OnGet()
{
    await Task.Delay(1000);
    for (int i = 0; i <= 100; i++)
    {
        Categories.Add(new Category(i, $"Categoria {i}", i * 18.95m));
    }
}
```
Como já possuímos a ligação do arquivo Razor com a nossa página através do `@model`, nós podemos utilizar uma variável especial chamada `Model` dentro do nosso código html utilizando o @, ou seja `@Model`. E toda vez que estamos chamando essa variável especial `@Model` ela estará se referindo ao `@model` que representa o `@model MyRazorApp.Pages.indexModel`, que nada mais é do que a importação do nosso modelo para dentro do Razor.

Assim, teremos acesso a diversas informações da página, inclusive Request e Response. Por exemplo, com Request nós podemos inspecionar o cabeçalho, podemos ver a URL e até tentar ver o endereço de IP da pessoa que está acessando a aplicação.

Utilizaremos um foreach para iterar sobre cada categoria que está dentro da lista `Categories`
```csharp
    <table>
        <thead>
        <tr>
            <td>ID</td>
            <td>Title</td>
            <td>Price</td>
        </tr>
        </thead>
        <tbody>
        @foreach (var category in Model.Categories)
        {
            <tr>
                <td>@category.Id</td>
                <td>@category.Title</td>
                <td>@category.Price</td>
            </tr>
        }      
        </tbody>
    </table>
```

A tarefa `async` do método Get está sendo utilizada para garantir que o servidor terá tempo suficiente para processar e retornar as informações.

Como estamos trabalhando em ambiente localhost, as coisas acontecem de forma muito mais rápida e talvez nós nem consigamos notar esse processamento, por isso é importante se atentar às necessidades de utilizar assincronismo durante as operações.

Como estamos passando variáveis geradas em um código C# para nossa tabela, podemos converter os valores da coluna "Price" para String e formatá-los com o tipo `"C"` (currency) para o tipo moeda, que irá pegar a Culture Info do computador que está acessando.

```csharp
<td>@category.Price.ToString("C")</td>
```
No caso, a Culture Info tem relação com o idioma padrão que está sendo utilizado no computador e não com a região de onde a pessoa está acessando, então, se quisermos pressetar esse Culture Info para algo mais específico, devemos passar um segundo parâmetro para a formatação, por exemplo:
```csharp
<td>@category.Price.ToString("C", new CultureInfo("pt-BR")</td>
```
dessa forma, a culture info será setada para português-brasileiro


## Página Razor

Um `@page` é uma página Razor que será usada para criar outras páginas, pois ela é o modelo usado de base.

Se criarmos, por exemplo, duas novas páginas baseadas em arqivos Razor Pages, `Sobre`e `Login`, ambas as páginas serão automaticamente reconhecidas, pois no arquivo `Program.cs` estamos utilizando `UseRouting()` e `MapRazorPages()` que faz toda a rota e reconhecimento dos arquivos que no nosso projeto estão dentro da pasta padrão nomeada Pages.

Então, se digitarmos o endereço completo do site e o endpoint desejado, nós chegaremos à página que desejamos.

O browser não entende arquivos `.cshtml`, então, no final, todo arquivo html é gerado dentro da pasta `wwwroot` do projeto para que esse arquivo possa ser servido ao browser.

PS: Os arquivos físicos não irão existir dentro da pasta `wwwroot` pois eles são servidos sob demanda, mas se inspecionarmos, encontraremos os arquivos temporários.

* Quando estamos usando uma tag `<a>` dentro de .NET e queremos nos referir à raiz da aplicação, devemos utilizar o `~/` no elemento `href`. `<a href="~/">` e qualquer nome posterior a barra, será o nome da página que desejamos acessar. `<a href="~/About">`

* Lembrando que, por ser uma aplicação Server-Side, toda nova requisição irá recarregar a página, diferente de uma aplicação Angular ou React, que trabalha com estados do lado Client-Side


## Partial Views 

Nós devemos aplicar nosso menu a todas as páginas existentes, porém, como fazemos isso sem copiar e colar o mesmo código em cada página?

View Partials é um recurso do ASP.NET que permite que criemos uma Partial só para o pedaço de código HTML desejado.

É convenção que se utilize uma pasta chamada `Shared` dentro do diretório `Pages`. Embora não seja obrigatório, manter esse padrão facilitará a interação com o projeto ASP.NET

Criaremos um novo arquivo de formato `.cshtml`, não precisamos criar uma Razor Pages, apenas um novo arquivo. É comum utilizar o sufixo `Partial` para identificar que este novo arquivo é uma partial dentro do projeto.

Um arquivo que será uma Partial View não deve conter `@page` pois ele não é uma página e não queremos que haja uma rota para acessar esse arquivo como uma página.

Pegaremos o código HTML que desejarmos e recortaremos ele do nosso index e colaremos no novo arquivo criado, que será a nossa Partial View, no caso, nomeada como `NavMenuPartial`

Para chamarmos essa Partial dentro do nosso código, nós utilizamos o código `@Html.RenderPartialAsync(string)` passando o nome do arquivo como parâmetro, porém, essa não é a forma adequada de utilizar Partials, devemos, então, utilizar os Tag Helpers.

### Tag Helpers

Tag Helper é a forma de utilizar o ASP.NET num formato amigável para o HTML.

Quando adicionamos suporte dos Tag Helpers, além de contar com as tags do HTML, contaremos também com tags do ASP.NET
```csharp
<asp- >
```
No final das contas, os Tag Helpers são uma maneira otimizada e limpa de escrever códigos para renderizar o conteúdo através das Partial Views. 

Para usar Tag Helpers nós devemos adicionar uma nova linha em cada página que irá necessitar as tags ASP.NET ou Partial Views.
Esse pacote é contido dentro de `Microsoft.AspNetCore.Mvc.TagHelpers` e nós importaremos todos os `TagHelpers` contidos nesse pacote.
```csharp
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```
e dentro do nosso código HTML, usaremos a tag `<partial />` e utilizar o seu atributo `name=""` referenciando o caminho e o nome do arquivo onde a nossa Partial View está contida.
```csharp
<partial name="Shared/NavMenuPartial"/>
```
Nós podemos criar nossas Tag Helpers para interagir com funcionalidades do C#, porém, esse assunto não será abordado nesse material. 


## View Imports