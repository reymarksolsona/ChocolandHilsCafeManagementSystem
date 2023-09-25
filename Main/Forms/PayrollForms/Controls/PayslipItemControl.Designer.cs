
namespace Main.Forms.PayrollForms.Controls
{
    partial class PayslipItemControl
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
            this.label23 = new System.Windows.Forms.Label();
            this.LblEmployeeName = new System.Windows.Forms.Label();
            this.LblEmployeeNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LblTotalNetTakeHomePay = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LblTotalDeductions = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblTotalIncome = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.LVPayslipDeductions = new System.Windows.Forms.ListView();
            this.LVCDeductions = new System.Windows.Forms.ColumnHeader();
            this.LVCDeductionAmount = new System.Windows.Forms.ColumnHeader();
            this.LVPayslipEarnings = new System.Windows.Forms.ListView();
            this.LVCEarnings = new System.Windows.Forms.ColumnHeader();
            this.LVCMultiplier = new System.Windows.Forms.ColumnHeader();
            this.LVCAmount = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.LblShiftStartDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblShiftEndDate = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(9, 7);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(78, 21);
            this.label23.TabIndex = 43;
            this.label23.Text = "Employee";
            // 
            // LblEmployeeName
            // 
            this.LblEmployeeName.AutoSize = true;
            this.LblEmployeeName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEmployeeName.ForeColor = System.Drawing.Color.Black;
            this.LblEmployeeName.Location = new System.Drawing.Point(93, 7);
            this.LblEmployeeName.Name = "LblEmployeeName";
            this.LblEmployeeName.Size = new System.Drawing.Size(28, 21);
            this.LblEmployeeName.TabIndex = 44;
            this.LblEmployeeName.Text = "---";
            // 
            // LblEmployeeNumber
            // 
            this.LblEmployeeNumber.AutoSize = true;
            this.LblEmployeeNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblEmployeeNumber.ForeColor = System.Drawing.Color.Black;
            this.LblEmployeeNumber.Location = new System.Drawing.Point(477, 7);
            this.LblEmployeeNumber.Name = "LblEmployeeNumber";
            this.LblEmployeeNumber.Size = new System.Drawing.Size(28, 21);
            this.LblEmployeeNumber.TabIndex = 46;
            this.LblEmployeeNumber.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(421, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 21);
            this.label3.TabIndex = 45;
            this.label3.Text = "ID No";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.Controls.Add(this.LblTotalNetTakeHomePay);
            this.panel5.Controls.Add(this.label28);
            this.panel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel5.Location = new System.Drawing.Point(10, 335);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(728, 33);
            this.panel5.TabIndex = 60;
            // 
            // LblTotalNetTakeHomePay
            // 
            this.LblTotalNetTakeHomePay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTotalNetTakeHomePay.ForeColor = System.Drawing.Color.Black;
            this.LblTotalNetTakeHomePay.Location = new System.Drawing.Point(552, 7);
            this.LblTotalNetTakeHomePay.Name = "LblTotalNetTakeHomePay";
            this.LblTotalNetTakeHomePay.Size = new System.Drawing.Size(159, 21);
            this.LblTotalNetTakeHomePay.TabIndex = 51;
            this.LblTotalNetTakeHomePay.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(353, 7);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(174, 17);
            this.label28.TabIndex = 49;
            this.label28.Text = "Your Net Take Home Pay >>";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Controls.Add(this.LblTotalDeductions);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel4.Location = new System.Drawing.Point(382, 296);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(356, 33);
            this.panel4.TabIndex = 59;
            // 
            // LblTotalDeductions
            // 
            this.LblTotalDeductions.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTotalDeductions.ForeColor = System.Drawing.Color.Black;
            this.LblTotalDeductions.Location = new System.Drawing.Point(180, 6);
            this.LblTotalDeductions.Name = "LblTotalDeductions";
            this.LblTotalDeductions.Size = new System.Drawing.Size(159, 21);
            this.LblTotalDeductions.TabIndex = 51;
            this.LblTotalDeductions.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(50, 6);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(105, 17);
            this.label27.TabIndex = 49;
            this.label27.Text = "Total Deductions";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.LblTotalIncome);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(10, 296);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 33);
            this.panel3.TabIndex = 58;
            // 
            // LblTotalIncome
            // 
            this.LblTotalIncome.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTotalIncome.ForeColor = System.Drawing.Color.Black;
            this.LblTotalIncome.Location = new System.Drawing.Point(201, 6);
            this.LblTotalIncome.Name = "LblTotalIncome";
            this.LblTotalIncome.Size = new System.Drawing.Size(147, 21);
            this.LblTotalIncome.TabIndex = 50;
            this.LblTotalIncome.Text = "0";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(83, 10);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(82, 17);
            this.label24.TabIndex = 49;
            this.label24.Text = "Total Income";
            // 
            // LVPayslipDeductions
            // 
            this.LVPayslipDeductions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LVCDeductions,
            this.LVCDeductionAmount});
            this.LVPayslipDeductions.GridLines = true;
            this.LVPayslipDeductions.HideSelection = false;
            this.LVPayslipDeductions.Location = new System.Drawing.Point(382, 60);
            this.LVPayslipDeductions.Name = "LVPayslipDeductions";
            this.LVPayslipDeductions.Size = new System.Drawing.Size(356, 230);
            this.LVPayslipDeductions.TabIndex = 57;
            this.LVPayslipDeductions.UseCompatibleStateImageBehavior = false;
            this.LVPayslipDeductions.View = System.Windows.Forms.View.Details;
            // 
            // LVCDeductions
            // 
            this.LVCDeductions.Text = "Deductions";
            this.LVCDeductions.Width = 150;
            // 
            // LVCDeductionAmount
            // 
            this.LVCDeductionAmount.Text = "Amount";
            this.LVCDeductionAmount.Width = 200;
            // 
            // LVPayslipEarnings
            // 
            this.LVPayslipEarnings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LVCEarnings,
            this.LVCMultiplier,
            this.LVCAmount});
            this.LVPayslipEarnings.GridLines = true;
            this.LVPayslipEarnings.HideSelection = false;
            this.LVPayslipEarnings.Location = new System.Drawing.Point(10, 60);
            this.LVPayslipEarnings.Name = "LVPayslipEarnings";
            this.LVPayslipEarnings.Size = new System.Drawing.Size(356, 230);
            this.LVPayslipEarnings.TabIndex = 56;
            this.LVPayslipEarnings.UseCompatibleStateImageBehavior = false;
            this.LVPayslipEarnings.View = System.Windows.Forms.View.Details;
            // 
            // LVCEarnings
            // 
            this.LVCEarnings.Text = "Earnings";
            this.LVCEarnings.Width = 150;
            // 
            // LVCMultiplier
            // 
            this.LVCMultiplier.Text = "Multiplier";
            this.LVCMultiplier.Width = 80;
            // 
            // LVCAmount
            // 
            this.LVCAmount.Text = "Amount";
            this.LVCAmount.Width = 120;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 61;
            this.label1.Text = "Shift From:";
            // 
            // LblShiftStartDate
            // 
            this.LblShiftStartDate.AutoSize = true;
            this.LblShiftStartDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblShiftStartDate.ForeColor = System.Drawing.Color.Black;
            this.LblShiftStartDate.Location = new System.Drawing.Point(83, 40);
            this.LblShiftStartDate.Name = "LblShiftStartDate";
            this.LblShiftStartDate.Size = new System.Drawing.Size(74, 17);
            this.LblShiftStartDate.TabIndex = 62;
            this.LblShiftStartDate.Text = "0000/00/00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(163, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 63;
            this.label4.Text = "To:";
            // 
            // LblShiftEndDate
            // 
            this.LblShiftEndDate.AutoSize = true;
            this.LblShiftEndDate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblShiftEndDate.ForeColor = System.Drawing.Color.Black;
            this.LblShiftEndDate.Location = new System.Drawing.Point(194, 40);
            this.LblShiftEndDate.Name = "LblShiftEndDate";
            this.LblShiftEndDate.Size = new System.Drawing.Size(74, 17);
            this.LblShiftEndDate.TabIndex = 64;
            this.LblShiftEndDate.Text = "0000/00/00";
            // 
            // PayslipItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LblShiftEndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LblShiftStartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.LVPayslipDeductions);
            this.Controls.Add(this.LVPayslipEarnings);
            this.Controls.Add(this.LblEmployeeNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblEmployeeName);
            this.Controls.Add(this.label23);
            this.Name = "PayslipItemControl";
            this.Size = new System.Drawing.Size(745, 374);
            this.Load += new System.EventHandler(this.PayslipItemControl_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label LblEmployeeName;
        private System.Windows.Forms.Label LblEmployeeNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label LblTotalNetTakeHomePay;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label LblTotalDeductions;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblTotalIncome;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ListView LVPayslipDeductions;
        private System.Windows.Forms.ColumnHeader LVCDeductions;
        private System.Windows.Forms.ColumnHeader LVCDeductionAmount;
        private System.Windows.Forms.ListView LVPayslipEarnings;
        private System.Windows.Forms.ColumnHeader LVCEarnings;
        private System.Windows.Forms.ColumnHeader LVCMultiplier;
        private System.Windows.Forms.ColumnHeader LVCAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblShiftStartDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblShiftEndDate;
    }
}
