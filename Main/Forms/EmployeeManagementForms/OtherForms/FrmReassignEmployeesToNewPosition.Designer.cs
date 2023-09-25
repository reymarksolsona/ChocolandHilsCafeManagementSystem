
namespace Main.Forms.EmployeeManagementForms.OtherForms
{
    partial class FrmReassignEmployeesToNewPosition
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
            this.LblPositionToDelete = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancelUpdatePosition = new System.Windows.Forms.Button();
            this.BtnSubmitNewPosition = new System.Windows.Forms.Button();
            this.CBoxPositions = new System.Windows.Forms.ComboBox();
            this.BtnForceDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.LblPositionToDelete);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(526, 105);
            this.panel1.TabIndex = 10;
            // 
            // LblPositionToDelete
            // 
            this.LblPositionToDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblPositionToDelete.ForeColor = System.Drawing.Color.White;
            this.LblPositionToDelete.Location = new System.Drawing.Point(53, 60);
            this.LblPositionToDelete.Name = "LblPositionToDelete";
            this.LblPositionToDelete.Size = new System.Drawing.Size(413, 25);
            this.LblPositionToDelete.TabIndex = 44;
            this.LblPositionToDelete.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(53, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 25);
            this.label2.TabIndex = 43;
            this.label2.Text = "Choose new position for all employees under:";
            // 
            // BtnCancelUpdatePosition
            // 
            this.BtnCancelUpdatePosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdatePosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdatePosition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdatePosition.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdatePosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdatePosition.Location = new System.Drawing.Point(389, 167);
            this.BtnCancelUpdatePosition.Name = "BtnCancelUpdatePosition";
            this.BtnCancelUpdatePosition.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdatePosition.TabIndex = 20;
            this.BtnCancelUpdatePosition.Text = "Cancel";
            this.BtnCancelUpdatePosition.UseVisualStyleBackColor = false;
            this.BtnCancelUpdatePosition.Click += new System.EventHandler(this.BtnCancelUpdatePosition_Click);
            // 
            // BtnSubmitNewPosition
            // 
            this.BtnSubmitNewPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSubmitNewPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmitNewPosition.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSubmitNewPosition.ForeColor = System.Drawing.Color.White;
            this.BtnSubmitNewPosition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubmitNewPosition.Location = new System.Drawing.Point(256, 167);
            this.BtnSubmitNewPosition.Name = "BtnSubmitNewPosition";
            this.BtnSubmitNewPosition.Size = new System.Drawing.Size(115, 47);
            this.BtnSubmitNewPosition.TabIndex = 19;
            this.BtnSubmitNewPosition.Text = "Submit";
            this.BtnSubmitNewPosition.UseVisualStyleBackColor = false;
            this.BtnSubmitNewPosition.Click += new System.EventHandler(this.BtnSubmitNewPosition_Click);
            // 
            // CBoxPositions
            // 
            this.CBoxPositions.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxPositions.FormattingEnabled = true;
            this.CBoxPositions.Location = new System.Drawing.Point(27, 111);
            this.CBoxPositions.Name = "CBoxPositions";
            this.CBoxPositions.Size = new System.Drawing.Size(477, 38);
            this.CBoxPositions.TabIndex = 18;
            // 
            // BtnForceDelete
            // 
            this.BtnForceDelete.BackColor = System.Drawing.Color.DarkRed;
            this.BtnForceDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnForceDelete.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnForceDelete.ForeColor = System.Drawing.Color.White;
            this.BtnForceDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnForceDelete.Location = new System.Drawing.Point(27, 166);
            this.BtnForceDelete.Name = "BtnForceDelete";
            this.BtnForceDelete.Size = new System.Drawing.Size(128, 47);
            this.BtnForceDelete.TabIndex = 21;
            this.BtnForceDelete.Text = "Delete Anyway";
            this.BtnForceDelete.UseVisualStyleBackColor = false;
            this.BtnForceDelete.Click += new System.EventHandler(this.BtnForceDelete_Click);
            // 
            // FrmReassignEmployeesToNewPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(526, 225);
            this.Controls.Add(this.BtnForceDelete);
            this.Controls.Add(this.BtnCancelUpdatePosition);
            this.Controls.Add(this.BtnSubmitNewPosition);
            this.Controls.Add(this.CBoxPositions);
            this.Controls.Add(this.panel1);
            this.Name = "FrmReassignEmployeesToNewPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmReassignEmployeesToNewPosition";
            this.Load += new System.EventHandler(this.FrmReassignEmployeesToNewPosition_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblPositionToDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancelUpdatePosition;
        private System.Windows.Forms.Button BtnSubmitNewPosition;
        private System.Windows.Forms.ComboBox CBoxPositions;
        private System.Windows.Forms.Button BtnForceDelete;
    }
}