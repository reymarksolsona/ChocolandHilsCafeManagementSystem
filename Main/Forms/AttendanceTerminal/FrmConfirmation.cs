using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.AttendanceTerminal
{
    public partial class FrmConfirmation : Form
    {
        public FrmConfirmation()
        {
            InitializeComponent();
        }

        public bool IsSuccess { get; set; } = false;

        private void FrmConfirmation_Load(object sender, EventArgs e)
        {
            if (this.IsSuccess)
            {
                PicBoxConfirmationImg.Image = Image.FromFile("./Resources/success.png");
            }
            else
            {
                PicBoxConfirmationImg.Image = Image.FromFile("./Resources/failed.png");
            }
            timer1.Interval = 2000;
            timer1.Tick += new EventHandler(timer_Tick);
            timer1.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
