using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinimalApiTest.Pages
{
    public class IndexModel : PageModel
    {
        public string Name { get; set; } = string.Empty;
        public void OnGet()
        {
        }
    }
}
