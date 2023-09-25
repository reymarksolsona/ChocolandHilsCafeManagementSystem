
namespace Main.Forms.EmployeeManagementForms.Controls
{
    partial class ManageEmpWorkScheduleControl
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DGVEmployeeList = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGVShiftList = new System.Windows.Forms.DataGridView();
            this.BtnSaveEmployeeShiftSchedule = new System.Windows.Forms.Button();
            this.GroupPanelShiftDays = new System.Windows.Forms.GroupBox();
            this.CBoxSunday = new System.Windows.Forms.CheckBox();
            this.CBoxSaturday = new System.Windows.Forms.CheckBox();
            this.CBoxFriday = new System.Windows.Forms.CheckBox();
            this.CBoxThursday = new System.Windows.Forms.CheckBox();
            this.CBoxWednesday = new System.Windows.Forms.CheckBox();
            this.CBoxMonday = new System.Windows.Forms.CheckBox();
            this.CBoxTuesday = new System.Windows.Forms.CheckBox();
            this.BtnSelectAllEmloyeesInShiftSchedTab = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnRefreshEmployees = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TbxSearchEmployeesInTab1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnDeleteAll = new System.Windows.Forms.Button();
            this.BtnRefreshEmployees2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TbxSearchEmployeesInTab2 = new System.Windows.Forms.TextBox();
            this.BtnUndoChanges = new System.Windows.Forms.Button();
            this.BtnSelectAllEmployees = new System.Windows.Forms.Button();
            this.BtnSaveWorkforceSchedule = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DGVScheduledWorkforceByDate = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DGVEmployeeListToSchedule = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnDeleteSchedule = new System.Windows.Forms.Button();
            this.BtnUpdateSelectedDateWorkForce = new System.Windows.Forms.Button();
            this.BtnGenerateWorkforceSchedule = new System.Windows.Forms.Button();
            this.LViewScheduleDates = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.DPicWorkScheduleEndTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DPicWorkScheduleStartFrom = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVShiftList)).BeginInit();
            this.GroupPanelShiftDays.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVScheduledWorkforceByDate)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeListToSchedule)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1235, 94);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Employee work schedule management";
            // 
            // DGVEmployeeList
            // 
            this.DGVEmployeeList.AllowUserToAddRows = false;
            this.DGVEmployeeList.AllowUserToDeleteRows = false;
            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVEmployeeList.Location = new System.Drawing.Point(0, 61);
            this.DGVEmployeeList.Name = "DGVEmployeeList";
            this.DGVEmployeeList.ReadOnly = true;
            this.DGVEmployeeList.RowTemplate.Height = 25;
            this.DGVEmployeeList.Size = new System.Drawing.Size(724, 557);
            this.DGVEmployeeList.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGVShiftList);
            this.groupBox2.Controls.Add(this.BtnSaveEmployeeShiftSchedule);
            this.groupBox2.Controls.Add(this.GroupPanelShiftDays);
            this.groupBox2.Location = new System.Drawing.Point(43, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 468);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shifts";
            // 
            // DGVShiftList
            // 
            this.DGVShiftList.AllowUserToAddRows = false;
            this.DGVShiftList.AllowUserToDeleteRows = false;
            this.DGVShiftList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVShiftList.Dock = System.Windows.Forms.DockStyle.Top;
            this.DGVShiftList.Location = new System.Drawing.Point(3, 23);
            this.DGVShiftList.Name = "DGVShiftList";
            this.DGVShiftList.ReadOnly = true;
            this.DGVShiftList.RowTemplate.Height = 25;
            this.DGVShiftList.Size = new System.Drawing.Size(417, 244);
            this.DGVShiftList.TabIndex = 53;
            this.DGVShiftList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVShiftList_CellClick);
            // 
            // BtnSaveEmployeeShiftSchedule
            // 
            this.BtnSaveEmployeeShiftSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveEmployeeShiftSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveEmployeeShiftSchedule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveEmployeeShiftSchedule.ForeColor = System.Drawing.Color.White;
            this.BtnSaveEmployeeShiftSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveEmployeeShiftSchedule.Location = new System.Drawing.Point(291, 415);
            this.BtnSaveEmployeeShiftSchedule.Name = "BtnSaveEmployeeShiftSchedule";
            this.BtnSaveEmployeeShiftSchedule.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveEmployeeShiftSchedule.TabIndex = 49;
            this.BtnSaveEmployeeShiftSchedule.Text = "Save";
            this.BtnSaveEmployeeShiftSchedule.UseVisualStyleBackColor = false;
            this.BtnSaveEmployeeShiftSchedule.Click += new System.EventHandler(this.BtnSaveEmployeeShiftSchedule_Click);
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
            this.GroupPanelShiftDays.Location = new System.Drawing.Point(16, 282);
            this.GroupPanelShiftDays.Name = "GroupPanelShiftDays";
            this.GroupPanelShiftDays.Size = new System.Drawing.Size(390, 74);
            this.GroupPanelShiftDays.TabIndex = 52;
            this.GroupPanelShiftDays.TabStop = false;
            this.GroupPanelShiftDays.Text = "Shift Days";
            // 
            // CBoxSunday
            // 
            this.CBoxSunday.AutoSize = true;
            this.CBoxSunday.Enabled = false;
            this.CBoxSunday.Location = new System.Drawing.Point(325, 32);
            this.CBoxSunday.Name = "CBoxSunday";
            this.CBoxSunday.Size = new System.Drawing.Size(52, 24);
            this.CBoxSunday.TabIndex = 56;
            this.CBoxSunday.Tag = "Sun-7";
            this.CBoxSunday.Text = "Sun";
            this.CBoxSunday.UseVisualStyleBackColor = true;
            // 
            // CBoxSaturday
            // 
            this.CBoxSaturday.AutoSize = true;
            this.CBoxSaturday.Enabled = false;
            this.CBoxSaturday.Location = new System.Drawing.Point(279, 32);
            this.CBoxSaturday.Name = "CBoxSaturday";
            this.CBoxSaturday.Size = new System.Drawing.Size(49, 24);
            this.CBoxSaturday.TabIndex = 55;
            this.CBoxSaturday.Tag = "Sat-6";
            this.CBoxSaturday.Text = "Sat";
            this.CBoxSaturday.UseVisualStyleBackColor = true;
            // 
            // CBoxFriday
            // 
            this.CBoxFriday.AutoSize = true;
            this.CBoxFriday.Enabled = false;
            this.CBoxFriday.Location = new System.Drawing.Point(233, 32);
            this.CBoxFriday.Name = "CBoxFriday";
            this.CBoxFriday.Size = new System.Drawing.Size(44, 24);
            this.CBoxFriday.TabIndex = 54;
            this.CBoxFriday.Tag = "Fri-5";
            this.CBoxFriday.Text = "Fri";
            this.CBoxFriday.UseVisualStyleBackColor = true;
            // 
            // CBoxThursday
            // 
            this.CBoxThursday.AutoSize = true;
            this.CBoxThursday.Enabled = false;
            this.CBoxThursday.Location = new System.Drawing.Point(175, 32);
            this.CBoxThursday.Name = "CBoxThursday";
            this.CBoxThursday.Size = new System.Drawing.Size(52, 24);
            this.CBoxThursday.TabIndex = 53;
            this.CBoxThursday.Tag = "Thu-4";
            this.CBoxThursday.Text = "Thu";
            this.CBoxThursday.UseVisualStyleBackColor = true;
            // 
            // CBoxWednesday
            // 
            this.CBoxWednesday.AutoSize = true;
            this.CBoxWednesday.Enabled = false;
            this.CBoxWednesday.Location = new System.Drawing.Point(119, 32);
            this.CBoxWednesday.Name = "CBoxWednesday";
            this.CBoxWednesday.Size = new System.Drawing.Size(58, 24);
            this.CBoxWednesday.TabIndex = 52;
            this.CBoxWednesday.Tag = "Wed-3";
            this.CBoxWednesday.Text = "Wed";
            this.CBoxWednesday.UseVisualStyleBackColor = true;
            // 
            // CBoxMonday
            // 
            this.CBoxMonday.AutoSize = true;
            this.CBoxMonday.Enabled = false;
            this.CBoxMonday.Location = new System.Drawing.Point(9, 32);
            this.CBoxMonday.Name = "CBoxMonday";
            this.CBoxMonday.Size = new System.Drawing.Size(58, 24);
            this.CBoxMonday.TabIndex = 50;
            this.CBoxMonday.Tag = "Mon-1";
            this.CBoxMonday.Text = "Mon";
            this.CBoxMonday.UseVisualStyleBackColor = true;
            // 
            // CBoxTuesday
            // 
            this.CBoxTuesday.AutoSize = true;
            this.CBoxTuesday.Enabled = false;
            this.CBoxTuesday.Location = new System.Drawing.Point(68, 32);
            this.CBoxTuesday.Name = "CBoxTuesday";
            this.CBoxTuesday.Size = new System.Drawing.Size(52, 24);
            this.CBoxTuesday.TabIndex = 51;
            this.CBoxTuesday.Tag = "Tue-2";
            this.CBoxTuesday.Text = "Tue";
            this.CBoxTuesday.UseVisualStyleBackColor = true;
            // 
            // BtnSelectAllEmloyeesInShiftSchedTab
            // 
            this.BtnSelectAllEmloyeesInShiftSchedTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSelectAllEmloyeesInShiftSchedTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectAllEmloyeesInShiftSchedTab.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectAllEmloyeesInShiftSchedTab.ForeColor = System.Drawing.Color.White;
            this.BtnSelectAllEmloyeesInShiftSchedTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSelectAllEmloyeesInShiftSchedTab.Location = new System.Drawing.Point(16, 20);
            this.BtnSelectAllEmloyeesInShiftSchedTab.Name = "BtnSelectAllEmloyeesInShiftSchedTab";
            this.BtnSelectAllEmloyeesInShiftSchedTab.Size = new System.Drawing.Size(143, 24);
            this.BtnSelectAllEmloyeesInShiftSchedTab.TabIndex = 54;
            this.BtnSelectAllEmloyeesInShiftSchedTab.Text = "Select all employees";
            this.BtnSelectAllEmloyeesInShiftSchedTab.UseVisualStyleBackColor = false;
            this.BtnSelectAllEmloyeesInShiftSchedTab.Click += new System.EventHandler(this.BtnSelectAllEmloyeesInShiftSchedTab_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(0, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1235, 657);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1227, 624);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employee Shift";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnRefreshEmployees);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.TbxSearchEmployeesInTab1);
            this.panel3.Controls.Add(this.BtnSelectAllEmloyeesInShiftSchedTab);
            this.panel3.Controls.Add(this.DGVEmployeeList);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(500, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 618);
            this.panel3.TabIndex = 9;
            // 
            // BtnRefreshEmployees
            // 
            this.BtnRefreshEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnRefreshEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefreshEmployees.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRefreshEmployees.ForeColor = System.Drawing.Color.White;
            this.BtnRefreshEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefreshEmployees.Location = new System.Drawing.Point(165, 19);
            this.BtnRefreshEmployees.Name = "BtnRefreshEmployees";
            this.BtnRefreshEmployees.Size = new System.Drawing.Size(62, 24);
            this.BtnRefreshEmployees.TabIndex = 57;
            this.BtnRefreshEmployees.Text = "Refresh";
            this.BtnRefreshEmployees.UseVisualStyleBackColor = false;
            this.BtnRefreshEmployees.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 56;
            this.label5.Text = "Search";
            // 
            // TbxSearchEmployeesInTab1
            // 
            this.TbxSearchEmployeesInTab1.Location = new System.Drawing.Point(411, 16);
            this.TbxSearchEmployeesInTab1.Name = "TbxSearchEmployeesInTab1";
            this.TbxSearchEmployeesInTab1.Size = new System.Drawing.Size(290, 27);
            this.TbxSearchEmployeesInTab1.TabIndex = 55;
            this.TbxSearchEmployeesInTab1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbxSearchEmployeesInTab1_KeyUp);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnRefreshEmployees2);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.TbxSearchEmployeesInTab2);
            this.tabPage2.Controls.Add(this.BtnUndoChanges);
            this.tabPage2.Controls.Add(this.BtnSelectAllEmployees);
            this.tabPage2.Controls.Add(this.BtnSaveWorkforceSchedule);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1227, 624);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Workforce Schedule";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // BtnDeleteAll
            // 
            this.BtnDeleteAll.BackColor = System.Drawing.Color.DarkRed;
            this.BtnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDeleteAll.ForeColor = System.Drawing.Color.White;
            this.BtnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDeleteAll.Location = new System.Drawing.Point(183, 106);
            this.BtnDeleteAll.Name = "BtnDeleteAll";
            this.BtnDeleteAll.Size = new System.Drawing.Size(97, 30);
            this.BtnDeleteAll.TabIndex = 61;
            this.BtnDeleteAll.Text = "Delete All";
            this.BtnDeleteAll.UseVisualStyleBackColor = false;
            this.BtnDeleteAll.Click += new System.EventHandler(this.BtnDeleteAll_Click);
            this.BtnDeleteAll.MouseHover += new System.EventHandler(this.BtnDeleteAll_MouseHover);
            // 
            // BtnRefreshEmployees2
            // 
            this.BtnRefreshEmployees2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnRefreshEmployees2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefreshEmployees2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRefreshEmployees2.ForeColor = System.Drawing.Color.White;
            this.BtnRefreshEmployees2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefreshEmployees2.Location = new System.Drawing.Point(586, 9);
            this.BtnRefreshEmployees2.Name = "BtnRefreshEmployees2";
            this.BtnRefreshEmployees2.Size = new System.Drawing.Size(62, 24);
            this.BtnRefreshEmployees2.TabIndex = 60;
            this.BtnRefreshEmployees2.Text = "Refresh";
            this.BtnRefreshEmployees2.UseVisualStyleBackColor = false;
            this.BtnRefreshEmployees2.Click += new System.EventHandler(this.BtnRefreshEmployees2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(856, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 59;
            this.label6.Text = "Search";
            // 
            // TbxSearchEmployeesInTab2
            // 
            this.TbxSearchEmployeesInTab2.Location = new System.Drawing.Point(915, 12);
            this.TbxSearchEmployeesInTab2.Name = "TbxSearchEmployeesInTab2";
            this.TbxSearchEmployeesInTab2.Size = new System.Drawing.Size(290, 27);
            this.TbxSearchEmployeesInTab2.TabIndex = 58;
            this.TbxSearchEmployeesInTab2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbxSearchEmployeesInTab2_KeyUp);
            // 
            // BtnUndoChanges
            // 
            this.BtnUndoChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnUndoChanges.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUndoChanges.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnUndoChanges.ForeColor = System.Drawing.Color.White;
            this.BtnUndoChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUndoChanges.Location = new System.Drawing.Point(964, 561);
            this.BtnUndoChanges.Name = "BtnUndoChanges";
            this.BtnUndoChanges.Size = new System.Drawing.Size(116, 49);
            this.BtnUndoChanges.TabIndex = 54;
            this.BtnUndoChanges.Text = "Undo Changes";
            this.BtnUndoChanges.UseVisualStyleBackColor = false;
            this.BtnUndoChanges.Click += new System.EventHandler(this.BtnUndoChanges_Click);
            this.BtnUndoChanges.MouseHover += new System.EventHandler(this.BtnUndoChanges_MouseHover);
            // 
            // BtnSelectAllEmployees
            // 
            this.BtnSelectAllEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSelectAllEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectAllEmployees.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectAllEmployees.ForeColor = System.Drawing.Color.White;
            this.BtnSelectAllEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSelectAllEmployees.Location = new System.Drawing.Point(453, 9);
            this.BtnSelectAllEmployees.Name = "BtnSelectAllEmployees";
            this.BtnSelectAllEmployees.Size = new System.Drawing.Size(127, 24);
            this.BtnSelectAllEmployees.TabIndex = 53;
            this.BtnSelectAllEmployees.Text = "Select all employees";
            this.BtnSelectAllEmployees.UseVisualStyleBackColor = false;
            this.BtnSelectAllEmployees.Click += new System.EventHandler(this.BtnSelectAllEmployees_Click);
            // 
            // BtnSaveWorkforceSchedule
            // 
            this.BtnSaveWorkforceSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveWorkforceSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveWorkforceSchedule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveWorkforceSchedule.ForeColor = System.Drawing.Color.White;
            this.BtnSaveWorkforceSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveWorkforceSchedule.Location = new System.Drawing.Point(1100, 561);
            this.BtnSaveWorkforceSchedule.Name = "BtnSaveWorkforceSchedule";
            this.BtnSaveWorkforceSchedule.Size = new System.Drawing.Size(102, 49);
            this.BtnSaveWorkforceSchedule.TabIndex = 52;
            this.BtnSaveWorkforceSchedule.Text = "Save";
            this.BtnSaveWorkforceSchedule.UseVisualStyleBackColor = false;
            this.BtnSaveWorkforceSchedule.Click += new System.EventHandler(this.BtnSaveWorkforceSchedule_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(437, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 516);
            this.panel2.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DGVScheduledWorkforceByDate);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 284);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(768, 232);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Workforce";
            // 
            // DGVScheduledWorkforceByDate
            // 
            this.DGVScheduledWorkforceByDate.AllowUserToAddRows = false;
            this.DGVScheduledWorkforceByDate.AllowUserToDeleteRows = false;
            this.DGVScheduledWorkforceByDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVScheduledWorkforceByDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVScheduledWorkforceByDate.Location = new System.Drawing.Point(3, 23);
            this.DGVScheduledWorkforceByDate.Name = "DGVScheduledWorkforceByDate";
            this.DGVScheduledWorkforceByDate.ReadOnly = true;
            this.DGVScheduledWorkforceByDate.RowTemplate.Height = 25;
            this.DGVScheduledWorkforceByDate.Size = new System.Drawing.Size(762, 206);
            this.DGVScheduledWorkforceByDate.TabIndex = 8;
            this.DGVScheduledWorkforceByDate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVScheduledWorkforceByDate_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DGVEmployeeListToSchedule);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(768, 282);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select employee";
            // 
            // DGVEmployeeListToSchedule
            // 
            this.DGVEmployeeListToSchedule.AllowUserToAddRows = false;
            this.DGVEmployeeListToSchedule.AllowUserToDeleteRows = false;
            this.DGVEmployeeListToSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeListToSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVEmployeeListToSchedule.Location = new System.Drawing.Point(3, 23);
            this.DGVEmployeeListToSchedule.Name = "DGVEmployeeListToSchedule";
            this.DGVEmployeeListToSchedule.ReadOnly = true;
            this.DGVEmployeeListToSchedule.RowTemplate.Height = 25;
            this.DGVEmployeeListToSchedule.Size = new System.Drawing.Size(762, 256);
            this.DGVEmployeeListToSchedule.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnDeleteAll);
            this.groupBox1.Controls.Add(this.BtnDeleteSchedule);
            this.groupBox1.Controls.Add(this.BtnUpdateSelectedDateWorkForce);
            this.groupBox1.Controls.Add(this.BtnGenerateWorkforceSchedule);
            this.groupBox1.Controls.Add(this.LViewScheduleDates);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DPicWorkScheduleEndTo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DPicWorkScheduleStartFrom);
            this.groupBox1.Location = new System.Drawing.Point(18, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 567);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scheduling";
            // 
            // BtnDeleteSchedule
            // 
            this.BtnDeleteSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnDeleteSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteSchedule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnDeleteSchedule.ForeColor = System.Drawing.Color.White;
            this.BtnDeleteSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDeleteSchedule.Location = new System.Drawing.Point(146, 518);
            this.BtnDeleteSchedule.Name = "BtnDeleteSchedule";
            this.BtnDeleteSchedule.Size = new System.Drawing.Size(89, 30);
            this.BtnDeleteSchedule.TabIndex = 52;
            this.BtnDeleteSchedule.Text = "Delete";
            this.BtnDeleteSchedule.UseVisualStyleBackColor = false;
            this.BtnDeleteSchedule.Visible = false;
            this.BtnDeleteSchedule.Click += new System.EventHandler(this.BtnDeleteSchedule_Click);
            this.BtnDeleteSchedule.MouseHover += new System.EventHandler(this.BtnDeleteSchedule_MouseHover);
            // 
            // BtnUpdateSelectedDateWorkForce
            // 
            this.BtnUpdateSelectedDateWorkForce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnUpdateSelectedDateWorkForce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdateSelectedDateWorkForce.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnUpdateSelectedDateWorkForce.ForeColor = System.Drawing.Color.White;
            this.BtnUpdateSelectedDateWorkForce.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpdateSelectedDateWorkForce.Location = new System.Drawing.Point(241, 518);
            this.BtnUpdateSelectedDateWorkForce.Name = "BtnUpdateSelectedDateWorkForce";
            this.BtnUpdateSelectedDateWorkForce.Size = new System.Drawing.Size(153, 30);
            this.BtnUpdateSelectedDateWorkForce.TabIndex = 51;
            this.BtnUpdateSelectedDateWorkForce.Text = "Update Workforce";
            this.BtnUpdateSelectedDateWorkForce.UseVisualStyleBackColor = false;
            this.BtnUpdateSelectedDateWorkForce.Click += new System.EventHandler(this.BtnUpdateSelectedDateWorkForce_Click);
            this.BtnUpdateSelectedDateWorkForce.MouseHover += new System.EventHandler(this.BtnUpdateSelectedDateWorkForce_MouseHover);
            // 
            // BtnGenerateWorkforceSchedule
            // 
            this.BtnGenerateWorkforceSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGenerateWorkforceSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateWorkforceSchedule.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerateWorkforceSchedule.ForeColor = System.Drawing.Color.White;
            this.BtnGenerateWorkforceSchedule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateWorkforceSchedule.Location = new System.Drawing.Point(286, 106);
            this.BtnGenerateWorkforceSchedule.Name = "BtnGenerateWorkforceSchedule";
            this.BtnGenerateWorkforceSchedule.Size = new System.Drawing.Size(89, 30);
            this.BtnGenerateWorkforceSchedule.TabIndex = 50;
            this.BtnGenerateWorkforceSchedule.Text = "Generate";
            this.BtnGenerateWorkforceSchedule.UseVisualStyleBackColor = false;
            this.BtnGenerateWorkforceSchedule.Click += new System.EventHandler(this.BtnGenerateWorkforceSchedule_Click);
            // 
            // LViewScheduleDates
            // 
            this.LViewScheduleDates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LViewScheduleDates.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LViewScheduleDates.FullRowSelect = true;
            this.LViewScheduleDates.GridLines = true;
            this.LViewScheduleDates.HideSelection = false;
            this.LViewScheduleDates.Location = new System.Drawing.Point(18, 142);
            this.LViewScheduleDates.Name = "LViewScheduleDates";
            this.LViewScheduleDates.Size = new System.Drawing.Size(376, 370);
            this.LViewScheduleDates.TabIndex = 5;
            this.LViewScheduleDates.UseCompatibleStateImageBehavior = false;
            this.LViewScheduleDates.View = System.Windows.Forms.View.Details;
            this.LViewScheduleDates.SelectedIndexChanged += new System.EventHandler(this.LViewScheduleDates_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Workforce #";
            this.columnHeader2.Width = 100;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(218, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "To";
            // 
            // DPicWorkScheduleEndTo
            // 
            this.DPicWorkScheduleEndTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DPicWorkScheduleEndTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicWorkScheduleEndTo.Location = new System.Drawing.Point(249, 71);
            this.DPicWorkScheduleEndTo.Name = "DPicWorkScheduleEndTo";
            this.DPicWorkScheduleEndTo.Size = new System.Drawing.Size(126, 29);
            this.DPicWorkScheduleEndTo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(28, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(81, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generate Schedule";
            // 
            // DPicWorkScheduleStartFrom
            // 
            this.DPicWorkScheduleStartFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DPicWorkScheduleStartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicWorkScheduleStartFrom.Location = new System.Drawing.Point(81, 71);
            this.DPicWorkScheduleStartFrom.Name = "DPicWorkScheduleStartFrom";
            this.DPicWorkScheduleStartFrom.Size = new System.Drawing.Size(126, 29);
            this.DPicWorkScheduleStartFrom.TabIndex = 0;
            // 
            // ManageEmpWorkScheduleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ManageEmpWorkScheduleControl";
            this.Size = new System.Drawing.Size(1235, 751);
            this.Load += new System.EventHandler(this.ManageEmpWorkScheduleControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVShiftList)).EndInit();
            this.GroupPanelShiftDays.ResumeLayout(false);
            this.GroupPanelShiftDays.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVScheduledWorkforceByDate)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeListToSchedule)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVEmployeeList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox GroupPanelShiftDays;
        private System.Windows.Forms.CheckBox CBoxSunday;
        private System.Windows.Forms.CheckBox CBoxSaturday;
        private System.Windows.Forms.CheckBox CBoxFriday;
        private System.Windows.Forms.CheckBox CBoxThursday;
        private System.Windows.Forms.CheckBox CBoxWednesday;
        private System.Windows.Forms.CheckBox CBoxMonday;
        private System.Windows.Forms.CheckBox CBoxTuesday;
        private System.Windows.Forms.DataGridView DGVShiftList;
        private System.Windows.Forms.Button BtnSaveEmployeeShiftSchedule;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView DGVScheduledWorkforceByDate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DGVEmployeeListToSchedule;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView LViewScheduleDates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DPicWorkScheduleEndTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DPicWorkScheduleStartFrom;
        private System.Windows.Forms.Button BtnSaveWorkforceSchedule;
        private System.Windows.Forms.Button BtnUpdateSelectedDateWorkForce;
        private System.Windows.Forms.Button BtnGenerateWorkforceSchedule;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button BtnSelectAllEmployees;
        private System.Windows.Forms.Button BtnDeleteSchedule;
        private System.Windows.Forms.Button BtnUndoChanges;
        private System.Windows.Forms.Button BtnSelectAllEmloyeesInShiftSchedTab;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TbxSearchEmployeesInTab1;
        private System.Windows.Forms.Button BtnRefreshEmployees;
        private System.Windows.Forms.Button BtnRefreshEmployees2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbxSearchEmployeesInTab2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button BtnDeleteAll;
    }
}
