
namespace Main.Forms.POSManagementForms.Controls
{
    partial class FrmEnterComboMealQuantity
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
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.NumUpDownOrderQty = new System.Windows.Forms.NumericUpDown();
            this.LblComboMealPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblComboMealName = new System.Windows.Forms.Label();
            this.PicBoxComboMealImage = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DGVProductExistingIngredients = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownOrderQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxComboMealImage)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductExistingIngredients)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(18, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 37);
            this.label2.TabIndex = 71;
            this.label2.Text = "Quantity";
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancel.Location = new System.Drawing.Point(229, 203);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(103, 44);
            this.BtnCancel.TabIndex = 70;
            this.BtnCancel.Text = "CANCEL";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // NumUpDownOrderQty
            // 
            this.NumUpDownOrderQty.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.NumUpDownOrderQty.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NumUpDownOrderQty.Location = new System.Drawing.Point(143, 146);
            this.NumUpDownOrderQty.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumUpDownOrderQty.Name = "NumUpDownOrderQty";
            this.NumUpDownOrderQty.Size = new System.Drawing.Size(189, 43);
            this.NumUpDownOrderQty.TabIndex = 69;
            this.NumUpDownOrderQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUpDownOrderQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumUpDownOrderQty_KeyUp);
            // 
            // LblComboMealPrice
            // 
            this.LblComboMealPrice.AutoSize = true;
            this.LblComboMealPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblComboMealPrice.Location = new System.Drawing.Point(196, 78);
            this.LblComboMealPrice.Name = "LblComboMealPrice";
            this.LblComboMealPrice.Size = new System.Drawing.Size(19, 21);
            this.LblComboMealPrice.TabIndex = 68;
            this.LblComboMealPrice.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(129, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 67;
            this.label1.Text = "Price:";
            // 
            // LblComboMealName
            // 
            this.LblComboMealName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblComboMealName.Location = new System.Drawing.Point(129, 19);
            this.LblComboMealName.Name = "LblComboMealName";
            this.LblComboMealName.Size = new System.Drawing.Size(221, 59);
            this.LblComboMealName.TabIndex = 66;
            this.LblComboMealName.Text = "Combo meal title";
            // 
            // PicBoxComboMealImage
            // 
            this.PicBoxComboMealImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicBoxComboMealImage.Location = new System.Drawing.Point(13, 19);
            this.PicBoxComboMealImage.Name = "PicBoxComboMealImage";
            this.PicBoxComboMealImage.Padding = new System.Windows.Forms.Padding(3);
            this.PicBoxComboMealImage.Size = new System.Drawing.Size(110, 110);
            this.PicBoxComboMealImage.TabIndex = 65;
            this.PicBoxComboMealImage.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DGVProductExistingIngredients);
            this.groupBox3.Location = new System.Drawing.Point(338, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 307);
            this.groupBox3.TabIndex = 72;
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
            this.DGVProductExistingIngredients.Location = new System.Drawing.Point(3, 19);
            this.DGVProductExistingIngredients.Name = "DGVProductExistingIngredients";
            this.DGVProductExistingIngredients.RowTemplate.Height = 25;
            this.DGVProductExistingIngredients.Size = new System.Drawing.Size(434, 285);
            this.DGVProductExistingIngredients.TabIndex = 2;
            // 
            // FrmEnterComboMealQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(162)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(787, 331);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.NumUpDownOrderQty);
            this.Controls.Add(this.LblComboMealPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblComboMealName);
            this.Controls.Add(this.PicBoxComboMealImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEnterComboMealQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEnterComboMealQuantity";
            this.Load += new System.EventHandler(this.FrmEnterComboMealQuantity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownOrderQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxComboMealImage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductExistingIngredients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.NumericUpDown NumUpDownOrderQty;
        private System.Windows.Forms.Label LblComboMealPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblComboMealName;
        private System.Windows.Forms.PictureBox PicBoxComboMealImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DGVProductExistingIngredients;
    }
}