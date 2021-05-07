using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimLib.Domain
{
    public class Position
    {
        //private readonly ILogger<Position> _logger;
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

    }
}
