using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using ToyRobotSimLib.Domain;

namespace ToyRobotSim.Tests
{
    public class SimulatorTests
    {
        private readonly IServiceProvider serviceProvider = new ContainerBuilder().Build();
        private readonly ISimulator simulator;
        private readonly IBoard board;

        public SimulatorTests()
        {
            board = serviceProvider.GetService<IBoard>();
            simulator = serviceProvider.GetService<ISimulator>();
        }

        [Fact]
        public void ValidateBoardBoundaries()
        {
            Assert.True(board.XAxisSizeLimit == 5 && board.YAxisSizeLimit == 5);
        }

        [Fact]
        public void ValidateTestScenarioOutcome1()
        {
            string[] args = new string[] { $"PLACE", $"1,1,North" };
            var result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"RIGHT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"RIGHT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"REPORT" };
            result = simulator.ProcessDirective(args);
            Assert.True(result.Equals("2,2,south",StringComparison.OrdinalIgnoreCase));
        }


        [Fact]
        public void ValidateTestScenarioOutcome2()
        {
            string[] args = new string[] { $"PLACE", $"0,0,East" };
            var result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"RIGHT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"LEFT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"LEFT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"RIGHT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"REPORT" };
            result = simulator.ProcessDirective(args);
            Assert.True(result.Equals("4,3,east", StringComparison.OrdinalIgnoreCase));
        }



        [Fact]
        public void ValidateTestScenarioOutcome3()
        {
            string[] args = new string[] { $"PLACE", $"4,2,East" };
            var result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"LEFT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"RIGHT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"LEFT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"RIGHT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"RIGHT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"RIGHT" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"MOVE" };
            result = simulator.ProcessDirective(args);
            args = new string[] { $"REPORT" };
            result = simulator.ProcessDirective(args);
            Assert.True(result.Equals("2,3,west", StringComparison.OrdinalIgnoreCase));
        }

    }
}
