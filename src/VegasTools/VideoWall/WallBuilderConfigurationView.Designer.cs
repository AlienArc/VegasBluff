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
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumberOfRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationBetweenFrames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationEachFrame)).BeginInit();
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
            this.NumberOfColumns.Location = new System.Drawing.Point(500, 46);
            this.NumberOfColumns.Name = "NumberOfColumns";
            this.NumberOfColumns.Size = new System.Drawing.Size(120, 31);
            this.NumberOfColumns.TabIndex = 1;
            // 
            // NumberOfRows
            // 
            this.NumberOfRows.Location = new System.Drawing.Point(500, 96);
            this.NumberOfRows.Name = "NumberOfRows";
            this.NumberOfRows.Size = new System.Drawing.Size(120, 31);
            this.NumberOfRows.TabIndex = 3;
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
            this.DurationBetweenFrames.Location = new System.Drawing.Point(500, 195);
            this.DurationBetweenFrames.Name = "DurationBetweenFrames";
            this.DurationBetweenFrames.Size = new System.Drawing.Size(120, 31);
            this.DurationBetweenFrames.TabIndex = 7;
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
            this.DurationEachFrame.Location = new System.Drawing.Point(500, 145);
            this.DurationEachFrame.Name = "DurationEachFrame";
            this.DurationEachFrame.Size = new System.Drawing.Size(120, 31);
            this.DurationEachFrame.TabIndex = 5;
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
            this.CreateButton.Location = new System.Drawing.Point(561, 295);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(123, 60);
            this.CreateButton.TabIndex = 8;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // WallBuilderConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 383);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.DurationBetweenFrames);
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
    }
}

