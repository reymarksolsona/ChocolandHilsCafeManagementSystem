
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVShiftList)).BeginInit();
            this.GroupPanelShiftDays.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(1764, 157);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(16, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(523, 40);
            this.label2.TabIndex = 43;
            this.label2.Text = "Employee work schedule management";
            // 
            // DGVEmployeeList
            // 
            this.DGVEmployeeList.AllowUserToAddRows = false;
            this.DGVEmployeeList.AllowUserToDeleteRows = false;
            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVEmployeeList.Location = new System.Drawing.Point(0, 113);
            this.DGVEmployeeList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DGVEmployeeList.Name = "DGVEmployeeList";
            this.DGVEmployeeList.ReadOnly = true;
            this.DGVEmployeeList.RowHeadersWidth = 62;
            this.DGVEmployeeList.RowTemplate.Height = 25;
            this.DGVEmployeeList.Size = new System.Drawing.Size(1034, 928);
            this.DGVEmployeeList.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGVShiftList);
            this.groupBox2.Controls.Add(this.BtnSaveEmployeeShiftSchedule);
            this.groupBox2.Controls.Add(this.GroupPanelShiftDays);
            this.groupBox2.Location = new System.Drawing.Point(61, 68);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(604, 780);
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
            this.DGVShiftList.Location = new System.Drawing.Point(4, 35);
            this.DGVShiftList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DGVShiftList.Name = "DGVShiftList";
            this.DGVShiftList.ReadOnly = true;
            this.DGVShiftList.RowHeadersWidth = 62;
            this.DGVShiftList.RowTemplate.Height = 25;
            this.DGVShiftList.Size = new System.Drawing.Size(596, 407);
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
            this.BtnSaveEmployeeShiftSchedule.Location = new System.Drawing.Point(416, 692);
            this.BtnSaveEmployeeShiftSchedule.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSaveEmployeeShiftSchedule.Name = "BtnSaveEmployeeShiftSchedule";
            this.BtnSaveEmployeeShiftSchedule.Size = new System.Drawing.Size(164, 78);
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
            this.GroupPanelShiftDays.Location = new System.Drawing.Point(23, 470);
            this.GroupPanelShiftDays.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupPanelShiftDays.Name = "GroupPanelShiftDays";
            this.GroupPanelShiftDays.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupPanelShiftDays.Size = new System.Drawing.Size(557, 123);
            this.GroupPanelShiftDays.TabIndex = 52;
            this.GroupPanelShiftDays.TabStop = false;
            this.GroupPanelShiftDays.Text = "Shift Days";
            // 
            // CBoxSunday
            // 
            this.CBoxSunday.AutoSize = true;
            this.CBoxSunday.Enabled = false;
            this.CBoxSunday.Location = new System.Drawing.Point(464, 53);
            this.CBoxSunday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxSunday.Name = "CBoxSunday";
            this.CBoxSunday.Size = new System.Drawing.Size(78, 35);
            this.CBoxSunday.TabIndex = 56;
            this.CBoxSunday.Tag = "Sun-7";
            this.CBoxSunday.Text = "Sun";
            this.CBoxSunday.UseVisualStyleBackColor = true;
            // 
            // CBoxSaturday
            // 
            this.CBoxSaturday.AutoSize = true;
            this.CBoxSaturday.Enabled = false;
            this.CBoxSaturday.Location = new System.Drawing.Point(399, 53);
            this.CBoxSaturday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxSaturday.Name = "CBoxSaturday";
            this.CBoxSaturday.Size = new System.Drawing.Size(72, 35);
            this.CBoxSaturday.TabIndex = 55;
            this.CBoxSaturday.Tag = "Sat-6";
            this.CBoxSaturday.Text = "Sat";
            this.CBoxSaturday.UseVisualStyleBackColor = true;
            // 
            // CBoxFriday
            // 
            this.CBoxFriday.AutoSize = true;
            this.CBoxFriday.Enabled = false;
            this.CBoxFriday.Location = new System.Drawing.Point(333, 53);
            this.CBoxFriday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxFriday.Name = "CBoxFriday";
            this.CBoxFriday.Size = new System.Drawing.Size(65, 35);
            this.CBoxFriday.TabIndex = 54;
            this.CBoxFriday.Tag = "Fri-5";
            this.CBoxFriday.Text = "Fri";
            this.CBoxFriday.UseVisualStyleBackColor = true;
            // 
            // CBoxThursday
            // 
            this.CBoxThursday.AutoSize = true;
            this.CBoxThursday.Enabled = false;
            this.CBoxThursday.Location = new System.Drawing.Point(250, 53);
            this.CBoxThursday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxThursday.Name = "CBoxThursday";
            this.CBoxThursday.Size = new System.Drawing.Size(78, 35);
            this.CBoxThursday.TabIndex = 53;
            this.CBoxThursday.Tag = "Thu-4";
            this.CBoxThursday.Text = "Thu";
            this.CBoxThursday.UseVisualStyleBackColor = true;
            // 
            // CBoxWednesday
            // 
            this.CBoxWednesday.AutoSize = true;
            this.CBoxWednesday.Enabled = false;
            this.CBoxWednesday.Location = new System.Drawing.Point(170, 53);
            this.CBoxWednesday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxWednesday.Name = "CBoxWednesday";
            this.CBoxWednesday.Size = new System.Drawing.Size(86, 35);
            this.CBoxWednesday.TabIndex = 52;
            this.CBoxWednesday.Tag = "Wed-3";
            this.CBoxWednesday.Text = "Wed";
            this.CBoxWednesday.UseVisualStyleBackColor = true;
            // 
            // CBoxMonday
            // 
            this.CBoxMonday.AutoSize = true;
            this.CBoxMonday.Enabled = false;
            this.CBoxMonday.Location = new System.Drawing.Point(13, 53);
            this.CBoxMonday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxMonday.Name = "CBoxMonday";
            this.CBoxMonday.Size = new System.Drawing.Size(87, 35);
            this.CBoxMonday.TabIndex = 50;
            this.CBoxMonday.Tag = "Mon-1";
            this.CBoxMonday.Text = "Mon";
            this.CBoxMonday.UseVisualStyleBackColor = true;
            // 
            // CBoxTuesday
            // 
            this.CBoxTuesday.AutoSize = true;
            this.CBoxTuesday.Enabled = false;
            this.CBoxTuesday.Location = new System.Drawing.Point(97, 53);
            this.CBoxTuesday.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CBoxTuesday.Name = "CBoxTuesday";
            this.CBoxTuesday.Size = new System.Drawing.Size(77, 35);
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
            this.BtnSelectAllEmloyeesInShiftSchedTab.Location = new System.Drawing.Point(23, 33);
            this.BtnSelectAllEmloyeesInShiftSchedTab.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnSelectAllEmloyeesInShiftSchedTab.Name = "BtnSelectAllEmloyeesInShiftSchedTab";
            this.BtnSelectAllEmloyeesInShiftSchedTab.Size = new System.Drawing.Size(204, 40);
            this.BtnSelectAllEmloyeesInShiftSchedTab.TabIndex = 54;
            this.BtnSelectAllEmloyeesInShiftSchedTab.Text = "Select all employees";
            this.BtnSelectAllEmloyeesInShiftSchedTab.UseVisualStyleBackColor = false;
            this.BtnSelectAllEmloyeesInShiftSchedTab.Click += new System.EventHandler(this.BtnSelectAllEmloyeesInShiftSchedTab_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(0, 157);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1764, 1095);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1756, 1051);
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
            this.panel3.Location = new System.Drawing.Point(718, 5);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1034, 1041);
            this.panel3.TabIndex = 9;
            // 
            // BtnRefreshEmployees
            // 
            this.BtnRefreshEmployees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnRefreshEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefreshEmployees.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRefreshEmployees.ForeColor = System.Drawing.Color.White;
            this.BtnRefreshEmployees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefreshEmployees.Location = new System.Drawing.Point(236, 32);
            this.BtnRefreshEmployees.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnRefreshEmployees.Name = "BtnRefreshEmployees";
            this.BtnRefreshEmployees.Size = new System.Drawing.Size(89, 40);
            this.BtnRefreshEmployees.TabIndex = 57;
            this.BtnRefreshEmployees.Text = "Refresh";
            this.BtnRefreshEmployees.UseVisualStyleBackColor = false;
            this.BtnRefreshEmployees.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(503, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 31);
            this.label5.TabIndex = 56;
            this.label5.Text = "Search";
            // 
            // TbxSearchEmployeesInTab1
            // 
            this.TbxSearchEmployeesInTab1.Location = new System.Drawing.Point(587, 27);
            this.TbxSearchEmployeesInTab1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TbxSearchEmployeesInTab1.Name = "TbxSearchEmployeesInTab1";
            this.TbxSearchEmployeesInTab1.Size = new System.Drawing.Size(413, 37);
            this.TbxSearchEmployeesInTab1.TabIndex = 55;
            this.TbxSearchEmployeesInTab1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbxSearchEmployeesInTab1_KeyUp);
            // 
            // ManageEmpWorkScheduleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ManageEmpWorkScheduleControl";
            this.Size = new System.Drawing.Size(1764, 1252);
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
        private System.Windows.Forms.Button BtnSelectAllEmloyeesInShiftSchedTab;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TbxSearchEmployeesInTab1;
        private System.Windows.Forms.Button BtnRefreshEmployees;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
