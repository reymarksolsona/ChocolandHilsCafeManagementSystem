using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.InventoryManagement.Contracts;
using DataAccess.Data.PayrollManagement.Contracts;
using Main.Controllers.UserManagementControllers;
using Main.Forms.AttendanceTerminal;
using Main.Forms.EmployeeManagementForms;
using Main.Forms.InventoryManagementForms;
using Main.Forms.InventoryManagementForms.Controls;
using Main.Forms.OtherDataForms;
using Main.Forms.PayrollForms;
using Main.Forms.POSManagementForms;
using Main.Forms.RequestsForm;
using Main.Forms.SalesReport;
using Main.Forms.UserManagementForms;
using Microsoft.Extensions.Options;
using Shared;
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

namespace Main
{
    public partial class MainFrm : Form
    {
        private readonly Sessions _sessions;
        private readonly OtherSettings _otherSettings;
        internal FrmMainEmployeeManagement _frmMainEmployeeManagement;
        private readonly FrmOtherData _frmOtherData;
        private readonly FrmPayroll _payrollForm;
        private readonly FrmUserManagement _frmUserManagement;
        private readonly AttendanceTerminalForm _attendanceTerminalForm;
        internal FrmInventory _frmInventory;
        private readonly FrmMainPOSTerminal _frmMainPOSTerminal;
        private readonly FrmSalesReport _frmSalesReport;
        internal FrmEmployeeRequests _frmEmployeeRequests;
        private readonly HomeFrm _frmHome;
        private readonly IIngredientInventoryData _ingredientInventoryData;
        private readonly IEmployeeCashAdvanceRequestData _employeeCashAdvanceRequestData;
        private readonly IEmployeeLeaveData _employeeLeaveData;
        private readonly IUserController _userController;
        private Button currentButton;
        private Form activeForm;

        public MainFrm(Sessions sessions,
                        IOptions<OtherSettings> otherSettingsOptions,
                        FrmMainEmployeeManagement frmMainEmployeeManagement,
                        FrmOtherData frmOtherData,
                        FrmPayroll payrollForm,
                        FrmUserManagement frmUserManagement,
                        AttendanceTerminalForm attendanceTerminalForm,
                        FrmInventory frmInventory,
                        FrmMainPOSTerminal frmMainPOSTerminal,
                        FrmSalesReport frmSalesReport,
                        FrmEmployeeRequests frmEmployeeRequests,
                        HomeFrm frmHome,
                        IIngredientInventoryData ingredientInventoryData,
                        IEmployeeCashAdvanceRequestData employeeCashAdvanceRequestData,
                        IEmployeeLeaveData employeeLeaveData,
                        IUserController userController)
        {
            InitializeComponent();
            _sessions = sessions;
            _otherSettings = otherSettingsOptions.Value;
            _frmMainEmployeeManagement = frmMainEmployeeManagement;
            _frmOtherData = frmOtherData;
            _payrollForm = payrollForm;
            _frmUserManagement = frmUserManagement;
            _attendanceTerminalForm = attendanceTerminalForm;
            _frmInventory = frmInventory;
            _frmMainPOSTerminal = frmMainPOSTerminal;
            _frmSalesReport = frmSalesReport;
            _frmEmployeeRequests = frmEmployeeRequests;
            _frmHome = frmHome;
            _ingredientInventoryData = ingredientInventoryData;
            _employeeCashAdvanceRequestData = employeeCashAdvanceRequestData;
            _employeeLeaveData = employeeLeaveData;
            _userController = userController;
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sessions.CurrentLoggedInUser = null;
            Application.Exit();
        }


        public void DisplayHomeControl() {
        }


        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (_sessions != null && _sessions.CurrentLoggedInUser != null)
            {
                this.LblCurrentUserName.Text = _sessions.CurrentLoggedInUser.FullName;
                this.LblCurrentUserRoles.Text = _sessions.CurrentLoggedInUser.Role.Role.RoleKey.ToString();

                if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.cashier)
                {
                    this.BtnPayrollSystem.Enabled = false;
                    this.BtnInventorySystem.Enabled = false;
                    this.BtnSalesReportSystem.Enabled = false;
                    this.BtnUserMgnment.Enabled = false;
                    this.BtnOtherData.Enabled = false;
                }

                if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.manager)
                {
                    this.BtnPayrollSystem.Enabled = false;
                    this.BtnInventorySystem.Enabled = false;
                    this.BtnOtherData.Enabled = false;
                }

