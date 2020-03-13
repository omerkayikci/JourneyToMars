using MarsRovers.Data.Core.Enums;

namespace MarsRovers.Data.Core.Enitities
{
    public class Rover
    {
        public MarsSurface Plateau { get; set; }
        public RoverPosition RoverPosition { get; set; }
        public CompassDirectionsType RoverDirection { get; set; }
        
        public Rover(MarsSurface plateau, RoverPosition roverPosition, CompassDirectionsType direction)
        {
            Plateau = plateau;
            RoverPosition = roverPosition;
            RoverDirection = direction;
        }
    }
}
