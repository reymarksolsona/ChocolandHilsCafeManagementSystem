
namespace Main.Forms.EmployeeManagementForms.OtherForms
{
    partial class FrmReassignEmployeesToNewShift
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblShiftToDelete = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancelUpdateShift = new System.Windows.Forms.Button();
            this.BtnSubmitNewShift = new System.Windows.Forms.Button();
            this.CBoxShifts = new System.Windows.Forms.ComboBox();
            this.BtnForceDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.LblShiftToDelete);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(526, 105);
            this.panel1.TabIndex = 8;
            // 
            // LblShiftToDelete
            // 
            this.LblShiftToDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblShiftToDelete.ForeColor = System.Drawing.Color.White;
            this.LblShiftToDelete.Location = new System.Drawing.Point(53, 60);
            this.LblShiftToDelete.Name = "LblShiftToDelete";
            this.LblShiftToDelete.Size = new System.Drawing.Size(413, 25);
            this.LblShiftToDelete.TabIndex = 44;
            this.LblShiftToDelete.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(53, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(371, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Choose new shift for all employees under:";
            // 
            // BtnCancelUpdateShift
            // 
            this.BtnCancelUpdateShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdateShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdateShift.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdateShift.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdateShift.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdateShift.Location = new System.Drawing.Point(387, 167);
            this.BtnCancelUpdateShift.Name = "BtnCancelUpdateShift";
            this.BtnCancelUpdateShift.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdateShift.TabIndex = 14;
            this.BtnCancelUpdateShift.Text = "Cancel";
            this.BtnCancelUpdateShift.UseVisualStyleBackColor = false;
            this.BtnCancelUpdateShift.Click += new System.EventHandler(this.BtnCancelUpdateShift_Click);
            // 
            // BtnSubmitNewShift
            // 
            this.BtnSubmitNewShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSubmitNewShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmitNewShift.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSubmitNewShift.ForeColor = System.Drawing.Color.White;
            this.BtnSubmitNewShift.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubmitNewShift.Location = new System.Drawing.Point(254, 167);
            this.BtnSubmitNewShift.Name = "BtnSubmitNewShift";
            this.BtnSubmitNewShift.Size = new System.Drawing.Size(115, 47);
            this.BtnSubmitNewShift.TabIndex = 13;
            this.BtnSubmitNewShift.Text = "Submit";
            this.BtnSubmitNewShift.UseVisualStyleBackColor = false;
            this.BtnSubmitNewShift.Click += new System.EventHandler(this.BtnSubmitNewShift_Click);
            // 
            // CBoxShifts
            // 
            this.CBoxShifts.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxShifts.FormattingEnabled = true;
            this.CBoxShifts.Location = new System.Drawing.Point(25, 111);
            this.CBoxShifts.Name = "CBoxShifts";
            this.CBoxShifts.Size = new System.Drawing.Size(477, 38);
            this.CBoxShifts.TabIndex = 12;
            // 
            // BtnForceDelete
            // 
            this.BtnForceDelete.BackColor = System.Drawing.Color.DarkRed;
            this.BtnForceDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnForceDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnForceDelete.ForeColor = System.Drawing.Color.White;
            this.BtnForceDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnForceDelete.Location = new System.Drawing.Point(25, 167);
            this.BtnForceDelete.Name = "BtnForceDelete";
            this.BtnForceDelete.Size = new System.Drawing.Size(128, 47);
            this.BtnForceDelete.TabIndex = 20;
            this.BtnForceDelete.Text = "Delete Anyway";
            this.BtnForceDelete.UseVisualStyleBackColor = false;
            this.BtnForceDelete.Click += new System.EventHandler(this.BtnForceDelete_Click);
            // 
            // FrmReassignEmployeesToNewShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(526, 225);
            this.Controls.Add(this.BtnForceDelete);
            this.Controls.Add(this.BtnCancelUpdateShift);
            this.Controls.Add(this.BtnSubmitNewShift);
            this.Controls.Add(this.CBoxShifts);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReassignEmployeesToNewShift";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmReassignEmployeesToNewShift";
            this.Load += new System.EventHandler(this.FrmReassignEmployeesToNewShift_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblShiftToDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancelUpdateShift;
        private System.Windows.Forms.Button BtnSubmitNewShift;
        private System.Windows.Forms.ComboBox CBoxShifts;
        private System.Windows.Forms.Button BtnForceDelete;
    }
}