using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Domain;

namespace ToyRobotSimLib.Interfaces
{
    public interface IBoard
    {
        int Rows { get; }
        int Columns { get; }

        void Configure(int rows, int columns);

        bool CheckPosition(Position position);

    }
}
