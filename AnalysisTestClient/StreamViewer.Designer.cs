namespace Ares.Client.AnalysisTest
{
    partial class StreamViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.btnStart = new System.Windows.Forms.Button();
            this.pbxPicBox = new System.Windows.Forms.PictureBox();
            this.lblDrops = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(294, 507);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pbxPicBox
            // 
            this.pbxPicBox.Location = new System.Drawing.Point(12, 12);
            this.pbxPicBox.Name = "pbxPicBox";
            this.pbxPicBox.Size = new System.Drawing.Size(640, 480);
            this.pbxPicBox.TabIndex = 1;
            this.pbxPicBox.TabStop = false;
            // 
            // lblDrops
            // 
            this.lblDrops.AutoSize = true;
            this.lblDrops.Location = new System.Drawing.Point(432, 507);
            this.lblDrops.Name = "lblDrops";
            this.lblDrops.Size = new System.Drawing.Size(0, 13);
            this.lblDrops.TabIndex = 2;
            // 
            // StreamViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 542);
            this.Controls.Add(this.lblDrops);
            this.Controls.Add(this.pbxPicBox);
            this.Controls.Add(this.btnStart);
            this.Name = "StreamViewer";
            this.Text = "Video Analysis Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.PictureBox pbxPicBox;
        private System.Windows.Forms.Label lblDrops;
    }
}


