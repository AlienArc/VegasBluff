namespace VegasTools.VideoWall
{
    partial class WallBuilderConfigurationView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.NumberOfColumns = new System.Windows.Forms.NumericUpDown();
            this.NumberOfRows = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.DurationBetweenFrames = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.DurationEachFrame = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.DelayBeforeZoom = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RandomizeTracks = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Padding = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.ZoomOffset = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationBetweenFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationEachFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayBeforeZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Padding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "How Many Columns?";
            // 
            // NumberOfColumns
            // 
            this.NumberOfColumns.DecimalPlaces = 1;
            this.NumberOfColumns.Location = new System.Drawing.Point(500, 46);
            this.NumberOfColumns.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.NumberOfColumns.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumberOfColumns.Name = "NumberOfColumns";
            this.NumberOfColumns.Size = new System.Drawing.Size(120, 31);
            this.NumberOfColumns.TabIndex = 1;
            this.NumberOfColumns.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // NumberOfRows
            // 
            this.NumberOfRows.DecimalPlaces = 1;
            this.NumberOfRows.Location = new System.Drawing.Point(500, 96);
            this.NumberOfRows.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.NumberOfRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.NumberOfRows.Name = "NumberOfRows";
            this.NumberOfRows.Size = new System.Drawing.Size(120, 31);
            this.NumberOfRows.TabIndex = 3;
            this.NumberOfRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "How Many Rows?";
            // 
            // DurationBetweenFrames
            // 
            this.DurationBetweenFrames.DecimalPlaces = 1;
            this.DurationBetweenFrames.Location = new System.Drawing.Point(500, 195);
            this.DurationBetweenFrames.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.DurationBetweenFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.DurationBetweenFrames.Name = "DurationBetweenFrames";
            this.DurationBetweenFrames.Size = new System.Drawing.Size(120, 31);
            this.DurationBetweenFrames.TabIndex = 7;
            this.DurationBetweenFrames.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(329, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "How many seconds to transition?";
            // 
            // DurationEachFrame
            // 
            this.DurationEachFrame.DecimalPlaces = 1;
            this.DurationEachFrame.Location = new System.Drawing.Point(500, 145);
            this.DurationEachFrame.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.DurationEachFrame.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.DurationEachFrame.Name = "DurationEachFrame";
            this.DurationEachFrame.Size = new System.Drawing.Size(120, 31);
            this.DurationEachFrame.TabIndex = 5;
            this.DurationEachFrame.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "How many seconds to hold?";
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(552, 475);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(123, 60);
            this.CreateButton.TabIndex = 8;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // DelayBeforeZoom
            // 
            this.DelayBeforeZoom.DecimalPlaces = 1;
            this.DelayBeforeZoom.Location = new System.Drawing.Point(500, 242);
            this.DelayBeforeZoom.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.DelayBeforeZoom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.DelayBeforeZoom.Name = "DelayBeforeZoom";
            this.DelayBeforeZoom.Size = new System.Drawing.Size(120, 31);
            this.DelayBeforeZoom.TabIndex = 10;
            this.DelayBeforeZoom.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Delay before zooming";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(102, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Randomize";
            // 
            // RandomizeTracks
            // 
            this.RandomizeTracks.AutoSize = true;
            this.RandomizeTracks.Location = new System.Drawing.Point(500, 296);
            this.RandomizeTracks.Name = "RandomizeTracks";
            this.RandomizeTracks.Size = new System.Drawing.Size(28, 27);
            this.RandomizeTracks.TabIndex = 11;
            this.RandomizeTracks.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(102, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Padding %";
            // 
            // Padding
            // 
            this.Padding.DecimalPlaces = 2;
            this.Padding.Location = new System.Drawing.Point(500, 352);
            this.Padding.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Padding.Name = "Padding";
            this.Padding.Size = new System.Drawing.Size(120, 31);
            this.Padding.TabIndex = 7;
            this.Padding.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "Zoom offset %";
            // 
            // ZoomOffset
            // 
            this.ZoomOffset.DecimalPlaces = 2;
            this.ZoomOffset.Location = new System.Drawing.Point(500, 399);
            this.ZoomOffset.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ZoomOffset.Name = "ZoomOffset";
            this.ZoomOffset.Size = new System.Drawing.Size(120, 31);
            this.ZoomOffset.TabIndex = 10;
            this.ZoomOffset.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // WallBuilderConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 591);
            this.Controls.Add(this.RandomizeTracks);
            this.Controls.Add(this.ZoomOffset);
            this.Controls.Add(this.DelayBeforeZoom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.Padding);
            this.Controls.Add(this.DurationBetweenFrames);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DurationEachFrame);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumberOfRows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NumberOfColumns);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WallBuilderConfigurationView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Video Wall Setup";
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationBetweenFrames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationEachFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DelayBeforeZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Padding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NumberOfColumns;
        private System.Windows.Forms.NumericUpDown NumberOfRows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown DurationBetweenFrames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown DurationEachFrame;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.NumericUpDown DelayBeforeZoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox RandomizeTracks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Padding;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown ZoomOffset;
    }
}

