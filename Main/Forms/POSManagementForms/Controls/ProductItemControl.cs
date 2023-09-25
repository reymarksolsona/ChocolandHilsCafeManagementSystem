using EntitiesShared.InventoryManagement;
using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.POSManagementForms.Controls
{
    public partial class ProductItemControl : UserControl
    {
        public ProductItemControl(ProductModel product, OtherSettings otherSettings)
        {
            InitializeComponent();
            Product = product;
            _otherSettings = otherSettings;
        }

        private ProductModel product;
        private readonly OtherSettings _otherSettings;

        public ProductModel Product
        {
            get { return product; }
            set { product = value; }
        }


        public event EventHandler ClickThisProduct;
        protected virtual void OnClickThisProduct(EventArgs e)
        {
            ClickThisProduct?.Invoke(this, e);
        }

        private void ProductItemControl_Load(object sender, EventArgs e)
        {
            if (PicBoxProductImage.Image != null)
            {
                PicBoxProductImage.Image.Dispose();
                PicBoxProductImage.ImageLocation = null;
                PicBoxProductImage.Image = null;
            }

            if (this.Product != null)
            {
                this.LblProductName.Text = this.Product.ProdName;
                this.LblProductPrice.Text = this.Product.PricePerOrder.ToString("0.##");

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
            }

            initControlsRecursive(this.Controls);
        }

        private void initControlsRecursive(ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                c.MouseClick += (sender, e) => {
                    OnClickThisProduct(EventArgs.Empty);
                };
                initControlsRecursive(c.Controls);
            }
        }
    }
}
