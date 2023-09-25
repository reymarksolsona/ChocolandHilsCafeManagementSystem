
namespace Main.Forms.PayrollForms.Controls
{
    partial class PayrollReportControl
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
            this.LVEmployeePayslipsHistory = new System.Windows.Forms.ListView();
            this.CHLV_EmpNum = new System.Windows.Forms.ColumnHeader();
            this.CHLV_Fullname = new System.Windows.Forms.ColumnHeader();
            this.CHLV_ShiftRange = new System.Windows.Forms.ColumnHeader();
            this.CHLV_DailyRate = new System.Windows.Forms.ColumnHeader();
            this.CHLV_Late = new System.Windows.Forms.ColumnHeader();
            this.CHLV_LateDeduction = new System.Windows.Forms.ColumnHeader();
            this.CHLV_UT = new System.Windows.Forms.ColumnHeader();
            this.CHLV_UTDeduction = new System.Windows.Forms.ColumnHeader();
            this.CHLV_NetBasicSalary = new System.Windows.Forms.ColumnHeader();
            this.CHLV_BenefitsTotal = new System.Windows.Forms.ColumnHeader();
            this.CHLV_DeductionsTotal = new System.Windows.Forms.ColumnHeader();
            this.CHLV_NetTakeHomePay = new System.Windows.Forms.ColumnHeader();
            this.CHLV_WorkDays = new System.Windows.Forms.ColumnHeader();
            this.CHLV_EEGovContrib = new System.Windows.Forms.ColumnHeader();
            this.CHLV_ERGovContrib = new System.Windows.Forms.ColumnHeader();
            this.CHVL_TotalGovContrib = new System.Windows.Forms.ColumnHeader();
            this.BtnFilterPayrollHistory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CBoxPayslipDates = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnGenerateEmployeePayslipsReportPDF = new System.Windows.Forms.Button();
            this.LblTotalPayment = new System.Windows.Forms.Label();
            this.BtnGenerateEmpGovContributionReport = new System.Windows.Forms.Button();
            this.BtnGenerateReportGovContrib = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.CboxMonths = new System.Windows.Forms.ComboBox();
            this.BtnMonthsForEmpGovContrib = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LblTotalPayment);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(1367, 52);
            this.panel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Payroll report";
            // 
            // LVEmployeePayslipsHistory
            // 
            this.LVEmployeePayslipsHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CHLV_EmpNum,
            this.CHLV_Fullname,
            this.CHLV_ShiftRange,
            this.CHLV_DailyRate,
            this.CHLV_Late,
            this.CHLV_LateDeduction,
            this.CHLV_UT,
            this.CHLV_UTDeduction,
            this.CHLV_NetBasicSalary,
            this.CHLV_BenefitsTotal,
            this.CHLV_DeductionsTotal,
            this.CHLV_NetTakeHomePay,
            this.CHLV_WorkDays,
            this.CHLV_EEGovContrib,
            this.CHLV_ERGovContrib,
            this.CHVL_TotalGovContrib});
            this.LVEmployeePayslipsHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LVEmployeePayslipsHistory.GridLines = true;
            this.LVEmployeePayslipsHistory.HideSelection = false;
            this.LVEmployeePayslipsHistory.Location = new System.Drawing.Point(0, 120);
            this.LVEmployeePayslipsHistory.Name = "LVEmployeePayslipsHistory";
            this.LVEmployeePayslipsHistory.Size = new System.Drawing.Size(1367, 428);
            this.LVEmployeePayslipsHistory.TabIndex = 9;
            this.LVEmployeePayslipsHistory.UseCompatibleStateImageBehavior = false;
            this.LVEmployeePayslipsHistory.View = System.Windows.Forms.View.Details;
            // 
            // CHLV_EmpNum
            // 
            this.CHLV_EmpNum.Text = "Emp#";
            // 
            // CHLV_Fullname
            // 
            this.CHLV_Fullname.Text = "Fullname";
            this.CHLV_Fullname.Width = 100;
            // 
            // CHLV_ShiftRange
            // 
            this.CHLV_ShiftRange.Text = "Shift Range";
            this.CHLV_ShiftRange.Width = 100;
            // 
            // CHLV_DailyRate
            // 
            this.CHLV_DailyRate.Text = "Daily Rate";
            this.CHLV_DailyRate.Width = 80;
            // 
            // CHLV_Late
            // 
            this.CHLV_Late.Text = "Late";
            // 
            // CHLV_LateDeduction
            // 
            this.CHLV_LateDeduction.Text = "Late Deduction";
            this.CHLV_LateDeduction.Width = 80;
            // 
            // CHLV_UT
            // 
            this.CHLV_UT.Text = "UT";
            // 
            // CHLV_UTDeduction
            // 
            this.CHLV_UTDeduction.Text = "UT Deduction";
            this.CHLV_UTDeduction.Width = 80;
            // 
            // CHLV_NetBasicSalary
            // 
            this.CHLV_NetBasicSalary.Text = "Net Basic Salary";
            this.CHLV_NetBasicSalary.Width = 80;
            // 
            // CHLV_BenefitsTotal
            // 
            this.CHLV_BenefitsTotal.Text = "Benefits";
            this.CHLV_BenefitsTotal.Width = 80;
            // 
            // CHLV_DeductionsTotal
            // 
            this.CHLV_DeductionsTotal.Text = "Deductions";
            this.CHLV_DeductionsTotal.Width = 80;
            // 
            // CHLV_NetTakeHomePay
            // 
            this.CHLV_NetTakeHomePay.Text = "Net Take Home Pay";
            this.CHLV_NetTakeHomePay.Width = 80;
            // 
            // CHLV_WorkDays
            // 
            this.CHLV_WorkDays.Text = "Days";
            this.CHLV_WorkDays.Width = 50;
            // 
            // CHLV_EEGovContrib
            // 
            this.CHLV_EEGovContrib.Text = "EE Govt. Contrib";
            this.CHLV_EEGovContrib.Width = 100;
            // 
            // CHLV_ERGovContrib
            // 
            this.CHLV_ERGovContrib.Text = "ER Gov Contrib";
            this.CHLV_ERGovContrib.Width = 100;
            // 
            // CHVL_TotalGovContrib
            // 
            this.CHVL_TotalGovContrib.Text = "Total Gov Contrib";
            this.CHVL_TotalGovContrib.Width = 100;
            // 
            // BtnFilterPayrollHistory
            // 
            this.BtnFilterPayrollHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnFilterPayrollHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilterPayrollHistory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnFilterPayrollHistory.ForeColor = System.Drawing.Color.White;
            this.BtnFilterPayrollHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFilterPayrollHistory.Location = new System.Drawing.Point(252, 69);
            this.BtnFilterPayrollHistory.Name = "BtnFilterPayrollHistory";
            this.BtnFilterPayrollHistory.Size = new System.Drawing.Size(69, 29);
            this.BtnFilterPayrollHistory.TabIndex = 55;
            this.BtnFilterPayrollHistory.Text = "Filter";
            this.BtnFilterPayrollHistory.UseVisualStyleBackColor = false;
            this.BtnFilterPayrollHistory.Click += new System.EventHandler(this.BtnFilterPayrollHistory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 53;
            this.label1.Text = "PayDate";
            // 
            // CBoxPayslipDates
            // 
            this.CBoxPayslipDates.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxPayslipDates.FormattingEnabled = true;
            this.CBoxPayslipDates.Location = new System.Drawing.Point(94, 69);
            this.CBoxPayslipDates.Name = "CBoxPayslipDates";
            this.CBoxPayslipDates.Size = new System.Drawing.Size(152, 29);
            this.CBoxPayslipDates.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(215, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 21);
            this.label3.TabIndex = 56;
            this.label3.Text = "Total:";
            // 
            // BtnGenerateEmployeePayslipsReportPDF
            // 
            this.BtnGenerateEmployeePayslipsReportPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGenerateEmployeePayslipsReportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateEmployeePayslipsReportPDF.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerateEmployeePayslipsReportPDF.ForeColor = System.Drawing.Color.White;
            this.BtnGenerateEmployeePayslipsReportPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateEmployeePayslipsReportPDF.Location = new System.Drawing.Point(327, 69);
            this.BtnGenerateEmployeePayslipsReportPDF.Name = "BtnGenerateEmployeePayslipsReportPDF";
            this.BtnGenerateEmployeePayslipsReportPDF.Size = new System.Drawing.Size(169, 29);
            this.BtnGenerateEmployeePayslipsReportPDF.TabIndex = 57;
            this.BtnGenerateEmployeePayslipsReportPDF.Text = "Generate PDF Report";
            this.BtnGenerateEmployeePayslipsReportPDF.UseVisualStyleBackColor = false;
            this.BtnGenerateEmployeePayslipsReportPDF.Click += new System.EventHandler(this.BtnGenerateEmployeePayslipsReportPDF_Click);
            // 
            // LblTotalPayment
            // 
            this.LblTotalPayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblTotalPayment.ForeColor = System.Drawing.Color.White;
            this.LblTotalPayment.Location = new System.Drawing.Point(266, 14);
            this.LblTotalPayment.Name = "LblTotalPayment";
            this.LblTotalPayment.Size = new System.Drawing.Size(230, 21);
            this.LblTotalPayment.TabIndex = 58;
            this.LblTotalPayment.Text = "00000";
            // 
            // BtnGenerateEmpGovContributionReport
            // 
            this.BtnGenerateEmpGovContributionReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGenerateEmpGovContributionReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateEmpGovContributionReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerateEmpGovContributionReport.ForeColor = System.Drawing.Color.White;
            this.BtnGenerateEmpGovContributionReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateEmpGovContributionReport.Location = new System.Drawing.Point(1108, 72);
            this.BtnGenerateEmpGovContributionReport.Name = "BtnGenerateEmpGovContributionReport";
            this.BtnGenerateEmpGovContributionReport.Size = new System.Drawing.Size(242, 29);
            this.BtnGenerateEmpGovContributionReport.TabIndex = 59;
            this.BtnGenerateEmpGovContributionReport.Text = "Government Contribution report";
            this.BtnGenerateEmpGovContributionReport.UseVisualStyleBackColor = false;
            this.BtnGenerateEmpGovContributionReport.Click += new System.EventHandler(this.BtnGenerateEmpGovContributionReport_Click);
            // 
            // BtnGenerateReportGovContrib
            // 
            this.BtnGenerateReportGovContrib.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGenerateReportGovContrib.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateReportGovContrib.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerateReportGovContrib.ForeColor = System.Drawing.Color.White;
            this.BtnGenerateReportGovContrib.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateReportGovContrib.Location = new System.Drawing.Point(502, 69);
            this.BtnGenerateReportGovContrib.Name = "BtnGenerateReportGovContrib";
            this.BtnGenerateReportGovContrib.Size = new System.Drawing.Size(169, 29);
            this.BtnGenerateReportGovContrib.TabIndex = 59;
            this.BtnGenerateReportGovContrib.Text = "Gov. Contrib PDF Report";
            this.BtnGenerateReportGovContrib.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(867, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 21);
            this.label4.TabIndex = 60;
            this.label4.Text = "Month";
            // 
            // CboxMonths
            // 
            this.CboxMonths.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CboxMonths.FormattingEnabled = true;
            this.CboxMonths.Location = new System.Drawing.Point(939, 72);
            this.CboxMonths.Name = "CboxMonths";
            this.CboxMonths.Size = new System.Drawing.Size(152, 29);
            this.CboxMonths.TabIndex = 61;
            // 
            // BtnMonthsForEmpGovContrib
            // 
            this.BtnMonthsForEmpGovContrib.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnMonthsForEmpGovContrib.FormattingEnabled = true;
            this.BtnMonthsForEmpGovContrib.Location = new System.Drawing.Point(939, 72);
            this.BtnMonthsForEmpGovContrib.Name = "BtnMonthsForEmpGovContrib";
            this.BtnMonthsForEmpGovContrib.Size = new System.Drawing.Size(152, 29);
            this.BtnMonthsForEmpGovContrib.TabIndex = 61;
            // 
            // PayrollReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CboxMonths);
            this.Controls.Add(this.BtnGenerateEmpGovContributionReport);
            this.Controls.Add(this.BtnGenerateEmployeePayslipsReportPDF);
            this.Controls.Add(this.BtnFilterPayrollHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBoxPayslipDates);
            this.Controls.Add(this.LVEmployeePayslipsHistory);
            this.Controls.Add(this.panel1);
            this.Name = "PayrollReportControl";
            this.Size = new System.Drawing.Size(1367, 548);
            this.Load += new System.EventHandler(this.PayrollReportControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView LVEmployeePayslipsHistory;
        private System.Windows.Forms.Button BtnFilterPayrollHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBoxPayslipDates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnGenerateEmployeePayslipsReportPDF;
        private System.Windows.Forms.Label LblTotalPayment;
        private System.Windows.Forms.ColumnHeader CHLV_EmpNum;
        private System.Windows.Forms.ColumnHeader CHLV_Fullname;
        private System.Windows.Forms.ColumnHeader CHLV_ShiftRange;
        private System.Windows.Forms.ColumnHeader CHLV_DailyRate;
        private System.Windows.Forms.ColumnHeader CHLV_Late;
        private System.Windows.Forms.ColumnHeader CHLV_LateDeduction;
        private System.Windows.Forms.ColumnHeader CHLV_UT;
        private System.Windows.Forms.ColumnHeader CHLV_UTDeduction;
        private System.Windows.Forms.ColumnHeader CHLV_NetBasicSalary;
        private System.Windows.Forms.ColumnHeader CHLV_BenefitsTotal;
        private System.Windows.Forms.ColumnHeader CHLV_DeductionsTotal;
        private System.Windows.Forms.ColumnHeader CHLV_NetTakeHomePay;
        private System.Windows.Forms.ColumnHeader CHLV_WorkDays;
        private System.Windows.Forms.ColumnHeader CHLV_EmployerContribution;
        private System.Windows.Forms.ColumnHeader CHLV_EEGovContrib;
        private System.Windows.Forms.ColumnHeader CHLV_ERGovContrib;
        private System.Windows.Forms.ColumnHeader CHVL_TotalGovContrib;
        private System.Windows.Forms.Button BtnGenerateEmpGovContributionReport;
        private System.Windows.Forms.Button BtnGenerateReportGovContrib;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CboxMonths;
        private System.Windows.Forms.ComboBox BtnMonthsForEmpGovContrib;
    }
}
