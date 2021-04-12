using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace oh7.CspEditor.Core5.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseIISIntegration();
                    webBuilder.UseKestrel();
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}