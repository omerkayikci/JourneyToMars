using MarsRovers.Data.Core.Enitities;
using MarsRovers.Data.Core.Enums;
using MarsRovers.Service.Interfaces;

using System;

namespace MarsRovers.Service
{
    public class MarsRoverService : IRoverService
    {
        /// <summary>
        /// Her 90 derecelik dönüş Kuzey baz alınarak düşünüldüğünde 1 adım olarak nitelendirildi.
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
        #region  İlerleme yönü saat yönü baz alınarak düşünülmüşür. Yani sola dönüş eksi yön sağa dönüş artı yön olarak düşünülmüştür. ileri hareket yönünde ise Kuzey ve Doğu artı, Güney ve Batı eksi yön olarak düşünülmüştür.
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
