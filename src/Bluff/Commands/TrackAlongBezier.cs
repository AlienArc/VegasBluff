using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Bluff.Helpers;
using Sony.Vegas;

namespace Bluff.Commands
{
    public class TrackAlongBezier
    {
        public static void Execute(Vegas vegas)
        {

            var selectedTracks = VegasHelper.GetTracks<VideoTrack>(vegas, 1, onlySelected: true);

            var config = GetConfig(selectedTracks);

            var points = GetPoints(config);

            //long startingTimeStep = (long)(config.TotalSeconds - config.TotalSecondsPerTrack) / (config.NumberOfTracks - 1);
            var width = vegas.Project.Video.Width;
            var height = vegas.Project.Video.Height;

            using (var undo = new UndoBlock("Track Along Bezier"))
            {
                for (var trackIndex = 0; trackIndex < config.NumberOfTracks; trackIndex++)
                {
                    var timeFrame = (long)(trackIndex * config.SecondsBetweenFrames * 24);

                    var selectedTrack = selectedTracks[config.NumberOfTracks - trackIndex - 1];
                    selectedTrack.TrackMotion.MotionKeyframes.Clear();

                    foreach (var point in points)
                    {
                        var mkf = GetOrCreateTrackMotionKeyframe(timeFrame, selectedTrack);
                        mkf.Width = width * point.z;
                        mkf.Height = height * point.z;
                        mkf.PositionX = point.x - (width / 2d);
                        mkf.PositionY = point.y - (height / 2d);

                        timeFrame += (24 / config.StepsPerSecond);
                    }
                } 
            }

        }

        private static TrackMotionKeyframe GetOrCreateTrackMotionKeyframe(long timeFrame, VideoTrack selectedTrack)
        {
            TrackMotionKeyframe mkf = null;
            if (timeFrame == 0)
            {
                mkf = selectedTrack.TrackMotion.MotionKeyframes[0];
            }
            else
            {
                mkf = selectedTrack.TrackMotion.InsertMotionKeyframe(Timecode.FromFrames(timeFrame));
            }
            return mkf;
        }

        private static BezierMotionConfig GetConfig(List<VideoTrack> selectedTracks)
        {
            var config = new BezierMotionConfig();
            config.NumberOfTracks = selectedTracks.Count;
            config.SecondsBetweenFrames = 3d;
            config.TotalSecondsPerTrack = 15;
            config.TotalSeconds = ((selectedTracks.Count - 1) * config.SecondsBetweenFrames) + config.TotalSecondsPerTrack;
            config.StepsPerSecond = 12;
            config.point4 = new PointInSpace();
            config.point4.z = .3;
            config.point4.x = -288;
            config.point4.y = 540;
            config.point3 = new PointInSpace();
            config.point3.x = 206;
            config.point3.y = 331;
            config.point3.z = .3;
            config.point2 = new PointInSpace();
            config.point2.x = 1400;//1050;
            config.point2.y = 225;
            config.point2.z = .3;
            config.point1 = new PointInSpace();
            config.point1.z = .3;
            config.point1.x = 2304;
            config.point1.y = 400;
            return config;
        }

        private static List<PointInSpace> GetPoints(BezierMotionConfig config)
        {
            //List<List<PointInSpace>> trackPoints = new List<List<PointInSpace>>();

            var stepSize = 1 / (config.TotalSecondsPerTrack * config.StepsPerSecond);

            //for (int trackIndex = 0; trackIndex < config.NumberOfTracks; trackIndex++)
            //{			
            var points = new List<PointInSpace>();

            for (double i = 0; i < 1; i += stepSize)
            {
                points.Add(Bezier4(config.point1, config.point2, config.point3, config.point4, i));
            }

            points.Add(config.point4);
            //trackPoints.Add(points);
            //}
            return points;
            //return trackPoints;
        }

        private static PointInSpace Bezier4(PointInSpace p1, PointInSpace p2, PointInSpace p3, PointInSpace p4, double mu)
        {
            double mum1, mum13, mu3;
            PointInSpace p;

            mum1 = 1 - mu;
            mum13 = mum1 * mum1 * mum1;
            mu3 = mu * mu * mu;

            p.x = mum13 * p1.x + 3 * mu * mum1 * mum1 * p2.x + 3 * mu * mu * mum1 * p3.x + mu3 * p4.x;
            p.y = mum13 * p1.y + 3 * mu * mum1 * mum1 * p2.y + 3 * mu * mu * mum1 * p3.y + mu3 * p4.y;
            p.z = mum13 * p1.z + 3 * mu * mum1 * mum1 * p2.z + 3 * mu * mu * mum1 * p3.z + mu3 * p4.z;

            return (p);
        }

        public struct PointInSpace
        {
            public double x;
            public double y;
            public double z;
        }

        public class BezierMotionConfig
        {
            public int NumberOfTracks;
            public double TotalSeconds;
            public double TotalSecondsPerTrack;
            public PointInSpace point1;
            public PointInSpace point2;
            public PointInSpace point3;
            public PointInSpace point4;
            public int StepsPerSecond;
            public double SecondsBetweenFrames;
        }
    }
}