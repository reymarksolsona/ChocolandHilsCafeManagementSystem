
namespace Main.Forms.POSManagementForms.Controls
{
    partial class BtnProductCategoryControl
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
            this.ButtonCategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonCategory
            // 
            this.ButtonCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(209)))));
            this.ButtonCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ButtonCategory.ForeColor = System.Drawing.Color.White;
            this.ButtonCategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonCategory.Location = new System.Drawing.Point(0, 0);
            this.ButtonCategory.Name = "ButtonCategory";
            this.ButtonCategory.Size = new System.Drawing.Size(170, 49);
            this.ButtonCategory.TabIndex = 63;
            this.ButtonCategory.Text = "Category";
            this.ButtonCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonCategory.UseVisualStyleBackColor = false;
            this.ButtonCategory.Click += new System.EventHandler(this.ButtonCategory_Click);
            // 
            // BtnProductCategoryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ButtonCategory);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "BtnProductCategoryControl";
            this.Size = new System.Drawing.Size(170, 49);
            this.Load += new System.EventHandler(this.BtnProductCategoryControl_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonCategory;
    }
}
