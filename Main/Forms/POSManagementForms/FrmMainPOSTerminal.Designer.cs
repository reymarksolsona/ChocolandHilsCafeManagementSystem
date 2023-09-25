
namespace Main.Forms.POSManagementForms
{
    partial class FrmMainPOSTerminal
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
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.LeftSideSplitInnerContainer = new System.Windows.Forms.SplitContainer();
            this.DGVCartItems = new System.Windows.Forms.DataGridView();
            this.TopPanelInSplitContainerPanel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.TabControlProductsAndComboMeals = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.RightSideSplitInnerContainer = new System.Windows.Forms.SplitContainer();
            this.FLPanelProductList = new System.Windows.Forms.FlowLayoutPanel();
            this.FLPanelProductCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.TopPanelInSplitContainerPanel2 = new System.Windows.Forms.Panel();
            this.LblCurrentProductCategory = new System.Windows.Forms.Label();
            this.BtnRefreshProductList = new System.Windows.Forms.Button();
            this.TbxSearchProducts = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FlowLayoutComboMealItems = new System.Windows.Forms.FlowLayoutPanel();
            this.LVComboMealProducts = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnRefreshComboMealItems = new System.Windows.Forms.Button();
            this.TboxSearchComboMeals = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.POSMainTabControl = new System.Windows.Forms.TabControl();
            this.TabPageStore = new System.Windows.Forms.TabPage();
            this.TabPageTableStatus = new System.Windows.Forms.TabPage();
            this.PanelDineInOrdersTableStatus = new System.Windows.Forms.Panel();
            this.FlowLayoutTables = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnNumberOfTables = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TabPageSalesHistory = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblTotalSales = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnFilterSaleHistory = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DPickerEndDateForSalesHistory = new System.Windows.Forms.DateTimePicker();
            this.DPickerStartDateForSalesHistory = new System.Windows.Forms.DateTimePicker();
            this.LVTransactionHistory = new System.Windows.Forms.ListView();
            this.TicketNumber = new System.Windows.Forms.ColumnHeader();
            this.CustomerName = new System.Windows.Forms.ColumnHeader();
            this.SubTotal = new System.Windows.Forms.ColumnHeader();
            this.Discount = new System.Windows.Forms.ColumnHeader();
            this.Percentage = new System.Windows.Forms.ColumnHeader();
            this.Total = new System.Windows.Forms.ColumnHeader();
            this.Status = new System.Windows.Forms.ColumnHeader();
            this.CashierName = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.TabProductOrderQty = new System.Windows.Forms.TabPage();
            this.LVProductAndComboMealOrders = new System.Windows.Forms.ListView();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnFilterProductOrderReport = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.DPicEndDateFilterProductOrdersReport = new System.Windows.Forms.DateTimePicker();
            this.DPicStartDateFilterProductOrdersReport = new System.Windows.Forms.DateTimePicker();
            this.TabPageIngredientsBreakdown = new System.Windows.Forms.TabPage();
            this.LVIngredientBreakdown = new System.Windows.Forms.ListView();
            this.Category = new System.Windows.Forms.ColumnHeader();
            this.Ingredient = new System.Windows.Forms.ColumnHeader();
            this.RemainingQtyValue = new System.Windows.Forms.ColumnHeader();
            this.ConsumeQtyValue = new System.Windows.Forms.ColumnHeader();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BtnFilterIngredientBreakdownReport = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.DPicEndDateIngBreakdownReport = new System.Windows.Forms.DateTimePicker();
            this.DPicStartDateIngBreakdownReport = new System.Windows.Forms.DateTimePicker();
            this.TabPageCashRegister = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.DGVCashRegisterTransactions = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.NumUpDwnTotalCash = new System.Windows.Forms.NumericUpDown();
            this.BtnCancelUpdateCashRegisterTrans = new System.Windows.Forms.Button();
            this.BtnSaveCashRegisterTransaction = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.NumUpDwnRemCash = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.NumUpDwnCashOut = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.NumUpDwnTotalSalesToday = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.NumUpDwnPrevDayRemCash = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.PanelPOSController = new System.Windows.Forms.Panel();
            this.POSControllerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.TboxCurrentNumberOfTables = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftSideSplitInnerContainer)).BeginInit();
            this.LeftSideSplitInnerContainer.Panel1.SuspendLayout();
            this.LeftSideSplitInnerContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCartItems)).BeginInit();
            this.TopPanelInSplitContainerPanel1.SuspendLayout();
            this.TabControlProductsAndComboMeals.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightSideSplitInnerContainer)).BeginInit();
            this.RightSideSplitInnerContainer.Panel1.SuspendLayout();
            this.RightSideSplitInnerContainer.Panel2.SuspendLayout();
            this.RightSideSplitInnerContainer.SuspendLayout();
            this.TopPanelInSplitContainerPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.POSMainTabControl.SuspendLayout();
            this.TabPageStore.SuspendLayout();
            this.TabPageTableStatus.SuspendLayout();
            this.PanelDineInOrdersTableStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.TabPageSalesHistory.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TabProductOrderQty.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.TabPageIngredientsBreakdown.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.TabPageCashRegister.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCashRegisterTransactions)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnTotalCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnRemCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnCashOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnTotalSalesToday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnPrevDayRemCash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.POSControllerSplitContainer)).BeginInit();
            this.POSControllerSplitContainer.Panel2.SuspendLayout();
            this.POSControllerSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TboxCurrentNumberOfTables)).BeginInit();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(255)))));
            this.MainSplitContainer.Panel1.Controls.Add(this.LeftSideSplitInnerContainer);
            this.MainSplitContainer.Panel1.Controls.Add(this.TopPanelInSplitContainerPanel1);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(242)))));
            this.MainSplitContainer.Panel2.Controls.Add(this.TabControlProductsAndComboMeals);
            this.MainSplitContainer.Size = new System.Drawing.Size(1207, 632);
            this.MainSplitContainer.SplitterDistance = 603;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // LeftSideSplitInnerContainer
            // 
            this.LeftSideSplitInnerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftSideSplitInnerContainer.Location = new System.Drawing.Point(0, 54);
            this.LeftSideSplitInnerContainer.Name = "LeftSideSplitInnerContainer";
            this.LeftSideSplitInnerContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LeftSideSplitInnerContainer.Panel1
            // 
            this.LeftSideSplitInnerContainer.Panel1.Controls.Add(this.DGVCartItems);
            this.LeftSideSplitInnerContainer.Size = new System.Drawing.Size(603, 578);
            this.LeftSideSplitInnerContainer.SplitterDistance = 340;
            this.LeftSideSplitInnerContainer.TabIndex = 2;
            // 
            // DGVCartItems
            // 
            this.DGVCartItems.AllowUserToAddRows = false;
            this.DGVCartItems.AllowUserToDeleteRows = false;
            this.DGVCartItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCartItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVCartItems.Location = new System.Drawing.Point(0, 0);
            this.DGVCartItems.Name = "DGVCartItems";
            this.DGVCartItems.ReadOnly = true;
            this.DGVCartItems.RowTemplate.Height = 25;
            this.DGVCartItems.Size = new System.Drawing.Size(603, 340);
            this.DGVCartItems.TabIndex = 0;
            this.DGVCartItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCartItems_CellClick);
            // 
            // TopPanelInSplitContainerPanel1
            // 
            this.TopPanelInSplitContainerPanel1.Controls.Add(this.label9);
            this.TopPanelInSplitContainerPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanelInSplitContainerPanel1.Location = new System.Drawing.Point(0, 0);
            this.TopPanelInSplitContainerPanel1.Name = "TopPanelInSplitContainerPanel1";
            this.TopPanelInSplitContainerPanel1.Size = new System.Drawing.Size(603, 54);
            this.TopPanelInSplitContainerPanel1.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(15, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 21);
            this.label9.TabIndex = 4;
            this.label9.Text = "Items:";
            // 
            // TabControlProductsAndComboMeals
            // 
            this.TabControlProductsAndComboMeals.Controls.Add(this.tabPage2);
            this.TabControlProductsAndComboMeals.Controls.Add(this.tabPage3);
            this.TabControlProductsAndComboMeals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlProductsAndComboMeals.Location = new System.Drawing.Point(0, 0);
            this.TabControlProductsAndComboMeals.Name = "TabControlProductsAndComboMeals";
            this.TabControlProductsAndComboMeals.SelectedIndex = 0;
            this.TabControlProductsAndComboMeals.Size = new System.Drawing.Size(600, 632);
            this.TabControlProductsAndComboMeals.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.RightSideSplitInnerContainer);
            this.tabPage2.Controls.Add(this.TopPanelInSplitContainerPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 598);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Products";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // RightSideSplitInnerContainer
            // 
            this.RightSideSplitInnerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightSideSplitInnerContainer.Location = new System.Drawing.Point(3, 77);
            this.RightSideSplitInnerContainer.Name = "RightSideSplitInnerContainer";
            this.RightSideSplitInnerContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // RightSideSplitInnerContainer.Panel1
            // 
            this.RightSideSplitInnerContainer.Panel1.Controls.Add(this.FLPanelProductList);
            // 
            // RightSideSplitInnerContainer.Panel2
            // 
            this.RightSideSplitInnerContainer.Panel2.Controls.Add(this.FLPanelProductCategories);
            this.RightSideSplitInnerContainer.Size = new System.Drawing.Size(586, 518);
            this.RightSideSplitInnerContainer.SplitterDistance = 304;
            this.RightSideSplitInnerContainer.TabIndex = 2;
            // 
            // FLPanelProductList
            // 
            this.FLPanelProductList.AutoScroll = true;
            this.FLPanelProductList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLPanelProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPanelProductList.Location = new System.Drawing.Point(0, 0);
            this.FLPanelProductList.Name = "FLPanelProductList";
            this.FLPanelProductList.Size = new System.Drawing.Size(586, 304);
            this.FLPanelProductList.TabIndex = 0;
            // 
            // FLPanelProductCategories
            // 
            this.FLPanelProductCategories.AutoScroll = true;
            this.FLPanelProductCategories.BackColor = System.Drawing.SystemColors.ControlLight;
            this.FLPanelProductCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FLPanelProductCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FLPanelProductCategories.Location = new System.Drawing.Point(0, 0);
            this.FLPanelProductCategories.Name = "FLPanelProductCategories";
            this.FLPanelProductCategories.Size = new System.Drawing.Size(586, 210);
            this.FLPanelProductCategories.TabIndex = 0;
            // 
            // TopPanelInSplitContainerPanel2
            // 
            this.TopPanelInSplitContainerPanel2.Controls.Add(this.LblCurrentProductCategory);
            this.TopPanelInSplitContainerPanel2.Controls.Add(this.BtnRefreshProductList);
            this.TopPanelInSplitContainerPanel2.Controls.Add(this.TbxSearchProducts);
            this.TopPanelInSplitContainerPanel2.Controls.Add(this.label2);
            this.TopPanelInSplitContainerPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanelInSplitContainerPanel2.Location = new System.Drawing.Point(3, 3);
            this.TopPanelInSplitContainerPanel2.Name = "TopPanelInSplitContainerPanel2";
            this.TopPanelInSplitContainerPanel2.Size = new System.Drawing.Size(586, 74);
            this.TopPanelInSplitContainerPanel2.TabIndex = 1;
            // 
            // LblCurrentProductCategory
            // 
            this.LblCurrentProductCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(209)))));
            this.LblCurrentProductCategory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblCurrentProductCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblCurrentProductCategory.ForeColor = System.Drawing.Color.White;
            this.LblCurrentProductCategory.Location = new System.Drawing.Point(0, 53);
            this.LblCurrentProductCategory.Name = "LblCurrentProductCategory";
            this.LblCurrentProductCategory.Size = new System.Drawing.Size(586, 21);
            this.LblCurrentProductCategory.TabIndex = 63;
            this.LblCurrentProductCategory.Text = "Current Category";
            // 
            // BtnRefreshProductList
            // 
            this.BtnRefreshProductList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnRefreshProductList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefreshProductList.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRefreshProductList.ForeColor = System.Drawing.Color.White;
            this.BtnRefreshProductList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefreshProductList.Location = new System.Drawing.Point(441, 8);
            this.BtnRefreshProductList.Name = "BtnRefreshProductList";
            this.BtnRefreshProductList.Size = new System.Drawing.Size(136, 31);
            this.BtnRefreshProductList.TabIndex = 62;
            this.BtnRefreshProductList.Text = "Refresh Products";
            this.BtnRefreshProductList.UseVisualStyleBackColor = false;
            this.BtnRefreshProductList.Click += new System.EventHandler(this.BtnRefreshProductList_Click);
            // 
            // TbxSearchProducts
            // 
            this.TbxSearchProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TbxSearchProducts.Location = new System.Drawing.Point(127, 10);
            this.TbxSearchProducts.Name = "TbxSearchProducts";
            this.TbxSearchProducts.Size = new System.Drawing.Size(284, 29);
            this.TbxSearchProducts.TabIndex = 1;
            this.TbxSearchProducts.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbxSearchProducts_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search item";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(592, 598);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Combo Meals";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 57);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FlowLayoutComboMealItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LVComboMealProducts);
            this.splitContainer1.Size = new System.Drawing.Size(586, 538);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 3;
            // 
            // FlowLayoutComboMealItems
            // 
            this.FlowLayoutComboMealItems.AutoScroll = true;
            this.FlowLayoutComboMealItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FlowLayoutComboMealItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutComboMealItems.Location = new System.Drawing.Point(0, 0);
            this.FlowLayoutComboMealItems.Name = "FlowLayoutComboMealItems";
            this.FlowLayoutComboMealItems.Size = new System.Drawing.Size(586, 316);
            this.FlowLayoutComboMealItems.TabIndex = 0;
            // 
            // LVComboMealProducts
            // 
            this.LVComboMealProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LVComboMealProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LVComboMealProducts.GridLines = true;
            this.LVComboMealProducts.HideSelection = false;
            this.LVComboMealProducts.Location = new System.Drawing.Point(0, 0);
            this.LVComboMealProducts.Name = "LVComboMealProducts";
            this.LVComboMealProducts.Size = new System.Drawing.Size(586, 218);
            this.LVComboMealProducts.TabIndex = 0;
            this.LVComboMealProducts.UseCompatibleStateImageBehavior = false;
            this.LVComboMealProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Product";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Price";
            this.columnHeader2.Width = 100;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnRefreshComboMealItems);
            this.panel2.Controls.Add(this.TboxSearchComboMeals);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 54);
            this.panel2.TabIndex = 2;
            // 
            // BtnRefreshComboMealItems
            // 
            this.BtnRefreshComboMealItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnRefreshComboMealItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRefreshComboMealItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnRefreshComboMealItems.ForeColor = System.Drawing.Color.White;
            this.BtnRefreshComboMealItems.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRefreshComboMealItems.Location = new System.Drawing.Point(434, 15);
            this.BtnRefreshComboMealItems.Name = "BtnRefreshComboMealItems";
            this.BtnRefreshComboMealItems.Size = new System.Drawing.Size(136, 31);
            this.BtnRefreshComboMealItems.TabIndex = 63;
            this.BtnRefreshComboMealItems.Text = "Refresh Combo Meals";
            this.BtnRefreshComboMealItems.UseVisualStyleBackColor = false;
            this.BtnRefreshComboMealItems.Click += new System.EventHandler(this.BtnRefreshComboMealItems_Click);
            // 
            // TboxSearchComboMeals
            // 
            this.TboxSearchComboMeals.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TboxSearchComboMeals.Location = new System.Drawing.Point(127, 17);
            this.TboxSearchComboMeals.Name = "TboxSearchComboMeals";
            this.TboxSearchComboMeals.Size = new System.Drawing.Size(284, 29);
            this.TboxSearchComboMeals.TabIndex = 1;
            this.TboxSearchComboMeals.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TboxSearchComboMeals_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(25, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 21);
            this.label11.TabIndex = 0;
            this.label11.Text = "Search item";
            // 
            // POSMainTabControl
            // 
            this.POSMainTabControl.Controls.Add(this.TabPageStore);
            this.POSMainTabControl.Controls.Add(this.TabPageTableStatus);
            this.POSMainTabControl.Controls.Add(this.TabPageSalesHistory);
            this.POSMainTabControl.Controls.Add(this.TabProductOrderQty);
            this.POSMainTabControl.Controls.Add(this.TabPageIngredientsBreakdown);
            this.POSMainTabControl.Controls.Add(this.TabPageCashRegister);
            this.POSMainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.POSMainTabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.POSMainTabControl.Location = new System.Drawing.Point(0, 0);
            this.POSMainTabControl.Name = "POSMainTabControl";
            this.POSMainTabControl.SelectedIndex = 0;
            this.POSMainTabControl.Size = new System.Drawing.Size(1221, 672);
            this.POSMainTabControl.TabIndex = 1;
            this.POSMainTabControl.SelectedIndexChanged += new System.EventHandler(this.POSMainTabControl_SelectedIndexChanged);
            // 
            // TabPageStore
            // 
            this.TabPageStore.Controls.Add(this.MainSplitContainer);
            this.TabPageStore.Location = new System.Drawing.Point(4, 30);
            this.TabPageStore.Name = "TabPageStore";
            this.TabPageStore.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageStore.Size = new System.Drawing.Size(1213, 638);
            this.TabPageStore.TabIndex = 0;
            this.TabPageStore.Text = "Store";
            this.TabPageStore.UseVisualStyleBackColor = true;
            // 
            // TabPageTableStatus
            // 
            this.TabPageTableStatus.Controls.Add(this.PanelDineInOrdersTableStatus);
            this.TabPageTableStatus.Location = new System.Drawing.Point(4, 30);
            this.TabPageTableStatus.Name = "TabPageTableStatus";
            this.TabPageTableStatus.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageTableStatus.Size = new System.Drawing.Size(1213, 638);
            this.TabPageTableStatus.TabIndex = 1;
            this.TabPageTableStatus.Text = "Tables";
            this.TabPageTableStatus.UseVisualStyleBackColor = true;
            // 
            // PanelDineInOrdersTableStatus
            // 
            this.PanelDineInOrdersTableStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelDineInOrdersTableStatus.Controls.Add(this.FlowLayoutTables);
            this.PanelDineInOrdersTableStatus.Controls.Add(this.panel1);
            this.PanelDineInOrdersTableStatus.Location = new System.Drawing.Point(63, 27);
            this.PanelDineInOrdersTableStatus.Name = "PanelDineInOrdersTableStatus";
            this.PanelDineInOrdersTableStatus.Size = new System.Drawing.Size(1101, 563);
            this.PanelDineInOrdersTableStatus.TabIndex = 0;
            // 
            // FlowLayoutTables
            // 
            this.FlowLayoutTables.AutoScroll = true;
            this.FlowLayoutTables.BackColor = System.Drawing.Color.White;
            this.FlowLayoutTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowLayoutTables.Location = new System.Drawing.Point(0, 62);
            this.FlowLayoutTables.Name = "FlowLayoutTables";
            this.FlowLayoutTables.Size = new System.Drawing.Size(1101, 501);
            this.FlowLayoutTables.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1101, 62);
            this.panel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.TboxCurrentNumberOfTables);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.BtnNumberOfTables);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(700, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(401, 62);
            this.panel5.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 64;
            this.label1.Text = "Number of tables";
            // 
            // BtnNumberOfTables
            // 
            this.BtnNumberOfTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnNumberOfTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNumberOfTables.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnNumberOfTables.ForeColor = System.Drawing.Color.White;
            this.BtnNumberOfTables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnNumberOfTables.Location = new System.Drawing.Point(301, 11);
            this.BtnNumberOfTables.Name = "BtnNumberOfTables";
            this.BtnNumberOfTables.Size = new System.Drawing.Size(83, 31);
            this.BtnNumberOfTables.TabIndex = 63;
            this.BtnNumberOfTables.Text = "Update";
            this.BtnNumberOfTables.UseVisualStyleBackColor = false;
            this.BtnNumberOfTables.Click += new System.EventHandler(this.BtnNumberOfTables_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Red;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(146, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "OCCUPIED";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LawnGreen;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(0, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "AVAILABLE";
            // 
            // TabPageSalesHistory
            // 
            this.TabPageSalesHistory.Controls.Add(this.panel3);
            this.TabPageSalesHistory.Controls.Add(this.groupBox1);
            this.TabPageSalesHistory.Controls.Add(this.LVTransactionHistory);
            this.TabPageSalesHistory.Location = new System.Drawing.Point(4, 30);
            this.TabPageSalesHistory.Name = "TabPageSalesHistory";
            this.TabPageSalesHistory.Size = new System.Drawing.Size(1213, 638);
            this.TabPageSalesHistory.TabIndex = 2;
            this.TabPageSalesHistory.Text = "Sales History";
            this.TabPageSalesHistory.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.LblTotalSales);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(622, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(583, 104);
            this.panel3.TabIndex = 27;
            // 
            // LblTotalSales
            // 
            this.LblTotalSales.AutoSize = true;
            this.LblTotalSales.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblTotalSales.ForeColor = System.Drawing.Color.Chartreuse;
            this.LblTotalSales.Location = new System.Drawing.Point(136, 28);
            this.LblTotalSales.Name = "LblTotalSales";
            this.LblTotalSales.Size = new System.Drawing.Size(76, 40);
            this.LblTotalSales.TabIndex = 25;
            this.LblTotalSales.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(21, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 40);
            this.label6.TabIndex = 24;
            this.label6.Text = "Total:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnFilterSaleHistory);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.DPickerEndDateForSalesHistory);
            this.groupBox1.Controls.Add(this.DPickerStartDateForSalesHistory);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 116);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // BtnFilterSaleHistory
            // 
            this.BtnFilterSaleHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnFilterSaleHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilterSaleHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnFilterSaleHistory.ForeColor = System.Drawing.Color.White;
            this.BtnFilterSaleHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFilterSaleHistory.Location = new System.Drawing.Point(251, 55);
            this.BtnFilterSaleHistory.Name = "BtnFilterSaleHistory";
            this.BtnFilterSaleHistory.Size = new System.Drawing.Size(81, 38);
            this.BtnFilterSaleHistory.TabIndex = 63;
            this.BtnFilterSaleHistory.Text = "Filter";
            this.BtnFilterSaleHistory.UseVisualStyleBackColor = false;
            this.BtnFilterSaleHistory.Click += new System.EventHandler(this.BtnFilterSaleHistory_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "End";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "Start";
            // 
            // DPickerEndDateForSalesHistory
            // 
            this.DPickerEndDateForSalesHistory.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerEndDateForSalesHistory.Location = new System.Drawing.Point(94, 64);
            this.DPickerEndDateForSalesHistory.Name = "DPickerEndDateForSalesHistory";
            this.DPickerEndDateForSalesHistory.Size = new System.Drawing.Size(151, 29);
            this.DPickerEndDateForSalesHistory.TabIndex = 1;
            // 
            // DPickerStartDateForSalesHistory
            // 
            this.DPickerStartDateForSalesHistory.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPickerStartDateForSalesHistory.Location = new System.Drawing.Point(94, 28);
            this.DPickerStartDateForSalesHistory.Name = "DPickerStartDateForSalesHistory";
            this.DPickerStartDateForSalesHistory.Size = new System.Drawing.Size(151, 29);
            this.DPickerStartDateForSalesHistory.TabIndex = 0;
            // 
            // LVTransactionHistory
            // 
            this.LVTransactionHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LVTransactionHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TicketNumber,
            this.CustomerName,
            this.SubTotal,
            this.Discount,
            this.Percentage,
            this.Total,
            this.Status,
            this.CashierName,
            this.columnHeader3});
            this.LVTransactionHistory.FullRowSelect = true;
            this.LVTransactionHistory.GridLines = true;
            this.LVTransactionHistory.HideSelection = false;
            this.LVTransactionHistory.Location = new System.Drawing.Point(8, 125);
            this.LVTransactionHistory.Name = "LVTransactionHistory";
            this.LVTransactionHistory.Size = new System.Drawing.Size(1197, 505);
            this.LVTransactionHistory.TabIndex = 0;
            this.LVTransactionHistory.UseCompatibleStateImageBehavior = false;
            this.LVTransactionHistory.View = System.Windows.Forms.View.Details;
            // 
            // TicketNumber
            // 
            this.TicketNumber.Text = "Ticket #";
            this.TicketNumber.Width = 120;
            // 
            // CustomerName
            // 
            this.CustomerName.Text = "Customer";
            this.CustomerName.Width = 120;
            // 
            // SubTotal
            // 
            this.SubTotal.Text = "Sub Total";
            this.SubTotal.Width = 100;
            // 
            // Discount
            // 
            this.Discount.Text = "Discount";
            this.Discount.Width = 100;
            // 
            // Percentage
            // 
            this.Percentage.Text = "Disc. Percent";
            this.Percentage.Width = 120;
            // 
            // Total
            // 
            this.Total.Text = "Total";
            this.Total.Width = 120;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 120;
            // 
            // CashierName
            // 
            this.CashierName.Text = "Cashier";
            this.CashierName.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            this.columnHeader3.Width = 120;
            // 
            // TabProductOrderQty
            // 
            this.TabProductOrderQty.Controls.Add(this.LVProductAndComboMealOrders);
            this.TabProductOrderQty.Controls.Add(this.groupBox4);
            this.TabProductOrderQty.Location = new System.Drawing.Point(4, 30);
            this.TabProductOrderQty.Name = "TabProductOrderQty";
            this.TabProductOrderQty.Padding = new System.Windows.Forms.Padding(3);
            this.TabProductOrderQty.Size = new System.Drawing.Size(1213, 638);
            this.TabProductOrderQty.TabIndex = 4;
            this.TabProductOrderQty.Text = "Product Order Qty";
            this.TabProductOrderQty.UseVisualStyleBackColor = true;
            // 
            // LVProductAndComboMealOrders
            // 
            this.LVProductAndComboMealOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LVProductAndComboMealOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.LVProductAndComboMealOrders.FullRowSelect = true;
            this.LVProductAndComboMealOrders.GridLines = true;
            this.LVProductAndComboMealOrders.HideSelection = false;
            this.LVProductAndComboMealOrders.Location = new System.Drawing.Point(8, 125);
            this.LVProductAndComboMealOrders.Name = "LVProductAndComboMealOrders";
            this.LVProductAndComboMealOrders.Size = new System.Drawing.Size(1197, 505);
            this.LVProductAndComboMealOrders.TabIndex = 3;
            this.LVProductAndComboMealOrders.UseCompatibleStateImageBehavior = false;
            this.LVProductAndComboMealOrders.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Category";
            this.columnHeader13.Width = 120;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Product";
            this.columnHeader14.Width = 150;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Price";
            this.columnHeader15.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Orders";
            this.columnHeader16.Width = 100;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Total";
            this.columnHeader17.Width = 100;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnFilterProductOrderReport);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.DPicEndDateFilterProductOrdersReport);
            this.groupBox4.Controls.Add(this.DPicStartDateFilterProductOrdersReport);
            this.groupBox4.Location = new System.Drawing.Point(8, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(358, 116);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filter";
            // 
            // BtnFilterProductOrderReport
            // 
            this.BtnFilterProductOrderReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnFilterProductOrderReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilterProductOrderReport.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnFilterProductOrderReport.ForeColor = System.Drawing.Color.White;
            this.BtnFilterProductOrderReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFilterProductOrderReport.Location = new System.Drawing.Point(251, 55);
            this.BtnFilterProductOrderReport.Name = "BtnFilterProductOrderReport";
            this.BtnFilterProductOrderReport.Size = new System.Drawing.Size(81, 38);
            this.BtnFilterProductOrderReport.TabIndex = 63;
            this.BtnFilterProductOrderReport.Text = "Filter";
            this.BtnFilterProductOrderReport.UseVisualStyleBackColor = false;
            this.BtnFilterProductOrderReport.Click += new System.EventHandler(this.BtnFilterProductOrderReport_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(21, 70);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 21);
            this.label21.TabIndex = 3;
            this.label21.Text = "End";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(21, 35);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 21);
            this.label22.TabIndex = 2;
            this.label22.Text = "Start";
            // 
            // DPicEndDateFilterProductOrdersReport
            // 
            this.DPicEndDateFilterProductOrdersReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicEndDateFilterProductOrdersReport.Location = new System.Drawing.Point(94, 64);
            this.DPicEndDateFilterProductOrdersReport.Name = "DPicEndDateFilterProductOrdersReport";
            this.DPicEndDateFilterProductOrdersReport.Size = new System.Drawing.Size(151, 29);
            this.DPicEndDateFilterProductOrdersReport.TabIndex = 1;
            // 
            // DPicStartDateFilterProductOrdersReport
            // 
            this.DPicStartDateFilterProductOrdersReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicStartDateFilterProductOrdersReport.Location = new System.Drawing.Point(94, 28);
            this.DPicStartDateFilterProductOrdersReport.Name = "DPicStartDateFilterProductOrdersReport";
            this.DPicStartDateFilterProductOrdersReport.Size = new System.Drawing.Size(151, 29);
            this.DPicStartDateFilterProductOrdersReport.TabIndex = 0;
            // 
            // TabPageIngredientsBreakdown
            // 
            this.TabPageIngredientsBreakdown.Controls.Add(this.LVIngredientBreakdown);
            this.TabPageIngredientsBreakdown.Controls.Add(this.groupBox5);
            this.TabPageIngredientsBreakdown.Location = new System.Drawing.Point(4, 30);
            this.TabPageIngredientsBreakdown.Name = "TabPageIngredientsBreakdown";
            this.TabPageIngredientsBreakdown.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageIngredientsBreakdown.Size = new System.Drawing.Size(1213, 638);
            this.TabPageIngredientsBreakdown.TabIndex = 5;
            this.TabPageIngredientsBreakdown.Text = "Ingredients Breakdown";
            this.TabPageIngredientsBreakdown.UseVisualStyleBackColor = true;
            // 
            // LVIngredientBreakdown
            // 
            this.LVIngredientBreakdown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LVIngredientBreakdown.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Category,
            this.Ingredient,
            this.RemainingQtyValue,
            this.ConsumeQtyValue});
            this.LVIngredientBreakdown.FullRowSelect = true;
            this.LVIngredientBreakdown.GridLines = true;
            this.LVIngredientBreakdown.HideSelection = false;
            this.LVIngredientBreakdown.Location = new System.Drawing.Point(8, 125);
            this.LVIngredientBreakdown.Name = "LVIngredientBreakdown";
            this.LVIngredientBreakdown.Size = new System.Drawing.Size(1197, 505);
            this.LVIngredientBreakdown.TabIndex = 5;
            this.LVIngredientBreakdown.UseCompatibleStateImageBehavior = false;
            this.LVIngredientBreakdown.View = System.Windows.Forms.View.Details;
            // 
            // Category
            // 
            this.Category.Text = "Category";
            this.Category.Width = 150;
            // 
            // Ingredient
            // 
            this.Ingredient.Text = "Ingredient";
            this.Ingredient.Width = 150;
            // 
            // RemainingQtyValue
            // 
            this.RemainingQtyValue.Text = "Remaining";
            this.RemainingQtyValue.Width = 120;
            // 
            // ConsumeQtyValue
            // 
            this.ConsumeQtyValue.Text = "Consume";
            this.ConsumeQtyValue.Width = 120;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BtnFilterIngredientBreakdownReport);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.DPicEndDateIngBreakdownReport);
            this.groupBox5.Controls.Add(this.DPicStartDateIngBreakdownReport);
            this.groupBox5.Location = new System.Drawing.Point(8, 9);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(358, 116);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Filter";
            // 
            // BtnFilterIngredientBreakdownReport
            // 
            this.BtnFilterIngredientBreakdownReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnFilterIngredientBreakdownReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFilterIngredientBreakdownReport.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnFilterIngredientBreakdownReport.ForeColor = System.Drawing.Color.White;
            this.BtnFilterIngredientBreakdownReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFilterIngredientBreakdownReport.Location = new System.Drawing.Point(251, 55);
            this.BtnFilterIngredientBreakdownReport.Name = "BtnFilterIngredientBreakdownReport";
            this.BtnFilterIngredientBreakdownReport.Size = new System.Drawing.Size(81, 38);
            this.BtnFilterIngredientBreakdownReport.TabIndex = 63;
            this.BtnFilterIngredientBreakdownReport.Text = "Filter";
            this.BtnFilterIngredientBreakdownReport.UseVisualStyleBackColor = false;
            this.BtnFilterIngredientBreakdownReport.Click += new System.EventHandler(this.BtnFilterIngredientBreakdownReport_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(21, 70);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(37, 21);
            this.label23.TabIndex = 3;
            this.label23.Text = "End";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(21, 35);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 21);
            this.label24.TabIndex = 2;
            this.label24.Text = "Start";
            // 
            // DPicEndDateIngBreakdownReport
            // 
            this.DPicEndDateIngBreakdownReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicEndDateIngBreakdownReport.Location = new System.Drawing.Point(94, 64);
            this.DPicEndDateIngBreakdownReport.Name = "DPicEndDateIngBreakdownReport";
            this.DPicEndDateIngBreakdownReport.Size = new System.Drawing.Size(151, 29);
            this.DPicEndDateIngBreakdownReport.TabIndex = 1;
            // 
            // DPicStartDateIngBreakdownReport
            // 
            this.DPicStartDateIngBreakdownReport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DPicStartDateIngBreakdownReport.Location = new System.Drawing.Point(94, 28);
            this.DPicStartDateIngBreakdownReport.Name = "DPicStartDateIngBreakdownReport";
            this.DPicStartDateIngBreakdownReport.Size = new System.Drawing.Size(151, 29);
            this.DPicStartDateIngBreakdownReport.TabIndex = 0;
            // 
            // TabPageCashRegister
            // 
            this.TabPageCashRegister.Controls.Add(this.panel4);
            this.TabPageCashRegister.Location = new System.Drawing.Point(4, 30);
            this.TabPageCashRegister.Name = "TabPageCashRegister";
            this.TabPageCashRegister.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCashRegister.Size = new System.Drawing.Size(1213, 638);
            this.TabPageCashRegister.TabIndex = 3;
            this.TabPageCashRegister.Text = "Cash Register";
            this.TabPageCashRegister.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.DGVCashRegisterTransactions);
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Location = new System.Drawing.Point(8, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1197, 617);
            this.panel4.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(499, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(248, 21);
            this.label20.TabIndex = 72;
            this.label20.Text = "Last 30 days cash out transaction";
            // 
            // DGVCashRegisterTransactions
            // 
            this.DGVCashRegisterTransactions.AllowUserToAddRows = false;
            this.DGVCashRegisterTransactions.AllowUserToDeleteRows = false;
            this.DGVCashRegisterTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVCashRegisterTransactions.Location = new System.Drawing.Point(495, 89);
            this.DGVCashRegisterTransactions.Name = "DGVCashRegisterTransactions";
            this.DGVCashRegisterTransactions.ReadOnly = true;
            this.DGVCashRegisterTransactions.RowTemplate.Height = 25;
            this.DGVCashRegisterTransactions.Size = new System.Drawing.Size(614, 452);
            this.DGVCashRegisterTransactions.TabIndex = 71;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.NumUpDwnTotalCash);
            this.groupBox2.Controls.Add(this.BtnCancelUpdateCashRegisterTrans);
            this.groupBox2.Controls.Add(this.BtnSaveCashRegisterTransaction);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.NumUpDwnRemCash);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.NumUpDwnCashOut);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.NumUpDwnTotalSalesToday);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.NumUpDwnPrevDayRemCash);
            this.groupBox2.Location = new System.Drawing.Point(138, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 470);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cash Register Current value";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 186);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 21);
            this.label19.TabIndex = 7;
            this.label19.Text = "Total Cash";
            // 
            // NumUpDwnTotalCash
            // 
            this.NumUpDwnTotalCash.DecimalPlaces = 2;
            this.NumUpDwnTotalCash.Enabled = false;
            this.NumUpDwnTotalCash.Location = new System.Drawing.Point(24, 210);
            this.NumUpDwnTotalCash.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.NumUpDwnTotalCash.Name = "NumUpDwnTotalCash";
            this.NumUpDwnTotalCash.Size = new System.Drawing.Size(261, 29);
            this.NumUpDwnTotalCash.TabIndex = 6;
            // 
            // BtnCancelUpdateCashRegisterTrans
            // 
            this.BtnCancelUpdateCashRegisterTrans.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnCancelUpdateCashRegisterTrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelUpdateCashRegisterTrans.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnCancelUpdateCashRegisterTrans.ForeColor = System.Drawing.Color.White;
            this.BtnCancelUpdateCashRegisterTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelUpdateCashRegisterTrans.Location = new System.Drawing.Point(107, 389);
            this.BtnCancelUpdateCashRegisterTrans.Name = "BtnCancelUpdateCashRegisterTrans";
            this.BtnCancelUpdateCashRegisterTrans.Size = new System.Drawing.Size(81, 38);
            this.BtnCancelUpdateCashRegisterTrans.TabIndex = 65;
            this.BtnCancelUpdateCashRegisterTrans.Text = "Cancel";
            this.BtnCancelUpdateCashRegisterTrans.UseVisualStyleBackColor = false;
            // 
            // BtnSaveCashRegisterTransaction
            // 
            this.BtnSaveCashRegisterTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.BtnSaveCashRegisterTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSaveCashRegisterTransaction.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BtnSaveCashRegisterTransaction.ForeColor = System.Drawing.Color.White;
            this.BtnSaveCashRegisterTransaction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSaveCashRegisterTransaction.Location = new System.Drawing.Point(204, 389);
            this.BtnSaveCashRegisterTransaction.Name = "BtnSaveCashRegisterTransaction";
            this.BtnSaveCashRegisterTransaction.Size = new System.Drawing.Size(81, 38);
            this.BtnSaveCashRegisterTransaction.TabIndex = 64;
            this.BtnSaveCashRegisterTransaction.Text = "Submit";
            this.BtnSaveCashRegisterTransaction.UseVisualStyleBackColor = false;
            this.BtnSaveCashRegisterTransaction.Click += new System.EventHandler(this.BtnSaveCashRegisterTransaction_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(27, 312);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(123, 21);
            this.label18.TabIndex = 7;
            this.label18.Text = "Remaining cash";
            // 
            // NumUpDwnRemCash
            // 
            this.NumUpDwnRemCash.DecimalPlaces = 2;
            this.NumUpDwnRemCash.Enabled = false;
            this.NumUpDwnRemCash.Location = new System.Drawing.Point(24, 336);
            this.NumUpDwnRemCash.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.NumUpDwnRemCash.Name = "NumUpDwnRemCash";
            this.NumUpDwnRemCash.Size = new System.Drawing.Size(261, 29);
            this.NumUpDwnRemCash.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 250);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 21);
            this.label14.TabIndex = 5;
            this.label14.Text = "Cash out";
            // 
            // NumUpDwnCashOut
            // 
            this.NumUpDwnCashOut.DecimalPlaces = 2;
            this.NumUpDwnCashOut.Location = new System.Drawing.Point(24, 274);
            this.NumUpDwnCashOut.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.NumUpDwnCashOut.Name = "NumUpDwnCashOut";
            this.NumUpDwnCashOut.Size = new System.Drawing.Size(261, 29);
            this.NumUpDwnCashOut.TabIndex = 4;
            this.NumUpDwnCashOut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NumUpDwnCashOut_KeyUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 21);
            this.label13.TabIndex = 3;
            this.label13.Text = "Total sales today";
            // 
            // NumUpDwnTotalSalesToday
            // 
            this.NumUpDwnTotalSalesToday.DecimalPlaces = 2;
            this.NumUpDwnTotalSalesToday.Enabled = false;
            this.NumUpDwnTotalSalesToday.Location = new System.Drawing.Point(24, 145);
            this.NumUpDwnTotalSalesToday.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.NumUpDwnTotalSalesToday.Name = "NumUpDwnTotalSalesToday";
            this.NumUpDwnTotalSalesToday.Size = new System.Drawing.Size(261, 29);
            this.NumUpDwnTotalSalesToday.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(215, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Previous day remaining cash";
            // 
            // NumUpDwnPrevDayRemCash
            // 
            this.NumUpDwnPrevDayRemCash.DecimalPlaces = 2;
            this.NumUpDwnPrevDayRemCash.Enabled = false;
            this.NumUpDwnPrevDayRemCash.Location = new System.Drawing.Point(24, 79);
            this.NumUpDwnPrevDayRemCash.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.NumUpDwnPrevDayRemCash.Name = "NumUpDwnPrevDayRemCash";
            this.NumUpDwnPrevDayRemCash.Size = new System.Drawing.Size(261, 29);
            this.NumUpDwnPrevDayRemCash.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(235, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 21);
            this.label12.TabIndex = 3;
            this.label12.Text = "Search item code";
            // 
            // PanelPOSController
            // 
            this.PanelPOSController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelPOSController.Location = new System.Drawing.Point(0, 0);
            this.PanelPOSController.Name = "PanelPOSController";
            this.PanelPOSController.Size = new System.Drawing.Size(370, 234);
            this.PanelPOSController.TabIndex = 0;
            // 
            // POSControllerSplitContainer
            // 
            this.POSControllerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.POSControllerSplitContainer.Name = "POSControllerSplitContainer";
            // 
            // POSControllerSplitContainer.Panel2
            // 
            this.POSControllerSplitContainer.Panel2.Controls.Add(this.PanelPOSController);
            this.POSControllerSplitContainer.Size = new System.Drawing.Size(603, 234);
            this.POSControllerSplitContainer.SplitterDistance = 229;
            this.POSControllerSplitContainer.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 208);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 15);
            this.label15.TabIndex = 5;
            this.label15.Text = "Cash out";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(23, 232);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(217, 23);
            this.numericUpDown4.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.numericUpDown4);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.numericUpDown5);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.numericUpDown6);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(413, 364);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cash Register Current value";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 132);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 15);
            this.label16.TabIndex = 3;
            this.label16.Text = "Total sales today";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(23, 157);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(217, 23);
            this.numericUpDown5.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(158, 15);
            this.label17.TabIndex = 1;
            this.label17.Text = "Previous day remaining cash";
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.Location = new System.Drawing.Point(23, 78);
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(217, 23);
            this.numericUpDown6.TabIndex = 0;
            // 
            // TboxCurrentNumberOfTables
            // 
            this.TboxCurrentNumberOfTables.Location = new System.Drawing.Point(164, 13);
            this.TboxCurrentNumberOfTables.Name = "TboxCurrentNumberOfTables";
            this.TboxCurrentNumberOfTables.Size = new System.Drawing.Size(120, 29);
            this.TboxCurrentNumberOfTables.TabIndex = 65;
            // 
            // FrmMainPOSTerminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 672);
            this.Controls.Add(this.POSMainTabControl);
            this.Name = "FrmMainPOSTerminal";
            this.Text = "Point of sale terminal";
            this.Load += new System.EventHandler(this.FrmMainPOSTerminal_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.LeftSideSplitInnerContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftSideSplitInnerContainer)).EndInit();
            this.LeftSideSplitInnerContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVCartItems)).EndInit();
            this.TopPanelInSplitContainerPanel1.ResumeLayout(false);
            this.TopPanelInSplitContainerPanel1.PerformLayout();
            this.TabControlProductsAndComboMeals.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.RightSideSplitInnerContainer.Panel1.ResumeLayout(false);
            this.RightSideSplitInnerContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RightSideSplitInnerContainer)).EndInit();
            this.RightSideSplitInnerContainer.ResumeLayout(false);
            this.TopPanelInSplitContainerPanel2.ResumeLayout(false);
            this.TopPanelInSplitContainerPanel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.POSMainTabControl.ResumeLayout(false);
            this.TabPageStore.ResumeLayout(false);
            this.TabPageTableStatus.ResumeLayout(false);
            this.PanelDineInOrdersTableStatus.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.TabPageSalesHistory.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TabProductOrderQty.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.TabPageIngredientsBreakdown.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.TabPageCashRegister.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCashRegisterTransactions)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnTotalCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnRemCash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnCashOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnTotalSalesToday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDwnPrevDayRemCash)).EndInit();
            this.POSControllerSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.POSControllerSplitContainer)).EndInit();
            this.POSControllerSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TboxCurrentNumberOfTables)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.Panel TopPanelInSplitContainerPanel1;
        private System.Windows.Forms.Panel TopPanelInSplitContainerPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer LeftSideSplitInnerContainer;
        private System.Windows.Forms.SplitContainer RightSideSplitInnerContainer;
        private System.Windows.Forms.DataGridView DGVCartItems;
        private System.Windows.Forms.FlowLayoutPanel FLPanelProductList;
        private System.Windows.Forms.FlowLayoutPanel FLPanelProductCategories;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TbxSearchProducts;
        private System.Windows.Forms.TabControl POSMainTabControl;
        private System.Windows.Forms.TabPage TabPageStore;
        private System.Windows.Forms.TabPage TabPageTableStatus;
        private System.Windows.Forms.TabPage TabPageSalesHistory;
        private System.Windows.Forms.Panel PanelDineInOrdersTableStatus;
        private System.Windows.Forms.TabControl TabControlProductsAndComboMeals;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TboxSearchComboMeals;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutComboMealItems;
        private System.Windows.Forms.ListView LVComboMealProducts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button BtnRefreshProductList;
        private System.Windows.Forms.Label LblCurrentProductCategory;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnRefreshComboMealItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutTables;
        private System.Windows.Forms.Panel PanelPOSController;
        private System.Windows.Forms.SplitContainer POSControllerSplitContainer;
        private System.Windows.Forms.ListView LVTransactionHistory;
        private System.Windows.Forms.TabPage TabPageCashRegister;
        private System.Windows.Forms.ColumnHeader TicketNumber;
        private System.Windows.Forms.ColumnHeader CustomerName;
        private System.Windows.Forms.ColumnHeader SubTotal;
        private System.Windows.Forms.ColumnHeader Discount;
        private System.Windows.Forms.ColumnHeader Percentage;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader CashierName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblTotalSales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnFilterSaleHistory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DPickerEndDateForSalesHistory;
        private System.Windows.Forms.DateTimePicker DPickerStartDateForSalesHistory;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown NumUpDwnPrevDayRemCash;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown NumUpDwnCashOut;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown NumUpDwnTotalSalesToday;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown NumUpDwnRemCash;
        private System.Windows.Forms.Button BtnSaveCashRegisterTransaction;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BtnCancelUpdateCashRegisterTrans;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown NumUpDwnTotalCash;
        private System.Windows.Forms.DataGridView DGVCashRegisterTransactions;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage TabProductOrderQty;
        private System.Windows.Forms.TabPage TabPageIngredientsBreakdown;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BtnFilterProductOrderReport;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker DPicEndDateFilterProductOrdersReport;
        private System.Windows.Forms.DateTimePicker DPicStartDateFilterProductOrdersReport;
        private System.Windows.Forms.ListView LVProductAndComboMealOrders;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ListView LVIngredientBreakdown;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BtnFilterIngredientBreakdownReport;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DateTimePicker DPicEndDateIngBreakdownReport;
        private System.Windows.Forms.DateTimePicker DPicStartDateIngBreakdownReport;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.ColumnHeader Ingredient;
        private System.Windows.Forms.ColumnHeader RemainingQtyValue;
        private System.Windows.Forms.ColumnHeader ConsumeQtyValue;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnNumberOfTables;
        private System.Windows.Forms.NumericUpDown TboxCurrentNumberOfTables;
    }
}