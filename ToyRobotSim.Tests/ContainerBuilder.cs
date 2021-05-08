using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Domain;
using ToyRobotSimLib.Interfaces;
using ToyRobotSimLib.Services;

namespace ToyRobotSim.Tests
{
    public class ContainerBuilder
    {
        public IServiceProvider Build()
        {
            var container = new ServiceCollection();

            container.AddSingleton<IBoard, Board>();
            container.AddSingleton<IRobot, Robot>();
            container.AddSingleton<ISimulator, Simulator>();
            container.AddSingleton<IDirectiveParser, DirectiveParser>();

            // configure logging
            container.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            return container.BuildServiceProvider();
        }
    }
}
