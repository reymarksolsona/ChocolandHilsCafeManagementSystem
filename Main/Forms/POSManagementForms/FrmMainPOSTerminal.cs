using DataAccess.Data.InventoryManagement.Contracts;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared;
using EntitiesShared.InventoryManagement;
using EntitiesShared.InventoryManagement.Models;
using EntitiesShared.POSManagement;
using EntitiesShared.POSManagement.CustomModels;
using Main.Controllers.InventoryControllers;
using Main.Controllers.POSControllers.ControllerInterface;
using Main.Forms.POSManagementForms.Controls;
using Microsoft.Extensions.Options;
using Shared;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms
{
    public partial class FrmMainPOSTerminal : Form
    {
        private readonly IProductData _productData;
        private readonly IComboMealData _comboMealData;
        private readonly IProductCategoryData _productCategoryData;
        private readonly IPOSCommandController _iPOSCommandController;
        private readonly IPOSReadController _pOSReadController;
        private readonly IIngredientData _ingredientData;
        private readonly IComboMealProductData _comboMealProductData;
        private readonly POSState _pOSState;
        private readonly UOMConverter _uOMConverter;
        private readonly IStoreTableData _storeTableData;
        private readonly IIngredientInventoryManager _ingredientInventoryManager;
        private readonly IProductIngredientData _productIngredientData;
        private readonly Sessions _sessions;
        private readonly OtherSettings _otherSettings;

        public FrmMainPOSTerminal(IProductData productData,
                                IComboMealData comboMealData,
                                IProductCategoryData productCategoryData,
                                IPOSCommandController iPOSCommandController,
                                IPOSReadController pOSReadController,
                                IIngredientData ingredientData,
                                IComboMealProductData comboMealProductData,
                                POSState pOSState,
                                UOMConverter uOMConverter,
                                IOptions<OtherSettings> otherSettings,
                                IStoreTableData storeTableData,
                                IIngredientInventoryManager ingredientInventoryManager,
                                IProductIngredientData productIngredientData,
                                Sessions sessions)
        {
            InitializeComponent();
            _productData = productData;
            _comboMealData = comboMealData;
            _productCategoryData = productCategoryData;
            _iPOSCommandController = iPOSCommandController;
            _pOSReadController = pOSReadController;
            _ingredientData = ingredientData;
            _comboMealProductData = comboMealProductData;
            _pOSState = pOSState;
            _uOMConverter = uOMConverter;
            _storeTableData = storeTableData;
            _ingredientInventoryManager = ingredientInventoryManager;
            _productIngredientData = productIngredientData;
            _sessions = sessions;
            _otherSettings = otherSettings.Value;
        }

        private List<ProductModel> _products;

        public List<ProductModel> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        private List<ProductCategoryModel> _productCategories;

        public List<ProductCategoryModel> ProductCategories
        {
            get { return _productCategories; }
            set { _productCategories = value; }
        }


        private List<ComboMealModel> _comboMeals;

        public List<ComboMealModel> ComboMeals
        {
            get { return _comboMeals; }
            set { _comboMeals = value; }
        }


        private List<TableStatusModel> _tableStatuses;

        public List<TableStatusModel> TableStatus
        {
            get { return _tableStatuses; }
            set { _tableStatuses = value; }
        }


        POSControllerControl pOSControllerControl;

        private void FrmMainPOSTerminal_Load(object sender, EventArgs e)
        {
            SetDGVCartItemsFontAndColors();
            SetDGVCashRegisterTransactionsFontAndColors();

            this.Products = _productData.GetAllNotDeleted();
            this.ProductCategories = _productCategoryData.GetAllNotDeleted();
            this.ComboMeals = _comboMealData.GetAllNotDeleted();
            //this.TableStatus = _pOSReadController.GetTableStatus();

            DisplayProductList(this.Products);
            DisplayProductCategoryList(this.ProductCategories);
            DisplayComboMealList(this.ComboMeals);

            this.LblCurrentProductCategory.Text = "ALL";

            // initialize controls
            InitializePOSControllerControl();

            _pOSState.PropertyChanged += TestingHandlingPOSStateChange;



            var currentTables = _storeTableData.GetTheLastTransaction();
            this.TboxCurrentNumberOfTables.Text = currentTables == null ? "20" : currentTables.NumberOfTables.ToString();
        }

        public void TestingHandlingPOSStateChange(object sender, PropertyChangedEventArgs e)
        {
            DisplayCurrentSaleTransactionProductsInCartDGV();
        }

        public void InitializePOSControllerControl()
        {
            this.LeftSideSplitInnerContainer.Panel2.Controls.Clear();
            this.pOSControllerControl = new(_iPOSCommandController, _pOSReadController, _pOSState, _otherSettings, _sessions);
            //pOSControllerControl.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            this.pOSControllerControl.Dock = DockStyle.Fill;

            this.LeftSideSplitInnerContainer.Panel2.Controls.Add(this.pOSControllerControl);
        }

        public void DisplayProductList(List<ProductModel> products)
        {
            FLPanelProductList.Controls.Clear();
            if (products != null)
            {
                foreach (var prod in products)
                {
                    var prodItemControl = new ProductItemControl(prod, _otherSettings);
                    prodItemControl.ClickThisProduct += HandleClickProductItem;
                    FLPanelProductList.Controls.Add(prodItemControl);
                }
            }
        }


        private void BtnRefreshProductList_Click(object sender, EventArgs e)
        {
            this.LblCurrentProductCategory.Text = "ALL";
            this.TbxSearchProducts.Text = "";
            DisplayProductList(this.Products);
        }


        private void TbxSearchProducts_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.Products != null && string.IsNullOrWhiteSpace(TbxSearchProducts.Text) == false)
                {
                    var searchResults = this.Products.Where(x =>
                                                x.ProdName
                                                .ToLower()
                                                .Contains(TbxSearchProducts.Text.ToLower())
                                               ).ToList();

                    DisplayProductList(searchResults);
                }
            }
        }

        private void HandleClickProductItem(object sender, EventArgs e)
        {
            if (_pOSState.CurrentSaleTransaction == null)
            {
                MessageBox.Show("Kindly initiate or select existing transaction to add item in the cart.", "Add item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ProductItemControl productItemControl = (ProductItemControl)sender;

            if (productItemControl != null && productItemControl.Product != null)
            {
                var existingProdInCart = _pOSState.CurrentSaleTransactionProducts
                                                    .Where(x => x.ProductId == productItemControl.Product.Id)
                                                    .FirstOrDefault();

                int existingQty = existingProdInCart != null ? existingProdInCart.Qty : 1;

                var productIngredients = _productIngredientData.GetAllByProduct(productItemControl.Product.Id);

                FrmEnterProductQuantity frmEnterProductQuantity = new(productItemControl.Product, 
                                                                    _otherSettings, 
                                                                    _ingredientInventoryManager,
                                                                    productIngredients, existingQty);

                frmEnterProductQuantity.ShowDialog();

                if (frmEnterProductQuantity.IsCancelled == false && frmEnterProductQuantity.Product != null)
                {
                    if (frmEnterProductQuantity.Quantity <= 0)
                    {
                        return;
                    }


                    if (existingProdInCart == null)
                    {
                        var newProductObjRef = JsonSerializer.Deserialize<ProductModel>(JsonSerializer.Serialize(frmEnterProductQuantity.Product));

                        _pOSState.CurrentSaleTransactionProducts.Add(new SaleTransactionProductModel
                        {
                            ProductId = newProductObjRef.Id,
                            Qty = frmEnterProductQuantity.Quantity,
                            productCurrentPrice = newProductObjRef.PricePerOrder,
                            Product = newProductObjRef,
                            totalAmount = (frmEnterProductQuantity.Quantity * newProductObjRef.PricePerOrder)
                        });
                    }
                    else
                    {
                        existingProdInCart.Qty = frmEnterProductQuantity.Quantity;
                        existingProdInCart.totalAmount = (existingProdInCart.Qty * existingProdInCart.productCurrentPrice);
                    }


                    DisplayCurrentSaleTransactionProductsInCartDGV();

                    //MessageBox.Show(.ToString());
                }
            }
        }

        public void DisplayProductCategoryList(List<ProductCategoryModel> categories)
        {
            FLPanelProductCategories.Controls.Clear();
            if (categories != null)
            {
                foreach(var category in categories)
                {
                    var btnCategoryControl = new BtnProductCategoryControl(category);
                    btnCategoryControl.ClickThisCategoryButton += HandleClickProductCategoryItem;
                    FLPanelProductCategories.Controls.Add(btnCategoryControl);
                }
            }
        }


        private void HandleClickProductCategoryItem(object sender, EventArgs e)
        {
            BtnProductCategoryControl btnProductCategoryControl = (BtnProductCategoryControl)sender;

            if (btnProductCategoryControl != null && btnProductCategoryControl.ProductCategory != null)
            {
                long selectedCategoryId = btnProductCategoryControl.ProductCategory.Id;

                this.LblCurrentProductCategory.Text = btnProductCategoryControl.ProductCategory.ProdCategory;

                var products = this.Products.Where(x => x.CategoryId == selectedCategoryId).ToList();
                DisplayProductList(products);
            }
        }



        public void DisplayComboMealList(List<ComboMealModel> comboMeals)
        {
            this.FlowLayoutComboMealItems.Controls.Clear();
            if (comboMeals != null)
            {
                foreach(var meal in comboMeals)
                {
                    var comboMealItemControl = new ComboMealItemControl(meal, _otherSettings);
                    comboMealItemControl.ClickThisComboMeal += HandleClickComboMealItem;
                    comboMealItemControl.ClickThisComboMeal += DisplayFormToEnterQuantityAndAddInCartComboMeal;
                    this.FlowLayoutComboMealItems.Controls.Add(comboMealItemControl);
                }
            }
        }

        public void DisplayFormToEnterQuantityAndAddInCartComboMeal(object sender, EventArgs e)
        {
            if (_pOSState.CurrentSaleTransaction == null)
            {
                MessageBox.Show("Kindly initiate or select existing transaction to add item in the cart.", "Add item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ComboMealItemControl comboMealItemObj = (ComboMealItemControl)sender;

            if (comboMealItemObj != null && comboMealItemObj.ComboMeal != null)
            {
                var existingComboMealInCart = _pOSState.CurrentSaleTransactionComboMeals
                                                .Where(x => x.ComboMealId == comboMealItemObj.ComboMeal.Id)
                                                .FirstOrDefault();

                int existingQty = existingComboMealInCart != null ? existingComboMealInCart.Qty : 1;

                var comboMealProducts = _comboMealProductData.GetAllByComboMeal(comboMealItemObj.ComboMeal.Id);

                List<ProductIngredientModel> productIngredients = new List<ProductIngredientModel>();

                if (comboMealProducts != null)
                {
                    foreach(var prod in comboMealProducts)
                    {
                        var ingredients = _productIngredientData.GetAllByProduct(prod.ProductId);
                        productIngredients.AddRange(ingredients);
                    }
                }

                FrmEnterComboMealQuantity frmEnterComboMealQuantity = new(comboMealItemObj.ComboMeal, 
                                                                            _otherSettings,
                                                                            _ingredientInventoryManager, productIngredients, existingQty);
                frmEnterComboMealQuantity.ShowDialog();
                
                if(frmEnterComboMealQuantity.IsCancelled == false && frmEnterComboMealQuantity.ComboMeal != null)
                {
                    if (existingComboMealInCart == null)
                    {
                        var newComboMealObjRef = JsonSerializer.Deserialize<ComboMealModel>(JsonSerializer.Serialize(frmEnterComboMealQuantity.ComboMeal));

                        _pOSState.CurrentSaleTransactionComboMeals.Add(new SaleTransactionComboMealModel { 
                            ComboMealId = newComboMealObjRef.Id,
                            Qty = frmEnterComboMealQuantity.Quantity,
                            ComboMealCurrentPrice = newComboMealObjRef.Price,
                            ComboMeal = newComboMealObjRef,
                            totalAmount = (frmEnterComboMealQuantity.Quantity * newComboMealObjRef.Price)
                        });
                    }
                    else
                    {
                        existingComboMealInCart.Qty += frmEnterComboMealQuantity.Quantity;
                        existingComboMealInCart.totalAmount = (existingComboMealInCart.Qty * existingComboMealInCart.ComboMealCurrentPrice);
                    }



                    DisplayCurrentSaleTransactionProductsInCartDGV();
                }
            }
        }


        private void HandleClickComboMealItem(object sender, EventArgs e)
        {
            ComboMealItemControl comboMealItemObj = (ComboMealItemControl)sender;

            if (comboMealItemObj != null && comboMealItemObj.ComboMeal != null)
            {
                long selectedComboMealId = comboMealItemObj.ComboMeal.Id;

                DisplayComboMealProducts(comboMealItemObj.ComboMeal);
            }
        }


        private void DisplayComboMealProducts (ComboMealModel comboMealItem)
        {
            this.LVComboMealProducts.Items.Clear();
            if (comboMealItem.Products != null)
            {
                foreach (var prod in comboMealItem.Products)
                {
                    string[] item = new string[] { prod.Product.ProdName, prod.Product.PricePerOrder.ToString("0.##") };

                    var listViewItem = new ListViewItem(item);
                    listViewItem.Tag = prod;

                    this.LVComboMealProducts.Items.Add(listViewItem);
                }
            }
        }


        private void BtnRefreshComboMealItems_Click(object sender, EventArgs e)
        {
            this.TboxSearchComboMeals.Text = "";
            this.LVComboMealProducts.Items.Clear();
            DisplayComboMealList(this.ComboMeals);
        }

        private void TboxSearchComboMeals_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter &&
                this.ComboMeals != null && 
                string.IsNullOrWhiteSpace(TboxSearchComboMeals.Text) == false)
            {
                var searchResults = this.ComboMeals.Where(x =>
                                                x.Title
                                                .ToLower()
                                                .Contains(TboxSearchComboMeals.Text.ToLower())
                                              ).ToList();

                this.LVComboMealProducts.Items.Clear();
                DisplayComboMealList(searchResults);
            }
        }

        private void SetDGVCartItemsFontAndColors()
        {
            this.DGVCartItems.BackgroundColor = Color.White;
            this.DGVCartItems.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            this.DGVCartItems.RowHeadersVisible = false;
            this.DGVCartItems.RowTemplate.Height = 35;
            this.DGVCartItems.RowTemplate.Resizable = DataGridViewTriState.True;
            this.DGVCartItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVCartItems.AllowUserToResizeRows = false;
            this.DGVCartItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCartItems.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            this.DGVCartItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVCartItems.MultiSelect = false;
        }


        public void DisplayCurrentSaleTransactionProductsInCartDGV()
        {
            this.pOSControllerControl.DisplayCurrentSaleTransactionSubTotal();

            List<SaleTransactionProductModel> products = _pOSState.CurrentSaleTransactionProducts;
            List<SaleTransactionComboMealModel> comboMeals = _pOSState.CurrentSaleTransactionComboMeals;

            this.DGVCartItems.Rows.Clear();
            this.DGVCartItems.ColumnCount = 6;

            this.DGVCartItems.Columns[0].Name = "ProductId";
            this.DGVCartItems.Columns[0].Visible = false;

            this.DGVCartItems.Columns[1].Name = "ProductType"; // Product or ComboMeal
            this.DGVCartItems.Columns[1].Visible = false;

            this.DGVCartItems.Columns[2].Name = "ItemName";
            this.DGVCartItems.Columns[2].HeaderText = "ItemName";
            this.DGVCartItems.Columns[2].Width = 260;

            this.DGVCartItems.Columns[3].Name = "Price";
            this.DGVCartItems.Columns[3].HeaderText = "Price";
            this.DGVCartItems.Columns[3].Width = 80;

            this.DGVCartItems.Columns[4].Name = "Quantity";
            this.DGVCartItems.Columns[4].HeaderText = "Qty";
            this.DGVCartItems.Columns[4].Width = 80;

            this.DGVCartItems.Columns[5].Name = "Total";
            this.DGVCartItems.Columns[5].HeaderText = "Total";
            this.DGVCartItems.Columns[5].Width = 80;

            DataGridViewButtonColumn btnIncreaseQty = new DataGridViewButtonColumn();
            btnIncreaseQty.HeaderText = "Inc";
            btnIncreaseQty.Text = "+";
            btnIncreaseQty.Name = "btnIncreaseQty";
            btnIncreaseQty.UseColumnTextForButtonValue = true;
            btnIncreaseQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnIncreaseQty.FlatStyle = FlatStyle.Flat;
            btnIncreaseQty.CellTemplate.Style.BackColor = Color.FromArgb(71, 125, 78);
            btnIncreaseQty.CellTemplate.Style.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            this.DGVCartItems.Columns.Add(btnIncreaseQty);

            DataGridViewButtonColumn btnDecreaseQty = new DataGridViewButtonColumn();
            btnDecreaseQty.HeaderText = "Dec";
            btnDecreaseQty.Text = "-";
            btnDecreaseQty.Name = "btnDecreaseQty";
            btnDecreaseQty.UseColumnTextForButtonValue = true;
            btnDecreaseQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnDecreaseQty.FlatStyle = FlatStyle.Flat;
            btnDecreaseQty.CellTemplate.Style.BackColor = Color.FromArgb(125, 112, 71);
            btnDecreaseQty.CellTemplate.Style.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            this.DGVCartItems.Columns.Add(btnDecreaseQty);

            DataGridViewButtonColumn btnRemoveItem = new DataGridViewButtonColumn();
            btnRemoveItem.HeaderText = "Rem";
            btnRemoveItem.Text = "x";
            btnRemoveItem.Name = "btnRemvoeItem";
            btnRemoveItem.UseColumnTextForButtonValue = true;
            btnRemoveItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnRemoveItem.FlatStyle = FlatStyle.Flat;
            btnRemoveItem.CellTemplate.Style.BackColor = Color.FromArgb(145, 82, 48);
            btnRemoveItem.CellTemplate.Style.Font = new Font("Century Gothic", 14, FontStyle.Bold);
            this.DGVCartItems.Columns.Add(btnRemoveItem);

            if (products != null)
            {
                foreach (var item in products)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVCartItems);
                    row.Height = 35;

                    row.Cells[0].Value = item.ProductId;
                    row.Cells[1].Value = "PROD";
                    row.Cells[2].Value = item.Product.ProdName;
                    row.Cells[3].Value = item.productCurrentPrice;
                    row.Cells[4].Value = item.Qty;
                    row.Cells[5].Value = item.totalAmount;

                    DGVCartItems.Rows.Add(row);
                }
            }

            if (comboMeals != null)
            {
                foreach (var item in comboMeals)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVCartItems);
                    row.Height = 35;

                    row.Cells[0].Value = item.ComboMealId;
                    row.Cells[1].Value = "COMBO";
                    row.Cells[2].Value = item.ComboMeal.Title;
                    row.Cells[3].Value = item.ComboMealCurrentPrice;
                    row.Cells[4].Value = item.Qty;
                    row.Cells[5].Value = item.totalAmount;

                    DGVCartItems.Rows.Add(row);
                }
            }

            DGVCartItems.ClearSelection();
        }

        private void POSMainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tables tab
            if (POSMainTabControl.SelectedTab == POSMainTabControl.TabPages[1])
            {
                this.TableStatus = _pOSReadController.GetTableStatus();
                DisplayTableStatus(this.TableStatus);
            }


            if (POSMainTabControl.SelectedTab == POSMainTabControl.TabPages[2])
            {
                var salesTransactionToday = _pOSReadController.GetByDate(DateTime.Now, StaticData.POSTransactionStatus.Paid);
                this.DisplaySalesHistory(salesTransactionToday);
            }

            if (POSMainTabControl.SelectedTab == POSMainTabControl.TabPages[3])
            {
                DateTime dateTimeNow = DateTime.Now;
                var productOrdersReport = _pOSReadController.GetProductOrdersReportByDateRangeAndTransStatus(StaticData.POSTransactionStatus.Paid, dateTimeNow, dateTimeNow);
                var comboMealOrdersReport = _pOSReadController.GetComboMealOrdersReportByDateRangeAndTransStatus(StaticData.POSTransactionStatus.Paid, dateTimeNow, dateTimeNow);

                this.DisplayProductsAndComboMealsOrdersReport(productOrdersReport, comboMealOrdersReport);
            }

            if (POSMainTabControl.SelectedTab == POSMainTabControl.TabPages[4])
            {
                DateTime dateTimeNow = DateTime.Now;
                var ingredientBreakDownForSales = _ingredientData.GetBreakDownForSalesReport(StaticData.POSTransactionStatus.Paid, dateTimeNow, dateTimeNow);

                this.DisplayIngredientBreakdown(ingredientBreakDownForSales);
            }

            if (POSMainTabControl.SelectedTab == POSMainTabControl.TabPages[5])
            {
                GetCashRegisterRemainingCashOnPrevDayAndTotalSales();
                DisplayOneMonthCashRegisterTransactions();
            }
        }

        public void DisplayTableStatus(List<TableStatusModel> tableStatus)
        {
            this.FlowLayoutTables.Controls.Clear();
            foreach (var table in tableStatus)
            {
                var tableItemControl = new RestaurantTableItemControl()
                {
                    IsOccupied = table.Status == StaticData.TableStatus.Occupied,
                    TableNumber = table.TableNumber,
                    TableTitle = table.TableTitle
                };

                tableItemControl.MarkThisTableAsAvailable += HandleMarkTableAsAvailable;

                this.FlowLayoutTables.Controls.Add(tableItemControl);
            }
        }

        private void HandleMarkTableAsAvailable(object sender, EventArgs e)
        {
            RestaurantTableItemControl tableObj = (RestaurantTableItemControl)sender;

            if (tableObj != null && tableObj.TableNumber > 0)
            {
                var markTableAsAvailableResults = _iPOSCommandController.MarkTableAsAvailable(tableObj.TableNumber);

                string resMsg = "";
                foreach (var msg in markTableAsAvailableResults.Messages)
                {
                    resMsg += msg;
                }

                if (markTableAsAvailableResults.IsSuccess)
                {
                    MessageBox.Show(resMsg, "Mark table as available", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.TableStatus = _pOSReadController.GetTableStatus();
                    DisplayTableStatus(this.TableStatus);
                }
                else
                {
                    MessageBox.Show(resMsg, "Mark table as available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DGVCartItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // increase quantity
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                if (DGVCartItems.CurrentRow != null && _pOSState.CurrentSaleTransaction != null)
                {
                    string prodType = DGVCartItems.CurrentRow.Cells["ProductType"].Value.ToString();
                    

                    if (_pOSState.CurrentSaleTransactionProducts != null && _pOSState.CurrentSaleTransactionProducts.Count > 0 
                            && prodType == "PROD")
                    {
                        long productId = long.Parse(DGVCartItems.CurrentRow.Cells["ProductId"].Value.ToString());

                        var existingProductInCart = _pOSState.CurrentSaleTransactionProducts
                                                        .Where(x => x.ProductId == productId).FirstOrDefault();

                        if (existingProductInCart != null)
                        {
                            existingProductInCart.Qty += 1;
                            existingProductInCart.totalAmount = (existingProductInCart.Qty * existingProductInCart.productCurrentPrice);
                            DisplayCurrentSaleTransactionProductsInCartDGV();
                        }
                    }

                    if (_pOSState.CurrentSaleTransactionComboMeals != null && _pOSState.CurrentSaleTransactionComboMeals.Count > 0 
                            && prodType == "COMBO")
                    {
                        long comboMealId = long.Parse(DGVCartItems.CurrentRow.Cells["ProductId"].Value.ToString());

                        var existingComboMealInCart = _pOSState.CurrentSaleTransactionComboMeals
                                                        .Where(x => x.ComboMealId == comboMealId).FirstOrDefault();

                        if (existingComboMealInCart != null)
                        {
                            existingComboMealInCart.Qty += 1;
                            existingComboMealInCart.totalAmount = (existingComboMealInCart.Qty * existingComboMealInCart.ComboMealCurrentPrice);
                            DisplayCurrentSaleTransactionProductsInCartDGV();
                        }
                    }
                }
            }

            // decrase quantity
            if ((e.ColumnIndex == 7) && e.RowIndex > -1)
            {
                if (DGVCartItems.CurrentRow != null && _pOSState.CurrentSaleTransaction != null)
                {
                    string prodType = DGVCartItems.CurrentRow.Cells["ProductType"].Value.ToString();


                    if (_pOSState.CurrentSaleTransactionProducts != null && _pOSState.CurrentSaleTransactionProducts.Count > 0
                            && prodType == "PROD")
                    {
                        long productId = long.Parse(DGVCartItems.CurrentRow.Cells["ProductId"].Value.ToString());

                        var existingProductInCart = _pOSState.CurrentSaleTransactionProducts
                                                        .Where(x => x.ProductId == productId).FirstOrDefault();

                        if (existingProductInCart != null)
                        {
                            if (existingProductInCart.Qty <= 1)
                            {
                                DialogResult dialogResult = MessageBox.Show($"Continue to remove {existingProductInCart.Product.ProdName}?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (dialogResult == DialogResult.Yes)
                                {
                                    _pOSState.CurrentSaleTransactionProducts.Remove(existingProductInCart);
                                }
                                   
                            }
                            else
                            {
                                existingProductInCart.Qty -= 1;
                                existingProductInCart.totalAmount = (existingProductInCart.Qty * existingProductInCart.productCurrentPrice);
                            }
                            DisplayCurrentSaleTransactionProductsInCartDGV();
                        }
                    }

                    if (_pOSState.CurrentSaleTransactionComboMeals != null && _pOSState.CurrentSaleTransactionComboMeals.Count > 0
                            && prodType == "COMBO")
                    {
                        long comboMealId = long.Parse(DGVCartItems.CurrentRow.Cells["ProductId"].Value.ToString());

                        var existingComboMealInCart = _pOSState.CurrentSaleTransactionComboMeals
                                                        .Where(x => x.ComboMealId == comboMealId).FirstOrDefault();

                        if (existingComboMealInCart != null)
                        {
                            if (existingComboMealInCart.Qty <= 1)
                            {
                                DialogResult dialogResult = MessageBox.Show($"Continue to remove {existingComboMealInCart.ComboMeal.Title}?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (dialogResult == DialogResult.Yes)
                                {
                                    _pOSState.CurrentSaleTransactionComboMeals.Remove(existingComboMealInCart);
                                }
                            }
                            else
                            {
                                existingComboMealInCart.Qty -= 1;
                                existingComboMealInCart.totalAmount = (existingComboMealInCart.Qty * existingComboMealInCart.ComboMealCurrentPrice);
                            }
                            DisplayCurrentSaleTransactionProductsInCartDGV();
                        }
                    }
                }
            }

            // remove item
            if ((e.ColumnIndex == 8) && e.RowIndex > -1)
            {
                if (DGVCartItems.CurrentRow != null && _pOSState.CurrentSaleTransaction != null)
                {
                    string prodType = DGVCartItems.CurrentRow.Cells["ProductType"].Value.ToString();

                    if (_pOSState.CurrentSaleTransactionProducts != null && _pOSState.CurrentSaleTransactionProducts.Count > 0
                            && prodType == "PROD")
                    {
                        long productId = long.Parse(DGVCartItems.CurrentRow.Cells["ProductId"].Value.ToString());

                        var existingProductInCart = _pOSState.CurrentSaleTransactionProducts
                                                        .Where(x => x.ProductId == productId).FirstOrDefault();

                        if (existingProductInCart != null)
                        {
                            DialogResult dialogResult = MessageBox.Show($"Continue to remove {existingProductInCart.Product.ProdName}?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dialogResult == DialogResult.Yes)
                            {
                                _pOSState.CurrentSaleTransactionProducts.Remove(existingProductInCart);
                                DisplayCurrentSaleTransactionProductsInCartDGV();
                            }

                        }
                    }

                    if (_pOSState.CurrentSaleTransactionComboMeals != null && _pOSState.CurrentSaleTransactionComboMeals.Count > 0
                            && prodType == "COMBO")
                    {
                        long comboMealId = long.Parse(DGVCartItems.CurrentRow.Cells["ProductId"].Value.ToString());

                        var existingComboMealInCart = _pOSState.CurrentSaleTransactionComboMeals
                                                        .Where(x => x.ComboMealId == comboMealId).FirstOrDefault();

                        if (existingComboMealInCart != null)
                        {
                            DialogResult dialogResult = MessageBox.Show($"Continue to remove {existingComboMealInCart.ComboMeal.Title}?", "Remove item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (dialogResult == DialogResult.Yes)
                            {
                                _pOSState.CurrentSaleTransactionComboMeals.Remove(existingComboMealInCart);
                                DisplayCurrentSaleTransactionProductsInCartDGV();
                            }

                        }
                    }
                }
            }

        }


        private void DisplaySalesHistory(List<SaleTransactionModel> saleTransactions)
        {
            this.LVTransactionHistory.Items.Clear();

            decimal totalSales = 0;
            if (saleTransactions != null)
            {
                foreach(var tran in saleTransactions)
                {
                    var row = new string[]
                    {
                        tran.TicketNumber,
                        tran.CustomerName,
                        tran.SubTotalAmount.ToString("0.##"),
                        tran.DiscountAmount.ToString("0.##"),
                        tran.DiscountPercent.ToString("0.##"),
                        tran.TotalAmount.ToString("0.##"),
                        tran.TransStatus.ToString(),
                        tran.CurrentUser,
                        tran.CreatedAt.ToShortDateString()
                    };

                    totalSales += tran.TotalAmount;

                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = tran;

                    this.LVTransactionHistory.Items.Add(listViewItem);
                }
            }

            this.LblTotalSales.Text = totalSales.ToString("0.##");
        }

        private void BtnFilterSaleHistory_Click(object sender, EventArgs e)
        {
            DateTime startDate = this.DPickerStartDateForSalesHistory.Value;
            DateTime endDate = this.DPickerEndDateForSalesHistory.Value;

            var searchResultsSalesTrans = _pOSReadController.GetByDateRange(startDate, endDate, StaticData.POSTransactionStatus.Paid);
            this.DisplaySalesHistory(searchResultsSalesTrans);
        }


        private void BtnFilterProductOrderReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = this.DPicStartDateFilterProductOrdersReport.Value;
            DateTime endDate = this.DPicEndDateFilterProductOrdersReport.Value;

            var productOrdersReport = _pOSReadController.GetProductOrdersReportByDateRangeAndTransStatus(StaticData.POSTransactionStatus.Paid, startDate, endDate);
            var comboMealOrdersReport = _pOSReadController.GetComboMealOrdersReportByDateRangeAndTransStatus(StaticData.POSTransactionStatus.Paid, startDate, endDate);

            this.DisplayProductsAndComboMealsOrdersReport(productOrdersReport, comboMealOrdersReport);
        }

        private void DisplayProductsAndComboMealsOrdersReport(IEnumerable<ProductOrdersReport>  productOrders, IEnumerable<ComboMealOrdersReport> comboMealOrders)
        {
            this.LVProductAndComboMealOrders.Items.Clear();

            if (productOrders != null)
            {
                foreach (var report in productOrders)
                {
                    var row = new string[]
                    {
                        report.ProdCategory,
                        report.ProdName,
                        report.ProductCurrentPrice.ToString("#,##0.##"),
                        report.Qty.ToString(),
                        report.TotalSales.ToString("#,##0.##")
                    };

                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = report;

                    this.LVProductAndComboMealOrders.Items.Add(listViewItem);
                }
            }

            if (comboMealOrders != null)
            {
                foreach (var report in comboMealOrders)
                {
                    var row = new string[]
                    {
                        "Combo Meal",
                        report.Title,
                        report.ComboMealCurrentPrice.ToString("#,##0.##"),
                        report.Qty.ToString(),
                        report.TotalSales.ToString("#,##0.##")
                    };

                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = report;

                    this.LVProductAndComboMealOrders.Items.Add(listViewItem);
                }
            }
        }


        public string GetUOMFormatted(StaticData.UOM uom, decimal qtyValue)
        {
            string uomFormatted = "";

            switch (uom)
            {
                case StaticData.UOM.kg:
                    uomFormatted = _uOMConverter.gram_to_kg_format(qtyValue);
                    break;

                case StaticData.UOM.L:
                    uomFormatted = _uOMConverter.ml_to_L_format(qtyValue);
                    break;

                case StaticData.UOM.pcs:
                    uomFormatted = _uOMConverter.pc_format(qtyValue);
                    break;
                default:
                    uomFormatted = "0";
                    break;
            }

            return uomFormatted;
        }


        private void BtnFilterIngredientBreakdownReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = this.DPicStartDateIngBreakdownReport.Value;
            DateTime endDate = this.DPicEndDateIngBreakdownReport.Value;

            var ingredientBreakDownForSales = _ingredientData.GetBreakDownForSalesReport(StaticData.POSTransactionStatus.Paid, startDate, endDate);

            this.DisplayIngredientBreakdown(ingredientBreakDownForSales);
        }

        public void DisplayIngredientBreakdown(IEnumerable<IngredientBreakDownForSalesReportModel> ingredientBreakDownForSalesReports)
        {
            this.LVIngredientBreakdown.Items.Clear();

            if (ingredientBreakDownForSalesReports != null)
            {
                foreach(var report in ingredientBreakDownForSalesReports)
                {
                    var row = new string[]
                    {
                        report.Category,
                        report.IngName,
                        this.GetUOMFormatted(report.UOM, report.RemainingQtyValue),
                        this.GetUOMFormatted(report.UOM, report.TotalDeductedQtyValue)
                    };

                    var listViewItem = new ListViewItem(row);
                    listViewItem.Tag = report;

                    this.LVIngredientBreakdown.Items.Add(listViewItem);
                }
            }
        }



        public void GetCashRegisterRemainingCashOnPrevDayAndTotalSales()
        {
            var cashRegisterLastTrans = _pOSReadController.GetCashRegisterLastTransaction();
            decimal cashRegisterRemCashFrmPrevDay = cashRegisterLastTrans != null ? cashRegisterLastTrans.RemainingCash : 0;
            decimal totalSalesToday = _pOSReadController.GetTotalSalesByDate(DateTime.Now);

            this.NumUpDwnPrevDayRemCash.Value = cashRegisterRemCashFrmPrevDay;
            this.NumUpDwnTotalSalesToday.Value = totalSalesToday;

            this.NumUpDwnTotalCash.Value = cashRegisterRemCashFrmPrevDay + totalSalesToday;
        }


        private void NumUpDwnCashOut_KeyUp(object sender, KeyEventArgs e)
        {
            decimal cashOutValue = NumUpDwnCashOut.Value;
            decimal totalCashInRegister = this.NumUpDwnTotalCash.Value;
            
            if (cashOutValue > totalCashInRegister)
            {
                MessageBox.Show("Invalid cash out value", "Remaining Cash computation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal remainingCash = totalCashInRegister - cashOutValue;

            NumUpDwnRemCash.Value = remainingCash > 0 ? remainingCash : 0;
        }


        private CashRegisterCashOutTransactionModel _cashRegisterTransaction;

        public CashRegisterCashOutTransactionModel CashRegisterTransaction
        {
            get { return _cashRegisterTransaction; }
            set { _cashRegisterTransaction = value; }
        }


        public bool IsNewCashRegisterTransaction { get; set; } = true;

        private void BtnSaveCashRegisterTransaction_Click(object sender, EventArgs e)
        {
            decimal totalSales = _pOSReadController.GetTotalSalesByDate(DateTime.Now);
            decimal remainingCash = totalSales - NumUpDwnCashOut.Value;

            if (totalSales == 0 || NumUpDwnCashOut.Value == 0)
            {
                MessageBox.Show("Invalid transaction", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsNewCashRegisterTransaction == true)
            {
                CashRegisterTransaction = new CashRegisterCashOutTransactionModel {
                    TotalSales = totalSales,
                    CashOut = NumUpDwnCashOut.Value,
                    RemainingCash = remainingCash > 0 ? remainingCash : 0
                };
            }

            if (IsNewCashRegisterTransaction == false && CashRegisterTransaction == null)
            {
                MessageBox.Show("Cash out object is null, invalid request", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsNewCashRegisterTransaction == false && CashRegisterTransaction != null)
            {
                CashRegisterTransaction.TotalSales = totalSales;
                CashRegisterTransaction.CashOut = NumUpDwnCashOut.Value;
                CashRegisterTransaction.RemainingCash = remainingCash > 0 ? remainingCash : 0;
            }

            var saveResults = _iPOSCommandController.SaveCashRegisterCashOutTransaction(CashRegisterTransaction, IsNewCashRegisterTransaction);

            string resMsg = "";
            foreach (var msg in saveResults.Messages)
            {
                resMsg += msg;
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resMsg, "Save cash register transaction", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetCashRegisterRemainingCashOnPrevDayAndTotalSales();
                NumUpDwnTotalCash.Value = 0;
                NumUpDwnCashOut.Value = 0;
                NumUpDwnRemCash.Value = 0;
            }
            else
            {
                MessageBox.Show(resMsg, "Save cash register transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetDGVCashRegisterTransactionsFontAndColors()
        {
            this.DGVCashRegisterTransactions.BackgroundColor = Color.White;
            this.DGVCashRegisterTransactions.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVCashRegisterTransactions.RowHeadersVisible = false;
            this.DGVCashRegisterTransactions.RowTemplate.Height = 35;
            this.DGVCashRegisterTransactions.RowTemplate.Resizable = DataGridViewTriState.True;
            this.DGVCashRegisterTransactions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVCashRegisterTransactions.AllowUserToResizeRows = false;
            this.DGVCashRegisterTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCashRegisterTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVCashRegisterTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVCashRegisterTransactions.MultiSelect = false;
        }

        public void DisplayOneMonthCashRegisterTransactions()
        {
            var transactions = _pOSReadController.GetCashRegisterTransByDateRange(30, DateTime.Now);
            DisplayCashRegisterTranactions(transactions);
        }

        private List<CashRegisterCashOutTransactionModel> _cashRegisterCashOutTransactions;

        public List<CashRegisterCashOutTransactionModel> CashRegisterCashOutTransactions
        {
            get { return _cashRegisterCashOutTransactions; }
            set { _cashRegisterCashOutTransactions = value; }
        }


        public void DisplayCashRegisterTranactions(List<CashRegisterCashOutTransactionModel> transactions)
        {
            this.CashRegisterCashOutTransactions = transactions;
            this.DGVCashRegisterTransactions.Rows.Clear();

            if (transactions != null)
            {
                this.DGVCashRegisterTransactions.ColumnCount = 6;

                this.DGVCashRegisterTransactions.Columns[0].Name = "TrasactionId";
                this.DGVCashRegisterTransactions.Columns[0].Visible = false;

                this.DGVCashRegisterTransactions.Columns[1].Name = "Date";
                this.DGVCashRegisterTransactions.Columns[1].Visible = true;

                this.DGVCashRegisterTransactions.Columns[2].Name = "TotalSales";
                this.DGVCashRegisterTransactions.Columns[2].HeaderText = "Total Sales";

                this.DGVCashRegisterTransactions.Columns[3].Name = "CashOut";
                this.DGVCashRegisterTransactions.Columns[3].HeaderText = "Cash out";

                this.DGVCashRegisterTransactions.Columns[4].Name = "RemCash";
                this.DGVCashRegisterTransactions.Columns[4].HeaderText = "RemainingCash";

                this.DGVCashRegisterTransactions.Columns[5].Name = "CashOutUser";
                this.DGVCashRegisterTransactions.Columns[5].HeaderText = "User";

                //DataGridViewImageColumn btnEditImg = new DataGridViewImageColumn();
                //btnEditImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //btnEditImg.Image = Image.FromFile("./Resources/edit-24.png");
                //this.DGVCashRegisterTransactions.Columns.Add(btnEditImg);

                //DataGridViewImageColumn btnCancelImg = new DataGridViewImageColumn();
                //btnCancelImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //btnCancelImg.Image = Image.FromFile("./Resources/remove-24.png");
                //this.DGVCashRegisterTransactions.Columns.Add(btnCancelImg);

                foreach (var trans in transactions)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVCashRegisterTransactions);

                    row.Cells[0].Value = trans.Id;
                    row.Cells[1].Value = trans.CreatedAt.ToShortDateString();
                    row.Cells[2].Value = trans.TotalSales.ToString("0.##");
                    row.Cells[3].Value = trans.CashOut.ToString("0.##");
                    row.Cells[4].Value = trans.RemainingCash.ToString("0.##");
                    row.Cells[5].Value = trans.CurrentUser;

                    this.DGVCashRegisterTransactions.Rows.Add(row);
                }
            }
        }

        private void BtnNumberOfTables_Click(object sender, EventArgs e)
        {
            decimal newMaxTableNum = this.TboxCurrentNumberOfTables.Value;
            var saveResults = _iPOSCommandController.UpdateMaxTableNumber(newMaxTableNum);

            string msg = "";

            foreach(var tempMsg in saveResults.Messages)
            {
                msg += $"{tempMsg} \n";
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(msg, "Update number of tables", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.TableStatus = _pOSReadController.GetTableStatus();
                DisplayTableStatus(this.TableStatus);
            }
            else
            {
                MessageBox.Show(msg, "Update number of tables", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        //public void GetAndDisplayCashRegisterTrans(long transId)
        //{
        //    if (this.CashRegisterCashOutTransactions != null)
        //    {
        //        var transDetails = this.CashRegisterCashOutTransactions.Where(x => x.Id == transId).FirstOrDefault();

        //        if (transDetails == null)
        //        {
        //            MessageBox.Show("Transaction id is invalid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        if (transDetails.CreatedAt != DateTime.Now)
        //        {
        //            MessageBox.Show("Not allowed to update this transaction", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }


        //    }
        //}

        //private void DGVCashRegisterTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    // update
        //    if ((e.ColumnIndex == 6) && e.RowIndex == 0)
        //    {
        //        if (DGVCashRegisterTransactions.CurrentRow != null)
        //        {
        //            long transactionId = long.Parse(DGVCashRegisterTransactions.CurrentRow.Cells[0].Value.ToString());
        //        }
        //    }

        //    // update
        //    if ((e.ColumnIndex == 6) && e.RowIndex > 0)
        //    {
        //        MessageBox.Show("Not allowed to update", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    // Cancel
        //    if ((e.ColumnIndex == 7) && e.RowIndex == 0)
        //    {
        //        if (DGVCashRegisterTransactions.CurrentRow != null)
        //        {
        //            long transactionId = long.Parse(DGVCashRegisterTransactions.CurrentRow.Cells[0].Value.ToString());
        //        }
        //    }

        //    // Cancel
        //    if ((e.ColumnIndex == 7) && e.RowIndex > 0)
        //    {
        //        MessageBox.Show("Not allowed to cancel", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //}
    }
}
