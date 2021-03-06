using System.Collections.Generic;
using System.Windows.Forms;
using Bluff.Helpers;
using Sony.Vegas;
using Bluff.Models;
using Bluff.VideoWall;

namespace Bluff.Commands
{
    public static class InsertVideoWall
    {
        public static void Execute(Vegas vegas)
        {
            var configData = new WallBuilderConfiguration();

            if (!GetConfigurationFromUser(configData)) return;

            var wallTracks = WallBuilder.BuildWall(vegas.Project.Video.Width, vegas.Project.Video.Height, configData);

            using (var undo = new UndoBlock("Insert Video Wall"))
            {
                var trackNumber = 0;

                var videoTracks = VegasHelper.GetTracks<VideoTrack>(vegas); 

                foreach (var track in wallTracks)
                {
                    var videoTrack = SelectOrInsertVideoTrack(vegas, videoTracks, trackNumber);
                    trackNumber += 1;

                    SetTrackKeyFrames(videoTrack, track);
                }
            }
        }

        private static bool GetConfigurationFromUser(WallBuilderConfiguration configData)
        {
            var configWindow = new Views.WallBuilder(configData); 
            var dr = configWindow.ShowDialog();
            return dr.GetValueOrDefault();
        }

        private static VideoTrack SelectOrInsertVideoTrack(Vegas vegas, List<VideoTrack> videoTracks, int trackNumber)
        {
            VideoTrack videoTrack = null;

            if (videoTracks.Count > trackNumber)
            {
                videoTrack = videoTracks[trackNumber];
            }
            else
            {
                videoTrack = new VideoTrack(trackNumber);
                vegas.Project.Tracks.Add(videoTrack);
            }
            return videoTrack;
        }

        private static void SetTrackKeyFrames(VideoTrack videoTrack, TrackInfo track)
        {
            videoTrack.TrackMotion.MotionKeyframes.Clear();
            videoTrack.CompositeMode = CompositeMode.SrcAlpha3D;

            foreach (var kf in track.KeyFrames)
            {
                var mkf = SelectOrInsertKeyFrame(videoTrack, kf);
                //mkf.Width = (double)kf.Width;
                //mkf.Height = (double)kf.Height;
                mkf.PositionX = (double)kf.PanX;
                mkf.PositionY = (double)kf.PanY;
                mkf.PositionZ = (double)kf.PanZ;
            }
        }

        private static TrackMotionKeyframe SelectOrInsertKeyFrame(VideoTrack videoTrack, KeyFrameInfo kf)
        {
            if (kf.Time == 0)
            {
                var mkf = videoTrack.TrackMotion.MotionKeyframes[0];
                if (mkf.Position.FrameCount > 0)
                    mkf.Position = new Timecode((double)kf.Time*1000);
                return mkf;
            }

            return videoTrack.TrackMotion.InsertMotionKeyframe(new Timecode((double)kf.Time * 1000));
        }
    }
}