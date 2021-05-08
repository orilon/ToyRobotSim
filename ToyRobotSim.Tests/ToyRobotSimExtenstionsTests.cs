using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Interfaces;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToyRobotSimLib.Enums;
using ToyRobotSimLib.Extensions;

namespace ToyRobotSim.Tests
{
    public class ToyRobotSimExtenstionsTests
    {
        private readonly IServiceProvider serviceProvider = new ContainerBuilder().Build();
        private readonly ISimulator simulator;
        private readonly IBoard board;

        public ToyRobotSimExtenstionsTests()
        {
            board = serviceProvider.GetService<IBoard>();
            simulator = serviceProvider.GetService<ISimulator>();
        }

        [Fact]
        public void ValidateCorrectGetDirectionSuccessful()
        {
            Assert.True("north".GetDirection() == Direction.North);
        }
        [Fact]
        public void ValidateIncorrectGetDirectionEnumFails()
        {
            Assert.False("south".GetDirection() == Direction.North);
        }
        [Fact]
        public void ValidateIncorrectGetDirectionValueFails()
        {
            Assert.Throws<ArgumentException>(() => "5".GetDirection());
        }

    }
}
