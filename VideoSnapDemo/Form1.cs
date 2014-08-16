/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2009-2010  Jmaxxz, Mike McBride, and Kevin Curtis
 * 
 * This file is under the the following License
 *          DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
 *                   Version 2, December 2004
 *       Copyright (C) 2004 Sam Hocevar <sam@hocevar.net>
 *
 *       Everyone is permitted to copy and distribute verbatim or modified
 *       copies of this license document, and changing it is allowed as long
 *       as the name is changed.
 *
 *                  DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
 *         TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
 *
 *          0. You just DO WHAT THE FUCK YOU WANT TO.
 * 
 * File: Form1.cs
 * Purpose: A simple GUI for testing the image capture class
 * IMPORTANT: Conversion of image to Bitmap is in the button1_Click method
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.90     curtisk  initial development                Fully implemented
 * 0.95     jmaxxz initial development                Cleaned up prototype, added bitmap stream support
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using VideoSnapDemo;
using Timer = System.Windows.Forms.Timer;
using Ares.Common.Video;
using Ares.Common.Webcam;

namespace SnapShot
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.PictureBox pictureBox1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private ContextMenuStrip videoContext;
        private ToolStripMenuItem saveStreamToolStripMenuItem;
        private SaveFileDialog saveFileDialog;
        private IVideoInput _cam;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            const int VIDEODEVICE = 0; // zero based index of video capture device to use
            const int VIDEOWIDTH = 640; // Depends on video device caps
            const int VIDEOHEIGHT = 480; // Depends on video device caps
            const int VIDEOBITSPERPIXEL = 24; // BitsPerPixel values determined by device

            _cam = new DSCapture(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL);
            _cam.VideoEventHandler += FrameUpdateHandler;
            _cam.Start();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.videoContext = new System.Windows.Forms.ContextMenuStrip();
            this.saveStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.videoContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.videoContext;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // videoContext
            // 
            this.videoContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveStreamToolStripMenuItem});
            this.videoContext.Name = "videoContext";
            this.videoContext.Size = new System.Drawing.Size(139, 26);
            // 
            // saveStreamToolStripMenuItem
            // 
            this.saveStreamToolStripMenuItem.Name = "saveStreamToolStripMenuItem";
            this.saveStreamToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveStreamToolStripMenuItem.Text = "Save Stream";
            this.saveStreamToolStripMenuItem.Click += new System.EventHandler(this.saveStreamToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "DxSnap";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.videoContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private long count = 0;
        private bool save = false;
        private string path;
        private void FrameUpdateHandler(object sender, Frame frame)
        {
            if (InvokeRequired)
            {
                // Execute the same method, but this time on the GUI thread
                BeginInvoke(new ThreadStart(() => FrameUpdateHandler(sender, frame)));
                return;
            }
            pictureBox1.Image = frame.Image;

            if (save)
            {
                pictureBox1.Image.Save(path + count + ".jpg",ImageFormat.Jpeg);
                count++;
            }
            
        }


        private void button1_Click(object sender, System.EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _cam.Dispose();
        }

        private void saveStreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult results = saveFileDialog.ShowDialog();
            if (results == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                save = true;
            }

        }

    }
}
