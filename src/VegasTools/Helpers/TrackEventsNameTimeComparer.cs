using System.Collections.Generic;
using Sony.Vegas;

namespace VegasTools.Helpers
{
    public class TrackEventsNameTimeComparer : IComparer<TrackEvent>
    {

        public int Compare(TrackEvent event1, TrackEvent event2)
        {

            var nameCompare = string.Compare(event1.ActiveTake.Name, event2.ActiveTake.Name);
            if (nameCompare != 0)
            {
                return nameCompare;
            }

            return event1.ActiveTake.Offset == event2.ActiveTake.Offset ? 0 : event1.ActiveTake.Offset > event2.ActiveTake.Offset ? 1 : -1;

        }
    }
}