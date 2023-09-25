using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Data.EmployeeManagement.Contracts;
using DataAccess.Data.OtherDataManagement.Contracts;
using DataAccess.Data.PayrollManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using Main.Controllers.EmployeeManagementControllers.ControllerInterface;
using Main.Controllers.OtherDataController.ControllerInterface;
using Main.Forms.EmployeeManagementForms.Controls;
using Main.Forms.EmployeeManagementForms.OtherForms;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PDFReportGenerators;
using Shared;
using Shared.Helpers;
using static EntitiesShared.StaticData;

namespace Main.Forms.EmployeeManagementForms
{
    public partial class FrmMainEmployeeManagement : Form
    {
        private readonly ILogger<FrmMainEmployeeManagement> _logger;
        private readonly Sessions _sessions;
        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;
        private readonly PayrollSettings _payrollSettings;
        private readonly OtherSettings _otherSettings;
        private readonly IEmployeeLeaveData _employeeLeaveData;
        private readonly IBranchData _branchData;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeeShiftData _employeeShiftData;
        private readonly IEmployeeShiftDayData _employeeShiftDayData;
        private readonly IEmployeeController _employeeController;
        private readonly IEmployeePayslipData _employeePayslipData;
        private readonly IWorkShiftController _workShiftController;
        private readonly ILeaveTypeController _leaveTypeController;
        private readonly IEmployeeLeaveController _employeeLeaveController;
        private readonly IHolidayController _holidayController;
        private readonly IHolidayData _holidayData;
        private readonly IEmployeeAttendanceData _employeeAttendanceData;
        private readonly IEmployeeBenefitsDeductionsController _employeeBenefitsDeductionsController;
        private readonly IEmployeeBenefitData _employeeBenefitData;
        private readonly ISpecificEmployeeBenefitData _specificEmployeeBenefitData;
        private readonly IEmployeeDeductionData _employeeDeductionData;
        private readonly ISpecificEmployeeDeductionData _specificEmployeeDeductionData;
        private readonly IWorkforceScheduleController _workforceScheduleController;
        private readonly IWorkforceScheduleData _workforceScheduleData;
        private readonly IEmployeePositionController _employeePositionController;
        private readonly IEmployeePositionData _employeePositionData;
        private readonly IAttendancePDFReport _attendancePDFReport;
        private readonly INumberOfWorkingDaysInAMonthData _numberOfWorkingDaysInAMonthData;
        private readonly IEmployeePayslipPDFReport _employeePayslipPDFReport;

        public FrmMainEmployeeManagement(ILogger<FrmMainEmployeeManagement> logger,
                                    Sessions sessions,
                                    DecimalMinutesToHrsConverter decimalMinutesToHrsConverter,
                                    IOptions<OtherSettings> otherSettingsOptions,
                                    IOptions<PayrollSettings> payrollSettingsOptions,
                                IEmployeeLeaveData employeeLeaveData,
                                IBranchData branchData,
                                IEmployeeData employeeData,
                                IEmployeeShiftData employeeShiftData,
                                IEmployeeShiftDayData employeeShiftDayData,
                                IEmployeeController employeeController,
                                IEmployeePayslipData employeePayslipData,
                                IWorkShiftController workShiftController,
                                ILeaveTypeController leaveTypeController,
                                IEmployeeLeaveController employeeLeaveController,
                                IHolidayController holidayController,
                                IHolidayData holidayData,
                                IEmployeeAttendanceData employeeAttendanceData,
                                IEmployeeBenefitsDeductionsController employeeBenefitsDeductionsController,
                                IEmployeeBenefitData employeeBenefitData,
                                ISpecificEmployeeBenefitData specificEmployeeBenefitData,
                                IEmployeeDeductionData employeeDeductionData,
                                ISpecificEmployeeDeductionData specificEmployeeDeductionData,
                                IWorkforceScheduleController workforceScheduleController,
                                IWorkforceScheduleData workforceScheduleData,
                                IEmployeePositionController employeePositionController,
                                IEmployeePositionData employeePositionData,
                                 IAttendancePDFReport attendancePDFReport,
                                 INumberOfWorkingDaysInAMonthData numberOfWorkingDaysInAMonthData,
                                 IEmployeePayslipPDFReport employeePayslipPDFReport)
        {
            InitializeComponent();
            _logger = logger;
            _sessions = sessions;
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
            _payrollSettings = payrollSettingsOptions.Value;
            _otherSettings = otherSettingsOptions.Value;
            _employeeLeaveData = employeeLeaveData;
            _branchData = branchData;
            _employeeData = employeeData;
            _employeeShiftData = employeeShiftData;
            _employeeShiftDayData = employeeShiftDayData;
            _employeeController = employeeController;
            _employeePayslipData = employeePayslipData;
            _workShiftController = workShiftController;
            _leaveTypeController = leaveTypeController;
            _employeeLeaveController = employeeLeaveController;
            _holidayController = holidayController;
            _holidayData = holidayData;
            _employeeAttendanceData = employeeAttendanceData;
            _employeeBenefitsDeductionsController = employeeBenefitsDeductionsController;
            _employeeBenefitData = employeeBenefitData;
            _specificEmployeeBenefitData = specificEmployeeBenefitData;
            _employeeDeductionData = employeeDeductionData;
            _specificEmployeeDeductionData = specificEmployeeDeductionData;
            _workforceScheduleController = workforceScheduleController;
            _workforceScheduleData = workforceScheduleData;
            _employeePositionController = employeePositionController;
            _employeePositionData = employeePositionData;
            _attendancePDFReport = attendancePDFReport;
            _numberOfWorkingDaysInAMonthData = numberOfWorkingDaysInAMonthData;
            _employeePayslipPDFReport = employeePayslipPDFReport;
        }

