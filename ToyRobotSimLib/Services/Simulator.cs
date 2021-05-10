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
    public abstract class Simulator : ISimulator
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

        public string GetConsoleIntroduction(bool breakToNewLine = false, bool asciiHeader = false)
        {
            StringBuilder sb = new StringBuilder();
            if (asciiHeader)
            {
                sb.AppendLine($"#######                 ######                                 #####           ");
                sb.AppendLine($"   #     ####  #   #    #     #  ####  #####   ####  #####    #     # # #    # ");
                sb.AppendLine($"   #    #    #  # #     #     # #    # #    # #    #   #      #       # ##  ## ");
                sb.AppendLine($"   #    #    #   #      ######  #    # #####  #    #   #       #####  # # ## # ");
                sb.AppendLine($"   #    #    #   #      #   #   #    # #    # #    #   #            # # #    # ");
                sb.AppendLine($"   #    #    #   #      #    #  #    # #    # #    #   #      #     # # #    # ");
                sb.AppendLine($"   #     ####    #      #     #  ####  #####   ####    #       #####  # #    # ");
                sb.AppendLine($"");
            }
            sb.AppendLine($"A phenomenal AI toy robot simulator, without the AI, progressing one unit at a time...");
            sb.AppendLine($"");
            sb.AppendLine($"To Start, you need to PLACE the robot onto the virtual board, which is {board.XAxisSizeLimit} (X-axis) by {board.YAxisSizeLimit} (Y-axis) units in size.");
            sb.AppendLine($"Commands:");
            sb.AppendLine($"".AppendPlaceInstruction(breakToNewLine));
            sb.AppendLine($"".AppendTurnLeftInstruction(breakToNewLine));
            sb.AppendLine($"".AppendTurnRightInstruction(breakToNewLine));
            sb.AppendLine($"".AppendMoveInstruction(breakToNewLine));
            sb.AppendLine($"".AppendReportInstruction(breakToNewLine));
            sb.AppendLine($"");
            return sb.ToString();
        }

        public string ProcessDirective(string[] args)
        {
            try
            {
                string result;
                var directive = (Enums.Directive)directiveParser.ParseDirective(args);

                if (!robot.IsPlaced && !Enum.Equals(directive, Directive.Place))
                    throw new NotImplementedException($"The Toy Robot has not yet been placed. Please place the robot first, using \"PLACE X,Y,F\"");

                (Direction direction, Position position) currentPosition = robot.CurrentPosition();
                switch (directive)
                {
                    case Directive.Place:
                        int x = args[1].Trim().Split(',')[0].GetInt();
                        int y = args[1].Trim().Split(',')[1].GetInt();
                        Direction direction = args[1].Trim().Split(',')[2].GetDirection();
                        if (!(direction, new Position(x, y)).ValidateBoardPlacement(board, out result))
                            return result;
                        robot.Place(direction, new Position(x, y));
                        return robot.Report();
                        break;
                    case Directive.Move:
                        if (robot.CalculateMove().ValidateBoardMove(board, out result))
                            robot.Move();
                        break;
                    case Directive.Left:
                        robot.TurnLeft();
                        break;
                    case Directive.Right:
                        robot.TurnRight();
                        break;
                    case Directive.Report:
                        return robot.Report();
                        break;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return string.Empty;

        }

        public bool CheckPosition(Position position) => board.CheckPosition(position);
    }
}
