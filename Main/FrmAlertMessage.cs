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
    public partial class FrmAlertMessage : Form
    {
        public FrmAlertMessage()
        {
            InitializeComponent();
        }

        private List<AlertMessage> alertMessages;

        public List<AlertMessage> AlertMessages
        {
            get { return alertMessages; }
            set { alertMessages = value; }
        }


        private void FrmAlertMessage_Load(object sender, EventArgs e)
        {
            if (this.AlertMessages != null)
            {
                foreach(var alertMsg in this.AlertMessages)
                {
                    var notificationItem = new NotificationItemControl();
                    notificationItem.AlertMessage = alertMsg;
                    notificationItem.Width = PanelNotifications.Width;
                    notificationItem.Dock = DockStyle.Top;
                    PanelNotifications.Controls.Add(notificationItem);
                }
            }
        }
    }
}
