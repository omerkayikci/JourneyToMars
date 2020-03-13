using MarsRovers.Data.Core.Enitities;
using System.Text;

namespace MarsRovers.Extensions
{
    public static class RoverExtensions
    {
        public static string ToRoverLastPosition(this Rover rover)
        {
            StringBuilder sb = new StringBuilder($"Rover x Coordinate: {rover.RoverPosition.XCoordinate}\n");
            sb.Append($"Rover y Coordinate: {rover.RoverPosition.YCoordinate}\n");
            sb.Append($"Rover Direction: {rover.RoverDirection}\n\n");

            return sb.ToString();
        }
    }
}
