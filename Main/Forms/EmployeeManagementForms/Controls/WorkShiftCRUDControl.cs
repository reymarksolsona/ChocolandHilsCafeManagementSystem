using EntitiesShared.EmployeeManagement;
using Shared.CustomModels;
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

namespace Main.Forms.EmployeeManagementForms.Controls
{
    public partial class WorkShiftCRUDControl : UserControl
    {
        public WorkShiftCRUDControl()
        {
            InitializeComponent();
            RenderBreakTimeInComboBox();
        }


        private void WorkShiftCRUDControl_Load(object sender, EventArgs e)
        {
            SetDGVWorkShiftsFontAndColors();
            DisplayWorkShiftList();

            //var culture = CultureInfo.CurrentCulture;
            //var abbr = culture.DateTimeFormat.GetAbbreviatedDayName(DateTime.Now.DayOfWeek);

        }

        List<ComboboxItem> BreakTimeHrsItems = new List<ComboboxItem> {
            new ComboboxItem { Text = "30mins", Value = (decimal)0.5 },
            new ComboboxItem { Text = "1hr", Value = (decimal)1 }
        };

        public void RenderBreakTimeInComboBox()
        {
            foreach (var breakTime in BreakTimeHrsItems)
            {
                this.CBoxBreakTimes.Items.Add(breakTime);
            }
        }

        private List<EmployeeShiftModel> employeeShifts;

        public List<EmployeeShiftModel> EmployeeShifts
        {
            get { return employeeShifts; }
            set { employeeShifts = value; }
        }


        private EmployeeShiftModel employeeShiftToAddUpdate;

        public EmployeeShiftModel EmployeeShiftToAddUpdate
        {
            get { return employeeShiftToAddUpdate; }
            set { employeeShiftToAddUpdate = value; }
        }


        private List<EmployeeShiftDayModel> employeeShiftDaysToAddUpdate = new List<EmployeeShiftDayModel>();

        public List<EmployeeShiftDayModel> EmployeeShiftDaysToAddUpdate
        {
            get { return employeeShiftDaysToAddUpdate; }
            set { employeeShiftDaysToAddUpdate = value; }
        }



        public bool IsSaveNew { get; set; } = true;


        // Event handler for saving
        public event EventHandler EmployeeShiftSaved;
        protected virtual void OnEmployeeShiftSaved(EventArgs e)
        {
            EmployeeShiftSaved?.Invoke(this, e);
        }

        public event PropertyChangedEventHandler PropSelectedEmpShiftIdToUpdateChanged;

        private string selectedEmpShiftIdToUpdate;
        // Used on clicking update button in datagridview
        public string SelectedEmpShiftIdToUpdate
        {
            get { return selectedEmpShiftIdToUpdate; }
            set {
                selectedEmpShiftIdToUpdate = value;
                
                if (PropSelectedEmpShiftIdToUpdateChanged != null)
                {
                    PropSelectedEmpShiftIdToUpdateChanged(this, new PropertyChangedEventArgs(SelectedEmpShiftIdToUpdate));
                }
            }
        }

        public event PropertyChangedEventHandler PropSelectedEmpShiftIdToDeleteChanged;

        private string selectedEmpShiftIdToDelete;
        // Used on clicking delete button in datagridview
        public string SelectedEmpShiftIdToDelete
        {
            get { return selectedEmpShiftIdToDelete; }
            set
            {
                selectedEmpShiftIdToDelete = value;

                if (PropSelectedEmpShiftIdToDeleteChanged != null)
                {
                    PropSelectedEmpShiftIdToDeleteChanged(this, new PropertyChangedEventArgs(SelectedEmpShiftIdToDelete));
                }
            }
        }

        private void SetDGVWorkShiftsFontAndColors()
        {
            this.DGVWorkShifts.BackgroundColor = Color.White;
            this.DGVWorkShifts.DefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVWorkShifts.RowHeadersVisible = false;
            this.DGVWorkShifts.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            this.DGVWorkShifts.AllowUserToResizeRows = false;
            this.DGVWorkShifts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.DGVWorkShifts.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);

            this.DGVWorkShifts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVWorkShifts.MultiSelect = false;

            this.DGVWorkShifts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVWorkShifts.ColumnHeadersHeight = 30;
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

        public void ResetForm()
        {
            this.IsSaveNew = true;
            this.TboxShiftTitle.Text = "";
            this.DTPickerShiftStartTime.Value = DateTime.Now;
            this.TboxShiftNumberOfHrs.Text = "";
            this.DTPickerShiftBreaktime.Value = DateTime.Now;
            this.DTPickerEarlyTimeOut.Value = DateTime.Now;
            this.DTPickerLateTimeIn.Value = DateTime.Now;
            this.CBoxBreakTimes.SelectedIndex = -1;
            this.CboxDisable.Checked = false;
            ResetShiftDaysCheckBoxes();
        }

