using System.Collections.Generic;

namespace Bluff.Models
{
    public class MarkerInfoComparer : IComparer<MarkerInfo>
    {
        public int Compare(MarkerInfo x, MarkerInfo y)
        {
            return x.Position.CompareTo(y.Position);
        }
    }
}