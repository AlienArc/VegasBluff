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

            using (var undo = new UndoBlock("Reorder Marker and Regions"))
            {
                var existingMarkers = VegasHelper.GetMarkersByTimecode(proj);
                var existingRegions = VegasHelper.GetRegionsByTimecode(proj);

                var markPositions = RemoveMarkers(proj, existingMarkers);
                var regionPositions = RemoveRegions(proj, existingRegions);

                var combinedPositions = new List<MarkerInfo>(markPositions);
                foreach (var regionPosition in regionPositions)
                {
                    combinedPositions.Add(regionPosition);
                }
                combinedPositions.Sort(new MarkerInfoComparer());

                foreach (var cp in combinedPositions)
                {
                    AddRegionOrMarker(cp, proj.Regions, proj.Markers);
                }

                //foreach (var mi in markPositions)
                //{
                //    AddRegionOrMarker(mi, proj.Regions, proj.Markers);
                //    //proj.Markers.Add(GetRegionOrMarker(mi));
                //}

                //foreach (var ri in regionPositions)
                //{
                //    AddRegionOrMarker(ri, proj.Regions, proj.Markers);
                //    //proj.Regions.Add(GetRegionOrMarker(ri));
                //}
            }

        }

        private static void AddRegionOrMarker(MarkerInfo markerInfo, BaseMarkerList<Region> regionList, BaseMarkerList<Marker> markerList)
        {
            var regionOrMarker = GetRegionOrMarker(markerInfo);

            if (regionOrMarker is Region)
            {
                regionList.Add(regionOrMarker);
            }
            else
            {
                markerList.Add(regionOrMarker);
            }

            if (!string.IsNullOrEmpty(markerInfo.Label))
            {
                regionOrMarker.Label = markerInfo.Label;
            }
        }

        private static Marker GetRegionOrMarker(MarkerInfo markerInfo)
        {
            var regionInfo = markerInfo as RegionInfo;

            if (regionInfo != null)
            {
                //if (!string.IsNullOrEmpty(regionInfo.Label))
                //{
                //    return new Region(regionInfo.Position, regionInfo.Length, regionInfo.Label);
                //}
                return new Region(regionInfo.Position, regionInfo.Length);
            }

            //if (!string.IsNullOrEmpty(markerInfo.Label))
            //{
            //    return new Marker(markerInfo.Position, markerInfo.Label);
            //}
            return new Marker(markerInfo.Position);
        }

        private static List<RegionInfo> RemoveRegions(Project proj, List<Region> orderedRegions)
        {
            var regionPositions = new List<RegionInfo>();
            foreach (var region in orderedRegions)
            {
                var ri = new RegionInfo
                {
                    Position = region.Position,
                    Length = region.Length,
                    Label = region.Label
                };
                regionPositions.Add(ri);

                proj.Regions.Remove(region);
            }

            return regionPositions;
        }

        private static List<MarkerInfo> RemoveMarkers(Project proj, List<Marker> orderedMarkers)
        {
            var markPositions = new List<MarkerInfo>();
            foreach (var marker in orderedMarkers)
            {
                var mi = new MarkerInfo();
                mi.Position = marker.Position;
                mi.Label = marker.Label;
                markPositions.Add(mi);

                proj.Markers.Remove(marker);
            }

            return markPositions;
        }
    }
}