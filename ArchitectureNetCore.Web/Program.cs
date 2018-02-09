using ArchitectureNetCore.Data.EF;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ArchitectureNetCore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

            DbInitializer.Initialize();
            return host;
        }
    }
}
