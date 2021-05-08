using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Interfaces;

namespace ToyRobotSimLib.Domain
{
    public class Board : IBoard
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Board()
        {
            Rows = 5;
            Columns = 5;
        }

        public bool CheckPosition(Position position)
        {
            return position.X <= Rows && position.Y <= Columns;
        }

        public void Configure(int rows, int columns)
        {
            throw new NotImplementedException();
        }
    }
}
