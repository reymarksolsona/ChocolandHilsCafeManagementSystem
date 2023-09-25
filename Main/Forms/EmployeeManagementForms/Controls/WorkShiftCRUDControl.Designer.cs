
namespace Main.Forms.EmployeeManagementForms.Controls
{
    partial class WorkShiftCRUDControl
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
            this.DTPickerShiftStartTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DTPickerLateTimeIn = new System.Windows.Forms.DateTimePicker();
            this.DTPickerEarlyTimeOut = new System.Windows.Forms.DateTimePicker();
            this.GroupPanelShiftDays = new System.Windows.Forms.GroupBox();
            this.CBoxSunday = new System.Windows.Forms.CheckBox();
            this.CBoxSaturday = new System.Windows.Forms.CheckBox();
            this.CBoxFriday = new System.Windows.Forms.CheckBox();
            this.CBoxThursday = new System.Windows.Forms.CheckBox();
            this.CBoxWednesday = new System.Windows.Forms.CheckBox();
            this.CBoxMonday = new System.Windows.Forms.CheckBox();
            this.CBoxTuesday = new System.Windows.Forms.CheckBox();
            this.TboxShiftNumberOfHrs = new System.Windows.Forms.NumericUpDown();
            this.CBoxBreakTimes = new System.Windows.Forms.ComboBox();
            this.CboxDisable = new System.Windows.Forms.CheckBox();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSaveWorkShift = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DTPickerShiftBreaktime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TboxShiftTitle = new System.Windows.Forms.TextBox();
            this.DGVWorkShifts = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GroupPanelShiftDays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TboxShiftNumberOfHrs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorkShifts)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1067, 94);
            this.panel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Work shifts";
            // 
            // DTPickerShiftStartTime
            // 
            this.DTPickerShiftStartTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DTPickerShiftStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPickerShiftStartTime.Location = new System.Drawing.Point(124, 58);
            this.DTPickerShiftStartTime.Name = "DTPickerShiftStartTime";
            this.DTPickerShiftStartTime.ShowUpDown = true;
            this.DTPickerShiftStartTime.Size = new System.Drawing.Size(162, 29);
            this.DTPickerShiftStartTime.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DTPickerLateTimeIn);
            this.groupBox1.Controls.Add(this.DTPickerEarlyTimeOut);
            this.groupBox1.Controls.Add(this.GroupPanelShiftDays);
            this.groupBox1.Controls.Add(this.TboxShiftNumberOfHrs);
            this.groupBox1.Controls.Add(this.CBoxBreakTimes);
            this.groupBox1.Controls.Add(this.CboxDisable);
            this.groupBox1.Controls.Add(this.BtnCancelUpdate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.BtnSaveWorkShift);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DTPickerShiftBreaktime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.TboxShiftTitle);
            this.groupBox1.Controls.Add(this.DTPickerShiftStartTime);
            this.groupBox1.Location = new System.Drawing.Point(11, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1037, 180);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(704, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 21);
            this.label6.TabIndex = 56;
            this.label6.Text = "Late Time IN";
            this.label6.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(704, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 54;
            this.label3.Text = "Early Time OUT";
            this.label3.Visible = false;
            // 
            // DTPickerLateTimeIn
            // 
            this.DTPickerLateTimeIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DTPickerLateTimeIn.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPickerLateTimeIn.Location = new System.Drawing.Point(841, 59);
            this.DTPickerLateTimeIn.Name = "DTPickerLateTimeIn";
            this.DTPickerLateTimeIn.ShowUpDown = true;
            this.DTPickerLateTimeIn.Size = new System.Drawing.Size(162, 29);
            this.DTPickerLateTimeIn.TabIndex = 55;
            this.DTPickerLateTimeIn.Visible = false;
            // 
            // DTPickerEarlyTimeOut
            // 
            this.DTPickerEarlyTimeOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DTPickerEarlyTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPickerEarlyTimeOut.Location = new System.Drawing.Point(841, 21);
            this.DTPickerEarlyTimeOut.Name = "DTPickerEarlyTimeOut";
            this.DTPickerEarlyTimeOut.ShowUpDown = true;
            this.DTPickerEarlyTimeOut.Size = new System.Drawing.Size(162, 29);
            this.DTPickerEarlyTimeOut.TabIndex = 53;
            this.DTPickerEarlyTimeOut.Visible = false;
            // 
            // GroupPanelShiftDays
            // 
            this.GroupPanelShiftDays.Controls.Add(this.CBoxSunday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxSaturday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxFriday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxThursday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxWednesday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxMonday);
            this.GroupPanelShiftDays.Controls.Add(this.CBoxTuesday);
            this.GroupPanelShiftDays.Location = new System.Drawing.Point(361, 103);
            this.GroupPanelShiftDays.Name = "GroupPanelShiftDays";
            this.GroupPanelShiftDays.Size = new System.Drawing.Size(380, 61);
            this.GroupPanelShiftDays.TabIndex = 52;
            this.GroupPanelShiftDays.TabStop = false;
            this.GroupPanelShiftDays.Text = "Choose days";
            // 
            // CBoxSunday
            // 
            this.CBoxSunday.AutoSize = true;
            this.CBoxSunday.Location = new System.Drawing.Point(318, 32);
            this.CBoxSunday.Name = "CBoxSunday";
            this.CBoxSunday.Size = new System.Drawing.Size(46, 19);
            this.CBoxSunday.TabIndex = 56;
            this.CBoxSunday.Tag = "Sun-7";
            this.CBoxSunday.Text = "Sun";
            this.CBoxSunday.UseVisualStyleBackColor = true;
            // 
            // CBoxSaturday
            // 
            this.CBoxSaturday.AutoSize = true;
            this.CBoxSaturday.Location = new System.Drawing.Point(270, 32);
            this.CBoxSaturday.Name = "CBoxSaturday";
            this.CBoxSaturday.Size = new System.Drawing.Size(42, 19);
            this.CBoxSaturday.TabIndex = 55;
            this.CBoxSaturday.Tag = "Sat-6";
            this.CBoxSaturday.Text = "Sat";
            this.CBoxSaturday.UseVisualStyleBackColor = true;
            // 
            // CBoxFriday
            // 
            this.CBoxFriday.AutoSize = true;
            this.CBoxFriday.Location = new System.Drawing.Point(225, 32);
            this.CBoxFriday.Name = "CBoxFriday";
            this.CBoxFriday.Size = new System.Drawing.Size(39, 19);
            this.CBoxFriday.TabIndex = 54;
            this.CBoxFriday.Tag = "Fri-5";
            this.CBoxFriday.Text = "Fri";
            this.CBoxFriday.UseVisualStyleBackColor = true;
            // 
            // CBoxThursday
            // 
            this.CBoxThursday.AutoSize = true;
            this.CBoxThursday.Location = new System.Drawing.Point(173, 32);
            this.CBoxThursday.Name = "CBoxThursday";
            this.CBoxThursday.Size = new System.Drawing.Size(46, 19);
            this.CBoxThursday.TabIndex = 53;
            this.CBoxThursday.Tag = "Thu-4";
            this.CBoxThursday.Text = "Thu";
            this.CBoxThursday.UseVisualStyleBackColor = true;
            // 
            // CBoxWednesday
            // 
            this.CBoxWednesday.AutoSize = true;
            this.CBoxWednesday.Location = new System.Drawing.Point(117, 32);
            this.CBoxWednesday.Name = "CBoxWednesday";
            this.CBoxWednesday.Size = new System.Drawing.Size(50, 19);
            this.CBoxWednesday.TabIndex = 52;
            this.CBoxWednesday.Tag = "Wed-3";
            this.CBoxWednesday.Text = "Wed";
            this.CBoxWednesday.UseVisualStyleBackColor = true;
            // 
            // CBoxMonday
            // 
            this.CBoxMonday.AutoSize = true;
            this.CBoxMonday.Location = new System.Drawing.Point(9, 32);
            this.CBoxMonday.Name = "CBoxMonday";
            this.CBoxMonday.Size = new System.Drawing.Size(51, 19);
            this.CBoxMonday.TabIndex = 50;
            this.CBoxMonday.Tag = "Mon-1";
            this.CBoxMonday.Text = "Mon";
            this.CBoxMonday.UseVisualStyleBackColor = true;
            // 
            // CBoxTuesday
            // 
            this.CBoxTuesday.AutoSize = true;
            this.CBoxTuesday.Location = new System.Drawing.Point(66, 32);
            this.CBoxTuesday.Name = "CBoxTuesday";
            this.CBoxTuesday.Size = new System.Drawing.Size(45, 19);
            this.CBoxTuesday.TabIndex = 51;
            this.CBoxTuesday.Tag = "Tue-2";
            this.CBoxTuesday.Text = "Tue";
            this.CBoxTuesday.UseVisualStyleBackColor = true;
            // 
            // TboxShiftNumberOfHrs
            // 
            this.TboxShiftNumberOfHrs.DecimalPlaces = 2;
            this.TboxShiftNumberOfHrs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxShiftNumberOfHrs.Location = new System.Drawing.Point(124, 97);
            this.TboxShiftNumberOfHrs.Name = "TboxShiftNumberOfHrs";
            this.TboxShiftNumberOfHrs.Size = new System.Drawing.Size(162, 29);
            this.TboxShiftNumberOfHrs.TabIndex = 8;
            // 
            // CBoxBreakTimes
            // 
            this.CBoxBreakTimes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxBreakTimes.Location = new System.Drawing.Point(502, 59);
            this.CBoxBreakTimes.Name = "CBoxBreakTimes";
            this.CBoxBreakTimes.Size = new System.Drawing.Size(162, 29);
            this.CBoxBreakTimes.TabIndex = 8;
            // 
            // CboxDisable
            // 
            this.CboxDisable.AutoSize = true;
            this.CboxDisable.ForeColor = System.Drawing.Color.Black;
            this.CboxDisable.Location = new System.Drawing.Point(763, 97);
            this.CboxDisable.Name = "CboxDisable";
            this.CboxDisable.Size = new System.Drawing.Size(64, 19);
            this.CboxDisable.TabIndex = 49;
            this.CboxDisable.Text = "Disable";
            this.CboxDisable.UseVisualStyleBackColor = true;
            this.CboxDisable.Visible = false;
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(763, 116);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdate.TabIndex = 48;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            this.BtnCancelUpdate.Click += new System.EventHandler(this.BtnCancelUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(20, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "Shift Hrs";
            // 
            // BtnSaveWorkShift
            // 
            this.BtnSaveWorkShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveWorkShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveWorkShift.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveWorkShift.ForeColor = System.Drawing.Color.White;
            this.BtnSaveWorkShift.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveWorkShift.Location = new System.Drawing.Point(888, 116);
            this.BtnSaveWorkShift.Name = "BtnSaveWorkShift";
            this.BtnSaveWorkShift.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveWorkShift.TabIndex = 47;
            this.BtnSaveWorkShift.Text = "Save";
            this.BtnSaveWorkShift.UseVisualStyleBackColor = false;
            this.BtnSaveWorkShift.Click += new System.EventHandler(this.BtnSaveWorkShift_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(361, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 21);
            this.label7.TabIndex = 35;
            this.label7.Text = "Breaktime Hours";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(361, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "Breaktime";
            // 
            // DTPickerShiftBreaktime
            // 
            this.DTPickerShiftBreaktime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DTPickerShiftBreaktime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DTPickerShiftBreaktime.Location = new System.Drawing.Point(502, 23);
            this.DTPickerShiftBreaktime.Name = "DTPickerShiftBreaktime";
            this.DTPickerShiftBreaktime.ShowUpDown = true;
            this.DTPickerShiftBreaktime.Size = new System.Drawing.Size(162, 29);
            this.DTPickerShiftBreaktime.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 27;
            this.label1.Text = "Start time";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(20, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 21);
            this.label9.TabIndex = 26;
            this.label9.Text = "Shift";
            // 
            // TboxShiftTitle
            // 
            this.TboxShiftTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxShiftTitle.Location = new System.Drawing.Point(124, 23);
            this.TboxShiftTitle.Name = "TboxShiftTitle";
            this.TboxShiftTitle.Size = new System.Drawing.Size(217, 29);
            this.TboxShiftTitle.TabIndex = 6;
            // 
            // DGVWorkShifts
            // 
            this.DGVWorkShifts.AllowUserToAddRows = false;
            this.DGVWorkShifts.AllowUserToDeleteRows = false;
            this.DGVWorkShifts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVWorkShifts.Location = new System.Drawing.Point(11, 303);
            this.DGVWorkShifts.Name = "DGVWorkShifts";
            this.DGVWorkShifts.ReadOnly = true;
            this.DGVWorkShifts.RowTemplate.Height = 25;
            this.DGVWorkShifts.Size = new System.Drawing.Size(1037, 201);
            this.DGVWorkShifts.TabIndex = 7;
            this.DGVWorkShifts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVWorkShifts_CellClick);
            // 
            // WorkShiftCRUDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DGVWorkShifts);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "WorkShiftCRUDControl";
            this.Size = new System.Drawing.Size(1067, 524);
            this.Load += new System.EventHandler(this.WorkShiftCRUDControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupPanelShiftDays.ResumeLayout(false);
            this.GroupPanelShiftDays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TboxShiftNumberOfHrs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVWorkShifts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DTPickerShiftStartTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGVWorkShifts;
        private System.Windows.Forms.TextBox TboxShiftTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DTPickerShiftBreaktime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.Button BtnSaveWorkShift;
        private System.Windows.Forms.CheckBox CboxDisable;
        private System.Windows.Forms.ComboBox CBoxBreakTimes;
        private System.Windows.Forms.NumericUpDown TboxShiftNumberOfHrs;
        private System.Windows.Forms.GroupBox GroupPanelShiftDays;
        private System.Windows.Forms.CheckBox CBoxSunday;
        private System.Windows.Forms.CheckBox CBoxSaturday;
        private System.Windows.Forms.CheckBox CBoxFriday;
        private System.Windows.Forms.CheckBox CBoxThursday;
        private System.Windows.Forms.CheckBox CBoxWednesday;
        private System.Windows.Forms.CheckBox CBoxMonday;
        private System.Windows.Forms.CheckBox CBoxTuesday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTPickerEarlyTimeOut;
        private System.Windows.Forms.DateTimePicker DTPickerLateTimeIn;
    }
}
