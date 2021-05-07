using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Interfaces;

namespace ToyRobotSimLib.Services
{
    public class ActionParser : IActionParser
    {
        public Action ParseAction(string[] args)
        {
            Action action;
            return Enum.TryParse(args[0], ignoreCase: true, out action)
                ? action
                : throw new ArgumentException($"The action provided is invalid. Please use one of the following actions: \nPLACE X,Y,F\nMOVE\nLEFT\nRIGHT\nREPORT");
        }
    }
}
