using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bluff.Bezier
{
    public partial class Configuration : Form
    {
        BezierMotionConfig Config;

        public Configuration(BezierMotionConfig config)
        {
            InitializeComponent();

            Closing += OnClosing;

            Config = config;

            Point1X.Value = (decimal)Config.Point1.X;
            Point1Y.Value = (decimal)Config.Point1.Y;
            Point1Z.Value = (decimal)Config.Point1.Zoom;

            Point2X.Value = (decimal)Config.Point2.X;
            Point2Y.Value = (decimal)Config.Point2.Y;
            Point2Z.Value = (decimal)Config.Point2.Zoom;

            Point3X.Value = (decimal)Config.Point3.X;
            Point3Y.Value = (decimal)Config.Point3.Y;
            Point3Z.Value = (decimal)Config.Point3.Zoom;

            Point4X.Value = (decimal)Config.Point4.X;
            Point4Y.Value = (decimal)Config.Point4.Y;
            Point4Z.Value = (decimal)Config.Point4.Zoom;

        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            Config.Point1.X = (double)Point1X.Value;
            Config.Point1.Y = (double)Point1Y.Value;
            Config.Point1.Zoom = (double)Point1Z.Value;

            Config.Point2.X = (double)Point2X.Value;
            Config.Point2.Y = (double)Point2Y.Value;
            Config.Point2.Zoom = (double)Point2Z.Value;

            Config.Point3.X = (double)Point3X.Value;
            Config.Point3.Y = (double)Point3Y.Value;
            Config.Point3.Zoom = (double)Point3Z.Value;

            Config.Point4.X = (double)Point4X.Value;
            Config.Point4.Y = (double)Point4Y.Value;
            Config.Point4.Zoom = (double)Point4Z.Value;
        }
    }
}
