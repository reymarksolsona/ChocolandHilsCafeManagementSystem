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
    public partial class ComboMealItemControl : UserControl
    {
        public ComboMealItemControl(ComboMealModel comboMeal, OtherSettings otherSettings)
        {
            InitializeComponent();

            ComboMeal = comboMeal;
            _otherSettings = otherSettings;
        }

        private ComboMealModel _comboMeal;
        private readonly OtherSettings _otherSettings;

        public ComboMealModel ComboMeal
        {
            get { return _comboMeal; }
            set { _comboMeal = value; }
        }


        public event EventHandler ClickThisComboMeal;
        protected virtual void OnClickThisComboMeal(EventArgs e)
        {
            ClickThisComboMeal?.Invoke(this, e);
        }

        private void ComboMealItemControl_Load(object sender, EventArgs e)
        {
            if (PicBoxComboMealImage.Image != null)
            {
                PicBoxComboMealImage.Image.Dispose();
                PicBoxComboMealImage.ImageLocation = null;
                PicBoxComboMealImage.Image = null;
            }

            if (this.ComboMeal != null)
            {
                this.LblComboMealName.Text = this.ComboMeal.Title;
                this.LblComboMealPrice.Text = this.ComboMeal.Price.ToString("0.##");

                string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var ProductImgsDirInfo = Directory.CreateDirectory($"{appPath}{_otherSettings.ComboMealImgsFileDirName}");

                if (ProductImgsDirInfo.Exists)
                {
                    string empImgPath = $"{appPath}\\{_otherSettings.ComboMealImgsFileDirName}\\{this.ComboMeal.ImageFilename}";

                    if (File.Exists(empImgPath))
                    {
                        PicBoxComboMealImage.Image = new Bitmap(empImgPath);
                        PicBoxComboMealImage.SizeMode = PictureBoxSizeMode.StretchImage;
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
                    OnClickThisComboMeal(EventArgs.Empty);
                };
                initControlsRecursive(c.Controls);
            }
        }

    }
}
