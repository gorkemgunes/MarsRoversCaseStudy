﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverHepsiburadaCase
{
    public interface IRover
    {
        int CoordinateXAxis { get; set; }
        int CoordinateYAxis { get; set; }
        string RoverDirection { get; set; }
        List<IRover> Rovers { get; set; }
    }
}
