﻿using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.PayrollManagement.Contracts;
using EntitiesShared;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Controllers.OtherDataController.ControllerInterface;
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
using static EntitiesShared.StaticData;

namespace Main.Forms.RequestsForm
{
    public partial class FrmEmployeeRequests : Form
    {
        private readonly Sessions _sessions;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeCashAdvanceRequestController _employeeCashAdvanceRequestController;
        private readonly IEmployeeCashAdvanceRequestData _employeeCashAdvanceRequestData;
        private readonly IEmployeeLeaveData _employeeLeaveData;
        private readonly IEmployeeLeaveController _employeeLeaveController;
        private readonly ILeaveTypeController _leaveTypeController;
        public event Action RefreshMainUI;

        public FrmEmployeeRequests(Sessions sessions,
                                    IEmployeeData employeeData,
                                    IEmployeeCashAdvanceRequestController employeeCashAdvanceRequestController,
                                    IEmployeeCashAdvanceRequestData employeeCashAdvanceRequestData,
                                    IEmployeeLeaveData employeeLeaveData,
                                    IEmployeeLeaveController employeeLeaveController,
                                    ILeaveTypeController leaveTypeController)
        {
            InitializeComponent();
            _sessions = sessions;
            _employeeData = employeeData;
            _employeeCashAdvanceRequestController = employeeCashAdvanceRequestController;
            _employeeCashAdvanceRequestData = employeeCashAdvanceRequestData;
            _employeeLeaveData = employeeLeaveData;
            _employeeLeaveController = employeeLeaveController;
            _leaveTypeController = leaveTypeController;
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

                RefreshUI();
            }

        }

        public void RefreshUI()
        {
            RefreshMainUI?.Invoke();
        }

