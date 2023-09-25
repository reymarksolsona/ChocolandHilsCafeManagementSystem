using EntitiesShared.InventoryManagement;
using Main.Controllers.InventoryControllers;
using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class FrmEnterProductQuantity : Form
    {
        public FrmEnterProductQuantity(ProductModel product, 
                                        OtherSettings otherSettings,
                                    IIngredientInventoryManager ingredientInventoryManager,
                                    List<ProductIngredientModel> ExistingProductIngredients,
                                    int quantity)
        {
            InitializeComponent();

            Product = product;
            _otherSettings = otherSettings;
            _ingredientInventoryManager = ingredientInventoryManager;
            _existingProductIngredients = ExistingProductIngredients;
            _quantity = quantity;
        }

        private ProductModel product;
        private readonly OtherSettings _otherSettings;
        private readonly IIngredientInventoryManager _ingredientInventoryManager;
        private readonly List<ProductIngredientModel> _existingProductIngredients;
        private readonly int _quantity;

        public ProductModel Product
        {
            get { return product; }
            set { product = value; }
        }


        public int Quantity { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsCanContinue { get; set; } = true;

        private void FrmEnterProductQuantity_Load(object sender, EventArgs e)
        {
            this.NumUpDownOrderQty.Value = _quantity;
            this.NumUpDownOrderQty.Focus();
            NumUpDownOrderQty.Select(0, this.NumUpDownOrderQty.Value.ToString().Length);

            if (this.Product != null)
            {
                this.LblProductName.Text = this.Product.ProdName;
                this.LblProductPrice.Text = this.Product.PricePerOrder.ToString("0.##");
            }

            string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var ProductImgsDirInfo = Directory.CreateDirectory($"{appPath}{_otherSettings.ProductImgsFileDirName}");

            if (ProductImgsDirInfo.Exists)
            {
                string empImgPath = $"{appPath}\\{_otherSettings.ProductImgsFileDirName}\\{this.Product.ImageFilename}";

                if (File.Exists(empImgPath))
                {
                    PicBoxProductImage.Image = new Bitmap(empImgPath);
                    PicBoxProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }


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

            // ingredients
            this.DisplayProductsExistingIngredientsInDGV(_existingProductIngredients, _quantity);
        }

        private void NumUpDownOrderQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (NumUpDownOrderQty.Value > 0)
            {
                IsCanContinue = true;
                Quantity = Convert.ToInt32(NumUpDownOrderQty.Value);

                DisplayProductsExistingIngredientsInDGV(_existingProductIngredients, Quantity);

                if (e.KeyCode == Keys.Enter)
                {
                    if (IsCanContinue == false)
                    {
                        MessageBox.Show("Not enough inventory for some of the ingredients for this product", "Not enough inventory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter quantity", "Invalid quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            IsCancelled = true;
            IsCanContinue = false;
            this.Close();
        }


        public void DisplayProductsExistingIngredientsInDGV(List<ProductIngredientModel> ExistingProductIngredients, int qty)
        {
            this.DGVProductExistingIngredients.Rows.Clear();

            if (ExistingProductIngredients != null)
            {
                this.DGVProductExistingIngredients.ColumnCount = 4;

                this.DGVProductExistingIngredients.Columns[0].Name = "ProductIngredientId";
                this.DGVProductExistingIngredients.Columns[0].Visible = false;

                this.DGVProductExistingIngredients.Columns[1].Name = "IngredientName";
                this.DGVProductExistingIngredients.Columns[1].HeaderText = "Ingredient";

                this.DGVProductExistingIngredients.Columns[2].Name = "InventoryQtyVal";
                this.DGVProductExistingIngredients.Columns[2].HeaderText = "Inventory";

                this.DGVProductExistingIngredients.Columns[3].Name = "Status";
                this.DGVProductExistingIngredients.Columns[3].HeaderText = "Status";

                foreach (var ingredient in ExistingProductIngredients)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVProductExistingIngredients);

                    row.Cells[0].Value = ingredient.Id;
                    row.Cells[0].ReadOnly = true;

                    row.Cells[1].Value = ingredient.Ingredient.IngName;
                    row.Cells[1].ReadOnly = true;

                    var orderQtyValueCost = ingredient.QtyValue * qty;
                    var properQtyValAndUOM = _ingredientInventoryManager.GetProperQtyValAndUOM(ingredient.UOM, orderQtyValueCost);

                    row.Cells[2].Value = $"{properQtyValAndUOM.Item2}{properQtyValAndUOM.Item1}"; // ex: 1kg
                    row.Cells[2].ReadOnly = true;

                    string inventoryStatusMsg = _ingredientInventoryManager.CheckIfEnoughInventory(ingredient.IngredientId, properQtyValAndUOM.Item2, properQtyValAndUOM.Item1);
                    row.Cells[3].Value = inventoryStatusMsg;

                    if (inventoryStatusMsg != "")
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        IsCanContinue = false;
                    }

                    this.DGVProductExistingIngredients.Rows.Add(row);
                }

                this.DGVProductExistingIngredients.ClearSelection();
            }
        }
    }
}
