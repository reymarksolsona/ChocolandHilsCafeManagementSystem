
namespace Main.Forms.RequestsForm.Controls
{
    partial class CashAdvanceForApprovalControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGVRequests = new System.Windows.Forms.DataGridView();
            this.LblEmployeeName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DPicDateNeed = new System.Windows.Forms.DateTimePicker();
            this.NumUDwnAmount = new System.Windows.Forms.NumericUpDown();
            this.TboxEmployeeRemarks = new System.Windows.Forms.TextBox();
            this.TboxEmployeeNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TboxAdminRemarks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnApproved = new System.Windows.Forms.Button();
            this.BtnDisapproved = new System.Windows.Forms.Button();
            this.DPicCashReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUDwnAmount)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1236, 59);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Request cash advance";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGVRequests);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(417, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(819, 517);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Requests";
            // 
            // DGVRequests
            // 
            this.DGVRequests.AllowUserToAddRows = false;
            this.DGVRequests.AllowUserToDeleteRows = false;
            this.DGVRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVRequests.Location = new System.Drawing.Point(3, 23);
            this.DGVRequests.Name = "DGVRequests";
            this.DGVRequests.ReadOnly = true;
            this.DGVRequests.RowTemplate.Height = 25;
            this.DGVRequests.Size = new System.Drawing.Size(813, 491);
            this.DGVRequests.TabIndex = 16;
            this.DGVRequests.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRequests_CellClick);
            // 
            // LblEmployeeName
            // 
            this.LblEmployeeName.AutoSize = true;
            this.LblEmployeeName.Location = new System.Drawing.Point(165, 75);
            this.LblEmployeeName.Name = "LblEmployeeName";
            this.LblEmployeeName.Size = new System.Drawing.Size(49, 20);
            this.LblEmployeeName.TabIndex = 59;
            this.LblEmployeeName.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 58;
            this.label6.Text = "Employee";
            // 
            // DPicDateNeed
            // 
            this.DPicDateNeed.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicDateNeed.Location = new System.Drawing.Point(165, 184);
            this.DPicDateNeed.Name = "DPicDateNeed";
            this.DPicDateNeed.Size = new System.Drawing.Size(225, 27);
            this.DPicDateNeed.TabIndex = 56;
            // 
            // NumUDwnAmount
            // 
            this.NumUDwnAmount.DecimalPlaces = 2;
            this.NumUDwnAmount.Location = new System.Drawing.Point(165, 145);
            this.NumUDwnAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NumUDwnAmount.Name = "NumUDwnAmount";
            this.NumUDwnAmount.Size = new System.Drawing.Size(225, 27);
            this.NumUDwnAmount.TabIndex = 55;
            // 
            // TboxEmployeeRemarks
            // 
            this.TboxEmployeeRemarks.Location = new System.Drawing.Point(165, 217);
            this.TboxEmployeeRemarks.Multiline = true;
            this.TboxEmployeeRemarks.Name = "TboxEmployeeRemarks";
            this.TboxEmployeeRemarks.Size = new System.Drawing.Size(225, 102);
            this.TboxEmployeeRemarks.TabIndex = 54;
            // 
            // TboxEmployeeNumber
            // 
            this.TboxEmployeeNumber.Location = new System.Drawing.Point(165, 104);
            this.TboxEmployeeNumber.Name = "TboxEmployeeNumber";
            this.TboxEmployeeNumber.Size = new System.Drawing.Size(225, 27);
            this.TboxEmployeeNumber.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 52;
            this.label5.Text = "Employee Remarks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "Date need";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 50;
            this.label1.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Employee number";
            // 
            // TboxAdminRemarks
            // 
            this.TboxAdminRemarks.Location = new System.Drawing.Point(165, 361);
            this.TboxAdminRemarks.Multiline = true;
            this.TboxAdminRemarks.Name = "TboxAdminRemarks";
            this.TboxAdminRemarks.Size = new System.Drawing.Size(225, 102);
            this.TboxAdminRemarks.TabIndex = 61;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 396);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 60;
            this.label7.Text = "Your remarks";
            // 
            // BtnApproved
            // 
            this.BtnApproved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApproved.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnApproved.ForeColor = System.Drawing.Color.White;
            this.BtnApproved.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnApproved.Location = new System.Drawing.Point(288, 505);
            this.BtnApproved.Name = "BtnApproved";
            this.BtnApproved.Size = new System.Drawing.Size(102, 47);
            this.BtnApproved.TabIndex = 63;
            this.BtnApproved.Text = "Approved";
            this.BtnApproved.UseVisualStyleBackColor = false;
            this.BtnApproved.Click += new System.EventHandler(this.BtnApproved_Click);
            // 
            // BtnDisapproved
            // 
            this.BtnDisapproved.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnDisapproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDisapproved.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDisapproved.ForeColor = System.Drawing.Color.White;
            this.BtnDisapproved.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDisapproved.Location = new System.Drawing.Point(165, 505);
            this.BtnDisapproved.Name = "BtnDisapproved";
            this.BtnDisapproved.Size = new System.Drawing.Size(117, 47);
            this.BtnDisapproved.TabIndex = 62;
            this.BtnDisapproved.Text = "Disapproved";
            this.BtnDisapproved.UseVisualStyleBackColor = false;
            this.BtnDisapproved.Click += new System.EventHandler(this.BtnDisapproved_Click);
            // 
            // DPicCashReleaseDate
            // 
            this.DPicCashReleaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicCashReleaseDate.Location = new System.Drawing.Point(165, 472);
            this.DPicCashReleaseDate.Name = "DPicCashReleaseDate";
            this.DPicCashReleaseDate.Size = new System.Drawing.Size(225, 27);
            this.DPicCashReleaseDate.TabIndex = 65;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 477);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 20);
            this.label8.TabIndex = 64;
            this.label8.Text = "Cash Release date";
            // 
            // CashAdvanceForApprovalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DPicCashReleaseDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.BtnApproved);
            this.Controls.Add(this.BtnDisapproved);
            this.Controls.Add(this.TboxAdminRemarks);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LblEmployeeName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DPicDateNeed);
            this.Controls.Add(this.NumUDwnAmount);
            this.Controls.Add(this.TboxEmployeeRemarks);
            this.Controls.Add(this.TboxEmployeeNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "CashAdvanceForApprovalControl";
            this.Size = new System.Drawing.Size(1236, 576);
            this.Load += new System.EventHandler(this.CashAdvanceForApprovalControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUDwnAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGVRequests;
        private System.Windows.Forms.Label LblEmployeeName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DPicDateNeed;
        private System.Windows.Forms.NumericUpDown NumUDwnAmount;
        private System.Windows.Forms.TextBox TboxEmployeeRemarks;
        private System.Windows.Forms.TextBox TboxEmployeeNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TboxAdminRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnApproved;
        private System.Windows.Forms.Button BtnDisapproved;
        private System.Windows.Forms.DateTimePicker DPicCashReleaseDate;
        private System.Windows.Forms.Label label8;
    }
}
