using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Enums;
using ToyRobotSimLib.Interfaces;

namespace ToyRobotSimLib.Services
{
    public class DirectiveParser : IDirectiveParser
    {
        public Directive ParseDirective(string[] args)
        {
            Directive directive;
            return Enum.TryParse(args[0], ignoreCase: true, out directive)
                ? directive
                : throw new ArgumentException($"The action provided is invalid. Please use one of the following actions: \nPLACE X,Y,F\nMOVE\nLEFT\nRIGHT\nREPORT");
        }
    }
}
