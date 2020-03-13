using MarsRovers.Data.Core.Interfaces;

namespace MarsRovers.Data.Core.Enitities
{
    public class RoverPosition : ICoordinates
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public RoverPosition(int xCoor, int yCoor)
        {
            XCoordinate = xCoor;
            YCoordinate = yCoor;
        }
    }
}
