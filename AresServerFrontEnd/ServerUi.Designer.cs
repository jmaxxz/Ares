namespace Ares.Server
{
    partial class ServerUi
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabServerInformation = new System.Windows.Forms.TabPage();
            this.txtBoxEndpoints = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPlayerColors = new System.Windows.Forms.TabPage();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.tabGameManager = new System.Windows.Forms.TabPage();
            this.colorManagementInterface = new Ares.Server.ColorManagementInterface();
            this.consoleInterface = new Ares.Server.ConsoleInterface();
            this.gameManagementInterface = new Ares.Server.GameManagementInterface();
            this.tabControl.SuspendLayout();
            this.tabServerInformation.SuspendLayout();
            this.tabPlayerColors.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.tabGameManager.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabServerInformation);
            this.tabControl.Controls.Add(this.tabPlayerColors);
            this.tabControl.Controls.Add(this.tabGameManager);
            this.tabControl.Controls.Add(this.tabConsole);
            this.tabControl.Location = new System.Drawing.Point(2, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(689, 396);
            this.tabControl.TabIndex = 4;
            // 
            // tabServerInformation
            // 
            this.tabServerInformation.Controls.Add(this.txtBoxEndpoints);
            this.tabServerInformation.Controls.Add(this.label1);
            this.tabServerInformation.Location = new System.Drawing.Point(4, 22);
            this.tabServerInformation.Name = "tabServerInformation";
            this.tabServerInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabServerInformation.Size = new System.Drawing.Size(681, 370);
            this.tabServerInformation.TabIndex = 1;
            this.tabServerInformation.Text = "Server Information";
            this.tabServerInformation.UseVisualStyleBackColor = true;
            // 
            // txtBoxEndpoints
            // 
            this.txtBoxEndpoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtBoxEndpoints.Location = new System.Drawing.Point(3, 19);
            this.txtBoxEndpoints.Name = "txtBoxEndpoints";
            this.txtBoxEndpoints.ReadOnly = true;
            this.txtBoxEndpoints.Size = new System.Drawing.Size(359, 345);
            this.txtBoxEndpoints.TabIndex = 2;
            this.txtBoxEndpoints.Text = "";
            this.txtBoxEndpoints.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Endpoints:";
            // 
            // tabPlayerColors
            // 
            this.tabPlayerColors.Controls.Add(this.colorManagementInterface);
            this.tabPlayerColors.Location = new System.Drawing.Point(4, 22);
            this.tabPlayerColors.Name = "tabPlayerColors";
            this.tabPlayerColors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlayerColors.Size = new System.Drawing.Size(681, 370);
            this.tabPlayerColors.TabIndex = 0;
            this.tabPlayerColors.Text = "Color Management";
            this.tabPlayerColors.UseVisualStyleBackColor = true;
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.consoleInterface);
            this.tabConsole.Location = new System.Drawing.Point(4, 22);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Size = new System.Drawing.Size(681, 370);
            this.tabConsole.TabIndex = 2;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // tabGameManager
            // 
            this.tabGameManager.Controls.Add(this.gameManagementInterface);
            this.tabGameManager.Location = new System.Drawing.Point(4, 22);
            this.tabGameManager.Name = "tabGameManager";
            this.tabGameManager.Size = new System.Drawing.Size(681, 370);
            this.tabGameManager.TabIndex = 3;
            this.tabGameManager.Text = "Game Management";
            this.tabGameManager.UseVisualStyleBackColor = true;
            // 
            // colorManagementInterface
            // 
            this.colorManagementInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorManagementInterface.Location = new System.Drawing.Point(3, 3);
            this.colorManagementInterface.Name = "colorManagementInterface";
            this.colorManagementInterface.PlayerManagementServer = null;
            this.colorManagementInterface.Size = new System.Drawing.Size(675, 364);
            this.colorManagementInterface.TabIndex = 0;
            // 
            // consoleInterface
            // 
            this.consoleInterface.BackingConsole = null;
            this.consoleInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consoleInterface.Location = new System.Drawing.Point(0, 0);
            this.consoleInterface.Name = "consoleInterface";
            this.consoleInterface.Size = new System.Drawing.Size(681, 370);
            this.consoleInterface.TabIndex = 0;
            // 
            // gameManagementInterface
            // 
            this.gameManagementInterface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameManagementInterface.Location = new System.Drawing.Point(0, 0);
            this.gameManagementInterface.Name = "gameManagementInterface";
            this.gameManagementInterface.Size = new System.Drawing.Size(681, 370);
            this.gameManagementInterface.TabIndex = 0;
            // 
            // ServerUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 400);
            this.Controls.Add(this.tabControl);
            this.Name = "ServerUi";
            this.Text = "ServerUi";
            this.Load += new System.EventHandler(this.ServerUi_Load);
            this.tabControl.ResumeLayout(false);
            this.tabServerInformation.ResumeLayout(false);
            this.tabServerInformation.PerformLayout();
            this.tabPlayerColors.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.tabGameManager.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabServerInformation;
        private System.Windows.Forms.TabPage tabPlayerColors;
        private System.Windows.Forms.RichTextBox txtBoxEndpoints;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabConsole;
        private ColorManagementInterface colorManagementInterface;
        private ConsoleInterface consoleInterface;
        private System.Windows.Forms.TabPage tabGameManager;
        private GameManagementInterface gameManagementInterface;

    }
}