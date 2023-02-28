using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RazorPage.Models.Identity;

namespace RazorPage.Models
{
    public class MyBlogContext : IdentityDbContext<User>
    {
        public DbSet<Article> articles { get; set; }

        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {
            //...option for MyBlog
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
