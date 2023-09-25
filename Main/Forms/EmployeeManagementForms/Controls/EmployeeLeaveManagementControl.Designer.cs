
namespace Main.Forms.EmployeeManagementForms.Controls
{
    partial class EmployeeLeaveManagementControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblEmployeePosition = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.BtnSearchEmployee = new System.Windows.Forms.Button();
            this.LblSelectedEmployeeFullname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TboxEmployeeToSearch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPageFileLeave = new System.Windows.Forms.TabPage();
            this.LblEmployeeLeaveNumberOfDays = new System.Windows.Forms.Label();
            this.BtnSaveEmployeeLeave = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.DPickerDurationEndDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.DPickerDurationStartDate = new System.Windows.Forms.DateTimePicker();
            this.LblLeaveDayCounts = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblRemainingLeave = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CBoxLeaveTypes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TboxLeaveReason = new System.Windows.Forms.TextBox();
            this.TabPageLeaveHistory = new System.Windows.Forms.TabPage();
            this.FLPanelEmployeeLeaveHistory = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CBoxYearList = new System.Windows.Forms.ComboBox();
            this.BtnDeleteEmployeeLeaveHistory = new System.Windows.Forms.Button();
            this.BtnFilterEmployeeLeaveHistory = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPageFileLeave.SuspendLayout();
            this.TabPageLeaveHistory.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(821, 94);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Employee Leaves Management";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.LblEmployeePosition);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.BtnSearchEmployee);
            this.panel2.Controls.Add(this.LblSelectedEmployeeFullname);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TboxEmployeeToSearch);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 110);
            this.panel2.TabIndex = 6;
            // 
            // LblEmployeePosition
            // 
            this.LblEmployeePosition.AutoSize = true;
            this.LblEmployeePosition.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEmployeePosition.ForeColor = System.Drawing.Color.Black;
            this.LblEmployeePosition.Location = new System.Drawing.Point(217, 72);
            this.LblEmployeePosition.Name = "LblEmployeePosition";
            this.LblEmployeePosition.Size = new System.Drawing.Size(16, 21);
            this.LblEmployeePosition.TabIndex = 50;
            this.LblEmployeePosition.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(121, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 21);
            this.label14.TabIndex = 49;
            this.label14.Text = "Position";
            // 
            // BtnSearchEmployee
            // 
            this.BtnSearchEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSearchEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchEmployee.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSearchEmployee.ForeColor = System.Drawing.Color.White;
            this.BtnSearchEmployee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearchEmployee.Location = new System.Drawing.Point(435, 6);
            this.BtnSearchEmployee.Name = "BtnSearchEmployee";
            this.BtnSearchEmployee.Size = new System.Drawing.Size(115, 37);
            this.BtnSearchEmployee.TabIndex = 48;
            this.BtnSearchEmployee.Text = "Search";
            this.BtnSearchEmployee.UseVisualStyleBackColor = false;
            this.BtnSearchEmployee.Click += new System.EventHandler(this.BtnSearchEmployee_Click);
            // 
            // LblSelectedEmployeeFullname
            // 
            this.LblSelectedEmployeeFullname.AutoSize = true;
            this.LblSelectedEmployeeFullname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblSelectedEmployeeFullname.ForeColor = System.Drawing.Color.Black;
            this.LblSelectedEmployeeFullname.Location = new System.Drawing.Point(217, 42);
            this.LblSelectedEmployeeFullname.Name = "LblSelectedEmployeeFullname";
            this.LblSelectedEmployeeFullname.Size = new System.Drawing.Size(16, 21);
            this.LblSelectedEmployeeFullname.TabIndex = 30;
            this.LblSelectedEmployeeFullname.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(121, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 29;
            this.label1.Text = "Fullname";
            // 
            // TboxEmployeeToSearch
            // 
            this.TboxEmployeeToSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxEmployeeToSearch.Location = new System.Drawing.Point(217, 10);
            this.TboxEmployeeToSearch.Name = "TboxEmployeeToSearch";
            this.TboxEmployeeToSearch.Size = new System.Drawing.Size(201, 29);
            this.TboxEmployeeToSearch.TabIndex = 28;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(18, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 21);
            this.label9.TabIndex = 27;
            this.label9.Text = "Enter employee number";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TabPageFileLeave);
            this.tabControl1.Controls.Add(this.TabPageLeaveHistory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 204);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(821, 528);
            this.tabControl1.TabIndex = 7;
            // 
            // TabPageFileLeave
            // 
            this.TabPageFileLeave.Controls.Add(this.LblEmployeeLeaveNumberOfDays);
            this.TabPageFileLeave.Controls.Add(this.BtnSaveEmployeeLeave);
            this.TabPageFileLeave.Controls.Add(this.label10);
            this.TabPageFileLeave.Controls.Add(this.DPickerDurationEndDate);
            this.TabPageFileLeave.Controls.Add(this.label8);
            this.TabPageFileLeave.Controls.Add(this.DPickerDurationStartDate);
            this.TabPageFileLeave.Controls.Add(this.LblLeaveDayCounts);
            this.TabPageFileLeave.Controls.Add(this.label6);
            this.TabPageFileLeave.Controls.Add(this.LblRemainingLeave);
            this.TabPageFileLeave.Controls.Add(this.label5);
            this.TabPageFileLeave.Controls.Add(this.CBoxLeaveTypes);
            this.TabPageFileLeave.Controls.Add(this.label4);
            this.TabPageFileLeave.Controls.Add(this.label3);
            this.TabPageFileLeave.Controls.Add(this.TboxLeaveReason);
            this.TabPageFileLeave.Location = new System.Drawing.Point(4, 30);
            this.TabPageFileLeave.Name = "TabPageFileLeave";
            this.TabPageFileLeave.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageFileLeave.Size = new System.Drawing.Size(813, 494);
            this.TabPageFileLeave.TabIndex = 0;
            this.TabPageFileLeave.Text = "File leave";
            this.TabPageFileLeave.UseVisualStyleBackColor = true;
            // 
            // LblEmployeeLeaveNumberOfDays
            // 
            this.LblEmployeeLeaveNumberOfDays.AutoSize = true;
            this.LblEmployeeLeaveNumberOfDays.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEmployeeLeaveNumberOfDays.ForeColor = System.Drawing.Color.Black;
            this.LblEmployeeLeaveNumberOfDays.Location = new System.Drawing.Point(236, 269);
            this.LblEmployeeLeaveNumberOfDays.Name = "LblEmployeeLeaveNumberOfDays";
            this.LblEmployeeLeaveNumberOfDays.Size = new System.Drawing.Size(16, 21);
            this.LblEmployeeLeaveNumberOfDays.TabIndex = 50;
            this.LblEmployeeLeaveNumberOfDays.Text = "-";
            // 
            // BtnSaveEmployeeLeave
            // 
            this.BtnSaveEmployeeLeave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveEmployeeLeave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveEmployeeLeave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveEmployeeLeave.ForeColor = System.Drawing.Color.White;
            this.BtnSaveEmployeeLeave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveEmployeeLeave.Location = new System.Drawing.Point(582, 289);
            this.BtnSaveEmployeeLeave.Name = "BtnSaveEmployeeLeave";
            this.BtnSaveEmployeeLeave.Size = new System.Drawing.Size(115, 37);
            this.BtnSaveEmployeeLeave.TabIndex = 49;
            this.BtnSaveEmployeeLeave.Text = "Save";
            this.BtnSaveEmployeeLeave.UseVisualStyleBackColor = false;
            this.BtnSaveEmployeeLeave.Click += new System.EventHandler(this.BtnSaveEmployeeLeave_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(463, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 21);
            this.label10.TabIndex = 40;
            this.label10.Text = "To";
            // 
            // DPickerDurationEndDate
            // 
            this.DPickerDurationEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DPickerDurationEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerDurationEndDate.Location = new System.Drawing.Point(494, 226);
            this.DPickerDurationEndDate.Name = "DPickerDurationEndDate";
            this.DPickerDurationEndDate.Size = new System.Drawing.Size(203, 29);
            this.DPickerDurationEndDate.TabIndex = 39;
            this.DPickerDurationEndDate.ValueChanged += new System.EventHandler(this.DPickerDurationEndDate_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(91, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 21);
            this.label8.TabIndex = 38;
            this.label8.Text = "Duration";
            // 
            // DPickerDurationStartDate
            // 
            this.DPickerDurationStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DPickerDurationStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerDurationStartDate.Location = new System.Drawing.Point(236, 226);
            this.DPickerDurationStartDate.Name = "DPickerDurationStartDate";
            this.DPickerDurationStartDate.Size = new System.Drawing.Size(203, 29);
            this.DPickerDurationStartDate.TabIndex = 37;
            // 
            // LblLeaveDayCounts
            // 
            this.LblLeaveDayCounts.AutoSize = true;
            this.LblLeaveDayCounts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblLeaveDayCounts.ForeColor = System.Drawing.Color.Black;
            this.LblLeaveDayCounts.Location = new System.Drawing.Point(640, 72);
            this.LblLeaveDayCounts.Name = "LblLeaveDayCounts";
            this.LblLeaveDayCounts.Size = new System.Drawing.Size(19, 21);
            this.LblLeaveDayCounts.TabIndex = 36;
            this.LblLeaveDayCounts.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(513, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 21);
            this.label6.TabIndex = 35;
            this.label6.Text = "Maximum Days:";
            // 
            // LblRemainingLeave
            // 
            this.LblRemainingLeave.AutoSize = true;
            this.LblRemainingLeave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblRemainingLeave.ForeColor = System.Drawing.Color.Black;
            this.LblRemainingLeave.Location = new System.Drawing.Point(236, 117);
            this.LblRemainingLeave.Name = "LblRemainingLeave";
            this.LblRemainingLeave.Size = new System.Drawing.Size(19, 21);
            this.LblRemainingLeave.TabIndex = 34;
            this.LblRemainingLeave.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(91, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "Remaining Leave";
            // 
            // CBoxLeaveTypes
            // 
            this.CBoxLeaveTypes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxLeaveTypes.FormattingEnabled = true;
            this.CBoxLeaveTypes.Location = new System.Drawing.Point(236, 69);
            this.CBoxLeaveTypes.Name = "CBoxLeaveTypes";
            this.CBoxLeaveTypes.Size = new System.Drawing.Size(258, 29);
            this.CBoxLeaveTypes.TabIndex = 32;
            this.CBoxLeaveTypes.SelectedIndexChanged += new System.EventHandler(this.CBoxLeaveTypes_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(91, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "Reason";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(91, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 21);
            this.label3.TabIndex = 30;
            this.label3.Text = "Leave Type";
            // 
            // TboxLeaveReason
            // 
            this.TboxLeaveReason.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxLeaveReason.Location = new System.Drawing.Point(236, 147);
            this.TboxLeaveReason.Multiline = true;
            this.TboxLeaveReason.Name = "TboxLeaveReason";
            this.TboxLeaveReason.Size = new System.Drawing.Size(461, 60);
            this.TboxLeaveReason.TabIndex = 29;
            // 
            // TabPageLeaveHistory
            // 
            this.TabPageLeaveHistory.Controls.Add(this.FLPanelEmployeeLeaveHistory);
            this.TabPageLeaveHistory.Controls.Add(this.groupBox1);
            this.TabPageLeaveHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabPageLeaveHistory.Location = new System.Drawing.Point(4, 30);
            this.TabPageLeaveHistory.Name = "TabPageLeaveHistory";
            this.TabPageLeaveHistory.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageLeaveHistory.Size = new System.Drawing.Size(813, 494);
            this.TabPageLeaveHistory.TabIndex = 1;
            this.TabPageLeaveHistory.Text = "Leave History";
            this.TabPageLeaveHistory.UseVisualStyleBackColor = true;
            // 
            // FLPanelEmployeeLeaveHistory
            // 
            this.FLPanelEmployeeLeaveHistory.AutoScroll = true;
            this.FLPanelEmployeeLeaveHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPanelEmployeeLeaveHistory.Location = new System.Drawing.Point(3, 95);
            this.FLPanelEmployeeLeaveHistory.Name = "FLPanelEmployeeLeaveHistory";
            this.FLPanelEmployeeLeaveHistory.Size = new System.Drawing.Size(807, 396);
            this.FLPanelEmployeeLeaveHistory.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CBoxYearList);
            this.groupBox1.Controls.Add(this.BtnDeleteEmployeeLeaveHistory);
            this.groupBox1.Controls.Add(this.BtnFilterEmployeeLeaveHistory);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // CBoxYearList
            // 
            this.CBoxYearList.FormattingEnabled = true;
            this.CBoxYearList.Location = new System.Drawing.Point(114, 26);
            this.CBoxYearList.Name = "CBoxYearList";
            this.CBoxYearList.Size = new System.Drawing.Size(190, 29);
            this.CBoxYearList.TabIndex = 51;
            // 
            // BtnDeleteEmployeeLeaveHistory
            // 
            this.BtnDeleteEmployeeLeaveHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnDeleteEmployeeLeaveHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteEmployeeLeaveHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDeleteEmployeeLeaveHistory.ForeColor = System.Drawing.Color.White;
            this.BtnDeleteEmployeeLeaveHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDeleteEmployeeLeaveHistory.Location = new System.Drawing.Point(723, 55);
            this.BtnDeleteEmployeeLeaveHistory.Name = "BtnDeleteEmployeeLeaveHistory";
            this.BtnDeleteEmployeeLeaveHistory.Size = new System.Drawing.Size(78, 31);
            this.BtnDeleteEmployeeLeaveHistory.TabIndex = 50;
            this.BtnDeleteEmployeeLeaveHistory.Text = "Delete";
            this.BtnDeleteEmployeeLeaveHistory.UseVisualStyleBackColor = false;
            this.BtnDeleteEmployeeLeaveHistory.Visible = false;
            // 
            // BtnFilterEmployeeLeaveHistory
            // 
            this.BtnFilterEmployeeLeaveHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnFilterEmployeeLeaveHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilterEmployeeLeaveHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnFilterEmployeeLeaveHistory.ForeColor = System.Drawing.Color.White;
            this.BtnFilterEmployeeLeaveHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFilterEmployeeLeaveHistory.Location = new System.Drawing.Point(321, 24);
            this.BtnFilterEmployeeLeaveHistory.Name = "BtnFilterEmployeeLeaveHistory";
            this.BtnFilterEmployeeLeaveHistory.Size = new System.Drawing.Size(78, 31);
            this.BtnFilterEmployeeLeaveHistory.TabIndex = 49;
            this.BtnFilterEmployeeLeaveHistory.Text = "Filter";
            this.BtnFilterEmployeeLeaveHistory.UseVisualStyleBackColor = false;
            this.BtnFilterEmployeeLeaveHistory.Click += new System.EventHandler(this.BtnFilterEmployeeLeaveHistory_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(14, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 21);
            this.label12.TabIndex = 42;
            this.label12.Text = "Duration";
            // 
            // EmployeeLeaveManagementControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "EmployeeLeaveManagementControl";
            this.Size = new System.Drawing.Size(821, 732);
            this.Load += new System.EventHandler(this.EmployeeLeaveManagementControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPageFileLeave.ResumeLayout(false);
            this.TabPageFileLeave.PerformLayout();
            this.TabPageLeaveHistory.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblSelectedEmployeeFullname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TboxEmployeeToSearch;
        private System.Windows.Forms.Button BtnSearchEmployee;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TabPageFileLeave;
        private System.Windows.Forms.TabPage TabPageLeaveHistory;
        private System.Windows.Forms.Label LblLeaveDayCounts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblRemainingLeave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBoxLeaveTypes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TboxLeaveReason;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker DPickerDurationEndDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker DPickerDurationStartDate;
        private System.Windows.Forms.Button BtnSaveEmployeeLeave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnFilterEmployeeLeaveHistory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LblEmployeePosition;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button BtnDeleteEmployeeLeaveHistory;
        private System.Windows.Forms.Label LblEmployeeLeaveNumberOfDays;
        private System.Windows.Forms.ComboBox CBoxYearList;
        private System.Windows.Forms.FlowLayoutPanel FLPanelEmployeeLeaveHistory;
    }
}
