using MarsRovers.Core.Common.Helpers;
using MarsRovers.Extensions;
using MarsRovers.Data.Core.Entities;
using MarsRovers.Data.Core.Enums;
using MarsRovers.Service;

using System;
using System.Linq;

namespace MarsRovers.ManuallyCommands
{
    public static class Program
    {
        static MarsRoverService _roverService;
        static RoverPosition _roverPosition;
        static MarsSurface _marsSurface;
        private static void Main(string[] args)
        {
            _roverService = new MarsRoverService();

            RoversMove();
        }

        private static void RoversMove()
        {
            Console.WriteLine("Manuel Input;");
            Console.WriteLine($"Enter the First Edge of the Plateau Surface(Sample Format:0x0):");
            var plateauInfo = Console.ReadLine().Trim().Split('x').ToList();

            if (!plateauInfo.IsSuitableSurface())
            {
                Console.WriteLine("Wrong surface area entry.");
                //4xx: Client Error It means the request contains incorrect syntax or cannot be fulfilled.
                Environment.Exit(400);
            }

            _marsSurface = new MarsSurface(int.Parse(plateauInfo.FirstOrDefault()), int.Parse(plateauInfo.LastOrDefault()));

            Console.WriteLine($"Enter the Rover Position and Direction(Sample Format:1 3 N):");
            var roverInfo = Console.ReadLine().Trim().Split(' ').ToList();

            if (!roverInfo.IsSuitableRoverInfo())
            {
                Console.WriteLine("Wrong rover information entry.");
                //4xx: Client Error It means the request contains incorrect syntax or cannot be fulfilled.
                Environment.Exit(400);
            }

            _roverPosition = new RoverPosition(int.Parse(roverInfo[0]), int.Parse(roverInfo[1]));
            CompassDirectionsType roverDirection = Enum.Parse<CompassDirectionsType>(roverInfo[2]);

            Console.WriteLine($"Enter the Rover motion commands");
            var roverCommands = Console.ReadLine();

            Rover firstRover = new Rover(_marsSurface, _roverPosition, roverDirection);
            firstRover = _roverService.MoveCommands(firstRover, roverCommands);

            Console.WriteLine($"{Environment.NewLine}Manually entered Mars surface information;{Environment.NewLine}{_marsSurface.SurfaceFirstEdge}x{_marsSurface.SurfaceSecondEdge}{Environment.NewLine}");
            Console.WriteLine($"Manually entered Rover position information;{Environment.NewLine}{_roverPosition.XCoordinate}x{_roverPosition.YCoordinate} {roverDirection.ToString()}{Environment.NewLine}");
            Console.WriteLine($"Rover Output;{Environment.NewLine}{firstRover.ToRoverLastPosition()}");

            Console.ReadLine();
        }
    }
}
