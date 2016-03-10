namespace Bluff
{
    partial class AboutBluff
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
            this.CloseButtom = new System.Windows.Forms.Button();
            this.AboutInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CloseButtom
            // 
            this.CloseButtom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButtom.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CloseButtom.Location = new System.Drawing.Point(782, 444);
            this.CloseButtom.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.CloseButtom.Name = "CloseButtom";
            this.CloseButtom.Size = new System.Drawing.Size(150, 44);
            this.CloseButtom.TabIndex = 0;
            this.CloseButtom.Text = "Close";
            this.CloseButtom.UseVisualStyleBackColor = true;
            // 
            // AboutInfo
            // 
            this.AboutInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AboutInfo.BackColor = System.Drawing.SystemColors.Control;
            this.AboutInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AboutInfo.DetectUrls = false;
            this.AboutInfo.Location = new System.Drawing.Point(24, 23);
            this.AboutInfo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.AboutInfo.Name = "AboutInfo";
            this.AboutInfo.ReadOnly = true;
            this.AboutInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.AboutInfo.Size = new System.Drawing.Size(908, 410);
            this.AboutInfo.TabIndex = 1;
            this.AboutInfo.Text = "";
            // 
            // AboutBluff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 512);
            this.Controls.Add(this.AboutInfo);
            this.Controls.Add(this.CloseButtom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBluff";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About Bluff";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButtom;
        private System.Windows.Forms.RichTextBox AboutInfo;
    }
}