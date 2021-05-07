using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Enums;

namespace ToyRobotSimLib.Interfaces
{
    public interface IRobot
    {
        bool IsPlaced { get; set; }

        Direction Direction { get; set; }
        
    }
}
