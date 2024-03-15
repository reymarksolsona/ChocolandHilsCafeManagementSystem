using EntitiesShared;
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

namespace Main.Forms.RequestsForm.Controls
{
    public partial class RequestLeaveControl : UserControl
    {
        private readonly Sessions _sessions;
        public event PropertyChangedEventHandler PropertyChanged;

        public RequestLeaveControl(Sessions sessions)
        {
            InitializeComponent();
            _sessions = sessions;
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

        private EmployeeLeaveModel newEmployeeLeave;
        public EmployeeLeaveModel NewEmployeeLeave
        {
            get { return newEmployeeLeave; }
            set { newEmployeeLeave = value; }
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

        private List<EmployeeLeaveModel> employeeLeaveHistory;
        public List<EmployeeLeaveModel> EmployeeLeaveHistory
        {
            get { return employeeLeaveHistory; }
            set { employeeLeaveHistory = value; }
        }

        public decimal EmployeeRemainingLeaveCountBaseOnSelectedLeave { get; set; }
        public void DisplayEmpRemainingLeaveCount(decimal leaveCount)
        {
            EmployeeRemainingLeaveCountBaseOnSelectedLeave = leaveCount;
            this.LblRemainingLeave.Text = leaveCount.ToString();
        }
        public long EmployeeLeaveIdToDelete { get; set; }

        public event EventHandler DeleteEmployeeLeave;
        protected virtual void OnDeleteEmployeeLeave(EventArgs e)
        {
            DeleteEmployeeLeave?.Invoke(this, e);
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

        public void ResetEmployeeFileLeaveForm()
        {
            this.CBoxLeaveTypes.SelectedIndex = -1;
            this.LblRemainingLeave.Text = "0";
            this.TboxLeaveReason.Text = "";
            this.CboxDuration.SelectedIndex = -1;
            this.DPickerDurationStartDate.Value = DateTime.Now;
            this.DPickerDurationEndDate.Value = DateTime.Now;
        }

        public void DisplayLeaveTypes()
        {
            if (this.LeaveTypes != null)
            {
                ComboboxItem item;
                foreach (var leaveType in this.LeaveTypes)
                {
                    item = new ComboboxItem();
                    item.Text = $"{leaveType.LeaveType} ({leaveType.NumberOfDays} days)";
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

        private void BtnSaveEmployeeLeave_Click(object sender, EventArgs e)
        {
            if (SelectedLeaveType == null)
            {
                MessageBox.Show("Select leave type", "Save employee leave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var selectedDurationItem = this.CboxDuration.SelectedItem as ComboboxItem;
            if (selectedDurationItem == null)
            {
                MessageBox.Show("Select duration", "Save employee leave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
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

        public event EventHandler EmployeeLeaveSaved;
        protected virtual void OnEmployeeLeaveSaved(EventArgs e)
        {
            EmployeeLeaveSaved?.Invoke(this, e);
        }

        public void DisplayList()
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

        private void RequestLeaveControl_Load(object sender, EventArgs e)
        {
            this.EmployeeNumber = _sessions.CurrentLoggedInUser.UserName;
            DisplayList();
            DisplayLeaveTypes();
            DisplayEmployeeLeavesInDGV();
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

        public event EventHandler EmployeeRemainingLeaveFetch;
        protected virtual void OnEmployeeRemainingLeaveFetch(EventArgs e)
        {
            EmployeeRemainingLeaveFetch?.Invoke(this, e);
        }

        private void DGVEmployeeLeaveHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
