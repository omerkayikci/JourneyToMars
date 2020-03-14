using MarsRovers.Data.Core.Entities;
using MarsRovers.Data.Core.Enums;
using MarsRovers.Service.Interfaces;

namespace MarsRovers.Service
{
    public class MarsRoverService : IRoverService
    {
        /// <summary>
        /// 90 degrees, starting point north direction was determined and set as 1 step.
        /// </summary>
        private readonly int StepsDirectionNumber = 1;
        private readonly int StepsMovedNumber = 1;

        public Rover MoveCommands(Rover rover, string movedCommands)
        {
            foreach (var command in movedCommands)
            {
                switch (command)
                {
                    case ('L'):
                        rover.RoverDirection = TurnLeft(rover.RoverDirection);
                        break;
                    case ('R'):
                        rover.RoverDirection = TurnRight(rover.RoverDirection);
                        break;
                    case ('M'):
                        rover = Move(rover);
                        break;
                }
            }

            return rover;
        }
        #region left turn minus right turn is indicated as plus. It is thought as North and East plus, South and West minus in forward direction. Change of direction and progress are clockwise
        public CompassDirectionsType TurnLeft(CompassDirectionsType roverDirection)
        {
            return (roverDirection - StepsDirectionNumber) < CompassDirectionsType.N ? CompassDirectionsType.W : roverDirection - StepsDirectionNumber;
        }

        public CompassDirectionsType TurnRight(CompassDirectionsType roverDirection)
        {
            return (roverDirection + StepsDirectionNumber) > CompassDirectionsType.W ? CompassDirectionsType.N : roverDirection + StepsDirectionNumber;
        }

        public Rover Move(Rover rover)
        {
            switch (rover.RoverDirection)
            {
                case CompassDirectionsType.N:
                    rover.RoverPosition.YCoordinate = rover.RoverPosition.YCoordinate + StepsMovedNumber;
                    break;
                case CompassDirectionsType.E:
                    rover.RoverPosition.XCoordinate = rover.RoverPosition.XCoordinate + StepsMovedNumber;
                    break;
                case CompassDirectionsType.S:
                    rover.RoverPosition.YCoordinate = rover.RoverPosition.YCoordinate - StepsMovedNumber;
                    break;
                case CompassDirectionsType.W:
                    rover.RoverPosition.XCoordinate = rover.RoverPosition.XCoordinate - StepsMovedNumber;
                    break;
            }

            return rover;
        }
        #endregion
    }
}
