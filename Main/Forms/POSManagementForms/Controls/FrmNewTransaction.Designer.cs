
namespace Main.Forms.POSManagementForms.Controls
{
    partial class FrmNewTransaction
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
            this.RBtnDineIn = new System.Windows.Forms.RadioButton();
            this.RBtnTakeOut = new System.Windows.Forms.RadioButton();
            this.TboxCustomerName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BtnContinueToCreateNewTrans = new System.Windows.Forms.Button();
            this.BtnCancelCreateNewTrans = new System.Windows.Forms.Button();
            this.BtnSelectTable = new System.Windows.Forms.Button();
            this.LblTableNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RBtnDineIn
            // 
            this.RBtnDineIn.AutoSize = true;
            this.RBtnDineIn.BackColor = System.Drawing.Color.Blue;
            this.RBtnDineIn.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RBtnDineIn.ForeColor = System.Drawing.Color.White;
            this.RBtnDineIn.Location = new System.Drawing.Point(23, 27);
            this.RBtnDineIn.Name = "RBtnDineIn";
            this.RBtnDineIn.Size = new System.Drawing.Size(109, 34);
            this.RBtnDineIn.TabIndex = 0;
            this.RBtnDineIn.TabStop = true;
            this.RBtnDineIn.Text = "DINE-IN";
            this.RBtnDineIn.UseVisualStyleBackColor = false;
            // 
            // RBtnTakeOut
            // 
            this.RBtnTakeOut.AutoSize = true;
            this.RBtnTakeOut.BackColor = System.Drawing.Color.Yellow;
            this.RBtnTakeOut.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RBtnTakeOut.ForeColor = System.Drawing.Color.Black;
            this.RBtnTakeOut.Location = new System.Drawing.Point(150, 27);
            this.RBtnTakeOut.Name = "RBtnTakeOut";
            this.RBtnTakeOut.Size = new System.Drawing.Size(130, 34);
            this.RBtnTakeOut.TabIndex = 1;
            this.RBtnTakeOut.TabStop = true;
            this.RBtnTakeOut.Text = "TAKE-OUT";
            this.RBtnTakeOut.UseVisualStyleBackColor = false;
            // 
            // TboxCustomerName
            // 
            this.TboxCustomerName.Location = new System.Drawing.Point(23, 101);
            this.TboxCustomerName.Name = "TboxCustomerName";
            this.TboxCustomerName.Size = new System.Drawing.Size(257, 29);
            this.TboxCustomerName.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(23, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 21);
            this.label9.TabIndex = 5;
            this.label9.Text = "Customer name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(23, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 21);
            this.label11.TabIndex = 11;
            this.label11.Text = "Selected table:";
            // 
            // BtnContinueToCreateNewTrans
            // 
            this.BtnContinueToCreateNewTrans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnContinueToCreateNewTrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnContinueToCreateNewTrans.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnContinueToCreateNewTrans.ForeColor = System.Drawing.Color.White;
            this.BtnContinueToCreateNewTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnContinueToCreateNewTrans.Location = new System.Drawing.Point(159, 246);
            this.BtnContinueToCreateNewTrans.Name = "BtnContinueToCreateNewTrans";
            this.BtnContinueToCreateNewTrans.Size = new System.Drawing.Size(121, 46);
            this.BtnContinueToCreateNewTrans.TabIndex = 64;
            this.BtnContinueToCreateNewTrans.Text = "CONTINUE";
            this.BtnContinueToCreateNewTrans.UseVisualStyleBackColor = false;
            this.BtnContinueToCreateNewTrans.Click += new System.EventHandler(this.BtnContinueToCreateNewTrans_Click);
            // 
            // BtnCancelCreateNewTrans
            // 
            this.BtnCancelCreateNewTrans.BackColor = System.Drawing.Color.Brown;
            this.BtnCancelCreateNewTrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelCreateNewTrans.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelCreateNewTrans.ForeColor = System.Drawing.Color.White;
            this.BtnCancelCreateNewTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelCreateNewTrans.Location = new System.Drawing.Point(23, 246);
            this.BtnCancelCreateNewTrans.Name = "BtnCancelCreateNewTrans";
            this.BtnCancelCreateNewTrans.Size = new System.Drawing.Size(121, 46);
            this.BtnCancelCreateNewTrans.TabIndex = 65;
            this.BtnCancelCreateNewTrans.Text = "CANCEL";
            this.BtnCancelCreateNewTrans.UseVisualStyleBackColor = false;
            this.BtnCancelCreateNewTrans.Click += new System.EventHandler(this.BtnCancelCreateNewTrans_Click);
            // 
            // BtnSelectTable
            // 
            this.BtnSelectTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSelectTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectTable.Location = new System.Drawing.Point(23, 182);
            this.BtnSelectTable.Name = "BtnSelectTable";
            this.BtnSelectTable.Size = new System.Drawing.Size(84, 30);
            this.BtnSelectTable.TabIndex = 66;
            this.BtnSelectTable.Text = "Select Table";
            this.BtnSelectTable.UseVisualStyleBackColor = false;
            this.BtnSelectTable.Click += new System.EventHandler(this.BtnSelectTable_Click);
            // 
            // LblTableNumber
            // 
            this.LblTableNumber.AutoSize = true;
            this.LblTableNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblTableNumber.Location = new System.Drawing.Point(150, 158);
            this.LblTableNumber.Name = "LblTableNumber";
            this.LblTableNumber.Size = new System.Drawing.Size(25, 21);
            this.LblTableNumber.TabIndex = 67;
            this.LblTableNumber.Text = "T-";
            // 
            // FrmNewTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(112)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(303, 312);
            this.Controls.Add(this.LblTableNumber);
            this.Controls.Add(this.BtnSelectTable);
            this.Controls.Add(this.BtnCancelCreateNewTrans);
            this.Controls.Add(this.BtnContinueToCreateNewTrans);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TboxCustomerName);
            this.Controls.Add(this.RBtnTakeOut);
            this.Controls.Add(this.RBtnDineIn);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmNewTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New transaction";
            this.Load += new System.EventHandler(this.FrmNewTransaction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton RBtnDineIn;
        private System.Windows.Forms.RadioButton RBtnTakeOut;
        private System.Windows.Forms.TextBox TboxCustomerName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button BtnContinueToCreateNewTrans;
        private System.Windows.Forms.Button BtnCancelCreateNewTrans;
        private System.Windows.Forms.Button BtnSelectTable;
        private System.Windows.Forms.Label LblTableNumber;
    }
}