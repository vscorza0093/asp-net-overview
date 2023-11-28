# aspnet-fundamentals

Uma visão geral sobre o ASP.NET Razor Pages - Balta.io

O conteúdo deste README foi escrito com as minhas palavras, para me ajudar a absover os conceitos apresentados no curso `Uma visão geral sobre o ASP.NET Razor Pages` no site balta.io do André Baltieri.

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

Sempre que quisermos servir qualquer conteúdo HTML no .NET, devemos utilizar um motor de visualização, que é responsável por manipular qualquer informação, gerar o HTML, CSS ou JS e entregar o output desse item para o navegador. 

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

Um Razor Page é dividido em dois arquivos, um arquivo `.cshtml`e um arquivo `.cshtml.cs`

Apesar de parecer um pouco confuso e apesar dos arquivos no explorer da IDE estarem aninhados, eles não são arquivos aninhados, é apenas um agrupamento para facilitar a visualização. 

A questão de termos dois arquivos facilita na separação de funções.

O arquivo `cshtml`, como comentado anteriormente, é uma junção de um arquivo C# com um arquivo HTML, onde temos uma sintaxe de programação do ambiente ASP.NET.
O `cshtml.cs` é uma class C#, complementar ao arquivo `cshtml`, essa classe herda de PageModel que serve como modelo para essa página que nós vamos exibir. 
Essa classe suporta os dois métodos a baixo:
```csharp
OnGet()
OnPost()
```
O método `OnGet()` será executado sempre que nossa página for renderizada, ou seja sempre que fizermos um Get para nossa página e sempre que fizermos um Post para nossa página, o método `OnPost()` será ativado.

Existem muitas funcionalidades C# presentes dentro de Razor, porém não são todas. Devemos sempre utilizar as chaves ao abrir e fechar um loop, ou uma declaração condicional. Porém, podemos mesclar quase livremente o código C# com o código HTML

```html
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
e dentro do nosso código HTML, usaremos a tag `<partial />` e utilizaremos o seu atributo `name=""` referenciando o caminho e o nome do arquivo onde a nossa Partial View está contida.
```csharp
<partial name="Shared/NavMenuPartial"/>
```
Nós podemos criar nossas Tag Helpers para interagir com funcionalidades do C#, porém, esse assunto não será abordado nesse material. 


## View Imports

View Import é um recurso para facilitar a reutilização de códigos, nos ajudando a diminuir a quantidade de código que deve ser reescrito a cada vez que precisemos utilizar um recurso de uma Partial, por exemplo, em uma nova página que acaba de ser criada.

Dentro da pasta `Pages` criamos um arquivo chamado `_ViewImports.cshtml` e vamos adicionar os imports necessários no momento

```csharp
@using MyRazorApp
@using MyRazorApp.Pages

@using System.Globalization
```

Agora podemos remover o `MyRazorApp` e `System Globalization` de todos os outros arquivos, e reduzir o nome de todas as `Pages`, excluindo o `MyRazorApp.Pages` da importação, por exemplo:

```csharp
@using MyRazorApp.Pages.IndexModel
```
irá se tornar
```csharp
@using IndexModel
```

Com isso conseguimos limpar bastante a quantidade de código da nossa aplicação.


## Layouts

Ao invés de ficar replicando o código a baixo em todas as outras páginas, podemos utilizar um outro recurso do ASP.NET, conhecido como Layouts.
```html
<!DOCTYPE html>
<html>
<head>
    <title>My Razor Page</title>
</head>
<body>
    <header>
        <partial name="Shared/NavMenuPartial"/>
    </header>
    <main>
    </main>
</body>
</html>
```

Dentro da pasta `Shared` criamos um arquivo `_Layouts.cshtml`.

Essa página Layout servirá de base para outras páginas

Essa página Layout não conterá um `@page`, não é uma página que precisa ser encontrada, então não é necessário fazer uma rota para esta página desta forma.

Em contra partida, na página que irá utilizar o Layout, devemos declará-lo

```csharp
@{
    Layout = "Shared/_Layout";
}
```

Agora devemos explicar para o ASP.NET onde desejamos renderizar nossa página de Layout, adicionando o método `RenderBody()` dentro tag `main` do nosso arquivo `_Layout.cshtml`, para renderizar o Body da página que está chamando nosso Layout

```html
<!DOCTYPE html>
<html>
<head>
    <title>My Razor Page</title>
</head>
<body>
    <header>
        <partial name="Shared/NavMenuPartial"/>
    </header>
    <main>
        @RenderBody()
    </main>
