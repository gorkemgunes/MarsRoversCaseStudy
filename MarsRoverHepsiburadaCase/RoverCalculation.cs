using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverHepsiburadaCase
{
    public class RoverCalculation : List<IRover>
    {
        public IScanningAreaSize areaSize { get; set; }

        public RoverCalculation(IScanningAreaSize areaSize)
        {
            this.areaSize = areaSize;
        }
        public void initializeRoverPositionAndOperation(string roverPosition, string roverOperation)
        {
            this.Add(new Rover(this, this.areaSize, roverPosition, roverOperation));
        }

        
        
    }
}
