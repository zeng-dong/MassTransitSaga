using MassTransitSaga.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace OrderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = SerilogConfigurator.CreateConfiguration()
                .CreateLogger();

            Log.Information("Configured Serilog, now build and run Host");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