</body>
</html>
```

Isso nos permite criar diversos Layouts e aplicar cada um para uma página específica, nos ajudando a reduzir drasticamente o código escrito, sendo possível excluir, no caso desse projeto, as tags <!DOCTYPE> <html> <head> <body> de todos os outros arquivos de página. 


## View Start

Podemos aplicar um Layout específico a todas as páginas que criarmos.

Na nossa pasta `Shared` devemos criar um arquivo chamado `_ViewStart.cshtml`.

No arquivo criado iremos inserir uma linha de código identificando que este arquivo está apontando para o nosso arquivo de Layout padrão

```html
@{
    Layout = "Shared/_Layout";
}
```

Agora, em todas as páginas que desejamos utilizar nosso Layout, podemos simplesmente não "importar" nenhum Layout e nas páginas que não desejamos utilizar o Layout padrão devemos sobrescrevê-lo, passando o valor `null` ou apontar para um Layout secundário.
```html
@{
    Layout = null;
}
```

## Rotas e Hiperlinks

Sempre que for necessário gerar um href dentro do nosso código devemos nos lembrar dos TagHelpers, que são as Tags de auxilio do ASP.NET para gerarmos nosso código, que estão trabalhando em conjunto com UseRouting e outros recursos para criar as rotas e chegar até nossa página.

Podemos usar o ASP.NET para gerar esses links e sempre que atualizarmos a URL de uma página, essa atualização será feita automaticamente para toda a rota.

Esse recurso ajuda a evitar a criação de URLs de maneira completamente manual, então se uma alteração for necessária, não precisa ser feita em todos os códigos que contém uma rota para determinada página que sofreu alteração em seu nome, evitando um erro 404.

Ao invés de usarmos href para a geração de links, utilizaremos a tag <a> ecom conjunto com `asp-page`: <a asp-page=""> passando o nome desejado no parâmetro de asp-page


## View Data

Nós podemos passar informações para diversas páginas através de um item chamado `ViewData`, que é um dicionário, onde definiremos o nome e o valor do objeto dentro de qualquer Tag HTML.

Utilizaremos a `ViewData` dentro do nosso arquivo de Layout e definiremos o título e um H1 em nosso Layout e aplicaremos para cada página separadamente.

```html
<head>
    <title>@ViewData["Title"] - My Razor App</title>
</head>
<body>
    <h1>@ViewData["Title"]</h1>
