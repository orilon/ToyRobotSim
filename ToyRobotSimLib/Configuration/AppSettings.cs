using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimLib.Configuration
{
    public class AppSettings
    {
        //TODO: Expand functionality for user to upload test case files, containing commands, to execute in/as batches.
        public string TempDirectory { get; set; }
        public int XAxisSizeLimit { get; set; }
        public int YAxisSizeLimit { get; set; }
    }
}
