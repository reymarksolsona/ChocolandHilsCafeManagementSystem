using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.OtherDataManagement.Contracts;
using Main.Controllers.OtherDataController.ControllerInterface;
using Main.Forms.OtherDataForms.Controls;
using Main.Forms.OtherDataForms.OtherForms;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.OtherDataForms
{
    public partial class FrmOtherData : Form
    {
        private readonly ILogger<FrmOtherData> _logger;
        private readonly ILeaveTypeController _leaveTypeController;
        //private readonly IGovernmentController _governmentController;
        private readonly IBranchInfoController _branchInfoController;
        private readonly IBranchData _branchData;
        private readonly IEmployeeData _employeeData;

        public FrmOtherData(ILogger<FrmOtherData> logger,
                                ILeaveTypeController leaveTypeController,
                                //IGovernmentController governmentController,
                                IBranchInfoController branchInfoController,
                                IBranchData branchData,
                                IEmployeeData employeeData)
        {
            InitializeComponent();
            _logger = logger;
            _leaveTypeController = leaveTypeController;
            //_governmentController = governmentController;
            _branchInfoController = branchInfoController;
            _branchData = branchData;
            _employeeData = employeeData;
        }

        //private void ContextMenuGovernmentItems_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{

        //    ToolStripItem clickedItem = e.ClickedItem;

        //    if (clickedItem != null && clickedItem.Name == "GovernmentAgencieToolStripItem")
        //    {
        //        DisplayAddUpdateGovernmentAgency();
        //    }
        //}

        //private void DisplayAddUpdateGovernmentAgency()
        //{
        //    this.panelContainer.Controls.Clear();

        //    var governmentAgencyControlObj = new GovernmentAgenciesCRUDControl();
        //    //leaveTypeControl.Dock = DockStyle.Fill;
        //    governmentAgencyControlObj.Location = new Point(this.ClientSize.Width / 2 - governmentAgencyControlObj.Size.Width / 2, this.ClientSize.Height / 2 - governmentAgencyControlObj.Size.Height / 2);
        //    governmentAgencyControlObj.Anchor = AnchorStyles.None;

        //    governmentAgencyControlObj.GovernmentAgencies = _governmentController.GetAll().Data;
        //    governmentAgencyControlObj.GovernmentAgencySaved += HandleGovernmentAgencySaved;
        //    governmentAgencyControlObj.PropertySelectedGovernmentAgencyIdToUpdateChanged += OnGovtAgencySelectedToUpdate;
        //    governmentAgencyControlObj.PropertySelectedGovernmentAgencyIdToDeleteChanged += OnGovernmentAgencySelectToDelete;

        //    this.panelContainer.Controls.Add(governmentAgencyControlObj);
        //}


        //private void HandleGovernmentAgencySaved (object sender, EventArgs e)
        //{
        //    GovernmentAgenciesCRUDControl agencyControllerObj = (GovernmentAgenciesCRUDControl)sender;

        //    var saveResults = _governmentController.Save(agencyControllerObj.GovernmentAgencyToAddUpdate, agencyControllerObj.IsSaveNew);
        //    string resultMessages = "";
        //    foreach (var msg in saveResults.Messages)
        //    {
        //        resultMessages += msg + "\n";
        //    }

        //    if (saveResults.IsSuccess)
        //    {
        //        MessageBox.Show(resultMessages, "Save agency details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        agencyControllerObj.ResetForm();
        //        agencyControllerObj.GovernmentAgencies = _governmentController.GetAll().Data;
        //        agencyControllerObj.DisplayGovernmentAgencyList();
        //    }
        //    else
        //    {
        //        MessageBox.Show(resultMessages, "Save agency details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }

        //}

        //private void OnGovtAgencySelectedToUpdate (object sender, PropertyChangedEventArgs e)
        //{
        //    GovernmentAgenciesCRUDControl agencyControlObj = (GovernmentAgenciesCRUDControl)sender;
        //    var selectedAgencyId = agencyControlObj.SelectedGovernmentAgencyIdToUpdate;
        //    if (long.TryParse(selectedAgencyId, out long agencyId))
        //    {
        //        agencyControlObj.GovernmentAgencyToAddUpdate = _governmentController.GetById(agencyId).Data;
        //        agencyControlObj.DisplaySelectedGovernmentAgency();
        //    }
        //}

        //private void OnGovernmentAgencySelectToDelete(object sender, PropertyChangedEventArgs e)
        //{
        //    GovernmentAgenciesCRUDControl agencyControlObj = (GovernmentAgenciesCRUDControl)sender;
        //    var selectedAgencyId = agencyControlObj.SelectedGovernmentAgencyIdToDelete;
        //    if (long.TryParse(selectedAgencyId, out long agencyId))
        //    {
        //        DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        //        if (res == DialogResult.OK)
        //        {
        //            var deleteResults = _governmentController.Delete(agencyId);

        //            string resultMessages = "";
        //            foreach (var msg in deleteResults.Messages)
        //            {
        //                resultMessages += msg + "\n";
        //            }

        //            if (deleteResults.IsSuccess)
        //            {
        //                MessageBox.Show(resultMessages, "Delete Govt. agency", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                agencyControlObj.ResetForm();
        //                agencyControlObj.GovernmentAgencies = _governmentController.GetAll().Data;
        //                agencyControlObj.DisplayGovernmentAgencyList();
        //            }
        //            else
        //            {
        //                MessageBox.Show(resultMessages, "Delete Govt. agency", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //        }
        //    }
        //}

        // -----------------------------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------------------------

        private void ContextMenuScheduleSettings_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            ToolStripItem clickedItem = e.ClickedItem;
            if (clickedItem != null && clickedItem.Name == "ToolStripItemLeaveType")
            {
                DisplayLeaveTypesUserControl();
            }
        }

        private void DisplayLeaveTypesUserControl()
        {
            this.panelContainer.Controls.Clear();

            var leaveTypeControl = new LeaveTypeCRUDControl();
            //leaveTypeControl.Dock = DockStyle.Fill;
            leaveTypeControl.Location = new Point(this.ClientSize.Width / 2 - leaveTypeControl.Size.Width / 2, this.ClientSize.Height / 2 - leaveTypeControl.Size.Height / 2);
            leaveTypeControl.Anchor = AnchorStyles.None;

            leaveTypeControl.LeaveTypes = _leaveTypeController.GetAll().Data;
            leaveTypeControl.LeaveTypeSaved += HandleLeaveTypeSaved;

            leaveTypeControl.PropertySelectedLeaveTypeIdToUpdateChanged += OnLeaveTypeSelectToUpdate;
            leaveTypeControl.PropertySelectedLeaveTypeIdToDeleteChanged += OnLeaveTypeSelectToDelete;

            //userControlToDisplay.Employees = this._employeeController.GetAll().Data;
            //userControlToDisplay.DisplayEmployeeList();

            //userControlToDisplay.PropertyChanged += OnEmployeeViewDetails;

            this.panelContainer.Controls.Add(leaveTypeControl);
        }

        private void HandleLeaveTypeSaved(object sender, EventArgs e)
        {
            LeaveTypeCRUDControl leaveTypeControlObj = (LeaveTypeCRUDControl)sender;

            var saveResults = _leaveTypeController.Save(leaveTypeControlObj.LeaveTypeToAddUpdate, leaveTypeControlObj.IsSaveNew);
            string resultMessages = "";
            foreach (var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Save leave type details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                leaveTypeControlObj.ResetForm();
                leaveTypeControlObj.LeaveTypes = _leaveTypeController.GetAll().Data;
                leaveTypeControlObj.DisplayLeaveTypeList();

            }
            else
            {
                MessageBox.Show(resultMessages, "Save leave type details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OnLeaveTypeSelectToUpdate(object sender, PropertyChangedEventArgs e)
        {
            LeaveTypeCRUDControl userControlObj = (LeaveTypeCRUDControl)sender;
            var selectedLeaveTypeId = userControlObj.SelectedLeaveTypeToUpdateId;
            if (long.TryParse(selectedLeaveTypeId, out long leaveTypeId))
            {
                userControlObj.LeaveTypeToAddUpdate = _leaveTypeController.GetById(leaveTypeId).Data;
                userControlObj.DisplaySelectedLeaveType();
            }
        }

        private void OnLeaveTypeSelectToDelete(object sender, PropertyChangedEventArgs e)
        {
            LeaveTypeCRUDControl leaveTypeControlObj = (LeaveTypeCRUDControl)sender;
            var selectedLeaveTypeId = leaveTypeControlObj.SelectedLeaveTypeToDeleteId;
            if (long.TryParse(selectedLeaveTypeId, out long leaveTypeId))
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var deleteResults = _leaveTypeController.Delete(leaveTypeId);
                    string resultMessages = "";
                    foreach (var msg in deleteResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (deleteResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete leave type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        leaveTypeControlObj.ResetForm();
                        leaveTypeControlObj.LeaveTypes = _leaveTypeController.GetAll().Data;
                        leaveTypeControlObj.DisplayLeaveTypeList();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete leave type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }


        // ####################33
        private void ContextMenuBranchesSettings_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "ToolStripMenuBranchesList")
            {
                DisplayBranchCRUDControl();
            }
        }

        private void DisplayBranchCRUDControl()
        {
            this.panelContainer.Controls.Clear();

            var controlObj = new BranchInfoCRUDControl();
            //leaveTypeControl.Dock = DockStyle.Fill;
            controlObj.Location = new Point(this.ClientSize.Width / 2 - controlObj.Size.Width / 2, this.ClientSize.Height / 2 - controlObj.Size.Height / 2);
            controlObj.Anchor = AnchorStyles.None;

            controlObj.Branches = _branchData.GetAllNotDeleted();

            controlObj.BranchSaved += HandleBranchSaved;
            controlObj.DeleteBranch += HandleBranchDelete;

            this.panelContainer.Controls.Add(controlObj);
        }


        private void HandleBranchSaved(object sender, EventArgs e)
        {
            BranchInfoCRUDControl controlObj = (BranchInfoCRUDControl)sender;

            var branchDetails = controlObj.BranchToAddUpdate;
            bool isNew = controlObj.IsSaveNew;

            var saveResults = _branchInfoController.Save(branchDetails, isNew);
            string resultMessages = "";
            foreach (var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Save branch details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                controlObj.ResetForm();
                controlObj.Branches = _branchData.GetAllNotDeleted();
                controlObj.DisplayBranchList();
            }
            else
            {
                MessageBox.Show(resultMessages, "Save branch details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void HandleBranchDelete(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                BranchInfoCRUDControl controlObj = (BranchInfoCRUDControl)sender;

                long selectedBranchId = controlObj.SelectedBranchIdToDelete;


                FrmReassignEmployeesToNewBranch frmReassignEmployeesToNewBranch = new FrmReassignEmployeesToNewBranch(_employeeData, _branchData, selectedBranchId);
                frmReassignEmployeesToNewBranch.ShowDialog();
                bool continueToDeleteShift = (frmReassignEmployeesToNewBranch.IsDone == true && frmReassignEmployeesToNewBranch.IsCancelled == false);

                if (continueToDeleteShift)
                {
                    var saveResults = _branchInfoController.Delete(selectedBranchId);
                    string resultMessages = "";
                    foreach (var msg in saveResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (saveResults.IsSuccess)
                    {
                        // TODO: Reassign employees under this branch we are going to delete

                        MessageBox.Show(resultMessages, "Delete branch details.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        controlObj.ResetForm();
                        controlObj.Branches = _branchData.GetAllNotDeleted();
                        controlObj.DisplayBranchList();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete branch details.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

    }
}
