using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Enums;

namespace ToyRobotSimLib.Interfaces
{
    public interface IDirectiveParser
    {
        Directive ParseDirective(string[] args);


    }
}
