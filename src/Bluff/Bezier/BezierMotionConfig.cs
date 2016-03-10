using Bluff.Models;

namespace Bluff.Bezier
{
    public class BezierMotionConfig
    {
        public int NumberOfTracks;
        public double TotalSeconds
        {
            get
            {
                return ((NumberOfTracks - 1) * SecondsBetweenTracks) + TotalSecondsPerTrack;
            }
        }

        public double TotalSecondsPerTrack;

        public PointInSpace Point1;
        public PointInSpace Point2;
        public PointInSpace Point3;
        public PointInSpace Point4;
        public int StepsPerSecond;
        public double SecondsBetweenTracks;
    }
}