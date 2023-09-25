using DataAccess.Data.InventoryManagement.Contracts;
using Shared.CustomModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.InventoryManagementForms.Controls
{
    public partial class FrmReassignIngredientsToOtherCategory : Form
    {
        private readonly IIngredientData _ingredientData;
        private readonly IIngredientCategoryData _ingredientCategoryData;

        public FrmReassignIngredientsToOtherCategory(IIngredientData ingredientData,
                                                    IIngredientCategoryData ingredientCategoryData,
                                                    long categoryIdToDelete)
        {
            InitializeComponent();
            _ingredientData = ingredientData;
            _ingredientCategoryData = ingredientCategoryData;
            CategoryIdToDelete = categoryIdToDelete;
        }


        public bool IsCancelled { get; set; } = false;
        public bool IsDone { get; set; }

        public long CategoryIdToDelete { get; set; }

        private void FrmReassignIngredientsToOtherCategory_Load(object sender, EventArgs e)
        {
            // exclude the category we are going to delete
            var categories = _ingredientCategoryData.GetAllNotDeleted().Where(x => x.Id != CategoryIdToDelete).ToList();

            if (categories != null && categories.Count > 0)
            {
                ComboboxItem item;

                foreach(var category in categories)
                {
                    item = new ComboboxItem();
                    item.Text = category.Category;
                    item.Value = category.Id;

                    this.CBoxCategories.Items.Add(item);
                }
            }

            var categoryToDeleteDetails = _ingredientCategoryData.Get(CategoryIdToDelete);

            if (categoryToDeleteDetails != null)
            {
                this.LblCategoryToDelete.Text = categoryToDeleteDetails.Category;
            }
        }

        private void BtnSubmitNewCategory_Click(object sender, EventArgs e)
        {
            if (this.CBoxCategories.SelectedIndex >= 0)
            {
                var selectedCategory = this.CBoxCategories.SelectedItem as ComboboxItem;

                if (selectedCategory != null)
                {
                    long selectedCategoryId = long.Parse(selectedCategory.Value.ToString());

                    bool isUpdated = _ingredientData.MassUpdateIngredientsCategory(CategoryIdToDelete, selectedCategoryId);

                    if (isUpdated == false)
                    {
                        this.IsCancelled = true;
                        this.IsDone = false;
                        MessageBox.Show("Unable to update ingredients category, see system log for possible errors and report this to developer.", "Update category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.IsCancelled = false;
                        this.IsDone = true;
                        this.Close();
                    }

                }
            }
        }

        private void BtnCancelUpdateCategory_Click(object sender, EventArgs e)
        {
            this.IsCancelled = true;
            this.IsDone = false;
            this.Close();
        }

        private void BtnForceDelete_Click(object sender, EventArgs e)
        {
            this.IsCancelled = false;
            this.IsDone = true;
            this.Close();
        }
    }
}
