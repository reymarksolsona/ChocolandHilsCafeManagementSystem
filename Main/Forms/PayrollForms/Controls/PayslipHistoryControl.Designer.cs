
namespace Main.Forms.PayrollForms.Controls
{
    partial class PayslipHistoryControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnGenerateEmployeePayslip = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVEmployeeList = new System.Windows.Forms.DataGridView();
            this.CBoxPayslipDates = new System.Windows.Forms.ComboBox();
            this.BtnCancelAllEmployeePayslip = new System.Windows.Forms.Button();
            this.PanelPayslipDetailsContainer = new System.Windows.Forms.Panel();
            this.BtnGeneratePayslipPDF = new System.Windows.Forms.Button();
            this.BtnCancelSelectedEmployeePayslip = new System.Windows.Forms.Button();
            this.BtnGeneratePayslipPDFAll = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1057, 52);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Payslip history";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.BtnGenerateEmployeePayslip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DGVEmployeeList);
            this.groupBox1.Controls.Add(this.CBoxPayslipDates);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(0, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 504);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 53;
            this.label3.Text = "Employees";
            // 
            // BtnGenerateEmployeePayslip
            // 
            this.BtnGenerateEmployeePayslip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGenerateEmployeePayslip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGenerateEmployeePayslip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGenerateEmployeePayslip.ForeColor = System.Drawing.Color.White;
            this.BtnGenerateEmployeePayslip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGenerateEmployeePayslip.Location = new System.Drawing.Point(174, 49);
            this.BtnGenerateEmployeePayslip.Name = "BtnGenerateEmployeePayslip";
            this.BtnGenerateEmployeePayslip.Size = new System.Drawing.Size(69, 29);
            this.BtnGenerateEmployeePayslip.TabIndex = 52;
            this.BtnGenerateEmployeePayslip.Text = "Filter";
            this.BtnGenerateEmployeePayslip.UseVisualStyleBackColor = false;
            this.BtnGenerateEmployeePayslip.Click += new System.EventHandler(this.BtnGenerateEmployeePayslip_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "PayDate";
            // 
            // DGVEmployeeList
            // 
            this.DGVEmployeeList.AllowUserToAddRows = false;
            this.DGVEmployeeList.AllowUserToDeleteRows = false;
            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVEmployeeList.Location = new System.Drawing.Point(3, 137);
            this.DGVEmployeeList.Name = "DGVEmployeeList";
            this.DGVEmployeeList.ReadOnly = true;
            this.DGVEmployeeList.RowTemplate.Height = 25;
            this.DGVEmployeeList.Size = new System.Drawing.Size(265, 361);
            this.DGVEmployeeList.TabIndex = 0;
            this.DGVEmployeeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployeeList_CellClick);
            // 
            // CBoxPayslipDates
            // 
            this.CBoxPayslipDates.FormattingEnabled = true;
            this.CBoxPayslipDates.Location = new System.Drawing.Point(16, 49);
            this.CBoxPayslipDates.Name = "CBoxPayslipDates";
            this.CBoxPayslipDates.Size = new System.Drawing.Size(152, 29);
            this.CBoxPayslipDates.TabIndex = 0;
            // 
            // BtnCancelAllEmployeePayslip
            // 
            this.BtnCancelAllEmployeePayslip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelAllEmployeePayslip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelAllEmployeePayslip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelAllEmployeePayslip.ForeColor = System.Drawing.Color.White;
            this.BtnCancelAllEmployeePayslip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelAllEmployeePayslip.Location = new System.Drawing.Point(502, 512);
            this.BtnCancelAllEmployeePayslip.Name = "BtnCancelAllEmployeePayslip";
            this.BtnCancelAllEmployeePayslip.Size = new System.Drawing.Size(105, 41);
            this.BtnCancelAllEmployeePayslip.TabIndex = 60;
            this.BtnCancelAllEmployeePayslip.Text = "Cancel All";
            this.BtnCancelAllEmployeePayslip.UseVisualStyleBackColor = false;
            this.BtnCancelAllEmployeePayslip.Click += new System.EventHandler(this.BtnCancelAllEmployeePayslip_Click);
            // 
            // PanelPayslipDetailsContainer
            // 
            this.PanelPayslipDetailsContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelPayslipDetailsContainer.Location = new System.Drawing.Point(271, 52);
            this.PanelPayslipDetailsContainer.Name = "PanelPayslipDetailsContainer";
            this.PanelPayslipDetailsContainer.Size = new System.Drawing.Size(786, 454);
            this.PanelPayslipDetailsContainer.TabIndex = 9;
            // 
            // BtnGeneratePayslipPDF
            // 
            this.BtnGeneratePayslipPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGeneratePayslipPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGeneratePayslipPDF.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGeneratePayslipPDF.ForeColor = System.Drawing.Color.White;
            this.BtnGeneratePayslipPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGeneratePayslipPDF.Location = new System.Drawing.Point(908, 512);
            this.BtnGeneratePayslipPDF.Name = "BtnGeneratePayslipPDF";
            this.BtnGeneratePayslipPDF.Size = new System.Drawing.Size(140, 41);
            this.BtnGeneratePayslipPDF.TabIndex = 58;
            this.BtnGeneratePayslipPDF.Text = "Generate PDF";
            this.BtnGeneratePayslipPDF.UseVisualStyleBackColor = false;
            this.BtnGeneratePayslipPDF.Click += new System.EventHandler(this.BtnGeneratePayslipPDF_Click);
            // 
            // BtnCancelSelectedEmployeePayslip
            // 
            this.BtnCancelSelectedEmployeePayslip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelSelectedEmployeePayslip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelSelectedEmployeePayslip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelSelectedEmployeePayslip.ForeColor = System.Drawing.Color.White;
            this.BtnCancelSelectedEmployeePayslip.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelSelectedEmployeePayslip.Location = new System.Drawing.Point(824, 512);
            this.BtnCancelSelectedEmployeePayslip.Name = "BtnCancelSelectedEmployeePayslip";
            this.BtnCancelSelectedEmployeePayslip.Size = new System.Drawing.Size(78, 41);
            this.BtnCancelSelectedEmployeePayslip.TabIndex = 59;
            this.BtnCancelSelectedEmployeePayslip.Text = "Cancel";
            this.BtnCancelSelectedEmployeePayslip.UseVisualStyleBackColor = false;
            this.BtnCancelSelectedEmployeePayslip.Click += new System.EventHandler(this.BtnCancelSelectedEmployeePayslip_Click);
            // 
            // BtnGeneratePayslipPDFAll
            // 
            this.BtnGeneratePayslipPDFAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnGeneratePayslipPDFAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGeneratePayslipPDFAll.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnGeneratePayslipPDFAll.ForeColor = System.Drawing.Color.White;
            this.BtnGeneratePayslipPDFAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGeneratePayslipPDFAll.Location = new System.Drawing.Point(613, 512);
            this.BtnGeneratePayslipPDFAll.Name = "BtnGeneratePayslipPDFAll";
            this.BtnGeneratePayslipPDFAll.Size = new System.Drawing.Size(140, 41);
            this.BtnGeneratePayslipPDFAll.TabIndex = 61;
            this.BtnGeneratePayslipPDFAll.Text = "Generate PDF All";
            this.BtnGeneratePayslipPDFAll.UseVisualStyleBackColor = false;
            this.BtnGeneratePayslipPDFAll.Click += new System.EventHandler(this.BtnGeneratePayslipPDFAll_Click);
            // 
            // PayslipHistoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BtnCancelAllEmployeePayslip);
            this.Controls.Add(this.BtnGeneratePayslipPDFAll);
            this.Controls.Add(this.BtnCancelSelectedEmployeePayslip);
            this.Controls.Add(this.BtnGeneratePayslipPDF);
            this.Controls.Add(this.PanelPayslipDetailsContainer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "PayslipHistoryControl";
            this.Size = new System.Drawing.Size(1057, 556);
            this.Load += new System.EventHandler(this.PayslipHistoryControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployeeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel PanelPayslipDetailsContainer;
        private System.Windows.Forms.ComboBox CBoxPayslipDates;
        private System.Windows.Forms.DataGridView DGVEmployeeList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnGenerateEmployeePayslip;
        private System.Windows.Forms.Button BtnGeneratePayslipPDF;
        private System.Windows.Forms.Button BtnCancelSelectedEmployeePayslip;
        private System.Windows.Forms.Button BtnCancelAllEmployeePayslip;
        private System.Windows.Forms.Button BtnGeneratePayslipPDFAll;
    }
}
