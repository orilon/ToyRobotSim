using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Domain;
using ToyRobotSimLib.Enums;
using ToyRobotSimLib.Interfaces;

namespace ToyRobotSimLib.Extensions
{
    public static class ToyRobotSimExtensions
    {
        public static Direction GetDirection(this string val)
        {
            Direction direction;
            if (!Enum.TryParse(val, true, out direction))
                throw new ArgumentException($"Unable to convert {val} to a valid direction. \nYour options are {string.Join(",", Enum.GetNames(typeof(Direction)))}");
            return direction;
        }

        public static Directive GetDirective(this string val)
        {
            Directive directive;
            if (!Enum.TryParse(val, true, out directive))
                throw new ArgumentException($"Unable to convert {val} to a valid directive. \nYour options are {string.Join(",", Enum.GetNames(typeof(Directive)))}");
            return directive;
        }

        public static int GetInt(this string val)
        {
            int output;
            if (!int.TryParse(val, out output))
                throw new ArgumentException($"Unable to convert {val} to a number. \nYour options are between 1 - 5.");
            return output;
        }

        public static bool ValidateBoardMove(this (Direction direction, Position position) val)
        {
            int output;
            if (!int.TryParse(val.position, out output))
                throw new ArgumentException($"Unable to convert {val} to a number. \nYour options are between 1 - 5.");
            return output;
        }

        public static bool VerifyBoardPosition(this IBoard board, Direction direction, Position position)
        {
            switch (direction)
            {
                case Direction.North:
                    if (position.Y < board.Rows)
                    break;
                case Direction.East:
                    break;
                case Direction.South:
                    break;
                case Direction.West:
                    break;
                default:
                    break;
            }
        }

    }
}
