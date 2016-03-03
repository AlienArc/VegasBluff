using System;
using System.Windows.Forms;

namespace Bluff.VideoWall
{
    public partial class WallBuilderConfigurationView : Form
    {
        private WallBuilderConfiguration _configData;

        public WallBuilderConfiguration ConfigData
        {
            get { return _configData; }
            set
            {
                _configData = value;
                NumberOfColumns.Value = _configData.Columns;
                NumberOfRows.Value = _configData.Rows;

                DurationEachFrame.Value = (decimal)_configData.DurationPerFrame;
                DurationBetweenFrames.Value = (decimal)_configData.DurationBetweenFrames;
                DelayBeforeZoom.Value = (decimal)_configData.DelayBeforeFirstZoom;
                RandomizeTracks.Checked = _configData.Randomize;
                Padding.Value = _configData.Padding;
                ZoomOffset.Value = _configData.ZoomOffset;
            }
        }

        public WallBuilderConfigurationView()
        {
            InitializeComponent();
            ConfigData = new WallBuilderConfiguration();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            ConfigData.Columns = (int)NumberOfColumns.Value;
            ConfigData.Rows = (int)NumberOfRows.Value;
            ConfigData.DurationPerFrame = (double)DurationEachFrame.Value;
            ConfigData.DurationBetweenFrames = (double)DurationBetweenFrames.Value;
            ConfigData.DelayBeforeFirstZoom = (double)DelayBeforeZoom.Value;
            ConfigData.Randomize = RandomizeTracks.Checked;
            ConfigData.Padding = Padding.Value;
            ConfigData.ZoomOffset = ZoomOffset.Value;

            DialogResult = DialogResult.OK;
            Hide();
        }
    }
}
