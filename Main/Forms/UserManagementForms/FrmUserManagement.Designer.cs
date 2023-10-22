﻿
namespace Main.Forms.UserManagementForms
{
    partial class FrmUserManagement
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
            this.components = new System.ComponentModel.Container();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.menuStripUserManagement = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripUserManagement = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemUserCRUDControl = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemUserActivityLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripUserManagement.SuspendLayout();
            this.contextMenuStripUserManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 35);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1220, 828);
            this.panelContainer.TabIndex = 51;
            // 
            // menuStripUserManagement
            // 
            this.menuStripUserManagement.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripUserManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStripUserManagement.Location = new System.Drawing.Point(0, 0);
            this.menuStripUserManagement.Name = "menuStripUserManagement";
            this.menuStripUserManagement.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStripUserManagement.Size = new System.Drawing.Size(1220, 35);
            this.menuStripUserManagement.TabIndex = 52;
            this.menuStripUserManagement.Text = "UserManagementMenuStrip";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDown = this.contextMenuStripUserManagement;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 29);
            this.toolStripMenuItem1.Text = "User";
            // 
            // contextMenuStripUserManagement
            // 
            this.contextMenuStripUserManagement.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripUserManagement.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemUserCRUDControl,
            this.toolStripMenuItemUserActivityLogs});
            this.contextMenuStripUserManagement.Name = "contextMenuStripUserManagement";
            this.contextMenuStripUserManagement.Size = new System.Drawing.Size(222, 68);
            this.contextMenuStripUserManagement.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripUserManagement_ItemClicked);
            // 
            // toolStripMenuItemUserCRUDControl
            // 
            this.toolStripMenuItemUserCRUDControl.Name = "toolStripMenuItemUserCRUDControl";
            this.toolStripMenuItemUserCRUDControl.Size = new System.Drawing.Size(221, 32);
            this.toolStripMenuItemUserCRUDControl.Text = "User Add/Edit";
            // 
            // toolStripMenuItemUserActivityLogs
            // 
            this.toolStripMenuItemUserActivityLogs.Name = "toolStripMenuItemUserActivityLogs";
            this.toolStripMenuItemUserActivityLogs.Size = new System.Drawing.Size(221, 32);
            this.toolStripMenuItemUserActivityLogs.Text = "User Activity logs";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 29);
            // 
            // FrmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 863);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.menuStripUserManagement);
            this.MainMenuStrip = this.menuStripUserManagement;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmUserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUser";
            this.menuStripUserManagement.ResumeLayout(false);
            this.menuStripUserManagement.PerformLayout();
            this.contextMenuStripUserManagement.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.MenuStrip menuStripUserManagement;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripUserManagement;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUserCRUDControl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUserActivityLogs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}