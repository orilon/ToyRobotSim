using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Domain;
using ToyRobotSimLib.Enums;

namespace ToyRobotSimLib.Interfaces
{
    public interface IBoard
    {
        int XAxisSizeLimit { get; }
        int YAxisSizeLimit { get; }

        void Configure(int rows, int columns);

        bool CheckPosition(Position position);

        bool ValidateBoardMove(Direction direction, Position position, out string result);

        bool ValidateBoardPlacement(Direction direction, Position position, out string result);

    }
}
