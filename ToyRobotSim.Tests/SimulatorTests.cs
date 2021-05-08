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
            Assert.True(board.Rows == 5 && board.Columns == 5);
        }
    }
}
