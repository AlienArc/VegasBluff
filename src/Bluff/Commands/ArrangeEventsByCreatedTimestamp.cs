using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using Bluff.Helpers;
using Bluff.Models;
using Sony.Vegas;

namespace Bluff.Commands
{
    public class ArrangeEventsByCreatedTimestamp
    {
        public static void Execute(Vegas vegas)
        {
            var videoTracks = VegasHelper.GetTracks<VideoTrack>(vegas, 1, 1, true);

            var selectedTrackEvents = VegasHelper.GetTrackEvents(videoTracks);

            var startingPosition = selectedTrackEvents[0].Start;

            var trackEventInfos = new List<TrackEventInfo>();
            foreach (var selectedTrackEvent in selectedTrackEvents)
            {
                trackEventInfos.Add(new TrackEventInfo(selectedTrackEvent));
            }

            //order the list
            trackEventInfos.Sort((info1, info2) => info1.FileTimestamp.CompareTo(info2.FileTimestamp));

            var baseTimeStamp = trackEventInfos[0].FileTimestamp;

            using (var undo = new UndoBlock("Order Events By Name And Time"))
            {
                //update order of the events
                foreach (var selectedTrackEvent in trackEventInfos)
                {
                    var currentPosition = startingPosition +
                                          Timecode.FromMilliseconds(
                                              (selectedTrackEvent.FileTimestamp - baseTimeStamp).TotalMilliseconds);

                    if (selectedTrackEvent.TrackEvent.IsGrouped)
                    {
                        foreach (var groupedTrackEvents in selectedTrackEvent.TrackEvent.Group)
                        {
                            groupedTrackEvents.Start = currentPosition;
                        }
                    }
                    else
                    {
                        selectedTrackEvent.TrackEvent.Start = currentPosition;
                    }
                }
            }
        }
    }
}