using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Bluff.Bezier;
using Bluff.Helpers;
using Bluff.Models;
using Sony.Vegas;

namespace Bluff.Commands
{
    public class TrackAlongBezier
    {
        public static void Execute(Vegas vegas)
        {

            var selectedTracks = VegasHelper.GetTracks<VideoTrack>(vegas, 1, onlySelected: true);
            var framerate = (int)Math.Round(vegas.Project.Video.FrameRate, 0, MidpointRounding.AwayFromZero);

            var config = GetConfig(selectedTracks, framerate);

            var points = GetPoints(config);

            var startingFrame = vegas.Transport.CursorPosition.FrameCount;

            var width = vegas.Project.Video.Width;
            var height = vegas.Project.Video.Height;

            var framesPerStep = (framerate / config.StepsPerSecond);

            using (var undo = new UndoBlock("Track Along Bezier"))
            {
                for (var trackIndex = 0; trackIndex < config.NumberOfTracks; trackIndex++)
                {
                    var currentFrame = startingFrame + (long)(trackIndex * config.SecondsBetweenTracks * 24);

                    var selectedTrack = selectedTracks[config.NumberOfTracks - trackIndex - 1];
                    selectedTrack.TrackMotion.MotionKeyframes.Clear();

                    foreach (var point in points)
                    {
                        SetTrackMotionKeyFrame(currentFrame, selectedTrack, width, point, height);

                        currentFrame += framesPerStep;
                    }
                } 
            }

        }

        private static void SetTrackMotionKeyFrame(long currentFrame, VideoTrack selectedTrack, int width, PointInSpace point,
            int height)
        {
            var mkf = GetOrCreateTrackMotionKeyframe(currentFrame, selectedTrack);
            mkf.Width = width*point.Zoom;
            mkf.Height = height*point.Zoom;
            mkf.PositionX = point.X - (width/2d);
            mkf.PositionY = point.Y - (height/2d);
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

        private static BezierMotionConfig GetConfig(List<VideoTrack> selectedTracks, int frameRate)
        {
            var config = new BezierMotionConfig();
            config.NumberOfTracks = selectedTracks.Count;
            config.SecondsBetweenTracks = 3d;
            config.TotalSecondsPerTrack = 15;
            
            config.StepsPerSecond = frameRate;
            config.Point4 = new PointInSpace();
            config.Point4.Zoom = .3;
            config.Point4.X = -288;
            config.Point4.Y = 540;
            config.Point3 = new PointInSpace();
            config.Point3.X = 206;
            config.Point3.Y = 331;
            config.Point3.Zoom = .3;
            config.Point2 = new PointInSpace();
            config.Point2.X = 1400;//1050;
            config.Point2.Y = 225;
            config.Point2.Zoom = .3;
            config.Point1 = new PointInSpace();
            config.Point1.Zoom = .3;
            config.Point1.X = 2304;
            config.Point1.Y = 400;
            
            var cfgView = new Configuration(config);
            cfgView.ShowDialog();

            return config;
        }

        private static List<PointInSpace> GetPoints(BezierMotionConfig config)
        {

            var stepSize = 1 / (config.TotalSecondsPerTrack * config.StepsPerSecond);

            var points = new List<PointInSpace>();

            for (double i = 0; i < 1; i += stepSize)
            {
                points.Add(Bezier4(config.Point1, config.Point2, config.Point3, config.Point4, i));
            }

            points.Add(config.Point4);

            return points;

        }

        private static PointInSpace Bezier4(PointInSpace point1, PointInSpace point2, PointInSpace point3, PointInSpace point4, double mu)
        {
            PointInSpace p;

            var mum1 = 1 - mu;
            var mum13 = mum1 * mum1 * mum1;
            var mu3 = mu * mu * mu;

            p.X = mum13 * point1.X + 3 * mu * mum1 * mum1 * point2.X + 3 * mu * mu * mum1 * point3.X + mu3 * point4.X;
            p.Y = mum13 * point1.Y + 3 * mu * mum1 * mum1 * point2.Y + 3 * mu * mu * mum1 * point3.Y + mu3 * point4.Y;
            p.Zoom = mum13 * point1.Zoom + 3 * mu * mum1 * mum1 * point2.Zoom + 3 * mu * mu * mum1 * point3.Zoom + mu3 * point4.Zoom;

            return (p);
        }

    }
}