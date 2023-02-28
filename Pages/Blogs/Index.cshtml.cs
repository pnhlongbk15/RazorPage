using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage.Models;

namespace RazorPage.Areas_Blog
{
    public class IndexModel : PageModel
    {
        private readonly RazorPage.Models.MyBlogContext _context;

        public IndexModel(RazorPage.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.articles != null)
            {
                Article = await _context.articles.ToListAsync();
            }
        }
    }
}
