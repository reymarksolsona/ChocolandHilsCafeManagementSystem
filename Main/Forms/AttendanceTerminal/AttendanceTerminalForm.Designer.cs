
namespace Main.Forms.AttendanceTerminal
{
    partial class AttendanceTerminalForm
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
            this.panelSecondaryBanner = new System.Windows.Forms.Panel();
            this.LblCurrentTime = new System.Windows.Forms.Label();
            this.LblCurrentDate = new System.Windows.Forms.Label();
            this.LblRenderedFormTitle = new System.Windows.Forms.Label();
            this.LViewAttendanceHistory = new System.Windows.Forms.ListView();
            this.LVColumnDate = new System.Windows.Forms.ColumnHeader();
            this.LVColumnEmployeeNum = new System.Windows.Forms.ColumnHeader();
            this.LVColumnEmployeeName = new System.Windows.Forms.ColumnHeader();
            this.LVColumnShift = new System.Windows.Forms.ColumnHeader();
            this.LVColumnShiftTime = new System.Windows.Forms.ColumnHeader();
            this.LVColumnFirstHalf = new System.Windows.Forms.ColumnHeader();
            this.LVColumnSecondHalf = new System.Windows.Forms.ColumnHeader();
            this.LVColumnRenderHrs = new System.Windows.Forms.ColumnHeader();
            this.LVColumnLate = new System.Windows.Forms.ColumnHeader();
            this.LVColumnUnderTime = new System.Windows.Forms.ColumnHeader();
            this.LVColumnOvertime = new System.Windows.Forms.ColumnHeader();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TBoxCurrentEmployeeNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RBtnTimeIN = new System.Windows.Forms.RadioButton();
            this.RBtnTimeOUT = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.LblCurrentEmployeeSchedule = new System.Windows.Forms.Label();
            this.DPickerTesting = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnFilterAttendance = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.DPickerFilterAttendanceEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.DPickerFilterAttendanceStart = new System.Windows.Forms.DateTimePicker();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.GBoxEditEmployeeAttendanceControls = new System.Windows.Forms.GroupBox();
            this.BtnUpdateEmployeeAttendance = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DPicTimeEditAttendance = new System.Windows.Forms.DateTimePicker();
            this.DPickerAttendanceDateEditAttendance = new System.Windows.Forms.DateTimePicker();
            this.RBtnTimeOutEditAttendance = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.TboxEditAttendanceEmployeeNumber = new System.Windows.Forms.TextBox();
            this.RBtnTimeINEditAttendance = new System.Windows.Forms.RadioButton();
            this.CBoxPositions = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.panelSecondaryBanner.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.GBoxEditEmployeeAttendanceControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSecondaryBanner
            // 
            this.panelSecondaryBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelSecondaryBanner.Controls.Add(this.LblCurrentTime);
            this.panelSecondaryBanner.Controls.Add(this.LblCurrentDate);
            this.panelSecondaryBanner.Controls.Add(this.LblRenderedFormTitle);
            this.panelSecondaryBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSecondaryBanner.Location = new System.Drawing.Point(0, 0);
            this.panelSecondaryBanner.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSecondaryBanner.Name = "panelSecondaryBanner";
            this.panelSecondaryBanner.Size = new System.Drawing.Size(1693, 158);
            this.panelSecondaryBanner.TabIndex = 2;
            // 
            // LblCurrentTime
            // 
            this.LblCurrentTime.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentTime.ForeColor = System.Drawing.Color.White;
            this.LblCurrentTime.Location = new System.Drawing.Point(1101, 32);
            this.LblCurrentTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCurrentTime.Name = "LblCurrentTime";
            this.LblCurrentTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCurrentTime.Size = new System.Drawing.Size(414, 103);
            this.LblCurrentTime.TabIndex = 2;
            this.LblCurrentTime.Text = "-";
            this.LblCurrentTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblCurrentDate
            // 
            this.LblCurrentDate.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentDate.ForeColor = System.Drawing.Color.White;
            this.LblCurrentDate.Location = new System.Drawing.Point(17, 85);
            this.LblCurrentDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCurrentDate.Name = "LblCurrentDate";
            this.LblCurrentDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCurrentDate.Size = new System.Drawing.Size(473, 50);
            this.LblCurrentDate.TabIndex = 1;
            this.LblCurrentDate.Text = "-";
            this.LblCurrentDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblRenderedFormTitle
            // 
            this.LblRenderedFormTitle.AutoSize = true;
            this.LblRenderedFormTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRenderedFormTitle.ForeColor = System.Drawing.Color.White;
            this.LblRenderedFormTitle.Location = new System.Drawing.Point(17, 15);
            this.LblRenderedFormTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRenderedFormTitle.Name = "LblRenderedFormTitle";
            this.LblRenderedFormTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LblRenderedFormTitle.Size = new System.Drawing.Size(328, 45);
            this.LblRenderedFormTitle.TabIndex = 0;
            this.LblRenderedFormTitle.Text = "Attendance Terminal";
            // 
            // LViewAttendanceHistory
            // 
            this.LViewAttendanceHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LVColumnDate,
            this.LVColumnEmployeeNum,
            this.LVColumnEmployeeName,
            this.LVColumnShift,
            this.LVColumnShiftTime,
            this.LVColumnFirstHalf,
            this.LVColumnSecondHalf,
            this.LVColumnRenderHrs,
            this.LVColumnLate,
            this.LVColumnUnderTime,
            this.LVColumnOvertime});
            this.LViewAttendanceHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LViewAttendanceHistory.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LViewAttendanceHistory.FullRowSelect = true;
            this.LViewAttendanceHistory.GridLines = true;
            this.LViewAttendanceHistory.HideSelection = false;
            this.LViewAttendanceHistory.Location = new System.Drawing.Point(0, 474);
            this.LViewAttendanceHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LViewAttendanceHistory.Name = "LViewAttendanceHistory";
            this.LViewAttendanceHistory.Size = new System.Drawing.Size(1693, 576);
            this.LViewAttendanceHistory.TabIndex = 4;
            this.LViewAttendanceHistory.UseCompatibleStateImageBehavior = false;
            this.LViewAttendanceHistory.View = System.Windows.Forms.View.Details;
            // 
            // LVColumnDate
            // 
            this.LVColumnDate.Text = "Date";
            this.LVColumnDate.Width = 70;
            // 
            // LVColumnEmployeeNum
            // 
            this.LVColumnEmployeeNum.Text = "Employee #";
            this.LVColumnEmployeeNum.Width = 120;
            // 
            // LVColumnEmployeeName
            // 
            this.LVColumnEmployeeName.Text = "Name";
            this.LVColumnEmployeeName.Width = 120;
            // 
            // LVColumnShift
            // 
            this.LVColumnShift.Text = "Shift";
            this.LVColumnShift.Width = 150;
            // 
            // LVColumnShiftTime
            // 
            this.LVColumnShiftTime.Text = "Shift Time";
            this.LVColumnShiftTime.Width = 150;
            // 
            // LVColumnFirstHalf
            // 
            this.LVColumnFirstHalf.Text = "First halfday";
            this.LVColumnFirstHalf.Width = 100;
            // 
            // LVColumnSecondHalf
            // 
            this.LVColumnSecondHalf.Text = "Second Halfday";
            this.LVColumnSecondHalf.Width = 100;
            // 
            // LVColumnRenderHrs
            // 
            this.LVColumnRenderHrs.Text = "Hours";
            // 
            // LVColumnLate
            // 
            this.LVColumnLate.Text = "Late";
            // 
            // LVColumnUnderTime
            // 
            this.LVColumnUnderTime.Text = "UT";
            // 
            // LVColumnOvertime
            // 
            this.LVColumnOvertime.Text = "OT";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TBoxCurrentEmployeeNumber
            // 
            this.TBoxCurrentEmployeeNumber.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TBoxCurrentEmployeeNumber.Location = new System.Drawing.Point(317, 119);
            this.TBoxCurrentEmployeeNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBoxCurrentEmployeeNumber.Name = "TBoxCurrentEmployeeNumber";
            this.TBoxCurrentEmployeeNumber.Size = new System.Drawing.Size(638, 49);
            this.TBoxCurrentEmployeeNumber.TabIndex = 5;
            this.TBoxCurrentEmployeeNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBoxCurrentEmployeeNumber_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(64, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Employee Number";
            // 
            // RBtnTimeIN
            // 
            this.RBtnTimeIN.AutoSize = true;
            this.RBtnTimeIN.Checked = true;
            this.RBtnTimeIN.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBtnTimeIN.Location = new System.Drawing.Point(317, 9);
            this.RBtnTimeIN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RBtnTimeIN.Name = "RBtnTimeIN";
            this.RBtnTimeIN.Size = new System.Drawing.Size(132, 40);
            this.RBtnTimeIN.TabIndex = 7;
            this.RBtnTimeIN.TabStop = true;
            this.RBtnTimeIN.Text = "Time-IN";
            this.RBtnTimeIN.UseVisualStyleBackColor = true;
            // 
            // RBtnTimeOUT
            // 
            this.RBtnTimeOUT.AutoSize = true;
            this.RBtnTimeOUT.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBtnTimeOUT.Location = new System.Drawing.Point(496, 9);
            this.RBtnTimeOUT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RBtnTimeOUT.Name = "RBtnTimeOUT";
            this.RBtnTimeOUT.Size = new System.Drawing.Size(158, 40);
            this.RBtnTimeOUT.TabIndex = 8;
            this.RBtnTimeOUT.TabStop = true;
            this.RBtnTimeOUT.Text = "Time-OUT";
            this.RBtnTimeOUT.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Shift Schedule";
            // 
            // LblCurrentEmployeeSchedule
            // 
            this.LblCurrentEmployeeSchedule.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentEmployeeSchedule.Location = new System.Drawing.Point(317, 192);
            this.LblCurrentEmployeeSchedule.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCurrentEmployeeSchedule.Name = "LblCurrentEmployeeSchedule";
            this.LblCurrentEmployeeSchedule.Size = new System.Drawing.Size(640, 58);
            this.LblCurrentEmployeeSchedule.TabIndex = 10;
            this.LblCurrentEmployeeSchedule.Text = "-";
            // 
            // DPickerTesting
            // 
            this.DPickerTesting.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DPickerTesting.Location = new System.Drawing.Point(1437, 108);
            this.DPickerTesting.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DPickerTesting.Name = "DPickerTesting";
            this.DPickerTesting.Size = new System.Drawing.Size(158, 39);
            this.DPickerTesting.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1437, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 32);
            this.label3.TabIndex = 11;
            this.label3.Text = "Testing Time";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 158);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1676, 308);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CBoxPositions);
            this.tabPage1.Controls.Add(this.label37);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.DPickerTesting);
            this.tabPage1.Controls.Add(this.RBtnTimeOUT);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.LblCurrentEmployeeSchedule);
            this.tabPage1.Controls.Add(this.TBoxCurrentEmployeeNumber);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.RBtnTimeIN);
            this.tabPage1.Location = new System.Drawing.Point(4, 41);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1668, 263);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "IN/OUT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnFilterAttendance);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.DPickerFilterAttendanceEnd);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.DPickerFilterAttendanceStart);
            this.tabPage2.Location = new System.Drawing.Point(4, 41);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1668, 263);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnFilterAttendance
            // 
            this.BtnFilterAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnFilterAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilterAttendance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnFilterAttendance.ForeColor = System.Drawing.Color.White;
            this.BtnFilterAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFilterAttendance.Location = new System.Drawing.Point(543, 32);
            this.BtnFilterAttendance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnFilterAttendance.Name = "BtnFilterAttendance";
            this.BtnFilterAttendance.Size = new System.Drawing.Size(164, 52);
            this.BtnFilterAttendance.TabIndex = 40;
            this.BtnFilterAttendance.Text = "Search";
            this.BtnFilterAttendance.UseVisualStyleBackColor = false;
            this.BtnFilterAttendance.Click += new System.EventHandler(this.BtnFilterAttendance_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 32);
            this.label5.TabIndex = 15;
            this.label5.Text = "To";
            // 
            // DPickerFilterAttendanceEnd
            // 
            this.DPickerFilterAttendanceEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerFilterAttendanceEnd.Location = new System.Drawing.Point(351, 35);
            this.DPickerFilterAttendanceEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DPickerFilterAttendanceEnd.Name = "DPickerFilterAttendanceEnd";
            this.DPickerFilterAttendanceEnd.Size = new System.Drawing.Size(158, 39);
            this.DPickerFilterAttendanceEnd.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 45);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "From";
            // 
            // DPickerFilterAttendanceStart
            // 
            this.DPickerFilterAttendanceStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerFilterAttendanceStart.Location = new System.Drawing.Point(119, 35);
            this.DPickerFilterAttendanceStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DPickerFilterAttendanceStart.Name = "DPickerFilterAttendanceStart";
            this.DPickerFilterAttendanceStart.Size = new System.Drawing.Size(158, 39);
            this.DPickerFilterAttendanceStart.TabIndex = 12;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.GBoxEditEmployeeAttendanceControls);
            this.tabPage3.Location = new System.Drawing.Point(4, 41);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage3.Size = new System.Drawing.Size(1668, 263);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Edit Employee Attendance";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // GBoxEditEmployeeAttendanceControls
            // 
            this.GBoxEditEmployeeAttendanceControls.Controls.Add(this.BtnUpdateEmployeeAttendance);
            this.GBoxEditEmployeeAttendanceControls.Controls.Add(this.label8);
            this.GBoxEditEmployeeAttendanceControls.Controls.Add(this.label7);
            this.GBoxEditEmployeeAttendanceControls.Controls.Add(this.DPicTimeEditAttendance);
            this.GBoxEditEmployeeAttendanceControls.Controls.Add(this.DPickerAttendanceDateEditAttendance);
            this.GBoxEditEmployeeAttendanceControls.Controls.Add(this.RBtnTimeOutEditAttendance);
            this.GBoxEditEmployeeAttendanceControls.Controls.Add(this.label6);
            this.GBoxEditEmployeeAttendanceControls.Controls.Add(this.TboxEditAttendanceEmployeeNumber);
            this.GBoxEditEmployeeAttendanceControls.Controls.Add(this.RBtnTimeINEditAttendance);
            this.GBoxEditEmployeeAttendanceControls.Location = new System.Drawing.Point(26, 28);
            this.GBoxEditEmployeeAttendanceControls.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GBoxEditEmployeeAttendanceControls.Name = "GBoxEditEmployeeAttendanceControls";
            this.GBoxEditEmployeeAttendanceControls.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GBoxEditEmployeeAttendanceControls.Size = new System.Drawing.Size(1439, 195);
            this.GBoxEditEmployeeAttendanceControls.TabIndex = 0;
            this.GBoxEditEmployeeAttendanceControls.TabStop = false;
            this.GBoxEditEmployeeAttendanceControls.Text = "Edit controls";
            this.GBoxEditEmployeeAttendanceControls.Visible = false;
            // 
            // BtnUpdateEmployeeAttendance
            // 
            this.BtnUpdateEmployeeAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnUpdateEmployeeAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdateEmployeeAttendance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnUpdateEmployeeAttendance.ForeColor = System.Drawing.Color.White;
            this.BtnUpdateEmployeeAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpdateEmployeeAttendance.Location = new System.Drawing.Point(1070, 92);
            this.BtnUpdateEmployeeAttendance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnUpdateEmployeeAttendance.Name = "BtnUpdateEmployeeAttendance";
            this.BtnUpdateEmployeeAttendance.Size = new System.Drawing.Size(164, 52);
            this.BtnUpdateEmployeeAttendance.TabIndex = 41;
            this.BtnUpdateEmployeeAttendance.Text = "Submit";
            this.BtnUpdateEmployeeAttendance.UseVisualStyleBackColor = false;
            this.BtnUpdateEmployeeAttendance.Click += new System.EventHandler(this.BtnUpdateEmployeeAttendance_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(806, 102);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 32);
            this.label8.TabIndex = 16;
            this.label8.Text = "Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(561, 105);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 32);
            this.label7.TabIndex = 15;
            this.label7.Text = "Date";
            // 
            // DPicTimeEditAttendance
            // 
            this.DPicTimeEditAttendance.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DPicTimeEditAttendance.Location = new System.Drawing.Point(877, 95);
            this.DPicTimeEditAttendance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DPicTimeEditAttendance.Name = "DPicTimeEditAttendance";
            this.DPicTimeEditAttendance.Size = new System.Drawing.Size(158, 39);
            this.DPicTimeEditAttendance.TabIndex = 14;
            // 
            // DPickerAttendanceDateEditAttendance
            // 
            this.DPickerAttendanceDateEditAttendance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerAttendanceDateEditAttendance.Location = new System.Drawing.Point(630, 95);
            this.DPickerAttendanceDateEditAttendance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DPickerAttendanceDateEditAttendance.Name = "DPickerAttendanceDateEditAttendance";
            this.DPickerAttendanceDateEditAttendance.Size = new System.Drawing.Size(158, 39);
            this.DPickerAttendanceDateEditAttendance.TabIndex = 13;
            // 
            // RBtnTimeOutEditAttendance
            // 
            this.RBtnTimeOutEditAttendance.AutoSize = true;
            this.RBtnTimeOutEditAttendance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBtnTimeOutEditAttendance.Location = new System.Drawing.Point(377, 45);
            this.RBtnTimeOutEditAttendance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RBtnTimeOutEditAttendance.Name = "RBtnTimeOutEditAttendance";
            this.RBtnTimeOutEditAttendance.Size = new System.Drawing.Size(149, 36);
            this.RBtnTimeOutEditAttendance.TabIndex = 12;
            this.RBtnTimeOutEditAttendance.TabStop = true;
            this.RBtnTimeOutEditAttendance.Text = "Time-OUT";
            this.RBtnTimeOutEditAttendance.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(27, 102);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(214, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "Employee Number";
            // 
            // TboxEditAttendanceEmployeeNumber
            // 
            this.TboxEditAttendanceEmployeeNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxEditAttendanceEmployeeNumber.Location = new System.Drawing.Point(236, 97);
            this.TboxEditAttendanceEmployeeNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TboxEditAttendanceEmployeeNumber.Name = "TboxEditAttendanceEmployeeNumber";
            this.TboxEditAttendanceEmployeeNumber.Size = new System.Drawing.Size(295, 39);
            this.TboxEditAttendanceEmployeeNumber.TabIndex = 9;
            // 
            // RBtnTimeINEditAttendance
            // 
            this.RBtnTimeINEditAttendance.AutoSize = true;
            this.RBtnTimeINEditAttendance.Checked = true;
            this.RBtnTimeINEditAttendance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RBtnTimeINEditAttendance.Location = new System.Drawing.Point(236, 45);
            this.RBtnTimeINEditAttendance.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RBtnTimeINEditAttendance.Name = "RBtnTimeINEditAttendance";
            this.RBtnTimeINEditAttendance.Size = new System.Drawing.Size(126, 36);
            this.RBtnTimeINEditAttendance.TabIndex = 11;
            this.RBtnTimeINEditAttendance.TabStop = true;
            this.RBtnTimeINEditAttendance.Text = "Time-IN";
            this.RBtnTimeINEditAttendance.UseVisualStyleBackColor = true;
            // 
            // CBoxPositions
            // 
            this.CBoxPositions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBoxPositions.FormattingEnabled = true;
            this.CBoxPositions.Location = new System.Drawing.Point(317, 59);
            this.CBoxPositions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxPositions.Name = "CBoxPositions";
            this.CBoxPositions.Size = new System.Drawing.Size(638, 40);
            this.CBoxPositions.TabIndex = 71;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(137, 59);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(106, 36);
            this.label37.TabIndex = 70;
            this.label37.Text = "Position";
            // 
            // AttendanceTerminalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1693, 1050);
            this.Controls.Add(this.LViewAttendanceHistory);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelSecondaryBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AttendanceTerminalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AttendanceTerminalForm";
            this.Load += new System.EventHandler(this.AttendanceTerminalForm_Load);
            this.panelSecondaryBanner.ResumeLayout(false);
            this.panelSecondaryBanner.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.GBoxEditEmployeeAttendanceControls.ResumeLayout(false);
            this.GBoxEditEmployeeAttendanceControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSecondaryBanner;
        private System.Windows.Forms.Label LblCurrentDate;
        private System.Windows.Forms.Label LblRenderedFormTitle;
        private System.Windows.Forms.ListView LViewAttendanceHistory;
        private System.Windows.Forms.ColumnHeader LVColumnEmployeeNum;
        private System.Windows.Forms.ColumnHeader LVColumnEmployeeName;
        private System.Windows.Forms.ColumnHeader LVColumnFirstHalf;
        private System.Windows.Forms.ColumnHeader LVColumnRenderHrs;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LblCurrentTime;
        private System.Windows.Forms.TextBox TBoxCurrentEmployeeNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RBtnTimeIN;
        private System.Windows.Forms.RadioButton RBtnTimeOUT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblCurrentEmployeeSchedule;
        private System.Windows.Forms.DateTimePicker DPickerTesting;
        private System.Windows.Forms.ColumnHeader LVColumnSecondHalf;
        private System.Windows.Forms.ColumnHeader LVColumnLate;
        private System.Windows.Forms.ColumnHeader LVColumnUnderTime;
        private System.Windows.Forms.ColumnHeader LVColumnOvertime;
        private System.Windows.Forms.ColumnHeader LVColumnShift;
        private System.Windows.Forms.ColumnHeader LVColumnShiftTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button BtnFilterAttendance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DPickerFilterAttendanceEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DPickerFilterAttendanceStart;
        private System.Windows.Forms.ColumnHeader LVColumnDate;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox GBoxEditEmployeeAttendanceControls;
        private System.Windows.Forms.RadioButton RBtnTimeOutEditAttendance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TboxEditAttendanceEmployeeNumber;
        private System.Windows.Forms.RadioButton RBtnTimeINEditAttendance;
        private System.Windows.Forms.DateTimePicker DPicTimeEditAttendance;
        private System.Windows.Forms.DateTimePicker DPickerAttendanceDateEditAttendance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnUpdateEmployeeAttendance;
        private System.Windows.Forms.ComboBox CBoxPositions;
        private System.Windows.Forms.Label label37;
    }
}