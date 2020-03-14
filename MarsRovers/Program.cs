using MarsRovers.Data.Core.Entities;
using MarsRovers.Data.Core.Enums;
using MarsRovers.Extensions;
using MarsRovers.Service;

using System;

namespace MarsRovers
{
    public static class Program
    {
        static MarsRoverService _roverService;
        private static void Main(string[] args)
        {
            _roverService = new MarsRoverService();

            RoversMove();
        }

        private static void RoversMove()
        {
            Console.WriteLine("Input;");
            Console.WriteLine($"PlateauSurface: 5x5{Environment.NewLine}");
            Console.WriteLine($"First Rover Location: 1 2 N{Environment.NewLine}First Rover Commands Order: LMLMLMLMM{Environment.NewLine}");
            Console.WriteLine($"Second Rover Location: 3 3 E{Environment.NewLine}Second Rover Commands Order: MMRMMRMRRM{Environment.NewLine}");

            MarsSurface marsSurface = new MarsSurface(5, 5);

            Rover firstRover = new Rover(marsSurface, new RoverPosition(1, 2), CompassDirectionsType.N);
            firstRover = _roverService.MoveCommands(firstRover, "LMLMLMLMM");

            Rover secondRover = new Rover(marsSurface, new RoverPosition(3, 3), CompassDirectionsType.E);
            secondRover = _roverService.MoveCommands(secondRover, "MMRMMRMRRM");

            Console.WriteLine($"First Rover Output;{Environment.NewLine}{firstRover.ToRoverLastPosition()}{Environment.NewLine}Second Rover Output;{Environment.NewLine}{secondRover.ToRoverLastPosition()}");

            Console.ReadLine();
        }
    }
}
