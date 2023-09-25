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
    public partial class RestaurantTableItemControl : UserControl
    {
        public RestaurantTableItemControl()
        {
            InitializeComponent();
        }

        public long TransactionId { get; set; }

        public bool IsOccupied { get; set; }

        public int TableNumber { get; set; }

        public string TableTitle { get; set; }

        public event EventHandler ClickThisTable;
        protected virtual void OnClickThisTable(EventArgs e)
        {
            ClickThisTable?.Invoke(this, e);
        }


        private void RestaurantTableItemControl_Load(object sender, EventArgs e)
        {
            if (PicBoxTableStatus.Image != null)
            {
                PicBoxTableStatus.Image.Dispose();
                PicBoxTableStatus.ImageLocation = null;
                PicBoxTableStatus.Image = null;
            }

            if (this.IsOccupied)
            {
                PicBoxTableStatus.Image = Image.FromFile("./Resources/restaurant-table-red-100.png");
                PicBoxTableStatus.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {

                PicBoxTableStatus.Image = Image.FromFile("./Resources/restaurant-table-green-100.png");
                PicBoxTableStatus.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            this.LblTableNumber.Text = this.TableTitle;

            this.initControlsRecursive(this.Controls);
        }


        private void initControlsRecursive(ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                c.MouseClick += (sender, e) => {
                    OnClickThisTable(EventArgs.Empty);
                };

                c.ContextMenuStrip = this.contextMenuStrip1;
                initControlsRecursive(c.Controls);
            }
        }

        public event EventHandler MarkThisTableAsAvailable;
        protected virtual void OnMarkThisTableAsAvailable(EventArgs e)
        {
            MarkThisTableAsAvailable?.Invoke(this, e);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "toolStripMenuItemEnableThisTable" && IsOccupied == true)
            {
                DialogResult dialogResult = MessageBox.Show("Continue to mark this table as available?", "Mark this table as available", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    OnMarkThisTableAsAvailable(EventArgs.Empty);
                }
            }
        }
    }
}
