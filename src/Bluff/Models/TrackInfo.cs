using System.Collections.Generic;

namespace Bluff.Models
{
    public class TrackInfo
    {
        public int Number;
        public int OffsetX;
        public int OffsetY;

        public List<KeyFrameInfo> KeyFrames;

        public TrackInfo()
        {
            KeyFrames = new List<KeyFrameInfo>();
        }
    }
}