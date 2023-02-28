namespace RazorPage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);
            hostBuilder.ConfigureWebHostDefaults((IWebHostBuilder webBuilder) =>
            {
                webBuilder.UseStartup<Startup>();
            });
            hostBuilder.Build().Run();
        }
    }
}
