using EntitiesShared.EmployeeManagement;
using EntitiesShared.EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class ManageEmpWorkScheduleControl : UserControl
    {

        private List<EmployeeModel> employees;

        public List<EmployeeModel> Employees
        {
            get { return employees; }
            set { employees = value; }
        }


        private List<EmployeeShiftModel> workShifts;

        public List<EmployeeShiftModel> WorkShifts
        {
            get { return workShifts; }
            set { workShifts = value; }
        }


        private List<EmployeeShiftDayModel> workShiftDays;

        public List<EmployeeShiftDayModel> WorkShiftDays
        {
            get { return workShiftDays; }
            set { workShiftDays = value; }
        }


        // Event handler for saving
        public event EventHandler EmployeeShiftUpdated;
        protected virtual void OnEmployeeShiftUpdated(EventArgs e)
        {
            EmployeeShiftUpdated?.Invoke(this, e);
        }
        public UpdateEmployeeShiftModel UpdateEmployeeShift { get; set; } = new UpdateEmployeeShiftModel();


        public ManageEmpWorkScheduleControl()
        {
            InitializeComponent();
        }


        public void ResetUpdateEmployeeShiftVal()
        {
            UpdateEmployeeShift = new UpdateEmployeeShiftModel();
        }


        private void ManageEmpWorkScheduleControl_Load(object sender, EventArgs e)
        {
            SetDGVEmployeeListFontAndColors();
            SetDGVShiftListFontAndColors();

            DisplayWorkShifts();
            DisplayEmployees();

            DisplayWorkScheduleInListView();
        }

        private void SetDGVEmployeeListFontAndColors()
        {
            // DataGridView in 1st tab
            this.DGVEmployeeList.BackgroundColor = Color.White;
            this.DGVEmployeeList.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeList.RowHeadersVisible = false;
            this.DGVEmployeeList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeList.AllowUserToResizeRows = false;
            this.DGVEmployeeList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEmployeeList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            //this.DGVEmployeeList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeList.MultiSelect = false;
            this.DGVEmployeeList.ReadOnly = false;
            this.DGVEmployeeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeList.ColumnHeadersHeight = 30;


            // DataGridView in 2nd tab
            this.DGVEmployeeListToSchedule.BackgroundColor = Color.White;
            this.DGVEmployeeListToSchedule.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVEmployeeListToSchedule.RowHeadersVisible = false;
            this.DGVEmployeeListToSchedule.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVEmployeeListToSchedule.AllowUserToResizeRows = false;
            this.DGVEmployeeListToSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVEmployeeListToSchedule.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            //this.DGVEmployeeListToSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployeeListToSchedule.MultiSelect = false;
            this.DGVEmployeeListToSchedule.ReadOnly = false;
            this.DGVEmployeeListToSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployeeListToSchedule.ColumnHeadersHeight = 30;


            // 2nd DataGridView in 2nd tab
            this.DGVScheduledWorkforceByDate.BackgroundColor = Color.White;
            this.DGVScheduledWorkforceByDate.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            this.DGVScheduledWorkforceByDate.RowHeadersVisible = false;
            this.DGVScheduledWorkforceByDate.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVScheduledWorkforceByDate.AllowUserToResizeRows = false;
            this.DGVScheduledWorkforceByDate.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVScheduledWorkforceByDate.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            //this.DGVScheduledWorkforceByDate.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVScheduledWorkforceByDate.MultiSelect = false;
            this.DGVScheduledWorkforceByDate.ReadOnly = false;
            this.DGVScheduledWorkforceByDate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVScheduledWorkforceByDate.ColumnHeadersHeight = 30;
        }

        private void SetDGVShiftListFontAndColors()
        {
            this.DGVShiftList.BackgroundColor = Color.White;
            this.DGVShiftList.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVShiftList.RowHeadersVisible = false;
            this.DGVShiftList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVShiftList.AllowUserToResizeRows = false;
            this.DGVShiftList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVShiftList.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVShiftList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVShiftList.MultiSelect = false;

            this.DGVShiftList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVShiftList.ColumnHeadersHeight = 30;
        }


        // Event handler for saving
        public event EventHandler ShiftSelected;
        protected virtual void OnShiftSelected(EventArgs e)
        {
            ShiftSelected?.Invoke(this, e);
        }

        private long selectedShiftId;

        public long SelectedShiftId
        {
            get { return selectedShiftId; }
            set { selectedShiftId = value; }
        }


        public void DisplayEmployeesInTab1(List<EmployeeModel> employees)
        {
            this.DGVEmployeeList.Rows.Clear();
            if (employees != null)
            {
                // ----------------------------- 1st tab datagridview
                this.DGVEmployeeList.ColumnCount = 3;

                this.DGVEmployeeList.Columns[0].Name = "EmployeeNumber";
                this.DGVEmployeeList.Columns[0].Visible = true;

                this.DGVEmployeeList.Columns[1].Name = "Fullname";
                this.DGVEmployeeList.Columns[1].Visible = true;

                this.DGVEmployeeList.Columns[2].Name = "Position";
                this.DGVEmployeeList.Columns[2].Visible = true;

                //this.DGVEmployeeList.Columns[3].Name = "Shift";
                //this.DGVEmployeeList.Columns[3].Visible = true;

                DataGridViewCheckBoxColumn selectChbx = new DataGridViewCheckBoxColumn();
                selectChbx.HeaderText = "Select";
                selectChbx.Name = "selectEmpCkbox";
                selectChbx.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DGVEmployeeList.Columns.Add(selectChbx);

                foreach (var employee in employees)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVEmployeeList);

                    string fullName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}";

                    row.Cells[0].Value = employee.EmployeeNumber;
                    row.Cells[1].Value = fullName;

                    if (employee.PositionShift.Count() > 0)
                    {
                        List<string> position = new List<string>();
                        foreach (var item in employee.PositionShift.ToList())
                        {
                            position.Add($"{item.Position} - ({item.Shift})");
                        }
                        string positions = string.Join(", ", position.Select(x => x).ToList().ToArray());
                        row.Cells[2].Value = positions;
                    }
                    //row.Cells[2].Value = employee.Position;

                    //if (employee.Shift != null)
                    //{
                    //    row.Cells[3].Value = employee.Shift.Shift;
                    //}

                    this.DGVEmployeeList.Rows.Add(row);
                }
            }
        }

        public void DisplayEmployeesInTab2(List<EmployeeModel> employees)
        {
            this.DGVEmployeeListToSchedule.Rows.Clear();
            if (employees != null)
            {
                this.DGVEmployeeListToSchedule.ColumnCount = 3;

                this.DGVEmployeeListToSchedule.Columns[0].Name = "EmployeeNumber2";
                this.DGVEmployeeListToSchedule.Columns[0].HeaderText = "Employee Number";
                this.DGVEmployeeListToSchedule.Columns[0].Visible = true;

                this.DGVEmployeeListToSchedule.Columns[1].Name = "Fullname2";
                this.DGVEmployeeListToSchedule.Columns[1].HeaderText = "Fullname";
                this.DGVEmployeeListToSchedule.Columns[1].Visible = true;

                this.DGVEmployeeListToSchedule.Columns[2].Name = "Position2";
                this.DGVEmployeeListToSchedule.Columns[2].HeaderText = "Position and Shift";
                this.DGVEmployeeListToSchedule.Columns[2].Visible = true;

                //this.DGVEmployeeListToSchedule.Columns[3].Name = "Shift2";
                //this.DGVEmployeeListToSchedule.Columns[3].HeaderText = "Shift";
                //this.DGVEmployeeListToSchedule.Columns[3].Visible = true;

                DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
                selectChbxToSchedule.HeaderText = "Select";
                selectChbxToSchedule.Name = "selectEmpCkbox2";
                selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DGVEmployeeListToSchedule.Columns.Add(selectChbxToSchedule);

                foreach (var employee in employees)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVEmployeeListToSchedule);

                    string fullName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}";

                    row.Cells[0].Value = employee.EmployeeNumber;
                    row.Cells[1].Value = fullName;

                    if (employee.PositionShift.Count() > 0)
                    {
                        List<string> position = new List<string>();
                        foreach (var item in employee.PositionShift.ToList())
                        {
                            position.Add($"{item.Position} - ({item.Shift})");
                        }
                        string positions = string.Join(", ", position.Select(x => x).ToList().ToArray());
                        row.Cells[2].Value = positions;
                    }
                    //row.Cells[2].Value = employee.Position.Title;

                    //if (employee.Shift != null)
                    //{
                    //    row.Cells[3].Value = employee.Shift.Shift;
                    //}

                    this.DGVEmployeeListToSchedule.Rows.Add(row);
                }

            }
        }

        public void DisplayEmployees()
        {
            DisplayEmployeesInTab1(this.Employees);
            DisplayEmployeesInTab2(this.Employees);
        }

        public void DisplayWorkShifts()
        {
            this.DGVShiftList.Rows.Clear();
            if (this.WorkShifts != null)
            {
                this.DGVShiftList.ColumnCount = 3;

                this.DGVShiftList.Columns[0].Name = "ShiftId";
                this.DGVShiftList.Columns[0].Visible = false;

                this.DGVShiftList.Columns[1].Name = "Shift";
                this.DGVShiftList.Columns[1].Visible = true;

                this.DGVShiftList.Columns[2].Name = "Time";
                this.DGVShiftList.Columns[2].Visible = true;

                foreach(var shift in this.WorkShifts)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVShiftList);

                    string timeStartAndEnd = $"{shift.StartTime.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture)} to {shift.EndTime.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture)}";

                    row.Cells[0].Value = shift.Id;
                    row.Cells[1].Value = shift.Shift;
                    row.Cells[2].Value = timeStartAndEnd;

                    this.DGVShiftList.Rows.Add(row);
                }
            }
        }


        public void ResetShiftDaysCheckBoxes()
        {
            foreach (var daysCheckBoxControl in this.GroupPanelShiftDays.Controls)
            {
                if (daysCheckBoxControl is CheckBox)
                {
                    ((CheckBox)daysCheckBoxControl).Checked = false;
                }
            }
        }

        public void DisplayWorkShiftDays()
        {
            ResetShiftDaysCheckBoxes();
            if (this.WorkShiftDays != null)
            {
                foreach (var shiftDay in this.WorkShiftDays)
                {
                    string dayNameTag = $"{shiftDay.DayName}-{shiftDay.OrderNum}";

                    foreach (var daysCheckBoxControl in this.GroupPanelShiftDays.Controls)
                    {
                        if (daysCheckBoxControl is CheckBox)
                        {
                            if (((CheckBox)daysCheckBoxControl).Tag.ToString() == dayNameTag)
                            {
                                ((CheckBox)daysCheckBoxControl).Checked = true;
                            }
                        }
                    }
                }
            }
        }

        private void DGVShiftList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string shiftId = this.DGVShiftList.CurrentRow.Cells[0].Value.ToString();
                this.SelectedShiftId = long.Parse(shiftId);
                this.OnShiftSelected(EventArgs.Empty);
            }
        }

        private void BtnSaveEmployeeShiftSchedule_Click(object sender, EventArgs e)
        {
            if (this.DGVShiftList.CurrentRow.Index > -1)
            {
                string shiftId = this.DGVShiftList.CurrentRow.Cells[0].Value.ToString();
                UpdateEmployeeShift.ShiftId = long.Parse(shiftId);

                foreach (DataGridViewRow row in this.DGVEmployeeList.Rows)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["selectEmpCkbox"].Value);
                    if (isSelected)
                    {
                        UpdateEmployeeShift.EmployeeNumbers.Add(row.Cells["EmployeeNumber"].Value.ToString());
                    }
                }

                if (UpdateEmployeeShift.ShiftId > 0 && UpdateEmployeeShift.EmployeeNumbers.Count > 0)
                {
                    OnEmployeeShiftUpdated(EventArgs.Empty);
                }
            }
            
        }

        private WorkforceScheduling workforceSchedule = new WorkforceScheduling();

        public WorkforceScheduling WorkforceSchedule
        {
            get { return workforceSchedule; }
            set { workforceSchedule = value; }
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }


        public List<EmployeeModel> GetSelectedEmployeeToSchedule()
        {
            List<EmployeeModel> selectedEmployees = new List<EmployeeModel>();

            foreach (DataGridViewRow row in this.DGVEmployeeListToSchedule.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectEmpCkbox2"].Value);
                if (isSelected)
                {
                    string empNum = row.Cells["EmployeeNumber2"].Value.ToString();
                    var empInList = this.Employees.Where(x => x.EmployeeNumber == empNum).FirstOrDefault();

                    if (empInList != null)
                    {
                        var empTmp = JsonSerializer.Deserialize<EmployeeModel>(JsonSerializer.Serialize(empInList));
                        selectedEmployees.Add(empTmp);
                    }
                }
            }

            return selectedEmployees;
        }


        public void ClearSelectedEmployees()
        {
            foreach (DataGridViewRow row in this.DGVEmployeeListToSchedule.Rows)
            {
                row.Cells["selectEmpCkbox2"].Value = (bool)false;
            }

        }

        private void BtnGenerateWorkforceSchedule_Click(object sender, EventArgs e)
        {
            var workSchedStartFrom = this.DPicWorkScheduleStartFrom.Value;
            var workSchedEndTo = this.DPicWorkScheduleEndTo.Value;

            if (workSchedEndTo < workSchedStartFrom)
            {
                MessageBox.Show("Invalid start and end date", "Generate workforce schedule", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (WorkforceSchedule != null && WorkforceSchedule.WorkforceSchedules != null && WorkforceSchedule.WorkforceSchedules.Count > 0)
            {
                var lastWorkForceDate = WorkforceSchedule.WorkforceSchedules.LastOrDefault().WorkDate;

                if (workSchedStartFrom.Date <= lastWorkForceDate.Date)
                {
                    MessageBox.Show($"Invalid start date: already have workforce schedule from {workSchedStartFrom.ToShortDateString()} and {lastWorkForceDate.ToShortDateString()}", "Generate workforce schedule", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                WorkforceSchedule.WorkForceByDate = new Dictionary<DateTime, List<EmployeeModel>>();
            }


            WorkforceSchedule.StartDate = workSchedStartFrom;
            WorkforceSchedule.EndDate = workSchedEndTo;

            var selectedEmployees = GetSelectedEmployeeToSchedule();

            if (selectedEmployees != null && selectedEmployees.Count == 0)
            {
                MessageBox.Show("Kindly select employee", "Generate workforce schedule", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // we will not pass the date key here
            // because, if the employeer or admin user who is generating the workforce schedule
            // remove the employee on the schedule, it will remove that employee on each day
            DisplayWorkForce(selectedEmployees);

            foreach (DateTime day in EachDay(workSchedStartFrom, workSchedEndTo))
            {
                var selectedEmployeesTmp = JsonSerializer.Deserialize<List<EmployeeModel>>(JsonSerializer.Serialize(selectedEmployees));

                if (WorkforceSchedule.WorkForceByDate.ContainsKey(day))
                {
                    var addedEmployees = WorkforceSchedule.WorkForceByDate[day];

                    if (addedEmployees != null)
                    {
                        foreach(var selectedEmp in selectedEmployeesTmp)
                        {
                            var empTmp = addedEmployees.Where(x => x.EmployeeNumber == selectedEmp.EmployeeNumber).FirstOrDefault();

                            if (empTmp == null)
                            {
                                addedEmployees.Add(selectedEmp);
                            }
                        }

                        WorkforceSchedule.WorkForceByDate[day] = addedEmployees;
                    }
                }
                else
                {
                    WorkforceSchedule.WorkForceByDate.Add(day, selectedEmployeesTmp);
                }
            }

            DisplayWorkScheduleInListView();

            ClearSelectedEmployees();
        }

        public void DisplayWorkScheduleInListView()
        {
            this.LViewScheduleDates.Items.Clear();
            foreach (var workSched in WorkforceSchedule.WorkForceByDate)
            {
                var row = new string[] { workSched.Key.ToShortDateString(), workSched.Value.Count.ToString() };

                var listViewItem = new ListViewItem(row);
                //listViewItem.BackColor = Color.Brown;
                listViewItem.Tag = workSched.Key.ToShortDateString();

                this.LViewScheduleDates.Items.Add(listViewItem);
            }
        }

        public void DisplayWorkForce(List<EmployeeModel> workforce, string dateKey = "")
        {
            this.DGVScheduledWorkforceByDate.Rows.Clear();
            if (workforce != null)
            {
                this.DGVScheduledWorkforceByDate.ColumnCount = 3;

                this.DGVScheduledWorkforceByDate.Columns[0].Name = "EmployeeNumber2";
                this.DGVScheduledWorkforceByDate.Columns[0].HeaderText = "Employee Number";
                this.DGVScheduledWorkforceByDate.Columns[0].Visible = true;

                this.DGVScheduledWorkforceByDate.Columns[1].Name = "Fullname2";
                this.DGVScheduledWorkforceByDate.Columns[1].HeaderText = "Fullname";
                this.DGVScheduledWorkforceByDate.Columns[1].Visible = true;

                this.DGVScheduledWorkforceByDate.Columns[2].Name = "Position2";
                this.DGVScheduledWorkforceByDate.Columns[2].HeaderText = "Position and Shift";
                this.DGVScheduledWorkforceByDate.Columns[2].Visible = true;

                //this.DGVScheduledWorkforceByDate.Columns[3].Name = "Shift2";
                //this.DGVScheduledWorkforceByDate.Columns[3].HeaderText = "Shift";
                //this.DGVScheduledWorkforceByDate.Columns[3].Visible = true;


                // Delete button
                DataGridViewImageColumn btnDeleteLeaveTypeImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteLeaveTypeImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteLeaveTypeImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVScheduledWorkforceByDate.Columns.Add(btnDeleteLeaveTypeImg);

                foreach (var employee in workforce)
                {
                    if (employee != null)
                    {
                        if (employee.IsDeleted == false)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(this.DGVScheduledWorkforceByDate);

                            string fullName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}";

                            row.Cells[0].Value = employee.EmployeeNumber;
                            row.Cells[1].Value = fullName;
                            if (employee.PositionShift.Count() > 0)
                            {
                                List<string> position = new List<string>();
                                foreach (var item in employee.PositionShift.ToList())
                                {
                                    position.Add($"{item.Position} - ({item.Shift})");
                                }
                                string positions = string.Join(", ", position.Select(x => x).ToList().ToArray());
                                row.Cells[2].Value = positions;
                            }
                            //row.Cells[2].Value = employee.Position.Title;

                            //if (employee.Shift != null)
                            //{
                            //    row.Cells[3].Value = employee.Shift.Shift;
                            //}

                            row.Tag = dateKey;

                            this.DGVScheduledWorkforceByDate.Rows.Add(row);
                        }
                    }
                }

            }
        }

        private void LViewScheduleDates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LViewScheduleDates.SelectedItems.Count > 0)
            {
                this.BtnDeleteSchedule.Visible = true; // dispaly delete button

                string selectedItem = LViewScheduleDates.SelectedItems[0].Tag as string;
                DateTime selectedDay = DateTime.Parse(selectedItem);

                var workForce = WorkforceSchedule.WorkForceByDate[selectedDay];

                if (workForce != null)
                {
                    // need to pass the date key, so if the admin user
                    // remove the employee, we will just remove that employee on a particular date
                    DisplayWorkForce(workForce, selectedItem);
                }
            }
            else
            {
                this.BtnDeleteSchedule.Visible = false;
            }
        }

        private void DGVScheduledWorkforceByDate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Remove button in DataGridView Workforce
            // when click
            if (e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                if (DGVScheduledWorkforceByDate.CurrentRow != null)
                {
                    string employeeNumber = DGVScheduledWorkforceByDate.CurrentRow.Cells[0].Value.ToString();
                    string selectedRowTag = DGVScheduledWorkforceByDate.CurrentRow.Tag as string;

                    if (selectedRowTag != "")
                    {
                        DateTime selectedDateKey = DateTime.Parse(selectedRowTag);

                        var workForceSched = WorkforceSchedule.WorkForceByDate[selectedDateKey];

                        if (workForceSched != null)
                        {
                            var empTmp = workForceSched.Where(x => x.EmployeeNumber == employeeNumber).FirstOrDefault();
                            if (empTmp != null)
                            {
                                empTmp.IsDeleted = true;
                                empTmp.DeletedAt = DateTime.Now;
                                //workForceSched.Remove(empTmp);

                                if (WorkforceSchedule.WorkforceSchedules != null)
                                {
                                    // if there is existing workforce schedule in our database
                                    // check if the employee we remove on the datagridview
                                    // is also existing in our database, if yes, then delete the record
                                    var workForceInDatabase = WorkforceSchedule.WorkforceSchedules
                                                                    .Where(x =>
                                                                        x.WorkDate == selectedDateKey &&
                                                                        x.EmployeeNumber == empTmp.EmployeeNumber
                                                                    ).FirstOrDefault();

                                    if (workForceInDatabase != null)
                                    {
                                        // mark as deleted
                                        workForceInDatabase.IsDeleted = true;
                                        workForceInDatabase.DeletedAt = DateTime.Now;
                                    }
                                }
                            }
                        }

                        // need to pass the date key, so if the admin user
                        // remove the employee, we will just remove that employee on a particular date
                        DisplayWorkForce(workForceSched, selectedDateKey.ToShortDateString());
                    }
                    else
                    {
                        // remove on each workday's workforce list
                        foreach(var workForceSched in WorkforceSchedule.WorkForceByDate)
                        {
                            var empTmp = workForceSched.Value.Where(x => x.EmployeeNumber == employeeNumber).FirstOrDefault();
                            if (empTmp != null)
                            {
                                empTmp.IsDeleted = true;
                                empTmp.DeletedAt = DateTime.Now;
                                //workForceSched.Value.Remove(empTmp);

                                if (WorkforceSchedule.WorkforceSchedules != null)
                                {
                                    // if there is existing workforce schedule in our database
                                    // check if the employee we remove on the datagridview
                                    // is also existing in our database, if yes, then delete the record
                                    var workForceInDatabase = WorkforceSchedule.WorkforceSchedules
                                                                    .Where(x =>
                                                                        x.WorkDate == workForceSched.Key &&
                                                                        x.EmployeeNumber == empTmp.EmployeeNumber
                                                                    ).FirstOrDefault();

                                    if (workForceInDatabase != null)
                                    {
                                        // mark as deleted
                                        workForceInDatabase.IsDeleted = true;
                                        workForceInDatabase.DeletedAt = DateTime.Now;
                                    }

                                }
                            }

                        }

                        DisplayWorkForce(WorkforceSchedule.WorkForceByDate.FirstOrDefault().Value);
                    }

                    DisplayWorkScheduleInListView();
                }
            }
        }

        private void BtnUpdateSelectedDateWorkForce_Click(object sender, EventArgs e)
        {
            if (LViewScheduleDates.SelectedItems.Count > 0)
            {
                // selected employees in datagrid tab 2, top datagridview
                var selectedEmployees = GetSelectedEmployeeToSchedule();

                if (selectedEmployees != null && selectedEmployees.Count == 0)
                {
                    MessageBox.Show("Kindly select employee", "Generate workforce schedule", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                string selectedItem = LViewScheduleDates.SelectedItems[0].Tag as string;
                DateTime selectedDay = DateTime.Parse(selectedItem);

                // existing workforce (Employee list in Global variable)
                var selectedDayWorkforce = WorkforceSchedule.WorkForceByDate[selectedDay];

                var newDayWorkforce = new List<EmployeeModel>();

                if (selectedDayWorkforce == null && selectedEmployees.Count > 0)
                {
                    newDayWorkforce = JsonSerializer.Deserialize<List<EmployeeModel>>(JsonSerializer.Serialize(selectedEmployees));
                }
                else if (selectedDayWorkforce != null &&  selectedEmployees.Count > 0)
                {
                    foreach(var emp in selectedEmployees)
                    {
                        var empInSelectedDay = selectedDayWorkforce.Where(x => x.EmployeeNumber == emp.EmployeeNumber).FirstOrDefault();
                        // add if not yet added
                        if (empInSelectedDay == null)
                        {
                            selectedDayWorkforce.Add(emp);
                        }
                    }
                    // create new workforce list in memory
                    newDayWorkforce = JsonSerializer.Deserialize<List<EmployeeModel>>(JsonSerializer.Serialize(selectedDayWorkforce));
                }

                WorkforceSchedule.WorkForceByDate[selectedDay] = newDayWorkforce;

                // need to pass the date key, so if the admin user
                // remove the employee, we will just remove that employee on a particular date
                DisplayWorkForce(newDayWorkforce, selectedItem);
                DisplayWorkScheduleInListView();

                ClearSelectedEmployees();
            }

        }

        private void BtnSelectAllEmployees_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVEmployeeListToSchedule.Rows)
            {
                row.Cells["selectEmpCkbox2"].Value = (bool)true;
            }
        }

        public event EventHandler SaveWorkforceSchedule;
        protected virtual void OnSaveWorkforceSchedule(EventArgs e)
        {
            SaveWorkforceSchedule?.Invoke(this, e);
        }

        private void BtnSaveWorkforceSchedule_Click(object sender, EventArgs e)
        {
            OnSaveWorkforceSchedule(EventArgs.Empty);
        }

        public void Reset()
        {
            this.ClearSelectedEmployees();
            this.DGVScheduledWorkforceByDate.Rows.Clear();
            DisplayWorkScheduleInListView();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void BtnDeleteSchedule_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure, you want to delete this?", "Delete confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (res == DialogResult.OK)
            {
                if (LViewScheduleDates.SelectedItems.Count > 0)
                {
                    this.BtnDeleteSchedule.Visible = true; // dispaly delete button

                    LViewScheduleDates.SelectedItems[0].ForeColor = Color.Red;

                    string selectedItem = LViewScheduleDates.SelectedItems[0].Tag as string;
                    DateTime selectedDay = DateTime.Parse(selectedItem);

                    LViewScheduleDates.SelectedItems[0].Text = $"{selectedDay.ToShortDateString()} - to delete";

                    var workForce = WorkforceSchedule.WorkForceByDate[selectedDay];

                    if (workForce != null)
                    {
                        foreach (var employee in workForce)
                        {
                            employee.IsDeleted = true;
                            employee.DeletedAt = DateTime.Now;

                            if (WorkforceSchedule.WorkforceSchedules != null)
                            {
                                // if there is existing workforce schedule in our database
                                // check if the employee we remove on the datagridview
                                // is also existing in our database, if yes, then delete the record
                                var workForceInDatabase = WorkforceSchedule.WorkforceSchedules
                                                                .Where(x =>
                                                                    x.WorkDate == selectedDay &&
                                                                    x.EmployeeNumber == employee.EmployeeNumber
                                                                ).FirstOrDefault();

                                if (workForceInDatabase != null)
                                {
                                    // mark as deleted
                                    workForceInDatabase.IsDeleted = true;
                                    workForceInDatabase.DeletedAt = DateTime.Now;
                                }
                            }
                        }

                        // need to pass the date key, so if the admin user
                        // remove the employee, we will just remove that employee on a particular date
                        DisplayWorkForce(workForce, selectedItem);
                    }
                }
            }

            
        }

        public event EventHandler UndoWorkForceChangesInFormOnly;
        protected virtual void OnUndoWorkForceChangesInFormOnly(EventArgs e)
        {
            UndoWorkForceChangesInFormOnly?.Invoke(this, e);
        }
        private void BtnUndoChanges_Click(object sender, EventArgs e)
        {
            OnUndoWorkForceChangesInFormOnly(EventArgs.Empty);
        }

        private void BtnSelectAllEmloyeesInShiftSchedTab_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVEmployeeList.Rows)
            {
                row.Cells["selectEmpCkbox"].Value = (bool)true;
            }
        }

        private void TbxSearchEmployeesInTab1_KeyUp(object sender, KeyEventArgs e)
        {
            var searchStr = TbxSearchEmployeesInTab1.Text;

            if (e.KeyCode == Keys.Enter && this.Employees != null && string.IsNullOrWhiteSpace(searchStr) == false)
            {

                var searchResultEmployes = this.Employees.Where(
                                                x => 
                                                    x.EmployeeNumber.Contains(searchStr) ||
                                                    x.FullName.Contains(searchStr)
                                                ).ToList();

                DisplayEmployeesInTab1(searchResultEmployes);

                e.Handled = true;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            DisplayEmployeesInTab1(this.Employees);
            DisplayEmployeesInTab2(this.Employees);
        }

        private void BtnRefreshEmployees2_Click(object sender, EventArgs e)
        {
            DisplayEmployeesInTab1(this.Employees);
            DisplayEmployeesInTab2(this.Employees);
        }

        private void TbxSearchEmployeesInTab2_KeyUp(object sender, KeyEventArgs e)
        {
            var searchStr = TbxSearchEmployeesInTab2.Text;

            if (e.KeyCode == Keys.Enter && this.Employees != null && string.IsNullOrWhiteSpace(searchStr) == false)
            {

                var searchResultEmployes = this.Employees.Where(
                                                x =>
                                                    x.EmployeeNumber.Contains(searchStr) ||
                                                    x.FullName.Contains(searchStr)
                                                ).ToList();

                DisplayEmployeesInTab2(searchResultEmployes);

                e.Handled = true;
            }
        }

        private void BtnUpdateSelectedDateWorkForce_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(BtnUpdateSelectedDateWorkForce, "Updated existing workforce");
        }

        private void BtnDeleteSchedule_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(BtnDeleteSchedule, "Delete workforce");
        }

        private void BtnUndoChanges_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(BtnUndoChanges, "Undo any changes");
        }

        private void BtnDeleteAll_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(BtnDeleteAll, "Delete all workforce schedule based on selected date range");
        }


        public DateTime SelectedDateRangeToDeleteStart { get; set; }
        public DateTime SelectedDateRangeToDeleteEnd { get; set; }

        public event EventHandler DeleteAllWorkForceSchedule;
        protected virtual void OnDeleteAllWorkForceSchedule(EventArgs e)
        {
            DeleteAllWorkForceSchedule?.Invoke(this, e);
        }

        private void BtnDeleteAll_Click(object sender, EventArgs e)
        {
            SelectedDateRangeToDeleteStart = DPicWorkScheduleStartFrom.Value;
            SelectedDateRangeToDeleteEnd = DPicWorkScheduleEndTo.Value;

            OnDeleteAllWorkForceSchedule(EventArgs.Empty);
        }
    }
}
