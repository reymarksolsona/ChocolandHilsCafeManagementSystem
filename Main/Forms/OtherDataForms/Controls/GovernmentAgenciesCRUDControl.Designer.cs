
namespace Main.Forms.OtherDataForms.Controls
{
    partial class GovernmentAgenciesCRUDControl
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
            this.GBoxGovtAgencyForm = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.TbxAgency = new System.Windows.Forms.TextBox();
            this.BtnSaveAgency = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DGVGovernmentAgencies = new System.Windows.Forms.DataGridView();
            this.GBoxGovtAgencyForm.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGovernmentAgencies)).BeginInit();
            this.SuspendLayout();
            // 
            // GBoxGovtAgencyForm
            // 
            this.GBoxGovtAgencyForm.Controls.Add(this.label9);
            this.GBoxGovtAgencyForm.Controls.Add(this.BtnCancelUpdate);
            this.GBoxGovtAgencyForm.Controls.Add(this.TbxAgency);
            this.GBoxGovtAgencyForm.Controls.Add(this.BtnSaveAgency);
            this.GBoxGovtAgencyForm.ForeColor = System.Drawing.Color.Black;
            this.GBoxGovtAgencyForm.Location = new System.Drawing.Point(11, 121);
            this.GBoxGovtAgencyForm.Name = "GBoxGovtAgencyForm";
            this.GBoxGovtAgencyForm.Size = new System.Drawing.Size(299, 206);
            this.GBoxGovtAgencyForm.TabIndex = 47;
            this.GBoxGovtAgencyForm.TabStop = false;
            this.GBoxGovtAgencyForm.Text = "Add New";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(15, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 21);
            this.label9.TabIndex = 25;
            this.label9.Text = "Agency";
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(165, 115);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdate.TabIndex = 46;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            this.BtnCancelUpdate.Click += new System.EventHandler(this.BtnCancelUpdate_Click);
            // 
            // TbxAgency
            // 
            this.TbxAgency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxAgency.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxAgency.Location = new System.Drawing.Point(15, 67);
            this.TbxAgency.Name = "TbxAgency";
            this.TbxAgency.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbxAgency.Size = new System.Drawing.Size(265, 29);
            this.TbxAgency.TabIndex = 24;
            // 
            // BtnSaveAgency
            // 
            this.BtnSaveAgency.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveAgency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveAgency.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveAgency.ForeColor = System.Drawing.Color.White;
            this.BtnSaveAgency.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveAgency.Location = new System.Drawing.Point(44, 115);
            this.BtnSaveAgency.Name = "BtnSaveAgency";
            this.BtnSaveAgency.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveAgency.TabIndex = 2;
            this.BtnSaveAgency.Text = "Save";
            this.BtnSaveAgency.UseVisualStyleBackColor = false;
            this.BtnSaveAgency.Click += new System.EventHandler(this.BtnSaveAgency_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(859, 94);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Government agencies";
            // 
            // DGVGovernmentAgencies
            // 
            this.DGVGovernmentAgencies.AllowUserToAddRows = false;
            this.DGVGovernmentAgencies.AllowUserToDeleteRows = false;
            this.DGVGovernmentAgencies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVGovernmentAgencies.Location = new System.Drawing.Point(335, 121);
            this.DGVGovernmentAgencies.Name = "DGVGovernmentAgencies";
            this.DGVGovernmentAgencies.ReadOnly = true;
            this.DGVGovernmentAgencies.RowTemplate.Height = 25;
            this.DGVGovernmentAgencies.Size = new System.Drawing.Size(513, 206);
            this.DGVGovernmentAgencies.TabIndex = 4;
            this.DGVGovernmentAgencies.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVGovernmentAgencies_CellClick);
            this.DGVGovernmentAgencies.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVGovernmentAgencies_CellMouseEnter);
            // 
            // GovernmentAgenciesCRUDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GBoxGovtAgencyForm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DGVGovernmentAgencies);
            this.Name = "GovernmentAgenciesCRUDControl";
            this.Size = new System.Drawing.Size(859, 345);
            this.Load += new System.EventHandler(this.GovernmentAgenciesCRUDControl_Load);
            this.GBoxGovtAgencyForm.ResumeLayout(false);
            this.GBoxGovtAgencyForm.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGovernmentAgencies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBoxGovtAgencyForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.TextBox TbxAgency;
        private System.Windows.Forms.Button BtnSaveAgency;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVGovernmentAgencies;
    }
}
