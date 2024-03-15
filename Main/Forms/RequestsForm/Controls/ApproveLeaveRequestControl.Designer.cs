namespace Main.Forms.RequestsForm.Controls
{
    partial class ApproveLeaveRequestControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnApprovedEmpLeave = new System.Windows.Forms.Button();
            this.BtnDisapprovedEmpLeave = new System.Windows.Forms.Button();
            this.TboxAdminRemarks = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TboxEmployeeLeaveRemarks = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.DGVEmployeeLeaveApproval = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeLeaveApproval)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(1129, 59);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Approve Leave";
            // 
            // BtnApprovedEmpLeave
            // 
            this.BtnApprovedEmpLeave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnApprovedEmpLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApprovedEmpLeave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnApprovedEmpLeave.ForeColor = System.Drawing.Color.White;
            this.BtnApprovedEmpLeave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnApprovedEmpLeave.Location = new System.Drawing.Point(305, 391);
            this.BtnApprovedEmpLeave.Name = "BtnApprovedEmpLeave";
            this.BtnApprovedEmpLeave.Size = new System.Drawing.Size(102, 47);
            this.BtnApprovedEmpLeave.TabIndex = 81;
            this.BtnApprovedEmpLeave.Text = "Approved";
            this.BtnApprovedEmpLeave.UseVisualStyleBackColor = false;
            this.BtnApprovedEmpLeave.Click += new System.EventHandler(this.BtnApprovedEmpLeave_Click);
            // 
            // BtnDisapprovedEmpLeave
            // 
            this.BtnDisapprovedEmpLeave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnDisapprovedEmpLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDisapprovedEmpLeave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDisapprovedEmpLeave.ForeColor = System.Drawing.Color.White;
            this.BtnDisapprovedEmpLeave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDisapprovedEmpLeave.Location = new System.Drawing.Point(182, 391);
            this.BtnDisapprovedEmpLeave.Name = "BtnDisapprovedEmpLeave";
            this.BtnDisapprovedEmpLeave.Size = new System.Drawing.Size(117, 47);
            this.BtnDisapprovedEmpLeave.TabIndex = 80;
            this.BtnDisapprovedEmpLeave.Text = "Disapproved";
            this.BtnDisapprovedEmpLeave.UseVisualStyleBackColor = false;
            this.BtnDisapprovedEmpLeave.Click += new System.EventHandler(this.BtnDisapprovedEmpLeave_Click);
            // 
            // TboxAdminRemarks
            // 
            this.TboxAdminRemarks.Location = new System.Drawing.Point(39, 274);
            this.TboxAdminRemarks.Multiline = true;
            this.TboxAdminRemarks.Name = "TboxAdminRemarks";
            this.TboxAdminRemarks.Size = new System.Drawing.Size(368, 102);
            this.TboxAdminRemarks.TabIndex = 79;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(39, 238);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 21);
            this.label13.TabIndex = 78;
            this.label13.Text = "Your remarks";
            // 
            // TboxEmployeeLeaveRemarks
            // 
            this.TboxEmployeeLeaveRemarks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxEmployeeLeaveRemarks.Location = new System.Drawing.Point(39, 107);
            this.TboxEmployeeLeaveRemarks.Multiline = true;
            this.TboxEmployeeLeaveRemarks.Name = "TboxEmployeeLeaveRemarks";
            this.TboxEmployeeLeaveRemarks.Size = new System.Drawing.Size(368, 94);
            this.TboxEmployeeLeaveRemarks.TabIndex = 76;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(39, 83);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 21);
            this.label12.TabIndex = 77;
            this.label12.Text = "Reason";
            // 
            // DGVEmployeeLeaveApproval
            // 
            this.DGVEmployeeLeaveApproval.AllowUserToAddRows = false;
            this.DGVEmployeeLeaveApproval.AllowUserToDeleteRows = false;
            this.DGVEmployeeLeaveApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeLeaveApproval.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGVEmployeeLeaveApproval.Location = new System.Drawing.Point(465, 59);
            this.DGVEmployeeLeaveApproval.Name = "DGVEmployeeLeaveApproval";
            this.DGVEmployeeLeaveApproval.ReadOnly = true;
            this.DGVEmployeeLeaveApproval.RowHeadersWidth = 62;
            this.DGVEmployeeLeaveApproval.RowTemplate.Height = 25;
            this.DGVEmployeeLeaveApproval.Size = new System.Drawing.Size(664, 417);
            this.DGVEmployeeLeaveApproval.TabIndex = 75;
            this.DGVEmployeeLeaveApproval.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployeeLeaveApproval_CellClick);
            // 
            // ApproveLeaveRequestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BtnApprovedEmpLeave);
            this.Controls.Add(this.BtnDisapprovedEmpLeave);
            this.Controls.Add(this.TboxAdminRemarks);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.TboxEmployeeLeaveRemarks);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.DGVEmployeeLeaveApproval);
            this.Controls.Add(this.panel1);
            this.Name = "ApproveLeaveRequestControl";
            this.Size = new System.Drawing.Size(1129, 476);
            this.Load += new System.EventHandler(this.ApproveLeaveRequestControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeLeaveApproval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnApprovedEmpLeave;
        private System.Windows.Forms.Button BtnDisapprovedEmpLeave;
        private System.Windows.Forms.TextBox TboxAdminRemarks;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TboxEmployeeLeaveRemarks;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView DGVEmployeeLeaveApproval;
    }
}
