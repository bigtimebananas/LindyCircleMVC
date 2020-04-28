using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(LindyCircleMVC.Areas.Identity.IdentityHostingStartup))]
namespace LindyCircleMVC.Areas.Identity
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