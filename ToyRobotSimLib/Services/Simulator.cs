using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Interfaces;
using ToyRobotSimLib.Enums;
using ToyRobotSimLib.Domain;
using ToyRobotSimLib.Extensions;

namespace ToyRobotSimLib.Services
{
    public class Simulator : ISimulator
    {
        private readonly IBoard board;
        private readonly IRobot robot;
        private readonly IDirectiveParser directiveParser;

        public Simulator(IBoard board, IRobot robot, IDirectiveParser actionParser)
        {
            this.board = board;
            this.robot = robot;
            directiveParser = actionParser;
        }

        public string ProcessDirective(string[] args)
        {
            try
            {
                var directive = (Enums.Directive)directiveParser.ParseDirective(args);

                if (!robot.IsPlaced && !Enum.Equals(directive,Directive.Place))
                    throw new NotImplementedException($"The Toy Robot has not yet been placed. Please place the robot first, using \"PLACE X,Y,F\"");

                (Direction direction, Position position) currentPosition = robot.CurrentPosition();
                switch (directive)
                {
                    case Directive.Place:
                        int x = args[0].GetInt();
                        int y = args[1].GetInt();
                        Direction direction = args[2].GetDirection();
                        (Direction, Position) nextPosition = robot.CalculateMove(direction, new Position(x, y));
                        break;
                    case Directive.Move:
                        break;
                    case Directive.Left:
                        break;
                    case Directive.Right:
                        break;
                    case Directive.Report:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                return string.Empty;

            }

        }

        public bool CheckPosition(Position position) => board.CheckPosition(position);
    }
}
