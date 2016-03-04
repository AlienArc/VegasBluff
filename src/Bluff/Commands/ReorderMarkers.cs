using System.Collections.Generic;
using System.Runtime.InteropServices;
using Bluff.Helpers;
using Bluff.Models;
using Sony.Vegas;

namespace Bluff.Commands
{
    public class ReorderMarkers
    {
        public static void Execute(Vegas vegas)
        {
            var proj = vegas.Project;

            using (var undo = new UndoBlock("Convert Markers To Regions"))
            {
                var orderedMarkers = VegasHelper.GetMarkersByTimecode(proj);
                var markPositions = new List<MarkerInfo>();

                foreach (var marker in orderedMarkers)
                {
                    var mi = new MarkerInfo();
                    mi.Position = marker.Position;
                    mi.Label = marker.Label;
                    markPositions.Add(mi);

                    proj.Markers.Remove(marker);
                }
                
                foreach (var mark in markPositions)
                {
                    var marker = new Marker(mark.Position);
                    proj.Markers.Add(marker);
                    if (!string.IsNullOrEmpty(mark.Label))
                    {
                        marker.Label = mark.Label;
                    }
                }
            }

        }
    }
}