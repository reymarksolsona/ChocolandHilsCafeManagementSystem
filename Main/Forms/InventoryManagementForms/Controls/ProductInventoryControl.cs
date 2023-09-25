using EntitiesShared;
using EntitiesShared.InventoryManagement;
using Main.Controllers.InventoryControllers;
using Main.FormModels;
using Shared;
using Shared.CustomModels;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.InventoryManagementForms.Controls
{
    public partial class ProductInventoryControl : UserControl
    {
        public ProductInventoryControl(UOMConverter uOMConverter,
                            IIngredientInventoryManager ingredientInventoryManager,
                            OtherSettings otherSettings)
        {
            InitializeComponent();
            _uOMConverter = uOMConverter;
            _ingredientInventoryManager = ingredientInventoryManager;
            _otherSettings = otherSettings;
        }

        private readonly UOMConverter _uOMConverter;
        private readonly IIngredientInventoryManager _ingredientInventoryManager;
        private readonly OtherSettings _otherSettings;

        private void ProductInventoryControl_Load(object sender, EventArgs e)
        {
            SetDGVProrductCategoriesFontAndColors();
            SetDGVIngredientListToSelectFontAndColors();
            SetDGVSelectedIngredientsFontAndColors();
            SetDGVProductListAndDGVProductExistingIngredientsFontAndColors();
            SetDGVProductListForComboMealFontAndColors();

            SetDGVSelectedIngredientsColumns();

            DisplayProductCategoriesInDGV();
            DisplayExistingProductsInDGV(this.ExistingProducts);
            DisplayProductsInDGVForComboMeal(this.ExistingProducts);
            DisplayIngredientInDGV(Ingredients);
            DisplayComboMealsInDGV(this.ExistingComboMeals);

            this.PropertyIsIsNewProductChanged += OnisNewProductUpdate;
            this.PropertyIsNewComboMealChanged += OnIsNewComboMealUpdate;

        }

        private void SetDGVProrductCategoriesFontAndColors()
        {
            this.DGVProrductCategories.BackgroundColor = Color.White;
            this.DGVProrductCategories.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProrductCategories.RowHeadersVisible = false;
            this.DGVProrductCategories.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVProrductCategories.AllowUserToResizeRows = false;
            this.DGVProrductCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVProrductCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProrductCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVProrductCategories.MultiSelect = false;

            this.DGVProrductCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVProrductCategories.ColumnHeadersHeight = 30;
        }

        private List<ProductCategoryModel> _productCategories;

        public List<ProductCategoryModel> ProductCategories
        {
            get { return _productCategories; }
            set { _productCategories = value; }
        }

        private ProductCategoryModel productCategoryToAddUpdate;

        public ProductCategoryModel ProductCategoryToAddUpdate
        {
            get { return productCategoryToAddUpdate; }
            set { productCategoryToAddUpdate = value; }
        }

        public long SelectedProductCategoryId { get; set; }

        public bool IsNewProductCategory { get; set; } = true;

        public event EventHandler ProductCategorySave;
        protected virtual void OnProductCategorySave(EventArgs e)
        {
            ProductCategorySave?.Invoke(this, e);
        }

        public void ResetProductCategoryForm()
        {
            this.TbxCategory.Text = "";
            this.BtnCancelUpdateCategory.Visible = false;
            this.GBoxIngredeitnCategoryForm.Text = "Add new";
            this.IsNewProductCategory = true;
            this.ProductCategoryToAddUpdate = null;
            this.SelectedProductCategoryId = 0;
        }

        public void MoveToAddProductTab()
        {
            this.MainTabControl.SelectedIndex = this.MainTabControl.TabPages.IndexOf(MainTabAddProduct);
        }

        private void BtnSaveCategory_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TbxCategory.Text))
                return;

            if (this.IsNewProductCategory == true)
            {

                if (this.ProductCategories != null)
                {
                    var existingCategory = this.ProductCategories.Where(x => x.ProdCategory.ToLower() == this.TbxCategory.Text.ToLower()).FirstOrDefault();

                    if (existingCategory != null)
                    {
                        MessageBox.Show($"Duplicate category.", "Save new category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this.ProductCategoryToAddUpdate = new ProductCategoryModel
                {
                    ProdCategory = this.TbxCategory.Text
                };
            }
            else
            {
                if (this.ProductCategoryToAddUpdate != null && this.ProductCategories != null)
                {
                    var existingCategory = this.ProductCategories.Where(x => 
                                                x.ProdCategory.ToLower() == this.TbxCategory.Text.ToLower() &&
                                                x.Id != this.ProductCategoryToAddUpdate.Id
                                                ).FirstOrDefault();

                    if (existingCategory != null)
                    {
                        MessageBox.Show($"Duplicate category.", "Save new category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    this.ProductCategoryToAddUpdate.ProdCategory = this.TbxCategory.Text;
                }

            }

            OnProductCategorySave(EventArgs.Empty);
        }


        public void DisplayProductCategoriesInDGV()
        {
            DisplayIngredientsInCbox(); // We put it here so we can also update the combox when the user update or delete category

            this.DGVProrductCategories.Rows.Clear();
            if (this.ProductCategories != null)
            {
                this.DGVProrductCategories.ColumnCount = 3;

                this.DGVProrductCategories.Columns[0].Name = "CategoryId";
                this.DGVProrductCategories.Columns[0].Visible = false;

                this.DGVProrductCategories.Columns[1].Name = "Category";
                this.DGVProrductCategories.Columns[1].HeaderText = "Category";

                this.DGVProrductCategories.Columns[2].Name = "CreatedAt";
                this.DGVProrductCategories.Columns[2].HeaderText = "Created At";

                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVProrductCategories.Columns.Add(btnUpdateImg);


                // Delete button
                DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVProrductCategories.Columns.Add(btnDeleteImg);

                foreach (var category in this.ProductCategories)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVProrductCategories);

                    row.Cells[0].Value = category.Id;
                    row.Cells[1].Value = category.ProdCategory;
                    row.Cells[2].Value = category.CreatedAt.ToShortDateString();

                    this.DGVProrductCategories.Rows.Add(row);
                }
            }

        }


        public void DisplayIngredientsInCbox()
        {
            this.CboxCategories.Items.Clear();

            if (this.ProductCategories != null)
            {
                ComboboxItem item;
                foreach (var category in this.ProductCategories)
                {
                    item = new ComboboxItem();
                    item.Text = category.ProdCategory;
                    item.Value = category.Id;

                    this.CboxCategories.Items.Add(item);
                }
            }

            this.CboxCategoryForFilteringProducts.Items.Clear();

            if (this.ProductCategories != null)
            {
                ComboboxItem item;
                foreach (var category in this.ProductCategories)
                {
                    item = new ComboboxItem();
                    item.Text = category.ProdCategory;
                    item.Value = category.Id;

                    this.CboxCategoryForFilteringProducts.Items.Add(item);
                }
            }
        }

        public long SelectedCategoryId { get; set; }
        //public event EventHandler SelectCategoryToUpdate;
        //protected virtual void OnSelectCategoryToUpdate(EventArgs e)
        //{
        //    SelectCategoryToUpdate?.Invoke(this, e);
        //}

        public event EventHandler SelectCategoryToDelete;
        protected virtual void OnSelectCategoryToDelete(EventArgs e)
        {
            SelectCategoryToDelete?.Invoke(this, e);
        }

        public void DisplaySelectedCategoryDetails()
        {
            if (this.ProductCategoryToAddUpdate != null)
            {
                this.TbxCategory.Text = this.ProductCategoryToAddUpdate.ProdCategory;
            }
        }

        private void DGVProrductCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update button
            if ((e.ColumnIndex == 3) && e.RowIndex > -1)
            {
                if (DGVProrductCategories.CurrentRow != null && this.ProductCategories != null)
                {
                    string categoryId = DGVProrductCategories.CurrentRow.Cells[0].Value.ToString();

                    SelectedCategoryId = long.Parse(categoryId);

                    this.BtnCancelUpdateCategory.Visible = true;
                    this.IsNewProductCategory = false;

                    this.ProductCategoryToAddUpdate = this.ProductCategories.Where(x => x.Id == SelectedCategoryId).FirstOrDefault();
                    DisplaySelectedCategoryDetails();

                    //OnSelectCategoryToUpdate(EventArgs.Empty);
                }
            }

            // Delete button
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                if (DGVProrductCategories.CurrentRow != null)
                {
                    string categoryId = DGVProrductCategories.CurrentRow.Cells[0].Value.ToString();
                    SelectedCategoryId = long.Parse(categoryId);
                    OnSelectCategoryToDelete(EventArgs.Empty);
                }
            }
        }

        private void BtnCancelUpdateCategory_Click(object sender, EventArgs e)
        {
            this.ResetProductCategoryForm();
        }




        // ###################################################################


        private void SetDGVProductListAndDGVProductExistingIngredientsFontAndColors()
        {
            this.DGVProductList.BackgroundColor = Color.White;
            this.DGVProductList.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProductList.RowHeadersVisible = false;
            this.DGVProductList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVProductList.AllowUserToResizeRows = false;
            this.DGVProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVProductList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProductList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductList.MultiSelect = false;

            this.DGVProductList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVProductList.ColumnHeadersHeight = 30;


            // --------------------------------

            this.DGVProductExistingIngredients.BackgroundColor = Color.White;
            this.DGVProductExistingIngredients.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProductExistingIngredients.RowHeadersVisible = false;
            this.DGVProductExistingIngredients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVProductExistingIngredients.AllowUserToResizeRows = false;
            this.DGVProductExistingIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVProductExistingIngredients.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProductExistingIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductExistingIngredients.MultiSelect = false;

            this.DGVProductExistingIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVProductExistingIngredients.ColumnHeadersHeight = 30;
        }



        private List<ProductModel> _existingProducts;

        public List<ProductModel> ExistingProducts
        {
            get { return _existingProducts; }
            set { _existingProducts = value; }
        }

        private List<ProductIngredientModel> _existingProductIngredients;

        public List<ProductIngredientModel> ExistingProductIngredients
        {
            get { return _existingProductIngredients; }
            set { _existingProductIngredients = value; }
        }


        public void DisplayExistingProductsInDGV(List<ProductModel> products)
        {
            this.DGVProductList.Rows.Clear();

            if (products != null)
            {
                this.DGVProductList.ColumnCount = 6;

                this.DGVProductList.Columns[0].Name = "ProductId";
                this.DGVProductList.Columns[0].Visible = false;

                this.DGVProductList.Columns[1].Name = "BarcodeLbl";
                this.DGVProductList.Columns[1].HeaderText = "Barcode";

                this.DGVProductList.Columns[2].Name = "Category";
                this.DGVProductList.Columns[2].HeaderText = "Category";

                this.DGVProductList.Columns[3].Name = "ProductName";
                this.DGVProductList.Columns[3].HeaderText = "Name";

                this.DGVProductList.Columns[4].Name = "PricePerOrder";
                this.DGVProductList.Columns[4].HeaderText = "Price per order";

                this.DGVProductList.Columns[5].Name = "HaveImage";
                this.DGVProductList.Columns[5].HeaderText = "Image";

                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVProductList.Columns.Add(btnUpdateImg);

                foreach (var product in products)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVProductList);

                    row.Cells[0].Value = product.Id;
                    row.Cells[0].ReadOnly = true;

                    row.Cells[1].Value = product.BarcodeLbl;
                    row.Cells[1].ReadOnly = true;

                    row.Cells[2].Value = product.Category.ProdCategory;
                    row.Cells[2].ReadOnly = true;

                    row.Cells[3].Value = product.ProdName;
                    row.Cells[3].ReadOnly = true;

                    row.Cells[4].Value = product.PricePerOrder;
                    row.Cells[4].ReadOnly = true;

                    row.Cells[5].Value = string.IsNullOrEmpty(product.ImageFilename) ? "N" : "Y";
                    row.Cells[5].ReadOnly = true;

                    this.DGVProductList.Rows.Add(row);
                }
            }
        }


        public void DisplayProductsExistingIngredientsInDGV()
        {
            this.DGVProductExistingIngredients.Rows.Clear();

            if (this.ExistingProductIngredients != null)
            {
                this.DGVProductExistingIngredients.ColumnCount = 5;

                this.DGVProductExistingIngredients.Columns[0].Name = "ProductIngredientId";
                this.DGVProductExistingIngredients.Columns[0].Visible = false;

                this.DGVProductExistingIngredients.Columns[1].Name = "IngredientName";
                this.DGVProductExistingIngredients.Columns[1].HeaderText = "IngredientName";

                this.DGVProductExistingIngredients.Columns[2].Name = "UOM";
                this.DGVProductExistingIngredients.Columns[2].HeaderText = "UOM";

                this.DGVProductExistingIngredients.Columns[3].Name = "QtyValue";
                this.DGVProductExistingIngredients.Columns[3].HeaderText = "Qty value";

                this.DGVProductExistingIngredients.Columns[4].Name = "Cost";
                this.DGVProductExistingIngredients.Columns[4].HeaderText = "Cost";

                decimal totalCost = 0;

                foreach (var ingredient in ExistingProductIngredients)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVProductExistingIngredients);

                    row.Cells[0].Value = ingredient.Id;
                    row.Cells[0].ReadOnly = true;

                    row.Cells[1].Value = ingredient.Ingredient.IngName;
                    row.Cells[1].ReadOnly = true;

                    row.Cells[2].Value = ingredient.UOM;
                    row.Cells[2].ReadOnly = true;

                    row.Cells[3].Value = ingredient.QtyValue;
                    row.Cells[3].ReadOnly = true;

                    decimal tempCost = _ingredientInventoryManager.GetProductIngredientCost(ingredient.IngredientId, ingredient.QtyValue, ingredient.UOM);
                    totalCost += tempCost;

                    row.Cells[4].Value = tempCost;
                    row.Cells[4].ReadOnly = true;

                    this.DGVProductExistingIngredients.Rows.Add(row);
                }

                this.LblTotalCostOfIngredients.Text = totalCost.ToString("0.##");
            }
        }

        public long SelectedExistingProductId { get; set; }

        public event EventHandler GetProductExistingIngredients;
        protected virtual void OnGetProductExistingIngredients(EventArgs e)
        {
            GetProductExistingIngredients?.Invoke(this, e);
        }

        public event EventHandler GetProductDetailsAndDispalyInForm;
        protected virtual void OnGetProductDetailsAndDispalyInForm(EventArgs e)
        {
            GetProductDetailsAndDispalyInForm?.Invoke(this, e);
        }

        private void DGVProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVProductList.CurrentRow != null && this.ExistingProducts != null)
                {
                    SelectedExistingProductId = long.Parse(DGVProductList.CurrentRow.Cells[0].Value.ToString());
                    OnGetProductExistingIngredients(EventArgs.Empty);
                }
            }

            //Update button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                if (DGVProductList.CurrentRow != null && this.ProductCategories != null)
                {
                    SelectedExistingProductId = long.Parse(DGVProductList.CurrentRow.Cells[0].Value.ToString());
                    OnGetProductDetailsAndDispalyInForm(EventArgs.Empty);
                }
            }
        }

        // ###################################################################

        private List<IngredientModel> _ingredients;
        public List<IngredientModel> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; }
        }

        private Dictionary<long, IngredientModel> selectedIngredients = new Dictionary<long, IngredientModel>();

        public Dictionary<long, IngredientModel> SelectedIngredients
        {
            get { return selectedIngredients; }
            set { selectedIngredients = value; }
        }

        private void SetDGVIngredientListToSelectFontAndColors()
        {
            this.DGVIngredientListToSelect.BackgroundColor = Color.White;
            this.DGVIngredientListToSelect.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVIngredientListToSelect.RowHeadersVisible = false;
            this.DGVIngredientListToSelect.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVIngredientListToSelect.AllowUserToResizeRows = false;
            this.DGVIngredientListToSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVIngredientListToSelect.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVIngredientListToSelect.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVIngredientListToSelect.MultiSelect = false;

            this.DGVIngredientListToSelect.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVIngredientListToSelect.ColumnHeadersHeight = 30;
        }

        private void SetDGVSelectedIngredientsFontAndColors()
        {
            this.DGVSelectedIngredients.BackgroundColor = Color.White;
            this.DGVSelectedIngredients.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVSelectedIngredients.RowHeadersVisible = false;
            this.DGVSelectedIngredients.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVSelectedIngredients.AllowUserToResizeRows = false;
            this.DGVSelectedIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVSelectedIngredients.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            //this.DGVSelectedIngredients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVSelectedIngredients.MultiSelect = false;

            this.DGVSelectedIngredients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVSelectedIngredients.ColumnHeadersHeight = 30;
        }



        public void DisplayIngredientInDGV(List<IngredientModel> Ingredients)
        {
            this.DGVIngredientListToSelect.Rows.Clear();
            if (Ingredients != null)
            {
                this.DGVIngredientListToSelect.ColumnCount = 5;

                this.DGVIngredientListToSelect.Columns[0].Name = "IngredientId";
                this.DGVIngredientListToSelect.Columns[0].Visible = false;

                this.DGVIngredientListToSelect.Columns[1].Name = "Ingredient";
                this.DGVIngredientListToSelect.Columns[1].HeaderText = "Ingredient";

                this.DGVIngredientListToSelect.Columns[2].Name = "Category";
                this.DGVIngredientListToSelect.Columns[2].HeaderText = "Category";

                this.DGVIngredientListToSelect.Columns[3].Name = "UOM";
                this.DGVIngredientListToSelect.Columns[3].HeaderText = "UOM";

                this.DGVIngredientListToSelect.Columns[4].Name = "QtyValue";
                this.DGVIngredientListToSelect.Columns[4].HeaderText = "Rem. Qty Value";

                DataGridViewCheckBoxColumn selectChbx = new DataGridViewCheckBoxColumn();
                selectChbx.HeaderText = "Select";
                selectChbx.Name = "selectIngredientCkbox";
                selectChbx.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                selectChbx.ReadOnly = false;
                this.DGVIngredientListToSelect.Columns.Add(selectChbx);

                //// Delete button
                //DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                ////btnDeleteLeaveTypeImg.Name = "";
                //btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //btnDeleteImg.Image = Image.FromFile("./Resources/icons8-plus-24.png");
                //this.DGVIngredientListToSelect.Columns.Add(btnDeleteImg);

                foreach (var ing in Ingredients)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVIngredientListToSelect);

                    row.Cells[0].Value = ing.Id;
                    row.Cells[0].ReadOnly = true;

                    row.Cells[1].Value = ing.IngName;
                    row.Cells[1].ReadOnly = true;

                    row.Cells[2].Value = ing.Category.Category;
                    row.Cells[2].ReadOnly = true;

                    row.Cells[3].Value = ing.UOM;
                    row.Cells[3].ReadOnly = true;

                    row.Cells[4].Value = this.GetUOMFormatted(ing.UOM, ing.RemainingQtyValue);
                    row.Cells[4].ReadOnly = true;



                    this.DGVIngredientListToSelect.Rows.Add(row);
                }

                if (this.SelectedIngredients.Count > 0)
                {
                    foreach (DataGridViewRow row in this.DGVIngredientListToSelect.Rows)
                    {
                        long ingredientIdTemp = long.Parse(row.Cells["IngredientId"].Value.ToString());
                        if (this.SelectedIngredients.ContainsKey(ingredientIdTemp))
                        {
                            row.Cells["selectIngredientCkbox"].Value = (bool)true;
                        }
                    }
                }

            }
        }

        public void UncheckSelectedProductsInDGV()
        {
            foreach (DataGridViewRow row in this.DGVIngredientListToSelect.Rows)
            {
                row.Cells["selectIngredientCkbox"].Value = (bool)false;
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

        public string[] GetUOMSmallAndBig (StaticData.UOM uom)
        {
            var uomList = new string[] { };

            switch (uom)
            {
                case StaticData.UOM.kg:

                    uomList = new string[] { StaticData.UOM.kg.ToString(), StaticData.UOM.g.ToString() };
                    break;

                case StaticData.UOM.L:
                    uomList = new string[] { StaticData.UOM.L.ToString(), StaticData.UOM.ml.ToString() };

                    break;

                case StaticData.UOM.pcs:
                    uomList = new string[] { StaticData.UOM.pcs.ToString() , StaticData.UOM.pc.ToString() };
                    break;

                default:
                    break;
            }

            return uomList;
        }

        public void SetDGVSelectedIngredientsColumns()
        {
            this.DGVSelectedIngredients.ColumnCount = 4;

            this.DGVSelectedIngredients.Columns[0].Name = "IngredientId";
            this.DGVSelectedIngredients.Columns[0].Visible = false;

            this.DGVSelectedIngredients.Columns[1].Name = "Ingredient";
            this.DGVSelectedIngredients.Columns[1].HeaderText = "Ingredient";

            this.DGVSelectedIngredients.Columns[2].Name = "QtyValue";
            this.DGVSelectedIngredients.Columns[2].HeaderText = "Rem. Qty Value";

            this.DGVSelectedIngredients.Columns[3].Name = "UOM";
            this.DGVSelectedIngredients.Columns[3].HeaderText = "UOM";


            // Delete button
            DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
            //btnDeleteLeaveTypeImg.Name = "";
            btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
            btnDeleteImg.ReadOnly = false;
            this.DGVSelectedIngredients.Columns.Add(btnDeleteImg);

            DataGridViewComboBoxColumn newColumn = new DataGridViewComboBoxColumn();
            newColumn.Name = "UOMToUse";
            this.DGVSelectedIngredients.Columns.Add(newColumn);

            //DataGridViewTextBoxColumn textboxColumn = new DataGridViewTextBoxColumn();

            NumericUpDownColumn numTextBox = new NumericUpDownColumn();
            numTextBox.HeaderText = "Amount";
            numTextBox.Name = "selectedIngredientAmount";
            numTextBox.DefaultCellStyle.BackColor = Color.Bisque;
            numTextBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            numTextBox.ReadOnly = false;
            DGVSelectedIngredients.Columns.Add(numTextBox);


            DataGridViewTextBoxColumn textboxColumn = new DataGridViewTextBoxColumn();
            textboxColumn.HeaderText = "Cost";
            textboxColumn.Name = "TotalCost";
            //textboxColumn.DefaultCellStyle.BackColor = Color.Bisque;
            textboxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            textboxColumn.ReadOnly = true;
            DGVSelectedIngredients.Columns.Add(textboxColumn);
        }


        public void AddIngredientInDGVSelectedIngredients(IngredientModel ingredient, StaticData.UOM? uomToUseDefaultValue = null, decimal defaultQtyValue = 0)
        {
            if (ingredient != null)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.DGVSelectedIngredients);

                row.Cells[0].Value = ingredient.Id;
                row.Cells[0].ReadOnly = true;

                row.Cells[1].Value = ingredient.IngName;
                row.Cells[1].ReadOnly = true;

                row.Cells[2].Value = this.GetUOMFormatted(ingredient.UOM, ingredient.RemainingQtyValue);
                row.Cells[2].ReadOnly = true;

                row.Cells[3].Value = ingredient.UOM;
                row.Cells[3].ReadOnly = true;

                this.DGVSelectedIngredients.Rows.Add(row);

                DataGridViewComboBoxCell UOMToUseCell = (DataGridViewComboBoxCell)(row.Cells["UOMToUse"]);
                UOMToUseCell.DataSource = this.GetUOMSmallAndBig(ingredient.UOM);
                
                if (uomToUseDefaultValue != null)
                {
                    UOMToUseCell.Value = uomToUseDefaultValue.ToString();
                }

                NumericUpDownCell qtyValue = (NumericUpDownCell)(row.Cells["selectedIngredientAmount"]);
                qtyValue.Value = defaultQtyValue;
            }
        }


        private void DGVIngredientListToSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if ((e.ColumnIndex == this.DGVIngredientListToSelect.CurrentRow.Cells["selectIngredientCkbox"].ColumnIndex) && e.RowIndex > -1)
            {
                DataGridViewCheckBoxCell cell = this.DGVIngredientListToSelect.CurrentCell as DataGridViewCheckBoxCell;

                if (cell != null && !cell.ReadOnly)
                {
                    cell.Value = cell.Value == null || !((bool)cell.Value);
                    this.DGVIngredientListToSelect.RefreshEdit();
                    this.DGVIngredientListToSelect.NotifyCurrentCellDirty(true);
                }

                bool isSelected = Convert.ToBoolean(this.DGVIngredientListToSelect.CurrentRow.Cells["selectIngredientCkbox"].Value);
                long ingredientId = long.Parse(this.DGVIngredientListToSelect.CurrentRow.Cells["IngredientId"].Value.ToString());

                if (isSelected)
                {
                    var ingredient = this.Ingredients.Where(x => x.Id == ingredientId).FirstOrDefault();

                    if (this.SelectedIngredients.ContainsKey(ingredientId) == false)
                    {
                        this.SelectedIngredients.Add(ingredientId, ingredient);

                        AddIngredientInDGVSelectedIngredients(ingredient);
                    }
                }
                else
                {
                    if (this.SelectedIngredients.ContainsKey(ingredientId))
                    {
                        if (this.SelectedIngredients.Remove(ingredientId))
                        {
                            foreach (DataGridViewRow row in this.DGVSelectedIngredients.Rows)
                            {
                                long tempIngredientId = long.Parse(row.Cells["IngredientId"].Value.ToString());

                                if (tempIngredientId == ingredientId)
                                {
                                    this.DGVSelectedIngredients.Rows.RemoveAt(row.Index);
                                }
                            }

                            // Marking existing ingredient if on update transaction
                            MarkAsDeletedExistingIngredientIfUpdate(ingredientId);
                        }
                    }
                }

                this.LblNumberOfSelectedIngredients.Text = this.SelectedIngredients.Count().ToString();
            }
              
        }

        public void RefreshDGVSelectedIngredientsToComputeTotalCost()
        {
            decimal totalCost = 0;
            foreach (DataGridViewRow row in this.DGVSelectedIngredients.Rows)
            {
                if (row.Cells["UOMToUse"].Value != null)
                {
                    long ingredientId = long.Parse(row.Cells["IngredientId"].Value.ToString());
                    decimal qtyValue = decimal.Parse(row.Cells["selectedIngredientAmount"].Value.ToString());
                    var selectedUOM = (StaticData.UOM)Enum.Parse(typeof(StaticData.UOM), row.Cells["UOMToUse"].Value.ToString());

                    decimal cost = _ingredientInventoryManager.GetProductIngredientCost(ingredientId, qtyValue, selectedUOM);
                    totalCost += cost;

                    row.Cells["TotalCost"].Value = cost;
                }
            }

            this.LblTotalCostFromAddingNewProduct.Text = totalCost.ToString("0.##");
            this.LblTotalCost2.Text = totalCost.ToString("0.##");
        }

        private void BtnCompute_Click(object sender, EventArgs e)
        {
            RefreshDGVSelectedIngredientsToComputeTotalCost();
        }

        private void DGVIngredientListToSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.DGVIngredientListToSelect.RefreshEdit();
        }

        private void DGVSelectedIngredients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 4) && e.RowIndex > -1)
            {
                if (DGVSelectedIngredients.CurrentRow != null)
                {
                    long ingredientId = long.Parse(DGVSelectedIngredients.CurrentRow.Cells[0].Value.ToString());

                    if (this.SelectedIngredients.ContainsKey(ingredientId))
                    {
                        if (this.SelectedIngredients.Remove(ingredientId))
                        {
                            this.DGVSelectedIngredients.Rows.RemoveAt(e.RowIndex);

                            foreach (DataGridViewRow row in this.DGVIngredientListToSelect.Rows)
                            {
                                long ingredientIdTemp = long.Parse(row.Cells["IngredientId"].Value.ToString());

                                if (ingredientIdTemp == ingredientId)
                                {
                                    row.Cells["selectIngredientCkbox"].Value = (bool)false;
                                }
                            }

                            // Marking existing ingredient if on update transaction
                            MarkAsDeletedExistingIngredientIfUpdate(ingredientId);
                        }

                    }
                }

                this.LblNumberOfSelectedIngredients.Text = this.SelectedIngredients.Count().ToString();
            }


            if ((e.ColumnIndex == 6) && e.RowIndex > -1)
            {
                DGVSelectedIngredients.CurrentCell = DGVSelectedIngredients[e.ColumnIndex, e.RowIndex];
                DGVSelectedIngredients.BeginEdit(true);
                string numUpDownVal = DGVSelectedIngredients.CurrentCell.Value != null ? DGVSelectedIngredients.CurrentCell.Value.ToString() : "";
                ((NumericUpDown)DGVSelectedIngredients.EditingControl).Select(0, numUpDownVal.Length);
            }
        }

        private void TboxSearchIngredients_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && string.IsNullOrWhiteSpace(TboxSearchIngredients.Text) == false)
            {
                var searchResults = this.Ingredients.Where(x => x.IngName.Contains(TboxSearchIngredients.Text)).ToList();
                DisplayIngredientInDGV(searchResults);
            }
        }

        private void BtnRefreshIngredientList_Click(object sender, EventArgs e)
        {
            this.TboxSearchIngredients.Text = "";
            DisplayIngredientInDGV(Ingredients);
        }


        private List<ProductIngredientModel> _productSelectedIngredients = new List<ProductIngredientModel>();

        public List<ProductIngredientModel> ProductSelectedIngredients
        {
            get { return _productSelectedIngredients; }
            set { _productSelectedIngredients = value; }
        }

        public void MarkAsDeletedExistingIngredientIfUpdate(long ingredientId)
        {
            if (this.ProductSelectedIngredients != null)
            {
                var existingIngredient = this.ProductSelectedIngredients.Where(x => x.IngredientId == ingredientId).FirstOrDefault();

                if (existingIngredient != null && existingIngredient.Id > 0)
                {
                    existingIngredient.IsDeleted = true;
                    existingIngredient.DeletedAt = DateTime.Now;
                }
            }
        }

        private ProductModel _productToAddUpdate;

        public ProductModel ProductToAddUpdate
        {
            get { return _productToAddUpdate; }
            set { _productToAddUpdate = value; }
        }


        public event PropertyChangedEventHandler PropertyIsIsNewProductChanged;
        private bool isNewProduct = true;

        public bool IsNewProduct
        {
            get { return isNewProduct; }
            set { 
                isNewProduct = value; 
                
                if (PropertyIsIsNewProductChanged != null)
                {
                    PropertyIsIsNewProductChanged(this, new PropertyChangedEventArgs(IsNewProduct.ToString()));
                }
            }
        }


        private void OnisNewProductUpdate(object sender, PropertyChangedEventArgs e)
        { 
            if (IsNewProduct)
            {
                this.BtnCancelSaveProductDetails.Visible = false;
                this.LblNewOrUpdateProductIndicator.Text = "Add New product";
            }
            else
            {
                this.BtnCancelSaveProductDetails.Visible = true;
                this.LblNewOrUpdateProductIndicator.Text = "Update product";
            }
        }

        public event EventHandler ProductSave;
        protected virtual void OnProductSave(EventArgs e)
        {
            ProductSave?.Invoke(this, e);
        }


        private void CkBoxAutoGenerateBarcodeLbl_CheckedChanged(object sender, EventArgs e)
        {
            TboxBarcodeLbl.Enabled = !CkBoxAutoGenerateBarcodeLbl.Checked;
        }

        private void BtnSaveProductDetails_Click(object sender, EventArgs e)
        {
            if (ProductSelectedIngredients == null)
            {
                ProductSelectedIngredients = new List<ProductIngredientModel>();
            }
            bool isContinueToGenerateData = true;

            if (this.CboxCategories.SelectedIndex < 0)
            {
                MessageBox.Show($"Kindly choose category.", "Product Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selectedCategory = this.CboxCategories.SelectedItem as ComboboxItem;
            long categoryId = long.Parse(selectedCategory.Value.ToString());

            if (string.IsNullOrEmpty(TboxProductName.Text))
            {
                MessageBox.Show($"Provide product name.", "Product name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (CkBoxAutoGenerateBarcodeLbl.Checked == false)
            {
                if (string.IsNullOrEmpty(TboxBarcodeLbl.Text))
                {
                    MessageBox.Show($"Provide product barcode label.", "Product barcode label", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (NumUpDownPricePerOrder.Value <= 0)
            {
                MessageBox.Show($"Provide price per order.", "Product price per order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //if (this.SelectedIngredients == null)
            //{
            //    MessageBox.Show($"Kindly choose product's ingredients.", "Product's ingredients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //if (this.SelectedIngredients.Count == 0)
            //{
            //    MessageBox.Show($"Kindly choose product's ingredients.", "Product's ingredients", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            if (this.SelectedIngredients != null && this.SelectedIngredients.Count > 0)
            {
                foreach (DataGridViewRow row in this.DGVSelectedIngredients.Rows)
                {
                    long tempIngredientId = long.Parse(row.Cells["IngredientId"].Value.ToString());
                    string ingredientNmae = row.Cells["Ingredient"].Value.ToString();
                    string uom = row.Cells["UOMToUse"].Value != null ? row.Cells["UOMToUse"].Value.ToString() : "";
                    string qtyValueTmp = row.Cells["selectedIngredientAmount"].Value != null ? row.Cells["selectedIngredientAmount"].Value.ToString() : "";

                    if (string.IsNullOrEmpty(uom))
                    {
                        MessageBox.Show($"Kindly choose unit of measurement for {ingredientNmae}", "Unit of measurement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        isContinueToGenerateData = false;
                        break;
                    }

                    if (string.IsNullOrEmpty(qtyValueTmp))
                    {
                        MessageBox.Show($"Kindly provide quantity value for {ingredientNmae}", "Quantity value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        isContinueToGenerateData = false;
                        break;
                    }

                    if (decimal.TryParse(qtyValueTmp, out decimal qtyValue))
                    {
                        var existingIngredientDetails = ProductSelectedIngredients.Where(x => x.IngredientId == tempIngredientId).FirstOrDefault();

                        if (existingIngredientDetails == null)
                        {
                            ProductSelectedIngredients.Add(new ProductIngredientModel
                            {
                                IngredientId = tempIngredientId,
                                UOM = (StaticData.UOM)Enum.Parse(typeof(StaticData.UOM), uom),
                                QtyValue = qtyValue
                            });
                        }
                        else
                        {
                            existingIngredientDetails.UOM = (StaticData.UOM)Enum.Parse(typeof(StaticData.UOM), uom);
                            existingIngredientDetails.QtyValue = qtyValue;
                            existingIngredientDetails.IsDeleted = false;
                            existingIngredientDetails.DeletedAt = DateTime.MinValue;
                        }

                    }
                }
            }

            
            if (isContinueToGenerateData == true)
            {
                if (IsNewProduct)
                {

                    if (this.ExistingProducts != null)
                    {
                        var existingProd = this.ExistingProducts.Where(x => x.ProdName.ToLower() == TboxProductName.Text.ToLower()).FirstOrDefault();

                        if (existingProd != null)
                        {
                            MessageBox.Show("Duplicate product", "Save new product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    this.ProductToAddUpdate = new ProductModel
                    {
                        isBarcodeLblAutoGenerate = CkBoxAutoGenerateBarcodeLbl.Checked,
                        BarcodeLbl = TboxBarcodeLbl.Text,
                        CategoryId = categoryId,
                        ProdName = TboxProductName.Text,
                        PricePerOrder = NumUpDownPricePerOrder.Value
                    };
                    OnProductSave(EventArgs.Empty);
                }
                else
                {
                    if (this.ProductToAddUpdate != null)
                    {
                        if (this.ExistingProducts != null)
                        {
                            var existingProd = this.ExistingProducts.Where(x => 
                                                                x.ProdName.ToLower() == TboxProductName.Text.ToLower() &&
                                                                x.Id != this.ProductToAddUpdate.Id).FirstOrDefault();

                            if (existingProd != null)
                            {
                                MessageBox.Show("Duplicate product", "Save product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }

                        this.ProductToAddUpdate.BarcodeLbl = TboxBarcodeLbl.Text;
                        this.ProductToAddUpdate.CategoryId = categoryId;
                        this.ProductToAddUpdate.ProdName = TboxProductName.Text;
                        this.ProductToAddUpdate.PricePerOrder = NumUpDownPricePerOrder.Value;

                        OnProductSave(EventArgs.Empty);
                    }
                }
            }
        }

        public void ClearProductDetailsForm()
        {
            this.CkBoxAutoGenerateBarcodeLbl.Checked = false;
            this.TboxBarcodeLbl.Text = "";
            this.IsNewProduct = true;
            this.ProductToAddUpdate = null;
            this.SelectedIngredients = new Dictionary<long, IngredientModel>();
            this.ProductSelectedIngredients = new List<ProductIngredientModel>();
            this.DGVSelectedIngredients.Rows.Clear();
            this.UncheckSelectedProductsInDGV();
            this.CboxCategories.SelectedIndex = -1;
            this.TboxProductName.Text = "";
            this.NumUpDownPricePerOrder.Value = 0;
            this.LblNumberOfSelectedIngredients.Text = "0";
            this.BtnCancelSaveProductDetails.Visible = false;

            if (PicBoxProductImage.Image != null)
            {
                PicBoxProductImage.Image.Dispose();
                PicBoxProductImage.ImageLocation = null;
                PicBoxProductImage.Image = null;
            }

        }

        private void BtnCancelSaveProductDetails_Click(object sender, EventArgs e)
        {
            ClearProductDetailsForm();
        }

        public void SelectedCategoryInCbox(long categoryId)
        {
            for (var i = 0; i < this.CboxCategories.Items.Count; i++)
            {
                var item = this.CboxCategories.Items[i] as ComboboxItem;
                if (long.Parse(item.Value.ToString()) == categoryId)
                {
                    this.CboxCategories.SelectedIndex = i;
                    break;
                }
            }
        }

        public void DisplayProductDetailsAndIngredientsInFormAndDGV()
        {
            this.SelectedIngredients = new Dictionary<long, IngredientModel>();
            this.DGVSelectedIngredients.Rows.Clear();
            this.UncheckSelectedProductsInDGV();

            if (this.ProductToAddUpdate != null)
            {
                SelectedCategoryInCbox(this.ProductToAddUpdate.CategoryId);

                this.TboxBarcodeLbl.Text = this.ProductToAddUpdate.BarcodeLbl;
                this.TboxProductName.Text = this.ProductToAddUpdate.ProdName;
                this.NumUpDownPricePerOrder.Value = this.ProductToAddUpdate.PricePerOrder;


                string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var ProductImgsDirInfo = Directory.CreateDirectory($"{appPath}{_otherSettings.ProductImgsFileDirName}");

                if (PicBoxProductImage.Image != null)
                {
                    PicBoxProductImage.Image.Dispose();
                    PicBoxProductImage.ImageLocation = null;
                    PicBoxProductImage.Image = null;
                }

                if (ProductImgsDirInfo.Exists)
                {
                    string empImgPath = $"{appPath}\\{_otherSettings.ProductImgsFileDirName}\\{ProductToAddUpdate.ImageFilename}";

                    if (File.Exists(empImgPath))
                    {
                        PicBoxProductImage.Image = new Bitmap(empImgPath);
                        PicBoxProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }


                if (this.ProductSelectedIngredients != null)
                {
                    //int[] existingIngredientIds = this.ProductSelectedIngredients.Select(x => x.IngredientId).ToArray();

                    foreach (DataGridViewRow row in this.DGVIngredientListToSelect.Rows)
                    {
                        long ingredientIdInTheDGV = long.Parse(row.Cells["IngredientId"].Value.ToString());
                        var existingIngredientDetails = this.ProductSelectedIngredients.Where(x => x.IngredientId == ingredientIdInTheDGV).FirstOrDefault();

                        if (existingIngredientDetails != null)
                        {
                            row.Cells["selectIngredientCkbox"].Value = (bool)true;

                            var ingredientDetails = this.Ingredients.Where(x => x.Id == ingredientIdInTheDGV).FirstOrDefault();

                            if (ingredientDetails != null)
                            {
                                if (this.SelectedIngredients.ContainsKey(ingredientDetails.Id) == false)
                                {
                                    this.SelectedIngredients.Add(ingredientDetails.Id, ingredientDetails);

                                    AddIngredientInDGVSelectedIngredients(ingredientDetails, existingIngredientDetails.UOM, existingIngredientDetails.QtyValue);
                                }
                            }
                        }
                    }
                }

                this.MainTabControl.SelectedIndex = this.MainTabControl.TabPages.IndexOf(MainTabAddProduct);
                this.BtnCancelSaveProductDetails.Visible = true;
                this.IsNewProduct = false;
            }
        }


        private void BtnFilterProducts_Click(object sender, EventArgs e)
        {
            if (this.ExistingProducts != null)
            {
                long categoryId = 0;
                string productName = this.TboxProductNameForFiltering.Text;

                if (this.CboxCategoryForFilteringProducts.SelectedIndex >= 0)
                {
                    var selectedCategory = this.CboxCategoryForFilteringProducts.SelectedItem as ComboboxItem;
                    categoryId = long.Parse(selectedCategory.Value.ToString());
                }

                List<ProductModel> searchResults = new List<ProductModel>();
                if (categoryId > 0 && string.IsNullOrEmpty(productName)) // Category only
                {
                    searchResults = this.ExistingProducts.Where(x => x.CategoryId == categoryId).ToList();

                }else if (categoryId > 0 && string.IsNullOrEmpty(productName) == false) // both
                {
                    searchResults = this.ExistingProducts.Where(
                        x => x.CategoryId == categoryId && 
                        x.ProdName.ToLower().Contains(productName.ToLower())
                    ).ToList();
                }
                else if (categoryId == 0 && string.IsNullOrEmpty(productName) == false) // product name only
                {
                    searchResults = this.ExistingProducts.Where(
                        x => x.ProdName.ToLower()
                        .Contains(productName.ToLower())
                        ).ToList();
                }
                
                DisplayExistingProductsInDGV(searchResults);
            }
        }

        public event EventHandler RefreshProductList;
        protected virtual void OnRefreshProductList(EventArgs e)
        {
            RefreshProductList?.Invoke(this, e);
        }

        private void BtnRefreshProductList_Click(object sender, EventArgs e)
        {
            OnRefreshProductList(EventArgs.Empty);
            this.TboxProductNameForFiltering.Text = "";
            this.CboxCategoryForFilteringProducts.SelectedIndex = -1;
        }


        // ######################################################################################
        // ######################################################################################
        // ######################################################################################

        public event EventHandler SaveComboMeal;
        protected virtual void OnSaveComboMeal(EventArgs e)
        {
            SaveComboMeal?.Invoke(this, e);
        }

        private ComboMealModel _comboMealToAddUpdate;

        public ComboMealModel ComboMealToAddUpdate
        {
            get { return _comboMealToAddUpdate; }
            set { _comboMealToAddUpdate = value; }
        }


        private List<ComboMealProductModel> _comboMealProductsToAddUpdate = new List<ComboMealProductModel>();

        public List<ComboMealProductModel> ComboMealProductsToAddUpdate
        {
            get { return _comboMealProductsToAddUpdate; }
            set { _comboMealProductsToAddUpdate = value; }
        }


        public long SelectedComboMealId { get; set; }


        public event PropertyChangedEventHandler PropertyIsNewComboMealChanged;
        private bool isNewComboMeal = true;

        public bool IsNewComboMeal
        {
            get { return isNewComboMeal; }
            set {
                isNewComboMeal = value; 

                if (PropertyIsNewComboMealChanged != null)
                {
                    PropertyIsNewComboMealChanged(this, new PropertyChangedEventArgs(IsNewComboMeal.ToString()));
                }
            }
        }

        private void OnIsNewComboMealUpdate(object sender, PropertyChangedEventArgs e)
        {
            if (IsNewComboMeal)
            {
                BtnCancelSaveComboMeal.Visible = false;
                LblAddOrUpdateComboMealIndicator.Text = "Add New Combo Meal";
            }
            else
            {
                BtnCancelSaveComboMeal.Visible = true;
                LblAddOrUpdateComboMealIndicator.Text = "Update Combo Meal";
            }
        }

        private void SetDGVProductListForComboMealFontAndColors()
        {
            this.DGVProductListForComboMeal.BackgroundColor = Color.White;
            this.DGVProductListForComboMeal.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProductListForComboMeal.RowHeadersVisible = false;
            this.DGVProductListForComboMeal.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVProductListForComboMeal.AllowUserToResizeRows = false;
            this.DGVProductListForComboMeal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVProductListForComboMeal.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVProductListForComboMeal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductListForComboMeal.MultiSelect = false;

            this.DGVProductListForComboMeal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVProductListForComboMeal.ColumnHeadersHeight = 30;

            // --------------------------------------

            this.DGVComboMealList.BackgroundColor = Color.White;
            this.DGVComboMealList.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVComboMealList.RowHeadersVisible = false;
            this.DGVComboMealList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVComboMealList.AllowUserToResizeRows = false;
            this.DGVComboMealList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVComboMealList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVComboMealList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVComboMealList.MultiSelect = false;

            this.DGVComboMealList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVComboMealList.ColumnHeadersHeight = 30;


            // --------------------------------------

            this.DGVComboMealExistingProducts.BackgroundColor = Color.White;
            this.DGVComboMealExistingProducts.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVComboMealExistingProducts.RowHeadersVisible = false;
            this.DGVComboMealExistingProducts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVComboMealExistingProducts.AllowUserToResizeRows = false;
            this.DGVComboMealExistingProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVComboMealExistingProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVComboMealExistingProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVComboMealExistingProducts.MultiSelect = false;

            this.DGVComboMealExistingProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVComboMealExistingProducts.ColumnHeadersHeight = 30;
        }


        public void DisplayProductsInDGVForComboMeal(List<ProductModel> products)
        {
            this.DGVProductListForComboMeal.Rows.Clear();

            if (products != null)
            {
                this.DGVProductListForComboMeal.ColumnCount = 4;

                this.DGVProductListForComboMeal.Columns[0].Name = "ProductId";
                this.DGVProductListForComboMeal.Columns[0].Visible = false;

                this.DGVProductListForComboMeal.Columns[1].Name = "Category";
                this.DGVProductListForComboMeal.Columns[1].HeaderText = "Category";

                this.DGVProductListForComboMeal.Columns[2].Name = "ProductName";
                this.DGVProductListForComboMeal.Columns[2].HeaderText = "Name";

                this.DGVProductListForComboMeal.Columns[3].Name = "PricePerOrder";
                this.DGVProductListForComboMeal.Columns[3].HeaderText = "Price per order";

                // checkbox
                DataGridViewCheckBoxColumn selectChbx = new DataGridViewCheckBoxColumn();
                selectChbx.HeaderText = "Select";
                selectChbx.Name = "selectProductCkbox";
                selectChbx.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                selectChbx.ReadOnly = false;
                this.DGVProductListForComboMeal.Columns.Add(selectChbx);

                // quantity
                NumericUpDownColumn numTextBox = new NumericUpDownColumn();
                numTextBox.HeaderText = "Quantity";
                numTextBox.Name = "selectedProductQty";
                numTextBox.DefaultCellStyle.BackColor = Color.Bisque;
                numTextBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                numTextBox.ReadOnly = false;
                this.DGVProductListForComboMeal.Columns.Add(numTextBox);

                foreach (var product in products)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVProductListForComboMeal);

                    row.Cells[0].Value = product.Id;
                    row.Cells[0].ReadOnly = true;

                    row.Cells[1].Value = product.Category.ProdCategory;
                    row.Cells[1].ReadOnly = true;

                    row.Cells[2].Value = product.ProdName;
                    row.Cells[2].ReadOnly = true;

                    row.Cells[3].Value = product.PricePerOrder;
                    row.Cells[3].ReadOnly = true;

                    this.DGVProductListForComboMeal.Rows.Add(row);
                }
            }
        }

        private void DGVProductListForComboMeal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 5) && e.RowIndex > -1)
            {
                DGVProductListForComboMeal.CurrentCell = DGVProductListForComboMeal[e.ColumnIndex, e.RowIndex];
                DGVProductListForComboMeal.BeginEdit(true);
                string numUpDownVal = DGVProductListForComboMeal.CurrentCell.Value != null ? DGVProductListForComboMeal.CurrentCell.Value.ToString() : "";
                ((NumericUpDown)DGVProductListForComboMeal.EditingControl).Select(0, numUpDownVal.Length);
            }
        }


        public void ClearProductListInComboMealTab()
        {
            foreach (DataGridViewRow row in this.DGVProductListForComboMeal.Rows)
            {
                row.Cells["selectProductCkbox"].Value = (bool)false;
                row.Cells["selectedProductQty"].Value = 0;
            }
        }

        public void ClearComboMealForm()
        {
            this.CkBoxComboMealAutoGen.Checked = false;
            this.TboxComboMealBarcodeLbl.Text = "";
            this.TboxComboMealTitle.Text = "";
            this.NumUpDownComboMealPrice.Value = 0;
            this.IsNewComboMeal = true;
            this.ComboMealToAddUpdate = null;
            this.ComboMealProductsToAddUpdate = new List<ComboMealProductModel>();
            this.SelectedComboMealId = 0;

            if (PicBoxComboMealImage.Image != null)
            {
                PicBoxComboMealImage.Image.Dispose();
                PicBoxComboMealImage.ImageLocation = null;
                PicBoxComboMealImage.Image = null;
            }

            ClearProductListInComboMealTab();
        }


        private void CkBoxComboMealAutoGen_CheckedChanged(object sender, EventArgs e)
        {
            TboxComboMealBarcodeLbl.Enabled = !CkBoxComboMealAutoGen.Checked;
        }

        private void BtnSaveComboMeal_Click(object sender, EventArgs e)
        {
            if (this.IsNewComboMeal)
                this.ComboMealProductsToAddUpdate = new List<ComboMealProductModel>();

            foreach (DataGridViewRow row in this.DGVProductListForComboMeal.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectProductCkbox"].Value);

                long selectedProductId = long.Parse(row.Cells["ProductId"].Value.ToString());
                string qtyValueTmp = row.Cells["selectedProductQty"].Value != null ? row.Cells["selectedProductQty"].Value.ToString() : "";


                if (isSelected)
                {
                    if (string.IsNullOrWhiteSpace(qtyValueTmp))
                    {
                        MessageBox.Show("Kindly provide quantity for all selected products", "Product quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (int.TryParse(qtyValueTmp, out int qty) == false)
                    {
                        MessageBox.Show("Invalid quantity", "Product quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (qty <= 0)
                    {
                        MessageBox.Show("Kindly provide quantity for all selected products", "Product quantity", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    var existingProd = ComboMealProductsToAddUpdate.Where(x => x.ProductId == selectedProductId).FirstOrDefault();

                    if (existingProd == null)
                    {
                        ComboMealProductsToAddUpdate.Add(new ComboMealProductModel
                        {
                            Quantity = qty,
                            ProductId = selectedProductId
                        });
                    }
                    else
                    {
                        existingProd.Quantity = qty;
                    }
                }
                else
                {
                    if (ComboMealProductsToAddUpdate != null)
                    {
                        var existingProd = ComboMealProductsToAddUpdate.Where(x => x.ProductId == selectedProductId).FirstOrDefault();

                        if (existingProd != null)
                        {
                            existingProd.IsDeleted = true;
                            existingProd.DeletedAt = DateTime.Now;
                        }
                    }
                }
            }


            if (ComboMealProductsToAddUpdate.Count <= 1)
            {
                MessageBox.Show("Kindly select at least 2 products.", "Products", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(TboxComboMealTitle.Text))
            {
                MessageBox.Show("Kindly provide combo meal title", "Combo meal title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (NumUpDownComboMealPrice.Value <= 0)
            {
                MessageBox.Show("Kindly provide combo meal price", "Combo meal price", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (CkBoxComboMealAutoGen.Checked == false)
            {
                if (string.IsNullOrEmpty(TboxComboMealBarcodeLbl.Text))
                {
                    MessageBox.Show($"Provide combo meal barcode label.", "Product combo meal label", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (this.IsNewComboMeal)
            {
                if (this.ExistingComboMeals != null)
                {
                    var existingComboMeal = this.ExistingComboMeals.Where(x => x.Title.ToLower() == TboxComboMealTitle.Text.ToLower()).FirstOrDefault();

                    if (existingComboMeal != null)
                    {
                        MessageBox.Show($"Duplicate combo meal.", "Save new combo meal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this.ComboMealToAddUpdate = new ComboMealModel
                {
                    isBarcodeLblAutoGenerate = CkBoxComboMealAutoGen.Checked,
                    BarcodeLbl = TboxComboMealBarcodeLbl.Text,
                    Title = TboxComboMealTitle.Text,
                    Price = NumUpDownComboMealPrice.Value
                };

                OnSaveComboMeal(EventArgs.Empty);
            }
            else
            {
                if (this.ComboMealToAddUpdate != null)
                {
                    if (this.ExistingComboMeals != null)
                    {
                        var existingComboMeal = this.ExistingComboMeals.Where(x => 
                                                        x.Title.ToLower() == TboxComboMealTitle.Text.ToLower() &&
                                                        x.Id != this.ComboMealToAddUpdate.Id).FirstOrDefault();

                        if (existingComboMeal != null)
                        {
                            MessageBox.Show($"Duplicate combo meal.", "Save combo meal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    this.ComboMealToAddUpdate.BarcodeLbl = TboxComboMealBarcodeLbl.Text;
                    this.ComboMealToAddUpdate.Title = TboxComboMealTitle.Text;
                    this.ComboMealToAddUpdate.Price = NumUpDownComboMealPrice.Value;
                    OnSaveComboMeal(EventArgs.Empty);
                }
            }
        }

        private List<ComboMealModel> _comboMeals;

        public List<ComboMealModel> ExistingComboMeals
        {
            get { return _comboMeals; }
            set { _comboMeals = value; }
        }

        public void DisplayComboMealsInDGV(List<ComboMealModel> comboMealsToDisplay)
        {
            this.DGVComboMealList.Rows.Clear();

            if (comboMealsToDisplay != null)
            {
                this.DGVComboMealList.ColumnCount = 5;

                this.DGVComboMealList.Columns[0].Name = "ComboMealId";
                this.DGVComboMealList.Columns[0].Visible = false;

                this.DGVComboMealList.Columns[1].Name = "ComboMealBarcodeLbl";
                this.DGVComboMealList.Columns[1].HeaderText = "Barcode";

                this.DGVComboMealList.Columns[2].Name = "ComboMealTitle";
                this.DGVComboMealList.Columns[2].HeaderText = "Title";

                this.DGVComboMealList.Columns[3].Name = "ComboMealPrice";
                this.DGVComboMealList.Columns[3].HeaderText = "Price";

                this.DGVComboMealList.Columns[4].Name = "ComboMealHaveImage";
                this.DGVComboMealList.Columns[4].HeaderText = "Image";

                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVComboMealList.Columns.Add(btnUpdateImg);

                // Delete button
                DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVComboMealList.Columns.Add(btnDeleteImg);

                foreach (var item in comboMealsToDisplay)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVComboMealList);

                    row.Cells[0].Value = item.Id;
                    row.Cells[0].ReadOnly = true;

                    row.Cells[1].Value = item.BarcodeLbl;
                    row.Cells[1].ReadOnly = true;

                    row.Cells[2].Value = item.Title;
                    row.Cells[2].ReadOnly = true;

                    row.Cells[3].Value = item.Price;
                    row.Cells[3].ReadOnly = true;

                    row.Cells[4].Value = string.IsNullOrEmpty(item.BarcodeLbl) ? "N" : "Y";
                    row.Cells[4].ReadOnly = true;

                    this.DGVComboMealList.Rows.Add(row);
                }
            }
        }


        public void DisplayComboMealProducts(List<ComboMealProductModel> comboMealProducts)
        {
            this.DGVComboMealExistingProducts.Rows.Clear();

            if (comboMealProducts != null)
            {
                this.DGVComboMealExistingProducts.ColumnCount = 5;

                this.DGVComboMealExistingProducts.Columns[0].Name = "ProductId";
                this.DGVComboMealExistingProducts.Columns[0].Visible = false;

                this.DGVComboMealExistingProducts.Columns[1].Name = "Category";
                this.DGVComboMealExistingProducts.Columns[1].HeaderText = "Category";

                this.DGVComboMealExistingProducts.Columns[2].Name = "ProductName";
                this.DGVComboMealExistingProducts.Columns[2].HeaderText = "Name";

                this.DGVComboMealExistingProducts.Columns[3].Name = "PricePerOrder";
                this.DGVComboMealExistingProducts.Columns[3].HeaderText = "Price per order";

                this.DGVComboMealExistingProducts.Columns[4].Name = "Quantity";
                this.DGVComboMealExistingProducts.Columns[4].HeaderText = "Quantity";

                foreach (var item in comboMealProducts)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVComboMealExistingProducts);

                    row.Cells[0].Value = item.Id;
                    row.Cells[0].ReadOnly = true;

                    row.Cells[1].Value = item.Product.Category.ProdCategory;
                    row.Cells[1].ReadOnly = true;

                    row.Cells[2].Value = item.Product.ProdName;
                    row.Cells[2].ReadOnly = true;

                    row.Cells[3].Value = item.Product.PricePerOrder;
                    row.Cells[3].ReadOnly = true;

                    row.Cells[4].Value = item.Quantity;
                    row.Cells[4].ReadOnly = true;

                    this.DGVComboMealExistingProducts.Rows.Add(row);
                }
            }
        }


        public event EventHandler DeleteComboMeal;
        protected virtual void OnDeleteComboMeal(EventArgs e)
        {
            DeleteComboMeal?.Invoke(this, e);
        }

        private void DGVComboMealList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && this.ExistingComboMeals != null)
            {
                long comboMealId = long.Parse(DGVComboMealList.CurrentRow.Cells[0].Value.ToString());

                var comboMealProducts = this.ExistingComboMeals.Where(x => x.Id == comboMealId).Select(x => x.Products).FirstOrDefault();

                DisplayComboMealProducts(comboMealProducts);
            }

            // update button
            if ((e.ColumnIndex == 5) && e.RowIndex > -1 && this.ExistingComboMeals != null)
            {
                if (DGVComboMealList.CurrentRow != null)
                {
                    ClearComboMealForm();

                    long comboMealId = long.Parse(DGVComboMealList.CurrentRow.Cells[0].Value.ToString());

                    var existingComboMeal = this.ExistingComboMeals.Where(x => x.Id == comboMealId).FirstOrDefault();
                    var comboMealProducts = existingComboMeal.Products;

                    this.IsNewComboMeal = false;
                    this.ComboMealToAddUpdate = existingComboMeal;
                    this.ComboMealProductsToAddUpdate = comboMealProducts;

                    if (this.ComboMealToAddUpdate != null)
                    {
                        this.TboxComboMealBarcodeLbl.Text = this.ComboMealToAddUpdate.BarcodeLbl;
                        this.TboxComboMealTitle.Text = this.ComboMealToAddUpdate.Title;
                        this.NumUpDownComboMealPrice.Value = this.ComboMealToAddUpdate.Price;

                        string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        var comboMealImgsDirInfo = Directory.CreateDirectory($"{appPath}{_otherSettings.ComboMealImgsFileDirName}");

                        if (PicBoxComboMealImage.Image != null)
                        {
                            PicBoxComboMealImage.Image.Dispose();
                            PicBoxComboMealImage.ImageLocation = null;
                            PicBoxComboMealImage.Image = null;
                        }

                        if (comboMealImgsDirInfo.Exists)
                        {
                            string empImgPath = $"{appPath}\\{_otherSettings.ComboMealImgsFileDirName}\\{this.ComboMealToAddUpdate.ImageFilename}";

                            if (File.Exists(empImgPath))
                            {
                                PicBoxComboMealImage.Image = new Bitmap(empImgPath);
                                PicBoxComboMealImage.SizeMode = PictureBoxSizeMode.StretchImage;
                            }
                        }

                        foreach (DataGridViewRow row in this.DGVProductListForComboMeal.Rows)
                        {
                            long selectedProductId = long.Parse(row.Cells["ProductId"].Value.ToString());

                            var comboMealProdTmp = this.ComboMealProductsToAddUpdate.Where(x => x.ProductId == selectedProductId).FirstOrDefault();

                            if (comboMealProdTmp != null)
                            {
                                row.Cells["selectProductCkbox"].Value = (bool)true;
                                row.Cells["selectedProductQty"].Value = comboMealProdTmp.Quantity;
                            }
                        }


                        this.TabControlComboMeals.SelectedIndex = this.TabControlComboMeals.TabPages.IndexOf(TabComboMealAddUpdate);
                    }
                }
            }


            // Delete button
            if ((e.ColumnIndex == 6) && e.RowIndex > -1 && this.ExistingComboMeals != null)
            {
                this.SelectedComboMealId = long.Parse(DGVComboMealList.CurrentRow.Cells[0].Value.ToString());
                OnDeleteComboMeal(EventArgs.Empty);
            }
        }

        private void BtnCancelSaveComboMeal_Click(object sender, EventArgs e)
        {
            ClearComboMealForm();
        }

        private void BtnBrowseProductImage_Click(object sender, EventArgs e)
        {
            ProductImageBrowser.InitialDirectory = "C://Desktop";
            ProductImageBrowser.Title = "Select image to be update.";
            ProductImageBrowser.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            ProductImageBrowser.FilterIndex = 1;

            try
            {
                if (ProductImageBrowser.ShowDialog() == DialogResult.OK)
                {
                    if (ProductImageBrowser.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(ProductImageBrowser.FileName);
                        //label1.Text = path;
                        PicBoxProductImage.Image = new Bitmap(ProductImageBrowser.FileName);
                        PicBoxProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }

        public string UploadProductImage(string barcodeLbl)
        {
            try
            {
                if (ProductImageBrowser.CheckFileExists)
                {
                    string filename = Path.GetFileName(ProductImageBrowser.FileName);
                    string fileExt = Path.GetExtension(ProductImageBrowser.FileName);
                    if (filename != null && fileExt != null && File.Exists(ProductImageBrowser.FileName))
                    {
                        string productImgsDirName = $"\\{_otherSettings.ProductImgsFileDirName}\\";

                        string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                        var directoryInfo = Directory.CreateDirectory($"{appPath}{productImgsDirName}");

                        string newFileName = $"{barcodeLbl}{fileExt}";

                        string fullUploadPath = $"{appPath}{productImgsDirName}{newFileName}";

                        if (directoryInfo.Exists && File.Exists(fullUploadPath) == true)
                        {
                            return newFileName;
                            //File.Delete(fullUploadPath);
                        }

                        if (directoryInfo.Exists && File.Exists(fullUploadPath) == false)
                        {
                            System.IO.File.Copy(ProductImageBrowser.FileName, fullUploadPath, true);
                            MessageBox.Show("Image uploaded successfully.", "Upload image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return newFileName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ ex.Message } { ex.StackTrace }", "File Already exits");
            }
            return "";
        }

        private void BtnBrowserComboMealImage_Click(object sender, EventArgs e)
        {
            ComboMealImageBrowser.InitialDirectory = "C://Desktop";
            ComboMealImageBrowser.Title = "Select image to be update.";
            ComboMealImageBrowser.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            ComboMealImageBrowser.FilterIndex = 1;

            try
            {
                if (ComboMealImageBrowser.ShowDialog() == DialogResult.OK)
                {
                    if (ComboMealImageBrowser.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(ComboMealImageBrowser.FileName);
                        //label1.Text = path;
                        PicBoxComboMealImage.Image = new Bitmap(ComboMealImageBrowser.FileName);
                        PicBoxComboMealImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }


        public string UploadComboMealImage(string barcodeLbl)
        {
            try
            {
                if (ComboMealImageBrowser.CheckFileExists)
                {
                    string filename = Path.GetFileName(ComboMealImageBrowser.FileName);
                    string fileExt = Path.GetExtension(ComboMealImageBrowser.FileName);
                    if (filename != null && fileExt != null && File.Exists(ComboMealImageBrowser.FileName))
                    {
                        string ImgsDirName = $"\\{_otherSettings.ComboMealImgsFileDirName}\\";

                        string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                        var directoryInfo = Directory.CreateDirectory($"{appPath}{ImgsDirName}");

                        string newFileName = $"{barcodeLbl}{fileExt}";

                        string fullUploadPath = $"{appPath}{ImgsDirName}{newFileName}";

                        if (directoryInfo.Exists && File.Exists(fullUploadPath) == true)
                        {
                            return newFileName;
                        }

                        if (directoryInfo.Exists && File.Exists(fullUploadPath) == false)
                        {
                            System.IO.File.Copy(ComboMealImageBrowser.FileName, fullUploadPath, true);
                            MessageBox.Show("Image uploaded successfully.", "Upload image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return newFileName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ ex.Message } { ex.StackTrace }", "File Already exits");
            }
            return "";
        }

    }
}
