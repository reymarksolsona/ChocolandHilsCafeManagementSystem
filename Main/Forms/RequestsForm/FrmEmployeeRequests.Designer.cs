
namespace Main.Forms.RequestsForm
{
    partial class FrmEmployeeRequests
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
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.CashAdvanceMenus = new System.Windows.Forms.ToolStripMenuItem();
            this.CMenuCashAdvance = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RequestCashAdvanceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CashAdvanceApprovalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RequestsMainPanel = new System.Windows.Forms.Panel();
            this.MainMenuStrip.SuspendLayout();
            this.CMenuCashAdvance.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CashAdvanceMenus,
            this.leaveToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(1069, 24);
            this.MainMenuStrip.TabIndex = 0;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // CashAdvanceMenus
            // 
            this.CashAdvanceMenus.DropDown = this.CMenuCashAdvance;
            this.CashAdvanceMenus.Name = "CashAdvanceMenus";
            this.CashAdvanceMenus.Size = new System.Drawing.Size(94, 20);
            this.CashAdvanceMenus.Text = "Cash Advance";
            // 
            // CMenuCashAdvance
            // 
            this.CMenuCashAdvance.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RequestCashAdvanceMenuItem,
            this.CashAdvanceApprovalMenuItem});
            this.CMenuCashAdvance.Name = "CMenuCashAdvance";
            this.CMenuCashAdvance.OwnerItem = this.CashAdvanceMenus;
            this.CMenuCashAdvance.Size = new System.Drawing.Size(197, 48);
            this.CMenuCashAdvance.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.CMenuCashAdvance_ItemClicked);
            // 
            // RequestCashAdvanceMenuItem
            // 
            this.RequestCashAdvanceMenuItem.Name = "RequestCashAdvanceMenuItem";
            this.RequestCashAdvanceMenuItem.Size = new System.Drawing.Size(196, 22);
            this.RequestCashAdvanceMenuItem.Text = "Request Cash advance";
            // 
            // CashAdvanceApprovalMenuItem
            // 
            this.CashAdvanceApprovalMenuItem.Name = "CashAdvanceApprovalMenuItem";
            this.CashAdvanceApprovalMenuItem.Size = new System.Drawing.Size(196, 22);
            this.CashAdvanceApprovalMenuItem.Text = "Cash advance approval";
            // 
            // leaveToolStripMenuItem
            // 
            this.leaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requestLeaveToolStripMenuItem,
            this.approveLeaveToolStripMenuItem});
            this.leaveToolStripMenuItem.Name = "leaveToolStripMenuItem";
            this.leaveToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.leaveToolStripMenuItem.Text = "Leave";
            // 
            // requestLeaveToolStripMenuItem
            // 
            this.requestLeaveToolStripMenuItem.Name = "requestLeaveToolStripMenuItem";
            this.requestLeaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.requestLeaveToolStripMenuItem.Text = "Request Leave";
            this.requestLeaveToolStripMenuItem.Click += new System.EventHandler(this.requestLeaveToolStripMenuItem_Click);
            // 
            // approveLeaveToolStripMenuItem
            // 
            this.approveLeaveToolStripMenuItem.Name = "approveLeaveToolStripMenuItem";
            this.approveLeaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.approveLeaveToolStripMenuItem.Text = "Approve Leave";
            this.approveLeaveToolStripMenuItem.Click += new System.EventHandler(this.approveLeaveToolStripMenuItem_Click);
            // 
            // RequestsMainPanel
            // 
            this.RequestsMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestsMainPanel.Location = new System.Drawing.Point(0, 24);
            this.RequestsMainPanel.Name = "RequestsMainPanel";
            this.RequestsMainPanel.Size = new System.Drawing.Size(1069, 607);
            this.RequestsMainPanel.TabIndex = 1;
            // 
            // FrmEmployeeRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 631);
            this.Controls.Add(this.RequestsMainPanel);
            this.Controls.Add(this.MainMenuStrip);
            this.Name = "FrmEmployeeRequests";
            this.Text = "Employee requests";
            this.Load += new System.EventHandler(this.FrmEmployeeRequests_Load);
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.CMenuCashAdvance.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem CashAdvanceMenus;
        private System.Windows.Forms.ContextMenuStrip CMenuCashAdvance;
        private System.Windows.Forms.ToolStripMenuItem RequestCashAdvanceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CashAdvanceApprovalMenuItem;
        private System.Windows.Forms.Panel RequestsMainPanel;
        private System.Windows.Forms.ToolStripMenuItem leaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestLeaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem approveLeaveToolStripMenuItem;
    }
}