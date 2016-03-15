using System.ComponentModel;

namespace Bluff.VideoWall
{
    [Magic]
    public class WallBuilderConfiguration : INotifyPropertyChanged
    {
        public int Columns { get; set; } = 3;
        public int Rows { get; set; } = 3;
        public double DurationPerFrame { get; set; } = 5;
        public double DurationBetweenFrames { get; set; } = 1;
        public double DelayBeforeFirstZoom { get; set; } = 5;
        public bool Randomize { get; set; } = true;
        public decimal Padding { get; set; } = 0.05m;
        public decimal ZoomOffset { get; set; } = 0.1m;

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}