
namespace Main.Forms.POSManagementForms.Controls
{
    partial class FrmEnterProductQuantity
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
            this.PicBoxProductImage = new System.Windows.Forms.PictureBox();
            this.LblProductName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblProductPrice = new System.Windows.Forms.Label();
            this.NumUpDownOrderQty = new System.Windows.Forms.NumericUpDown();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DGVProductExistingIngredients = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownOrderQty)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductExistingIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // PicBoxProductImage
            // 
            this.PicBoxProductImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxProductImage.Location = new System.Drawing.Point(12, 12);
            this.PicBoxProductImage.Name = "PicBoxProductImage";
            this.PicBoxProductImage.Padding = new System.Windows.Forms.Padding(3);
            this.PicBoxProductImage.Size = new System.Drawing.Size(110, 110);
            this.PicBoxProductImage.TabIndex = 1;
            this.PicBoxProductImage.TabStop = false;
            // 
            // LblProductName
            // 
            this.LblProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblProductName.Location = new System.Drawing.Point(129, 12);
            this.LblProductName.Name = "LblProductName";
            this.LblProductName.Size = new System.Drawing.Size(221, 59);
            this.LblProductName.TabIndex = 2;
            this.LblProductName.Text = "Product Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(129, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Price:";
            // 
            // LblProductPrice
            // 
            this.LblProductPrice.AutoSize = true;
            this.LblProductPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblProductPrice.Location = new System.Drawing.Point(196, 71);
            this.LblProductPrice.Name = "LblProductPrice";
            this.LblProductPrice.Size = new System.Drawing.Size(19, 21);
            this.LblProductPrice.TabIndex = 4;
            this.LblProductPrice.Text = "0";
            // 
            // NumUpDownOrderQty
            // 
            this.NumUpDownOrderQty.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.NumUpDownOrderQty.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumUpDownOrderQty.Location = new System.Drawing.Point(140, 137);
            this.NumUpDownOrderQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUpDownOrderQty.Name = "NumUpDownOrderQty";
            this.NumUpDownOrderQty.Size = new System.Drawing.Size(189, 43);
            this.NumUpDownOrderQty.TabIndex = 6;
            this.NumUpDownOrderQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDownOrderQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumUpDownOrderQty_KeyUp);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(226, 194);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(103, 44);
            this.BtnCancel.TabIndex = 63;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(15, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 37);
            this.label2.TabIndex = 64;
            this.label2.Text = "Quantity";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DGVProductExistingIngredients);
            this.groupBox3.Location = new System.Drawing.Point(335, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 307);
            this.groupBox3.TabIndex = 65;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ingredients Status";
            // 
            // DGVProductExistingIngredients
            // 
            this.DGVProductExistingIngredients.AllowUserToAddRows = false;
            this.DGVProductExistingIngredients.AllowUserToDeleteRows = false;
            this.DGVProductExistingIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVProductExistingIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVProductExistingIngredients.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGVProductExistingIngredients.Location = new System.Drawing.Point(3, 25);
            this.DGVProductExistingIngredients.Name = "DGVProductExistingIngredients";
            this.DGVProductExistingIngredients.RowTemplate.Height = 25;
            this.DGVProductExistingIngredients.Size = new System.Drawing.Size(434, 279);
            this.DGVProductExistingIngredients.TabIndex = 2;
            // 
            // FrmEnterProductQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(787, 331);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.NumUpDownOrderQty);
            this.Controls.Add(this.LblProductPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblProductName);
            this.Controls.Add(this.PicBoxProductImage);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEnterProductQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Quantity";
            this.Load += new System.EventHandler(this.FrmEnterProductQuantity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownOrderQty)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductExistingIngredients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicBoxProductImage;
        private System.Windows.Forms.Label LblProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblProductPrice;
        private System.Windows.Forms.NumericUpDown NumUpDownOrderQty;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DGVProductExistingIngredients;
    }
}