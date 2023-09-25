using EntitiesShared.EmployeeManagement;
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

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class EmployeeLeaveManagementControl : UserControl
    {
        public EmployeeLeaveManagementControl()
        {
            InitializeComponent();
        }

        private List<LeaveTypeModel> leaveLypes;

        public List<LeaveTypeModel> LeaveTypes
        {
            get { return leaveLypes; }
            set { leaveLypes = value; }
        }

        private LeaveTypeModel selectedLeaveType;

        public LeaveTypeModel SelectedLeaveType
        {
            get { return selectedLeaveType; }
            set { selectedLeaveType = value; }
        }


        public decimal EmployeeRemainingLeaveCountBaseOnSelectedLeave { get; set; }
        public void DisplayEmpRemainingLeaveCount(decimal leaveCount)
        {
            EmployeeRemainingLeaveCountBaseOnSelectedLeave = leaveCount;
            this.LblRemainingLeave.Text = leaveCount.ToString();
        }


        public event EventHandler EmployeeRemainingLeaveFetch;
        protected virtual void OnEmployeeRemainingLeaveFetch(EventArgs e)
        {
            EmployeeRemainingLeaveFetch?.Invoke(this, e);
        }


        private List<EmployeeLeaveModel> employeeLeaveHistory;

        public List<EmployeeLeaveModel> EmployeeLeaveHistory
        {
            get { return employeeLeaveHistory; }
            set { employeeLeaveHistory = value; }
        }

        public void DisplayEmployeeLeaveHistory()
        {
            if (this.EmployeeLeaveHistory != null)
            {
                FLPanelEmployeeLeaveHistory.Controls.Clear();

                foreach (var empLeave in this.EmployeeLeaveHistory)
                {
                    var leaveItem = new EmployeeLeaveItem
                    {
                        LeaveId = empLeave.Id,
                        LeaveType = empLeave.LeaveType.LeaveType,
                        CreatedAT = empLeave.CreatedAt.ToShortDateString(),
                        Duration = $"{empLeave.StartDate.ToShortDateString()} to {empLeave.EndDate.ToShortDateString()}",
                        Reason = empLeave.Reason
                    };

                    leaveItem.DeleteThisItem += HandleDeleteEmployeeLeave;

                    FLPanelEmployeeLeaveHistory.Controls.Add(leaveItem);
                }
            }
        }

        private void HandleDeleteEmployeeLeave(object sender, EventArgs e)
        {
            EmployeeLeaveItem leaveItem = (EmployeeLeaveItem)sender;
            EmployeeLeaveId = leaveItem.LeaveId;
            OnDeleteEmployeeLeave(EventArgs.Empty);
        }


        private EmployeeLeaveModel newEmployeeLeave;

        public EmployeeLeaveModel NewEmployeeLeave
        {
            get { return newEmployeeLeave; }
            set { newEmployeeLeave = value; }
        }


        private void EmployeeLeaveManagementControl_Load(object sender, EventArgs e)
        {
            if (this.LeaveTypes != null)
            {
                ComboboxItem item;
                foreach (var leaveType in this.LeaveTypes)
                {
                    item = new ComboboxItem();
                    item.Text = leaveType.LeaveType;
                    item.Value = leaveType.Id;
                    this.CBoxLeaveTypes.Items.Add(item);
                }
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

        private void CBoxLeaveTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CBoxLeaveTypes.SelectedIndex >= 0)
            {
                if (string.IsNullOrEmpty(this.TboxEmployeeToSearch.Text))
                {
                    MessageBox.Show("Kindly input employee number.", "Searching employee remaining leave count.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                var selectedLeaveType = this.CBoxLeaveTypes.SelectedItem as ComboboxItem;
                if (selectedLeaveType != null)
                {
                    var selectedLeaveTypeId = long.Parse(selectedLeaveType.Value.ToString());
                    var leaveType = this.LeaveTypes.Where(x => x.Id == selectedLeaveTypeId).FirstOrDefault();

                    if (leaveType != null)
                    {
                        this.SelectedLeaveType = leaveType;
                        this.LblLeaveDayCounts.Text = leaveType.NumberOfDays.ToString();
                        OnEmployeeRemainingLeaveFetch(EventArgs.Empty);
                    }
                }
            }
        }


        public event PropertyChangedEventHandler PropSelectedEmpShiftIdToUpdateChanged;

        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { 
                employeeNumber = value; 
                
                if (PropSelectedEmpShiftIdToUpdateChanged != null)
                {
                    PropSelectedEmpShiftIdToUpdateChanged(this, new PropertyChangedEventArgs(EmployeeNumber));
                }
            }
        }

        public event EventHandler DeleteEmployeeLeave;
        protected virtual void OnDeleteEmployeeLeave(EventArgs e)
        {
            DeleteEmployeeLeave?.Invoke(this, e);
        }

        private long employeeLeaveId;

        public long EmployeeLeaveId
        {
            get { return employeeLeaveId; }
            set { employeeLeaveId = value; }
        }


        public event EventHandler FilterEmployeeLeave;
        protected virtual void OnFilterEmployeeLeave(EventArgs e)
        {
            FilterEmployeeLeave?.Invoke(this, e);
        }

        public int FilterEmployeeLeaveHistoryYear
        {
            get;set;
        }

        private EmployeeModel employee;

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }



        private EmployeeLeaveModel employeeLeaveToAdd;

        public EmployeeLeaveModel EmployeeLeaveToAdd
        {
            get { return employeeLeaveToAdd; }
            set { employeeLeaveToAdd = value; }
        }

        // Event handler for saving
        public event EventHandler EmployeeLeaveSaved;
        protected virtual void OnEmployeeLeaveSaved(EventArgs e)
        {
            EmployeeLeaveSaved?.Invoke(this, e);
        }

        private void BtnSearchEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TboxEmployeeToSearch.Text) == false)
                this.EmployeeNumber = this.TboxEmployeeToSearch.Text;
        }

        public void DisplaySearchEmployee()
        {
            if (this.Employee != null)
            {
                this.LblSelectedEmployeeFullname.Text = $"{this.Employee.LastName.ToUpper()} {this.Employee.FirstName}, {this.Employee.MiddleName}";
                this.LblEmployeePosition.Text = this.Employee.Position.Title;
            }
        }

        private void BtnSaveEmployeeLeave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.TboxEmployeeToSearch.Text))
            {
                MessageBox.Show("Enter employee number", "Save employee leave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (SelectedLeaveType == null)
            {
                MessageBox.Show("Select leave type", "Save employee leave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TimeSpan duration = this.DPickerDurationEndDate.Value - this.DPickerDurationStartDate.Value;
            decimal durationTotalDays = 0;

            if (this.DPickerDurationEndDate.Value == this.DPickerDurationStartDate.Value)
            {
                durationTotalDays = 1;
            }
            else
            {
                durationTotalDays = (decimal)duration.TotalDays;
            }

            decimal remainingLeaveCount = EmployeeRemainingLeaveCountBaseOnSelectedLeave - durationTotalDays;


            this.NewEmployeeLeave = new EmployeeLeaveModel {
                LeaveId = SelectedLeaveType.Id,
                EmployeeNumber = this.TboxEmployeeToSearch.Text,
                Reason = this.TboxLeaveReason.Text,
                StartDate = this.DPickerDurationStartDate.Value,
                EndDate = this.DPickerDurationEndDate.Value,
                //NumberOfDays = durationTotalDays,
                RemainingDays = remainingLeaveCount,
                CurrentYear = DateTime.Now.Year
            };

            OnEmployeeLeaveSaved(EventArgs.Empty);
        }

        public void ResetForm()
        {
            this.TboxEmployeeToSearch.Text = "";
            this.LblSelectedEmployeeFullname.Text = "-";
            this.LblEmployeePosition.Text = "-";
            this.CBoxLeaveTypes.SelectedIndex = -1;
            this.LblLeaveDayCounts.Text = "0";
            this.LblRemainingLeave.Text = "0";
            this.TboxLeaveReason.Text = "";
            this.DPickerDurationStartDate.Value = DateTime.Now;
            this.DPickerDurationEndDate.Value = DateTime.Now;
            this.LblEmployeeLeaveNumberOfDays.Text = "";
        }

        private void DPickerDurationEndDate_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan duration = this.DPickerDurationEndDate.Value - this.DPickerDurationStartDate.Value;
            this.LblEmployeeLeaveNumberOfDays.Text = duration.TotalDays.ToString("0.##");
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
    }
}
