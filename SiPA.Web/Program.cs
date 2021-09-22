using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SiPA.Web.Data;
using System.IO;

namespace SiPA.Web
{
    public class Program
    {

        //Para publicar
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
         Host.CreateDefaultBuilder(args)
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
             });

        //Para desarrollar

        //public static void Main(string[] args)
        //{
        //    var host = CreateWebHostBuilder(args).Build();
        //    RunSeeding(host);
        //    host.Run();
        //}

        //private static void RunSeeding(IWebHost host)
        //{
        //    var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
        //    using (var scope = scopeFactory.CreateScope())
        //    {
        //        var seeder = scope.ServiceProvider.GetService<SeedDb>();
        //        seeder.SeedAsync().Wait();
        //    }
        //}

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        //{
        //    return WebHost.CreateDefaultBuilder(args)
        //        .UseContentRoot(Directory.GetCurrentDirectory())
        //        .UseWebRoot("wwwroot")
        //        .UseStartup<Startup>()
        //        .ConfigureLogging((ctx, logging) =>
        //         {
        //         });
        //}
    }
}
