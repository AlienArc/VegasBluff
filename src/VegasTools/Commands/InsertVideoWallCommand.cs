using System.Collections.Generic;
using System.Windows.Forms;
using Sony.Vegas;
using VegasTools.Models;
using VegasTools.VideoWall;

namespace VegasTools.Commands
{
    public static class InsertVideoWallCommand
    {
        public static void Execute(Vegas vegas)
        {
            var configData = new WallBuilderConfiguration();

            if (!GetConfigurationFromUser(configData)) return;

            var wallTracks = WallBuilder.BuildWall(vegas.Project.Video.Width, vegas.Project.Video.Height, configData);

            using (var undo = new UndoBlock("Insert Video Wall"))
            {
                var trackNumber = 0;

                var videoTracks = GetCurrentVideoTracks(vegas);

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
            var configWindow = new WallBuilderConfigurationView();
            configWindow.ConfigData = configData;
            if (configWindow.ShowDialog() != DialogResult.OK)
            {
                return false;
            }
            return true;
        }

        private static List<VideoTrack> GetCurrentVideoTracks(Vegas vegas)
        {
            var videoTracks = new List<VideoTrack>();
            foreach (var track in vegas.Project.Tracks)
            {
                if (track.IsVideo())
                {
                    videoTracks.Add((VideoTrack) track);
                }
            }
            return videoTracks;
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

            foreach (var kf in track.KeyFrames)
            {
                var mkf = SelectOrInsertKeyFrame(videoTrack, kf);
                mkf.Width = (double)kf.Width;
                mkf.Height = (double)kf.Height;
                mkf.PositionX = (double)kf.PanX;
                mkf.PositionY = (double)kf.PanY;
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