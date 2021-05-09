using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using ToyRobotSimLib.Domain;
using ToyRobotSimLib.Interfaces;
using ToyRobotSimLib.Services;
using ToyRobotSimLib.Configuration;
using System.Text;

namespace ToyRobotSim
{
    class Program
    {

        public static readonly IServiceProvider serviceProvider = new ContainerBuilder().Build();
        private AppSettings config;

        static void Main(string[] args)
        {
            //Startup();
            //IOptions<AppSettings> options

            ILogger logger = serviceProvider.GetService<ILogger<IRobot>>();
            IBoard board = serviceProvider.GetService<IBoard>();
            IRobot robot = serviceProvider.GetService<IRobot>();
            IDirectiveParser parser = serviceProvider.GetService<IDirectiveParser>();
            ISimulator simulator = new Simulator(board, robot, parser);

            Console.WriteLine(simulator.GetConsoleIntroduction());
            bool _exit = false;
            do
            {
                try
                {
                    Console.WriteLine($"What would you like the robot to do?");
                    if (args.Length == 0)
                        args = Console.ReadLine().Split(' ');
                    var response = simulator.ProcessDirective(args);
                    if (!String.IsNullOrEmpty(response))
                        Console.WriteLine($"{response}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

                Console.WriteLine($"");
                args = new string[] { };

            } while (!_exit);

        }

    }
}
