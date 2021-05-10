using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Configuration;
using ToyRobotSimLib.Enums;
using ToyRobotSimLib.Interfaces;

namespace ToyRobotSimLib.Domain
{
    public class Board : IBoard
    {
        public int XAxisSizeLimit { get; private set; }
        public int YAxisSizeLimit { get; private set; }
        private AppSettings config;

        public Board(IOptions<AppSettings> options)
        {
            config = options.Value;
            XAxisSizeLimit = config.XAxisSizeLimit;
            YAxisSizeLimit = config.YAxisSizeLimit;
        }

        public bool CheckPosition(Position position)
        {
            return position.X <= XAxisSizeLimit && position.Y <= YAxisSizeLimit;
        }

        public void Configure(int rows, int columns)
        {
            throw new NotImplementedException();
        }

        public bool ValidateBoardMove(Direction direction, Position position, out string result)
        {
            result = null;
            switch (direction)
            {
                case Direction.North:
                    if ((position.Y) < XAxisSizeLimit && position.Y >= 0)
                        return true;
                    break;
                case Direction.East:
                    if ((position.X) < YAxisSizeLimit && position.X >= 0)
                        return true;
                    break;
                case Direction.South:
                    if ((position.Y) < XAxisSizeLimit && position.Y >= 0)
                        return true;
                    break;
                case Direction.West:
                    if ((position.X) < YAxisSizeLimit && position.X >= 0)
                        return true;
                    break;
            }
            result = $"Oops, the placement exceeds the boards boundaries. Please try again.";
            return false;
        }
        public bool ValidateBoardPlacement(Direction direction, Position position, out string result)
        {
            result = null;
            if ((position.Y < YAxisSizeLimit && position.Y >= 0)  && (position.X < XAxisSizeLimit && position.X >= 0))
                return true;
            result = $"Oops, the placement exceeds the boards boundaries. Please try again.";
            return false;
        }
    }
}
