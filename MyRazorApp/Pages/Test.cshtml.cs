using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages
{
    public class TestModel : PageModel
    {

        // Formato de inicialização anônima de objetos, com getter e setter, formato relativamente recente que simplifica a inicialização de objetos em C#
        public List<Guitar> GuitarList {get; set;} = new();

        Person personObject {get; set;} = new("João");

        public async Task OnGet()
        {
            await Task.Delay(2000);

            for (int i = 0; i < 20; i++)
                GuitarList.Add(new Guitar("Fender", "Telecaster"));
        }
    }
}
public record Person(string name);
// Palavra chave reservada "record" nos permite criar uma classe sem comportamentos, de maneira muito simplificada
public record Guitar(string brand, string model);
