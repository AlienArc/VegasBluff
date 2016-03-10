using System;
using System.IO;
using Sony.Vegas;

namespace Bluff.Models
{
    public class TrackEventInfo
    {
        private DateTime? _fileTimeStamp;

        public TrackEvent TrackEvent { get; private set; }

        public DateTime FileTimestamp
        {
            get
            {
                if (_fileTimeStamp == null)
                {
                    var filePath = TrackEvent.ActiveTake.Media.FilePath;
                    _fileTimeStamp = File.GetCreationTime(filePath);
                }

                return _fileTimeStamp.Value;
            }
        }

        public TrackEventInfo(TrackEvent trackEvent)
        {
            TrackEvent = trackEvent;
        }
    }
}