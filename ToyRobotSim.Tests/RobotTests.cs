using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ToyRobotSimLib.Domain;
using ToyRobotSimLib.Interfaces;
using Xunit;

namespace ToyRobotSim.Tests
{
    public class RobotTests
    {
        private readonly IServiceProvider serviceProvider = new ContainerBuilder().Build();
        private readonly IRobot robot;

        public RobotTests()
        {
            robot = serviceProvider.GetService<IRobot>();
        }

        [Fact]
        public void RobotIsNotPlaced()
        {
            Assert.True(!robot.IsPlaced);
        }

    }
}
