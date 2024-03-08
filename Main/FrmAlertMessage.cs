using Main.Forms.EmployeeManagementForms;
using Main.Forms.InventoryManagementForms;
using Main.Forms.RequestsForm;
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
                    notificationItem.Click += NotificationItemClickHandler; 
                    notificationItem.Cursor = Cursors.Hand;
                    PanelNotifications.Controls.Add(notificationItem);
                }
            }
        }

        void NotificationItemClickHandler(object sender, EventArgs e)
        {
            string title = ((NotificationItemControl)sender).AlertMessage.Title.ToString();
            string empNumber = ((NotificationItemControl)sender).AlertMessage.EmpNum;
            if (title.Equals("Inventory ingredients expiration"))
            {
                ((MainFrm)this.Owner).HandleInventorySystemButtonClick();
                FrmInventory frmInventory = ((MainFrm)this.Owner)._frmInventory;
                frmInventory.DisplayIgredientInventoryControlAndMoveToExpireTab();
            } 
            else if (title.Equals("Cash Advance request"))
            {
                ((MainFrm)this.Owner).HandleRequestsButtonClick();
                FrmEmployeeRequests frmEmployeeRequests = ((MainFrm)this.Owner)._frmEmployeeRequests;
                frmEmployeeRequests.DisplayRequestCashAdvanceListControl();
            }
            else if (title.Equals("Leave request"))
            {
                ((MainFrm)this.Owner).HandleEmployeeButtonClick();
                FrmMainEmployeeManagement frmmainEmployeeManagement = ((MainFrm)this.Owner)._frmMainEmployeeManagement;
                frmmainEmployeeManagement.showEmpList(empNumber);
            }
            this.Close();
        }
    }
}
