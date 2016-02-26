namespace VegasTools.VideoWall
{
    public class WallBuilderConfiguration
    {
        public int Columns { get; set; } = 3;
        public int Rows { get; set; } = 3;
        public double DurationPerFrame { get; set; } = 5;
        public double DurationBetweenFrames { get; set; } = 1;

    }
}