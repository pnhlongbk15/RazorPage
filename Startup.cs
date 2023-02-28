using Microsoft.EntityFrameworkCore;
using RazorPage.Models;

namespace RazorPage
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration) // ta có thể đọc file appsetting.json qua đối tượng IConfiguration.
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyBlogContext>(option =>
            {
                string connectString = Configuration.GetConnectionString("MyBlogContext");
                option.UseMySQL(connectString);
            });



            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                 {
                     options.RootDirectory = "/Pages"; // folder contains file.cshtml, default is Pages.
                     // however, we can custome path to access at @page in file.cshtml 
                     // we have default folder for store file.cshtml with subject is Areas.
                     // options.Conventions.AddPageRoute("pathDefault", "pathCustome"); // override path default in razor page.
                 });
            // config route for razor page
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("hello world");
                });
            });
        }
    }
}
