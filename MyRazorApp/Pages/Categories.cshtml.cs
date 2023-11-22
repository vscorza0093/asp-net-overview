using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorApp.Pages
{
    public class CategoriesModel : PageModel
    {
        public List<Category> CategoryList { get; set; } = new(); 

        public void OnGet(int skip=0, int take=25)
        {
            var intermediateList = new List<Category>();
            for (int i = 0; i <= 1787; i++)
            {
                intermediateList.Add(new Category(i, $"Categoria {i}", i * 18.95m));
            }
            CategoryList = intermediateList.Skip(skip).Take(take).ToList();
        }
    }
}
public record Category(int Id, string Title, decimal Price);
