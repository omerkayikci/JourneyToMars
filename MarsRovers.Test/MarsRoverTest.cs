using MarsRovers.Data.Core.Entities;
using MarsRovers.Data.Core.Enums;
using MarsRovers.Core.Common.Helpers;
using MarsRovers.Service;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MarsRovers.Test
{
    [TestClass]
    public class MarsRoverTest
    {
        readonly MarsRoverService _marsRoverService;
        public MarsRoverTest()
        {
            _marsRoverService = new MarsRoverService();
        }
        /// <summary>
        /// Test method for First Rover check output
        /// </summary>
        [TestMethod]
        public void RoverMoveOutputCheck()
        {
            Rover inputRover = new Rover(new MarsSurface(5, 5), new RoverPosition(1, 2), CompassDirectionsType.N);
            Rover rover = _marsRoverService.MoveCommands(inputRover, "LMLMLMLMM");
            Assert.IsNotNull(rover);
            Assert.IsTrue(rover.RoverPosition.XCoordinate == 1);
            Assert.IsTrue(rover.RoverPosition.YCoordinate == 3);
            Assert.AreEqual(rover.RoverDirection, CompassDirectionsType.N);
        }

        /// <summary>
        /// Test method for surface area check
        /// </summary>
        [TestMethod]
        public void SuitableSurfaceTest()
        {
            List<string> surfaceInput = new List<string> { "5", "5" };
            bool result = surfaceInput.IsSuitableSurface();

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test method for wrong surface area check
        /// </summary>
        [TestMethod]
        public void SuitableSurfaceTest_Wrong()
        {
            List<string> surfaceInput = new List<string> { "wrongEdge1", "wrongEdge1", "5" };
            bool result = surfaceInput.IsSuitableSurface();

            Assert.IsTrue(!result);
        }

        /// <summary>
        /// Test method for rover position check
        /// </summary>
        [TestMethod]
        public void SuitableRoverPositionTest()
        {
            List<string> roverInput = new List<string> { "1", "2", "N" };
            bool result = roverInput.IsSuitableRoverInfo();

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test method for wrong rover position check
        /// </summary>
        [TestMethod]
        public void SuitableRoverPosition_Wrong()
        {
            List<string> roverInput = new List<string> { "roverxCorWrong", "roveryCorWrong", "NW" };
            bool result = roverInput.IsSuitableRoverInfo();

            Assert.IsTrue(!result);
        }
    }
}
