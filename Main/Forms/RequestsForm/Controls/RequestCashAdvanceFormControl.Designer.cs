
namespace Main.Forms.RequestsForm.Controls
{
    partial class RequestCashAdvanceFormControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TboxEmployeeNumber = new System.Windows.Forms.TextBox();
            this.TboxEmployeeRemarks = new System.Windows.Forms.TextBox();
            this.NumUDwnAmount = new System.Windows.Forms.NumericUpDown();
            this.DPicDateNeed = new System.Windows.Forms.DateTimePicker();
            this.BtnSubmitCashAdvanceRequest = new System.Windows.Forms.Button();
            this.DGVPreviousRequests = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCancelCashAdvanceRequest = new System.Windows.Forms.Button();
            this.BtnSearchEmployee = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.LblEmployeeName = new System.Windows.Forms.Label();
            this.TboxAdminRemarks = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TboxCashReleaseDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUDwnAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPreviousRequests)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1031, 59);
            this.panel1.TabIndex = 6;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Employee number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Amount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Date need";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Remarks";
            // 
            // TboxEmployeeNumber
            // 
            this.TboxEmployeeNumber.Location = new System.Drawing.Point(158, 111);
            this.TboxEmployeeNumber.Name = "TboxEmployeeNumber";
            this.TboxEmployeeNumber.Size = new System.Drawing.Size(160, 27);
            this.TboxEmployeeNumber.TabIndex = 11;
            // 
            // TboxEmployeeRemarks
            // 
            this.TboxEmployeeRemarks.Location = new System.Drawing.Point(158, 240);
            this.TboxEmployeeRemarks.Multiline = true;
            this.TboxEmployeeRemarks.Name = "TboxEmployeeRemarks";
            this.TboxEmployeeRemarks.Size = new System.Drawing.Size(225, 102);
            this.TboxEmployeeRemarks.TabIndex = 12;
            // 
            // NumUDwnAmount
            // 
            this.NumUDwnAmount.DecimalPlaces = 2;
            this.NumUDwnAmount.Location = new System.Drawing.Point(158, 152);
            this.NumUDwnAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NumUDwnAmount.Name = "NumUDwnAmount";
            this.NumUDwnAmount.Size = new System.Drawing.Size(225, 27);
            this.NumUDwnAmount.TabIndex = 13;
            // 
            // DPicDateNeed
            // 
            this.DPicDateNeed.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicDateNeed.Location = new System.Drawing.Point(158, 191);
            this.DPicDateNeed.Name = "DPicDateNeed";
            this.DPicDateNeed.Size = new System.Drawing.Size(225, 27);
            this.DPicDateNeed.TabIndex = 14;
            // 
            // BtnSubmitCashAdvanceRequest
            // 
            this.BtnSubmitCashAdvanceRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSubmitCashAdvanceRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmitCashAdvanceRequest.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSubmitCashAdvanceRequest.ForeColor = System.Drawing.Color.White;
            this.BtnSubmitCashAdvanceRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubmitCashAdvanceRequest.Location = new System.Drawing.Point(161, 348);
            this.BtnSubmitCashAdvanceRequest.Name = "BtnSubmitCashAdvanceRequest";
            this.BtnSubmitCashAdvanceRequest.Size = new System.Drawing.Size(102, 47);
            this.BtnSubmitCashAdvanceRequest.TabIndex = 15;
            this.BtnSubmitCashAdvanceRequest.Text = "Save";
            this.BtnSubmitCashAdvanceRequest.UseVisualStyleBackColor = false;
            this.BtnSubmitCashAdvanceRequest.Click += new System.EventHandler(this.BtnSubmitCashAdvanceRequest_Click);
            // 
            // DGVPreviousRequests
            // 
            this.DGVPreviousRequests.AllowUserToAddRows = false;
            this.DGVPreviousRequests.AllowUserToDeleteRows = false;
            this.DGVPreviousRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPreviousRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVPreviousRequests.Location = new System.Drawing.Point(3, 23);
            this.DGVPreviousRequests.Name = "DGVPreviousRequests";
            this.DGVPreviousRequests.ReadOnly = true;
            this.DGVPreviousRequests.RowTemplate.Height = 25;
            this.DGVPreviousRequests.Size = new System.Drawing.Size(619, 496);
            this.DGVPreviousRequests.TabIndex = 16;
            this.DGVPreviousRequests.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPreviousRequests_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGVPreviousRequests);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(406, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 522);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Previous requests";
            // 
            // BtnCancelCashAdvanceRequest
            // 
            this.BtnCancelCashAdvanceRequest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelCashAdvanceRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelCashAdvanceRequest.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelCashAdvanceRequest.ForeColor = System.Drawing.Color.White;
            this.BtnCancelCashAdvanceRequest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelCashAdvanceRequest.Location = new System.Drawing.Point(269, 348);
            this.BtnCancelCashAdvanceRequest.Name = "BtnCancelCashAdvanceRequest";
            this.BtnCancelCashAdvanceRequest.Size = new System.Drawing.Size(102, 47);
            this.BtnCancelCashAdvanceRequest.TabIndex = 45;
            this.BtnCancelCashAdvanceRequest.Text = "Cancel";
            this.BtnCancelCashAdvanceRequest.UseVisualStyleBackColor = false;
            this.BtnCancelCashAdvanceRequest.Visible = false;
            this.BtnCancelCashAdvanceRequest.Click += new System.EventHandler(this.BtnCancelCashAdvanceRequest_Click);
            // 
            // BtnSearchEmployee
            // 
            this.BtnSearchEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSearchEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchEmployee.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSearchEmployee.ForeColor = System.Drawing.Color.White;
            this.BtnSearchEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearchEmployee.Location = new System.Drawing.Point(324, 111);
            this.BtnSearchEmployee.Name = "BtnSearchEmployee";
            this.BtnSearchEmployee.Size = new System.Drawing.Size(59, 27);
            this.BtnSearchEmployee.TabIndex = 46;
            this.BtnSearchEmployee.Text = "Search";
            this.BtnSearchEmployee.UseVisualStyleBackColor = false;
            this.BtnSearchEmployee.Click += new System.EventHandler(this.BtnSearchEmployee_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 47;
            this.label6.Text = "Employee";
            // 
            // LblEmployeeName
            // 
            this.LblEmployeeName.AutoSize = true;
            this.LblEmployeeName.Location = new System.Drawing.Point(158, 82);
            this.LblEmployeeName.Name = "LblEmployeeName";
            this.LblEmployeeName.Size = new System.Drawing.Size(49, 20);
            this.LblEmployeeName.TabIndex = 48;
            this.LblEmployeeName.Text = "Name";
            // 
            // TboxAdminRemarks
            // 
            this.TboxAdminRemarks.Enabled = false;
            this.TboxAdminRemarks.Location = new System.Drawing.Point(32, 435);
            this.TboxAdminRemarks.Multiline = true;
            this.TboxAdminRemarks.Name = "TboxAdminRemarks";
            this.TboxAdminRemarks.Size = new System.Drawing.Size(351, 102);
            this.TboxAdminRemarks.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 409);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 49;
            this.label7.Text = "Admin remarks";
            // 
            // TboxCashReleaseDate
            // 
            this.TboxCashReleaseDate.Enabled = false;
            this.TboxCashReleaseDate.Location = new System.Drawing.Point(161, 543);
            this.TboxCashReleaseDate.Name = "TboxCashReleaseDate";
            this.TboxCashReleaseDate.Size = new System.Drawing.Size(222, 27);
            this.TboxCashReleaseDate.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 546);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 20);
            this.label8.TabIndex = 52;
            this.label8.Text = "Cash release date";
            // 
            // RequestCashAdvanceFormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TboxCashReleaseDate);
            this.Controls.Add(this.TboxAdminRemarks);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LblEmployeeName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnSearchEmployee);
            this.Controls.Add(this.BtnCancelCashAdvanceRequest);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnSubmitCashAdvanceRequest);
            this.Controls.Add(this.DPicDateNeed);
            this.Controls.Add(this.NumUDwnAmount);
            this.Controls.Add(this.TboxEmployeeRemarks);
            this.Controls.Add(this.TboxEmployeeNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "RequestCashAdvanceFormControl";
            this.Size = new System.Drawing.Size(1031, 581);
            this.Load += new System.EventHandler(this.RequestCashAdvanceFormControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUDwnAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPreviousRequests)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TboxEmployeeNumber;
        private System.Windows.Forms.TextBox TboxEmployeeRemarks;
        private System.Windows.Forms.NumericUpDown NumUDwnAmount;
        private System.Windows.Forms.DateTimePicker DPicDateNeed;
        private System.Windows.Forms.Button BtnSubmitCashAdvanceRequest;
        private System.Windows.Forms.DataGridView DGVPreviousRequests;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnCancelCashAdvanceRequest;
        private System.Windows.Forms.Button BtnSearchEmployee;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblEmployeeName;
        private System.Windows.Forms.TextBox TboxAdminRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TboxCashReleaseDate;
        private System.Windows.Forms.Label label8;
    }
}
