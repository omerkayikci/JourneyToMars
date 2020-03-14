using MarsRovers.Data.Core.Enums;

using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers.Core.Common.Helpers
{
    public static class RoverHelper
    {
        /// <summary>
        /// The accuracy of the rover information entered
        /// </summary>
        /// <param name="roverInfo">Rover Information</param>
        /// <returns></returns>
        public static bool IsSuitableRoverInfo(this List<string> roverInfo)
        {
            bool suitableRover = false;

            if (roverInfo.Count() != 3)
            {
                return suitableRover;
            }

            int.TryParse(roverInfo[0], out int xCoordinate);
            int.TryParse(roverInfo[1], out int yCoordinate);
            Enum.TryParse(roverInfo[2], out CompassDirectionsType direction);

            if (xCoordinate == 0 || yCoordinate == 0 || direction == 0)
            {
                return suitableRover;
            }
            else
            {
                suitableRover = true;
            }


            return suitableRover;
        }
    }
}
