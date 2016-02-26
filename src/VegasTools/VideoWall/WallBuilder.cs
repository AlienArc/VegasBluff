using System;
using System.Collections.Generic;
using VegasTools.Models;

namespace VegasTools.VideoWall
{
    public static class WallBuilder
    {
        public static List<TrackInfo> BuildWall(int width, int height, WallBuilderConfiguration configData)
        {
            int columns = configData.Columns;
            int rows = configData.Rows;
            double durationPerFrame = configData.DurationPerFrame;
            double durationBetweenFrames = configData.DurationBetweenFrames;
            var padding = 100;

            var totalCells = columns * rows;
            //var Duration = totalCells * durationPerFrame + totalCells * durationBetweenFrames + durationBetweenFrames;

            var gridX = columns;
            var gridY = rows;

            var maxWidth = width * gridX;
            var maxHeight = height * gridY;

            var tracks = new List<TrackInfo>();

            for (var x = 0; x < gridX; x++)
            {
                for (var y = 0; y < gridY; y++)
                {
                    var idx = x * gridX + y;
                    var ti = new TrackInfo();
                    ti.Number = idx + 1;
                    ti.OffsetX = (width * x);
                    ti.OffsetY = (height * y);
                    tracks.Add(ti);
                }
            }

            var totalKeyFrames = totalCells * 2 + 1;

            var centerX = maxWidth / 2;
            var centerY = maxHeight / 2;

            var random = new Random();
            Shuffle(tracks, random);

            double currentTime = 0;

            for (var currentKf = 1; currentKf < totalKeyFrames + 1; currentKf++)
            {
                if (currentKf != 0 && currentKf % 2 == 0)
                {
                    //this is a closeup
                    var currentCell = currentKf / 2;
                    var currentTrack = tracks[currentCell - 1];
                    var targetX = currentTrack.OffsetX;
                    var targetY = currentTrack.OffsetY;

                    foreach (var ti in tracks)
                    {

                        var kf = new KeyFrameInfo();
                        kf.time = currentTime;
                        kf.PanX = ti.OffsetX - targetX;
                        kf.PanY = ti.OffsetY - targetY;
                        kf.Width = width;
                        kf.Height = height;
                        ti.KeyFrames.Add(kf);

                        kf = new KeyFrameInfo();
                        kf.time = currentTime + durationPerFrame;
                        kf.PanX = ti.OffsetX - targetX;
                        kf.PanY = ti.OffsetY - targetY;
                        kf.Width = width;
                        kf.Height = height;
                        ti.KeyFrames.Add(kf);

                    }

                    currentTime += durationPerFrame;
                }
                else
                {

                    var targetX = 0;
                    var targetY = 0;

                    var baseScale = Math.Min(1d / gridX, 1d / gridY);
                    var postframeTimeStep = durationBetweenFrames;

                    if (currentKf < 2 || currentKf > totalKeyFrames - 2)
                    {
                        //this is a full shot

                        targetX = centerX - width / 2;
                        targetY = centerY - height / 2;

                    }
                    else
                    {
                        //transitional shot

                        var previousCell = (currentKf - 1) / 2;
                        var nextCell = (currentKf + 1) / 2;
                        var previousTrack = tracks[previousCell - 1];
                        var nextTrack = tracks[nextCell - 1];

                        targetX = previousTrack.OffsetX - (previousTrack.OffsetX - nextTrack.OffsetX) / 2;
                        targetY = previousTrack.OffsetY - (previousTrack.OffsetY - nextTrack.OffsetY) / 2;

                        double widthDiff = Math.Abs(previousTrack.OffsetX - nextTrack.OffsetX) + width;
                        double heightDiff = Math.Abs(previousTrack.OffsetY - nextTrack.OffsetY) + height;
                        var scaleFactor = Math.Min(widthDiff / width, heightDiff / height);
                        baseScale = baseScale * scaleFactor;

                        currentTime += postframeTimeStep = durationBetweenFrames / 2;

                    }


                    foreach (var ti in tracks)
                    {
                        var kf = new KeyFrameInfo();
                        kf.time = currentTime; //DurationPerStop * (currentKF - 1d);
                        kf.Width = width * baseScale;
                        kf.Height = height * baseScale;
                        kf.PanX = (ti.OffsetX - targetX) * baseScale;
                        kf.PanY = (ti.OffsetY - targetY) * baseScale;
                        ti.KeyFrames.Add(kf);
                    }

                    currentTime += postframeTimeStep;
                }
            }

            return tracks;
        }

        public static void Shuffle<T>(IList<T> list, Random random)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var j = random.Next(i, list.Count);
                var temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }
        }
    }
}