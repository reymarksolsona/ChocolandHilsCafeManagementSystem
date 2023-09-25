
namespace Main.Forms.OtherDataForms.Controls
{
    partial class BranchInfoCRUDControl
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
            this.GBoxBranchForm = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TbxAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.TbxBranchName = new System.Windows.Forms.TextBox();
            this.BtnSaveBranchDetails = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TbxTellNo = new System.Windows.Forms.TextBox();
            this.DGVBranchList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.GBoxBranchForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBranchList)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1007, 94);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Branches";
            // 
            // GBoxBranchForm
            // 
            this.GBoxBranchForm.Controls.Add(this.label3);
            this.GBoxBranchForm.Controls.Add(this.TbxAddress);
            this.GBoxBranchForm.Controls.Add(this.label9);
            this.GBoxBranchForm.Controls.Add(this.BtnCancelUpdate);
            this.GBoxBranchForm.Controls.Add(this.TbxBranchName);
            this.GBoxBranchForm.Controls.Add(this.BtnSaveBranchDetails);
            this.GBoxBranchForm.Controls.Add(this.label1);
            this.GBoxBranchForm.Controls.Add(this.TbxTellNo);
            this.GBoxBranchForm.ForeColor = System.Drawing.Color.Black;
            this.GBoxBranchForm.Location = new System.Drawing.Point(39, 114);
            this.GBoxBranchForm.Name = "GBoxBranchForm";
            this.GBoxBranchForm.Size = new System.Drawing.Size(299, 325);
            this.GBoxBranchForm.TabIndex = 48;
            this.GBoxBranchForm.TabStop = false;
            this.GBoxBranchForm.Text = "Add new branch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 48;
            this.label3.Text = "Address";
            // 
            // TbxAddress
            // 
            this.TbxAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxAddress.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxAddress.Location = new System.Drawing.Point(18, 178);
            this.TbxAddress.Multiline = true;
            this.TbxAddress.Name = "TbxAddress";
            this.TbxAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbxAddress.Size = new System.Drawing.Size(265, 71);
            this.TbxAddress.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(18, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Branch Name";
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(168, 255);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdate.TabIndex = 46;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            this.BtnCancelUpdate.Click += new System.EventHandler(this.BtnCancelUpdate_Click);
            // 
            // TbxBranchName
            // 
            this.TbxBranchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxBranchName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxBranchName.Location = new System.Drawing.Point(18, 53);
            this.TbxBranchName.Name = "TbxBranchName";
            this.TbxBranchName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbxBranchName.Size = new System.Drawing.Size(265, 27);
            this.TbxBranchName.TabIndex = 24;
            // 
            // BtnSaveBranchDetails
            // 
            this.BtnSaveBranchDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveBranchDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveBranchDetails.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveBranchDetails.ForeColor = System.Drawing.Color.White;
            this.BtnSaveBranchDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveBranchDetails.Location = new System.Drawing.Point(18, 255);
            this.BtnSaveBranchDetails.Name = "BtnSaveBranchDetails";
            this.BtnSaveBranchDetails.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveBranchDetails.TabIndex = 2;
            this.BtnSaveBranchDetails.Text = "Save";
            this.BtnSaveBranchDetails.UseVisualStyleBackColor = false;
            this.BtnSaveBranchDetails.Click += new System.EventHandler(this.BtnSaveBranchDetails_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Tell No";
            // 
            // TbxTellNo
            // 
            this.TbxTellNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxTellNo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxTellNo.Location = new System.Drawing.Point(18, 115);
            this.TbxTellNo.Name = "TbxTellNo";
            this.TbxTellNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbxTellNo.Size = new System.Drawing.Size(265, 27);
            this.TbxTellNo.TabIndex = 1;
            // 
            // DGVBranchList
            // 
            this.DGVBranchList.AllowUserToAddRows = false;
            this.DGVBranchList.AllowUserToDeleteRows = false;
            this.DGVBranchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVBranchList.Location = new System.Drawing.Point(362, 122);
            this.DGVBranchList.Name = "DGVBranchList";
            this.DGVBranchList.ReadOnly = true;
            this.DGVBranchList.RowTemplate.Height = 25;
            this.DGVBranchList.Size = new System.Drawing.Size(611, 317);
            this.DGVBranchList.TabIndex = 49;
            this.DGVBranchList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBranchList_CellClick);
            // 
            // BranchInfoCRUDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DGVBranchList);
            this.Controls.Add(this.GBoxBranchForm);
            this.Controls.Add(this.panel1);
            this.Name = "BranchInfoCRUDControl";
            this.Size = new System.Drawing.Size(1007, 468);
            this.Load += new System.EventHandler(this.BranchInfoCRUDControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GBoxBranchForm.ResumeLayout(false);
            this.GBoxBranchForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBranchList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbxAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.TextBox TbxBranchName;
        private System.Windows.Forms.Button BtnSaveBranchDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbxTellNo;
        private System.Windows.Forms.DataGridView DGVBranchList;
        private System.Windows.Forms.GroupBox GBoxBranchForm;
    }
}
