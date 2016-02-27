using System;
using System.Collections.Generic;
using Sony.Vegas;
using VegasTools.Models;

namespace VegasTools.VideoWall
{
    public static class WallBuilder
    {
        public static List<TrackInfo> BuildWall(int width, int height, WallBuilderConfiguration configData)
        {
            var delay = (decimal)configData.DelayBeforeFirstZoom;
            var columns = configData.Columns;
            var rows = configData.Rows;
            var durationPerFrame = (decimal)configData.DurationPerFrame;
            var durationBetweenFrames = (decimal)configData.DurationBetweenFrames;
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

            if (configData.Randomize)
            {
                var random = new Random();
                Shuffle(tracks, random);
            }

            var currentTime = delay;
            var paddingScale = (1 - configData.Padding);
            var globalZoomLimit = (1 - configData.ZoomOffset);

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
                        kf.Time = currentTime;
                        kf.PanX = (ti.OffsetX - targetX)*globalZoomLimit;
                        kf.PanY = (ti.OffsetY - targetY)*globalZoomLimit;
                        kf.Width = width*paddingScale*globalZoomLimit;
                        kf.Height = height*paddingScale*globalZoomLimit;
                        kf.KeyframeType = VideoKeyframeType.Smooth;
                        ti.KeyFrames.Add(kf);

                        var easing = 1.05m;
                        kf = new KeyFrameInfo();
                        kf.Time = currentTime + durationPerFrame/2;
                        kf.PanX = (ti.OffsetX - targetX) * globalZoomLimit * easing;
                        kf.PanY = (ti.OffsetY - targetY) * globalZoomLimit * easing;
                        kf.Width = width*paddingScale*globalZoomLimit* easing;
                        kf.Height = height*paddingScale*globalZoomLimit* easing;
                        kf.KeyframeType = VideoKeyframeType.Smooth;
                        ti.KeyFrames.Add(kf);

                        kf = new KeyFrameInfo();
                        kf.Time = currentTime + durationPerFrame;
                        kf.PanX = (ti.OffsetX - targetX)*globalZoomLimit;
                        kf.PanY = (ti.OffsetY - targetY)*globalZoomLimit;
                        kf.Width = width*paddingScale*globalZoomLimit;
                        kf.Height = height*paddingScale*globalZoomLimit;
                        kf.KeyframeType = VideoKeyframeType.Slow;
                        ti.KeyFrames.Add(kf);

                    }

                    currentTime += durationPerFrame;
                }
                else
                {

                    var targetX = 0;
                    var targetY = 0;

                    var baseScale = Math.Min(1m / gridX, 1m / gridY);
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

                        decimal widthDiff = Math.Abs(previousTrack.OffsetX - nextTrack.OffsetX) + width;
                        decimal heightDiff = Math.Abs(previousTrack.OffsetY - nextTrack.OffsetY) + height;
                        var scaleFactor = Math.Min(widthDiff / width, heightDiff / height);
                        baseScale = baseScale * scaleFactor;

                        currentTime += postframeTimeStep = durationBetweenFrames / 2;

                    }

                    if (currentKf == 1 && currentTime != 0)
                    {
                        InsertKeyFrames(width, height, tracks, 0, baseScale, targetX, targetY, paddingScale);
                    }

                    InsertKeyFrames(width, height, tracks, currentTime, baseScale, targetX, targetY, paddingScale);

                    currentTime += postframeTimeStep;
                }
            }

            return tracks;
        }

        private static void InsertKeyFrames(int width, int height, List<TrackInfo> tracks, decimal currentTime, decimal baseScale,
            int targetX, int targetY, decimal paddingScale)
        {
            foreach (var ti in tracks)
            {
                var kf = new KeyFrameInfo();
                kf.Time = currentTime; //DurationPerStop * (currentKF - 1d);
                kf.Width = width*baseScale*paddingScale;
                kf.Height = height*baseScale*paddingScale;
                kf.PanX = (ti.OffsetX - targetX)*baseScale;
                kf.PanY = (ti.OffsetY - targetY)*baseScale;
                kf.KeyframeType = VideoKeyframeType.Slow;
                ti.KeyFrames.Add(kf);
            }
        }

        public static void Shuffle(IList<TrackInfo> list, Random random)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var j = random.Next(i, list.Count);
                var temp = list[j];
                list[j] = list[i];
                list[i] = temp;
                list[i].Number = i + 1;
            }
        }
    }
}