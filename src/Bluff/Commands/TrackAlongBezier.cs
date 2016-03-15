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

            var points = BezierMotion.GetPoints(config);

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
    }
}