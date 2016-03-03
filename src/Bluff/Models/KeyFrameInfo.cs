namespace Bluff.Models
{
    public class KeyFrameInfo
    {
        public decimal Time { get; set; }
        public decimal PanX { get; set; }
        public decimal PanY { get; set; }
        public decimal PanZ { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public Sony.Vegas.VideoKeyframeType KeyframeType { get; set; }
    }
}