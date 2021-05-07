using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using ToyRobotSimLib.Domain;
using ToyRobotSimLib.Interfaces;

namespace ToyRobotSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void Startup()
        {
            // instantiate
            var services = new ServiceCollection();
            ConfigureServices(services);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // configure logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            // build config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            services.Configure<AppSettings>(configuration.GetSection("App"));

            // add services:
            services.AddTransient<IRobot, Robot>();

            // add app
            services.AddTransient<Program>();
        }
    }
}
