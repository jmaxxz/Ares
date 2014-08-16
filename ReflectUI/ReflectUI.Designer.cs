/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2009  Jmaxxz, Mike McBride, and Kevin Curtis
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
 * File: ReflextUI.cs
 * Purpose: A tree based user control which shows the reflected state of an object
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Fully implemented
 */
namespace Ares.Common.ReflectUI
{
    partial class ReflectUI
    {
#pragma warning disable 649
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;
#pragma warning restore 649

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
            this.ReflectionTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // ReflectionTree
            // 
            this.ReflectionTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReflectionTree.Location = new System.Drawing.Point(0, 0);
            this.ReflectionTree.Name = "ReflectionTree";
            this.ReflectionTree.Size = new System.Drawing.Size(59, 87);
            this.ReflectionTree.TabIndex = 0;
            this.ReflectionTree.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.ReflectionTree_BeforeExpand);
            // 
            // ReflectUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ReflectionTree);
            this.Name = "ReflectUI";
            this.Size = new System.Drawing.Size(59, 87);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView ReflectionTree;
    }
}