using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class NotificationItemControl : UserControl
    {
        public NotificationItemControl()
        {
            InitializeComponent();
        }

        private AlertMessage alertMessage;

        public AlertMessage AlertMessage
        {
            get { return alertMessage; }
            set { alertMessage = value; }
        }

        private void NotificationItemControl_Load(object sender, EventArgs e)
        {
            if (this.AlertMessage != null)
            {
                this.LblTitle.Text = this.AlertMessage.Title;
                LblMessage.Text = this.AlertMessage.Message;
            }
        }
    }
}
