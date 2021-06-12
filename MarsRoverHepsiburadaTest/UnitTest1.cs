using MarsRoverHepsiburadaCase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace MarsRoverHepsiburadaTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AreaSizeCheck()
        {
            IScanningAreaSize areaSize = new AreaSize("5 5");

            Assert.IsNotNull(areaSize.Width);
            Assert.IsNotNull(areaSize.Height);
            Assert.AreEqual(5, areaSize.Width);
            Assert.AreEqual(5, areaSize.Height); 
        }


        [TestMethod]
        public void initializeRoverPositionAndOperationTest()
        {
            var mockObject = Substitute.For<IScanningAreaSize>();
            mockObject.Width.Returns(5);
            mockObject.Height.Returns(5);

            RoverCalculation roverCal = new RoverCalculation(mockObject);

            //initialize rover position and operation
            roverCal.initializeRoverPositionAndOperation("1 2 N", "LMLMLMLMM");
            roverCal.initializeRoverPositionAndOperation("3 3 E", "MMRMMRMRRM");
             
            //Has two row
            Assert.IsTrue(roverCal.Count > 0);
            Assert.IsFalse(roverCal.Count != 2);
            Assert.IsTrue(roverCal.Count == 2);

            Assert.IsFalse(roverCal.Count == 1);

            IRover firstRover = roverCal[0];
            IRover secondRover = roverCal[1];

            Assert.IsNotNull(firstRover);
            Assert.IsNotNull(secondRover); 
        }


        [TestMethod]
        public void RoverIsWithinArea()
        {
            var mockObject = Substitute.For<IScanningAreaSize>();
            mockObject.Width.Returns(5);
            mockObject.Height.Returns(5);

            RoverCalculation roverCal = new RoverCalculation(mockObject);

            //initialize rover position and operation
            roverCal.initializeRoverPositionAndOperation("1 2 N", "LMLMLMLMM");
            roverCal.initializeRoverPositionAndOperation("3 3 E", "MMRMMRMRRM");

            //FirstRover has not changed direction
            Assert.IsFalse(roverCal[0].CoordinateXAxis == 1 && roverCal[0].CoordinateYAxis == 2 && roverCal[0].RoverDirection == "N");

            //SecondRover has not changed direction
            Assert.IsFalse(roverCal[1].CoordinateXAxis == 3 && roverCal[1].CoordinateYAxis == 3 && roverCal[1].RoverDirection == "E");
             
        }

        [TestMethod]
        public void RoverCoordinateTest()
        {
            //Area scanning size  mock
            var mockObject = Substitute.For<IScanningAreaSize>();
            mockObject.Width.Returns(5);
            mockObject.Height.Returns(5);
            RoverCalculation roverCal = new RoverCalculation(mockObject);

            //initialize rover position and operation
            roverCal.initializeRoverPositionAndOperation("1 2 N", "LMLMLMLMM");
            roverCal.initializeRoverPositionAndOperation("3 3 E", "MMRMMRMRRM");
             
            IRover firstRover = roverCal[0];
            IRover secondRover = roverCal[1]; 
             
            Assert.AreEqual(1, firstRover.CoordinateXAxis);
            Assert.AreEqual(3, firstRover.CoordinateYAxis);
            Assert.AreEqual("N",firstRover.RoverDirection);

            Assert.AreEqual(5, secondRover.CoordinateXAxis);
            Assert.AreEqual(1, secondRover.CoordinateYAxis);
            Assert.AreEqual("E", secondRover.RoverDirection);
        }
    }
}
