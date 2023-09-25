
namespace Main.Forms.EmployeeManagementForms.Controls
{
    partial class HolidayCRUDControl
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
            this.GBoxLeaveTypeForm = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CboxHolidayType = new System.Windows.Forms.ComboBox();
            this.CBoxHolidayDayNum = new System.Windows.Forms.ComboBox();
            this.CboxHolidayMonthAbbv = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TbxHoliday = new System.Windows.Forms.TextBox();
            this.BtnSaveHoliday = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVHolidays = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.GBoxLeaveTypeForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHolidays)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1007, 94);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Holidays";
            // 
            // GBoxLeaveTypeForm
            // 
            this.GBoxLeaveTypeForm.Controls.Add(this.label4);
            this.GBoxLeaveTypeForm.Controls.Add(this.CboxHolidayType);
            this.GBoxLeaveTypeForm.Controls.Add(this.CBoxHolidayDayNum);
            this.GBoxLeaveTypeForm.Controls.Add(this.CboxHolidayMonthAbbv);
            this.GBoxLeaveTypeForm.Controls.Add(this.label9);
            this.GBoxLeaveTypeForm.Controls.Add(this.TbxHoliday);
            this.GBoxLeaveTypeForm.Controls.Add(this.BtnSaveHoliday);
            this.GBoxLeaveTypeForm.Controls.Add(this.label1);
            this.GBoxLeaveTypeForm.ForeColor = System.Drawing.Color.Black;
            this.GBoxLeaveTypeForm.Location = new System.Drawing.Point(27, 133);
            this.GBoxLeaveTypeForm.Name = "GBoxLeaveTypeForm";
            this.GBoxLeaveTypeForm.Size = new System.Drawing.Size(299, 338);
            this.GBoxLeaveTypeForm.TabIndex = 48;
            this.GBoxLeaveTypeForm.TabStop = false;
            this.GBoxLeaveTypeForm.Text = "Add new holiday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(19, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 49;
            this.label4.Text = "Type";
            // 
            // CboxHolidayType
            // 
            this.CboxHolidayType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CboxHolidayType.FormattingEnabled = true;
            this.CboxHolidayType.Location = new System.Drawing.Point(19, 231);
            this.CboxHolidayType.Name = "CboxHolidayType";
            this.CboxHolidayType.Size = new System.Drawing.Size(265, 29);
            this.CboxHolidayType.TabIndex = 48;
            // 
            // CBoxHolidayDayNum
            // 
            this.CBoxHolidayDayNum.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxHolidayDayNum.FormattingEnabled = true;
            this.CBoxHolidayDayNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.CBoxHolidayDayNum.Location = new System.Drawing.Point(19, 161);
            this.CBoxHolidayDayNum.Name = "CBoxHolidayDayNum";
            this.CBoxHolidayDayNum.Size = new System.Drawing.Size(265, 29);
            this.CBoxHolidayDayNum.TabIndex = 47;
            // 
            // CboxHolidayMonthAbbv
            // 
            this.CboxHolidayMonthAbbv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CboxHolidayMonthAbbv.FormattingEnabled = true;
            this.CboxHolidayMonthAbbv.Location = new System.Drawing.Point(19, 126);
            this.CboxHolidayMonthAbbv.Name = "CboxHolidayMonthAbbv";
            this.CboxHolidayMonthAbbv.Size = new System.Drawing.Size(265, 29);
            this.CboxHolidayMonthAbbv.TabIndex = 46;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(19, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Holiday";
            // 
            // TbxHoliday
            // 
            this.TbxHoliday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxHoliday.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxHoliday.Location = new System.Drawing.Point(19, 61);
            this.TbxHoliday.Name = "TbxHoliday";
            this.TbxHoliday.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbxHoliday.Size = new System.Drawing.Size(265, 27);
            this.TbxHoliday.TabIndex = 24;
            // 
            // BtnSaveHoliday
            // 
            this.BtnSaveHoliday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveHoliday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveHoliday.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveHoliday.ForeColor = System.Drawing.Color.White;
            this.BtnSaveHoliday.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveHoliday.Location = new System.Drawing.Point(169, 280);
            this.BtnSaveHoliday.Name = "BtnSaveHoliday";
            this.BtnSaveHoliday.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveHoliday.TabIndex = 2;
            this.BtnSaveHoliday.Text = "Save";
            this.BtnSaveHoliday.UseVisualStyleBackColor = false;
            this.BtnSaveHoliday.Click += new System.EventHandler(this.BtnSaveHoliday_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Date";
            // 
            // DGVHolidays
            // 
            this.DGVHolidays.AllowUserToAddRows = false;
            this.DGVHolidays.AllowUserToDeleteRows = false;
            this.DGVHolidays.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHolidays.Location = new System.Drawing.Point(371, 133);
            this.DGVHolidays.Name = "DGVHolidays";
            this.DGVHolidays.ReadOnly = true;
            this.DGVHolidays.RowTemplate.Height = 25;
            this.DGVHolidays.Size = new System.Drawing.Size(611, 294);
            this.DGVHolidays.TabIndex = 49;
            this.DGVHolidays.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVHolidays_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(371, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(346, 15);
            this.label3.TabIndex = 50;
            this.label3.Text = "Note: If you need to update, just delete the existing and add new";
            // 
            // HolidayCRUDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DGVHolidays);
            this.Controls.Add(this.GBoxLeaveTypeForm);
            this.Controls.Add(this.panel1);
            this.Name = "HolidayCRUDControl";
            this.Size = new System.Drawing.Size(1007, 495);
            this.Load += new System.EventHandler(this.HolidayCRUDControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GBoxLeaveTypeForm.ResumeLayout(false);
            this.GBoxLeaveTypeForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHolidays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GBoxLeaveTypeForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TbxHoliday;
        private System.Windows.Forms.Button BtnSaveHoliday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVHolidays;
        private System.Windows.Forms.ComboBox CBoxHolidayDayNum;
        private System.Windows.Forms.ComboBox CboxHolidayMonthAbbv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboxHolidayType;
        private System.Windows.Forms.Label label4;
    }
}
