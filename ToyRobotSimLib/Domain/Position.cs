using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimLib.Domain
{
    public class Position
    {
        //private readonly ILogger<App> _logger;

        public Position(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public int X { get; }
        public int Y { get; }
    }
}
