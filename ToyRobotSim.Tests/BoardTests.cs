using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Enums;
using Xunit;

namespace ToyRobotSim.Tests
{
    public class BoardTests
    {
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

            yield return new object[] { (Direction)Enum.ToObject(typeof(Direction), rnd.Next(0,3)), new int[] { rnd.Next(0, 5), rnd.Next(0, 5) } };
        }
    }
}
