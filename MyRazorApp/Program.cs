var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection(); // Para fazer a aplicação rodar via HTTPS

app.UseStaticFiles(); // Arquivos estáticos como .CSS, .JS, .JSON e imagens são servidos por padrão dentro da pasta wwwroot. Devemos criar esta pasta e utilizar o método UseStaticFiles() para que esses arquivos sejam reconhecidos pela aplicação.

// As próximas duas linhas de código auxiliam no mapeamento de páginas, dando suporte para criar URLs customizadas e também criar uma página que será encontrada automaticamente pela aplicação, a partir da pasta Pages
app.UseRouting(); // 
app.MapRazorPages(); //

app.Run();
