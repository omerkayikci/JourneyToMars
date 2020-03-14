using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRovers.Core.Common.Helpers
{
    public static class PlateauHelper
    {
        /// <summary>
        /// The accuracy of the surface information entered
        /// </summary>
        /// <param name="surface">Surface Information</param>
        /// <returns></returns>
        public static bool IsSuitableSurface(this IEnumerable<string> surface)
        {
            bool suitableSurface = false;

            if (surface.Count() != 2)
            {
                return suitableSurface;
            }

            int.TryParse(surface.FirstOrDefault(), out int firstEdge);
            int.TryParse(surface.LastOrDefault(), out int secondEdge);

            if (firstEdge == 0 || secondEdge == 0)
            {
                return suitableSurface;
            }
            else
            {
                suitableSurface = true;
            }

            return suitableSurface;
        }
    }
}