        private void FrmEmployeeRequests_Load(object sender, EventArgs e)
        {
            if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.normal)
            {
                this.CashAdvanceMenus.DropDownItems.Remove(CashAdvanceApprovalMenuItem);
                this.leaveToolStripMenuItem.DropDownItems.Remove(approveLeaveToolStripMenuItem);
            }
        }

        private void requestLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayEmployeeRequestLeaveListControl();
        }

        public void DisplayEmployeeRequestLeaveListControl()
        {
            this.RequestsMainPanel.Controls.Clear();
            var requestControlObj = new RequestLeaveControl(_sessions);
            requestControlObj.Location = new Point(this.ClientSize.Width / 2 - requestControlObj.Size.Width / 2, this.ClientSize.Height / 2 - requestControlObj.Size.Height / 2);
            requestControlObj.Anchor = AnchorStyles.None;
            var empNumber = _sessions.CurrentLoggedInUser.UserName;

            int year = DateTime.Now.Year;
            requestControlObj.EmployeeRemainingLeaveFetch += HandleSearchingEmployeeRemainingLeaveCounts;

            requestControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(empNumber, year);
            requestControlObj.LeaveTypes = _leaveTypeController.GetAll().Data;
            requestControlObj.EmployeeLeaveSaved += HandleSaveEmployeeLeave;
            requestControlObj.DeleteEmployeeLeave += HandleDeleteEmployeeLeave;
            requestControlObj.FilterEmployeeLeave += HandleFilterEmployeeLeaveHistory;

            this.RequestsMainPanel.Controls.Add(requestControlObj);
        }

        private void HandleFilterEmployeeLeaveHistory(object sender, EventArgs e)
        {
            RequestLeaveControl controlToDisplay = (RequestLeaveControl)sender;
            var employeeNumber = controlToDisplay.EmployeeNumber;
            var year = controlToDisplay.FilterEmployeeLeaveHistoryYear;

            if (string.IsNullOrEmpty(employeeNumber) == false)
            {
                // search all leave by employee
                controlToDisplay.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(employeeNumber, year);
                controlToDisplay.DisplayEmployeeLeavesInDGV();
            }
        }

        private void HandleSaveEmployeeLeave(object sender, EventArgs e)
        {
            RequestLeaveControl controlToDisplay = (RequestLeaveControl)sender;
            var newEmployeeLeave = controlToDisplay.NewEmployeeLeave;

            if (newEmployeeLeave != null)
            {
                // for now, the transaction is always new
                var saveResults = _employeeLeaveController.Save(newEmployeeLeave, true);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save employee leave details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    controlToDisplay.ResetEmployeeFileLeaveForm();

                    // search all leave by employee
                    controlToDisplay.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(newEmployeeLeave.EmployeeNumber, DateTime.Now.Year);
                    controlToDisplay.DisplayEmployeeLeavesInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void HandleDeleteEmployeeLeave(object sender, EventArgs e)
        {
            RequestLeaveControl controlToDisplay = (RequestLeaveControl)sender;
            var employeeNumber = controlToDisplay.EmployeeNumber;
            var selectedEmployeeLeaveId = controlToDisplay.EmployeeLeaveIdToDelete;

            if (string.IsNullOrEmpty(employeeNumber) == false && selectedEmployeeLeaveId > 0)
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var saveResults = _employeeLeaveController.Delete(selectedEmployeeLeaveId, employeeNumber);

                    string resultMessages = "";
                    foreach (var msg in saveResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (saveResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete employee leave details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // search all leave by employee
                        controlToDisplay.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(employeeNumber, DateTime.Now.Year);
                        controlToDisplay.DisplayEmployeeLeavesInDGV();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete employee leave details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void HandleSearchingEmployeeRemainingLeaveCounts(object sender, EventArgs e)
        {
            RequestLeaveControl controlToDisplay = (RequestLeaveControl)sender;
            var selectedLeaveType = controlToDisplay.SelectedLeaveType;
            var employeeNumber = controlToDisplay.EmployeeNumber;

            if (selectedLeaveType != null && string.IsNullOrEmpty(employeeNumber) == false)
            {
                var empLeavesBySelectedLeave = _employeeLeaveData.GetAllByEmployeeNumberAndLeaveId(employeeNumber, selectedLeaveType.Id, DateTime.Now.Year);

                if (empLeavesBySelectedLeave != null && empLeavesBySelectedLeave.Count > 0)
                {
                    var lastEmpLeave = empLeavesBySelectedLeave.LastOrDefault();
                    decimal remainingLeave = lastEmpLeave.RemainingDays;
                    controlToDisplay.DisplayEmpRemainingLeaveCount(remainingLeave);
                }
                else
                {
                    controlToDisplay.DisplayEmpRemainingLeaveCount(selectedLeaveType.NumberOfDays);
                }
            }
        }

        public void DisplayRequestLeaveListControl()
        {
            this.RequestsMainPanel.Controls.Clear();
            var requestControlObj = new ApproveLeaveRequestControl(_sessions);
            requestControlObj.Location = new Point(this.ClientSize.Width / 2 - requestControlObj.Size.Width / 2, this.ClientSize.Height / 2 - requestControlObj.Size.Height / 2);
            requestControlObj.Anchor = AnchorStyles.None;

            requestControlObj.EmployeeLeaveApprovedOrDisapproved += HandleLeaveRequestApproval;

            requestControlObj.EmployeeLeaveForApproval = _employeeLeaveData.GetAllByStatus(EmployeeRequestApprovalStatus.Pending);

            this.RequestsMainPanel.Controls.Add(requestControlObj);
        }

        private void HandleLeaveRequestApproval(object sender, EventArgs e)
        {
            ApproveLeaveRequestControl employeeCRUDControlObj = (ApproveLeaveRequestControl)sender;
            string remarks = employeeCRUDControlObj.EmployeeLeaveApprovalRemarks;
            var employeeNumber = employeeCRUDControlObj.EmployeeNumber;
            long employeeLeaveId = employeeCRUDControlObj.SelectedLeaveIdForApproval;
            var approvalStatus = employeeCRUDControlObj.EmployeeLeaveApprovalStatus;

            var approvalResults = _employeeLeaveController.Approval(employeeLeaveId, employeeNumber, remarks, approvalStatus);

            string resultMessages = "";
            foreach (var msg in approvalResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (approvalResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Employee leave approval", MessageBoxButtons.OK, MessageBoxIcon.Information);

                employeeCRUDControlObj.EmployeeLeaveForApproval = _employeeLeaveData.GetAllByStatus(EmployeeRequestApprovalStatus.Pending);
                employeeCRUDControlObj.DisplayEmployeeLeavesForApprovalInDGV();
                employeeCRUDControlObj.ClearTextBox();
            }
            else
            {
                MessageBox.Show(resultMessages, "Employee leave approval", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            RefreshUI();
        }

        private void approveLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayRequestLeaveListControl();
        }
    }
}
