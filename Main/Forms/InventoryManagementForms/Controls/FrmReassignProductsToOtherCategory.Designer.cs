
namespace Main.Forms.InventoryManagementForms.Controls
{
    partial class FrmReassignProductsToOtherCategory
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
            this.LblCategoryToDelete = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancelUpdateCategory = new System.Windows.Forms.Button();
            this.BtnSubmitNewCategory = new System.Windows.Forms.Button();
            this.CBoxCategories = new System.Windows.Forms.ComboBox();
            this.BtnForceDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panel1.Controls.Add(this.LblCategoryToDelete);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(526, 105);
            this.panel1.TabIndex = 7;
            // 
            // LblCategoryToDelete
            // 
            this.LblCategoryToDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCategoryToDelete.ForeColor = System.Drawing.Color.White;
            this.LblCategoryToDelete.Location = new System.Drawing.Point(53, 60);
            this.LblCategoryToDelete.Name = "LblCategoryToDelete";
            this.LblCategoryToDelete.Size = new System.Drawing.Size(413, 25);
            this.LblCategoryToDelete.TabIndex = 44;
            this.LblCategoryToDelete.Text = "-";
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
            this.label2.Text = "Choose new category for all products under:";
            // 
            // BtnCancelUpdateCategory
            // 
            this.BtnCancelUpdateCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdateCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdateCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdateCategory.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdateCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdateCategory.Location = new System.Drawing.Point(389, 166);
            this.BtnCancelUpdateCategory.Name = "BtnCancelUpdateCategory";
            this.BtnCancelUpdateCategory.Size = new System.Drawing.Size(115, 47);
            this.BtnCancelUpdateCategory.TabIndex = 11;
            this.BtnCancelUpdateCategory.Text = "Cancel";
            this.BtnCancelUpdateCategory.UseVisualStyleBackColor = false;
            this.BtnCancelUpdateCategory.Click += new System.EventHandler(this.BtnCancelUpdateCategory_Click);
            // 
            // BtnSubmitNewCategory
            // 
            this.BtnSubmitNewCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSubmitNewCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubmitNewCategory.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSubmitNewCategory.ForeColor = System.Drawing.Color.White;
            this.BtnSubmitNewCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSubmitNewCategory.Location = new System.Drawing.Point(256, 166);
            this.BtnSubmitNewCategory.Name = "BtnSubmitNewCategory";
            this.BtnSubmitNewCategory.Size = new System.Drawing.Size(115, 47);
            this.BtnSubmitNewCategory.TabIndex = 10;
            this.BtnSubmitNewCategory.Text = "Submit";
            this.BtnSubmitNewCategory.UseVisualStyleBackColor = false;
            this.BtnSubmitNewCategory.Click += new System.EventHandler(this.BtnSubmitNewCategory_Click);
            // 
            // CBoxCategories
            // 
            this.CBoxCategories.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxCategories.FormattingEnabled = true;
            this.CBoxCategories.Location = new System.Drawing.Point(27, 110);
            this.CBoxCategories.Name = "CBoxCategories";
            this.CBoxCategories.Size = new System.Drawing.Size(477, 38);
            this.CBoxCategories.TabIndex = 9;
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
            this.BtnForceDelete.TabIndex = 19;
            this.BtnForceDelete.Text = "Delete Anyway";
            this.BtnForceDelete.UseVisualStyleBackColor = false;
            this.BtnForceDelete.Click += new System.EventHandler(this.BtnForceDelete_Click);
            // 
            // FrmReassignProductsToOtherCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(173)))));
            this.ClientSize = new System.Drawing.Size(526, 225);
            this.ControlBox = false;
            this.Controls.Add(this.BtnForceDelete);
            this.Controls.Add(this.BtnCancelUpdateCategory);
            this.Controls.Add(this.BtnSubmitNewCategory);
            this.Controls.Add(this.CBoxCategories);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmReassignProductsToOtherCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose new category";
            this.Load += new System.EventHandler(this.FrmReassignProductsToOtherCategory_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblCategoryToDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancelUpdateCategory;
        private System.Windows.Forms.Button BtnSubmitNewCategory;
        private System.Windows.Forms.ComboBox CBoxCategories;
        private System.Windows.Forms.Button BtnForceDelete;
    }
}