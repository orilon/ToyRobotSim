using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Domain;
using ToyRobotSimLib.Enums;
using ToyRobotSimLib.Interfaces;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ToyRobotSim.Tests
{
    public class BoardTests
    {

        private readonly IServiceProvider serviceProvider = new ContainerBuilder().Build();
        private readonly IBoard board;
        private readonly ILogger logger;

        public BoardTests()
        {
            logger = serviceProvider.GetService<ILogger>();
            board = serviceProvider.GetService<IBoard>();
        }

        [Fact]
        public void BoardIsConfigured()
        {
            Assert.True(board.CheckPosition(new Position(5, 5)));
        }


        [Theory]
        [MemberData(nameof(TestData))]
        public void PlaceNotOutsideBoard(Direction direction, params int[] placement)
        {
            switch (direction)
            {
                case Direction.North:
                    Assert.True(placement[0] < 5 && placement[1] < 5);
                    break;
                case Direction.East:
                    Assert.True(placement[0] < 5 && placement[1] < 5);
                    break;
                case Direction.South:
                    Assert.True(placement[0] < 5 && placement[1] < 5);
                    break;
                case Direction.West:
                    Assert.True(placement[0] < 5 && placement[1] < 5);
                    break;
                default:
                    Assert.True(placement[0] < 5 && placement[1] < 5);
                    break;
            }
        }

        public static IEnumerable<object[]> TestData()
        {
            Random rnd = new Random();
            //object[] obj = new object[] { (Direction)Enum.ToObject(typeof(Direction), rnd.Next(0, 3)), new int[] { rnd.Next(0, 5), rnd.Next(0, 5) } };   
            yield return new object[] { (Direction)Enum.ToObject(typeof(Direction), rnd.Next(0, 3)), new int[] { rnd.Next(0, 5), rnd.Next(0, 5) } };
            yield return new object[] { (Direction)Enum.ToObject(typeof(Direction), rnd.Next(0, 3)), new int[] { rnd.Next(0, 5), rnd.Next(0, 5) } };
            yield return new object[] { (Direction)Enum.ToObject(typeof(Direction), rnd.Next(0, 3)), new int[] { rnd.Next(0, 5), rnd.Next(0, 5) } };
            yield return new object[] { (Direction)Enum.ToObject(typeof(Direction), rnd.Next(0, 3)), new int[] { rnd.Next(0, 5), rnd.Next(0, 5) } };
        }
    }
}
