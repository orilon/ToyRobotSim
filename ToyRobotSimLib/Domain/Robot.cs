using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Enums;
using ToyRobotSimLib.Interfaces;
using Microsoft.Extensions.Logging;

namespace ToyRobotSimLib.Domain
{
    public class Robot : IRobot
    {
        public Direction Direction { get; set; }
        public bool IsPlaced { get; set; }
        public Position Position { get; set; }

        private readonly ILogger<IRobot> _logger;

        public Robot(ILogger<IRobot> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public bool Place(Direction direction, Position position)
        {
            IsPlaced = true;
            Direction = direction;
            Position = position;
            return IsPlaced;
        }

        public object Move()
        {
            if (!IsPlaced)
                throw new ApplicationException($"Unable to move the robot until it has been (first) PLACED.");
            var newPosition = CalculateMove();
            Direction = newPosition.direction;
            Position = newPosition.position;
            return newPosition;
        }

        //TODO Refactor method (DRY with TurnRight)
        public Direction TurnLeft()
        {
            var directions = (Direction[])Enum.GetValues(typeof(Direction));
            Direction = ((int)Direction - 1) >= 0 ? directions[(int)Direction - 1] : directions[directions.Length - 1];
            return Direction;
        }

        //TODO Refactor method (DRY with TurnLeft)
        public Direction TurnRight()
        {
            var directions = (Direction[])Enum.GetValues(typeof(Direction));
            Direction = (int)Direction + 1 < directions.Length ? directions[(int)Direction + 1] : directions[0];
            return Direction;
        }

        public string Report()
        {
            if (!IsPlaced)
                return $"The Toy Robot has not yet been placed. Please place it using the following: PLACE X,Y,F";
            return $"{Position.X},{Position.Y},{Direction.ToString()}";
        }

        public Direction CurrrentDirection() => Direction;

        public (bool isPlaced, Direction direction, Position position) CurrentPlacement() => (IsPlaced, Direction, Position);

        public (Direction direction, Position position) CurrentPosition() => (Direction, Position);

        public (Direction direction, Position position) CalculateMove()
        {
            var nextPosition = new Position(Position.X, Position.Y);
            switch (Direction)
            {
                case Direction.North:
                    nextPosition.X++;
                    break;
                case Direction.East:
                    nextPosition.Y++;
                    break;
                case Direction.South:
                    nextPosition.X--;
                    break;
                case Direction.West:
                    nextPosition.Y--;
                    break;
            }
            return (Direction, nextPosition);
        }
    }
}
