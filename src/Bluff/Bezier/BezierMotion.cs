using System.Collections.Generic;
using Bluff.Models;

namespace Bluff.Bezier
{
    public class BezierMotion
    {
        public static List<PointInSpace> GetPoints(BezierMotionConfig config)
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