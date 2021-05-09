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

        public static bool ValidateBoardMove(this (Direction direction, Position position) value, IBoard board, out string result)
        {
            return board.ValidateBoardMove(value.direction, value.position, out result);
        }

        public static bool ValidateBoardPlacement(this (Direction direction, Position position) value, IBoard board, out string result)
        {
            return board.ValidateBoardPlacement(value.direction, value.position, out result);
        }

        public static string AppendPlaceInstruction(this string value, bool breakToNewLine = false)
        {
            string msg = $"PLACE X,Y,F :|||\"X\" is the X-Axis position value||\"Y\" is the Y-Axis position value||\"F\" is the Cardinal direction (North, East, West, South).";
            if (breakToNewLine)
            {
                return $"{msg.Replace("|||", "").Replace("||", "\n")}";
            }
            return $"{msg.Replace("|||", "").Replace("||", ", ")}";
        }

        public static string AppendMoveInstruction(this string value, bool breakToNewLine = false)
        {
            string msg = $"MOVE        :|||will move the Toy Robot in it's current Cardinal direction (North, East, West, South), by one position.";
            if (breakToNewLine)
            {
                return $"{msg.Replace("|||", "").Replace("||", "\n")}";
            }
            return $"{msg.Replace("|||", "").Replace("||", ", ")}";
        }

        public static string AppendTurnLeftInstruction(this string value, bool breakToNewLine = false)
        {
            string msg = $"LEFT        :|||will rotate/turn the Toy Robot from it's current Cardinal direction (North, East, West, South), by 90° to its LEFT.";
            if (breakToNewLine)
            {
                return $"{msg.Replace("|||", "").Replace("||", "\n")}";
            }
            return $"{msg.Replace("|||", "").Replace("||", ", ")}";
        }


        public static string AppendTurnRightInstruction(this string value, bool breakToNewLine = false)
        {
            string msg = $"RIGHT       :|||will rotate/turn the Toy Robot from it's current Cardinal direction (North, East, West, South), by 90° to its RIGHT.";
            if (breakToNewLine)
            {
                return $"{msg.Replace("|||", "").Replace("||", "\n")}";
            }
            return $"{msg.Replace("|||", "").Replace("||", ", ")}";
        }

        public static string AppendReportInstruction(this string value, bool breakToNewLine = false)
        {
            string msg = $"REPORT      :|||will output the Toy Robots x-Axis position, Y-Axis position, and its current Cardinal direction (North, East, West, South).";
            if (breakToNewLine)
            {
                return $"{msg.Replace("|||", "").Replace("||", "\n")}";
            }
            return $"{msg.Replace("|||", "").Replace("||", ", ")}";
        }


    }
}
