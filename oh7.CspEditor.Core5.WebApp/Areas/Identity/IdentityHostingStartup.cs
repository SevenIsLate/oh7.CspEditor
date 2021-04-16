using Microsoft.AspNetCore.Hosting;
using oh7.CspEditor.Core5.WebApp.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace oh7.CspEditor.Core5.WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}