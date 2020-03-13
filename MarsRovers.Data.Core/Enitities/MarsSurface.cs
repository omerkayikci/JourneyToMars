using MarsRovers.Data.Core.Interfaces;

namespace MarsRovers.Data.Core.Enitities
{
    public class MarsSurface : ISurface
    {
        public int SurfaceFirstEdge { get; set; }
        public int SurfaceSecondEdge { get; set; }

        public MarsSurface(int aEdge, int bEdge)
        {
            SurfaceFirstEdge = aEdge;
            SurfaceSecondEdge = bEdge;
        }
    }
}
