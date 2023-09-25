
namespace Main.Forms.POSManagementForms.Controls
{
    partial class FrmSelectAvailableTable
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
            this.PanelDineInOrdersTableStatus = new System.Windows.Forms.Panel();
            this.FlowLayoutTables = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PanelDineInOrdersTableStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelDineInOrdersTableStatus
            // 
            this.PanelDineInOrdersTableStatus.Controls.Add(this.FlowLayoutTables);
            this.PanelDineInOrdersTableStatus.Controls.Add(this.panel1);
            this.PanelDineInOrdersTableStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDineInOrdersTableStatus.Location = new System.Drawing.Point(20, 20);
            this.PanelDineInOrdersTableStatus.Name = "PanelDineInOrdersTableStatus";
            this.PanelDineInOrdersTableStatus.Size = new System.Drawing.Size(760, 410);
            this.PanelDineInOrdersTableStatus.TabIndex = 1;
            // 
            // FlowLayoutTables
            // 
            this.FlowLayoutTables.AutoScroll = true;
            this.FlowLayoutTables.BackColor = System.Drawing.Color.White;
            this.FlowLayoutTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FlowLayoutTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutTables.Location = new System.Drawing.Point(0, 62);
            this.FlowLayoutTables.Name = "FlowLayoutTables";
            this.FlowLayoutTables.Size = new System.Drawing.Size(760, 348);
            this.FlowLayoutTables.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 62);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(146, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "OCCUPIED";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LawnGreen;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "AVAILABLE";
            // 
            // FrmSelectAvailableTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanelDineInOrdersTableStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSelectAvailableTable";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Table";
            this.Load += new System.EventHandler(this.FrmSelectAvailableTable_Load);
            this.PanelDineInOrdersTableStatus.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelDineInOrdersTableStatus;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutTables;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}