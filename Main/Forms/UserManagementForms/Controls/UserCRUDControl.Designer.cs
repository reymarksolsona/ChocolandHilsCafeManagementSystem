
namespace Main.Forms.UserManagementForms.Controls
{
    partial class UserCRUDControl
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
            this.DGVUsers = new System.Windows.Forms.DataGridView();
            this.GBoxLeaveTypeForm = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CBoxPermissions = new System.Windows.Forms.ComboBox();
            this.CboxDisable = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBoxPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TboxUserFullname = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.TboxUserName = new System.Windows.Forms.TextBox();
            this.BtnSaveUser = new System.Windows.Forms.Button();
            this.TBoxSearchEmployeeStr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnClearSearchResult = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsers)).BeginInit();
            this.GBoxLeaveTypeForm.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(857, 94);
            this.panel1.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "User Management";
            // 
            // DGVUsers
            // 
            this.DGVUsers.AllowUserToAddRows = false;
            this.DGVUsers.AllowUserToDeleteRows = false;
            this.DGVUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVUsers.Location = new System.Drawing.Point(334, 150);
            this.DGVUsers.Name = "DGVUsers";
            this.DGVUsers.ReadOnly = true;
            this.DGVUsers.RowTemplate.Height = 25;
            this.DGVUsers.Size = new System.Drawing.Size(508, 380);
            this.DGVUsers.TabIndex = 55;
            this.DGVUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVUsers_CellClick);
            // 
            // GBoxLeaveTypeForm
            // 
            this.GBoxLeaveTypeForm.Controls.Add(this.label5);
            this.GBoxLeaveTypeForm.Controls.Add(this.CBoxPermissions);
            this.GBoxLeaveTypeForm.Controls.Add(this.CboxDisable);
            this.GBoxLeaveTypeForm.Controls.Add(this.label4);
            this.GBoxLeaveTypeForm.Controls.Add(this.TBoxPassword);
            this.GBoxLeaveTypeForm.Controls.Add(this.label3);
            this.GBoxLeaveTypeForm.Controls.Add(this.TboxUserFullname);
            this.GBoxLeaveTypeForm.Controls.Add(this.label9);
            this.GBoxLeaveTypeForm.Controls.Add(this.BtnCancelUpdate);
            this.GBoxLeaveTypeForm.Controls.Add(this.TboxUserName);
            this.GBoxLeaveTypeForm.Controls.Add(this.BtnSaveUser);
            this.GBoxLeaveTypeForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GBoxLeaveTypeForm.ForeColor = System.Drawing.Color.Black;
            this.GBoxLeaveTypeForm.Location = new System.Drawing.Point(11, 115);
            this.GBoxLeaveTypeForm.Name = "GBoxLeaveTypeForm";
            this.GBoxLeaveTypeForm.Size = new System.Drawing.Size(299, 415);
            this.GBoxLeaveTypeForm.TabIndex = 54;
            this.GBoxLeaveTypeForm.TabStop = false;
            this.GBoxLeaveTypeForm.Text = "Add new user";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 57;
            this.label5.Text = "Permission";
            // 
            // CBoxPermissions
            // 
            this.CBoxPermissions.FormattingEnabled = true;
            this.CBoxPermissions.Location = new System.Drawing.Point(14, 290);
            this.CBoxPermissions.Name = "CBoxPermissions";
            this.CBoxPermissions.Size = new System.Drawing.Size(265, 29);
            this.CBoxPermissions.TabIndex = 56;
            // 
            // CboxDisable
            // 
            this.CboxDisable.AutoSize = true;
            this.CboxDisable.ForeColor = System.Drawing.Color.Black;
            this.CboxDisable.Location = new System.Drawing.Point(14, 28);
            this.CboxDisable.Name = "CboxDisable";
            this.CboxDisable.Size = new System.Drawing.Size(80, 25);
            this.CboxDisable.TabIndex = 55;
            this.CboxDisable.Text = "Disable";
            this.CboxDisable.UseVisualStyleBackColor = true;
            this.CboxDisable.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 54;
            this.label4.Text = "Password";
            // 
            // TBoxPassword
            // 
            this.TBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBoxPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TBoxPassword.Location = new System.Drawing.Point(14, 221);
            this.TBoxPassword.Name = "TBoxPassword";
            this.TBoxPassword.PasswordChar = '*';
            this.TBoxPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TBoxPassword.Size = new System.Drawing.Size(265, 29);
            this.TBoxPassword.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Full Name";
            // 
            // TboxUserFullname
            // 
            this.TboxUserFullname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TboxUserFullname.Enabled = false;
            this.TboxUserFullname.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxUserFullname.Location = new System.Drawing.Point(14, 155);
            this.TboxUserFullname.MaxLength = 500;
            this.TboxUserFullname.Name = "TboxUserFullname";
            this.TboxUserFullname.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TboxUserFullname.Size = new System.Drawing.Size(265, 29);
            this.TboxUserFullname.TabIndex = 50;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(14, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(216, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Employee number as username";
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(164, 334);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdate.TabIndex = 46;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            this.BtnCancelUpdate.Click += new System.EventHandler(this.BtnCancelUpdate_Click);
            // 
            // TboxUserName
            // 
            this.TboxUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TboxUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxUserName.Location = new System.Drawing.Point(14, 90);
            this.TboxUserName.MaxLength = 20;
            this.TboxUserName.Name = "TboxUserName";
            this.TboxUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TboxUserName.Size = new System.Drawing.Size(265, 29);
            this.TboxUserName.TabIndex = 24;
            this.TboxUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TboxUserName_KeyUp);
            // 
            // BtnSaveUser
            // 
            this.BtnSaveUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveUser.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveUser.ForeColor = System.Drawing.Color.White;
            this.BtnSaveUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveUser.Location = new System.Drawing.Point(14, 334);
            this.BtnSaveUser.Name = "BtnSaveUser";
            this.BtnSaveUser.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveUser.TabIndex = 2;
            this.BtnSaveUser.Text = "Save";
            this.BtnSaveUser.UseVisualStyleBackColor = false;
            this.BtnSaveUser.Click += new System.EventHandler(this.BtnSaveUser_Click);
            // 
            // TBoxSearchEmployeeStr
            // 
            this.TBoxSearchEmployeeStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBoxSearchEmployeeStr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TBoxSearchEmployeeStr.Location = new System.Drawing.Point(512, 115);
            this.TBoxSearchEmployeeStr.Name = "TBoxSearchEmployeeStr";
            this.TBoxSearchEmployeeStr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TBoxSearchEmployeeStr.Size = new System.Drawing.Size(265, 29);
            this.TBoxSearchEmployeeStr.TabIndex = 56;
            this.TBoxSearchEmployeeStr.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TBoxSearchEmployeeStr_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(453, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Search";
            // 
            // BtnClearSearchResult
            // 
            this.BtnClearSearchResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnClearSearchResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearSearchResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnClearSearchResult.ForeColor = System.Drawing.Color.White;
            this.BtnClearSearchResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnClearSearchResult.Location = new System.Drawing.Point(783, 115);
            this.BtnClearSearchResult.Name = "BtnClearSearchResult";
            this.BtnClearSearchResult.Size = new System.Drawing.Size(59, 29);
            this.BtnClearSearchResult.TabIndex = 58;
            this.BtnClearSearchResult.Text = "Clear";
            this.BtnClearSearchResult.UseVisualStyleBackColor = false;
            this.BtnClearSearchResult.Click += new System.EventHandler(this.BtnClearSearchResult_Click);
            // 
            // UserCRUDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BtnClearSearchResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBoxSearchEmployeeStr);
            this.Controls.Add(this.DGVUsers);
            this.Controls.Add(this.GBoxLeaveTypeForm);
            this.Controls.Add(this.panel1);
            this.Name = "UserCRUDControl";
            this.Size = new System.Drawing.Size(857, 552);
            this.Load += new System.EventHandler(this.UserCRUDControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVUsers)).EndInit();
            this.GBoxLeaveTypeForm.ResumeLayout(false);
            this.GBoxLeaveTypeForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVUsers;
        private System.Windows.Forms.GroupBox GBoxLeaveTypeForm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.Button BtnSaveUser;
        private System.Windows.Forms.TextBox TBoxSearchEmployeeStr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TboxUserName;
        private System.Windows.Forms.TextBox TboxUserFullname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBoxPassword;
        private System.Windows.Forms.CheckBox CboxDisable;
        private System.Windows.Forms.Button BtnClearSearchResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBoxPermissions;
    }
}
