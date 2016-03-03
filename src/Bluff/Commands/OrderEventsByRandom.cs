using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sony.Vegas;
using Bluff.Helpers;

namespace Bluff.Commands
{
    public static class OrderEventsByRandom
    {
        public static void Execute(Vegas vegas)
        {
            var videoTracks = VegasHelper.GetTracks<VideoTrack>(vegas, 1);

            var selectedTrackEvents = VegasHelper.GetSelectedTrackEvents(videoTracks);

            var currentPosition = selectedTrackEvents[0].Start;

            //order the list
            ListHelpers.Shuffle(selectedTrackEvents, new Random());

            using (var undo = new UndoBlock("Randomize Events"))
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