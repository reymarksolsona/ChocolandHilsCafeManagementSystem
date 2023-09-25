
namespace Main.Forms.PayrollForms
{
    partial class FrmPayroll
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
            this.menuStripPayroll = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CMStripPayroll = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TStripMenuItemGenerate = new System.Windows.Forms.ToolStripMenuItem();
            this.TStripMenuItemHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.TStripMenuItemReports = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.menuStripPayroll.SuspendLayout();
            this.CMStripPayroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripPayroll
            // 
            this.menuStripPayroll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStripPayroll.Location = new System.Drawing.Point(0, 0);
            this.menuStripPayroll.Name = "menuStripPayroll";
            this.menuStripPayroll.Size = new System.Drawing.Size(1065, 24);
            this.menuStripPayroll.TabIndex = 0;
            this.menuStripPayroll.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDown = this.CMStripPayroll;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(55, 20);
            this.toolStripMenuItem1.Text = "Payroll";
            // 
            // CMStripPayroll
            // 
            this.CMStripPayroll.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TStripMenuItemGenerate,
            this.TStripMenuItemHistory,
            this.TStripMenuItemReports});
            this.CMStripPayroll.Name = "CMStripPayroll";
            this.CMStripPayroll.OwnerItem = this.toolStripMenuItem1;
            this.CMStripPayroll.Size = new System.Drawing.Size(122, 70);
            this.CMStripPayroll.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.CMStripPayroll_ItemClicked);
            // 
            // TStripMenuItemGenerate
            // 
            this.TStripMenuItemGenerate.Name = "TStripMenuItemGenerate";
            this.TStripMenuItemGenerate.Size = new System.Drawing.Size(121, 22);
            this.TStripMenuItemGenerate.Text = "Generate";
            // 
            // TStripMenuItemHistory
            // 
            this.TStripMenuItemHistory.Name = "TStripMenuItemHistory";
            this.TStripMenuItemHistory.Size = new System.Drawing.Size(121, 22);
            this.TStripMenuItemHistory.Text = "History";
            // 
            // TStripMenuItemReports
            // 
            this.TStripMenuItemReports.Name = "TStripMenuItemReports";
            this.TStripMenuItemReports.Size = new System.Drawing.Size(121, 22);
            this.TStripMenuItemReports.Text = "Reports";
            // 
            // panelContainer
            // 
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 24);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1065, 616);
            this.panelContainer.TabIndex = 1;
            // 
            // FrmPayroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 640);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.menuStripPayroll);
            this.MainMenuStrip = this.menuStripPayroll;
            this.Name = "FrmPayroll";
            this.Text = "PayrollForm";
            this.Load += new System.EventHandler(this.FrmPayroll_Load);
            this.menuStripPayroll.ResumeLayout(false);
            this.menuStripPayroll.PerformLayout();
            this.CMStripPayroll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripPayroll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip CMStripPayroll;
        private System.Windows.Forms.ToolStripMenuItem TStripMenuItemGenerate;
        private System.Windows.Forms.ToolStripMenuItem TStripMenuItemHistory;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ToolStripMenuItem TStripMenuItemReports;
    }
}