﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverHepsiburadaCase
{
    public class Rover : IRover
    {
        //Constructor
        public Rover(List<IRover> rovers, IScanningAreaSize areaSize, string roverPosition, string roverProcess)
        {
            //set Rover
            Rovers = rovers;

            // set initial rovers position
            initializeRoverStartPosition(roverPosition);

            //Control Rovers start position with in areasize
            if (!RoverIsWithinArea(areaSize))
                return;

            //calculate rovers new position
            calculateRoverProcess(roverProcess);
        }

        public int CoordinateXAxis { get; set; }
        public int CoordinateYAxis { get; set; }
        public string RoverDirection { get; set; }
        public List<IRover> Rovers { get; set; }

        private static readonly char Seperator = ' ';
        public static class RoverFront
        {
            public const string North = "N";
            public const string East = "E";
            public const string South = "S";
            public const string West = "W";
        }

        public static class Process
        {
            public const string Forward = "M";
            public const string TurnLeft = "L";
            public const string TurnRight = "R";
        }
        private void initializeRoverStartPosition(string roverPosition)
        {
            string[] roverPositions = roverPosition.Split(Rover.Seperator);
            this.CoordinateXAxis = Convert.ToInt32(roverPositions[0]);
            this.CoordinateYAxis = Convert.ToInt32(roverPositions[1]);
            this.RoverDirection = roverPositions[2];
        }

        private void calculateRoverProcess(string roverProcess)
        {
            char[] proceses = roverProcess.ToCharArray();

            foreach (char process in proceses)
            {
                switch (process.ToString())
                {
                    //Process is move forward
                    // set new direction
                    case Process.Forward:
                        if (this.RoverDirection == RoverFront.North)
                            this.CoordinateYAxis += 1;
                        else if (this.RoverDirection == RoverFront.East)
                            this.CoordinateXAxis += 1;
                        else if (this.RoverDirection == RoverFront.South)
                            this.CoordinateYAxis -= 1;
                        else if (this.RoverDirection == RoverFront.West)
                            this.CoordinateXAxis -= 1;
                        break;

                    //Rover Turn left
                    case Process.TurnLeft:

                        if (this.RoverDirection == RoverFront.North)
                            this.RoverDirection = RoverFront.West;
                        else if (this.RoverDirection == RoverFront.West)
                            this.RoverDirection = RoverFront.South;
                        else if (this.RoverDirection == RoverFront.South)
                            this.RoverDirection = RoverFront.East;
                        else if (this.RoverDirection == RoverFront.East)
                            this.RoverDirection = RoverFront.North;
                        break;

                    //Rover Turn Rigth
                    case Process.TurnRight:

                        if (this.RoverDirection == RoverFront.North)
                            this.RoverDirection = RoverFront.East;
                        else if (this.RoverDirection == RoverFront.East)
                            this.RoverDirection = RoverFront.South;
                        else if (this.RoverDirection == RoverFront.South)
                            this.RoverDirection = RoverFront.West;
                        else if (this.RoverDirection == RoverFront.West)
                            this.RoverDirection = RoverFront.North;
                        break;
                    default:
                        throw new Exception();
                }
            }
        }

        private bool RoverIsWithinArea(IScanningAreaSize areaSize)
        {
            bool param = false;
            if ((CoordinateXAxis >= 0) && (CoordinateXAxis < areaSize.Width) &&
                (CoordinateYAxis >= 0) && (CoordinateYAxis < areaSize.Height))
                param = true;

            return param;
        }
    }
}
