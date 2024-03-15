namespace Main.Forms.RequestsForm.Controls
{
    partial class RequestLeaveControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageEmpLeaveFiling = new System.Windows.Forms.TabPage();
            this.CboxDuration = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.CBoxLeaveTypes = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.DPickerDurationStartDate = new System.Windows.Forms.DateTimePicker();
            this.TboxLeaveReason = new System.Windows.Forms.TextBox();
            this.LblRemainingLeave = new System.Windows.Forms.Label();
            this.BtnSaveEmployeeLeave = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.DPickerDurationEndDate = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.TabPageEmpLeaveHistory = new System.Windows.Forms.TabPage();
            this.TBoxEmployerEnteredRemarks = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.TBoxEmployeeLeaveReason = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.DGVEmployeeLeaveHistory = new System.Windows.Forms.DataGridView();
            this.CBoxYearList = new System.Windows.Forms.ComboBox();
            this.BtnFilterEmployeeLeaveHistory = new System.Windows.Forms.Button();
            this.label30 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPageEmpLeaveFiling.SuspendLayout();
            this.TabPageEmpLeaveHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeLeaveHistory)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1017, 59);
            this.panel1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Request Leave";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPageEmpLeaveFiling);
            this.tabControl1.Controls.Add(this.TabPageEmpLeaveHistory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1017, 521);
            this.tabControl1.TabIndex = 71;
            // 
            // TabPageEmpLeaveFiling
            // 
            this.TabPageEmpLeaveFiling.Controls.Add(this.CboxDuration);
            this.TabPageEmpLeaveFiling.Controls.Add(this.label35);
            this.TabPageEmpLeaveFiling.Controls.Add(this.CBoxLeaveTypes);
            this.TabPageEmpLeaveFiling.Controls.Add(this.label31);
            this.TabPageEmpLeaveFiling.Controls.Add(this.DPickerDurationStartDate);
            this.TabPageEmpLeaveFiling.Controls.Add(this.TboxLeaveReason);
            this.TabPageEmpLeaveFiling.Controls.Add(this.LblRemainingLeave);
            this.TabPageEmpLeaveFiling.Controls.Add(this.BtnSaveEmployeeLeave);
            this.TabPageEmpLeaveFiling.Controls.Add(this.label32);
            this.TabPageEmpLeaveFiling.Controls.Add(this.label34);
            this.TabPageEmpLeaveFiling.Controls.Add(this.DPickerDurationEndDate);
            this.TabPageEmpLeaveFiling.Controls.Add(this.label29);
            this.TabPageEmpLeaveFiling.Controls.Add(this.label33);
            this.TabPageEmpLeaveFiling.Location = new System.Drawing.Point(4, 30);
            this.TabPageEmpLeaveFiling.Name = "TabPageEmpLeaveFiling";
            this.TabPageEmpLeaveFiling.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageEmpLeaveFiling.Size = new System.Drawing.Size(1009, 487);
            this.TabPageEmpLeaveFiling.TabIndex = 0;
            this.TabPageEmpLeaveFiling.Text = "File Leave";
            this.TabPageEmpLeaveFiling.UseVisualStyleBackColor = true;
            // 
            // CboxDuration
            // 
            this.CboxDuration.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CboxDuration.FormattingEnabled = true;
            this.CboxDuration.Location = new System.Drawing.Point(362, 319);
            this.CboxDuration.Name = "CboxDuration";
            this.CboxDuration.Size = new System.Drawing.Size(432, 29);
            this.CboxDuration.TabIndex = 68;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(263, 325);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(71, 21);
            this.label35.TabIndex = 67;
            this.label35.Text = "Duration";
            // 
            // CBoxLeaveTypes
            // 
            this.CBoxLeaveTypes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxLeaveTypes.FormattingEnabled = true;
            this.CBoxLeaveTypes.Location = new System.Drawing.Point(362, 72);
            this.CBoxLeaveTypes.Name = "CBoxLeaveTypes";
            this.CBoxLeaveTypes.Size = new System.Drawing.Size(432, 29);
            this.CBoxLeaveTypes.TabIndex = 54;
            this.CBoxLeaveTypes.SelectedIndexChanged += new System.EventHandler(this.CBoxLeaveTypes_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(302, 234);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(47, 21);
            this.label31.TabIndex = 65;
            this.label31.Text = "From";
            // 
            // DPickerDurationStartDate
            // 
            this.DPickerDurationStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DPickerDurationStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerDurationStartDate.Location = new System.Drawing.Point(362, 231);
            this.DPickerDurationStartDate.Name = "DPickerDurationStartDate";
            this.DPickerDurationStartDate.Size = new System.Drawing.Size(203, 29);
            this.DPickerDurationStartDate.TabIndex = 59;
            // 
            // TboxLeaveReason
            // 
            this.TboxLeaveReason.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxLeaveReason.Location = new System.Drawing.Point(362, 150);
            this.TboxLeaveReason.Multiline = true;
            this.TboxLeaveReason.Name = "TboxLeaveReason";
            this.TboxLeaveReason.Size = new System.Drawing.Size(432, 60);
            this.TboxLeaveReason.TabIndex = 51;
            // 
            // LblRemainingLeave
            // 
            this.LblRemainingLeave.AutoSize = true;
            this.LblRemainingLeave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblRemainingLeave.ForeColor = System.Drawing.Color.Black;
            this.LblRemainingLeave.Location = new System.Drawing.Point(365, 123);
            this.LblRemainingLeave.Name = "LblRemainingLeave";
            this.LblRemainingLeave.Size = new System.Drawing.Size(19, 21);
            this.LblRemainingLeave.TabIndex = 56;
            this.LblRemainingLeave.Text = "0";
            // 
            // BtnSaveEmployeeLeave
            // 
            this.BtnSaveEmployeeLeave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveEmployeeLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveEmployeeLeave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveEmployeeLeave.ForeColor = System.Drawing.Color.White;
            this.BtnSaveEmployeeLeave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveEmployeeLeave.Location = new System.Drawing.Point(362, 367);
            this.BtnSaveEmployeeLeave.Name = "BtnSaveEmployeeLeave";
            this.BtnSaveEmployeeLeave.Size = new System.Drawing.Size(319, 37);
            this.BtnSaveEmployeeLeave.TabIndex = 63;
            this.BtnSaveEmployeeLeave.Text = "Submit";
            this.BtnSaveEmployeeLeave.UseVisualStyleBackColor = false;
            this.BtnSaveEmployeeLeave.Click += new System.EventHandler(this.BtnSaveEmployeeLeave_Click);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(220, 123);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(129, 21);
            this.label32.TabIndex = 55;
            this.label32.Text = "Remaining Leave";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(263, 75);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(86, 21);
            this.label34.TabIndex = 52;
            this.label34.Text = "Leave Type";
            // 
            // DPickerDurationEndDate
            // 
            this.DPickerDurationEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DPickerDurationEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerDurationEndDate.Location = new System.Drawing.Point(362, 271);
            this.DPickerDurationEndDate.Name = "DPickerDurationEndDate";
            this.DPickerDurationEndDate.Size = new System.Drawing.Size(203, 29);
            this.DPickerDurationEndDate.TabIndex = 61;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(324, 274);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(25, 21);
            this.label29.TabIndex = 62;
            this.label29.Text = "To";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(288, 156);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(61, 21);
            this.label33.TabIndex = 53;
            this.label33.Text = "Reason";
            // 
            // TabPageEmpLeaveHistory
            // 
            this.TabPageEmpLeaveHistory.Controls.Add(this.TBoxEmployerEnteredRemarks);
            this.TabPageEmpLeaveHistory.Controls.Add(this.label18);
            this.TabPageEmpLeaveHistory.Controls.Add(this.TBoxEmployeeLeaveReason);
            this.TabPageEmpLeaveHistory.Controls.Add(this.label19);
            this.TabPageEmpLeaveHistory.Controls.Add(this.DGVEmployeeLeaveHistory);
            this.TabPageEmpLeaveHistory.Controls.Add(this.CBoxYearList);
            this.TabPageEmpLeaveHistory.Controls.Add(this.BtnFilterEmployeeLeaveHistory);
            this.TabPageEmpLeaveHistory.Controls.Add(this.label30);
            this.TabPageEmpLeaveHistory.Location = new System.Drawing.Point(4, 30);
            this.TabPageEmpLeaveHistory.Name = "TabPageEmpLeaveHistory";
            this.TabPageEmpLeaveHistory.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageEmpLeaveHistory.Size = new System.Drawing.Size(1009, 487);
            this.TabPageEmpLeaveHistory.TabIndex = 1;
            this.TabPageEmpLeaveHistory.Text = "History";
            this.TabPageEmpLeaveHistory.UseVisualStyleBackColor = true;
            // 
            // TBoxEmployerEnteredRemarks
            // 
            this.TBoxEmployerEnteredRemarks.Location = new System.Drawing.Point(22, 285);
            this.TBoxEmployerEnteredRemarks.Multiline = true;
            this.TBoxEmployerEnteredRemarks.Name = "TBoxEmployerEnteredRemarks";
            this.TBoxEmployerEnteredRemarks.Size = new System.Drawing.Size(368, 102);
            this.TBoxEmployerEnteredRemarks.TabIndex = 76;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(25, 264);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(103, 21);
            this.label18.TabIndex = 75;
            this.label18.Text = "Your remarks";
            // 
            // TBoxEmployeeLeaveReason
            // 
            this.TBoxEmployeeLeaveReason.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TBoxEmployeeLeaveReason.Location = new System.Drawing.Point(22, 130);
            this.TBoxEmployeeLeaveReason.Multiline = true;
            this.TBoxEmployeeLeaveReason.Name = "TBoxEmployeeLeaveReason";
            this.TBoxEmployeeLeaveReason.Size = new System.Drawing.Size(368, 94);
            this.TBoxEmployeeLeaveReason.TabIndex = 73;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(25, 109);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 21);
            this.label19.TabIndex = 74;
            this.label19.Text = "Reason";
            // 
            // DGVEmployeeLeaveHistory
            // 
            this.DGVEmployeeLeaveHistory.AllowUserToAddRows = false;
            this.DGVEmployeeLeaveHistory.AllowUserToDeleteRows = false;
            this.DGVEmployeeLeaveHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeLeaveHistory.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGVEmployeeLeaveHistory.Location = new System.Drawing.Point(436, 3);
            this.DGVEmployeeLeaveHistory.Name = "DGVEmployeeLeaveHistory";
            this.DGVEmployeeLeaveHistory.ReadOnly = true;
            this.DGVEmployeeLeaveHistory.RowHeadersWidth = 62;
            this.DGVEmployeeLeaveHistory.RowTemplate.Height = 25;
            this.DGVEmployeeLeaveHistory.Size = new System.Drawing.Size(570, 481);
            this.DGVEmployeeLeaveHistory.TabIndex = 67;
            this.DGVEmployeeLeaveHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployeeLeaveHistory_CellClick);
            // 
            // CBoxYearList
            // 
            this.CBoxYearList.FormattingEnabled = true;
            this.CBoxYearList.Location = new System.Drawing.Point(68, 39);
            this.CBoxYearList.Name = "CBoxYearList";
            this.CBoxYearList.Size = new System.Drawing.Size(190, 29);
            this.CBoxYearList.TabIndex = 54;
            // 
            // BtnFilterEmployeeLeaveHistory
            // 
            this.BtnFilterEmployeeLeaveHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnFilterEmployeeLeaveHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilterEmployeeLeaveHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnFilterEmployeeLeaveHistory.ForeColor = System.Drawing.Color.White;
            this.BtnFilterEmployeeLeaveHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFilterEmployeeLeaveHistory.Location = new System.Drawing.Point(264, 39);
            this.BtnFilterEmployeeLeaveHistory.Name = "BtnFilterEmployeeLeaveHistory";
            this.BtnFilterEmployeeLeaveHistory.Size = new System.Drawing.Size(78, 31);
            this.BtnFilterEmployeeLeaveHistory.TabIndex = 53;
            this.BtnFilterEmployeeLeaveHistory.Text = "Filter";
            this.BtnFilterEmployeeLeaveHistory.UseVisualStyleBackColor = false;
            this.BtnFilterEmployeeLeaveHistory.Click += new System.EventHandler(this.BtnFilterEmployeeLeaveHistory_Click);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(25, 46);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(40, 21);
            this.label30.TabIndex = 52;
            this.label30.Text = "Year";
            // 
            // RequestLeaveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "RequestLeaveControl";
            this.Size = new System.Drawing.Size(1017, 580);
            this.Load += new System.EventHandler(this.RequestLeaveControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPageEmpLeaveFiling.ResumeLayout(false);
            this.TabPageEmpLeaveFiling.PerformLayout();
            this.TabPageEmpLeaveHistory.ResumeLayout(false);
            this.TabPageEmpLeaveHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeLeaveHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPageEmpLeaveFiling;
        private System.Windows.Forms.ComboBox CboxDuration;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox CBoxLeaveTypes;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DateTimePicker DPickerDurationStartDate;
        private System.Windows.Forms.TextBox TboxLeaveReason;
        private System.Windows.Forms.Label LblRemainingLeave;
        private System.Windows.Forms.Button BtnSaveEmployeeLeave;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.DateTimePicker DPickerDurationEndDate;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TabPage TabPageEmpLeaveHistory;
        private System.Windows.Forms.TextBox TBoxEmployerEnteredRemarks;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox TBoxEmployeeLeaveReason;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView DGVEmployeeLeaveHistory;
        private System.Windows.Forms.ComboBox CBoxYearList;
        private System.Windows.Forms.Button BtnFilterEmployeeLeaveHistory;
        private System.Windows.Forms.Label label30;
    }
}
