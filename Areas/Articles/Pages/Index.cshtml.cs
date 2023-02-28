using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPage.Models;

namespace RazorPage.Areas.Articles.Pages
{
    public class Articles : PageModel
    {
        private readonly MyBlogContext _myBlogContext;
        public Articles(MyBlogContext blogContext)
        {
            _myBlogContext = blogContext;
        }

        public void OnGet()
        {
            var posts = (from a in _myBlogContext.articles
                         orderby a.Created descending
                         select a).ToList();
            ViewData["posts"] = posts;
            Console.WriteLine("posts:{0}", posts);
        }
    }
}
