
namespace Main.Forms.OtherDataForms.OtherForms
{
    partial class FrmReassignEmployeesToNewBranch
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblBranchToDelete = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancelUpdateBranch = new System.Windows.Forms.Button();
            this.BtnSubmitNewBranch = new System.Windows.Forms.Button();
            this.CBoxBranches = new System.Windows.Forms.ComboBox();
            this.BtnForceDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.LblBranchToDelete);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(526, 105);
            this.panel1.TabIndex = 9;
            // 
            // LblBranchToDelete
            // 
            this.LblBranchToDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblBranchToDelete.ForeColor = System.Drawing.Color.White;
            this.LblBranchToDelete.Location = new System.Drawing.Point(53, 60);
            this.LblBranchToDelete.Name = "LblBranchToDelete";
            this.LblBranchToDelete.Size = new System.Drawing.Size(413, 25);
            this.LblBranchToDelete.TabIndex = 44;
            this.LblBranchToDelete.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(53, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Choose new branch for all employees under:";
            // 
            // BtnCancelUpdateBranch
            // 
            this.BtnCancelUpdateBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdateBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdateBranch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdateBranch.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdateBranch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdateBranch.Location = new System.Drawing.Point(388, 166);
            this.BtnCancelUpdateBranch.Name = "BtnCancelUpdateBranch";
            this.BtnCancelUpdateBranch.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdateBranch.TabIndex = 17;
            this.BtnCancelUpdateBranch.Text = "Cancel";
            this.BtnCancelUpdateBranch.UseVisualStyleBackColor = false;
            this.BtnCancelUpdateBranch.Click += new System.EventHandler(this.BtnCancelUpdateBranch_Click);
            // 
            // BtnSubmitNewBranch
            // 
            this.BtnSubmitNewBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSubmitNewBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmitNewBranch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSubmitNewBranch.ForeColor = System.Drawing.Color.White;
            this.BtnSubmitNewBranch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubmitNewBranch.Location = new System.Drawing.Point(255, 166);
            this.BtnSubmitNewBranch.Name = "BtnSubmitNewBranch";
            this.BtnSubmitNewBranch.Size = new System.Drawing.Size(115, 47);
            this.BtnSubmitNewBranch.TabIndex = 16;
            this.BtnSubmitNewBranch.Text = "Submit";
            this.BtnSubmitNewBranch.UseVisualStyleBackColor = false;
            this.BtnSubmitNewBranch.Click += new System.EventHandler(this.BtnSubmitNewBranch_Click);
            // 
            // CBoxBranches
            // 
            this.CBoxBranches.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxBranches.FormattingEnabled = true;
            this.CBoxBranches.Location = new System.Drawing.Point(26, 110);
            this.CBoxBranches.Name = "CBoxBranches";
            this.CBoxBranches.Size = new System.Drawing.Size(477, 38);
            this.CBoxBranches.TabIndex = 15;
            // 
            // BtnForceDelete
            // 
            this.BtnForceDelete.BackColor = System.Drawing.Color.DarkRed;
            this.BtnForceDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnForceDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnForceDelete.ForeColor = System.Drawing.Color.White;
            this.BtnForceDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnForceDelete.Location = new System.Drawing.Point(26, 166);
            this.BtnForceDelete.Name = "BtnForceDelete";
            this.BtnForceDelete.Size = new System.Drawing.Size(128, 47);
            this.BtnForceDelete.TabIndex = 18;
            this.BtnForceDelete.Text = "Delete Anyway";
            this.BtnForceDelete.UseVisualStyleBackColor = false;
            this.BtnForceDelete.Click += new System.EventHandler(this.BtnForceDelete_Click);
            // 
            // FrmReassignEmployeesToNewBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(526, 225);
            this.Controls.Add(this.BtnForceDelete);
            this.Controls.Add(this.BtnCancelUpdateBranch);
            this.Controls.Add(this.BtnSubmitNewBranch);
            this.Controls.Add(this.CBoxBranches);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReassignEmployeesToNewBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmReassignEmployeesToNewBranch";
            this.Load += new System.EventHandler(this.FrmReassignEmployeesToNewBranch_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblBranchToDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancelUpdateBranch;
        private System.Windows.Forms.Button BtnSubmitNewBranch;
        private System.Windows.Forms.ComboBox CBoxBranches;
        private System.Windows.Forms.Button BtnForceDelete;
    }
}