        private void EmployeeMenuItemsMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "ToolStripItem_DetailsCRUD")
            {
                // Add/update form
                DisplayAddUpdateEmployeeUserControl();
            }
            else if (clickedItem != null && clickedItem.Name == "ToolStripItem_List" && _sessions.CurrentLoggedInUser.Role.Role.RoleKey == UserRole.admin)
            {
                DisplayEmployeeListUserControl();
            }
            else if (clickedItem != null && clickedItem.Name == "ToolStripItem_Benefits_Deductions" && _sessions.CurrentLoggedInUser.Role.Role.RoleKey == UserRole.admin)
            {
                DisplayBenefitDeductionCRUDControl();
            }
            else if (clickedItem != null && clickedItem.Name == "ToolStripItem_PositionAndSalaryRate" && _sessions.CurrentLoggedInUser.Role.Role.RoleKey == UserRole.admin)
            {
                DisplayEmpPositionWithSalaryRateCRUDControl();
            }
        }

        private void PayrollMenuItems_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (clickedItem != null && clickedItem.Name == "")
            {
            }
        }

        #region Add/Update employee confirmation user control related methods event handlers


        private void HandleBackToForm(object sender, EventArgs e)
        {
            DisplayAddUpdateEmployeeUserControl();
        }

        #endregion


        #region Add/Update employee user control related methods and event handlers

        private void DisplayAddUpdateEmployeeUserControl(string defaultEmployeeNum = "")
        {
            this.panelContainer.Controls.Clear();

            var controlToDisplay = new EmployeeDetailsCRUDControl(_sessions, _decimalMinutesToHrsConverter, _otherSettings, _payrollSettings, _attendancePDFReport);
            //controlToDisplay.Dock = DockStyle.Fill;
            controlToDisplay.Location = new Point(this.ClientSize.Width / 2 - controlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - controlToDisplay.Size.Height / 2);
            //controlToDisplay.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left);

            controlToDisplay.LeaveTypes = _leaveTypeController.GetAll().Data;
            //controlToDisplay.GovtAgencies = _governmentAgencyData.GetAllNotDeleted();
            controlToDisplay.WorkShifts = _workShiftController.GetAll().Data;
            controlToDisplay.Branches = _branchData.GetAllNotDeleted();
            controlToDisplay.Positions = _employeePositionData.GetAllNotDeleted();
            // TODO: add the existing emp. govt. ids from our database and use the CustomModels -> EmployeeGovtIdCardTempModel.cs

            // event added
            controlToDisplay.EmployeeSaved += this.HandleEmployeeSaved;
            controlToDisplay.PropertyChanged += this.OnEmployeeNumberEnter;
            controlToDisplay.WorkShiftSelected += HandleSelectedWorkShiftToGetOtherInfo;
            controlToDisplay.FilterEmployeeAttendance += HandleFilterEmployeeAttendance;
            controlToDisplay.FilterEmployeePayslip += HandleFilterEmployeePayslip;
            controlToDisplay.EmployeeRemainingLeaveFetch += HandleSearchingEmployeeRemainingLeaveCounts;
            controlToDisplay.EmployeeLeaveSaved += HandleSaveEmployeeLeave;
            controlToDisplay.DeleteEmployeeLeave += HandleDeleteEmployeeLeave;
            controlToDisplay.FilterEmployeeLeave += HandleFilterEmployeeLeaveHistory;
            controlToDisplay.EmployeeLeaveApprovedOrDisapproved += ControlToDisplay_EmployeeLeaveApproval;
            controlToDisplay.GeneratePayslipPDFForSelectedEmployee += ControlToDisplay_GeneratePayslipPDFForSelectedEmployee;

            controlToDisplay.UndoMarkEmployeeAsResigned += HandleUndoMarkEmployeeAsResigned;
            controlToDisplay.MarkEmployeeAsResigned += HandleMarkEmployeeAsResigned;
            controlToDisplay.MarkEmployeeAsDeleted += HandleMarkEmployeeAsDeleted;

            this.panelContainer.Controls.Add(controlToDisplay);

            if (string.IsNullOrEmpty(defaultEmployeeNum) == false)
            {
                controlToDisplay.UpdateEmployeeDetails();
                controlToDisplay.TbxEmployeeNumber.Text = defaultEmployeeNum;
                controlToDisplay.EmployeeNumber = defaultEmployeeNum;
                //controlToDisplay.EmployeeNumber = defaultEmployeeNum;
            }

        }

        private void ControlToDisplay_GeneratePayslipPDFForSelectedEmployee(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            var paydate = employeeCRUDControlObj.SelectedDateForPayslipToGeneratePDF;
            string employeeNumber = employeeCRUDControlObj.EmployeeNumber;

            var payslip = _employeePayslipData.GetEmployeePayslipRecordByPaydate(employeeNumber, paydate);

            if (payslip != null)
            {
                _employeePayslipPDFReport.GenerateEmployeePayslip(payslip);
                MessageBox.Show($"Kindly check the generated pdf to {_payrollSettings.GeneratedPDFLoc}.", "Generated PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HandleEmployeeSaved(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;

            var saveResults = _employeeController.SaveEmployeeDetails(employeeCRUDControlObj.IsNew,
                                                                      employeeCRUDControlObj.Employee,
                                                                       employeeCRUDControlObj.EmployeeGovtIdCards);

            string resultMessages = "";
            foreach (var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (employeeCRUDControlObj.IsNew)
                {
                    MessageBox.Show($"{saveResults.Data.Employee.FullName} employee number is {saveResults.Data.Employee.EmployeeNumber}", "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                string imageFileName = employeeCRUDControlObj.UploadEmployeeImage(saveResults.Data.Employee.EmployeeNumber);

                _employeeController.SaveEmployeeImageFileName(saveResults.Data.Employee.EmployeeNumber, imageFileName);

                employeeCRUDControlObj.ClearForm();

                // Trigger display employee info after saving
                employeeCRUDControlObj.EmployeeNumber = saveResults.Data.Employee.EmployeeNumber;
                employeeCRUDControlObj.IsNew = false;

                //string msg = addUpdateEmployeeObj.IsNew ? "Successfully save new employee details." : "Successfully update employee details.";

                //DisplayAddUpdateEmployeeConfirmationUserControl(saveResults.Data, msg);
            }
            else
            {
                MessageBox.Show(resultMessages, "Save employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void HandleSelectedWorkShiftToGetOtherInfo(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            long selectedWorkShiftId = employeeCRUDControlObj.SelectedShiftId;

            if (selectedWorkShiftId > 0)
            {
                var shiftDays = _employeeShiftDayData.GetByShiftId(selectedWorkShiftId);
                employeeCRUDControlObj.WorkShiftDays = shiftDays;
                employeeCRUDControlObj.DisplayWorkShiftDays();
            }

        }

        private void OnEmployeeNumberEnter(object sender, PropertyChangedEventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            var employeeDetails = this._employeeController.GetByEmployeeNumber(employeeCRUDControlObj.EmployeeNumber);

            if (employeeDetails != null && employeeDetails.IsSuccess && employeeDetails.Data != null)
            {
                employeeCRUDControlObj.EmployeeGovtIdCards = _employeeController.GetAllEmployeeIdCardsMapToCustomModel(employeeDetails.Data.EmployeeNumber);
                //employeeCRUDControlObj.EmployeeSalary = _employeeController.GetEmployeeSalaryRateByEmployeeNumber(employeeDetails.Data.EmployeeNumber).Data;
                employeeCRUDControlObj.DisplayEmployeeDetails(employeeDetails.Data);


                int year = DateTime.Now.Year;
                DateTime Jan1 = new DateTime(year, 1, 1);
                DateTime today = DateTime.Now;

                employeeCRUDControlObj.AttendanceHistory = _employeeAttendanceData.GetAllAttendanceRecordByWorkDateRange(employeeDetails.Data.EmployeeNumber, Jan1, today);
                employeeCRUDControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(employeeDetails.Data.EmployeeNumber, year);

                if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == UserRole.admin)
                {
                    employeeCRUDControlObj.EmployeeLeaveForApproval = _employeeLeaveData.GetAllByStatus(EmployeeRequestApprovalStatus.Pending);
                }
                else
                {
                    employeeCRUDControlObj.EmployeeLeaveForApproval = _employeeLeaveData.GetAllByEmpAndStatus(employeeDetails.Data.EmployeeNumber, EmployeeRequestApprovalStatus.Pending);
                }

                employeeCRUDControlObj.Holidays = _holidayData.GetAllNotDeleted();
                employeeCRUDControlObj.WorkforceSchedules = _workforceScheduleData.GetAllForEmpAttendance(Jan1, today, employeeDetails.Data.EmployeeNumber);

                employeeCRUDControlObj.PayslipPaydates = _employeePayslipData.GetEmployeePayslipPaydatesList(employeeDetails.Data.EmployeeNumber);

                employeeCRUDControlObj.DisplayAttendanceRecord(Jan1, today);
                employeeCRUDControlObj.DisplayEmpPayslipPaydateList();
                employeeCRUDControlObj.DisplayEmployeeLeavesInDGV();
                employeeCRUDControlObj.DisplayEmployeeLeavesForApprovalInDGV();

                employeeCRUDControlObj.MoveToNextTabSaveEmployeeDetails();


            }
            else
            {
                string resultMessages = "";
                foreach (var msg in employeeDetails.Messages)
                {
                    resultMessages += msg + "\n";
                }
                MessageBox.Show(resultMessages, "Search employee details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void HandleFilterEmployeeAttendance(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeDetailsCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            var EmployeeNumber = employeeDetailsCRUDControlObj.EmployeeNumber;
            DateTime startDate = employeeDetailsCRUDControlObj.FilterAttendanceStartDate;
            DateTime endDate = employeeDetailsCRUDControlObj.FilterAttendanceEndDate;

            employeeDetailsCRUDControlObj.AttendanceHistory = _employeeAttendanceData.GetAllAttendanceRecordByWorkDateRange(EmployeeNumber, startDate, endDate);
            employeeDetailsCRUDControlObj.DisplayAttendanceRecord(startDate, endDate);
        }


        private void HandleFilterEmployeePayslip(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            var employeeNumber = employeeCRUDControlObj.EmployeeNumber;
            var paydate = employeeCRUDControlObj.SelectedPayslipPaydateToView;

            var payslipData = _employeePayslipData.GetEmployeePayslipRecordByPaydate(employeeNumber, paydate);
            var employeeData = _employeeController.GetByEmployeeNumber(employeeNumber).Data;

            employeeCRUDControlObj.DisplayEmployeePayslip(employeeData, payslipData);
        }

        private void HandleMarkEmployeeAsResigned(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            var employeeNumber = employeeCRUDControlObj.EmployeeNumber;

            if (string.IsNullOrWhiteSpace(employeeNumber) == false)
            {
                var markAsQuitRes = _employeeController.MarkEmployeeAsQuit(employeeNumber);

                if (markAsQuitRes == true)
                {
                    MessageBox.Show("Successfully mark this employee as resigned.", "Mark Resigned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var employeeDetails = this._employeeController.GetByEmployeeNumber(employeeNumber);
                    employeeCRUDControlObj.DisplayEmployeeDetails(employeeDetails.Data);
                }
            }
        }

        private void HandleUndoMarkEmployeeAsResigned(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            var employeeNumber = employeeCRUDControlObj.EmployeeNumber;

            if (string.IsNullOrWhiteSpace(employeeNumber) == false)
            {
                var undoMarkAsQuitRes = _employeeController.UndoMarkEmployeeAsQuit(employeeNumber);

                if (undoMarkAsQuitRes == true)
                {
                    MessageBox.Show("Successfully undo employee resigned.", "Undo Mark Resigned", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var employeeDetails = this._employeeController.GetByEmployeeNumber(employeeNumber);
                    employeeCRUDControlObj.DisplayEmployeeDetails(employeeDetails.Data);
                }
            }
        }

        private void HandleMarkEmployeeAsDeleted(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
            var employeeNumber = employeeCRUDControlObj.EmployeeNumber;

            if (string.IsNullOrWhiteSpace(employeeNumber) == false)
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this employee?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var markAsQuitRes = _employeeController.MarkEmployeeAsDeleted(employeeNumber);

                    if (markAsQuitRes == true)
                    {
                        employeeCRUDControlObj.ClearForm();
                    }
                }
            }
        }

        private void ControlToDisplay_EmployeeLeaveApproval(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl employeeCRUDControlObj = (EmployeeDetailsCRUDControl)sender;
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
                // search all leave by employee
                employeeCRUDControlObj.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(employeeNumber, DateTime.Now.Year);
                employeeCRUDControlObj.DisplayEmployeeLeavesInDGV();


                employeeCRUDControlObj.EmployeeLeaveForApproval = _employeeLeaveData.GetAllByStatus(EmployeeRequestApprovalStatus.Pending);
                employeeCRUDControlObj.DisplayEmployeeLeavesForApprovalInDGV();
            }
            else
            {
                MessageBox.Show(resultMessages, "Employee leave approval", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion


        #region Employee list user control related methods and event handlers

        private void DisplayEmployeeListUserControl()
        {
            this.panelContainer.Controls.Clear();

            var employeeListControlObj = new EmployeeListControl();
            employeeListControlObj.Dock = DockStyle.Fill;
            //userControlToDisplay.Location = new Point(this.ClientSize.Width / 2 - userControlToDisplay.Size.Width / 2, this.ClientSize.Height / 2 - userControlToDisplay.Size.Height / 2);
            //userControlToDisplay.Anchor = AnchorStyles.None;

            employeeListControlObj.Employees = this._employeeController.GetAll().Data;
            employeeListControlObj.DisplayEmployeeList();

            employeeListControlObj.PropertyChanged += OnEmployeeViewDetails; // when view details button click
            employeeListControlObj.SearchStringEnter += this.OnSearchStringEnter; // when Search button click
            employeeListControlObj.ReloadEmployeeList += this.OnReloadEmployeeList; // when button reload click

            this.panelContainer.Controls.Add(employeeListControlObj);
        }

        // when view details button click
        private void OnEmployeeViewDetails (object sender, PropertyChangedEventArgs e)
        {
            EmployeeListControl employeeListControlObj = (EmployeeListControl)sender;
            var selectedEmployeeNumber = employeeListControlObj.SelectedEmployeeNumber;
            DisplayAddUpdateEmployeeUserControl(selectedEmployeeNumber);
        }

        // when search string key up == enter
        private void OnSearchStringEnter(object sender, EventArgs e)
        {
            EmployeeListControl employeeListControlObj = (EmployeeListControl)sender;
            var searchParams = employeeListControlObj.SearchEmployeeParameters;
            employeeListControlObj.Employees = this._employeeController.Search(searchParams.SearchString).Data;
            employeeListControlObj.DisplayEmployeeList();
        }

        // when button reload click
        private void OnReloadEmployeeList(object sender, EventArgs e)
        {
            EmployeeListControl employeeListControlObj = (EmployeeListControl)sender;
            employeeListControlObj.Employees = this._employeeController.GetAll().Data;
            employeeListControlObj.DisplayEmployeeList();
        }

        #endregion


        private void WorkSchedulesMenItems_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem clickedItem = e.ClickedItem;

            if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == UserRole.admin)
            {
                if (clickedItem != null && clickedItem.Name == "WorkShiftsMenItem")
                {
                    // CRUD form
                    DisplayWorkScheduleShiftsCRUDControl();
                }
                else if (clickedItem != null && clickedItem.Name == "EmpWorkShiftScheds")
                {
                    DisplayEmployeeWorkShiftScheduleMgmntControl();
                }
                else if (clickedItem != null && clickedItem.Name == "HolidaysMenuItem")
                {
                    DisplayHolidayCRUDControl();
                }
            }
        }

        public void DisplayWorkScheduleShiftsCRUDControl()
        {
            this.panelContainer.Controls.Clear();

            var workShiftsCRUDControlObj = new WorkShiftCRUDControl();
            //addUpdateEmployeeUserControl.Dock = DockStyle.Fill;
            workShiftsCRUDControlObj.Location = new Point(this.ClientSize.Width / 2 - workShiftsCRUDControlObj.Size.Width / 2, this.ClientSize.Height / 2 - workShiftsCRUDControlObj.Size.Height / 2);
            workShiftsCRUDControlObj.Anchor = AnchorStyles.None;

            workShiftsCRUDControlObj.EmployeeShifts = _workShiftController.GetAll().Data;

            workShiftsCRUDControlObj.EmployeeShiftSaved += HandleWorkShiftSaved;
            workShiftsCRUDControlObj.PropSelectedEmpShiftIdToUpdateChanged += OnShiftSelectedToUpdate;
            workShiftsCRUDControlObj.PropSelectedEmpShiftIdToDeleteChanged += OnShiftSelectedToDelete;

            this.panelContainer.Controls.Add(workShiftsCRUDControlObj);
        }

        private void HandleWorkShiftSaved (object sender, EventArgs e)
        {
            WorkShiftCRUDControl workShiftsCRUDControlObj = (WorkShiftCRUDControl)sender;

            var saveWorkShift = workShiftsCRUDControlObj.EmployeeShiftToAddUpdate;
            var shiftDays = workShiftsCRUDControlObj.EmployeeShiftDaysToAddUpdate;
            bool isNew = workShiftsCRUDControlObj.IsSaveNew;

            if (saveWorkShift != null)
            {
                var saveResults = _workShiftController.Save(saveWorkShift, shiftDays, isNew);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    workShiftsCRUDControlObj.ResetForm();

                    workShiftsCRUDControlObj.EmployeeShifts = _workShiftController.GetAll().Data;
                    workShiftsCRUDControlObj.DisplayWorkShiftList();

                    //string msg = addUpdateEmployeeObj.IsNew ? "Successfully save new employee details." : "Successfully update employee details.";

                    //DisplayAddUpdateEmployeeConfirmationUserControl(saveResults.Data, msg);
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void OnShiftSelectedToUpdate(object sender, PropertyChangedEventArgs e)
        {
            WorkShiftCRUDControl workShiftsCRUDControlObj = (WorkShiftCRUDControl)sender;
            var selectedShiftId = workShiftsCRUDControlObj.SelectedEmpShiftIdToUpdate;

            if (long.TryParse(selectedShiftId, out long shiftId))
            {
                var selectedShift = _workShiftController.GetById(shiftId).Data;
                if (selectedShift != null)
                {
                    workShiftsCRUDControlObj.EmployeeShiftToAddUpdate = selectedShift;
                    workShiftsCRUDControlObj.EmployeeShiftDaysToAddUpdate = _employeeShiftDayData.GetByShiftId(selectedShift.Id);
                    workShiftsCRUDControlObj.DisplaySelectedShift();
                }
                
            }

        }

        private void OnShiftSelectedToDelete(object sender, PropertyChangedEventArgs e)
        {
            WorkShiftCRUDControl workShiftsCRUDControlObj = (WorkShiftCRUDControl)sender;
            var selectedShiftId = workShiftsCRUDControlObj.SelectedEmpShiftIdToDelete;

            if (long.TryParse(selectedShiftId, out long shiftId))
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    FrmReassignEmployeesToNewShift frmReassignEmpToNewShift = new FrmReassignEmployeesToNewShift(_employeeData, _employeeShiftData, shiftId);
                    frmReassignEmpToNewShift.ShowDialog();
                    bool continueToDeleteShift = (frmReassignEmpToNewShift.IsDone == true && frmReassignEmpToNewShift.IsCancelled == false);

                    if (continueToDeleteShift)
                    {
                        var deleteResults = _workShiftController.Delete(shiftId);

                        string resultMessages = "";
                        foreach (var msg in deleteResults.Messages)
                        {
                            resultMessages += msg + "\n";
                        }

                        if (deleteResults.IsSuccess)
                        {
                            MessageBox.Show(resultMessages, "Delete shift.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            workShiftsCRUDControlObj.ResetForm();
                            workShiftsCRUDControlObj.EmployeeShifts = _workShiftController.GetAll().Data;
                            workShiftsCRUDControlObj.DisplayWorkShiftList();
                        }
                        else
                        {
                            MessageBox.Show(resultMessages, "Delete shift", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    
                }
            }
        }

        #region Employee Work shift scheduling control
        public void DisplayEmployeeWorkShiftScheduleMgmntControl()
        {
            this.panelContainer.Controls.Clear();

            var manageEmpWorkScheduleControlObj = new ManageEmpWorkScheduleControl();
            //addUpdateEmployeeUserControl.Dock = DockStyle.Fill;
            manageEmpWorkScheduleControlObj.Location = new Point(this.ClientSize.Width / 2 - manageEmpWorkScheduleControlObj.Size.Width / 2, this.ClientSize.Height / 2 - manageEmpWorkScheduleControlObj.Size.Height / 2);
            manageEmpWorkScheduleControlObj.Anchor = AnchorStyles.None;

            manageEmpWorkScheduleControlObj.Employees = _employeeController.GetAll().Data;
            manageEmpWorkScheduleControlObj.WorkShifts = _workShiftController.GetAll().Data;
            manageEmpWorkScheduleControlObj.WorkforceSchedule = _workforceScheduleController.GetWorkforceSchedule();

            manageEmpWorkScheduleControlObj.ShiftSelected += HandleShiftSelectedToGetAdditionalDetails;
            manageEmpWorkScheduleControlObj.EmployeeShiftUpdated += HandleUpdateEmployeeShift;
            manageEmpWorkScheduleControlObj.SaveWorkforceSchedule += HandleSaveWorkforceSchedule;
            manageEmpWorkScheduleControlObj.UndoWorkForceChangesInFormOnly += HandleUndoChangesOnWorkforceScheduleFormOnly;
            manageEmpWorkScheduleControlObj.DeleteAllWorkForceSchedule += HandleDeleteAllWorkForceSchedule;
            //manageEmpWorkScheduleControlObj.EmployeeShifts = _workShiftController.GetAll().Data;

            //manageEmpWorkScheduleControlObj.EmployeeShiftSaved += HandleWorkShiftSaved;
            //manageEmpWorkScheduleControlObj.PropSelectedEmpShiftIdToUpdateChanged += OnShiftSelectedToUpdate;
            //manageEmpWorkScheduleControlObj.PropSelectedEmpShiftIdToDeleteChanged += OnShiftSelectedToDelete;

            this.panelContainer.Controls.Add(manageEmpWorkScheduleControlObj);
        }

        private void HandleShiftSelectedToGetAdditionalDetails(object sender, EventArgs e)
        {
            ManageEmpWorkScheduleControl manageEmpWorkScheduleControlObj = (ManageEmpWorkScheduleControl)sender;
            var selectedShiftId = manageEmpWorkScheduleControlObj.SelectedShiftId;

            if (selectedShiftId > 0)
            {
                var shiftDays = _employeeShiftDayData.GetByShiftId(selectedShiftId);
                manageEmpWorkScheduleControlObj.WorkShiftDays = shiftDays;
                manageEmpWorkScheduleControlObj.DisplayWorkShiftDays();
            }
        }

        private void HandleDeleteAllWorkForceSchedule(object sender, EventArgs e)
        {
            ManageEmpWorkScheduleControl manageEmpWorkScheduleControlObj = (ManageEmpWorkScheduleControl)sender;

            DateTime dateRangeStart = manageEmpWorkScheduleControlObj.SelectedDateRangeToDeleteStart;
            DateTime dateRangeEnd = manageEmpWorkScheduleControlObj.SelectedDateRangeToDeleteEnd;

            DialogResult res = MessageBox.Show($"Are you sure, you want to delete schedules from {dateRangeStart.ToShortDateString()} to {dateRangeEnd.ToShortDateString()}? \n You can't undo this action!",
                                        "Delete workforce schedule by date range", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                var deleteResults = _workforceScheduleController.DeleteByDateRange(dateRangeStart, dateRangeEnd);

                string resultMessages = "";
                foreach (var msg in deleteResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                MessageBox.Show(resultMessages, "Delete workforce schedule by date range", MessageBoxButtons.OK, MessageBoxIcon.Information);

                manageEmpWorkScheduleControlObj.Employees = _employeeController.GetAll().Data;
                manageEmpWorkScheduleControlObj.WorkShifts = _workShiftController.GetAll().Data;
                manageEmpWorkScheduleControlObj.WorkforceSchedule = _workforceScheduleController.GetWorkforceSchedule();

                manageEmpWorkScheduleControlObj.DisplayEmployees();
                manageEmpWorkScheduleControlObj.DisplayWorkShifts();
                manageEmpWorkScheduleControlObj.ResetUpdateEmployeeShiftVal();
                manageEmpWorkScheduleControlObj.DisplayWorkScheduleInListView();
            }
        }


        private void HandleUndoChangesOnWorkforceScheduleFormOnly(object sender, EventArgs e)
        {
            ManageEmpWorkScheduleControl manageEmpWorkScheduleControlObj = (ManageEmpWorkScheduleControl)sender;
            manageEmpWorkScheduleControlObj.WorkforceSchedule = _workforceScheduleController.GetWorkforceSchedule();
            manageEmpWorkScheduleControlObj.DisplayWorkScheduleInListView();
        }

        private void HandleUpdateEmployeeShift(object sender, EventArgs e)
        {
            ManageEmpWorkScheduleControl manageEmpWorkScheduleControlObj = (ManageEmpWorkScheduleControl)sender;
            var updateEmployeeShift = manageEmpWorkScheduleControlObj.UpdateEmployeeShift;

            if (updateEmployeeShift != null)
            {
                var updateResults = _employeeController.UpdateEmployeesShift(updateEmployeeShift);

                string resultMessages = "";
                foreach (var msg in updateResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                MessageBox.Show(resultMessages, "Update employee shift", MessageBoxButtons.OK, MessageBoxIcon.Information);

                manageEmpWorkScheduleControlObj.Employees = _employeeController.GetAll().Data;
                manageEmpWorkScheduleControlObj.WorkShifts = _workShiftController.GetAll().Data;
                manageEmpWorkScheduleControlObj.WorkforceSchedule = _workforceScheduleController.GetWorkforceSchedule();

                manageEmpWorkScheduleControlObj.DisplayEmployees();
                manageEmpWorkScheduleControlObj.DisplayWorkShifts();
                manageEmpWorkScheduleControlObj.ResetUpdateEmployeeShiftVal();
                manageEmpWorkScheduleControlObj.DisplayWorkScheduleInListView();
            }
        }


        private void HandleSaveWorkforceSchedule(object sender, EventArgs e)
        {
            ManageEmpWorkScheduleControl manageEmpWorkScheduleControlObj = (ManageEmpWorkScheduleControl)sender;
            var workforceSchedule = manageEmpWorkScheduleControlObj.WorkforceSchedule;

            if (workforceSchedule != null)
            {
                var saveResults = _workforceScheduleController.Save(workforceSchedule);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    manageEmpWorkScheduleControlObj.WorkforceSchedule = saveResults.Data;
                    manageEmpWorkScheduleControlObj.Reset();
                    MessageBox.Show(resultMessages, "Save workforce schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save workforce schedule", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void HandleSearchingEmployeeRemainingLeaveCounts(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl controlToDisplay = (EmployeeDetailsCRUDControl)sender;
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

        private void HandleSaveEmployeeLeave(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl controlToDisplay = (EmployeeDetailsCRUDControl)sender;
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

                    if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey == UserRole.admin)
                    {
                        controlToDisplay.EmployeeLeaveForApproval = _employeeLeaveData.GetAllByStatus(EmployeeRequestApprovalStatus.Pending);
                    }
                    else
                    {
                        controlToDisplay.EmployeeLeaveForApproval = _employeeLeaveData.GetAllByEmpAndStatus(newEmployeeLeave.EmployeeNumber, EmployeeRequestApprovalStatus.Pending);
                    }

                    controlToDisplay.DisplayEmployeeLeavesInDGV();
                    controlToDisplay.DisplayEmployeeLeavesForApprovalInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void HandleDeleteEmployeeLeave(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl controlToDisplay = (EmployeeDetailsCRUDControl)sender;
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


        private void HandleFilterEmployeeLeaveHistory(object sender, EventArgs e)
        {
            EmployeeDetailsCRUDControl controlToDisplay = (EmployeeDetailsCRUDControl)sender;
            var employeeNumber = controlToDisplay.EmployeeNumber;
            var year = controlToDisplay.FilterEmployeeLeaveHistoryYear;

            if (string.IsNullOrEmpty(employeeNumber) == false)
            {
                // search all leave by employee
                controlToDisplay.EmployeeLeaveHistory = _employeeLeaveData.GetAllByEmployeeNumberAndYear(employeeNumber, year);
                controlToDisplay.DisplayEmployeeLeavesInDGV();
            }
        }

        #endregion

        #region Holiday CRUD Control

        public void DisplayHolidayCRUDControl()
        {
            this.panelContainer.Controls.Clear();

            var holidayCRUDControlObj = new HolidayCRUDControl();
            //addUpdateEmployeeUserControl.Dock = DockStyle.Fill;
            holidayCRUDControlObj.Location = new Point(this.ClientSize.Width / 2 - holidayCRUDControlObj.Size.Width / 2, this.ClientSize.Height / 2 - holidayCRUDControlObj.Size.Height / 2);
            holidayCRUDControlObj.Anchor = AnchorStyles.None;

            holidayCRUDControlObj.Holidays = _holidayData.GetAllNotDeleted();
            holidayCRUDControlObj.DisplayHolidays();

            holidayCRUDControlObj.HolidaySaved += HandleSaveHoliday;
            holidayCRUDControlObj.HolidayDelete += HandleDeleteHoliday;

            this.panelContainer.Controls.Add(holidayCRUDControlObj);
        }


        private void HandleSaveHoliday(object sender, EventArgs e)
        {
            HolidayCRUDControl holidayCRUDControlObj = (HolidayCRUDControl)sender;
            var newHolidayDetails = holidayCRUDControlObj.NewHolidayToAdd;

            if (newHolidayDetails != null)
            {
                // for now, the transaction is always new holiday
                var saveResults = _holidayController.Save(newHolidayDetails, true);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save employee leave details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    holidayCRUDControlObj.ResetForm();

                    holidayCRUDControlObj.Holidays = _holidayData.GetAllNotDeleted();
                    holidayCRUDControlObj.DisplayHolidays();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void HandleDeleteHoliday(object sender, EventArgs e)
        {
            HolidayCRUDControl holidayCRUDControlObj = (HolidayCRUDControl)sender;
            long holidayIdToDelete = holidayCRUDControlObj.HolidayIdToDelete;

            if (holidayIdToDelete > 0)
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var saveResults = _holidayController.Delete(holidayIdToDelete);

                    string resultMessages = "";
                    foreach (var msg in saveResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (saveResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete holiday details", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        holidayCRUDControlObj.Holidays = _holidayData.GetAllNotDeleted();
                        holidayCRUDControlObj.DisplayHolidays();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete holiday details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        #endregion

        #region Employee Benefits/Deduction CRUD

        public void DisplayBenefitDeductionCRUDControl()
        {
            this.panelContainer.Controls.Clear();

            var benefitDeductionControlObj = new EmployeeBenefitsAndDeductions();
            benefitDeductionControlObj.Location = new Point(this.ClientSize.Width / 2 - benefitDeductionControlObj.Size.Width / 2, this.ClientSize.Height / 2 - benefitDeductionControlObj.Size.Height / 2);
            benefitDeductionControlObj.Anchor = AnchorStyles.None;

            benefitDeductionControlObj.Benefits = _employeeBenefitData.GetAllNotDeleted();
            benefitDeductionControlObj.SpecificEmployeeBenefits = _specificEmployeeBenefitData.GetAllUnpaid();
            benefitDeductionControlObj.Deductions = _employeeDeductionData.GetAllNotDeleted();
            benefitDeductionControlObj.SpecificEmployeeDeductions = _specificEmployeeDeductionData.GetAllPending();

            benefitDeductionControlObj.SaveBenefit += HandleSaveEmployeeBenefits;
            benefitDeductionControlObj.BtnUpdateBenefitClicked += HandleSelectEmpBenefit;
            benefitDeductionControlObj.BtnDeleteBenefitClicked += HandleDeleteEmpBenefit;

            benefitDeductionControlObj.SaveSpecificEmployeeBenefit += BenefitDeductionControlObj_SaveSpecificEmployeeBenefit;
            benefitDeductionControlObj.BtnDeleteSpecificBenefitClicked += BenefitDeductionControlObj_BtnDeleteSpecificBenefitClicked;

            benefitDeductionControlObj.SaveDeduction += HandleSaveEmployeeDeduction;
            benefitDeductionControlObj.BtnUpdateDeductionClicked += HandleSelectEmpDeduction;
            benefitDeductionControlObj.BtnDeleteDeductionClicked += HandleDeleteEmpDedution;

            benefitDeductionControlObj.SaveSpecificEmployeeDeduction += BenefitDeductionControlObj_SaveSpecificEmployeeDeduction;
            benefitDeductionControlObj.BtnDeleteSpecificDedutionClicked += BenefitDeductionControlObj_BtnDeleteSpecificDedutionClicked;

            this.panelContainer.Controls.Add(benefitDeductionControlObj);
        }


        private void HandleSaveEmployeeBenefits(object sender, EventArgs e)
        {
            EmployeeBenefitsAndDeductions benefitDeductionControlObj = (EmployeeBenefitsAndDeductions)sender;
            var benefit = benefitDeductionControlObj.BenefitToSave;
            var isNew = benefitDeductionControlObj.BenefitIsSaveNew;

            if (benefit != null)
            {
                var saveResults = _employeeBenefitsDeductionsController.SaveBenefit(benefit, isNew);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save benefit details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    benefitDeductionControlObj.ResetBenefitForm();

                    benefitDeductionControlObj.Benefits = _employeeBenefitData.GetAllNotDeleted();
                    benefitDeductionControlObj.DisplayBenefitsInDGV();

                    //string msg = addUpdateEmployeeObj.IsNew ? "Successfully save new employee details." : "Successfully update employee details.";

                    //DisplayAddUpdateEmployeeConfirmationUserControl(saveResults.Data, msg);
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void HandleSelectEmpBenefit(object sender, EventArgs e)
        {
            EmployeeBenefitsAndDeductions benefitDeductionControlObj = (EmployeeBenefitsAndDeductions)sender;
            var benefitId = benefitDeductionControlObj.BenefitIdToDeleteOrUpdate;

            benefitDeductionControlObj.BenefitToSave = _employeeBenefitData.Get(benefitId);
            benefitDeductionControlObj.DisplaySelectedBenefit();
        }


        private void HandleDeleteEmpBenefit(object sender, EventArgs e)
        {
            EmployeeBenefitsAndDeductions benefitDeductionControlObj = (EmployeeBenefitsAndDeductions)sender;
            var benefitId = benefitDeductionControlObj.BenefitIdToDeleteOrUpdate;

            if (benefitId > 0)
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var saveResults = _employeeBenefitsDeductionsController.DeleteBenefit(benefitId);

                    string resultMessages = "";
                    foreach (var msg in saveResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (saveResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete benefit.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        benefitDeductionControlObj.Benefits = _employeeBenefitData.GetAllNotDeleted();
                        benefitDeductionControlObj.DisplayBenefitsInDGV();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete benefit details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private void BenefitDeductionControlObj_SaveSpecificEmployeeBenefit(object sender, EventArgs e)
        {
            EmployeeBenefitsAndDeductions benefitDeductionControlObj = (EmployeeBenefitsAndDeductions)sender;
            var specificBenefit = benefitDeductionControlObj.SpecificEmployeeBenefitToSave;
            var isNew = benefitDeductionControlObj.SpecificBenefitIsSaveNew;

            if (specificBenefit != null)
            {
                var saveResults = _employeeBenefitsDeductionsController.SaveSpecificEmployeeBenefit(specificBenefit, isNew);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save specific benefit details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    benefitDeductionControlObj.ResetSpecificBenefitForm();

                    benefitDeductionControlObj.SpecificEmployeeBenefits = _specificEmployeeBenefitData.GetAllUnpaid();
                    benefitDeductionControlObj.DisplaySpecificEmployeeBenefitsInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save shift details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        private void BenefitDeductionControlObj_SaveSpecificEmployeeDeduction(object sender, EventArgs e)
        {
            EmployeeBenefitsAndDeductions benefitDeductionControlObj = (EmployeeBenefitsAndDeductions)sender;
            var deduction = benefitDeductionControlObj.SpecificEmployeeDeductionToSave;
            var isNew = benefitDeductionControlObj.SpecificDeductionIsSaveNew;

            if (deduction != null)
            {
                var saveResults = _employeeBenefitsDeductionsController.SaveSpecificDeduction(deduction, isNew);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save deduction details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    benefitDeductionControlObj.ResetSpecificDeductionForm();

                    benefitDeductionControlObj.SpecificEmployeeDeductions = _specificEmployeeDeductionData.GetAllPending();
                    benefitDeductionControlObj.DisplaySpecificEmployeeDeductionsInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save deduction details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void HandleSaveEmployeeDeduction(object sender, EventArgs e)
        {
            EmployeeBenefitsAndDeductions benefitDeductionControlObj = (EmployeeBenefitsAndDeductions)sender;
            var deduction = benefitDeductionControlObj.DeductionToSave;
            var isNew = benefitDeductionControlObj.DeductionIsSaveNew;

            if (deduction != null)
            {
                var saveResults = _employeeBenefitsDeductionsController.SaveDeduction(deduction, isNew);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save deduction details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    benefitDeductionControlObj.ResetDeductionForm();

                    benefitDeductionControlObj.Deductions = _employeeDeductionData.GetAllNotDeleted();
                    benefitDeductionControlObj.DisplayDeductionsInDGV();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save deduction details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }


        private void HandleSelectEmpDeduction(object sender, EventArgs e)
        {
            EmployeeBenefitsAndDeductions benefitDeductionControlObj = (EmployeeBenefitsAndDeductions)sender;
            var deductionId = benefitDeductionControlObj.DeductionIdToDeleteOrUpdate;

            benefitDeductionControlObj.DeductionToSave = _employeeDeductionData.Get(deductionId);
            benefitDeductionControlObj.DisplaySelectedDeduction();
        }


        private void BenefitDeductionControlObj_BtnDeleteSpecificBenefitClicked(object sender, EventArgs e)
        {
            EmployeeBenefitsAndDeductions benefitDeductionControlObj = (EmployeeBenefitsAndDeductions)sender;
            var benefitId = benefitDeductionControlObj.SpecificEmpBenefitIdToDelete;

            if (benefitId > 0)
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var saveResults = _employeeBenefitsDeductionsController.DeleteSpecificBenefit(benefitId);

                    string resultMessages = "";
                    foreach (var msg in saveResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (saveResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete deduction.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        benefitDeductionControlObj.SpecificEmployeeBenefits = _specificEmployeeBenefitData.GetAllUnpaid();
                        benefitDeductionControlObj.DisplaySpecificEmployeeBenefitsInDGV();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete deduction details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private void HandleDeleteEmpDedution(object sender, EventArgs e)
        {
            EmployeeBenefitsAndDeductions benefitDeductionControlObj = (EmployeeBenefitsAndDeductions)sender;
            var deductionId = benefitDeductionControlObj.DeductionIdToDeleteOrUpdate;

            if (deductionId > 0)
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var saveResults = _employeeBenefitsDeductionsController.DeleteDeduction(deductionId);

                    string resultMessages = "";
                    foreach (var msg in saveResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (saveResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete deduction.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        benefitDeductionControlObj.Deductions = _employeeDeductionData.GetAllNotDeleted();
                        benefitDeductionControlObj.DisplayDeductionsInDGV();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete deduction details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void BenefitDeductionControlObj_BtnDeleteSpecificDedutionClicked(object sender, EventArgs e)
        {
            EmployeeBenefitsAndDeductions benefitDeductionControlObj = (EmployeeBenefitsAndDeductions)sender;
            var deductionId = benefitDeductionControlObj.SpecificEmpDeductionIdToDelete;

            if (deductionId > 0)
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    var saveResults = _employeeBenefitsDeductionsController.DeleteSpecificDeduction(deductionId);

                    string resultMessages = "";
                    foreach (var msg in saveResults.Messages)
                    {
                        resultMessages += msg + "\n";
                    }

                    if (saveResults.IsSuccess)
                    {
                        MessageBox.Show(resultMessages, "Delete deduction.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        benefitDeductionControlObj.SpecificEmployeeDeductions = _specificEmployeeDeductionData.GetAllPending();
                        benefitDeductionControlObj.DisplaySpecificEmployeeDeductionsInDGV();
                    }
                    else
                    {
                        MessageBox.Show(resultMessages, "Delete deduction details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        #endregion


        public void DisplayEmpPositionWithSalaryRateCRUDControl()
        {
            this.panelContainer.Controls.Clear();

            var controlObj = new EmpPositionWithSalaryRateCRUDControl(_numberOfWorkingDaysInAMonthData);
            controlObj.Location = new Point(this.ClientSize.Width / 2 - controlObj.Size.Width / 2, this.ClientSize.Height / 2 - controlObj.Size.Height / 2);
            controlObj.Anchor = AnchorStyles.None;

            controlObj.Positions = _employeePositionData.GetAllNotDeleted();

            controlObj.PositionSaved += HandleSaveEmployeePosition;
            controlObj.DeletePosition += HandleDeleteEmployeePosition;
            controlObj.UpdateNumberOfWorkingDays += HandleUpdateNumberOfWorkingDays;

            this.panelContainer.Controls.Add(controlObj);
        }

        private void HandleUpdateNumberOfWorkingDays(object sender, EventArgs e)
        {
            EmpPositionWithSalaryRateCRUDControl controlObj = (EmpPositionWithSalaryRateCRUDControl)sender;
            decimal numberOfWorkingDays = controlObj.NumberOfWorkingDays;

            var saveResults = _employeePositionController.UpdateNumberOfWorkingDaysInAMonth(numberOfWorkingDays);

            string resultMessages = "";
            foreach (var msg in saveResults.Messages)
            {
                resultMessages += msg + "\n";
            }

            if (saveResults.IsSuccess)
            {
                MessageBox.Show(resultMessages, "Save new number of working days in month", MessageBoxButtons.OK, MessageBoxIcon.Information);

                controlObj.ResetForm();
                controlObj.Positions = _employeePositionData.GetAllNotDeleted();
                controlObj.DisplayPositionList();
            }
            else
            {
                MessageBox.Show(resultMessages, "Save new number of working days in month", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void HandleSaveEmployeePosition(object sender, EventArgs e)
        {
            EmpPositionWithSalaryRateCRUDControl controlObj = (EmpPositionWithSalaryRateCRUDControl)sender;
            var positiionDetails = controlObj.PositionToAddUpdate;
            var isNew = controlObj.IsSaveNew;

            if (positiionDetails != null)
            {
                var saveResults = _employeePositionController.Save(positiionDetails, isNew);

                string resultMessages = "";
                foreach (var msg in saveResults.Messages)
                {
                    resultMessages += msg + "\n";
                }

                if (saveResults.IsSuccess)
                {
                    MessageBox.Show(resultMessages, "Save position details", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    controlObj.ResetForm();
                    controlObj.Positions = _employeePositionData.GetAllNotDeleted();
                    controlObj.DisplayPositionList();
                }
                else
                {
                    MessageBox.Show(resultMessages, "Save position details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }


        private void HandleDeleteEmployeePosition(object sender, EventArgs e)
        {
            EmpPositionWithSalaryRateCRUDControl controlObj = (EmpPositionWithSalaryRateCRUDControl)sender;
            long positionId = controlObj.SelectedPositionIdToDelete;

            if (positionId > 0)
            {
                DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (res == DialogResult.OK)
                {
                    FrmReassignEmployeesToNewPosition frmReassignEmployeesToNewPosition = new FrmReassignEmployeesToNewPosition(_employeeData, _employeePositionData, positionId);
                    frmReassignEmployeesToNewPosition.ShowDialog();
                    bool continueToDeleteShift = (frmReassignEmployeesToNewPosition.IsDone == true && frmReassignEmployeesToNewPosition.IsCancelled == false);

                    if (continueToDeleteShift)
                    {
                        var deleteResults = _employeePositionController.Delete(positionId);

                        string resultMessages = "";
                        foreach (var msg in deleteResults.Messages)
                        {
                            resultMessages += msg + "\n";
                        }

                        if (deleteResults.IsSuccess)
                        {
                            MessageBox.Show(resultMessages, "Delete position details", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            controlObj.ResetForm();
                            controlObj.Positions = _employeePositionData.GetAllNotDeleted();
                            controlObj.DisplayPositionList();
                        }
                        else
                        {
                            MessageBox.Show(resultMessages, "Delete position details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }

        }
    }
}
