using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Enums;

namespace ToyRobotSimLib.Interfaces
{
    public interface ISimulator
    {
        string ProcessDirective(string[] args);

        string GetConsoleIntroduction(bool breakToNewLine = false, bool asciiHeader = false);

    }
}
