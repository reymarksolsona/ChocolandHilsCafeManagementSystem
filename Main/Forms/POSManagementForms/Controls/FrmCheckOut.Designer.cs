
namespace Main.Forms.POSManagementForms.Controls
{
    partial class FrmCheckOut
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
            this.TboxSubTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TboxTicketNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TboxCustomer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TboxTableNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TboxChange = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TboxDue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CBoxUsePercentageInDiscount = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblDiscountTotal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnCheckout = new System.Windows.Forms.Button();
            this.BtnCancelCheckout = new System.Windows.Forms.Button();
            this.NumUpDownDiscountValue = new System.Windows.Forms.NumericUpDown();
            this.NumUpDnCustomerCash = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownDiscountValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDnCustomerCash)).BeginInit();
            this.SuspendLayout();
            // 
            // TboxSubTotal
            // 
            this.TboxSubTotal.Enabled = false;
            this.TboxSubTotal.Location = new System.Drawing.Point(37, 141);
            this.TboxSubTotal.Name = "TboxSubTotal";
            this.TboxSubTotal.Size = new System.Drawing.Size(257, 35);
            this.TboxSubTotal.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sub Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 30);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ticket #";
            // 
            // TboxTicketNum
            // 
            this.TboxTicketNum.Enabled = false;
            this.TboxTicketNum.Location = new System.Drawing.Point(37, 212);
            this.TboxTicketNum.Name = "TboxTicketNum";
            this.TboxTicketNum.Size = new System.Drawing.Size(257, 35);
            this.TboxTicketNum.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 30);
            this.label3.TabIndex = 13;
            this.label3.Text = "Customer";
            // 
            // TboxCustomer
            // 
            this.TboxCustomer.Enabled = false;
            this.TboxCustomer.Location = new System.Drawing.Point(37, 282);
            this.TboxCustomer.Name = "TboxCustomer";
            this.TboxCustomer.Size = new System.Drawing.Size(257, 35);
            this.TboxCustomer.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 30);
            this.label4.TabIndex = 15;
            this.label4.Text = "Table #";
            // 
            // TboxTableNumber
            // 
            this.TboxTableNumber.Enabled = false;
            this.TboxTableNumber.Location = new System.Drawing.Point(37, 355);
            this.TboxTableNumber.Name = "TboxTableNumber";
            this.TboxTableNumber.Size = new System.Drawing.Size(257, 35);
            this.TboxTableNumber.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 30);
            this.label5.TabIndex = 16;
            this.label5.Text = "Cash";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 30);
            this.label6.TabIndex = 18;
            this.label6.Text = "Change";
            // 
            // TboxChange
            // 
            this.TboxChange.Enabled = false;
            this.TboxChange.Location = new System.Drawing.Point(363, 284);
            this.TboxChange.Name = "TboxChange";
            this.TboxChange.Size = new System.Drawing.Size(257, 35);
            this.TboxChange.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(363, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 30);
            this.label7.TabIndex = 20;
            this.label7.Text = "Due";
            // 
            // TboxDue
            // 
            this.TboxDue.Enabled = false;
            this.TboxDue.Location = new System.Drawing.Point(363, 353);
            this.TboxDue.Name = "TboxDue";
            this.TboxDue.Size = new System.Drawing.Size(257, 35);
            this.TboxDue.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 30);
            this.label8.TabIndex = 22;
            this.label8.Text = "Discount";
            // 
            // CBoxUsePercentageInDiscount
            // 
            this.CBoxUsePercentageInDiscount.AutoSize = true;
            this.CBoxUsePercentageInDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CBoxUsePercentageInDiscount.Location = new System.Drawing.Point(464, 115);
            this.CBoxUsePercentageInDiscount.Name = "CBoxUsePercentageInDiscount";
            this.CBoxUsePercentageInDiscount.Size = new System.Drawing.Size(135, 25);
            this.CBoxUsePercentageInDiscount.TabIndex = 23;
            this.CBoxUsePercentageInDiscount.Text = "Use Percentage";
            this.CBoxUsePercentageInDiscount.UseVisualStyleBackColor = true;
            this.CBoxUsePercentageInDiscount.CheckedChanged += new System.EventHandler(this.CBoxUsePercentageInDiscount_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(20, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 40);
            this.label9.TabIndex = 24;
            this.label9.Text = "Total:";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblTotal.ForeColor = System.Drawing.Color.Chartreuse;
            this.LblTotal.Location = new System.Drawing.Point(135, 8);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(76, 40);
            this.LblTotal.TabIndex = 25;
            this.LblTotal.Text = "0.00";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LblDiscountTotal);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.LblTotal);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(37, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 94);
            this.panel1.TabIndex = 26;
            // 
            // LblDiscountTotal
            // 
            this.LblDiscountTotal.AutoSize = true;
            this.LblDiscountTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblDiscountTotal.ForeColor = System.Drawing.Color.Chartreuse;
            this.LblDiscountTotal.Location = new System.Drawing.Point(144, 57);
            this.LblDiscountTotal.Name = "LblDiscountTotal";
            this.LblDiscountTotal.Size = new System.Drawing.Size(40, 21);
            this.LblDiscountTotal.TabIndex = 27;
            this.LblDiscountTotal.Text = "0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(27, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 26;
            this.label10.Text = "Discount:";
            // 
            // BtnCheckout
            // 
            this.BtnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCheckout.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCheckout.ForeColor = System.Drawing.Color.White;
            this.BtnCheckout.Image = global::Main.Properties.Resources.checkout_white_30;
            this.BtnCheckout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCheckout.Location = new System.Drawing.Point(503, 406);
            this.BtnCheckout.Name = "BtnCheckout";
            this.BtnCheckout.Size = new System.Drawing.Size(117, 60);
            this.BtnCheckout.TabIndex = 70;
            this.BtnCheckout.Text = "CHECKOUT";
            this.BtnCheckout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCheckout.UseVisualStyleBackColor = false;
            this.BtnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);
            // 
            // BtnCancelCheckout
            // 
            this.BtnCancelCheckout.BackColor = System.Drawing.Color.DarkRed;
            this.BtnCancelCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelCheckout.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelCheckout.ForeColor = System.Drawing.Color.White;
            this.BtnCancelCheckout.Image = global::Main.Properties.Resources.icons8_cancel_301;
            this.BtnCancelCheckout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelCheckout.Location = new System.Drawing.Point(363, 406);
            this.BtnCancelCheckout.Name = "BtnCancelCheckout";
            this.BtnCancelCheckout.Size = new System.Drawing.Size(117, 60);
            this.BtnCancelCheckout.TabIndex = 72;
            this.BtnCancelCheckout.Text = "CLOSED";
            this.BtnCancelCheckout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelCheckout.UseVisualStyleBackColor = false;
            this.BtnCancelCheckout.Click += new System.EventHandler(this.BtnCancelCheckout_Click);
            // 
            // NumUpDownDiscountValue
            // 
            this.NumUpDownDiscountValue.DecimalPlaces = 2;
            this.NumUpDownDiscountValue.Location = new System.Drawing.Point(363, 143);
            this.NumUpDownDiscountValue.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NumUpDownDiscountValue.Name = "NumUpDownDiscountValue";
            this.NumUpDownDiscountValue.Size = new System.Drawing.Size(257, 35);
            this.NumUpDownDiscountValue.TabIndex = 73;
            this.NumUpDownDiscountValue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumUpDownDiscountValue_KeyUp);
            // 
            // NumUpDnCustomerCash
            // 
            this.NumUpDnCustomerCash.Location = new System.Drawing.Point(363, 212);
            this.NumUpDnCustomerCash.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.NumUpDnCustomerCash.Name = "NumUpDnCustomerCash";
            this.NumUpDnCustomerCash.Size = new System.Drawing.Size(257, 35);
            this.NumUpDnCustomerCash.TabIndex = 74;
            this.NumUpDnCustomerCash.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumUpDnCustomerCash_KeyUp);
            // 
            // FrmCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(112)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(651, 493);
            this.Controls.Add(this.NumUpDnCustomerCash);
            this.Controls.Add(this.NumUpDownDiscountValue);
            this.Controls.Add(this.BtnCancelCheckout);
            this.Controls.Add(this.BtnCheckout);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.CBoxUsePercentageInDiscount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TboxDue);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TboxChange);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TboxTableNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TboxCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TboxTicketNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TboxSubTotal);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkout";
            this.Load += new System.EventHandler(this.FrmCheckOut_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDownDiscountValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDnCustomerCash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TboxSubTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TboxTicketNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TboxCustomer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TboxTableNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TboxChange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TboxDue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox CBoxUsePercentageInDiscount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCheckout;
        private System.Windows.Forms.Button BtnCancelCheckout;
        private System.Windows.Forms.NumericUpDown NumUpDownDiscountValue;
        private System.Windows.Forms.NumericUpDown NumUpDnCustomerCash;
        private System.Windows.Forms.Label LblDiscountTotal;
        private System.Windows.Forms.Label label10;
    }
}