using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Domain;
using ToyRobotSimLib.Enums;

namespace ToyRobotSimLib.Interfaces
{
    public interface IRobot
    {
        #region Properties

        bool IsPlaced { get; set; }
        Direction Direction { get; set; }
        Position Position { get; set; }

        #endregion

        #region Methods

        bool Place(Direction direction, Position position);
        object Move();
        Direction TurnLeft();
        Direction TurnRight();
        string Report();

        #endregion

        #region Helpers

        Direction CurrrentDirection();
        (bool isPlaced, Direction direction, Position position) CurrentPlacement();
        (Direction direction, Position position) CurrentPosition();
        (Direction direction, Position position) CalculateMove();

        #endregion
    }
}
