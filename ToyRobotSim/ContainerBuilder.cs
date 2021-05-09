using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Domain;
using ToyRobotSimLib.Interfaces;
using ToyRobotSimLib.Services;
using System.IO;
using ToyRobotSimLib.Configuration;

namespace ToyRobotSim
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var services = new ServiceCollection();

            // build config
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();
            services.Configure<AppSettings>(configuration.GetSection("App"));

            // add services
            services.AddSingleton<IBoard, Board>();
            services.AddSingleton<IRobot, Robot>();
            services.AddSingleton<ISimulator, Simulator>();
            services.AddSingleton<IDirectiveParser, DirectiveParser>();

            // configure logging
            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            return services.BuildServiceProvider();
        }
    }
}
