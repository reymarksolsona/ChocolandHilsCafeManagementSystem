using EntitiesShared.EmployeeManagement;
using EntitiesShared.EmployeeManagement.Models;
using EntitiesShared.OtherDataManagement;
using Shared.CustomModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Shared.Helpers;
using System.Globalization;
using EntitiesShared.PayrollManagement;
using Main.Forms.PayrollForms.Controls;
using Shared;
using static EntitiesShared.StaticData;
using PDFReportGenerators;
using EntitiesShared;
using DataAccess.Data.EmployeeManagement.Contracts;

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class EmployeeDetailsCRUDControl : UserControl
    {
        private readonly IEmployeeShiftDayData _employeeShiftDayData;
        private readonly IEmployeePositionData _employeePositionData;
        public EmployeeDetailsCRUDControl(Sessions sessions,
                                        DecimalMinutesToHrsConverter decimalMinutesToHrsConverter, 
                                        OtherSettings otherSettings,
                                        PayrollSettings payrollSettings,
                                        IAttendancePDFReport attendancePDFReport, IEmployeeShiftDayData employeeShiftDayData, IEmployeePositionData employeePositionData)
        {
            InitializeComponent();
            _sessions = sessions;
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
            _otherSettings = otherSettings;
            _payrollSettings = payrollSettings;
            _attendancePDFReport = attendancePDFReport;
            _employeeShiftDayData = employeeShiftDayData;
            _employeePositionData = employeePositionData;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        //private List<GovernmentAgencyModel> govtAgencies;

        //public List<GovernmentAgencyModel> GovtAgencies
        //{
        //    get { return govtAgencies; }
        //    set { govtAgencies = value; }
        //}


        public event EventHandler WorkShiftSelected;
        protected virtual void OnWorkShiftSelected(EventArgs e)
        {
            WorkShiftSelected?.Invoke(this, e);
        }

        private long selectedShiftId;

        public long SelectedShiftId
        {
            get { return selectedShiftId; }
            set { selectedShiftId = value; }
        }

        private List<LeaveTypeModel> leaveLypes;

        public List<LeaveTypeModel> LeaveTypes
        {
            get { return leaveLypes; }
            set { leaveLypes = value; }
        }


        private List<EmployeeShiftModel> workShifts;

        public List<EmployeeShiftModel> WorkShifts
        {
            get { return workShifts; }
            set { workShifts = value; }
        }


        private List<BranchModel> branches;

        public List<BranchModel> Branches
        {
            get { return branches; }
            set { branches = value; }
        }

        private List<EmployeePositionModel> positions;

        public List<EmployeePositionModel> Positions
        {
            get { return positions; }
            set { positions = value; }
        }



        private List<EmployeeShiftDayModel> workShiftDays = new List<EmployeeShiftDayModel>();

        public List<EmployeeShiftDayModel> WorkShiftDays
        {
            get { return workShiftDays; }
            set { workShiftDays = value; }
        }


        private EmployeeModel employee;

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        private List<EmployeeGovtIdCardTempModel> employeeGovtIdCards = new List<EmployeeGovtIdCardTempModel>();

        public List<EmployeeGovtIdCardTempModel> EmployeeGovtIdCards
        {
            get { return employeeGovtIdCards; }
            set { employeeGovtIdCards = value; }
        }


        //private EmployeeSalaryRateModel employeeSalary;

        //public EmployeeSalaryRateModel EmployeeSalary
        //{
        //    get { return employeeSalary; }
        //    set { employeeSalary = value; }
        //}



        private bool isNew;

        public bool IsNew
        {
            get { return isNew; }
            set { isNew = value; }
        }

        private Dictionary<DateTime, AttendanceRecord> attendanceToDisplay = new Dictionary<DateTime, AttendanceRecord>();

        public Dictionary<DateTime, AttendanceRecord> AttendanceToDisplay
        {
            get { return attendanceToDisplay; }
            set { attendanceToDisplay = value; }
        }



        public event EventHandler EmployeeSaved;
        protected virtual void OnEmployeeSaved(EventArgs e)
        {
            EmployeeSaved?.Invoke(this, e);
        }

        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set
            {
                employeeNumber = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(EmployeeNumber));
                }
            }
        }


        public static void EnableTab(TabPage page, bool enable)
        {
            EnableControls(page.Controls, enable);
        }
        private static void EnableControls(Control.ControlCollection ctls, bool enable)
        {
            foreach (Control ctl in ctls)
            {
                ctl.Enabled = enable;
                EnableControls(ctl.Controls, enable);
            }
        }

        private List<EmployeeAttendanceModel> attendanceHistory;

        public List<EmployeeAttendanceModel> AttendanceHistory
        {
            get { return attendanceHistory; }
            set { attendanceHistory = value; }
        }


        private List<EmployeeLeaveModel> employeeLeaveHistory;

        public List<EmployeeLeaveModel> EmployeeLeaveHistory
        {
            get { return employeeLeaveHistory; }
            set { employeeLeaveHistory = value; }
        }

        private List<EmployeeLeaveModel> employeeLeaveForApproval;

        public List<EmployeeLeaveModel> EmployeeLeaveForApproval
        {
            get { return employeeLeaveForApproval; }
            set { employeeLeaveForApproval = value; }
        }

        private List<HolidayModel> holidays;

        public List<HolidayModel> Holidays
        {
            get { return holidays; }
            set { holidays = value; }
        }

        private List<WorkforceScheduleModel> workforceSchedules;

        public List<WorkforceScheduleModel> WorkforceSchedules
        {
            get { return workforceSchedules; }
            set { workforceSchedules = value; }
        }

        private List<EmployeePositionShiftModel> positionShift;

        public List<EmployeePositionShiftModel> PositionShift
        {
            get { return positionShift; }
            set { positionShift = value; }
        }

        private int selectedPositionShiftIndex;

        public int SelectedPositionShiftIndex
        {
            get { return selectedPositionShiftIndex; }
            set { selectedPositionShiftIndex = value; }
        }

        private void EmployeeDetailsCRUDControl_Load(object sender, EventArgs e)
        {
            LoadOtherComboBoxData();

            SetDGVEmployeeLeaveHistoryFontAndColors();
            DisplayLeaveTypes();

            this.EmployeeNumber = _sessions.CurrentLoggedInUser.UserName;

            if (_sessions.CurrentLoggedInUser.Role.Role.RoleKey != UserRole.admin)
            {
                this.BtnActionAddNewEmployee.Enabled = false;
                this.BtnActionUpdateEmployeeDetails.Enabled = false;
                this.BtnActionSearchEmployeeByEmployeeNumber.Enabled = false;
                this.BtnSaveEmployee.Enabled = false;
                this.BtnCancelUpdateEmployee.Enabled = false;
                this.BtnBrowseEmployeeImage.Enabled = false;
                this.BtnAddNewEmpGovtId.Enabled = false;
                this.BtnUndoToDelete.Enabled = false;
                this.BtnDeleteEmpIdCard.Enabled = false;

                this.BtnDeleteThisEmployee.Enabled = false;
                this.BtnUndoResignedEmployee.Enabled = false;
                this.BtnMarkAsResignedThisEmployee.Enabled = false;
                this.groupBox4.Visible = false;
                this.groupBox3.Visible = false;

                this.TboxAdminRemarks.Enabled = false;
                this.BtnApprovedEmpLeave.Enabled = false;
                this.BtnDisapprovedEmpLeave.Enabled = false;
            }

        }


        public void LoadOtherComboBoxData()
        {
            // Govt. agencies load in combo box
            this.CboxGovtAgencies.Items.Clear();
            Dictionary<StaticData.GovContributions, string> govtAgencies = new Dictionary<GovContributions, string>();
            govtAgencies.Add(GovContributions.SSS, "SSS");
            govtAgencies.Add(GovContributions.PhilHealth, "PhilHealth");
            govtAgencies.Add(GovContributions.PagIbig, "PagIbig");

            ComboboxItem govAgencyitem;
            foreach (var govAgency in govtAgencies)
            {
                govAgencyitem = new ComboboxItem();
                govAgencyitem.Text = govAgency.Value;
                govAgencyitem.Value = (int)govAgency.Key;
                this.CboxGovtAgencies.Items.Add(govAgencyitem);
            }
            //if (this.GovtAgencies != null)
            //{
            //    
            //    foreach (var agency in this.GovtAgencies)
            //    {
            //        item = new ComboboxItem();
            //        item.Text = agency.GovtAgency;
            //        item.Value = agency.Id;
            //        this.CboxGovtAgencies.Items.Add(item);
            //    }
            //}

            // Work shifts load in combo box
            this.CBoxShiftList.Items.Clear();
            if (this.WorkShifts != null)
            {
                ComboboxItem item;
                foreach (var shift in this.WorkShifts)
                {
                    item = new ComboboxItem();
                    item.Text = $"{shift.Shift} - from {shift.StartTime.ToShortTimeString()} to {shift.EndTime.ToShortTimeString()}";
                    item.Value = shift.Id;
                    this.CBoxShiftList.Items.Add(item);
                }
            }

            // Branches load in combo box
            this.CBoxBranches.Items.Clear();
            if (this.Branches != null)
            {
                ComboboxItem item;
                foreach (var branch in this.Branches)
                {
                    item = new ComboboxItem();
                    item.Text = branch.BranchName;
                    item.Value = branch.Id;
                    this.CBoxBranches.Items.Add(item);
                }
            }

            // Positions load in combo box
            this.CBoxPositions.Items.Clear();
            if (this.Positions != null)
            {
                ComboboxItem item;
                foreach (var position in this.Positions)
                {
                    item = new ComboboxItem();
                    item.Text = position.Title;
                    item.Value = position.Id;
                    this.CBoxPositions.Items.Add(item);
                }
            }

            this.button2.Enabled = false;
        }


        public void ClearForm()
        {
            this.employeeNumber = "";
            this.IsNew = true;

            if (PicBoxEmpImage.Image != null)
            {
                PicBoxEmpImage.Image.Dispose();
                PicBoxEmpImage.ImageLocation = null;
                PicBoxEmpImage.Image = null;
            }

            this.LViewAttendanceHistory.Items.Clear();
            this.AttendanceHistory = null;

            this.LblActionForEmployeeDetails.Text = "Add new employee";
            this.TbxEmployeeNumberDisplayOnly.Text = "";
            this.TbxFirstName.Text = "";
            this.TbxLastName.Text = "";
            this.TbxMiddleInitial.Text = "";
            this.DTPicBirthDate.Value = DateTime.Now;
            this.TbxMobileNumber.Text = "";
            this.DTPicHireDate.Value = DateTime.Now;
            this.TbxAddress.Text = "";
            this.TbxEmail.Text = "";
            this.TbxEmployeeNumber.Text = "";
            this.CboxGovtAgencies.SelectedIndex = -1;
            this.CBoxBranches.SelectedIndex = -1;
            this.CBoxPositions.SelectedIndex = -1;

            this.CBoxShiftList.SelectedIndex = -1;
            this.LblShiftWorkingDays.Text = "";

            this.TboxEmpIdNumber.Text = "";

            this.GBoxSearchEmployee.Visible = false;
            this.BtnCancelUpdateEmployee.Visible = false;

            TabControlSaveEmployeeDetails.SelectedIndex = 0;

            this.BtnActionAddNewEmployee.Enabled = true;
            this.BtnActionUpdateEmployeeDetails.Enabled = true;
            this.BtnCancelUpdateEmployee.Visible = true;
            this.ListViewEmpGovtIdCards.Items.Clear();
                
            this.BtnUndoToDelete.Visible = false;
            this.BtnDeleteEmpIdCard.Visible = false;

            this.EmployeeGovtIdCards = new List<EmployeeGovtIdCardTempModel>();

            this.EmployeeLeaveHistory = new List<EmployeeLeaveModel>();
            this.DGVEmployeeLeaveHistory.Rows.Clear();

            this.EmployeeLeaveForApproval = new List<EmployeeLeaveModel>();
            this.DGVEmployeeLeaveApproval.Rows.Clear();

        }

        public EmployeeModel CurrentEmployeeDetails { get; set; }
        public void DisplayEmployeeDetails(EmployeeModel employeeDetails)
        {
            if (employeeDetails != null)
            {
                CurrentEmployeeDetails = employeeDetails;

                this.TbxEmployeeNumberDisplayOnly.Text = employeeDetails.EmployeeNumber;
                this.TbxFirstName.Text = employeeDetails.FirstName;
                this.TbxLastName.Text = employeeDetails.LastName;
                this.TbxMiddleInitial.Text = employeeDetails.MiddleName;
                this.DTPicBirthDate.Value = employeeDetails.BirthDate;
                this.TbxMobileNumber.Text = employeeDetails.MobileNumber;
                this.DTPicHireDate.Value = employeeDetails.DateHire;
                this.TbxAddress.Text = employeeDetails.Address;
                this.TbxEmail.Text = employeeDetails.EmailAddress;

                if (employeeDetails.IsQuit == true)
                {
                    this.PanelResignedIndicator.Visible = true;
                    this.LblResignedDate.Text = employeeDetails.QuitDate.ToLongDateString();
                    this.BtnUndoResignedEmployee.Visible = true;
                }
                else
                {
                    this.PanelResignedIndicator.Visible = false;
                    this.BtnUndoResignedEmployee.Visible = false;
                }

                string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var EmployeeImgsDirInfo = Directory.CreateDirectory($"{appPath}{_otherSettings.EmployeeImgsFileDirName}");

                if (EmployeeImgsDirInfo.Exists)
                {
                    string empImgPath = $"{appPath}\\{_otherSettings.EmployeeImgsFileDirName}\\{employeeDetails.ImageFileName}";

                    if (File.Exists(empImgPath))
                    {
                        PicBoxEmpImage.Image = new Bitmap(empImgPath);
                        PicBoxEmpImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }


                //for(int i=0; i < this.CBoxShiftList.Items.Count; i++)
                //{
                //    var item = this.CBoxShiftList.Items[i] as ComboboxItem;
                //    if (long.Parse(item.Value.ToString()) == employeeDetails.ShiftId)
                //    {
                //        this.CBoxShiftList.SelectedIndex = i;
                //        break;
                //    }
                //}

                for(int i=0; i<this.CBoxBranches.Items.Count; i++)
                {
                    var item = this.CBoxBranches.Items[i] as ComboboxItem;
                    if (long.Parse(item.Value.ToString()) == employeeDetails.BranchId)
                    {
                        this.CBoxBranches.SelectedIndex = i;
                        break;
                    }
                }

                // Select position
                //for (int i = 0; i < this.CBoxPositions.Items.Count; i++)
                //{
                //    var item = this.CBoxPositions.Items[i] as ComboboxItem;
                //    if (long.Parse(item.Value.ToString()) == employeeDetails.PositionId)
                //    {
                //        this.CBoxPositions.SelectedIndex = i;
                //        break;
                //    }
                //}

                // Display salary rate based on position selected
                //if (employeeDetails.Position != null)
                //{
                //    this.TbxDailySalaryRate.Text = employeeDetails.Position.DailyRate.ToString();
                //}
                
                if (employeeDetails.PositionShift != null)
                {
                    ListViewItem item;

                    this.PositionShiftList.Items.Clear();

                    foreach (var positionShift in employeeDetails.PositionShift.ToList())
                    {
                        string[] row = { positionShift.Position, positionShift.Shift,  positionShift.DailyRate.ToString()};
                        item = new ListViewItem(row);
                        this.PositionShiftList.Items.Add(item);
                    }

                    this.PositionShift = employeeDetails.PositionShift;
                }

                var shift = employeeDetails.Shift;
                //this.WorkShiftDays = shift.ShiftDays;
//                DisplayWorkShiftDays();

                DisplayEmployeeGovtIds();
                //DisplayEmployeeSalaryRate();
            }
        }

        private void DisplayEmployeeGovtIds()
        {
            this.ListViewEmpGovtIdCards.Items.Clear();

            if (EmployeeGovtIdCards != null)
            {
                this.BtnDeleteEmpIdCard.Visible = true;

                foreach (var govtId in EmployeeGovtIdCards)
                {
                    if (govtId.EmployeeGovtIdCard != null)
                    {
                        var row = new string[] {
                            govtId.EmployeeGovtIdCard.GovtAgencyEnumVal.ToString(),
                            govtId.EmployeeGovtIdCard.EmployeeIdNumber,
                            (govtId.IsExisting ? "EXISTING" : "NEW"),
                            govtId.EmployeeGovtIdCard.IsDeleted ? "To Delete" : ""
                        };

                        var listViewItem = new ListViewItem(row);
                        listViewItem.Tag = govtId;

                        this.ListViewEmpGovtIdCards.Items.Add(listViewItem);
                    }


                }
            }
        }


        //private void DisplayEmployeeSalaryRate()
        //{
        //    if (this.EmployeeSalary != null)
        //    {
        //        this.TbxSalaryRate.Text = this.EmployeeSalary.SalaryRate.ToString();
        //        this.TboxHalfMonthRate.Text = this.EmployeeSalary.HalfMonthRate.ToString();
        //        this.TbxDailySalaryRate.Text = this.EmployeeSalary.DailyRate.ToString();
        //    }
        //}


        public string UploadEmployeeImage(string employeeNum)
        {
            try
            {
                if (openFileDialogBrowseEmpImg.CheckFileExists)
                {
                    string filename = Path.GetFileName(openFileDialogBrowseEmpImg.FileName);
                    string fileExt = Path.GetExtension(openFileDialogBrowseEmpImg.FileName);
                    if (filename != null && fileExt != null && File.Exists(openFileDialogBrowseEmpImg.FileName))
                    {
                        string employeeImgsDirName = $"\\{_otherSettings.EmployeeImgsFileDirName}\\";

                        string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                        var directoryInfo = Directory.CreateDirectory($"{appPath}{employeeImgsDirName}");

                        string newFileName = $"{employeeNum}{fileExt}";

                        string fullUploadPath = $"{appPath}{employeeImgsDirName}{newFileName}";

                        if (directoryInfo.Exists && File.Exists(fullUploadPath) == true)
                        {
                            //File.Delete(fullUploadPath);
                            return newFileName;
                        }

                        if (directoryInfo.Exists && File.Exists(fullUploadPath) == false)
                        {
                            File.Copy(openFileDialogBrowseEmpImg.FileName, fullUploadPath, true);
                            MessageBox.Show("Image uploaded successfully.", "Upload image", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return newFileName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ ex.Message } { ex.StackTrace }", "File Already exits");
            }
            return "";
        }

        private void BtnSaveEmployee_Click(object sender, EventArgs e)
        {
            //if (this.RBtnUpdate.Checked == false && this.RBtnNew.Checked == false)
            //{
            //    MessageBox.Show("Kindly choose action.", "Save employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            // Workshift
            //var selectedWorkShift = this.CBoxShiftList.SelectedItem as ComboboxItem;
            //if (selectedWorkShift == null)
            //{
            //    MessageBox.Show("Kindly choose emplooyee shift.", "Save employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //long selectedWorkShiftId = long.Parse(selectedWorkShift.Value.ToString());

            // Branch
            var selectedBranch = this.CBoxBranches.SelectedItem as ComboboxItem;
            if (selectedBranch == null)
            {
                MessageBox.Show("Kindly choose branch.", "Save employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            long selectedBranchId = long.Parse(selectedBranch.Value.ToString());

            // Position
            //var selectedPosition = this.CBoxPositions.SelectedItem as ComboboxItem;
            //if (selectedPosition == null)
            //{
            //    MessageBox.Show("Kindly choose employee position.", "Save employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            //long selectedPositionId = long.Parse(selectedPosition.Value.ToString());


            DateTime minDateForEmpBirthDate = DateTime.Now.AddYears(-(_otherSettings.MinAgeForEmployee));

            if (this.DTPicBirthDate.Value > minDateForEmpBirthDate)
            {
                MessageBox.Show($"Invalid employee birth date, the employee should be {_otherSettings.MinAgeForEmployee} years old.", "Save employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            Employee = new EmployeeModel
            {
                FirstName = this.TbxFirstName.Text,
                LastName = this.TbxLastName.Text,
                MiddleName = this.TbxMiddleInitial.Text,
                BirthDate = this.DTPicBirthDate.Value,
                MobileNumber = this.TbxMobileNumber.Text,
                DateHire = this.DTPicHireDate.Value,
                Address = this.TbxAddress.Text,
                EmailAddress = this.TbxEmail.Text,
                //ShiftId = null,
                BranchId = selectedBranchId,
                //PositionId = null,
                PositionShift = this.PositionShift
            };

            if (this.IsNew == false)
            {
                Employee.EmployeeNumber = this.EmployeeNumber;//this.TbxEmployeeNumber.Text;
            }

            OnEmployeeSaved(EventArgs.Empty);
        }

        public void MoveToNextTabSaveEmployeeDetails()
        {
            TabControlSaveEmployeeDetails.SelectedIndex = (TabControlSaveEmployeeDetails.SelectedIndex + 1 < TabControlSaveEmployeeDetails.TabCount) ?
                             TabControlSaveEmployeeDetails.SelectedIndex + 1 : TabControlSaveEmployeeDetails.SelectedIndex;
        }

        public void MoveToLeaveRequestTab()
        {
            TabControlSaveEmployeeDetails.SelectedIndex = 6;
            tabControl1.SelectedIndex = 2;
        }

        private void BtnActionAddNewEmployee_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.BtnCancelUpdateEmployee.Visible = true;
            this.BtnActionUpdateEmployeeDetails.Enabled = false;
            this.LblActionForEmployeeDetails.Text = "Add new employee";

            // if update, disable the update employee button, 
            //the user needs to click cancel in order to choose update employee
            MoveToNextTabSaveEmployeeDetails();
        }

        public void UpdateEmployeeDetails()
        {
            this.ClearForm();
            this.IsNew = false;
            this.GBoxSearchEmployee.Visible = true;
            this.BtnCancelUpdateEmployee.Visible = true;
            this.LblActionForEmployeeDetails.Text = "Update employee details";

            // if update, disable the add employee button, 
            //the user needs to click cancel in order to choose add new
            this.BtnActionAddNewEmployee.Enabled = false;
        }

        private void BtnActionUpdateEmployeeDetails_Click(object sender, EventArgs e)
        {
            UpdateEmployeeDetails();
        }

        private void BtnActionSearchEmployeeByEmployeeNumber_Click(object sender, EventArgs e)
        {
            this.EmployeeNumber = TbxEmployeeNumber.Text;
        }

        private void BtnCancelUpdateEmployee_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

        private void BtnAddNewEmpGovtId_Click(object sender, EventArgs e)
        {
            string empGovtIdNumber = this.TboxEmpIdNumber.Text;
            if (this.CboxGovtAgencies.SelectedIndex >= 0 && string.IsNullOrEmpty(empGovtIdNumber) == false)
            {
                var selectedGovtAgency = this.CboxGovtAgencies.SelectedItem as ComboboxItem;

                if (selectedGovtAgency != null)
                {
                    var selectedGovtAgencyEnum = (StaticData.GovContributions)Enum.Parse(typeof(StaticData.GovContributions), selectedGovtAgency.Value.ToString());

                    var addedNewGovtId = EmployeeGovtIdCards.Where(x =>
                                            x.EmployeeGovtIdCard.GovtAgencyEnumVal == selectedGovtAgencyEnum).FirstOrDefault();

                    var tmpEmployeeGovtIdCard = new EmployeeGovtIdCardTempModel
                    {
                        IsExisting = false,
                        IsNeedToUpdate = false,
                        EmployeeGovtIdCard = new EmployeeGovtIdCardModel
                        {
                            // we can't add the employee number on this code
                            // I assume that every transaction is add new employee, and we will wait for the employee number to generate
                            // I will add the employee number in EmployeeController.cs
                            EmployeeIdNumber = empGovtIdNumber,
                            GovtAgencyEnumVal = selectedGovtAgencyEnum,
                            //GovernmentAgency = new GovernmentAgencyModel
                            //{
                            //    // add temporary object to get the name or title of the govt. agency
                            //    GovtAgency = selectedGovtAgency.Text.ToString()
                            //}
                        }
                    };

                    if (addedNewGovtId == null)
                    {
                        // if completely new id, just add it
                        EmployeeGovtIdCards.Add(tmpEmployeeGovtIdCard);
                    }
                    else if (addedNewGovtId != null)
                    {
                        if (addedNewGovtId.IsExisting)
                        {
                            // if existing in our database, we just need to update
                            // the employee govt. id number
                            addedNewGovtId.IsNeedToUpdate = true;
                            addedNewGovtId.EmployeeGovtIdCard.EmployeeIdNumber = empGovtIdNumber;
                        }
                        else
                        {
                            // if new id, we need to replace
                            EmployeeGovtIdCards.Remove(addedNewGovtId);
                            EmployeeGovtIdCards.Add(tmpEmployeeGovtIdCard);
                        }
                    }
                    this.TboxEmpIdNumber.Text = "";
                    this.CboxGovtAgencies.SelectedIndex = -1;

                    DisplayEmployeeGovtIds();
                }
            }
        }

        private void BtnDeleteEmpIdCard_Click(object sender, EventArgs e)
        {
            if (ListViewEmpGovtIdCards.SelectedItems.Count > 0)
            {
                EmployeeGovtIdCardTempModel selectedEmpGovtId = ListViewEmpGovtIdCards.SelectedItems[0].Tag as EmployeeGovtIdCardTempModel;
                if (selectedEmpGovtId != null)
                {
                    var addedNewGovtId = EmployeeGovtIdCards.Where(x =>
                                            x.EmployeeGovtIdCard.GovtAgencyEnumVal == selectedEmpGovtId.EmployeeGovtIdCard.GovtAgencyEnumVal).FirstOrDefault();

                    if (addedNewGovtId != null)
                    {
                        if (addedNewGovtId.IsExisting == false)
                        {
                            EmployeeGovtIdCards.Remove(addedNewGovtId);
                        }
                        else
                        {
                            addedNewGovtId.EmployeeGovtIdCard.IsDeleted = true;
                            addedNewGovtId.EmployeeGovtIdCard.DeletedAt = DateTime.Now;
                        }
                    }

                    this.TboxEmpIdNumber.Text = "";
                    this.CboxGovtAgencies.SelectedIndex = -1;

                    this.DisplayEmployeeGovtIds();
                }
            }
        }


        private void ListViewEmpGovtIdCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewEmpGovtIdCards.SelectedItems.Count > 0)
            {
                EmployeeGovtIdCardTempModel selectedEmpGovtId = ListViewEmpGovtIdCards.SelectedItems[0].Tag as EmployeeGovtIdCardTempModel;
                if (selectedEmpGovtId != null)
                {
                    var addedNewGovtId = EmployeeGovtIdCards.Where(x =>
                                            x.EmployeeGovtIdCard.GovtAgencyEnumVal == selectedEmpGovtId.EmployeeGovtIdCard.GovtAgencyEnumVal).FirstOrDefault();

                    if (addedNewGovtId != null)
                    {
                        for(int i=0; i< this.CboxGovtAgencies.Items.Count; i++)
                        {
                            var govtAgencyItem = this.CboxGovtAgencies.Items[i] as ComboboxItem;

                            if (govtAgencyItem != null)
                            {
                                var selectedGovtAgencyEnum = (StaticData.GovContributions)Enum.Parse(typeof(StaticData.GovContributions), govtAgencyItem.Value.ToString());

                                if (addedNewGovtId.EmployeeGovtIdCard.GovtAgencyEnumVal == selectedGovtAgencyEnum)
                                {
                                    this.CboxGovtAgencies.SelectedIndex = i;
                                    break;
                                }
                            }
                        }

                        TboxEmpIdNumber.Text = addedNewGovtId.EmployeeGovtIdCard.EmployeeIdNumber;
                    }

                    if (addedNewGovtId.EmployeeGovtIdCard.IsDeleted == true)
                    {
                        this.BtnUndoToDelete.Visible = true;
                    }
                    else
                    {
                        this.BtnUndoToDelete.Visible = false;
                    }
                }
                else
                {
                    this.BtnUndoToDelete.Visible = false;
                }
            }
            else
            {
                this.BtnUndoToDelete.Visible = false;
            }
        }

        private void BtnUndoToDelete_Click(object sender, EventArgs e)
        {
            if (ListViewEmpGovtIdCards.SelectedItems.Count > 0)
            {
                EmployeeGovtIdCardTempModel selectedEmpGovtId = ListViewEmpGovtIdCards.SelectedItems[0].Tag as EmployeeGovtIdCardTempModel;
                if (selectedEmpGovtId != null)
                {
                    var addedNewGovtId = EmployeeGovtIdCards.Where(x =>
                                            x.EmployeeGovtIdCard.GovtAgencyEnumVal == selectedEmpGovtId.EmployeeGovtIdCard.GovtAgencyEnumVal).FirstOrDefault();

                    addedNewGovtId.EmployeeGovtIdCard.IsDeleted = false;
                    addedNewGovtId.EmployeeGovtIdCard.DeletedAt = DateTime.MinValue;

                    this.BtnUndoToDelete.Visible = false;
                    this.DisplayEmployeeGovtIds();
                }
            }
        }

        private void CBoxShiftList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CBoxShiftList.SelectedIndex >= 0)
            {
                var selectedShift = this.CBoxShiftList.SelectedItem as ComboboxItem;

                if (selectedShift != null)
                {
                    SelectedShiftId = long.Parse(selectedShift.Value.ToString());
                    OnWorkShiftSelected(EventArgs.Empty);
                }

            }
        }


        public void DisplayWorkShiftDays()
        {
            this.LblShiftWorkingDays.Text = "";
            // Display shift days
            if (this.WorkShiftDays != null)
            {
                string workDays = string.Join(", ", this.WorkShiftDays.OrderBy(x => x.OrderNum).Select(x => x.DayName).ToArray());
                this.LblShiftWorkingDays.Text = workDays;
            }
        }

        private void BtnBrowseEmployeeImage_Click(object sender, EventArgs e)
        {
            openFileDialogBrowseEmpImg.InitialDirectory = "C://Desktop";
            openFileDialogBrowseEmpImg.Title = "Select image to be upload.";
            openFileDialogBrowseEmpImg.Filter = "Image Only(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            openFileDialogBrowseEmpImg.FilterIndex = 1;

            try
            {
                if (openFileDialogBrowseEmpImg.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialogBrowseEmpImg.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialogBrowseEmpImg.FileName);
                        //label1.Text = path;
                        PicBoxEmpImage.Image = new Bitmap(openFileDialogBrowseEmpImg.FileName);
                        PicBoxEmpImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
            catch (Exception ex)
            {
                //it will give if file is already exits..
                MessageBox.Show(ex.Message);
            }
        }



        // ########################################################

        public void AddThisToAttendanceListView(AttendanceRecordType attendanceRecordType, DateTime day, AttendanceRecord record)
        {
            if (this.AttendanceToDisplay.ContainsKey(day))
            {
                var existingRecord = this.AttendanceToDisplay[day];
                int existingRecordTypeHierarchy = (int)existingRecord.recordType;
                int attendanceRecordTypeHierarchy = (int)attendanceRecordType;

                record.recordType = attendanceRecordType;
                record.WorkDate = day;

                if (attendanceRecordType == AttendanceRecordType.timeInOut)
                {
                    this.AttendanceToDisplay[day] = record;
                }
                else if (attendanceRecordTypeHierarchy > existingRecordTypeHierarchy)
                {
                    this.AttendanceToDisplay[day] = record;
                }
            }
            else
            {
                record.recordType = attendanceRecordType;
                record.WorkDate = day;

                this.AttendanceToDisplay.Add(day, record);
            }
        }



        //public bool CheckIfNotDayOff(DateTime workDay)
        //{
        //    if (WorkShiftDays == null)
        //        return true;

        //    string[] workdays = WorkShiftDays.Select(x => x.DayName).ToList().ToArray();

        //    var workDayName = workDay.ToString("ddd", CultureInfo.InvariantCulture);

        //    return workdays.Contains(workDayName) ;
        //}


        public bool CheckIfNotDayOffBasedOnAttendanceShiftDays(DateTime workDay, EmployeeAttendanceModel attendance)
        {
            if (attendance == null)
                return true;

            if (attendance.Shift == null && attendance.Shift.ShiftDays == null)
                return true;

            string[] workdays = attendance.Shift.ShiftDays.Select(x => x.DayName).ToList().ToArray();

            var workDayName = workDay.ToString("ddd", CultureInfo.InvariantCulture);

            return workdays.Contains(workDayName);
        }


        public bool CheckIfEmpHaveScheduledShift(DateTime workDay)
        {
            var workforceSched = WorkforceSchedules != null ? WorkforceSchedules.Where(x => x.WorkDate == workDay).FirstOrDefault() : null;
            return workforceSched != null;
        }

        public bool CheckIfAbsentOnEmpShift(DateTime workDay, EmployeeAttendanceModel attendance)
        {
            var workforceSched = WorkforceSchedules != null ? WorkforceSchedules.Where(x => x.WorkDate == workDay).FirstOrDefault() : null;

            bool isAbsentOnWorkSched = workforceSched == null ? 
                                        true : 
                                        (workDay.Date < DateTime.Now.Date && workforceSched.isDone == false);

            return CheckIfNotDayOffBasedOnAttendanceShiftDays(workDay, attendance) == true && isAbsentOnWorkSched == true;
        }



        private void AddThisAttendanceRecordToListView (EmployeeAttendanceModel attendance, DateTime day)
        {
            if (attendance == null && CheckIfNotDayOffBasedOnAttendanceShiftDays(day, attendance) == false)
            {
                var row = new string[]
                {
                    day.ToShortDateString(),
                    day.ToString("ddd", CultureInfo.InvariantCulture),
                    "OFF", "", ""
                };

                AddThisToAttendanceListView(AttendanceRecordType.off, day, new AttendanceRecord { record = row });
            }
            else if (attendance == null && CheckIfEmpHaveScheduledShift(day) == false)
            {
                var row = new string[]
                        {
                            day.ToShortDateString(),
                            day.ToString("ddd", CultureInfo.InvariantCulture),
                            "", "", "NO shift sched"
                        };

                AddThisToAttendanceListView(AttendanceRecordType.error, day, new AttendanceRecord { record = row });
            }
            else  if (attendance == null && CheckIfAbsentOnEmpShift(day, attendance))
            { // for absent
                var row = new string[]
                {
                    day.ToShortDateString(),
                    day.ToString("ddd", CultureInfo.InvariantCulture),
                    "", "", "AWOL"
                };

                AddThisToAttendanceListView(AttendanceRecordType.awol, day, new AttendanceRecord { record = row });

            }else 
            {
                if (attendance != null)
                {
                    DateTime firstTimeOut = DateTime.Now;
                    if (attendance.FirstTimeOut == DateTime.MinValue)
                    {
                        firstTimeOut = attendance.Shift.EarlyTimeOut;
                    }
                    else
                    {
                        firstTimeOut = attendance.FirstTimeOut;
                    }

                    string firstTimeINandOUT = $"{attendance.FirstTimeIn.ToString("hh:mm tt")} {firstTimeOut.ToString("hh:mm tt")}";

                    string secondTimeINandOUT = "";

                    if (attendance.IsTimeOutProvided)
                    {
                        secondTimeINandOUT = $"{attendance.SecondTimeIn.ToString("hh:mm tt")} {attendance.SecondTimeOut.ToString("hh:mm tt")}";
                    }

                    string wholeDayTotalHrs = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.TotalHrs); //attendance.FirstHalfHrs + attendance.SecondHalfHrs
                    string late = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.TotalLate); // attendance.FirstHalfLateMins + attendance.SecondHalfLateMins
                    string underTime = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.TotalUnderTime); //attendance.FirstHalfUnderTimeMins + attendance.SecondHalfUnderTimeMins
                    string overTime = _decimalMinutesToHrsConverter.ConvertToStringHrs(attendance.OverTimeMins);

                    var row = new string[]
                    {
                    attendance.WorkDate.ToShortDateString(),
                    day.ToString("ddd", CultureInfo.InvariantCulture),
                    attendance.Shift.Shift,
                    $"{attendance.Shift.StartTime.ToString("hh:mm tt")} to {attendance.Shift.EndTime.ToString("hh:mm tt")}",
                    firstTimeINandOUT,
                    secondTimeINandOUT,
                    wholeDayTotalHrs,
                    late,
                    underTime,
                    overTime,
                    attendance.IsPaid ? "Paid" : ""
                    };


                    AddThisToAttendanceListView(AttendanceRecordType.timeInOut, day, new AttendanceRecord { record = row });
                }
                else
                {
                    if (day.Date <= DateTime.Now.Date)
                    {
                        var row = new string[]
                        {
                            day.ToShortDateString(),
                            day.ToString("ddd", CultureInfo.InvariantCulture),
                            "", "", "NO Attendance record"
                        };

                        AddThisToAttendanceListView(AttendanceRecordType.error, day, new AttendanceRecord { record = row });
                    }
                }
            }
        }


        private void DisplayThisEmployeeLeaveRecInListInview(EmployeeLeaveModel leave, DateTime currentDate)
        {
            if (leave != null)
            {
                var row = new string[]
                {
                    currentDate.ToShortDateString(),
                    currentDate.ToString("ddd", CultureInfo.InvariantCulture),
                    $"LV: {leave.LeaveType.LeaveType}",
                    "",
                    leave.StartDate.ToShortDateString(),
                    leave.EndDate.ToShortDateString(),
                    leave.NumberOfDays.ToString() + "d",
                    "","","",""
                };


                AddThisToAttendanceListView(AttendanceRecordType.leave, currentDate, new AttendanceRecord { record = row });

            }
        }

        private void DisplayThisHolidayListInview(HolidayModel holiday, DateTime currentDate)
        {
            if (holiday != null)
            {
                var row = new string[]
                {
                    currentDate.ToShortDateString(),
                    currentDate.ToString("ddd", CultureInfo.InvariantCulture),
                    $"HD: {holiday.Holiday}",
                    "","", "", "","","","",""
                };


                AddThisToAttendanceListView(AttendanceRecordType.holiday, currentDate, new AttendanceRecord { record = row });
            }
        }


        public void DisplayAttendanceFromTemporaryLocation()
        {
            if (this.AttendanceToDisplay != null)
            {
                this.LViewAttendanceHistory.Items.Clear();

                foreach (var record in this.AttendanceToDisplay)
                {
                    var listViewItem = new ListViewItem(record.Value.record);

                    if (record.Value.recordType == AttendanceRecordType.timeInOut)
                    {
                        listViewItem.ForeColor = Color.FromArgb(50, 168, 82); // green
                    }else if (record.Value.recordType == AttendanceRecordType.awol)
                    {
                        listViewItem.ForeColor = Color.FromArgb(207, 54, 54); // red
                    }

                    this.LViewAttendanceHistory.Items.Add(listViewItem);
                }
            }
        }


        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public void DisplayAttendanceRecord(DateTime startDate, DateTime endDate)
        {
            if (this.AttendanceHistory != null)
            {
                this.AttendanceToDisplay = new Dictionary<DateTime, AttendanceRecord>();

                foreach (DateTime day in EachDay(startDate, endDate))
                {
                    var dayAttendanceRec = this.AttendanceHistory.Where(x => x.WorkDate == day).FirstOrDefault();
                    var dayLeaveRec = this.EmployeeLeaveHistory.Where(x => x.StartDate <= day && x.EndDate >= day).FirstOrDefault();
                    var holidayRec = this.Holidays.Where(x => 
                                        x.DayNum == day.Day && 
                                        x.MonthAbbr == day.ToString("MMM", CultureInfo.InvariantCulture)).FirstOrDefault();

                    AddThisAttendanceRecordToListView(dayAttendanceRec, day);
                    DisplayThisEmployeeLeaveRecInListInview(dayLeaveRec, day);
                    DisplayThisHolidayListInview(holidayRec, day);
                }

                DisplayAttendanceFromTemporaryLocation();
            }
        }


        private List<DateTime> payslipPaydates;

        public List<DateTime> PayslipPaydates
        {
            get { return payslipPaydates; }
            set { payslipPaydates = value; }
        }

        public void DisplayEmpPayslipPaydateList()
        {
            // Work shifts load in combo box
            if (this.PayslipPaydates != null)
            {
                ComboboxItem item;
                foreach (var paydate in this.PayslipPaydates)
                {
                    item = new ComboboxItem();
                    item.Text = paydate.ToShortDateString();
                    item.Value = paydate;
                    this.CBoxPayslipPaydateList.Items.Add(item);
                }
            }
        }


        private DateTime filterAttendanceStartDate;

        public DateTime FilterAttendanceStartDate
        {
            get { return filterAttendanceStartDate; }
            set { filterAttendanceStartDate = value; }
        }


        private DateTime filterAttendanceEndDate;
        private readonly Sessions _sessions;
        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;
        private readonly OtherSettings _otherSettings;
        private readonly PayrollSettings _payrollSettings;
        private readonly IAttendancePDFReport _attendancePDFReport;

        public DateTime FilterAttendanceEndDate
        {
            get { return filterAttendanceEndDate; }
            set { filterAttendanceEndDate = value; }
        }


        // Event handler for saving leave type
        public event EventHandler FilterEmployeeAttendance;
        protected virtual void OnFilterEmployeeAttendance(EventArgs e)
        {
            FilterEmployeeAttendance?.Invoke(this, e);
        }


        private void BtnFilterAttendanceHistory_Click(object sender, EventArgs e)
        {
            FilterAttendanceStartDate = this.DPickerFilterAttendanceStartDate.Value;
            FilterAttendanceEndDate = this.DPickerFilterAttendanceEndDate.Value;

            if (string.IsNullOrEmpty(this.EmployeeNumber))
            {
                MessageBox.Show("Search employee first.", "Search employee details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OnFilterEmployeeAttendance(EventArgs.Empty);
        }

        private void TbxEmployeeNumber_KeyUp(object sender, KeyEventArgs e)
        {

        }


        public DateTime SelectedPayslipPaydateToView { get; set; }

        public event EventHandler FilterEmployeePayslip;
        protected virtual void OnFilterEmployeePayslip(EventArgs e)
        {
            FilterEmployeePayslip?.Invoke(this, e);
        }

        private void BtnFilterPayslipByPaydate_Click(object sender, EventArgs e)
        {
            var selectedPaydate = this.CBoxPayslipPaydateList.SelectedItem as ComboboxItem;
            if (selectedPaydate != null)
            {
                SelectedPayslipPaydateToView = DateTime.Parse(selectedPaydate.Value.ToString());
                OnFilterEmployeePayslip(EventArgs.Empty);
            }
        }

        public void DisplayEmployeePayslip(EmployeeModel employee, EmployeePayslipModel payslip)
        {
            if (employee != null && payslip != null)
            {
                this.PanelPayslipDetailsContainer.Controls.Clear();
                var payslipItemControlObj = new PayslipItemControl { Employee = employee, Payslip = payslip };
                payslipItemControlObj.Location = new Point(this.PanelPayslipDetailsContainer.Width / 2 - payslipItemControlObj.Size.Width / 2, this.PanelPayslipDetailsContainer.Height / 2 - payslipItemControlObj.Size.Height / 2);
                payslipItemControlObj.Anchor = AnchorStyles.None;
                this.PanelPayslipDetailsContainer.Controls.Add(payslipItemControlObj);
            }
        }

        public event EventHandler MarkEmployeeAsResigned;
        protected virtual void OnMarkEmployeeAsResigned(EventArgs e)
        {
            MarkEmployeeAsResigned?.Invoke(this, e);
        }
        private void BtnMarkAsResignedThisEmployee_Click(object sender, EventArgs e)
        {
            OnMarkEmployeeAsResigned(EventArgs.Empty);
        }


        public event EventHandler MarkEmployeeAsDeleted;
        protected virtual void OnMarkEmployeeAsDeleted(EventArgs e)
        {
            MarkEmployeeAsDeleted?.Invoke(this, e);
        }
        private void BtnDeleteThisEmployee_Click(object sender, EventArgs e)
        {
            OnMarkEmployeeAsDeleted(EventArgs.Empty);
        }

        public event EventHandler UndoMarkEmployeeAsResigned;
        protected virtual void OnUndoMarkEmployeeAsResigned(EventArgs e)
        {
            UndoMarkEmployeeAsResigned?.Invoke(this, e);
        }
        private void BtnUndoResignedEmployee_Click(object sender, EventArgs e)
        {
            OnUndoMarkEmployeeAsResigned(EventArgs.Empty);
        }

        private void BtnGenerateAttendanceReportPDF_Click(object sender, EventArgs e)
        {
            if (this.AttendanceToDisplay != null && this.CurrentEmployeeDetails != null)
            {
                _attendancePDFReport.GenerateAttendanceReportPDF(this.AttendanceToDisplay, this.CurrentEmployeeDetails);

                MessageBox.Show($"Attendance PDF report successfully generated, kindly check in {_payrollSettings.GeneratedPDFLoc}", "Search employee details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void SetDGVEmployeeLeaveHistoryFontAndColors()
        {
            this.DGVEmployeeLeaveHistory.BackgroundColor = Color.White;
            this.DGVEmployeeLeaveHistory.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVEmployeeLeaveHistory.RowHeadersVisible = false;
            this.DGVEmployeeLeaveHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeLeaveHistory.AllowUserToResizeRows = false;
            this.DGVEmployeeLeaveHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVEmployeeLeaveHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVEmployeeLeaveHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeLeaveHistory.MultiSelect = false;

            this.DGVEmployeeLeaveHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeLeaveHistory.ColumnHeadersHeight = 30;

            // =============================
            this.DGVEmployeeLeaveApproval.BackgroundColor = Color.White;
            this.DGVEmployeeLeaveApproval.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVEmployeeLeaveApproval.RowHeadersVisible = false;
            this.DGVEmployeeLeaveApproval.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeLeaveApproval.AllowUserToResizeRows = false;
            this.DGVEmployeeLeaveApproval.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVEmployeeLeaveApproval.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVEmployeeLeaveApproval.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeLeaveApproval.MultiSelect = false;

            this.DGVEmployeeLeaveApproval.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeLeaveApproval.ColumnHeadersHeight = 30;
        }

        public void DisplayLeaveTypes()
        {
            if (this.LeaveTypes != null)
            {
                ComboboxItem item;
                foreach (var leaveType in this.LeaveTypes)
                {
                    item = new ComboboxItem();
                    item.Text = $"{ leaveType.LeaveType} ({leaveType.NumberOfDays} days)";
                    item.Value = leaveType.Id;
                    this.CBoxLeaveTypes.Items.Add(item);
                }
            }

            ComboboxItem durationItem;
            foreach (var duration in StaticData.GetLeaveDurationTypes)
            {
                durationItem = new ComboboxItem();
                durationItem.Text = duration.Value;
                durationItem.Value = duration.Key; // enum value
                this.CboxDuration.Items.Add(durationItem);
            }

            int startingYear = 2021;
            int currentDate = 2025;

            ComboboxItem yearItem;
            for (int year = startingYear; year <= currentDate; year++)
            {

                yearItem = new ComboboxItem();
                yearItem.Text = year.ToString();
                yearItem.Value = year;
                this.CBoxYearList.Items.Add(yearItem);
            }
        }

        public void DisplayEmployeeLeavesInDGV()
        {
            this.DGVEmployeeLeaveHistory.Rows.Clear();
            if (this.EmployeeLeaveHistory != null)
            {
                this.DGVEmployeeLeaveHistory.ColumnCount = 7;

                this.DGVEmployeeLeaveHistory.Columns[0].Name = "EmployeeLeaveRecordId";
                this.DGVEmployeeLeaveHistory.Columns[0].Visible = false;

                this.DGVEmployeeLeaveHistory.Columns[1].Name = "LeaveType";
                this.DGVEmployeeLeaveHistory.Columns[1].HeaderText = "Leave type";

                this.DGVEmployeeLeaveHistory.Columns[2].Name = "DurationType";
                this.DGVEmployeeLeaveHistory.Columns[2].HeaderText = "DurationType";

                this.DGVEmployeeLeaveHistory.Columns[3].Name = "CreatedAt";
                this.DGVEmployeeLeaveHistory.Columns[3].HeaderText = "Created At";

                this.DGVEmployeeLeaveHistory.Columns[4].Name = "NumberDays";
                this.DGVEmployeeLeaveHistory.Columns[4].HeaderText = "Days";

                this.DGVEmployeeLeaveHistory.Columns[5].Name = "DateRange";
                this.DGVEmployeeLeaveHistory.Columns[5].HeaderText = "Date";

                this.DGVEmployeeLeaveHistory.Columns[6].Name = "ApprovalStatus";
                this.DGVEmployeeLeaveHistory.Columns[6].HeaderText = "Approval";

                // Delete button
                DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVEmployeeLeaveHistory.Columns.Add(btnDeleteImg);

                foreach (var record in this.EmployeeLeaveHistory)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVEmployeeLeaveHistory);

                    row.Cells[0].Value = record.Id;
                    row.Cells[1].Value = record.LeaveType.LeaveType;
                    row.Cells[2].Value = record.DurationType;
                    row.Cells[3].Value = record.CreatedAt.ToShortDateString();
                    row.Cells[4].Value = record.NumberOfDays;
                    row.Cells[5].Value = $"{record.StartDate.ToString("MMM-dd")} to {record.EndDate.ToString("MMM-dd")}";
                    row.Cells[6].Value = record.ApprovalStatus.ToString();

                    this.DGVEmployeeLeaveHistory.Rows.Add(row);
                }
            }

        }



        public void DisplayEmployeeLeavesForApprovalInDGV()
        {
            this.DGVEmployeeLeaveApproval.Rows.Clear();
            if (this.EmployeeLeaveForApproval != null)
            {
                this.DGVEmployeeLeaveApproval.ColumnCount = 7;

                this.DGVEmployeeLeaveApproval.Columns[0].Name = "EmployeeLeaveRecordId";
                this.DGVEmployeeLeaveApproval.Columns[0].Visible = false;

                this.DGVEmployeeLeaveApproval.Columns[1].Name = "LeaveType";
                this.DGVEmployeeLeaveApproval.Columns[1].HeaderText = "Leave type";

                this.DGVEmployeeLeaveApproval.Columns[2].Name = "DurationType";
                this.DGVEmployeeLeaveApproval.Columns[2].HeaderText = "DurationType";

                this.DGVEmployeeLeaveApproval.Columns[3].Name = "CreatedAt";
                this.DGVEmployeeLeaveApproval.Columns[3].HeaderText = "Created At";

                this.DGVEmployeeLeaveApproval.Columns[4].Name = "NumberDays";
                this.DGVEmployeeLeaveApproval.Columns[4].HeaderText = "Days";

                this.DGVEmployeeLeaveApproval.Columns[5].Name = "DateRange";
                this.DGVEmployeeLeaveApproval.Columns[5].HeaderText = "Date";

                this.DGVEmployeeLeaveApproval.Columns[6].Name = "ApprovalStatus";
                this.DGVEmployeeLeaveApproval.Columns[6].HeaderText = "Approval";

                //// Delete button
                //DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                ////btnDeleteLeaveTypeImg.Name = "";
                //btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                //this.DGVEmployeeLeaveApproval.Columns.Add(btnDeleteImg);

                foreach (var record in this.EmployeeLeaveForApproval)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVEmployeeLeaveApproval);

                    row.Cells[0].Value = record.Id;
                    row.Cells[1].Value = record.LeaveType.LeaveType;
                    row.Cells[2].Value = record.DurationType;
                    row.Cells[3].Value = record.CreatedAt.ToShortDateString();
                    row.Cells[4].Value = record.NumberOfDays;
                    row.Cells[5].Value = $"{record.StartDate.ToString("MMM-dd")} to {record.EndDate.ToString("MMM-dd")}";
                    row.Cells[6].Value = record.ApprovalStatus.ToString();

                    this.DGVEmployeeLeaveApproval.Rows.Add(row);
                }
            }

        }


        public event EventHandler EmployeeRemainingLeaveFetch;
        protected virtual void OnEmployeeRemainingLeaveFetch(EventArgs e)
        {
            EmployeeRemainingLeaveFetch?.Invoke(this, e);
        }

        private LeaveTypeModel selectedLeaveType;

        public LeaveTypeModel SelectedLeaveType
        {
            get { return selectedLeaveType; }
            set { selectedLeaveType = value; }
        }

        private void CBoxLeaveTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CBoxLeaveTypes.SelectedIndex >= 0)
            {
                var selectedLeaveType = this.CBoxLeaveTypes.SelectedItem as ComboboxItem;
                if (selectedLeaveType != null)
                {
                    var selectedLeaveTypeId = long.Parse(selectedLeaveType.Value.ToString());
                    var leaveType = this.LeaveTypes.Where(x => x.Id == selectedLeaveTypeId).FirstOrDefault();

                    if (leaveType != null)
                    {
                        this.SelectedLeaveType = leaveType;
                        OnEmployeeRemainingLeaveFetch(EventArgs.Empty);
                    }
                }
            }
        }

        public decimal EmployeeRemainingLeaveCountBaseOnSelectedLeave { get; set; }
        public void DisplayEmpRemainingLeaveCount(decimal leaveCount)
        {
            EmployeeRemainingLeaveCountBaseOnSelectedLeave = leaveCount;
            this.LblRemainingLeave.Text = leaveCount.ToString();
        }

        // Event handler for saving
        public event EventHandler EmployeeLeaveSaved;
        protected virtual void OnEmployeeLeaveSaved(EventArgs e)
        {
            EmployeeLeaveSaved?.Invoke(this, e);
        }

        private EmployeeLeaveModel newEmployeeLeave;

        public EmployeeLeaveModel NewEmployeeLeave
        {
            get { return newEmployeeLeave; }
            set { newEmployeeLeave = value; }
        }


        public void ResetEmployeeFileLeaveForm()
        {
            this.CBoxLeaveTypes.SelectedIndex = -1;
            this.LblRemainingLeave.Text = "0";
            this.TboxLeaveReason.Text = "";
            this.DPickerDurationStartDate.Value = DateTime.Now;
            this.DPickerDurationEndDate.Value = DateTime.Now;
        }

        private void BtnSaveEmployeeLeave_Click(object sender, EventArgs e)
        {
            if (SelectedLeaveType == null)
            {
                MessageBox.Show("Select leave type", "Save employee leave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selectedDurationItem = this.CboxDuration.SelectedItem as ComboboxItem;
            var durationType = (StaticData.LeaveDurationType)selectedDurationItem.Value;

            DateTime startDate = this.DPickerDurationStartDate.Value.Date;
            DateTime endDate = this.DPickerDurationEndDate.Value.Date;

            if (startDate < DateTime.Now.Date)
            {
                MessageBox.Show("Invalid start date", "Save employee leave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TimeSpan duration = endDate.Subtract(startDate);
            decimal durationTotalDays = 0;

            if (startDate == endDate)
            {
                durationTotalDays = 1;
            }
            else
            {
                durationTotalDays = (decimal)duration.TotalDays;
            }

            decimal remainingLeaveCount = EmployeeRemainingLeaveCountBaseOnSelectedLeave - durationTotalDays;

            this.NewEmployeeLeave = new EmployeeLeaveModel
            {
                LeaveId = SelectedLeaveType.Id,
                EmployeeNumber = this.EmployeeNumber,
                Reason = this.TboxLeaveReason.Text,
                DurationType = durationType,
                StartDate = startDate,
                EndDate = endDate,
                //NumberOfDays = durationTotalDays,
                RemainingDays = remainingLeaveCount,
                CurrentYear = DateTime.Now.Year
            };

            OnEmployeeLeaveSaved(EventArgs.Empty);
        }

        public long EmployeeLeaveIdToDelete { get; set; }

        public event EventHandler DeleteEmployeeLeave;
        protected virtual void OnDeleteEmployeeLeave(EventArgs e)
        {
            DeleteEmployeeLeave?.Invoke(this, e);
        }

        private void DGVEmployeeLeaveHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Delete button
            if ((e.ColumnIndex == 7) && e.RowIndex > -1)
            {
                if (DGVEmployeeLeaveHistory.CurrentRow != null)
                {
                    string employeeLeaveId = DGVEmployeeLeaveHistory.CurrentRow.Cells[0].Value.ToString();
                    EmployeeLeaveIdToDelete = long.Parse(employeeLeaveId);
                    OnDeleteEmployeeLeave(EventArgs.Empty);
                }
            }

            if (e.RowIndex > -1)
            {
                if (DGVEmployeeLeaveHistory.CurrentRow != null)
                {
                    string employeeLeaveId = DGVEmployeeLeaveHistory.CurrentRow.Cells[0].Value.ToString();
                    long selectedLeaveId = long.Parse(employeeLeaveId);
                    var employeeLeaveDetais = this.EmployeeLeaveHistory.Where(x => x.Id == selectedLeaveId).FirstOrDefault();
                    
                    if (employeeLeaveDetais != null)
                    {
                        this.TBoxEmployerEnteredRemarks.Text = employeeLeaveDetais.EmployerRemarks;
                        this.TBoxEmployeeLeaveReason.Text = employeeLeaveDetais.Reason;
                    }
                }
            }

        }


        public event EventHandler FilterEmployeeLeave;
        protected virtual void OnFilterEmployeeLeave(EventArgs e)
        {
            FilterEmployeeLeave?.Invoke(this, e);
        }

        public int FilterEmployeeLeaveHistoryYear
        {
            get; set;
        }

        private void BtnFilterEmployeeLeaveHistory_Click(object sender, EventArgs e)
        {
            var selectedYear = this.CBoxYearList.SelectedItem as ComboboxItem;
            if (selectedYear != null)
            {
                this.FilterEmployeeLeaveHistoryYear = int.Parse(selectedYear.Value.ToString());
                OnFilterEmployeeLeave(EventArgs.Empty);
            }
        }

        private void DGVEmployeeLeaveApproval_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVEmployeeLeaveApproval.CurrentRow != null)
                {
                    string employeeLeaveId = DGVEmployeeLeaveApproval.CurrentRow.Cells[0].Value.ToString();
                    long selectedLeaveId = long.Parse(employeeLeaveId);
                    var employeeLeaveDetais = this.EmployeeLeaveForApproval.Where(x => x.Id == selectedLeaveId).FirstOrDefault();

                    if (employeeLeaveDetais != null)
                    {
                        this.TboxEmployeeLeaveRemarks.Text = employeeLeaveDetais.Reason;
                    }
                }
            }
        }


        public event EventHandler EmployeeLeaveApprovedOrDisapproved;
        protected virtual void OnEmployeeLeaveApproval(EventArgs e)
        {
            EmployeeLeaveApprovedOrDisapproved?.Invoke(this, e);
        }

        public long SelectedLeaveIdForApproval { get; set; }
        public string EmployeeLeaveApprovalRemarks { get; set; }
        public StaticData.EmployeeRequestApprovalStatus EmployeeLeaveApprovalStatus { get; set; }

        private void EmployeeLeaveApproval (StaticData.EmployeeRequestApprovalStatus status)
        {
            if (string.IsNullOrEmpty(TboxAdminRemarks.Text))
            {
                MessageBox.Show("Your remarks is required", "Approval", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (DGVEmployeeLeaveApproval.CurrentRow != null)
            {
                DialogResult res = MessageBox.Show($"Continue to {status}?", "Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    string remarks = TboxAdminRemarks.Text;

                    string employeeLeaveId = DGVEmployeeLeaveApproval.CurrentRow.Cells[0].Value.ToString();

                    this.EmployeeLeaveApprovalRemarks = TboxAdminRemarks.Text;
                    this.SelectedLeaveIdForApproval = long.Parse(employeeLeaveId);
                    this.EmployeeLeaveApprovalStatus = status;

                    OnEmployeeLeaveApproval(EventArgs.Empty);
                }
            }
        }


        private void BtnApprovedEmpLeave_Click(object sender, EventArgs e)
        {
            this.EmployeeLeaveApproval(EmployeeRequestApprovalStatus.Approved);
        }

        private void BtnDisapprovedEmpLeave_Click(object sender, EventArgs e)
        {
            this.EmployeeLeaveApproval(EmployeeRequestApprovalStatus.Disapproved);
        }


        public DateTime SelectedDateForPayslipToGeneratePDF { get; set; }

        public event EventHandler GeneratePayslipPDFForSelectedEmployee;
        protected virtual void OnGeneratePayslipPDFForSelectedEmployee(EventArgs e)
        {
            GeneratePayslipPDFForSelectedEmployee?.Invoke(this, e);
        }

        private void BtnGeneratePDF_Click(object sender, EventArgs e)
        {
            var selectedPaydate = this.CBoxPayslipPaydateList.SelectedItem as ComboboxItem;
            if (selectedPaydate != null)
            {
                SelectedDateForPayslipToGeneratePDF = DateTime.Parse(selectedPaydate.Value.ToString());
                OnGeneratePayslipPDFForSelectedEmployee(EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem item;

            var selectedPosition = this.CBoxPositions.SelectedItem as ComboboxItem;
            var selectedShift = this.CBoxShiftList.SelectedItem as ComboboxItem;
            if (selectedPosition == null || selectedShift == null)
            {
                MessageBox.Show("Please select position and shift.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedWorkingDays = _employeeShiftDayData.GetByShiftId((long)selectedShift.Value);
            var dailyRate = _employeePositionData.GetAll().Where(x => x.Id == (long)selectedPosition.Value).Select(s => s.DailyRate).FirstOrDefault();

            EmployeePositionShiftModel positionShift = new EmployeePositionShiftModel()
            {
                PositionId = (long)selectedPosition.Value,
                Position = selectedPosition.Text,
                ShiftId = (long)selectedShift.Value,
                Shift = selectedShift.Text,
                WorkingDays = selectedWorkingDays,
                DailyRate = dailyRate
            };

            if (PositionShift == null)
            {
                PositionShift = new List<EmployeePositionShiftModel>();
            }

            bool isConflict = false;
            List<EmployeePositionShiftModel> conflictSchedList = new List<EmployeePositionShiftModel>();
            
            if (PositionShift.Any())
            {
                foreach (var days in positionShift.WorkingDays.ToList())
                {
                    foreach (var shift in PositionShift.ToList())
                    {
                        foreach (var selectedDays in shift.WorkingDays.ToList())
                        {
                            if (selectedDays.DayName.Contains(days.DayName))
                            {
                                conflictSchedList.Add(shift);
                                break;
                            }
                        }
                    }
                }

                if (conflictSchedList.Any())
                {
                    conflictSchedList = conflictSchedList.Distinct().ToList();
                }

                foreach (var sched in conflictSchedList.ToList())
                {
                    var conflictSched = this.WorkShifts.Where(x => x.Id == sched.ShiftId).FirstOrDefault();
                    var selectedPositionShift = this.WorkShifts.Where(x => x.Id == positionShift.ShiftId).FirstOrDefault();
                    isConflict = conflictSched.StartTime < selectedPositionShift.EndTime && selectedPositionShift.StartTime < conflictSched.EndTime;
                    if (isConflict)
                    {
                        break;
                    }
                }
            }

            var isPositionExist = PositionShift.Where(x => x.PositionId == positionShift.PositionId && x.ShiftId == positionShift.ShiftId).Any();
            var isShiftConflicts = PositionShift.Where(x => x.ShiftId == positionShift.ShiftId).Any();

            if (isPositionExist && isShiftConflicts)
            {
                MessageBox.Show("Position and shift schedule already added. Please select different position or shift schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (isShiftConflicts && !isPositionExist || isConflict)
            {
                MessageBox.Show("Shift schedule conflict. Please select different shift schedule.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PositionShift.Add(positionShift);

            string[] row = { positionShift.Position, positionShift.Shift, positionShift.DailyRate.ToString() };
            item = new ListViewItem(row);
            this.PositionShiftList.Items.Add(item);
            this.CBoxShiftList.SelectedIndex = -1;
            this.CBoxPositions.SelectedIndex = -1;

        }

        private void PositionShiftList_Click(object sender, EventArgs e)
        {
            if (this.PositionShiftList.SelectedIndices.Count > 0)
            {
                int index = this.PositionShiftList.SelectedIndices[0];
                this.selectedPositionShiftIndex = index;
                this.button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.selectedPositionShiftIndex > -1)
            {
                this.PositionShiftList.Items.RemoveAt(this.selectedPositionShiftIndex);
                this.PositionShift.RemoveAt(this.selectedPositionShiftIndex);
                this.selectedPositionShiftIndex = -1;
                this.button2.Enabled = false;
            }
        }
    }
}
