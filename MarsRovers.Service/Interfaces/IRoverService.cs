using MarsRovers.Data.Core.Entities;
using MarsRovers.Data.Core.Enums;

namespace MarsRovers.Service.Interfaces
{
    internal interface IRoverService
    {
        Rover MoveCommands(Rover rover, string movedCommands);
        CompassDirectionsType TurnLeft(CompassDirectionsType roverDirection);
        CompassDirectionsType TurnRight(CompassDirectionsType roverDirection);
        Rover Move(Rover rover);
    }
}
