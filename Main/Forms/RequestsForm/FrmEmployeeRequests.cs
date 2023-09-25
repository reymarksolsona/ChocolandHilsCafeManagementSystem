using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.PayrollManagement.Contracts;
using EntitiesShared;
using Main.Controllers.RequestControllers.ControllerInterface;
using Main.Forms.RequestsForm.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.RequestsForm
{
    public partial class FrmEmployeeRequests : Form
    {
        private readonly Sessions _sessions;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeCashAdvanceRequestController _employeeCashAdvanceRequestController;
        private readonly IEmployeeCashAdvanceRequestData _employeeCashAdvanceRequestData;

        public FrmEmployeeRequests(Sessions sessions,
                                    IEmployeeData employeeData,
                                    IEmployeeCashAdvanceRequestController employeeCashAdvanceRequestController,
                                    IEmployeeCashAdvanceRequestData employeeCashAdvanceRequestData)
        {
            InitializeComponent();
            _sessions = sessions;
            _employeeData = employeeData;
            _employeeCashAdvanceRequestController = employeeCashAdvanceRequestController;
            _employeeCashAdvanceRequestData = employeeCashAdvanceRequestData;
        }

        private void CMenuCashAdvance_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "RequestCashAdvanceMenuItem")
            {
                DisplayRequestCashAdvanceFormControl();
            }
            else if (clickedItem != null && clickedItem.Name == "CashAdvanceApprovalMenuItem")
            {
                if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.admin)
                {
                    DisplayRequestCashAdvanceListControl();
                }
                else
                {
                    MessageBox.Show("Unauthorized request", "View pending cash advance request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void DisplayRequestCashAdvanceFormControl()
        {
            this.RequestsMainPanel.Controls.Clear();
            var requestControlObj = new RequestCashAdvanceFormControl(_sessions);
            requestControlObj.Location = new Point(this.ClientSize.Width / 2 - requestControlObj.Size.Width / 2, this.ClientSize.Height / 2 - requestControlObj.Size.Height / 2);
            requestControlObj.Anchor = AnchorStyles.None;

            requestControlObj.CashAdvanceSave += HandleSaveCashAdvanceRequest;
            requestControlObj.EnterEmployeeNumber += HandleOnEnterEmployeeNumber;
            requestControlObj.CancelRequest += HandleDeleteCashAdvanceRequest;

            string currEmpNumber = _sessions.CurrentLoggedInUser.UserName;

            requestControlObj.CurrentEmployeeNumber = currEmpNumber;
            requestControlObj.CurrentEmployeeDetails = _employeeData.GetByEmployeeNumber(currEmpNumber);
            requestControlObj.PreviousCashAdvanceRequests = _employeeCashAdvanceRequestData.GetAllNotDeletedByEmployee(currEmpNumber);

            this.RequestsMainPanel.Controls.Add(requestControlObj);
        }

        private void HandleOnEnterEmployeeNumber(object sender, EventArgs e)
        {
            RequestCashAdvanceFormControl requestControlObj = (RequestCashAdvanceFormControl)sender;

            requestControlObj.ResetForm();
            requestControlObj.CurrentEmployeeDetails = _employeeData.GetByEmployeeNumber(requestControlObj.CurrentEmployeeNumber);
            requestControlObj.PreviousCashAdvanceRequests = _employeeCashAdvanceRequestData.GetAllNotDeletedByEmployee(requestControlObj.CurrentEmployeeNumber);
            requestControlObj.DisplayPreviousCashAdvanceRequests();
            requestControlObj.DisplayEmployeeDetails();
        }

        private void HandleSaveCashAdvanceRequest(object sender, EventArgs e)
        {
            RequestCashAdvanceFormControl requestControlObj = (RequestCashAdvanceFormControl)sender;

            var requestDetails = requestControlObj.CashAdvanceRequestToAddUpdate;
            var isNew = requestControlObj.IsSaveNew;

            var saveResults = _employeeCashAdvanceRequestController.Save(requestDetails, isNew);
            string resultMessages = "";
            foreach (var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Submit request details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                requestControlObj.ResetForm();
                requestControlObj.PreviousCashAdvanceRequests = _employeeCashAdvanceRequestData.GetAllNotDeletedByEmployee(requestControlObj.CurrentEmployeeNumber);
                requestControlObj.DisplayPreviousCashAdvanceRequests();
            }
            else
            {
                MessageBox.Show(resultMessages, "Submit request details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleDeleteCashAdvanceRequest(object sender, EventArgs e)
        {
            RequestCashAdvanceFormControl requestControlObj = (RequestCashAdvanceFormControl)sender;
            long requestId = requestControlObj.SelectedRequestIdToDelete;

            DialogResult res = MessageBox.Show("Are you sure, you want to cancel this request?", "Cancel confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                var deleteResults = _employeeCashAdvanceRequestController.CancelRequest(requestId);
                string resultMessages = "";
                foreach (var msg in deleteResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (deleteResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Cancel request", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    requestControlObj.ResetForm();
                    requestControlObj.PreviousCashAdvanceRequests = _employeeCashAdvanceRequestData.GetAllNotDeletedByEmployee(requestControlObj.CurrentEmployeeNumber);
                    requestControlObj.DisplayPreviousCashAdvanceRequests();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Cancel request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }


        public void DisplayRequestCashAdvanceListControl()
        {
            this.RequestsMainPanel.Controls.Clear();
            var requestControlObj = new CashAdvanceForApprovalControl(_sessions);
            requestControlObj.Location = new Point(this.ClientSize.Width / 2 - requestControlObj.Size.Width / 2, this.ClientSize.Height / 2 - requestControlObj.Size.Height / 2);
            requestControlObj.Anchor = AnchorStyles.None;

            requestControlObj.RequestApproval += HandleRequestApproval;

            requestControlObj.Requests = _employeeCashAdvanceRequestData.GetAllNotDeletedByStatus(StaticData.EmployeeRequestApprovalStatus.Pending);

            this.RequestsMainPanel.Controls.Add(requestControlObj);
        }

        private void HandleRequestApproval(object sender, EventArgs e)
        {
            CashAdvanceForApprovalControl requestControlObj = (CashAdvanceForApprovalControl)sender;

            long requestId = requestControlObj.SelectedRequestId;
            string remarks = requestControlObj.AdminRemarks;
            DateTime cashReleaseDate = requestControlObj.CashReleaseDate;
            StaticData.EmployeeRequestApprovalStatus approvalStatus = requestControlObj.ApprovalStatus;

            DialogResult res = MessageBox.Show($"Continue to {approvalStatus} this request?", $"{approvalStatus} confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                var approvalResults = _employeeCashAdvanceRequestController.Approval(requestId, approvalStatus, remarks, cashReleaseDate);
                string resultMessages = "";
                foreach (var msg in approvalResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (approvalResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, $"Request {approvalStatus}", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    requestControlObj.Requests = _employeeCashAdvanceRequestData.GetAllNotDeletedByStatus(StaticData.EmployeeRequestApprovalStatus.Pending);
                    requestControlObj.DisplayCashAdvanceRequests();
                }
                else
                {
                    MessageBox.Show(resultMessages, $"Request {approvalStatus}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    }
}