                if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.normal)
                {
                    this.BtnPayrollSystem.Enabled = false;
                    this.BtnInventorySystem.Enabled = false;
                    this.BtnSalesReportSystem.Enabled = false;
                    this.BtnPointOfSale.Enabled = false;
                    this.BtnUserMgnment.Enabled = false;
                    this.BtnOtherData.Enabled = false;
                }
            }

            if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == EntitiesShared.StaticData.UserRole.admin)
            {
                List<AlertMessage> alertMessages = new();

                DateTime startDate = DateTime.Now;
                DateTime endDate = startDate.AddDays(_otherSettings.NumDaysNotifyUserForInventoryExpDate);
                int notificationCountForInventory = _ingredientInventoryData.GetCountOfIngredientInventoryByExpirationDate(startDate, endDate);
                if (notificationCountForInventory > 0)
                {
                    this.BtnInventorySystem.Text = $"Inventory ({notificationCountForInventory})";
                    this.BtnInventorySystem.ForeColor = Color.Red;

                    string msg = $"{notificationCountForInventory} ingredient(s) inventory near on expiration date";
                    ToolTipForNavButtons.SetToolTip(this.BtnInventorySystem, msg);

                    alertMessages.Add(new AlertMessage { Title = "Inventory ingredients expiration", Message = msg });
                }

                var activeCashAdvanceRequests = _employeeCashAdvanceRequestData
                                        .GetAllNotDeletedByStatus(EntitiesShared.StaticData.EmployeeRequestApprovalStatus.Pending);

                if (activeCashAdvanceRequests != null && activeCashAdvanceRequests.Count > 0)
                {
                    this.BtnRequests.Text = $"Requests ({activeCashAdvanceRequests.Count})";
                    this.BtnRequests.ForeColor = Color.Red;

                    foreach (var request in activeCashAdvanceRequests)
                    {
                        alertMessages.Add(new AlertMessage
                        {
                            Title = "Cash Advance request",
                            Message = $"{request.Employee.FullName} request {request.Amount} cash advance"
                        });
                    }
                }

                var pendingEmpLeaveRequests = _employeeLeaveData.GetAllByStatus(EmployeeRequestApprovalStatus.Pending);

                if (pendingEmpLeaveRequests != null && pendingEmpLeaveRequests.Count > 0)
                {
                    this.BtnEmployeeManagementMenuItem.Text = $"Employees ({pendingEmpLeaveRequests.Count})";
                    this.BtnEmployeeManagementMenuItem.ForeColor = Color.Red;

                    foreach(var request in pendingEmpLeaveRequests)
                    {
                        alertMessages.Add(new AlertMessage
                        {
                            Title = "Leave request",
                            Message = $"{request.EmployeeNumber} - {request.DurationType}({request.Duration})",
                            EmpNum = request.EmployeeNumber
                        });
                    }
                }

                if (alertMessages != null && alertMessages.Count > 0)
                {
                    FrmAlertMessage frmAlertMessage = new();
                    frmAlertMessage.AlertMessages = alertMessages;
                    frmAlertMessage.Owner = this;
                    frmAlertMessage.ShowDialog();
                }
            }

            
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelSidebar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.Transparent;
                }
            }
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(42, 42, 64);
                    //btnCloseChildForm.Visible = true;
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Hide();

            ActivateButton(btnSender);

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMainBody.Controls.Add(childForm);
            this.panelMainBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            this.LblRenderedFormTitle.Text = childForm.Text;
        }

        private void BtnUserLogout_Click(object sender, EventArgs e)
        {
            _sessions.CurrentLoggedInUser = null;
            Application.Exit();
        }

        private void BtnEmployeeManagementMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmMainEmployeeManagement, sender);
        }

        private void BtnPayrollSystem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_payrollForm, sender);
        }

        private void BtnOtherData_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmOtherData, sender);
        }

        private void BtnUserMgnment_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmUserManagement, sender);

            _userController.GetAll();
        }

        private void BtnAttendanceTerminal_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Hide();

            ActivateButton(sender);

            activeForm = _attendanceTerminalForm;
            _attendanceTerminalForm.TopLevel = false;

            _attendanceTerminalForm.Location = new Point(this.panelMainBody.Width / 2 - _attendanceTerminalForm.Size.Width / 2, this.panelMainBody.Height / 2 - _attendanceTerminalForm.Size.Height / 2);
            _attendanceTerminalForm.Anchor = AnchorStyles.None;

            _attendanceTerminalForm.FormBorderStyle = FormBorderStyle.None;
            this.panelMainBody.Controls.Add(_attendanceTerminalForm);
            this.panelMainBody.Tag = _attendanceTerminalForm;
            _attendanceTerminalForm.BringToFront();
            _attendanceTerminalForm.Show();
            this.LblRenderedFormTitle.Text = _attendanceTerminalForm.Text;
        }

        private void BtnInventorySystem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmInventory, sender);
        }

        private void BtnGoToHomeFrm_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmHome, sender);
        }

        private void BtnPointOfSale_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmMainPOSTerminal, sender);
        }

        private void BtnToggleMenu_Click(object sender, EventArgs e)
        {
            if (panelSidebar.Width == 55)
            {
                panelSidebar.Width = 212;
                BtnToggleMenu.Image = Image.FromFile("./Resources/less-than-white-30.png");
            }
            else
            {
                BtnToggleMenu.Image = Image.FromFile("./Resources/more-than-white-30.png");
                panelSidebar.Width = 55;
            }
        }

        private void BtnSalesReportSystem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmSalesReport, sender);
        }

        private void BtnRequests_Click(object sender, EventArgs e)
        {
            OpenChildForm(_frmEmployeeRequests, sender);
        }

        public void HandleRequestsButtonClick()
        {
            // Actions to be performed when BtnRequests is clicked
            // For example:
            OpenChildForm(_frmEmployeeRequests, BtnRequests);
            _frmEmployeeRequests.Show();
        }

        public void HandleEmployeeButtonClick()
        {
            // Actions to be performed when BtnRequests is clicked
            // For example:
            OpenChildForm(_frmMainEmployeeManagement, BtnEmployeeManagementMenuItem);
            _frmMainEmployeeManagement.Show();
        }

        public void HandleInventorySystemButtonClick()
        {
            // Actions to be performed when BtnRequests is clicked
            // For example:
            OpenChildForm(_frmInventory, BtnInventorySystem);
            _frmInventory.Show();
        }
    }
}
