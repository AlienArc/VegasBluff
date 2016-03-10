using System.Collections.Generic;
using System.Windows.Forms;
using Sony.Vegas;
using Bluff.Helpers;

namespace Bluff.Commands
{
    public static class OrderEventsByNameAndTime
    {
        public static void Execute(Vegas vegas)
        {
            var videoTracks = VegasHelper.GetTracks<VideoTrack>(vegas, 1);
            
            var selectedTrackEvents = VegasHelper.GetTrackEvents(videoTracks);

            var currentPosition = selectedTrackEvents[0].Start;

            //order the list
            selectedTrackEvents.Sort(new TrackEventsNameTimeComparer());

            using (var undo = new UndoBlock("Order Events By Name And Time"))
            {
                //update order of the events
                foreach (var selectedTrackEvent in selectedTrackEvents)
                {
                    if (selectedTrackEvent.IsGrouped)
                    {
                        foreach (var groupedTrackEvents in selectedTrackEvent.Group)
                        {
                            groupedTrackEvents.Start = currentPosition;
                        }
                    }
                    else
                    {
                        selectedTrackEvent.Start = currentPosition;
                    }
                    currentPosition += selectedTrackEvent.Length;
                }
            }
        }
    }
}