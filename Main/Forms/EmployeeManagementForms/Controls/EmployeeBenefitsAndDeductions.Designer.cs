
namespace Main.Forms.EmployeeManagementForms.Controls
{
    partial class EmployeeBenefitsAndDeductions
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DGVEmployeeBenefits = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnCancelBenefitUpdate = new System.Windows.Forms.Button();
            this.NumUpDwnBenefitAmount = new System.Windows.Forms.NumericUpDown();
            this.BtnSaveBenefits = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TbxBenefitTitle = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DGVSpecificEmployeeBenefits = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TBoxEmployeeNumber = new System.Windows.Forms.TextBox();
            this.BtnCancelSpecificEmployeeBenefit = new System.Windows.Forms.Button();
            this.NumUpDwBenefitAmount = new System.Windows.Forms.NumericUpDown();
            this.BtnSaveSpecificEmployeeBenefit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TBoxBenefitTitle = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DGVEmployeeDeductions = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCancelUpdateEmpDeduction = new System.Windows.Forms.Button();
            this.NumUpDwnDeductionAmount = new System.Windows.Forms.NumericUpDown();
            this.BtnSaveEmpDeduction = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TBoxDeductionTitle = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.DGVSpecificEmployeeDeductions = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TboxEmployeeNumberForDeduction = new System.Windows.Forms.TextBox();
            this.BtnCancelSpecificEmployeeDeduction = new System.Windows.Forms.Button();
            this.NumUpDwnSpecificEmployeeDeductionAmount = new System.Windows.Forms.NumericUpDown();
            this.BtnSaveSpecificEmployeeDeduction = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TboxSpecificEmpDeductionTitle = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeBenefits)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnBenefitAmount)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSpecificEmployeeBenefits)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwBenefitAmount)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeDeductions)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnDeductionAmount)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSpecificEmployeeDeductions)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnSpecificEmployeeDeductionAmount)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(916, 94);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Employee benefits and deductions";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(916, 357);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DGVEmployeeBenefits);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(908, 323);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Benefits";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DGVEmployeeBenefits
            // 
            this.DGVEmployeeBenefits.AllowUserToAddRows = false;
            this.DGVEmployeeBenefits.AllowUserToDeleteRows = false;
            this.DGVEmployeeBenefits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeBenefits.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGVEmployeeBenefits.Location = new System.Drawing.Point(316, 3);
            this.DGVEmployeeBenefits.Name = "DGVEmployeeBenefits";
            this.DGVEmployeeBenefits.ReadOnly = true;
            this.DGVEmployeeBenefits.RowTemplate.Height = 25;
            this.DGVEmployeeBenefits.Size = new System.Drawing.Size(589, 317);
            this.DGVEmployeeBenefits.TabIndex = 1;
            this.DGVEmployeeBenefits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployeeBenefits_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnCancelBenefitUpdate);
            this.groupBox1.Controls.Add(this.NumUpDwnBenefitAmount);
            this.groupBox1.Controls.Add(this.BtnSaveBenefits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TbxBenefitTitle);
            this.groupBox1.Location = new System.Drawing.Point(20, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save";
            // 
            // BtnCancelBenefitUpdate
            // 
            this.BtnCancelBenefitUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelBenefitUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelBenefitUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelBenefitUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelBenefitUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelBenefitUpdate.Location = new System.Drawing.Point(42, 169);
            this.BtnCancelBenefitUpdate.Name = "BtnCancelBenefitUpdate";
            this.BtnCancelBenefitUpdate.Size = new System.Drawing.Size(98, 47);
            this.BtnCancelBenefitUpdate.TabIndex = 48;
            this.BtnCancelBenefitUpdate.Text = "Cancel";
            this.BtnCancelBenefitUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelBenefitUpdate.Visible = false;
            this.BtnCancelBenefitUpdate.Click += new System.EventHandler(this.BtnCancelBenefitUpdate_Click);
            // 
            // NumUpDwnBenefitAmount
            // 
            this.NumUpDwnBenefitAmount.Location = new System.Drawing.Point(16, 125);
            this.NumUpDwnBenefitAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDwnBenefitAmount.Name = "NumUpDwnBenefitAmount";
            this.NumUpDwnBenefitAmount.Size = new System.Drawing.Size(228, 29);
            this.NumUpDwnBenefitAmount.TabIndex = 44;
            // 
            // BtnSaveBenefits
            // 
            this.BtnSaveBenefits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveBenefits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveBenefits.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveBenefits.ForeColor = System.Drawing.Color.White;
            this.BtnSaveBenefits.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveBenefits.Location = new System.Drawing.Point(146, 169);
            this.BtnSaveBenefits.Name = "BtnSaveBenefits";
            this.BtnSaveBenefits.Size = new System.Drawing.Size(98, 47);
            this.BtnSaveBenefits.TabIndex = 47;
            this.BtnSaveBenefits.Text = "Save";
            this.BtnSaveBenefits.UseVisualStyleBackColor = false;
            this.BtnSaveBenefits.Click += new System.EventHandler(this.BtnSaveBenefits_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 21);
            this.label3.TabIndex = 45;
            this.label3.Text = "Default amount";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Benefit title";
            // 
            // TbxBenefitTitle
            // 
            this.TbxBenefitTitle.Location = new System.Drawing.Point(16, 56);
            this.TbxBenefitTitle.Name = "TbxBenefitTitle";
            this.TbxBenefitTitle.Size = new System.Drawing.Size(228, 29);
            this.TbxBenefitTitle.TabIndex = 44;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.DGVSpecificEmployeeBenefits);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(908, 323);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Specific Employee Benefit";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DGVSpecificEmployeeBenefits
            // 
            this.DGVSpecificEmployeeBenefits.AllowUserToAddRows = false;
            this.DGVSpecificEmployeeBenefits.AllowUserToDeleteRows = false;
            this.DGVSpecificEmployeeBenefits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSpecificEmployeeBenefits.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGVSpecificEmployeeBenefits.Location = new System.Drawing.Point(316, 3);
            this.DGVSpecificEmployeeBenefits.Name = "DGVSpecificEmployeeBenefits";
            this.DGVSpecificEmployeeBenefits.ReadOnly = true;
            this.DGVSpecificEmployeeBenefits.RowTemplate.Height = 25;
            this.DGVSpecificEmployeeBenefits.Size = new System.Drawing.Size(589, 317);
            this.DGVSpecificEmployeeBenefits.TabIndex = 2;
            this.DGVSpecificEmployeeBenefits.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSpecificEmployeeBenefits_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.TBoxEmployeeNumber);
            this.groupBox3.Controls.Add(this.BtnCancelSpecificEmployeeBenefit);
            this.groupBox3.Controls.Add(this.NumUpDwBenefitAmount);
            this.groupBox3.Controls.Add(this.BtnSaveSpecificEmployeeBenefit);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.TBoxBenefitTitle);
            this.groupBox3.Location = new System.Drawing.Point(22, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 290);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 21);
            this.label8.TabIndex = 49;
            this.label8.Text = "Employee Number";
            // 
            // TBoxEmployeeNumber
            // 
            this.TBoxEmployeeNumber.Location = new System.Drawing.Point(16, 50);
            this.TBoxEmployeeNumber.Name = "TBoxEmployeeNumber";
            this.TBoxEmployeeNumber.Size = new System.Drawing.Size(228, 29);
            this.TBoxEmployeeNumber.TabIndex = 50;
            // 
            // BtnCancelSpecificEmployeeBenefit
            // 
            this.BtnCancelSpecificEmployeeBenefit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelSpecificEmployeeBenefit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelSpecificEmployeeBenefit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelSpecificEmployeeBenefit.ForeColor = System.Drawing.Color.White;
            this.BtnCancelSpecificEmployeeBenefit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelSpecificEmployeeBenefit.Location = new System.Drawing.Point(42, 224);
            this.BtnCancelSpecificEmployeeBenefit.Name = "BtnCancelSpecificEmployeeBenefit";
            this.BtnCancelSpecificEmployeeBenefit.Size = new System.Drawing.Size(98, 47);
            this.BtnCancelSpecificEmployeeBenefit.TabIndex = 48;
            this.BtnCancelSpecificEmployeeBenefit.Text = "Cancel";
            this.BtnCancelSpecificEmployeeBenefit.UseVisualStyleBackColor = false;
            this.BtnCancelSpecificEmployeeBenefit.Visible = false;
            this.BtnCancelSpecificEmployeeBenefit.Click += new System.EventHandler(this.BtnCancelSpecificEmployeeBenefit_Click);
            // 
            // NumUpDwBenefitAmount
            // 
            this.NumUpDwBenefitAmount.Location = new System.Drawing.Point(16, 175);
            this.NumUpDwBenefitAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDwBenefitAmount.Name = "NumUpDwBenefitAmount";
            this.NumUpDwBenefitAmount.Size = new System.Drawing.Size(228, 29);
            this.NumUpDwBenefitAmount.TabIndex = 44;
            // 
            // BtnSaveSpecificEmployeeBenefit
            // 
            this.BtnSaveSpecificEmployeeBenefit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveSpecificEmployeeBenefit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveSpecificEmployeeBenefit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveSpecificEmployeeBenefit.ForeColor = System.Drawing.Color.White;
            this.BtnSaveSpecificEmployeeBenefit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveSpecificEmployeeBenefit.Location = new System.Drawing.Point(146, 224);
            this.BtnSaveSpecificEmployeeBenefit.Name = "BtnSaveSpecificEmployeeBenefit";
            this.BtnSaveSpecificEmployeeBenefit.Size = new System.Drawing.Size(98, 47);
            this.BtnSaveSpecificEmployeeBenefit.TabIndex = 47;
            this.BtnSaveSpecificEmployeeBenefit.Text = "Save";
            this.BtnSaveSpecificEmployeeBenefit.UseVisualStyleBackColor = false;
            this.BtnSaveSpecificEmployeeBenefit.Click += new System.EventHandler(this.BtnSaveSpecificEmployeeBenefit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 21);
            this.label6.TabIndex = 45;
            this.label6.Text = "Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Benefit title";
            // 
            // TBoxBenefitTitle
            // 
            this.TBoxBenefitTitle.Location = new System.Drawing.Point(16, 110);
            this.TBoxBenefitTitle.Name = "TBoxBenefitTitle";
            this.TBoxBenefitTitle.Size = new System.Drawing.Size(228, 29);
            this.TBoxBenefitTitle.TabIndex = 44;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DGVEmployeeDeductions);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(908, 323);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Deductions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DGVEmployeeDeductions
            // 
            this.DGVEmployeeDeductions.AllowUserToAddRows = false;
            this.DGVEmployeeDeductions.AllowUserToDeleteRows = false;
            this.DGVEmployeeDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeDeductions.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGVEmployeeDeductions.Location = new System.Drawing.Point(323, 3);
            this.DGVEmployeeDeductions.Name = "DGVEmployeeDeductions";
            this.DGVEmployeeDeductions.ReadOnly = true;
            this.DGVEmployeeDeductions.RowTemplate.Height = 25;
            this.DGVEmployeeDeductions.Size = new System.Drawing.Size(582, 317);
            this.DGVEmployeeDeductions.TabIndex = 3;
            this.DGVEmployeeDeductions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployeeDeductions_CellClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnCancelUpdateEmpDeduction);
            this.groupBox2.Controls.Add(this.NumUpDwnDeductionAmount);
            this.groupBox2.Controls.Add(this.BtnSaveEmpDeduction);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TBoxDeductionTitle);
            this.groupBox2.Location = new System.Drawing.Point(18, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 234);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Save";
            // 
            // BtnCancelUpdateEmpDeduction
            // 
            this.BtnCancelUpdateEmpDeduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdateEmpDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdateEmpDeduction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdateEmpDeduction.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdateEmpDeduction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdateEmpDeduction.Location = new System.Drawing.Point(42, 160);
            this.BtnCancelUpdateEmpDeduction.Name = "BtnCancelUpdateEmpDeduction";
            this.BtnCancelUpdateEmpDeduction.Size = new System.Drawing.Size(98, 47);
            this.BtnCancelUpdateEmpDeduction.TabIndex = 49;
            this.BtnCancelUpdateEmpDeduction.Text = "Cancel";
            this.BtnCancelUpdateEmpDeduction.UseVisualStyleBackColor = false;
            this.BtnCancelUpdateEmpDeduction.Visible = false;
            this.BtnCancelUpdateEmpDeduction.Click += new System.EventHandler(this.BtnCancelUpdateEmpDeduction_Click);
            // 
            // NumUpDwnDeductionAmount
            // 
            this.NumUpDwnDeductionAmount.Location = new System.Drawing.Point(16, 125);
            this.NumUpDwnDeductionAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDwnDeductionAmount.Name = "NumUpDwnDeductionAmount";
            this.NumUpDwnDeductionAmount.Size = new System.Drawing.Size(228, 29);
            this.NumUpDwnDeductionAmount.TabIndex = 44;
            // 
            // BtnSaveEmpDeduction
            // 
            this.BtnSaveEmpDeduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveEmpDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveEmpDeduction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveEmpDeduction.ForeColor = System.Drawing.Color.White;
            this.BtnSaveEmpDeduction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveEmpDeduction.Location = new System.Drawing.Point(146, 160);
            this.BtnSaveEmpDeduction.Name = "BtnSaveEmpDeduction";
            this.BtnSaveEmpDeduction.Size = new System.Drawing.Size(98, 47);
            this.BtnSaveEmpDeduction.TabIndex = 47;
            this.BtnSaveEmpDeduction.Text = "Save";
            this.BtnSaveEmpDeduction.UseVisualStyleBackColor = false;
            this.BtnSaveEmpDeduction.Click += new System.EventHandler(this.BtnSaveEmpDeduction_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 21);
            this.label4.TabIndex = 45;
            this.label4.Text = "Default amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "Deduction Title";
            // 
            // TBoxDeductionTitle
            // 
            this.TBoxDeductionTitle.Location = new System.Drawing.Point(16, 56);
            this.TBoxDeductionTitle.Name = "TBoxDeductionTitle";
            this.TBoxDeductionTitle.Size = new System.Drawing.Size(228, 29);
            this.TBoxDeductionTitle.TabIndex = 44;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.DGVSpecificEmployeeDeductions);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(908, 323);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Specific Employee Deduction";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // DGVSpecificEmployeeDeductions
            // 
            this.DGVSpecificEmployeeDeductions.AllowUserToAddRows = false;
            this.DGVSpecificEmployeeDeductions.AllowUserToDeleteRows = false;
            this.DGVSpecificEmployeeDeductions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSpecificEmployeeDeductions.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGVSpecificEmployeeDeductions.Location = new System.Drawing.Point(316, 3);
            this.DGVSpecificEmployeeDeductions.Name = "DGVSpecificEmployeeDeductions";
            this.DGVSpecificEmployeeDeductions.ReadOnly = true;
            this.DGVSpecificEmployeeDeductions.RowTemplate.Height = 25;
            this.DGVSpecificEmployeeDeductions.Size = new System.Drawing.Size(589, 317);
            this.DGVSpecificEmployeeDeductions.TabIndex = 3;
            this.DGVSpecificEmployeeDeductions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVSpecificEmployeeDeductions_CellClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.TboxEmployeeNumberForDeduction);
            this.groupBox4.Controls.Add(this.BtnCancelSpecificEmployeeDeduction);
            this.groupBox4.Controls.Add(this.NumUpDwnSpecificEmployeeDeductionAmount);
            this.groupBox4.Controls.Add(this.BtnSaveSpecificEmployeeDeduction);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.TboxSpecificEmpDeductionTitle);
            this.groupBox4.Location = new System.Drawing.Point(19, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(260, 290);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Save";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 21);
            this.label9.TabIndex = 49;
            this.label9.Text = "Employee Number";
            // 
            // TboxEmployeeNumberForDeduction
            // 
            this.TboxEmployeeNumberForDeduction.Location = new System.Drawing.Point(16, 50);
            this.TboxEmployeeNumberForDeduction.Name = "TboxEmployeeNumberForDeduction";
            this.TboxEmployeeNumberForDeduction.Size = new System.Drawing.Size(228, 29);
            this.TboxEmployeeNumberForDeduction.TabIndex = 50;
            // 
            // BtnCancelSpecificEmployeeDeduction
            // 
            this.BtnCancelSpecificEmployeeDeduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelSpecificEmployeeDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelSpecificEmployeeDeduction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelSpecificEmployeeDeduction.ForeColor = System.Drawing.Color.White;
            this.BtnCancelSpecificEmployeeDeduction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelSpecificEmployeeDeduction.Location = new System.Drawing.Point(42, 224);
            this.BtnCancelSpecificEmployeeDeduction.Name = "BtnCancelSpecificEmployeeDeduction";
            this.BtnCancelSpecificEmployeeDeduction.Size = new System.Drawing.Size(98, 47);
            this.BtnCancelSpecificEmployeeDeduction.TabIndex = 48;
            this.BtnCancelSpecificEmployeeDeduction.Text = "Cancel";
            this.BtnCancelSpecificEmployeeDeduction.UseVisualStyleBackColor = false;
            this.BtnCancelSpecificEmployeeDeduction.Visible = false;
            this.BtnCancelSpecificEmployeeDeduction.Click += new System.EventHandler(this.BtnCancelSpecificEmployeeDeduction_Click);
            // 
            // NumUpDwnSpecificEmployeeDeductionAmount
            // 
            this.NumUpDwnSpecificEmployeeDeductionAmount.Location = new System.Drawing.Point(16, 175);
            this.NumUpDwnSpecificEmployeeDeductionAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDwnSpecificEmployeeDeductionAmount.Name = "NumUpDwnSpecificEmployeeDeductionAmount";
            this.NumUpDwnSpecificEmployeeDeductionAmount.Size = new System.Drawing.Size(228, 29);
            this.NumUpDwnSpecificEmployeeDeductionAmount.TabIndex = 44;
            // 
            // BtnSaveSpecificEmployeeDeduction
            // 
            this.BtnSaveSpecificEmployeeDeduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveSpecificEmployeeDeduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveSpecificEmployeeDeduction.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveSpecificEmployeeDeduction.ForeColor = System.Drawing.Color.White;
            this.BtnSaveSpecificEmployeeDeduction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveSpecificEmployeeDeduction.Location = new System.Drawing.Point(146, 224);
            this.BtnSaveSpecificEmployeeDeduction.Name = "BtnSaveSpecificEmployeeDeduction";
            this.BtnSaveSpecificEmployeeDeduction.Size = new System.Drawing.Size(98, 47);
            this.BtnSaveSpecificEmployeeDeduction.TabIndex = 47;
            this.BtnSaveSpecificEmployeeDeduction.Text = "Save";
            this.BtnSaveSpecificEmployeeDeduction.UseVisualStyleBackColor = false;
            this.BtnSaveSpecificEmployeeDeduction.Click += new System.EventHandler(this.BtnSaveSpecificEmployeeDeduction_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 21);
            this.label10.TabIndex = 45;
            this.label10.Text = "Amount";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(114, 21);
            this.label11.TabIndex = 2;
            this.label11.Text = "Deduction Title";
            // 
            // TboxSpecificEmpDeductionTitle
            // 
            this.TboxSpecificEmpDeductionTitle.Location = new System.Drawing.Point(16, 110);
            this.TboxSpecificEmpDeductionTitle.Name = "TboxSpecificEmpDeductionTitle";
            this.TboxSpecificEmpDeductionTitle.Size = new System.Drawing.Size(228, 29);
            this.TboxSpecificEmpDeductionTitle.TabIndex = 44;
            // 
            // EmployeeBenefitsAndDeductions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "EmployeeBenefitsAndDeductions";
            this.Size = new System.Drawing.Size(916, 451);
            this.Load += new System.EventHandler(this.EmployeeBenefitsAndDeductions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeBenefits)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnBenefitAmount)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSpecificEmployeeBenefits)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwBenefitAmount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeDeductions)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnDeductionAmount)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSpecificEmployeeDeductions)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnSpecificEmployeeDeductionAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DGVEmployeeBenefits;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbxBenefitTitle;
        private System.Windows.Forms.Button BtnSaveBenefits;
        private System.Windows.Forms.NumericUpDown NumUpDwnBenefitAmount;
        private System.Windows.Forms.DataGridView DGVEmployeeDeductions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown NumUpDwnDeductionAmount;
        private System.Windows.Forms.Button BtnSaveEmpDeduction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBoxDeductionTitle;
        private System.Windows.Forms.Button BtnCancelBenefitUpdate;
        private System.Windows.Forms.Button BtnCancelUpdateEmpDeduction;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TBoxEmployeeNumber;
        private System.Windows.Forms.Button BtnCancelSpecificEmployeeBenefit;
        private System.Windows.Forms.NumericUpDown NumUpDwBenefitAmount;
        private System.Windows.Forms.Button BtnSaveSpecificEmployeeBenefit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBoxBenefitTitle;
        private System.Windows.Forms.DataGridView DGVSpecificEmployeeBenefits;
        private System.Windows.Forms.DataGridView DGVSpecificEmployeeDeductions;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TboxEmployeeNumberForDeduction;
        private System.Windows.Forms.Button BtnCancelSpecificEmployeeDeduction;
        private System.Windows.Forms.NumericUpDown NumUpDwnSpecificEmployeeDeductionAmount;
        private System.Windows.Forms.Button BtnSaveSpecificEmployeeDeduction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TboxSpecificEmpDeductionTitle;
    }
}
