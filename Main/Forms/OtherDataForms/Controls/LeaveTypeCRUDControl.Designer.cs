
namespace Main.Forms.OtherDataForms.Controls
{
    partial class LeaveTypeCRUDControl
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
            this.GBoxLeaveTypeForm = new System.Windows.Forms.GroupBox();
            this.CboxDisable = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCancelUpdate = new System.Windows.Forms.Button();
            this.TbxLeaveType = new System.Windows.Forms.TextBox();
            this.BtnSaveLeaveType = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TboxNumberOfDays = new System.Windows.Forms.TextBox();
            this.LeaveTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVLeaveTypes = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.GBoxLeaveTypeForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLeaveTypes)).BeginInit();
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
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(22, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Leave types";
            // 
            // GBoxLeaveTypeForm
            // 
            this.GBoxLeaveTypeForm.Controls.Add(this.CboxDisable);
            this.GBoxLeaveTypeForm.Controls.Add(this.label9);
            this.GBoxLeaveTypeForm.Controls.Add(this.BtnCancelUpdate);
            this.GBoxLeaveTypeForm.Controls.Add(this.TbxLeaveType);
            this.GBoxLeaveTypeForm.Controls.Add(this.BtnSaveLeaveType);
            this.GBoxLeaveTypeForm.Controls.Add(this.label1);
            this.GBoxLeaveTypeForm.Controls.Add(this.TboxNumberOfDays);
            this.GBoxLeaveTypeForm.ForeColor = System.Drawing.Color.Black;
            this.GBoxLeaveTypeForm.Location = new System.Drawing.Point(22, 127);
            this.GBoxLeaveTypeForm.Name = "GBoxLeaveTypeForm";
            this.GBoxLeaveTypeForm.Size = new System.Drawing.Size(299, 294);
            this.GBoxLeaveTypeForm.TabIndex = 47;
            this.GBoxLeaveTypeForm.TabStop = false;
            this.GBoxLeaveTypeForm.Text = "Add new leave type";
            // 
            // CboxDisable
            // 
            this.CboxDisable.AutoSize = true;
            this.CboxDisable.ForeColor = System.Drawing.Color.Black;
            this.CboxDisable.Location = new System.Drawing.Point(18, 32);
            this.CboxDisable.Name = "CboxDisable";
            this.CboxDisable.Size = new System.Drawing.Size(64, 19);
            this.CboxDisable.TabIndex = 47;
            this.CboxDisable.Text = "Disable";
            this.CboxDisable.UseVisualStyleBackColor = true;
            this.CboxDisable.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(18, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Leave type";
            // 
            // BtnCancelUpdate
            // 
            this.BtnCancelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdate.Location = new System.Drawing.Point(168, 200);
            this.BtnCancelUpdate.Name = "BtnCancelUpdate";
            this.BtnCancelUpdate.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdate.TabIndex = 46;
            this.BtnCancelUpdate.Text = "Cancel";
            this.BtnCancelUpdate.UseVisualStyleBackColor = false;
            this.BtnCancelUpdate.Visible = false;
            this.BtnCancelUpdate.Click += new System.EventHandler(this.BtnCancelUpdate_Click);
            // 
            // TbxLeaveType
            // 
            this.TbxLeaveType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbxLeaveType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxLeaveType.Location = new System.Drawing.Point(18, 86);
            this.TbxLeaveType.Name = "TbxLeaveType";
            this.TbxLeaveType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbxLeaveType.Size = new System.Drawing.Size(265, 27);
            this.TbxLeaveType.TabIndex = 24;
            // 
            // BtnSaveLeaveType
            // 
            this.BtnSaveLeaveType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveLeaveType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveLeaveType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveLeaveType.ForeColor = System.Drawing.Color.White;
            this.BtnSaveLeaveType.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveLeaveType.Location = new System.Drawing.Point(18, 200);
            this.BtnSaveLeaveType.Name = "BtnSaveLeaveType";
            this.BtnSaveLeaveType.Size = new System.Drawing.Size(115, 47);
            this.BtnSaveLeaveType.TabIndex = 2;
            this.BtnSaveLeaveType.Text = "Save";
            this.BtnSaveLeaveType.UseVisualStyleBackColor = false;
            this.BtnSaveLeaveType.Click += new System.EventHandler(this.BtnSaveLeaveType_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 45;
            this.label1.Text = "Number of days";
            // 
            // TboxNumberOfDays
            // 
            this.TboxNumberOfDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TboxNumberOfDays.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxNumberOfDays.Location = new System.Drawing.Point(18, 151);
            this.TboxNumberOfDays.Name = "TboxNumberOfDays";
            this.TboxNumberOfDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TboxNumberOfDays.Size = new System.Drawing.Size(265, 27);
            this.TboxNumberOfDays.TabIndex = 1;
            // 
            // LeaveTypeId
            // 
            this.LeaveTypeId.HeaderText = "LeaveTypeId";
            this.LeaveTypeId.Name = "LeaveTypeId";
            this.LeaveTypeId.Visible = false;
            // 
            // DGVLeaveTypes
            // 
            this.DGVLeaveTypes.AllowUserToAddRows = false;
            this.DGVLeaveTypes.AllowUserToDeleteRows = false;
            this.DGVLeaveTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLeaveTypes.Location = new System.Drawing.Point(348, 127);
            this.DGVLeaveTypes.Name = "DGVLeaveTypes";
            this.DGVLeaveTypes.ReadOnly = true;
            this.DGVLeaveTypes.RowTemplate.Height = 25;
            this.DGVLeaveTypes.Size = new System.Drawing.Size(611, 294);
            this.DGVLeaveTypes.TabIndex = 0;
            this.DGVLeaveTypes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLeaveTypes_CellClick);
            this.DGVLeaveTypes.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLeaveTypes_CellMouseEnter);
            // 
            // LeaveTypeCRUDControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.GBoxLeaveTypeForm);
            this.Controls.Add(this.DGVLeaveTypes);
            this.Controls.Add(this.panel1);
            this.Name = "LeaveTypeCRUDControl";
            this.Size = new System.Drawing.Size(1007, 468);
            this.Load += new System.EventHandler(this.LeaveTypeCRUDControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.GBoxLeaveTypeForm.ResumeLayout(false);
            this.GBoxLeaveTypeForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLeaveTypes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox GBoxLeaveTypeForm;
        private System.Windows.Forms.CheckBox CboxDisable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnCancelUpdate;
        private System.Windows.Forms.TextBox TbxLeaveType;
        private System.Windows.Forms.Button BtnSaveLeaveType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TboxNumberOfDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeaveTypeId;
        private System.Windows.Forms.DataGridView DGVLeaveTypes;
    }
}
