
namespace Main.Forms.POSManagementForms.Controls
{
    partial class ComboMealItemControl
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
            this.LblComboMealName = new System.Windows.Forms.Label();
            this.PicBoxComboMealImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblComboMealPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxComboMealImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblComboMealName
            // 
            this.LblComboMealName.AutoEllipsis = true;
            this.LblComboMealName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblComboMealName.Location = new System.Drawing.Point(77, 20);
            this.LblComboMealName.Name = "LblComboMealName";
            this.LblComboMealName.Size = new System.Drawing.Size(113, 33);
            this.LblComboMealName.TabIndex = 2;
            this.LblComboMealName.Text = "label1";
            // 
            // PicBoxComboMealImage
            // 
            this.PicBoxComboMealImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicBoxComboMealImage.Location = new System.Drawing.Point(0, 0);
            this.PicBoxComboMealImage.Name = "PicBoxComboMealImage";
            this.PicBoxComboMealImage.Padding = new System.Windows.Forms.Padding(3);
            this.PicBoxComboMealImage.Size = new System.Drawing.Size(71, 88);
            this.PicBoxComboMealImage.TabIndex = 3;
            this.PicBoxComboMealImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LblComboMealPrice);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.PicBoxComboMealImage);
            this.panel1.Controls.Add(this.LblComboMealName);
            this.panel1.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 88);
            this.panel1.TabIndex = 4;
            // 
            // LblComboMealPrice
            // 
            this.LblComboMealPrice.AutoEllipsis = true;
            this.LblComboMealPrice.Location = new System.Drawing.Point(126, 53);
            this.LblComboMealPrice.Name = "LblComboMealPrice";
            this.LblComboMealPrice.Size = new System.Drawing.Size(43, 25);
            this.LblComboMealPrice.TabIndex = 5;
            this.LblComboMealPrice.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(77, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Price";
            // 
            // ComboMealItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe WP", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "ComboMealItemControl";
            this.Size = new System.Drawing.Size(206, 92);
            this.Load += new System.EventHandler(this.ComboMealItemControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxComboMealImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblComboMealName;
        private System.Windows.Forms.PictureBox PicBoxComboMealImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblComboMealPrice;
        private System.Windows.Forms.Label label1;
    }
}
