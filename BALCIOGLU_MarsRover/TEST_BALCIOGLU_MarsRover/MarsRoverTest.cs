using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BALCIOGLU_MarsRover;
using static BALCIOGLU_MarsRover.Constant;

namespace TEST_BALCIOGLU_MarsRover
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void MarsRoverSuccessTest()
        {
            int platoX = 5;
            int platoY = 5;
            int roverCount = 2;
            string[] roverPositions = new string[2] { "1 2 N", "3 3 E" };
            string[] roverMoves = new string[2] { "LMLMLMLMM", "MMRMMRMRRM" };
            string[] roverPositionResult = new string[2] { "1 3 N", "5 1 E" };

            List<RoverInfo> roverList = new List<RoverInfo>();

            for (int i = 1; i <= roverCount; i++)
            {
                RoverInfo roverInfo = new RoverInfo() { RoverId = i };

                var positions = roverPositions[i - 1].Split(' ');

                roverInfo.X = Convert.ToInt16(positions[0]);
                roverInfo.Y = Convert.ToInt16(positions[1]);
                roverInfo.Direction = (Directions)Enum.Parse(typeof(Directions), positions[2]);
                roverInfo.RoverMoves = roverMoves[i - 1];
                roverList.Add(roverInfo);
            }

            foreach (var rover in roverList)
            {
                rover.RoverMovingStart(new List<int> { platoX, platoY });
                if(rover.Success) System.Diagnostics.Trace.WriteLine($"{rover.RoverMovesOut} {(rover.ErrorMessage.Length > 0 ? $" --> {rover.ErrorMessage}" : "")}");
                else System.Diagnostics.Trace.WriteLine(rover.ErrorMessage);
                Assert.IsTrue(rover.Success);
                Assert.AreEqual($"{rover.X} {rover.Y} {rover.Direction.ToString()}", roverPositionResult[rover.RoverId - 1]);
            }
        }

        [TestMethod]
        public void MarsRoverFailTest()
        {
            int platoX = 5;
            int platoY = 5;
            int roverCount = 2;
            string[] roverPositions = new string[2] { "1 2 N", "3 3 E" };
            string[] roverMoves = new string[2] { "LMLMLMLMMT", "MMMMRMMRTMRRM" };
            string[] roverPositionResult = new string[2] { "1 3 N", "5 1 E" };

            List<RoverInfo> roverList = new List<RoverInfo>();

            for (int i = 1; i <= roverCount; i++)
            {
                RoverInfo roverInfo = new RoverInfo() { RoverId = i };

                var positions = roverPositions[i - 1].Split(' ');

                roverInfo.X = Convert.ToInt16(positions[0]);
                roverInfo.Y = Convert.ToInt16(positions[1]);
                roverInfo.Direction = (Directions)Enum.Parse(typeof(Directions), positions[2]);
                roverInfo.RoverMoves = roverMoves[i - 1];
                roverList.Add(roverInfo);
            }

            foreach (var rover in roverList)
            {
                rover.RoverMovingStart(new List<int> { platoX, platoY });
                if (rover.Success) System.Diagnostics.Trace.WriteLine($"{rover.RoverMovesOut} {(rover.ErrorMessage.Length > 0 ? $" --> {rover.ErrorMessage}" : "")}");
                else System.Diagnostics.Trace.WriteLine(rover.ErrorMessage);
                Assert.IsTrue(rover.Success);
                Assert.AreEqual($"{rover.X} {rover.Y} {rover.Direction.ToString()}", roverPositionResult[rover.RoverId - 1]);
            }
        }
    }
}
