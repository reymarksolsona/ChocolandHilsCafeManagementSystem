using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class BtnProductCategoryControl : UserControl
    {
        public BtnProductCategoryControl(ProductCategoryModel prodCategory)
        {
            InitializeComponent();

            ProductCategory = prodCategory;
        }


        private ProductCategoryModel _productCategory;

        public ProductCategoryModel ProductCategory
        {
            get { return _productCategory; }
            set { _productCategory = value; }
        }


        public event EventHandler ClickThisCategoryButton;
        protected virtual void OnClickThisCategoryButton(EventArgs e)
        {
            ClickThisCategoryButton?.Invoke(this, e);
        }

        private void BtnProductCategoryControl_Load(object sender, EventArgs e)
        {
            if (this.ProductCategory != null)
            {
                this.ButtonCategory.Text = this.ProductCategory.ProdCategory;
            }
        }

        private void ButtonCategory_Click(object sender, EventArgs e)
        {
            OnClickThisCategoryButton(EventArgs.Empty);
        }
    }
}
