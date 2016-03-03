using System.Collections.Generic;
using Sony.Vegas;

namespace Bluff.Commands
{
    public class ConvertMarkersToRegions
    {
        public static void Execute(Vegas vegas)
        {
            Marker fistMarker = null;

            var markersToRemove = new List<Marker>();

            var proj = vegas.Project;

            using (var undo = new UndoBlock("Convert Markers To Regions"))
            {
                foreach (var marker in proj.Markers)
                {
                    if (fistMarker == null)
                    {
                        fistMarker = marker;
                    }
                    else
                    {
                        markersToRemove.Add(fistMarker);
                        markersToRemove.Add(marker);
                        Region currentRegion = new Region(fistMarker.Position, marker.Position - fistMarker.Position);
                        proj.Regions.Add(currentRegion);
                        fistMarker = null;
                    }
                }

                foreach (var marker in markersToRemove)
                {
                    proj.Markers.Remove(marker);
                }
            }

        }
    }
}