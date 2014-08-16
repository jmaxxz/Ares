/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2010  Jmaxxz, Mike McBride, and Kevin Curtis
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
 */
using System.Windows.Forms;

namespace Ares.Client
{
    partial class ClientUi

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
            this.videoOut = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.videoOut)).BeginInit();
            this.SuspendLayout();
            // 
            // videoOut
            // 
            this.videoOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoOut.Location = new System.Drawing.Point(0, 0);
            this.videoOut.Name = "videoOut";
            this.videoOut.Size = new System.Drawing.Size(487, 330);
            this.videoOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.videoOut.TabIndex = 1;
            this.videoOut.TabStop = false;
            this.videoOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClientUi_MouseDown);
            this.videoOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ClientUi_MouseUp);
            // 
            // ClientUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(487, 330);
            this.Controls.Add(this.videoOut);
            this.Name = "ClientUi";
            this.Text = "Ares Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientUi_FormClosing);
            this.Load += new System.EventHandler(this.ClientUi_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ClientUi_KeyUp);
            
            ((System.ComponentModel.ISupportInitialize)(this.videoOut)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox videoOut;
    }
}

