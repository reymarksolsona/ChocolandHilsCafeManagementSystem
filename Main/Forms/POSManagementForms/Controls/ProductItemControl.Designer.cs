
namespace Main.Forms.POSManagementForms.Controls
{
    partial class ProductItemControl
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
            this.LblProductPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblProductName = new System.Windows.Forms.Label();
            this.PicBoxProductImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LblProductPrice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LblProductName);
            this.panel1.Controls.Add(this.PicBoxProductImage);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 88);
            this.panel1.TabIndex = 0;
            // 
            // LblProductPrice
            // 
            this.LblProductPrice.AutoEllipsis = true;
            this.LblProductPrice.Location = new System.Drawing.Point(131, 50);
            this.LblProductPrice.Name = "LblProductPrice";
            this.LblProductPrice.Size = new System.Drawing.Size(43, 22);
            this.LblProductPrice.TabIndex = 3;
            this.LblProductPrice.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(82, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Price";
            // 
            // LblProductName
            // 
            this.LblProductName.AutoEllipsis = true;
            this.LblProductName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblProductName.Location = new System.Drawing.Point(82, 16);
            this.LblProductName.Name = "LblProductName";
            this.LblProductName.Size = new System.Drawing.Size(108, 29);
            this.LblProductName.TabIndex = 1;
            this.LblProductName.Text = "label1";
            // 
            // PicBoxProductImage
            // 
            this.PicBoxProductImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicBoxProductImage.Location = new System.Drawing.Point(0, 0);
            this.PicBoxProductImage.Name = "PicBoxProductImage";
            this.PicBoxProductImage.Padding = new System.Windows.Forms.Padding(3);
            this.PicBoxProductImage.Size = new System.Drawing.Size(71, 88);
            this.PicBoxProductImage.TabIndex = 0;
            this.PicBoxProductImage.TabStop = false;
            // 
            // ProductItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ProductItemControl";
            this.Size = new System.Drawing.Size(206, 92);
            this.Load += new System.EventHandler(this.ProductItemControl_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxProductImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PicBoxProductImage;
        private System.Windows.Forms.Label LblProductPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblProductName;
    }
}