</body>
```

Em seguida inserimos a definição dentro de cada arquivo desejado

```html
@page
@model Index
@{
    ViewData["Title"] = "Home Page";
    ViewData["H1"] = "Welcome to my Web Page"
}
```


## Parâmetros e Rotas

Podemos passar parâmetros para URLs de algumas maneiras.

No exemplo a baixo estamos definindo a URL da página com seu caminho inicial, seu nome e o parâmetro obrigatório.

```csharp
public class HomePage : PageModel
{
    public void OnGet(int row)
    {

    }
}
```
```html
@page "~/home/{row}"
```

Se tentarmos acessar a página sem especificar um parâmetro `localhost:8000/home`, obteremos um erro 404 e ao passarmos o parâmetro obrigatório, acessaremos a página normalmente `localhost:8000/home/1`, nunca esquecendo que, obviamente, o parâmetro passado deve corresponder ao parâmetro requisitado para que não ocorra um erro 404.

A partir disso nós podemos manipular este parâmetro dentro do nosso código.

Se quisermos definir um valor padrão e evitar que nossa aplicação quebre em casos que o valor não tenha sido passado nós podemos simplesmente inserir esse valor no parâmetro recebido pelo método OnGet() da nossa classe que herda de PageModel.

```csharp
public class HomePage : PageModel
{
    public void OnGet(int row=0, int column=0)
    {
    }
}
```

Também podemos definir nosso parâmetro no arquivo HTML como Nullable.

```html
@page "~/home/{row?}/{column?}"
```

Podemos definir nosso parâmetro como Nullable no HTML sem definir um valor padrão para ele no nosso método OnGet(), porém, dessa forma estamos tratando erros diferentes.

Podemos finalmente chamar nossa URL sem passar parâmetros ou então passando parâmetros e com a opção também da seguinte chamada: `localhost:8000/home?row=10&column=3`.

Essa composição é conhecida como QueryString, começando com `?` e separando os parâmetros por `&`

Podemos especificar a forma de chamada que terá prioridade para recuperar nossos parâmetros, através do uso de alguns atributos como: `[FromQuery]`, `[FromForm]`, `[FromRoute]`

```csharp
public class HomePage : PageModel
{
    public void OnGet([FromQuery]int row=0, [FromQuery]int column=0)
    {
    }
}
```

## Por que não utilizar Session atualmente?

Session é uma informação que fica na memória e dura por um tempo X e faz parte de  um modelo antigo do ASP.NET. A partir de determinada versão, começou-se a trabalhar muito com aplicações sem estado (stateless), devido a utilização da arquitetura de MVC.

Por exemplo, um site está hospedado na núvem e faz uma promoção em um dia específico do ano e é preciso aumentar a quantidade de máquinas que está rodando o site. Então o site não está sendo rodado por apenas uma máquina. 

Então quando fazemos uma requisição para a máquina 1 nós geramos uma informação na sessão, porém essa sessão não é compartilhada entre todas as máquinas. Na próxima vez que acessarmos o site, podemos acabar caindo na máquina 2 porque a máquina 1 estava cheia, porém na máquina 2 não existe a sessão com a qual você estava trabalhando. 

Para isso temos o ViewData, TempData, ViewBag e outras formas de segurar nossas iformações durante uma requisição, fora isso, nossa única opção de autenticação atualmente seria pelo uso de Cookies.


## Append Version

Digamos que a página de uma loja possui um design padrão que está definido em um arquivo css, porém essa mesma loja possui outros designs prontos para datadas comemorativas diferentes.

O problema é que no primeiro acesso do usuário à nossa aplicação ele irá carregar nosso arquivo estático de formato `.css`, e como todo arquivo estático ele será armazenado no cache e nas próximas vezes que este usuário recarregar a página ele já irá identificar esse arquivo no cache local e não irá fazer uma nova requisição deste arquivo para o servidor e irá ignorar qualquer atualização feita no arquivo, mantendo sempre o design que foi cacheado.

Lembrando que a utilização do cache é importante para a boa performance das aplicações e queremos apenas que esse arquivo estático seja atualizado quando subirmos uma nova versão do projeto.

Para isso utilizamos um recurso do ASP.NET que está incluso nos `Tag Helpers` que é o `asp-append-version`, onde podemos definir seu valor como `true` para que toda vez que fizermos um novo deploy do projeto seja gerado um hash para identificar nosso arquivo css, o que tornará seu nome dinâmico, fazendo com que o nome de um arquivo em cache no computador do usuário seja diferente do nome da nova versão em deploy.

```html
<link rel="StyleSheet" href="~/css/site.css" asp-append-version="true"/>
```

Podemos verificar os nomes gerados através das ferramentas de desenvolvimento do navegador.


## Nested CSS

Um recurso interessante do Razor é a possibilidade de criar arquivos css individuais para páginas Razor específicas.

Esse recurso nos ajuda a evitar que toda página carregue informações css desnecessárias para si, podendo individualizar as necessidades de cada página e mantendo um arquivo padrão mais centralizado.

Criamos este arquivo na pasta Pages, utilizamos o mesmo nome da página a qual queremos aplicar, utilizamos a extensão secundária `cshtml` e a extensão principal `css`, exemplo: `Home.cshtml.css`

Nosso css estará aninhado com nosso arquivo cshtml, junto com nosso arquivo css.

Toda vez que utilizamos esse método, nossa aplicação irá gerar um arquivo de css temporário, que tem um nome específico que é composto pelo `~`, o nome da aplicação seguido da extensão secundária `styles` seguido da extensão principal `css`, exemplo: "~/MyRazorApp.styles.css". 

Esse arquivo não será reconhecido pela IDE, pois de fato não existe, esse arquivo será gerado sob demanda pela nossa aplicação, e podemos e inspecionar o arquivo gerado através das ferramentas de desenvolvimento do navegador.


## Render Section

Agora queremos inserir um arquivo javascript no nosso código que irá simplesmente exibir um alerta com uma mensagem.

Aplicamos ele ao Layout e ele está funcionando para todas as páginas. Mas digamos que queremos que ele funcione em apenas uma página específica, por exemplo Categorias.

Por convenção, tags para chamar um arquivo css ficam no head do código e arquivos tags para chamar um arquivo java script ficam no final do código, podendo ser até mesmo depois do footer.

Se chamarmos o script JS apenas na página Categorias teremos um problema de ordem de renderização, já que o script JS será sempre renderizado dentro do main do html onde está contido. Queremos que ele seja renderizado apenas após o footer, mas podemos querer que ele seja renderizado em qualquer outro setor do código.

Essa técnica serve para outros componentes além de scripts.

Deveremos usar, em nosso Layout principal a tag `@RenderSection()`, que criará uma seção, pense como uma div, e irá renderizar os itens. Passaremos uma string para o parâmetro `name` e podemos também passar o parâmetro `required` que por padrão vem como falso, exemplo: `@RenderSection(name:"scripts", required:false)` o required serve para dizer se todas as páginas devem implementar este item.

Agora implementamos o script individualmente em cada página necessária, através da tag `@section` passando o nome criado no `@RenderSection()` e a tag completa com caminho para o arquivo JS.

```html
@section scripts
{
    <script src="~/js/site.js"></script>
}
```

Lembrando que isso pode ser usado para qualquer item que desejamos controlar a ordem de renderização, não precisa ser necessariamente um arquivo JS.