        private void BtnCancelUpdate_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        public DateTime ConvertStringTimeToDateTimeVal(string timeStr)
        {
            return DateTime.ParseExact(timeStr, "HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public void DisplaySelectedShift()
        {
            ResetShiftDaysCheckBoxes();
            if (this.EmployeeShiftToAddUpdate != null)
            {
                this.TboxShiftTitle.Text = this.EmployeeShiftToAddUpdate.Shift;
                this.DTPickerShiftStartTime.Value = this.EmployeeShiftToAddUpdate.StartTime; //this.ConvertStringTimeToDateTimeVal(this.EmployeeShiftToAddUpdate.StartTime);
                //this.DTPickerShiftEndTime.Value = this.EmployeeShiftToAddUpdate.EndTime;//this.ConvertStringTimeToDateTimeVal(this.EmployeeShiftToAddUpdate.EndTime);
                this.TboxShiftNumberOfHrs.Text = this.EmployeeShiftToAddUpdate.NumberOfHrs.ToString();
                //this.DTPickerShiftBreaktime.Value = this.EmployeeShiftToAddUpdate.BreakTime;//this.ConvertStringTimeToDateTimeVal(this.EmployeeShiftToAddUpdate.BreakTime);
                this.DTPickerEarlyTimeOut.Value = this.EmployeeShiftToAddUpdate.EarlyTimeOut;
                this.DTPickerLateTimeIn.Value = this.EmployeeShiftToAddUpdate.LateTimeIn;
                this.endTime.Value = this.EmployeeShiftToAddUpdate.EndTime;

                int index = BreakTimeHrsItems.FindIndex(a => (decimal)a.Value == this.EmployeeShiftToAddUpdate.BreakTimeHrs);
                this.CBoxBreakTimes.SelectedIndex = index;

                this.CboxDisable.Checked = this.EmployeeShiftToAddUpdate.IsActive == false;

                // Display shift days
                if (this.EmployeeShiftDaysToAddUpdate != null)
                {
                    foreach (var shiftDay in this.EmployeeShiftDaysToAddUpdate)
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
        }

        public string ComputeTimeDiffFromShiftStartAndEndTime()
        {
            var shiftStartTime = this.DTPickerShiftStartTime.Value;

            decimal numberOfHrs = this.TboxShiftNumberOfHrs.Value;

            int wholePartFrmHr = (int)decimal.Truncate(numberOfHrs);
            int fractionPartFrmHr = (int)numberOfHrs - wholePartFrmHr;

            var shiftEndTime = shiftStartTime.AddHours(wholePartFrmHr);
            shiftEndTime = shiftEndTime.AddMinutes(fractionPartFrmHr);

            TimeSpan interval = shiftEndTime - shiftStartTime;

            return interval.TotalHours.ToString("0.##");
        }

        public decimal GetHrInSelectedBreakTimeHrs()
        {
            var selectedIdx = CBoxBreakTimes.SelectedIndex;

            if (selectedIdx > -1)
            {
                var breakTimeItem = BreakTimeHrsItems[selectedIdx];

                if (breakTimeItem != null)
                {
                    return (decimal)breakTimeItem.Value;
                }
            }
            return 0;
        }

        //public decimal GetComputedShiftHrs()
        //{

        //    decimal currentComputedShiftHrs = decimal.Parse(ComputeTimeDiffFromShiftStartAndEndTime());

        //    var newShiftHrs = currentComputedShiftHrs - GetHrInSelectedBreakTimeHrs();

        //    return newShiftHrs;
        //}

        //private void CBoxBreakTimes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    this.TboxShiftNumberOfHrs.Text = GetComputedShiftHrs().ToString();
        //}


        private void CollectCheckedDays()
        {
            foreach (var daysCheckBoxControl in this.GroupPanelShiftDays.Controls)
            {
                if (daysCheckBoxControl is CheckBox)
                {
                    var dayCheckbox = (CheckBox)daysCheckBoxControl;

                    // MON-1, TUE-2, etc.
                    // see checkbox tag in form design
                    string dayTag = dayCheckbox.Tag as string;
                    string[] dayNumAndOrderNum = dayTag.Trim().Split('-');

                    string dayName = dayNumAndOrderNum[0];
                    int dayOrderNum = int.Parse(dayNumAndOrderNum[1]);

                    // if on updating
                    // check if the dayname is already in the list
                    // if already added and the checkbox is unchecked, then that means the user wants to delete the dayname

                    if (this.IsSaveNew == false)
                    {
                        var shiftDayInTheList = EmployeeShiftDaysToAddUpdate.Where(x => x.DayName == dayName && x.OrderNum == dayOrderNum).FirstOrDefault();

                        if (shiftDayInTheList != null && dayCheckbox.Checked == false)
                        {
                            shiftDayInTheList.IsDeleted = true;
                            shiftDayInTheList.DeletedAt = DateTime.Now;
                            shiftDayInTheList.IsNeedToUpdate = true;
                        }

                        if (shiftDayInTheList == null && dayCheckbox.Checked == true)
                        {
                            EmployeeShiftDaysToAddUpdate.Add(new EmployeeShiftDayModel
                            {
                                DayName = dayName,
                                OrderNum = dayOrderNum,
                                IsNeedToAdd = true
                            }); ;
                        }
                    }
                    else
                    {
                        if (dayCheckbox.Checked)
                        {
                            EmployeeShiftDaysToAddUpdate.Add(new EmployeeShiftDayModel
                            {
                                DayName = dayName,
                                OrderNum = dayOrderNum
                            });
                        }
                    }

                }
            }
        }


        private void BtnSaveWorkShift_Click(object sender, EventArgs e)
        {
            var shiftStartTime = this.DTPickerShiftStartTime.Value;
            decimal breakTimeHrs = GetHrInSelectedBreakTimeHrs();
            var timeDiff = TimeSpan.Parse(this.endTime.Value.Subtract(shiftStartTime).ToString());
            decimal numberOfHrs = (decimal)Math.Abs(timeDiff.TotalHours);
            var diff = (this.endTime.Value - shiftStartTime).TotalHours;
            var additionalHrs = (12 - (diff * -1));
            var totalNumberOfHrs = diff > 0 ? diff : 12 + additionalHrs;
            numberOfHrs = (decimal)totalNumberOfHrs;
            decimal wholeWorkingHrs = numberOfHrs + breakTimeHrs;

            decimal wholePartFrmHr = decimal.Truncate(wholeWorkingHrs); // include hrs from breaktime
            decimal fractionPartFrmHr = wholeWorkingHrs - wholePartFrmHr;

            var shiftEndTime = shiftStartTime.AddHours((double)wholePartFrmHr);
            shiftEndTime = shiftEndTime.AddMinutes((double)fractionPartFrmHr);

            CollectCheckedDays();

            DateTime breaktime = DateTime.Parse(this.DTPickerShiftBreaktime.Value.ToString("HH:mm:ss", CultureInfo.CurrentCulture));
            DateTime earlyTimeIn = breaktime.AddHours((double)breakTimeHrs);

            var employeeShift = new EmployeeShiftModel
            {
                Shift = this.TboxShiftTitle.Text,
                StartTime = DateTime.Parse(this.DTPickerShiftStartTime.Value.ToString("HH:mm:ss", CultureInfo.CurrentCulture)),
                EndTime = DateTime.Parse(this.endTime.Value.ToString("HH:mm:ss", CultureInfo.CurrentCulture)),
                NumberOfHrs = numberOfHrs,
                //BreakTime = breaktime,
                //BreakTimeHrs = breakTimeHrs,
                //EarlyTimeOut = DateTime.Parse(this.DTPickerEarlyTimeOut.Value.ToString("HH:mm:ss", CultureInfo.CurrentCulture)),
                //LateTimeIn = DateTime.Parse(this.DTPickerLateTimeIn.Value.ToString("HH:mm:ss", CultureInfo.CurrentCulture)),
                EarlyTimeOut = breaktime,
                LateTimeIn = earlyTimeIn,
                IsActive = this.CboxDisable.Checked == true ? false : true
            };

            if (this.IsSaveNew == true)
            {
                if (this.EmployeeShifts != null)
                {
                    var existingEmpShift = this.EmployeeShifts.Where(x => x.Shift.ToLower() == employeeShift.Shift.ToLower()).FirstOrDefault();

                    if (existingEmpShift != null)
                    {
                        MessageBox.Show("Invalid shift title, duplicate data", "Duplicate data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                this.EmployeeShiftToAddUpdate = employeeShift;
            }else
            {
                if (this.EmployeeShiftToAddUpdate != null)
                {
                    if (this.EmployeeShifts != null)
                    {
                        var existingEmpShift = this.EmployeeShifts
                                                    .Where(x => x.Shift.ToLower() == employeeShift.Shift.ToLower() &&
                                                            x.Id != this.EmployeeShiftToAddUpdate.Id)
                                                    .FirstOrDefault();

                        if (existingEmpShift != null)
                        {
                            MessageBox.Show("Invalid shift title, duplicate data", "Duplicate data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    this.EmployeeShiftToAddUpdate.Shift = employeeShift.Shift;
                    this.EmployeeShiftToAddUpdate.StartTime = employeeShift.StartTime;
                    this.EmployeeShiftToAddUpdate.EndTime = employeeShift.EndTime;
                    this.EmployeeShiftToAddUpdate.NumberOfHrs = employeeShift.NumberOfHrs;
                    this.EmployeeShiftToAddUpdate.BreakTime = employeeShift.BreakTime;
                    this.EmployeeShiftToAddUpdate.BreakTimeHrs = employeeShift.BreakTimeHrs;
                    this.EmployeeShiftToAddUpdate.EarlyTimeOut = employeeShift.EarlyTimeOut;
                    this.EmployeeShiftToAddUpdate.LateTimeIn = employeeShift.LateTimeIn;
                }
                
            }

            OnEmployeeShiftSaved(EventArgs.Empty);
        }


        public void DisplayWorkShiftList()
        {
            this.DGVWorkShifts.Rows.Clear();
            if (this.EmployeeShifts != null)
            {
                this.DGVWorkShifts.ColumnCount = 5;

                this.DGVWorkShifts.Columns[0].Name = "ShiftId";
                this.DGVWorkShifts.Columns[0].Visible = false;

                this.DGVWorkShifts.Columns[1].Name = "Shift";
                this.DGVWorkShifts.Columns[1].Visible = true;

                this.DGVWorkShifts.Columns[2].Name = "Start";
                this.DGVWorkShifts.Columns[2].Visible = true;

                this.DGVWorkShifts.Columns[3].Name = "End";
                this.DGVWorkShifts.Columns[3].Visible = true;

                //this.DGVWorkShifts.Columns[4].Name = "Breaktime";
                //this.DGVWorkShifts.Columns[4].Visible = true;

                //this.DGVWorkShifts.Columns[5].Name = "Breaktime Hrs";
                //this.DGVWorkShifts.Columns[5].Visible = true;

                this.DGVWorkShifts.Columns[4].Name = "Shift Hrs";
                this.DGVWorkShifts.Columns[4].Visible = true;

                //this.DGVWorkShifts.Columns[5].Name = "Early Time-OUT";
                //this.DGVWorkShifts.Columns[5].Visible = true;

                //this.DGVWorkShifts.Columns[6].Name = "Late Time-IN";
                //this.DGVWorkShifts.Columns[6].Visible = true;

                // Update button
                DataGridViewImageColumn btnUpdateImg = new DataGridViewImageColumn();
                //btnUpdateLeaveTypeImg.Name = "";
                btnUpdateImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnUpdateImg.Image = Image.FromFile("./Resources/edit-24.png");
                this.DGVWorkShifts.Columns.Add(btnUpdateImg);

                // Delete button
                DataGridViewImageColumn btnDeleteImg = new DataGridViewImageColumn();
                //btnDeleteLeaveTypeImg.Name = "";
                btnDeleteImg.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                btnDeleteImg.Image = Image.FromFile("./Resources/remove-24.png");
                this.DGVWorkShifts.Columns.Add(btnDeleteImg);

                foreach(var shift in this.EmployeeShifts)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.DGVWorkShifts);

                    if (shift.IsActive)
                        row.DefaultCellStyle.ForeColor = ForeColor = Color.Black;
                    else
                        row.DefaultCellStyle.ForeColor = ForeColor = Color.DimGray;

                    row.Cells[0].Value = shift.Id;
                    row.Cells[1].Value = shift.Shift;
                    row.Cells[2].Value = shift.StartTime.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
                    row.Cells[3].Value = shift.EndTime.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
                    //row.Cells[4].Value = shift.BreakTime.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
                    //row.Cells[5].Value = shift.BreakTimeHrs.ToString();
                    row.Cells[4].Value = shift.NumberOfHrs.ToString();
                    //row.Cells[5].Value = shift.LateTimeIn.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
                    //row.Cells[6].Value = shift.EarlyTimeOut.ToString("hh:mm:ss tt", CultureInfo.CurrentCulture);
                    this.DGVWorkShifts.Rows.Add(row);
                }
            }
        }

        private void DGVWorkShifts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Update button
            if (e.RowIndex > -1 && (e.ColumnIndex == 5))
            {
                if (DGVWorkShifts.CurrentRow != null)
                {
                    string shiftId = DGVWorkShifts.CurrentRow.Cells[0].Value.ToString();

                    SelectedEmpShiftIdToUpdate = shiftId;

                    this.CboxDisable.Visible = true;
                    this.BtnCancelUpdate.Visible = true;
                    this.IsSaveNew = false;
                }
            }

            // Delete button
            if (e.RowIndex > -1 && (e.ColumnIndex == 8))
            {
                if (DGVWorkShifts.CurrentRow != null)
                {
                    string shiftId = DGVWorkShifts.CurrentRow.Cells[0].Value.ToString();
                    SelectedEmpShiftIdToDelete = shiftId;
                }
            }
        }
    }
}
