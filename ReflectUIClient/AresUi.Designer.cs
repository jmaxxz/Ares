namespace ReflectUIClient
{
    partial class AresUi
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
            this.components = new System.ComponentModel.Container();
            this.VideoOut = new System.Windows.Forms.PictureBox();
            this.reflectUI1 = new Ares.Common.ReflectUI.ReflectUI();
            this.reflectUiContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rbRaw = new System.Windows.Forms.RadioButton();
            this.ckOverlay = new System.Windows.Forms.CheckBox();
            this.ckPBlobs = new System.Windows.Forms.CheckBox();
            this.ckBlobs = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ckScale = new System.Windows.Forms.CheckBox();
            this.nRed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nGreen = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nBlue = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.pnlSample = new System.Windows.Forms.Panel();
            this.lblDropped = new System.Windows.Forms.Label();
            this.dropRateTimer = new System.Windows.Forms.Timer(this.components);
            this.lblFps = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VideoOut)).BeginInit();
            this.reflectUiContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoOut
            // 
            this.VideoOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoOut.Location = new System.Drawing.Point(226, 12);
            this.VideoOut.Name = "VideoOut";
            this.VideoOut.Size = new System.Drawing.Size(429, 322);
            this.VideoOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.VideoOut.TabIndex = 0;
            this.VideoOut.TabStop = false;
            // 
            // reflectUI1
            // 
            this.reflectUI1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.reflectUI1.ContextMenuStrip = this.reflectUiContext;
            this.reflectUI1.Location = new System.Drawing.Point(13, 13);
            this.reflectUI1.Name = "reflectUI1";
            this.reflectUI1.Size = new System.Drawing.Size(207, 321);
            this.reflectUI1.Subject = null;
            this.reflectUI1.TabIndex = 1;
            // 
            // reflectUiContext
            // 
            this.reflectUiContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.reflectUiContext.Name = "reflectUiContext";
            this.reflectUiContext.Size = new System.Drawing.Size(114, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItemClick);
            // 
            // rbRaw
            // 
            this.rbRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbRaw.AutoSize = true;
            this.rbRaw.Checked = true;
            this.rbRaw.Location = new System.Drawing.Point(13, 357);
            this.rbRaw.Name = "rbRaw";
            this.rbRaw.Size = new System.Drawing.Size(77, 17);
            this.rbRaw.TabIndex = 2;
            this.rbRaw.TabStop = true;
            this.rbRaw.Text = "Raw Video";
            this.rbRaw.UseVisualStyleBackColor = true;
            // 
            // ckOverlay
            // 
            this.ckOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckOverlay.AutoSize = true;
            this.ckOverlay.Checked = true;
            this.ckOverlay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckOverlay.Location = new System.Drawing.Point(97, 357);
            this.ckOverlay.Name = "ckOverlay";
            this.ckOverlay.Size = new System.Drawing.Size(62, 17);
            this.ckOverlay.TabIndex = 5;
            this.ckOverlay.Text = "Overlay";
            this.ckOverlay.UseVisualStyleBackColor = true;
            // 
            // ckPBlobs
            // 
            this.ckPBlobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckPBlobs.AutoSize = true;
            this.ckPBlobs.Location = new System.Drawing.Point(97, 380);
            this.ckPBlobs.Name = "ckPBlobs";
            this.ckPBlobs.Size = new System.Drawing.Size(84, 17);
            this.ckPBlobs.TabIndex = 6;
            this.ckPBlobs.Text = "Player Blobs";
            this.ckPBlobs.UseVisualStyleBackColor = true;
            // 
            // ckBlobs
            // 
            this.ckBlobs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckBlobs.AutoSize = true;
            this.ckBlobs.Location = new System.Drawing.Point(97, 403);
            this.ckBlobs.Name = "ckBlobs";
            this.ckBlobs.Size = new System.Drawing.Size(52, 17);
            this.ckBlobs.TabIndex = 6;
            this.ckBlobs.Text = "Blobs";
            this.ckBlobs.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "H";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "S";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "B";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(580, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Add Player";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ckScale
            // 
            this.ckScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ckScale.AutoSize = true;
            this.ckScale.Checked = true;
            this.ckScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckScale.Location = new System.Drawing.Point(97, 426);
            this.ckScale.Name = "ckScale";
            this.ckScale.Size = new System.Drawing.Size(53, 17);
            this.ckScale.TabIndex = 16;
            this.ckScale.Text = "Scale";
            this.ckScale.UseVisualStyleBackColor = true;
            this.ckScale.CheckedChanged += new System.EventHandler(this.ckScale_CheckedChanged);
            // 
            // nRed
            // 
            this.nRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nRed.Location = new System.Drawing.Point(414, 416);
            this.nRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nRed.Name = "nRed";
            this.nRed.Size = new System.Drawing.Size(46, 20);
            this.nRed.TabIndex = 17;
            this.nRed.ValueChanged += new System.EventHandler(this.nGreen_ValueChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(414, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "R";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(466, 400);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "G";
            // 
            // nGreen
            // 
            this.nGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nGreen.Location = new System.Drawing.Point(466, 416);
            this.nGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nGreen.Name = "nGreen";
            this.nGreen.Size = new System.Drawing.Size(46, 20);
            this.nGreen.TabIndex = 19;
            this.nGreen.ValueChanged += new System.EventHandler(this.nGreen_ValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(518, 400);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "B";
            // 
            // nBlue
            // 
            this.nBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nBlue.Location = new System.Drawing.Point(518, 416);
            this.nBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nBlue.Name = "nBlue";
            this.nBlue.Size = new System.Drawing.Size(46, 20);
            this.nBlue.TabIndex = 21;
            this.nBlue.ValueChanged += new System.EventHandler(this.nGreen_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(417, 367);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(414, 351);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Name";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(580, 390);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Get Color";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown4.Location = new System.Drawing.Point(206, 343);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(62, 20);
            this.numericUpDown4.TabIndex = 26;
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown5.DecimalPlaces = 3;
            this.numericUpDown5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown5.Location = new System.Drawing.Point(205, 367);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown5.TabIndex = 27;
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numericUpDown6.DecimalPlaces = 3;
            this.numericUpDown6.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown6.Location = new System.Drawing.Point(205, 393);
            this.numericUpDown6.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(63, 20);
            this.numericUpDown6.TabIndex = 28;
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // pnlSample
            // 
            this.pnlSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSample.Location = new System.Drawing.Point(580, 345);
            this.pnlSample.Name = "pnlSample";
            this.pnlSample.Size = new System.Drawing.Size(75, 36);
            this.pnlSample.TabIndex = 30;
            // 
            // lblDropped
            // 
            this.lblDropped.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDropped.AutoSize = true;
            this.lblDropped.Location = new System.Drawing.Point(186, 424);
            this.lblDropped.Name = "lblDropped";
            this.lblDropped.Size = new System.Drawing.Size(62, 13);
            this.lblDropped.TabIndex = 31;
            this.lblDropped.Text = "Drop Rate: ";
            // 
            // dropRateTimer
            // 
            this.dropRateTimer.Enabled = true;
            this.dropRateTimer.Interval = 1000;
            this.dropRateTimer.Tick += new System.EventHandler(this.dropRateTimer_Tick);
            // 
            // lblFps
            // 
            this.lblFps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFps.AutoSize = true;
            this.lblFps.Location = new System.Drawing.Point(275, 349);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(30, 13);
            this.lblFps.TabIndex = 32;
            this.lblFps.Text = "FPS:";
            // 
            // AresUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 448);
            this.Controls.Add(this.lblFps);
            this.Controls.Add(this.lblDropped);
            this.Controls.Add(this.pnlSample);
            this.Controls.Add(this.numericUpDown6);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nBlue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nGreen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nRed);
            this.Controls.Add(this.ckScale);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckBlobs);
            this.Controls.Add(this.ckPBlobs);
            this.Controls.Add(this.ckOverlay);
            this.Controls.Add(this.rbRaw);
            this.Controls.Add(this.reflectUI1);
            this.Controls.Add(this.VideoOut);
            this.Name = "AresUi";
            this.Text = "Ares";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AresUi_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AresUi_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.VideoOut)).EndInit();
            this.reflectUiContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox VideoOut;
        private Ares.Common.ReflectUI.ReflectUI reflectUI1;
        private System.Windows.Forms.ContextMenuStrip reflectUiContext;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbRaw;
        private System.Windows.Forms.CheckBox ckOverlay;
        private System.Windows.Forms.CheckBox ckPBlobs;
        private System.Windows.Forms.CheckBox ckBlobs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ckScale;
        private System.Windows.Forms.NumericUpDown nRed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nGreen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nBlue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Panel pnlSample;
        private System.Windows.Forms.Label lblDropped;
        private System.Windows.Forms.Timer dropRateTimer;
        private System.Windows.Forms.Label lblFps;
    }
}

