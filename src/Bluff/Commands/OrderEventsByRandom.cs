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

            var selectedTracks = new List<VideoTrack>();
            foreach (var track in vegas.Project.Tracks)
            {
                if (track.IsVideo())
                {
                    selectedTracks.Add((VideoTrack)track);
                }
            }

            if (selectedTracks.Count == 0)
            {
                MessageBox.Show("Must have video tracks");
                return;
            }

            var selectedTrackEvents = new List<TrackEvent>();

            foreach (var selectedTrack in selectedTracks)
            {
                foreach (var trackEvent in selectedTrack.Events)
                {
                    if (trackEvent.Selected)
                    {
                        selectedTrackEvents.Add(trackEvent);
                    }
                }
            }

            if (selectedTrackEvents.Count == 0)
            {
                MessageBox.Show("Must have events selected");
                return;
            }

            var startTime = selectedTrackEvents[0].Start;

            //order the list
            ListHelpers.Shuffle(selectedTrackEvents, new Random());

            using (var undo = new UndoBlock("Order Events By Name And Time"))
            {
                //update order of the events
                foreach (var selectedTrackEvent in selectedTrackEvents)
                {
                    if (selectedTrackEvent.IsGrouped)
                    {
                        foreach (var groupedTrackEvents in selectedTrackEvent.Group)
                        {
                            groupedTrackEvents.Start = startTime;
                        }
                    }
                    else
                    {
                        selectedTrackEvent.Start = startTime;
                    }
                    startTime += selectedTrackEvent.Length;
                }
            }
        }


    }
}