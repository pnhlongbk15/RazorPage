using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPage.Areas.Products.Pages
{
    public class Test : PageModel
    {
        public string Name { get; set; } = "hoang long";
        // Get
        public void OnGet()
        {
            Console.WriteLine("onGet");
        }
        // Get ?handler=Long
        public void OnGetLong()
        {
            Console.WriteLine("OnGetLong");
        }

    }
}
