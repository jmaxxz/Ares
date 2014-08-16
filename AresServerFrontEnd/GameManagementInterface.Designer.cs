namespace Ares.Server
{
    partial class GameManagementInterface
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdStop = new System.Windows.Forms.Button();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.lblTimePermatch = new System.Windows.Forms.Label();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.txtTimePermatch = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // cmdStart
            // 
            this.cmdStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStart.Location = new System.Drawing.Point(93, 32);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(75, 23);
            this.cmdStart.TabIndex = 0;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdStop.Enabled = false;
            this.cmdStop.Location = new System.Drawing.Point(174, 32);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(75, 23);
            this.cmdStop.TabIndex = 1;
            this.cmdStop.Text = "Stop";
            this.cmdStop.UseVisualStyleBackColor = true;
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Location = new System.Drawing.Point(3, 37);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(50, 13);
            this.lblTimeLeft.TabIndex = 2;
            this.lblTimeLeft.Text = "Time left:";
            // 
            // lblTimePermatch
            // 
            this.lblTimePermatch.AutoSize = true;
            this.lblTimePermatch.Location = new System.Drawing.Point(3, 6);
            this.lblTimePermatch.Name = "lblTimePermatch";
            this.lblTimePermatch.Size = new System.Drawing.Size(63, 13);
            this.lblTimePermatch.TabIndex = 4;
            this.lblTimePermatch.Text = "Match Time";
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Interval = 500;
            // 
            // txtTimePermatch
            // 
            this.txtTimePermatch.Location = new System.Drawing.Point(72, 3);
            this.txtTimePermatch.Mask = "##:##";
            this.txtTimePermatch.Name = "txtTimePermatch";
            this.txtTimePermatch.Size = new System.Drawing.Size(100, 20);
            this.txtTimePermatch.TabIndex = 5;
            // 
            // GameManagementInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTimePermatch);
            this.Controls.Add(this.lblTimePermatch);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.cmdStop);
            this.Controls.Add(this.cmdStart);
            this.Name = "GameManagementInterface";
            this.Size = new System.Drawing.Size(252, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.Button cmdStop;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Label lblTimePermatch;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.MaskedTextBox txtTimePermatch;
    }
}
