
namespace Main.Forms.PayrollForms.Controls
{
    partial class GeneratePayrollControl
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblPaydate = new System.Windows.Forms.Label();
            this.LblAttendanceDateEnd = new System.Windows.Forms.Label();
            this.LblAttendanceDateStart = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TabControlDeductions = new System.Windows.Forms.TabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnGeneratePayrollInitiate = new System.Windows.Forms.Button();
            this.DPickerShiftEndDate = new System.Windows.Forms.DateTimePicker();
            this.DPickerPaydate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DPickerShiftStartDate = new System.Windows.Forms.DateTimePicker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LblTotalSelectedEmployees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnSelectAllEmployeesInDGV = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TboxSearchEmployee = new System.Windows.Forms.TextBox();
            this.DGVEmployeeList = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.BtnSelectAllGovtAgencies = new System.Windows.Forms.Button();
            this.DGVGovtAgencies = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnSelectAllBenefits = new System.Windows.Forms.Button();
            this.DGVBenefitsList = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DGVEmployeeCashAdvance = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSelectAllEmpCashAdvance = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnSelectAllDeductions = new System.Windows.Forms.Button();
            this.DGVDeductionList = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.BtnSelectAllCashRegisterTrans = new System.Windows.Forms.Button();
            this.DGVSalesRecords = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.BtnCancelSelectedEmployeePayslip = new System.Windows.Forms.Button();
            this.BtnCancelAllEmployeePayslip = new System.Windows.Forms.Button();
            this.PanelEmployeePayslipContainer = new System.Windows.Forms.Panel();
            this.DGVEmployeeListForOverview = new System.Windows.Forms.DataGridView();
            this.BtnGeneratePayslipPDF = new System.Windows.Forms.Button();
            this.BtnGenerateEmployeePayslip = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.TabControlDeductions.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGovtAgencies)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBenefitsList)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeCashAdvance)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDeductionList)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSalesRecords)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeListForOverview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(1103, 94);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LblPaydate);
            this.panel2.Controls.Add(this.LblAttendanceDateEnd);
            this.panel2.Controls.Add(this.LblAttendanceDateStart);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(514, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 94);
            this.panel2.TabIndex = 46;
            // 
            // LblPaydate
            // 
            this.LblPaydate.AutoSize = true;
            this.LblPaydate.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblPaydate.ForeColor = System.Drawing.Color.White;
            this.LblPaydate.Location = new System.Drawing.Point(110, 12);
            this.LblPaydate.Name = "LblPaydate";
            this.LblPaydate.Size = new System.Drawing.Size(116, 25);
            this.LblPaydate.TabIndex = 49;
            this.LblPaydate.Text = "0000/00/00";
            // 
            // LblAttendanceDateEnd
            // 
            this.LblAttendanceDateEnd.AutoSize = true;
            this.LblAttendanceDateEnd.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblAttendanceDateEnd.ForeColor = System.Drawing.Color.White;
            this.LblAttendanceDateEnd.Location = new System.Drawing.Point(403, 49);
            this.LblAttendanceDateEnd.Name = "LblAttendanceDateEnd";
            this.LblAttendanceDateEnd.Size = new System.Drawing.Size(116, 25);
            this.LblAttendanceDateEnd.TabIndex = 48;
            this.LblAttendanceDateEnd.Text = "0000/00/00";
            // 
            // LblAttendanceDateStart
            // 
            this.LblAttendanceDateStart.AutoSize = true;
            this.LblAttendanceDateStart.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblAttendanceDateStart.ForeColor = System.Drawing.Color.White;
            this.LblAttendanceDateStart.Location = new System.Drawing.Point(227, 49);
            this.LblAttendanceDateStart.Name = "LblAttendanceDateStart";
            this.LblAttendanceDateStart.Size = new System.Drawing.Size(116, 25);
            this.LblAttendanceDateStart.TabIndex = 47;
            this.LblAttendanceDateStart.Text = "0000/00/00";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(361, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 25);
            this.label13.TabIndex = 46;
            this.label13.Text = "To:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(17, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(209, 25);
            this.label11.TabIndex = 45;
            this.label11.Text = "Attendance Start from:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(17, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 25);
            this.label10.TabIndex = 44;
            this.label10.Text = "Paydate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Generate payroll";
            // 
            // TabControlDeductions
            // 
            this.TabControlDeductions.Controls.Add(this.tabPage6);
            this.TabControlDeductions.Controls.Add(this.tabPage1);
            this.TabControlDeductions.Controls.Add(this.tabPage2);
            this.TabControlDeductions.Controls.Add(this.tabPage3);
            this.TabControlDeductions.Controls.Add(this.tabPage4);
            this.TabControlDeductions.Controls.Add(this.tabPage5);
            this.TabControlDeductions.Controls.Add(this.tabPage7);
            this.TabControlDeductions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlDeductions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabControlDeductions.Location = new System.Drawing.Point(0, 94);
            this.TabControlDeductions.Name = "TabControlDeductions";
            this.TabControlDeductions.SelectedIndex = 0;
            this.TabControlDeductions.Size = new System.Drawing.Size(1103, 528);
            this.TabControlDeductions.TabIndex = 7;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.groupBox1);
            this.tabPage6.Location = new System.Drawing.Point(4, 30);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1095, 494);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Initate";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnGeneratePayrollInitiate);
            this.groupBox1.Controls.Add(this.DPickerShiftEndDate);
            this.groupBox1.Controls.Add(this.DPickerPaydate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DPickerShiftStartDate);
            this.groupBox1.Location = new System.Drawing.Point(228, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(519, 239);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate new payroll";
            // 
            // BtnGeneratePayrollInitiate
            // 
            this.BtnGeneratePayrollInitiate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGeneratePayrollInitiate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGeneratePayrollInitiate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGeneratePayrollInitiate.ForeColor = System.Drawing.Color.White;
            this.BtnGeneratePayrollInitiate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGeneratePayrollInitiate.Location = new System.Drawing.Point(339, 153);
            this.BtnGeneratePayrollInitiate.Name = "BtnGeneratePayrollInitiate";
            this.BtnGeneratePayrollInitiate.Size = new System.Drawing.Size(115, 47);
            this.BtnGeneratePayrollInitiate.TabIndex = 65;
            this.BtnGeneratePayrollInitiate.Text = "Initiate";
            this.BtnGeneratePayrollInitiate.UseVisualStyleBackColor = false;
            this.BtnGeneratePayrollInitiate.Click += new System.EventHandler(this.BtnGeneratePayrollInitiate_Click);
            // 
            // DPickerShiftEndDate
            // 
            this.DPickerShiftEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerShiftEndDate.Location = new System.Drawing.Point(337, 102);
            this.DPickerShiftEndDate.Name = "DPickerShiftEndDate";
            this.DPickerShiftEndDate.Size = new System.Drawing.Size(117, 29);
            this.DPickerShiftEndDate.TabIndex = 64;
            // 
            // DPickerPaydate
            // 
            this.DPickerPaydate.Location = new System.Drawing.Point(183, 56);
            this.DPickerPaydate.Name = "DPickerPaydate";
            this.DPickerPaydate.Size = new System.Drawing.Size(271, 29);
            this.DPickerPaydate.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(306, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 21);
            this.label7.TabIndex = 63;
            this.label7.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 21);
            this.label4.TabIndex = 59;
            this.label4.Text = "Paydate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 21);
            this.label6.TabIndex = 61;
            this.label6.Text = "Shift start from";
            // 
            // DPickerShiftStartDate
            // 
            this.DPickerShiftStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerShiftStartDate.Location = new System.Drawing.Point(183, 102);
            this.DPickerShiftStartDate.Name = "DPickerShiftStartDate";
            this.DPickerShiftStartDate.Size = new System.Drawing.Size(117, 29);
            this.DPickerShiftStartDate.TabIndex = 60;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LblTotalSelectedEmployees);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.BtnSelectAllEmployeesInDGV);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.TboxSearchEmployee);
            this.tabPage1.Controls.Add(this.DGVEmployeeList);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1095, 494);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LblTotalSelectedEmployees
            // 
            this.LblTotalSelectedEmployees.AutoSize = true;
            this.LblTotalSelectedEmployees.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTotalSelectedEmployees.Location = new System.Drawing.Point(212, 22);
            this.LblTotalSelectedEmployees.Name = "LblTotalSelectedEmployees";
            this.LblTotalSelectedEmployees.Size = new System.Drawing.Size(37, 21);
            this.LblTotalSelectedEmployees.TabIndex = 55;
            this.LblTotalSelectedEmployees.Text = "000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(22, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 21);
            this.label9.TabIndex = 53;
            this.label9.Text = "Total selected employees:";
            // 
            // BtnSelectAllEmployeesInDGV
            // 
            this.BtnSelectAllEmployeesInDGV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSelectAllEmployeesInDGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectAllEmployeesInDGV.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectAllEmployeesInDGV.ForeColor = System.Drawing.Color.White;
            this.BtnSelectAllEmployeesInDGV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSelectAllEmployeesInDGV.Location = new System.Drawing.Point(989, 24);
            this.BtnSelectAllEmployeesInDGV.Name = "BtnSelectAllEmployeesInDGV";
            this.BtnSelectAllEmployeesInDGV.Size = new System.Drawing.Size(87, 24);
            this.BtnSelectAllEmployeesInDGV.TabIndex = 54;
            this.BtnSelectAllEmployeesInDGV.Text = "Select all";
            this.BtnSelectAllEmployeesInDGV.UseVisualStyleBackColor = false;
            this.BtnSelectAllEmployeesInDGV.Click += new System.EventHandler(this.BtnSelectAllEmployeesInDGV_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(619, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 52;
            this.label3.Text = "Search";
            // 
            // TboxSearchEmployee
            // 
            this.TboxSearchEmployee.Location = new System.Drawing.Point(682, 19);
            this.TboxSearchEmployee.Name = "TboxSearchEmployee";
            this.TboxSearchEmployee.Size = new System.Drawing.Size(281, 29);
            this.TboxSearchEmployee.TabIndex = 51;
            this.TboxSearchEmployee.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TboxSearchEmployee_KeyUp);
            // 
            // DGVEmployeeList
            // 
            this.DGVEmployeeList.AllowUserToAddRows = false;
            this.DGVEmployeeList.AllowUserToDeleteRows = false;
            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeList.Location = new System.Drawing.Point(22, 54);
            this.DGVEmployeeList.Name = "DGVEmployeeList";
            this.DGVEmployeeList.ReadOnly = true;
            this.DGVEmployeeList.RowTemplate.Height = 25;
            this.DGVEmployeeList.Size = new System.Drawing.Size(1054, 378);
            this.DGVEmployeeList.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.BtnSelectAllGovtAgencies);
            this.tabPage2.Controls.Add(this.DGVGovtAgencies);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1095, 494);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Govt. Contributions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // BtnSelectAllGovtAgencies
            // 
            this.BtnSelectAllGovtAgencies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSelectAllGovtAgencies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectAllGovtAgencies.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectAllGovtAgencies.ForeColor = System.Drawing.Color.White;
            this.BtnSelectAllGovtAgencies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSelectAllGovtAgencies.Location = new System.Drawing.Point(699, 18);
            this.BtnSelectAllGovtAgencies.Name = "BtnSelectAllGovtAgencies";
            this.BtnSelectAllGovtAgencies.Size = new System.Drawing.Size(87, 24);
            this.BtnSelectAllGovtAgencies.TabIndex = 55;
            this.BtnSelectAllGovtAgencies.Text = "Select all";
            this.BtnSelectAllGovtAgencies.UseVisualStyleBackColor = false;
            this.BtnSelectAllGovtAgencies.Click += new System.EventHandler(this.BtnSelectAllGovtAgencies_Click);
            // 
            // DGVGovtAgencies
            // 
            this.DGVGovtAgencies.AllowUserToAddRows = false;
            this.DGVGovtAgencies.AllowUserToDeleteRows = false;
            this.DGVGovtAgencies.AllowUserToResizeRows = false;
            this.DGVGovtAgencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGovtAgencies.Location = new System.Drawing.Point(191, 48);
            this.DGVGovtAgencies.Name = "DGVGovtAgencies";
            this.DGVGovtAgencies.ReadOnly = true;
            this.DGVGovtAgencies.RowTemplate.Height = 25;
            this.DGVGovtAgencies.Size = new System.Drawing.Size(595, 363);
            this.DGVGovtAgencies.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnSelectAllBenefits);
            this.tabPage3.Controls.Add(this.DGVBenefitsList);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1095, 494);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Benefits";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BtnSelectAllBenefits
            // 
            this.BtnSelectAllBenefits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSelectAllBenefits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectAllBenefits.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectAllBenefits.ForeColor = System.Drawing.Color.White;
            this.BtnSelectAllBenefits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSelectAllBenefits.Location = new System.Drawing.Point(699, 16);
            this.BtnSelectAllBenefits.Name = "BtnSelectAllBenefits";
            this.BtnSelectAllBenefits.Size = new System.Drawing.Size(87, 24);
            this.BtnSelectAllBenefits.TabIndex = 58;
            this.BtnSelectAllBenefits.Text = "Select all";
            this.BtnSelectAllBenefits.UseVisualStyleBackColor = false;
            this.BtnSelectAllBenefits.Click += new System.EventHandler(this.BtnSelectAllBenefits_Click);
            // 
            // DGVBenefitsList
            // 
            this.DGVBenefitsList.AllowUserToAddRows = false;
            this.DGVBenefitsList.AllowUserToDeleteRows = false;
            this.DGVBenefitsList.AllowUserToResizeRows = false;
            this.DGVBenefitsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVBenefitsList.Location = new System.Drawing.Point(191, 46);
            this.DGVBenefitsList.Name = "DGVBenefitsList";
            this.DGVBenefitsList.ReadOnly = true;
            this.DGVBenefitsList.RowTemplate.Height = 25;
            this.DGVBenefitsList.Size = new System.Drawing.Size(595, 370);
            this.DGVBenefitsList.TabIndex = 57;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1095, 494);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Deductions";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DGVEmployeeCashAdvance);
            this.groupBox3.Controls.Add(this.panel4);
            this.groupBox3.Location = new System.Drawing.Point(7, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(522, 455);
            this.groupBox3.TabIndex = 60;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Employee Cash advance";
            // 
            // DGVEmployeeCashAdvance
            // 
            this.DGVEmployeeCashAdvance.AllowUserToAddRows = false;
            this.DGVEmployeeCashAdvance.AllowUserToDeleteRows = false;
            this.DGVEmployeeCashAdvance.AllowUserToResizeRows = false;
            this.DGVEmployeeCashAdvance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeCashAdvance.Location = new System.Drawing.Point(6, 68);
            this.DGVEmployeeCashAdvance.Name = "DGVEmployeeCashAdvance";
            this.DGVEmployeeCashAdvance.ReadOnly = true;
            this.DGVEmployeeCashAdvance.RowTemplate.Height = 25;
            this.DGVEmployeeCashAdvance.Size = new System.Drawing.Size(510, 379);
            this.DGVEmployeeCashAdvance.TabIndex = 60;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSelectAllEmpCashAdvance);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(516, 37);
            this.panel4.TabIndex = 59;
            // 
            // btnSelectAllEmpCashAdvance
            // 
            this.btnSelectAllEmpCashAdvance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.btnSelectAllEmpCashAdvance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAllEmpCashAdvance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSelectAllEmpCashAdvance.ForeColor = System.Drawing.Color.White;
            this.btnSelectAllEmpCashAdvance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectAllEmpCashAdvance.Location = new System.Drawing.Point(3, 8);
            this.btnSelectAllEmpCashAdvance.Name = "btnSelectAllEmpCashAdvance";
            this.btnSelectAllEmpCashAdvance.Size = new System.Drawing.Size(87, 24);
            this.btnSelectAllEmpCashAdvance.TabIndex = 58;
            this.btnSelectAllEmpCashAdvance.Text = "Select all";
            this.btnSelectAllEmpCashAdvance.UseVisualStyleBackColor = false;
            this.btnSelectAllEmpCashAdvance.Click += new System.EventHandler(this.btnSelectAllEmpCashAdvance_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.DGVDeductionList);
            this.groupBox2.Location = new System.Drawing.Point(550, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 458);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Predefined deductions";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnSelectAllDeductions);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(522, 37);
            this.panel3.TabIndex = 58;
            // 
            // BtnSelectAllDeductions
            // 
            this.BtnSelectAllDeductions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSelectAllDeductions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectAllDeductions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectAllDeductions.ForeColor = System.Drawing.Color.White;
            this.BtnSelectAllDeductions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSelectAllDeductions.Location = new System.Drawing.Point(3, 8);
            this.BtnSelectAllDeductions.Name = "BtnSelectAllDeductions";
            this.BtnSelectAllDeductions.Size = new System.Drawing.Size(87, 24);
            this.BtnSelectAllDeductions.TabIndex = 58;
            this.BtnSelectAllDeductions.Text = "Select all";
            this.BtnSelectAllDeductions.UseVisualStyleBackColor = false;
            this.BtnSelectAllDeductions.Click += new System.EventHandler(this.BtnSelectAllDeductions_Click);
            // 
            // DGVDeductionList
            // 
            this.DGVDeductionList.AllowUserToAddRows = false;
            this.DGVDeductionList.AllowUserToDeleteRows = false;
            this.DGVDeductionList.AllowUserToResizeRows = false;
            this.DGVDeductionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDeductionList.Location = new System.Drawing.Point(6, 68);
            this.DGVDeductionList.Name = "DGVDeductionList";
            this.DGVDeductionList.ReadOnly = true;
            this.DGVDeductionList.RowTemplate.Height = 25;
            this.DGVDeductionList.Size = new System.Drawing.Size(516, 384);
            this.DGVDeductionList.TabIndex = 57;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.BtnSelectAllCashRegisterTrans);
            this.tabPage5.Controls.Add(this.DGVSalesRecords);
            this.tabPage5.Location = new System.Drawing.Point(4, 30);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1095, 494);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Sales Bonus";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // BtnSelectAllCashRegisterTrans
            // 
            this.BtnSelectAllCashRegisterTrans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSelectAllCashRegisterTrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectAllCashRegisterTrans.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectAllCashRegisterTrans.ForeColor = System.Drawing.Color.White;
            this.BtnSelectAllCashRegisterTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSelectAllCashRegisterTrans.Location = new System.Drawing.Point(699, 20);
            this.BtnSelectAllCashRegisterTrans.Name = "BtnSelectAllCashRegisterTrans";
            this.BtnSelectAllCashRegisterTrans.Size = new System.Drawing.Size(87, 24);
            this.BtnSelectAllCashRegisterTrans.TabIndex = 61;
            this.BtnSelectAllCashRegisterTrans.Text = "Select all";
            this.BtnSelectAllCashRegisterTrans.UseVisualStyleBackColor = false;
            this.BtnSelectAllCashRegisterTrans.Click += new System.EventHandler(this.BtnSelectAllCashRegisterTrans_Click);
            // 
            // DGVSalesRecords
            // 
            this.DGVSalesRecords.AllowUserToAddRows = false;
            this.DGVSalesRecords.AllowUserToDeleteRows = false;
            this.DGVSalesRecords.AllowUserToResizeRows = false;
            this.DGVSalesRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSalesRecords.Location = new System.Drawing.Point(197, 50);
            this.DGVSalesRecords.Name = "DGVSalesRecords";
            this.DGVSalesRecords.ReadOnly = true;
            this.DGVSalesRecords.RowTemplate.Height = 25;
            this.DGVSalesRecords.Size = new System.Drawing.Size(589, 375);
            this.DGVSalesRecords.TabIndex = 58;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.BtnCancelSelectedEmployeePayslip);
            this.tabPage7.Controls.Add(this.BtnCancelAllEmployeePayslip);
            this.tabPage7.Controls.Add(this.PanelEmployeePayslipContainer);
            this.tabPage7.Controls.Add(this.DGVEmployeeListForOverview);
            this.tabPage7.Controls.Add(this.BtnGeneratePayslipPDF);
            this.tabPage7.Controls.Add(this.BtnGenerateEmployeePayslip);
            this.tabPage7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabPage7.Location = new System.Drawing.Point(4, 30);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1095, 494);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Generate";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // BtnCancelSelectedEmployeePayslip
            // 
            this.BtnCancelSelectedEmployeePayslip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelSelectedEmployeePayslip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelSelectedEmployeePayslip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelSelectedEmployeePayslip.ForeColor = System.Drawing.Color.White;
            this.BtnCancelSelectedEmployeePayslip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelSelectedEmployeePayslip.Location = new System.Drawing.Point(382, 428);
            this.BtnCancelSelectedEmployeePayslip.Name = "BtnCancelSelectedEmployeePayslip";
            this.BtnCancelSelectedEmployeePayslip.Size = new System.Drawing.Size(94, 47);
            this.BtnCancelSelectedEmployeePayslip.TabIndex = 62;
            this.BtnCancelSelectedEmployeePayslip.Text = "Cancel";
            this.BtnCancelSelectedEmployeePayslip.UseVisualStyleBackColor = false;
            this.BtnCancelSelectedEmployeePayslip.Click += new System.EventHandler(this.BtnCancelSelectedEmployeePayslip_Click);
            // 
            // BtnCancelAllEmployeePayslip
            // 
            this.BtnCancelAllEmployeePayslip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelAllEmployeePayslip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelAllEmployeePayslip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelAllEmployeePayslip.ForeColor = System.Drawing.Color.White;
            this.BtnCancelAllEmployeePayslip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelAllEmployeePayslip.Location = new System.Drawing.Point(282, 428);
            this.BtnCancelAllEmployeePayslip.Name = "BtnCancelAllEmployeePayslip";
            this.BtnCancelAllEmployeePayslip.Size = new System.Drawing.Size(94, 47);
            this.BtnCancelAllEmployeePayslip.TabIndex = 61;
            this.BtnCancelAllEmployeePayslip.Text = "Cancel All";
            this.BtnCancelAllEmployeePayslip.UseVisualStyleBackColor = false;
            this.BtnCancelAllEmployeePayslip.Click += new System.EventHandler(this.BtnCancelAllEmployeePayslip_Click);
            // 
            // PanelEmployeePayslipContainer
            // 
            this.PanelEmployeePayslipContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelEmployeePayslipContainer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PanelEmployeePayslipContainer.Location = new System.Drawing.Point(276, 3);
            this.PanelEmployeePayslipContainer.Name = "PanelEmployeePayslipContainer";
            this.PanelEmployeePayslipContainer.Size = new System.Drawing.Size(816, 419);
            this.PanelEmployeePayslipContainer.TabIndex = 59;
            // 
            // DGVEmployeeListForOverview
            // 
            this.DGVEmployeeListForOverview.AllowUserToAddRows = false;
            this.DGVEmployeeListForOverview.AllowUserToDeleteRows = false;
            this.DGVEmployeeListForOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeListForOverview.Dock = System.Windows.Forms.DockStyle.Left;
            this.DGVEmployeeListForOverview.Location = new System.Drawing.Point(3, 3);
            this.DGVEmployeeListForOverview.Name = "DGVEmployeeListForOverview";
            this.DGVEmployeeListForOverview.ReadOnly = true;
            this.DGVEmployeeListForOverview.RowTemplate.Height = 25;
            this.DGVEmployeeListForOverview.Size = new System.Drawing.Size(273, 488);
            this.DGVEmployeeListForOverview.TabIndex = 58;
            this.DGVEmployeeListForOverview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployeeListForOverview_CellClick);
            // 
            // BtnGeneratePayslipPDF
            // 
            this.BtnGeneratePayslipPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGeneratePayslipPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGeneratePayslipPDF.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGeneratePayslipPDF.ForeColor = System.Drawing.Color.White;
            this.BtnGeneratePayslipPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGeneratePayslipPDF.Location = new System.Drawing.Point(935, 428);
            this.BtnGeneratePayslipPDF.Name = "BtnGeneratePayslipPDF";
            this.BtnGeneratePayslipPDF.Size = new System.Drawing.Size(140, 47);
            this.BtnGeneratePayslipPDF.TabIndex = 57;
            this.BtnGeneratePayslipPDF.Text = "Generate PDF";
            this.BtnGeneratePayslipPDF.UseVisualStyleBackColor = false;
            this.BtnGeneratePayslipPDF.Click += new System.EventHandler(this.BtnGeneratePayslipPDF_Click);
            // 
            // BtnGenerateEmployeePayslip
            // 
            this.BtnGenerateEmployeePayslip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGenerateEmployeePayslip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateEmployeePayslip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerateEmployeePayslip.ForeColor = System.Drawing.Color.White;
            this.BtnGenerateEmployeePayslip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateEmployeePayslip.Location = new System.Drawing.Point(790, 428);
            this.BtnGenerateEmployeePayslip.Name = "BtnGenerateEmployeePayslip";
            this.BtnGenerateEmployeePayslip.Size = new System.Drawing.Size(139, 47);
            this.BtnGenerateEmployeePayslip.TabIndex = 51;
            this.BtnGenerateEmployeePayslip.Text = "Generate Payslip";
            this.BtnGenerateEmployeePayslip.UseVisualStyleBackColor = false;
            this.BtnGenerateEmployeePayslip.Click += new System.EventHandler(this.BtnGenerateEmployeePayslip_Click);
            // 
            // GeneratePayrollControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabControlDeductions);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "GeneratePayrollControl";
            this.Size = new System.Drawing.Size(1103, 622);
            this.Load += new System.EventHandler(this.GeneratePayrollControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TabControlDeductions.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVGovtAgencies)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVBenefitsList)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeCashAdvance)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDeductionList)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSalesRecords)).EndInit();
            this.tabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeListForOverview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl TabControlDeductions;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView DGVEmployeeList;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox TboxSearchEmployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSelectAllEmployeesInDGV;
        private System.Windows.Forms.Button BtnSelectAllGovtAgencies;
        private System.Windows.Forms.DataGridView DGVGovtAgencies;
        private System.Windows.Forms.Button BtnSelectAllBenefits;
        private System.Windows.Forms.DataGridView DGVBenefitsList;
        private System.Windows.Forms.Button BtnSelectAllDeductions;
        private System.Windows.Forms.DataGridView DGVDeductionList;
        private System.Windows.Forms.Button BtnSelectAllCashRegisterTrans;
        private System.Windows.Forms.DataGridView DGVSalesRecords;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button BtnGenerateEmployeePayslip;
        private System.Windows.Forms.DateTimePicker DPickerShiftEndDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DPickerShiftStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DPickerPaydate;
        private System.Windows.Forms.Button BtnGeneratePayrollInitiate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblAttendanceDateEnd;
        private System.Windows.Forms.Label LblAttendanceDateStart;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LblPaydate;
        private System.Windows.Forms.Label LblTotalSelectedEmployees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnGeneratePayslipPDF;
        private System.Windows.Forms.Panel PanelEmployeePayslipContainer;
        private System.Windows.Forms.DataGridView DGVEmployeeListForOverview;
        private System.Windows.Forms.Button BtnCancelAllEmployeePayslip;
        private System.Windows.Forms.Button BtnCancelSelectedEmployeePayslip;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DGVEmployeeCashAdvance;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSelectAllEmpCashAdvance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
    }
}
