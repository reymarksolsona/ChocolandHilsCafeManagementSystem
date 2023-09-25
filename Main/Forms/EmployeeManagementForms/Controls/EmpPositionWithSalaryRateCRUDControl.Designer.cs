
namespace Main.Forms.EmployeeManagementForms.Controls
{
    partial class EmpPositionWithSalaryRateCRUDControl
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
            this.BtnUpdateNumberOfWorkingDaysInAMonth = new System.Windows.Forms.Button();
            this.NumUpDwnNumberOfWorkingDays = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GboxPositionForm = new System.Windows.Forms.GroupBox();
            this.NumUpDwnMonthlyRate = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.CboxSingleEmployee = new System.Windows.Forms.CheckBox();
            this.NumUpDwnDailyRate = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.BtnSavePosition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TbxPositionTitle = new System.Windows.Forms.TextBox();
            this.DGVPositionList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnNumberOfWorkingDays)).BeginInit();
            this.GboxPositionForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnMonthlyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnDailyRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPositionList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.BtnUpdateNumberOfWorkingDaysInAMonth);
            this.panel1.Controls.Add(this.NumUpDwnNumberOfWorkingDays);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(959, 59);
            this.panel1.TabIndex = 4;
            // 
            // BtnUpdateNumberOfWorkingDaysInAMonth
            // 
            this.BtnUpdateNumberOfWorkingDaysInAMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnUpdateNumberOfWorkingDaysInAMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUpdateNumberOfWorkingDaysInAMonth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnUpdateNumberOfWorkingDaysInAMonth.ForeColor = System.Drawing.Color.White;
            this.BtnUpdateNumberOfWorkingDaysInAMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUpdateNumberOfWorkingDaysInAMonth.Location = new System.Drawing.Point(885, 13);
            this.BtnUpdateNumberOfWorkingDaysInAMonth.Name = "BtnUpdateNumberOfWorkingDaysInAMonth";
            this.BtnUpdateNumberOfWorkingDaysInAMonth.Size = new System.Drawing.Size(62, 29);
            this.BtnUpdateNumberOfWorkingDaysInAMonth.TabIndex = 58;
            this.BtnUpdateNumberOfWorkingDaysInAMonth.Text = "Update";
            this.BtnUpdateNumberOfWorkingDaysInAMonth.UseVisualStyleBackColor = false;
            this.BtnUpdateNumberOfWorkingDaysInAMonth.Click += new System.EventHandler(this.BtnUpdateNumberOfWorkingDaysInAMonth_Click);
            // 
            // NumUpDwnNumberOfWorkingDays
            // 
            this.NumUpDwnNumberOfWorkingDays.DecimalPlaces = 2;
            this.NumUpDwnNumberOfWorkingDays.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumUpDwnNumberOfWorkingDays.Location = new System.Drawing.Point(704, 12);
            this.NumUpDwnNumberOfWorkingDays.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDwnNumberOfWorkingDays.Name = "NumUpDwnNumberOfWorkingDays";
            this.NumUpDwnNumberOfWorkingDays.Size = new System.Drawing.Size(175, 29);
            this.NumUpDwnNumberOfWorkingDays.TabIndex = 56;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Positions with salary rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(469, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 21);
            this.label4.TabIndex = 57;
            this.label4.Text = "# of working days every month:";
            // 
            // GboxPositionForm
            // 
            this.GboxPositionForm.Controls.Add(this.NumUpDwnMonthlyRate);
            this.GboxPositionForm.Controls.Add(this.label3);
            this.GboxPositionForm.Controls.Add(this.CboxSingleEmployee);
            this.GboxPositionForm.Controls.Add(this.NumUpDwnDailyRate);
            this.GboxPositionForm.Controls.Add(this.label5);
            this.GboxPositionForm.Controls.Add(this.BtnCancelUpdate);
            this.GboxPositionForm.Controls.Add(this.BtnSavePosition);
            this.GboxPositionForm.Controls.Add(this.label1);
            this.GboxPositionForm.Controls.Add(this.TbxPositionTitle);
            this.GboxPositionForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GboxPositionForm.Location = new System.Drawing.Point(13, 65);
            this.GboxPositionForm.Name = "GboxPositionForm";
            this.GboxPositionForm.Size = new System.Drawing.Size(277, 361);
            this.GboxPositionForm.TabIndex = 5;
            this.GboxPositionForm.TabStop = false;
            this.GboxPositionForm.Text = "Position";
            // 
            // NumUpDwnMonthlyRate
            // 
            this.NumUpDwnMonthlyRate.DecimalPlaces = 2;
            this.NumUpDwnMonthlyRate.Location = new System.Drawing.Point(17, 149);
            this.NumUpDwnMonthlyRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDwnMonthlyRate.Name = "NumUpDwnMonthlyRate";
            this.NumUpDwnMonthlyRate.Size = new System.Drawing.Size(245, 29);
            this.NumUpDwnMonthlyRate.TabIndex = 54;
            this.NumUpDwnMonthlyRate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumUpDwnMonthlyRate_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 21);
            this.label3.TabIndex = 55;
            this.label3.Text = "Monthly Rate";
            // 
            // CboxSingleEmployee
            // 
            this.CboxSingleEmployee.AutoSize = true;
            this.CboxSingleEmployee.Location = new System.Drawing.Point(17, 259);
            this.CboxSingleEmployee.Name = "CboxSingleEmployee";
            this.CboxSingleEmployee.Size = new System.Drawing.Size(164, 25);
            this.CboxSingleEmployee.TabIndex = 53;
            this.CboxSingleEmployee.Text = "One employee only";
            this.CboxSingleEmployee.UseVisualStyleBackColor = true;
            // 
            // NumUpDwnDailyRate
            // 
            this.NumUpDwnDailyRate.DecimalPlaces = 2;
            this.NumUpDwnDailyRate.Enabled = false;
            this.NumUpDwnDailyRate.Location = new System.Drawing.Point(17, 219);
            this.NumUpDwnDailyRate.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumUpDwnDailyRate.Name = "NumUpDwnDailyRate";
            this.NumUpDwnDailyRate.Size = new System.Drawing.Size(245, 29);
            this.NumUpDwnDailyRate.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 52;
            this.label5.Text = "Daily Rate";
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(60, 299);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(98, 47);
            this.BtnCancelUpdate.TabIndex = 48;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            this.BtnCancelUpdate.Click += new System.EventHandler(this.BtnCancelUpdate_Click);
            // 
            // BtnSavePosition
            // 
            this.BtnSavePosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSavePosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSavePosition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSavePosition.ForeColor = System.Drawing.Color.White;
            this.BtnSavePosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSavePosition.Location = new System.Drawing.Point(164, 299);
            this.BtnSavePosition.Name = "BtnSavePosition";
            this.BtnSavePosition.Size = new System.Drawing.Size(98, 47);
            this.BtnSavePosition.TabIndex = 47;
            this.BtnSavePosition.Text = "Save";
            this.BtnSavePosition.UseVisualStyleBackColor = false;
            this.BtnSavePosition.Click += new System.EventHandler(this.BtnSavePosition_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Position Title";
            // 
            // TbxPositionTitle
            // 
            this.TbxPositionTitle.Location = new System.Drawing.Point(17, 59);
            this.TbxPositionTitle.Multiline = true;
            this.TbxPositionTitle.Name = "TbxPositionTitle";
            this.TbxPositionTitle.Size = new System.Drawing.Size(245, 56);
            this.TbxPositionTitle.TabIndex = 44;
            // 
            // DGVPositionList
            // 
            this.DGVPositionList.AllowUserToAddRows = false;
            this.DGVPositionList.AllowUserToDeleteRows = false;
            this.DGVPositionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPositionList.Location = new System.Drawing.Point(307, 65);
            this.DGVPositionList.Name = "DGVPositionList";
            this.DGVPositionList.ReadOnly = true;
            this.DGVPositionList.RowTemplate.Height = 25;
            this.DGVPositionList.Size = new System.Drawing.Size(640, 361);
            this.DGVPositionList.TabIndex = 6;
            this.DGVPositionList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPositionList_CellClick);
            // 
            // EmpPositionWithSalaryRateCRUDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DGVPositionList);
            this.Controls.Add(this.GboxPositionForm);
            this.Controls.Add(this.panel1);
            this.Name = "EmpPositionWithSalaryRateCRUDControl";
            this.Size = new System.Drawing.Size(959, 444);
            this.Load += new System.EventHandler(this.EmpPositionWithSalaryRateCRUDControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnNumberOfWorkingDays)).EndInit();
            this.GboxPositionForm.ResumeLayout(false);
            this.GboxPositionForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnMonthlyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnDailyRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPositionList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GboxPositionForm;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.Button BtnSavePosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbxPositionTitle;
        private System.Windows.Forms.NumericUpDown NumUpDwnDailyRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DGVPositionList;
        private System.Windows.Forms.CheckBox CboxSingleEmployee;
        private System.Windows.Forms.NumericUpDown NumUpDwnMonthlyRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnUpdateNumberOfWorkingDaysInAMonth;
        private System.Windows.Forms.NumericUpDown NumUpDwnNumberOfWorkingDays;
        private System.Windows.Forms.Label label4;
    }
}
