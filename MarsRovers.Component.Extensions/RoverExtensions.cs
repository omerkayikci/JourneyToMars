using MarsRovers.Data.Core.Entities;
using System.Text;

namespace MarsRovers.Extensions
{
    public static class RoverExtensions
    {
        /// <summary>
        /// Screen output for Rover motion
        /// </summary>
        /// <param name="rover">Rover result information on the move</param>
        /// <returns></returns>
        public static string ToRoverLastPosition(this Rover rover)
        {
            StringBuilder sb = new StringBuilder($"Rover x Coordinate: {rover.RoverPosition.XCoordinate}\n");
            sb.Append($"Rover y Coordinate: {rover.RoverPosition.YCoordinate}\n");
            sb.Append($"Rover Direction: {rover.RoverDirection}\n\n");

            return sb.ToString();
        }
    }
}
