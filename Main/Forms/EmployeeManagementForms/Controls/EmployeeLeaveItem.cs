using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class EmployeeLeaveItem : UserControl
    {
        public EmployeeLeaveItem()
        {
            InitializeComponent();
        }

        private long leaveId;

        [Category("Leave Item Data")]
        public long LeaveId
        {
            get { return leaveId; }
            set { leaveId = value; }
        }

        private string leaveType;

        [Category("Leave Item Data")]
        public string LeaveType
        {
            get { return leaveType; }
            set { 
                leaveType = value;
                this.LblLeaveType.Text = value;
            }
        }

        private string createdAt;

        [Category("Leave Item Data")]
        public string CreatedAT
        {
            get { return createdAt; }
            set { 
                createdAt = value;
                this.LblCreatedAt.Text = value;
            }
        }

        private string duration;

        [Category("Leave Item Data")]
        public string Duration
        {
            get { return duration; }
            set { duration = value;

                this.LblDucation.Text = value;
            }
        }


        private string reason;

        [Category("Leave Item Data")]
        public string Reason
        {
            get { return reason; }
            set { reason = value;
                this.TbxLeaveReason.Text = value;
            }
        }

        public event EventHandler DeleteThisItem;
        protected virtual void OnDeleteThisItem(EventArgs e)
        {
            DeleteThisItem?.Invoke(this, e);
        }

        private void BtnDeleteEmployeeLeaveHistory_Click(object sender, EventArgs e)
        {
            OnDeleteThisItem(EventArgs.Empty);
        }
    }
}
