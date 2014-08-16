namespace Ares.Server
{
    partial class ColorManagementInterface
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
            this.cmdGetPlayerColor = new System.Windows.Forms.Button();
            this.cmdSetPlayerColor = new System.Windows.Forms.Button();
            this.cmdRefreshPlayerList = new System.Windows.Forms.Button();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.lboxPlayers = new System.Windows.Forms.ListBox();
            this.videoFeed = new System.Windows.Forms.PictureBox();
            this.lblCurrentPlayerColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.videoFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdGetPlayerColor
            // 
            this.cmdGetPlayerColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdGetPlayerColor.Location = new System.Drawing.Point(525, 339);
            this.cmdGetPlayerColor.Name = "cmdGetPlayerColor";
            this.cmdGetPlayerColor.Size = new System.Drawing.Size(75, 26);
            this.cmdGetPlayerColor.TabIndex = 16;
            this.cmdGetPlayerColor.Text = "Get Color";
            this.cmdGetPlayerColor.UseVisualStyleBackColor = true;
            this.cmdGetPlayerColor.Click += new System.EventHandler(this.cmdGetPlayerColor_Click);
            // 
            // cmdSetPlayerColor
            // 
            this.cmdSetPlayerColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSetPlayerColor.Location = new System.Drawing.Point(606, 339);
            this.cmdSetPlayerColor.Name = "cmdSetPlayerColor";
            this.cmdSetPlayerColor.Size = new System.Drawing.Size(75, 26);
            this.cmdSetPlayerColor.TabIndex = 15;
            this.cmdSetPlayerColor.Text = "Set Color";
            this.cmdSetPlayerColor.UseVisualStyleBackColor = true;
            this.cmdSetPlayerColor.Click += new System.EventHandler(this.cmdSetPlayerColor_Click);
            // 
            // cmdRefreshPlayerList
            // 
            this.cmdRefreshPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdRefreshPlayerList.Location = new System.Drawing.Point(6, 339);
            this.cmdRefreshPlayerList.Name = "cmdRefreshPlayerList";
            this.cmdRefreshPlayerList.Size = new System.Drawing.Size(75, 26);
            this.cmdRefreshPlayerList.TabIndex = 14;
            this.cmdRefreshPlayerList.Text = "Refresh";
            this.cmdRefreshPlayerList.UseVisualStyleBackColor = true;
            this.cmdRefreshPlayerList.Click += new System.EventHandler(this.cmdRefreshPlayerList_Click);
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(3, 1);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(44, 13);
            this.lblPlayers.TabIndex = 13;
            this.lblPlayers.Text = "Players:";
            // 
            // lboxPlayers
            // 
            this.lboxPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lboxPlayers.FormattingEnabled = true;
            this.lboxPlayers.Location = new System.Drawing.Point(3, 17);
            this.lboxPlayers.Name = "lboxPlayers";
            this.lboxPlayers.Size = new System.Drawing.Size(276, 316);
            this.lboxPlayers.TabIndex = 12;
            this.lboxPlayers.SelectedValueChanged += new System.EventHandler(this.lboxPlayers_SelectedValueChanged);
            // 
            // videoFeed
            // 
            this.videoFeed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.videoFeed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.videoFeed.Location = new System.Drawing.Point(285, 17);
            this.videoFeed.Name = "videoFeed";
            this.videoFeed.Size = new System.Drawing.Size(396, 316);
            this.videoFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.videoFeed.TabIndex = 11;
            this.videoFeed.TabStop = false;
            // 
            // lblCurrentPlayerColor
            // 
            this.lblCurrentPlayerColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentPlayerColor.Location = new System.Drawing.Point(453, 339);
            this.lblCurrentPlayerColor.Name = "lblCurrentPlayerColor";
            this.lblCurrentPlayerColor.Size = new System.Drawing.Size(66, 26);
            this.lblCurrentPlayerColor.TabIndex = 17;
            // 
            // ColorManagementInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCurrentPlayerColor);
            this.Controls.Add(this.cmdGetPlayerColor);
            this.Controls.Add(this.cmdSetPlayerColor);
            this.Controls.Add(this.cmdRefreshPlayerList);
            this.Controls.Add(this.lblPlayers);
            this.Controls.Add(this.lboxPlayers);
            this.Controls.Add(this.videoFeed);
            this.Name = "ColorManagementInterface";
            this.Size = new System.Drawing.Size(685, 369);
            this.Load += new System.EventHandler(this.ColorManagementInterface_Load);
            ((System.ComponentModel.ISupportInitialize)(this.videoFeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGetPlayerColor;
        private System.Windows.Forms.Button cmdSetPlayerColor;
        private System.Windows.Forms.Button cmdRefreshPlayerList;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.ListBox lboxPlayers;
        private System.Windows.Forms.PictureBox videoFeed;
        private System.Windows.Forms.Label lblCurrentPlayerColor;
    }
}
