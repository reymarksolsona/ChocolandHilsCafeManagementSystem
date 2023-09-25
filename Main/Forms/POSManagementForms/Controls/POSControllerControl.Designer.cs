
namespace Main.Forms.POSManagementForms.Controls
{
    partial class POSControllerControl
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
            this.TabControlMain = new System.Windows.Forms.TabControl();
            this.TabPageControls = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnNewTransaction = new System.Windows.Forms.Button();
            this.TabPageActiveDineInTransactions = new System.Windows.Forms.TabPage();
            this.DGVActiveDineInTransactions = new System.Windows.Forms.DataGridView();
            this.TabPageCheckout = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblTransactionType = new System.Windows.Forms.Label();
            this.BtnCancelCurrentTransaction = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnCheckout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TboxTicketNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TboxCustomerName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblNumberOfItems = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblSubTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnSelectTable = new System.Windows.Forms.Button();
            this.LblCurrentTransTable = new System.Windows.Forms.Label();
            this.TabControlMain.SuspendLayout();
            this.TabPageControls.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.TabPageActiveDineInTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVActiveDineInTransactions)).BeginInit();
            this.TabPageCheckout.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlMain
            // 
            this.TabControlMain.Controls.Add(this.TabPageControls);
            this.TabControlMain.Controls.Add(this.TabPageActiveDineInTransactions);
            this.TabControlMain.Controls.Add(this.TabPageCheckout);
            this.TabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlMain.Location = new System.Drawing.Point(0, 0);
            this.TabControlMain.Name = "TabControlMain";
            this.TabControlMain.SelectedIndex = 0;
            this.TabControlMain.Size = new System.Drawing.Size(548, 308);
            this.TabControlMain.TabIndex = 12;
            this.TabControlMain.SelectedIndexChanged += new System.EventHandler(this.TabControlMain_SelectedIndexChanged);
            // 
            // TabPageControls
            // 
            this.TabPageControls.Controls.Add(this.flowLayoutPanel1);
            this.TabPageControls.Location = new System.Drawing.Point(4, 30);
            this.TabPageControls.Name = "TabPageControls";
            this.TabPageControls.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageControls.Size = new System.Drawing.Size(540, 274);
            this.TabPageControls.TabIndex = 0;
            this.TabPageControls.Text = "Controls";
            this.TabPageControls.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtnNewTransaction);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(534, 268);
            this.flowLayoutPanel1.TabIndex = 68;
            // 
            // BtnNewTransaction
            // 
            this.BtnNewTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(64)))), ((int)(((byte)(56)))));
            this.BtnNewTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNewTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnNewTransaction.ForeColor = System.Drawing.Color.White;
            this.BtnNewTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNewTransaction.Location = new System.Drawing.Point(3, 3);
            this.BtnNewTransaction.Name = "BtnNewTransaction";
            this.BtnNewTransaction.Size = new System.Drawing.Size(111, 38);
            this.BtnNewTransaction.TabIndex = 64;
            this.BtnNewTransaction.Text = "NEW";
            this.BtnNewTransaction.UseVisualStyleBackColor = false;
            this.BtnNewTransaction.Click += new System.EventHandler(this.BtnNewTransaction_Click);
            // 
            // TabPageActiveDineInTransactions
            // 
            this.TabPageActiveDineInTransactions.Controls.Add(this.DGVActiveDineInTransactions);
            this.TabPageActiveDineInTransactions.Location = new System.Drawing.Point(4, 30);
            this.TabPageActiveDineInTransactions.Name = "TabPageActiveDineInTransactions";
            this.TabPageActiveDineInTransactions.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageActiveDineInTransactions.Size = new System.Drawing.Size(540, 274);
            this.TabPageActiveDineInTransactions.TabIndex = 1;
            this.TabPageActiveDineInTransactions.Text = "ACTIVE DINE-IN";
            this.TabPageActiveDineInTransactions.UseVisualStyleBackColor = true;
            // 
            // DGVActiveDineInTransactions
            // 
            this.DGVActiveDineInTransactions.AllowUserToAddRows = false;
            this.DGVActiveDineInTransactions.AllowUserToDeleteRows = false;
            this.DGVActiveDineInTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVActiveDineInTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVActiveDineInTransactions.Location = new System.Drawing.Point(3, 3);
            this.DGVActiveDineInTransactions.Name = "DGVActiveDineInTransactions";
            this.DGVActiveDineInTransactions.ReadOnly = true;
            this.DGVActiveDineInTransactions.RowTemplate.Height = 25;
            this.DGVActiveDineInTransactions.Size = new System.Drawing.Size(534, 268);
            this.DGVActiveDineInTransactions.TabIndex = 0;
            this.DGVActiveDineInTransactions.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVActiveDineInTransactions_CellClick);
            // 
            // TabPageCheckout
            // 
            this.TabPageCheckout.Controls.Add(this.panel1);
            this.TabPageCheckout.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TabPageCheckout.Location = new System.Drawing.Point(4, 30);
            this.TabPageCheckout.Name = "TabPageCheckout";
            this.TabPageCheckout.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCheckout.Size = new System.Drawing.Size(540, 274);
            this.TabPageCheckout.TabIndex = 2;
            this.TabPageCheckout.Text = "Checkout";
            this.TabPageCheckout.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblCurrentTransTable);
            this.panel1.Controls.Add(this.BtnSelectTable);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.BtnCancelCurrentTransaction);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Controls.Add(this.BtnCheckout);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TboxTicketNumber);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TboxCustomerName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(14, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 268);
            this.panel1.TabIndex = 72;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LblTransactionType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(429, 41);
            this.panel3.TabIndex = 73;
            // 
            // LblTransactionType
            // 
            this.LblTransactionType.AutoSize = true;
            this.LblTransactionType.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblTransactionType.Location = new System.Drawing.Point(11, 10);
            this.LblTransactionType.Name = "LblTransactionType";
            this.LblTransactionType.Size = new System.Drawing.Size(159, 25);
            this.LblTransactionType.TabIndex = 0;
            this.LblTransactionType.Text = "Transaction type";
            // 
            // BtnCancelCurrentTransaction
            // 
            this.BtnCancelCurrentTransaction.BackColor = System.Drawing.Color.DarkRed;
            this.BtnCancelCurrentTransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelCurrentTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelCurrentTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelCurrentTransaction.ForeColor = System.Drawing.Color.White;
            this.BtnCancelCurrentTransaction.Image = global::Main.Properties.Resources.icons8_cancel_30;
            this.BtnCancelCurrentTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelCurrentTransaction.Location = new System.Drawing.Point(30, 179);
            this.BtnCancelCurrentTransaction.Name = "BtnCancelCurrentTransaction";
            this.BtnCancelCurrentTransaction.Size = new System.Drawing.Size(108, 45);
            this.BtnCancelCurrentTransaction.TabIndex = 71;
            this.BtnCancelCurrentTransaction.Text = "CANCEL";
            this.BtnCancelCurrentTransaction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelCurrentTransaction.UseVisualStyleBackColor = false;
            this.BtnCancelCurrentTransaction.Click += new System.EventHandler(this.BtnCancelCurrentTransaction_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Image = global::Main.Properties.Resources.save_white_26;
            this.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSave.Location = new System.Drawing.Point(168, 179);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(87, 45);
            this.BtnSave.TabIndex = 70;
            this.BtnSave.Text = "SAVE";
            this.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            this.BtnCheckout.Location = new System.Drawing.Point(282, 179);
            this.BtnCheckout.Name = "BtnCheckout";
            this.BtnCheckout.Size = new System.Drawing.Size(122, 45);
            this.BtnCheckout.TabIndex = 69;
            this.BtnCheckout.Text = "CHECKOUT";
            this.BtnCheckout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCheckout.UseVisualStyleBackColor = false;
            this.BtnCheckout.Click += new System.EventHandler(this.BtnCheckout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket #";
            // 
            // TboxTicketNumber
            // 
            this.TboxTicketNumber.Enabled = false;
            this.TboxTicketNumber.Location = new System.Drawing.Point(142, 63);
            this.TboxTicketNumber.Name = "TboxTicketNumber";
            this.TboxTicketNumber.Size = new System.Drawing.Size(235, 27);
            this.TboxTicketNumber.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Customer";
            // 
            // TboxCustomerName
            // 
            this.TboxCustomerName.Enabled = false;
            this.TboxCustomerName.Location = new System.Drawing.Point(142, 98);
            this.TboxCustomerName.Name = "TboxCustomerName";
            this.TboxCustomerName.Size = new System.Drawing.Size(235, 27);
            this.TboxCustomerName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Table/Order #";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TabControlMain);
            this.splitContainer1.Size = new System.Drawing.Size(828, 308);
            this.splitContainer1.SplitterDistance = 276;
            this.splitContainer1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LblNumberOfItems);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.LblSubTotal);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 308);
            this.panel2.TabIndex = 0;
            // 
            // LblNumberOfItems
            // 
            this.LblNumberOfItems.ForeColor = System.Drawing.Color.Red;
            this.LblNumberOfItems.Location = new System.Drawing.Point(18, 178);
            this.LblNumberOfItems.Name = "LblNumberOfItems";
            this.LblNumberOfItems.Size = new System.Drawing.Size(136, 25);
            this.LblNumberOfItems.TabIndex = 3;
            this.LblNumberOfItems.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 25);
            this.label6.TabIndex = 2;
            this.label6.Text = "Number Of Items";
            // 
            // LblSubTotal
            // 
            this.LblSubTotal.ForeColor = System.Drawing.Color.Red;
            this.LblSubTotal.Location = new System.Drawing.Point(18, 87);
            this.LblSubTotal.Name = "LblSubTotal";
            this.LblSubTotal.Size = new System.Drawing.Size(136, 25);
            this.LblSubTotal.TabIndex = 1;
            this.LblSubTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Sub Total:";
            // 
            // BtnSelectTable
            // 
            this.BtnSelectTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSelectTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnSelectTable.ForeColor = System.Drawing.Color.White;
            this.BtnSelectTable.Location = new System.Drawing.Point(261, 131);
            this.BtnSelectTable.Name = "BtnSelectTable";
            this.BtnSelectTable.Size = new System.Drawing.Size(116, 30);
            this.BtnSelectTable.TabIndex = 75;
            this.BtnSelectTable.Text = "Change table";
            this.BtnSelectTable.UseVisualStyleBackColor = false;
            this.BtnSelectTable.Click += new System.EventHandler(this.BtnSelectTable_Click);
            // 
            // LblCurrentTransTable
            // 
            this.LblCurrentTransTable.AutoSize = true;
            this.LblCurrentTransTable.Location = new System.Drawing.Point(142, 132);
            this.LblCurrentTransTable.Name = "LblCurrentTransTable";
            this.LblCurrentTransTable.Size = new System.Drawing.Size(31, 20);
            this.LblCurrentTransTable.TabIndex = 76;
            this.LblCurrentTransTable.Text = "T-0";
            // 
            // POSControllerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "POSControllerControl";
            this.Size = new System.Drawing.Size(828, 308);
            this.Load += new System.EventHandler(this.POSCheckOutControllerControl_Load);
            this.TabControlMain.ResumeLayout(false);
            this.TabPageControls.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.TabPageActiveDineInTransactions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVActiveDineInTransactions)).EndInit();
            this.TabPageCheckout.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl TabControlMain;
        private System.Windows.Forms.TabPage TabPageControls;
        private System.Windows.Forms.TabPage TabPageActiveDineInTransactions;
        private System.Windows.Forms.Button BtnNewTransaction;
        private System.Windows.Forms.DataGridView DGVActiveDineInTransactions;
        private System.Windows.Forms.TabPage TabPageCheckout;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCheckout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TboxTicketNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TboxCustomerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnCancelCurrentTransaction;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblSubTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblNumberOfItems;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblTransactionType;
        private System.Windows.Forms.Button BtnSelectTable;
        private System.Windows.Forms.Label LblCurrentTransTable;
    }
}
