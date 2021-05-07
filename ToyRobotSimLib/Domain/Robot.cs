using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimLib.Enums;
using ToyRobotSimLib.Interfaces;
using Microsoft.Extensions.Logging;

namespace ToyRobotSimLib.Domain
{
    public class Robot : IRobot
    {
        public Direction Direction { get; set; }
        private readonly ILogger<Robot> _logger;

        public Robot(ILogger<Robot> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void ProcessAction()
        {
            _logger.LogInformation($"Processing action...");
        }
    }
}
