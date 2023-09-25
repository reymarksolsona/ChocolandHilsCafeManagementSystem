using EntitiesShared;
using EntitiesShared.EmployeeManagement;
using EntitiesShared.OtherDataManagement;
using EntitiesShared.PayrollManagement;
using EntitiesShared.PayrollManagement.Models;
using EntitiesShared.POSManagement;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main.Forms.PayrollForms.Controls
{
    public partial class GeneratePayrollControl : UserControl
    {


        private DateTime payDate;

        public DateTime PayDate
        {
            get { return payDate; }
            set { payDate = value; }
        }

        private DateTime shiftStartDate;

        public DateTime ShiftStartDate
        {
            get { return shiftStartDate; }
            set { shiftStartDate = value; }
        }

        private DateTime shiftEndDate;

        public DateTime ShiftEndDate
        {
            get { return shiftEndDate; }
            set { shiftEndDate = value; }
        }

        // Event handler for saving leave type
        public event EventHandler InitiatePayrollGeneration;
        protected virtual void OnInitiatePayrollGeneration(EventArgs e)
        {
            InitiatePayrollGeneration?.Invoke(this, e);
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

        private List<EmployeeModel> employees;

        public List<EmployeeModel> Employees
        {
            get { return employees; }
            set { employees = value; }
        }


        private List<EmployeeBenefitModel> benefits;

        public List<EmployeeBenefitModel> Benefits
        {
            get { return benefits; }
            set { benefits = value; }
        }


        private List<EmployeeDeductionModel> deductions;
        public List<EmployeeDeductionModel> Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }


        private List<EmployeeCashAdvanceRequestModel> _employeesCashAdvance;

        public List<EmployeeCashAdvanceRequestModel> EmployeesCashAdvance
        {
            get { return _employeesCashAdvance; }
            set { _employeesCashAdvance = value; }
        }


        private List<CashRegisterCashOutTransactionModel> cashRegisterTotalSales;

        public List<CashRegisterCashOutTransactionModel> CashRegisterTotalSales
        {
            get { return cashRegisterTotalSales; }
            set { cashRegisterTotalSales = value; }
        }



        private readonly DecimalMinutesToHrsConverter _decimalMinutesToHrsConverter;

        public GeneratePayrollControl(DecimalMinutesToHrsConverter decimalMinutesToHrsConverter)
        {
            InitializeComponent();
            _decimalMinutesToHrsConverter = decimalMinutesToHrsConverter;
        }

        private void DGVFontAndColors(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = Color.White;
            dataGridView.DefaultCellStyle.Font = new Font("Century Gothic", 12);
            dataGridView.RowHeadersVisible = false;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = false;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.ColumnHeadersHeight = 30;
        }

        private void SetDGVFontAndColors()
        {
            this.DGVFontAndColors(this.DGVEmployeeList);
            this.DGVFontAndColors(this.DGVGovtAgencies);
            this.DGVFontAndColors(this.DGVBenefitsList);
            this.DGVFontAndColors(this.DGVEmployeeCashAdvance);
            this.DGVFontAndColors(this.DGVDeductionList);
            this.DGVFontAndColors(this.DGVSalesRecords);
            this.DGVFontAndColors(this.DGVEmployeeListForOverview);
        }

        private void GeneratePayrollControl_Load(object sender, EventArgs e)
        {
            SetDGVFontAndColors();
            DisplayGovernmentAgencyList();
            DisplayBenefitsInDGV();
            DisplayDeductionsInDGV();
        }

        private void BtnGeneratePayrollInitiate_Click(object sender, EventArgs e)
        {
            this.PayDate = DPickerPaydate.Value;
            this.ShiftStartDate = DPickerShiftStartDate.Value;
            this.ShiftEndDate = DPickerShiftEndDate.Value;

            this.LblPaydate.Text = DPickerPaydate.Value.ToShortDateString();
            this.LblAttendanceDateStart.Text = DPickerShiftStartDate.Value.ToShortDateString();
            this.LblAttendanceDateEnd.Text = DPickerShiftEndDate.Value.ToShortDateString();

            OnInitiatePayrollGeneration(EventArgs.Empty);
        }


        public void DisplayEmployeeWithAttendanceRecordAndSalary(List<EmployeeModel> EmployeeList)
        {
            if (this.AttendanceHistory != null && EmployeeList != null)
            {
                this.DGVEmployeeList.Rows.Clear();
                if (EmployeeList != null)
                {
                    this.DGVEmployeeList.ColumnCount = 8;

                    this.DGVEmployeeList.Columns[0].Name = "EmployeeNumber";
                    this.DGVEmployeeList.Columns[0].HeaderText = "Employee Number";
                    this.DGVEmployeeList.Columns[0].Visible = true;

                    this.DGVEmployeeList.Columns[1].Name = "Fullname2";
                    this.DGVEmployeeList.Columns[1].HeaderText = "Fullname";
                    this.DGVEmployeeList.Columns[1].Visible = true;

                    this.DGVEmployeeList.Columns[2].Name = "DailyRate";
                    this.DGVEmployeeList.Columns[2].HeaderText = "Daily Rate";
                    this.DGVEmployeeList.Columns[2].Visible = true;

                    this.DGVEmployeeList.Columns[3].Name = "Days";
                    this.DGVEmployeeList.Columns[3].HeaderText = "Days";
                    this.DGVEmployeeList.Columns[3].Visible = true;

                    this.DGVEmployeeList.Columns[4].Name = "L";
                    this.DGVEmployeeList.Columns[4].HeaderText = "L";
                    this.DGVEmployeeList.Columns[4].Visible = true;

                    this.DGVEmployeeList.Columns[5].Name = "Late";
                    this.DGVEmployeeList.Columns[5].HeaderText = "Late";
                    this.DGVEmployeeList.Columns[5].Visible = true;

                    this.DGVEmployeeList.Columns[6].Name = "UT";
                    this.DGVEmployeeList.Columns[6].HeaderText = "UT";
                    this.DGVEmployeeList.Columns[6].Visible = true;

                    this.DGVEmployeeList.Columns[7].Name = "OT";
                    this.DGVEmployeeList.Columns[7].HeaderText = "OT";
                    this.DGVEmployeeList.Columns[7].Visible = true;

                    DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
                    selectChbxToSchedule.HeaderText = "Select";
                    selectChbxToSchedule.Name = "selectEmpCkbox";
                    selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    this.DGVEmployeeList.Columns.Add(selectChbxToSchedule);


                    foreach (var employee in EmployeeList)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(this.DGVEmployeeList);

                        row.Cells[0].Value = employee.EmployeeNumber;
                        row.Cells[1].Value = employee.FullName;

                        if (employee.Position != null)
                        {
                            row.Cells[2].Value = employee.Position.DailyRate;
                        }

                        var currentEmpAttendanceRec = this.AttendanceHistory.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();
                        var totalDays = currentEmpAttendanceRec.Count;
                        var totalLateInMins = currentEmpAttendanceRec.Sum(x => x.TotalLate);
                        var totalUnderTime = currentEmpAttendanceRec.Sum(x => x.TotalUnderTime);

                        if (totalDays <= 0)
                        {
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            row.ReadOnly = true;
                        }

                        row.Cells[3].Value = totalDays.ToString();

                        if (this.EmployeeLeaveHistory != null)
                        {
                            var currentEmpLeave = this.EmployeeLeaveHistory.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();
                            var totalLeave = currentEmpLeave.Sum(x => x.NumberOfDays);
                            row.Cells[4].Value = totalLeave.ToString();
                        }
                        else
                        {
                            row.Cells[4].Value = "";
                        }

                        row.Cells[5].Value = _decimalMinutesToHrsConverter.ConvertToStringHrs(totalLateInMins);
                        row.Cells[6].Value = _decimalMinutesToHrsConverter.ConvertToStringHrs(totalUnderTime);

                        row.Cells[7].Value = "";

                        row.Tag = employee;

                        this.DGVEmployeeList.Rows.Add(row);
                    }

                }
            }
        }

        private void TboxSearchEmployee_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var searchStr = TboxSearchEmployee.Text;
                var searchEmployeeResults = this.Employees.Where(x => x.EmployeeNumber.Contains(searchStr) || 
                                                        x.FullName.Contains(searchStr)).ToList();

                this.DisplayEmployeeWithAttendanceRecordAndSalary(searchEmployeeResults);

                e.Handled = true;
            }
        }

        private void BtnSelectAllEmployeesInDGV_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVEmployeeList.Rows)
            {
                if (row.ReadOnly == false)
                    row.Cells["selectEmpCkbox"].Value = (bool)true;
            }
        }

        public void DisplayGovernmentAgencyList()
        {
            this.DGVGovtAgencies.Rows.Clear();

            var govContributions = StaticData.GetGovContributions;

            this.DGVGovtAgencies.ColumnCount = 1;

            this.DGVGovtAgencies.Columns[0].Name = "AgencyTitle";
            this.DGVGovtAgencies.Columns[0].HeaderText = "Agency";

            DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
            selectChbxToSchedule.HeaderText = "Select";
            selectChbxToSchedule.Name = "selectGovtAngencyCkbox";
            selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVGovtAgencies.Columns.Add(selectChbxToSchedule);

            foreach (var item in govContributions)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(DGVGovtAgencies);

                row.Cells[0].Value = item.Value;

                row.Tag = item.Key; // enum value

                DGVGovtAgencies.Rows.Add(row);
            }
        }

        public void DisplayBenefitsInDGV()
        {
            this.DGVBenefitsList.Rows.Clear();
            if (this.Benefits != null)
            {
                this.DGVBenefitsList.ColumnCount = 3;

                this.DGVBenefitsList.Columns[0].Name = "benefitId";
                this.DGVBenefitsList.Columns[0].Visible = false;

                this.DGVBenefitsList.Columns[1].Name = "BenefitTitle";
                this.DGVBenefitsList.Columns[1].HeaderText = "Title";

                this.DGVBenefitsList.Columns[2].Name = "BenefitAmount";
                this.DGVBenefitsList.Columns[2].HeaderText = "Amount";

                DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
                selectChbxToSchedule.HeaderText = "Select";
                selectChbxToSchedule.Name = "selectBenefitCkbox";
                selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DGVBenefitsList.Columns.Add(selectChbxToSchedule);

                foreach (var benefit in this.Benefits)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVBenefitsList);

                    row.Cells[0].Value = benefit.Id;
                    row.Cells[1].Value = benefit.BenefitTitle;
                    row.Cells[2].Value = benefit.Amount;

                    row.Tag = benefit;

                    DGVBenefitsList.Rows.Add(row);
                }

            }
        }


        public void DisplayEmployeeCashAdvanceRequestsInDGV()
        {
            this.DGVEmployeeCashAdvance.Rows.Clear();
            if (this.Deductions != null)
            {
                this.DGVEmployeeCashAdvance.ColumnCount = 4;

                this.DGVEmployeeCashAdvance.Columns[0].Name = "benefitId";
                this.DGVEmployeeCashAdvance.Columns[0].Visible = false;

                this.DGVEmployeeCashAdvance.Columns[1].Name = "EmployeeName";
                this.DGVEmployeeCashAdvance.Columns[1].HeaderText = "Employee";

                this.DGVEmployeeCashAdvance.Columns[2].Name = "DeductionAmount";
                this.DGVEmployeeCashAdvance.Columns[2].HeaderText = "Amount";

                this.DGVEmployeeCashAdvance.Columns[3].Name = "CashReleaseDate";
                this.DGVEmployeeCashAdvance.Columns[3].HeaderText = "Cash release date";

                DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
                selectChbxToSchedule.HeaderText = "Select";
                selectChbxToSchedule.Name = "selectCashAdvanceCkbox";
                selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DGVEmployeeCashAdvance.Columns.Add(selectChbxToSchedule);

                foreach (var cashAdvance in this.EmployeesCashAdvance)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVEmployeeCashAdvance);

                    row.Cells[0].Value = cashAdvance.Id;
                    row.Cells[1].Value = cashAdvance.Employee.FullName;
                    row.Cells[2].Value = cashAdvance.Amount;
                    row.Cells[3].Value = cashAdvance.CashReleaseDate.ToShortDateString();

                    row.Tag = cashAdvance;

                    DGVEmployeeCashAdvance.Rows.Add(row);
                }

            }
        }



        public void DisplayDeductionsInDGV()
        {
            this.DGVDeductionList.Rows.Clear();
            if (this.Deductions != null)
            {
                this.DGVDeductionList.ColumnCount = 2;

                this.DGVDeductionList.Columns[0].Name = "benefitId";
                this.DGVDeductionList.Columns[0].Visible = false;

                this.DGVDeductionList.Columns[1].Name = "DeductionTitle";
                this.DGVDeductionList.Columns[1].HeaderText = "Title";

                //this.DGVDeductionList.Columns[2].Name = "DeductionAmount";
                //this.DGVDeductionList.Columns[2].HeaderText = "Amount";

                DataGridViewTextBoxColumn textboxColumn = new DataGridViewTextBoxColumn();
                textboxColumn.HeaderText = "Default Amount";
                textboxColumn.Name = "DeductionAmount";
                textboxColumn.DefaultCellStyle.BackColor = Color.Bisque;
                textboxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //textboxColumn.ReadOnly = true;
                DGVDeductionList.Columns.Add(textboxColumn);

                DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
                selectChbxToSchedule.HeaderText = "Select";
                selectChbxToSchedule.Name = "selectDeductionCkbox";
                selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DGVDeductionList.Columns.Add(selectChbxToSchedule);

                foreach (var deduction in this.Deductions)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVDeductionList);

                    row.Cells[0].Value = deduction.Id;
                    row.Cells[1].Value = deduction.DeductionTitle;
                    row.Cells[2].Value = deduction.Amount;

                    row.Tag = deduction;

                    DGVDeductionList.Rows.Add(row);
                }

            }
        }


        public void DisplayCashRegisterTotalSalesInDGV()
        {
            this.DGVSalesRecords.Rows.Clear();
            if (this.CashRegisterTotalSales != null)
            {
                this.DGVSalesRecords.ColumnCount = 3;

                this.DGVSalesRecords.Columns[0].Name = "cashRegisterTransId";
                this.DGVSalesRecords.Columns[0].Visible = false;

                this.DGVSalesRecords.Columns[1].Name = "WorkDate";
                this.DGVSalesRecords.Columns[1].HeaderText = "Date";

                this.DGVSalesRecords.Columns[2].Name = "TotalSales";
                this.DGVSalesRecords.Columns[2].HeaderText = "Total sales";

                DataGridViewCheckBoxColumn selectChbxToSchedule = new DataGridViewCheckBoxColumn();
                selectChbxToSchedule.HeaderText = "Select";
                selectChbxToSchedule.Name = "selectSalesRecordCkbox";
                selectChbxToSchedule.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.DGVSalesRecords.Columns.Add(selectChbxToSchedule);

                foreach (var cashRegisterTrans in this.CashRegisterTotalSales)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(DGVSalesRecords);

                    row.Cells[0].Value = cashRegisterTrans.Id;
                    row.Cells[1].Value = cashRegisterTrans.CreatedAt.ToShortDateString();
                    row.Cells[2].Value = cashRegisterTrans.TotalSales.ToString("#,##0.##");

                    row.Tag = cashRegisterTrans;

                    DGVSalesRecords.Rows.Add(row);
                }

            }
        }


        private void BtnSelectAllGovtAgencies_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVGovtAgencies.Rows)
            {
                row.Cells["selectGovtAngencyCkbox"].Value = (bool)true;
            }
        }

        private void BtnSelectAllBenefits_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVBenefitsList.Rows)
            {
                row.Cells["selectBenefitCkbox"].Value = (bool)true;
            }
        }

        private void btnSelectAllEmpCashAdvance_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVEmployeeCashAdvance.Rows)
            {
                row.Cells["selectCashAdvanceCkbox"].Value = (bool)true;
            }
        }

        private void BtnSelectAllDeductions_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVDeductionList.Rows)
            {
                row.Cells["selectDeductionCkbox"].Value = (bool)true;
            }
        }

        private void BtnSelectAllCashRegisterTrans_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVSalesRecords.Rows)
            {
                row.Cells["selectSalesRecordCkbox"].Value = (bool)true;
            }
        }

        public List<EmployeeModel> GetSelectedEmployeeToGeneratePayslip()
        {
            List<EmployeeModel> selectedEmployees = new List<EmployeeModel>();

            foreach (DataGridViewRow row in this.DGVEmployeeList.Rows)
            {
                if (row.ReadOnly == false)
                {
                    bool isSelected = Convert.ToBoolean(row.Cells["selectEmpCkbox"].Value);
                    if (isSelected)
                    {
                        string empNum = row.Cells["EmployeeNumber"].Value.ToString();
                        var empInList = this.Employees.Where(x => x.EmployeeNumber == empNum).FirstOrDefault();

                        var currentEmpAttendanceRec = this.AttendanceHistory.Where(x => x.EmployeeNumber == empNum).ToList();
                        var totalDays = currentEmpAttendanceRec.Count;

                        if (empInList != null && totalDays > 0)
                        {
                            var empTmp = JsonSerializer.Deserialize<EmployeeModel>(JsonSerializer.Serialize(empInList));
                            selectedEmployees.Add(empTmp);
                        }
                    }
                }
            }

            return selectedEmployees;
        }


        public List<StaticData.GovContributions> GetSelectedGovtAgenciesToGeneratePayslip()
        {
            List<StaticData.GovContributions> selectedGovtContributions = new List<StaticData.GovContributions>();

            foreach (DataGridViewRow row in this.DGVGovtAgencies.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectGovtAngencyCkbox"].Value);
                if (isSelected)
                {
                    var selectedGovt = (StaticData.GovContributions)row.Tag;
                    selectedGovtContributions.Add(selectedGovt);
                }
            }

            return selectedGovtContributions;
        }


        public List<EmployeeBenefitModel> GetSelectedEmpBenefitsToGeneratePayslip()
        {
            List<EmployeeBenefitModel> selectedEmpBenefits = new List<EmployeeBenefitModel>();

            foreach (DataGridViewRow row in this.DGVBenefitsList.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectBenefitCkbox"].Value);
                if (isSelected)
                {
                    var selectedEmpBenefit = (EmployeeBenefitModel)row.Tag;
                    var empBenefitInList = this.Benefits.Where(x => x.Id == selectedEmpBenefit.Id).FirstOrDefault();

                    if (empBenefitInList != null)
                    {
                        var govtAgencyTemp = JsonSerializer.Deserialize<EmployeeBenefitModel>(JsonSerializer.Serialize(empBenefitInList));
                        selectedEmpBenefits.Add(govtAgencyTemp);
                    }
                }
            }

            return selectedEmpBenefits;
        }

        public List<EmployeeDeductionModel> GetSelectedEmpDeductionsToGeneratePayslip()
        {
            List<EmployeeDeductionModel> selectedEmpDeductions = new List<EmployeeDeductionModel>();

            foreach (DataGridViewRow row in this.DGVDeductionList.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectDeductionCkbox"].Value);
                decimal newAmount = Convert.ToDecimal(row.Cells["DeductionAmount"].Value);

                if (isSelected)
                {
                    var selectedEmpDeduction = (EmployeeDeductionModel)row.Tag;
                    var empDeductionInList = this.Deductions.Where(x => x.Id == selectedEmpDeduction.Id).FirstOrDefault();

                    empDeductionInList.Amount = newAmount;

                    if (empDeductionInList != null)
                    {
                        selectedEmpDeductions.Add(empDeductionInList);
                    }
                }
            }

            return selectedEmpDeductions;
        }


        public List<EmployeeCashAdvanceRequestModel> GetSelectedEmpCashAdvanceRequestToGeneratePayslip()
        {
            List<EmployeeCashAdvanceRequestModel> selectedEmpCashAdvance = new List<EmployeeCashAdvanceRequestModel>();

            foreach (DataGridViewRow row in this.DGVEmployeeCashAdvance.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectCashAdvanceCkbox"].Value);

                if (isSelected)
                {
                    var EmpCashAdvanceReq = (EmployeeCashAdvanceRequestModel)row.Tag;

                    if (EmpCashAdvanceReq != null)
                    {
                        selectedEmpCashAdvance.Add(EmpCashAdvanceReq);
                    }
                }
            }

            return selectedEmpCashAdvance;
        }

        public List<CashRegisterCashOutTransactionModel> GetSelectedSalesRecordToGeneratePayslip()
        {
            List<CashRegisterCashOutTransactionModel> selectedSalesRecords = new List<CashRegisterCashOutTransactionModel>();

            foreach (DataGridViewRow row in this.DGVSalesRecords.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["selectSalesRecordCkbox"].Value);
                if (isSelected)
                {
                    var saleRecord = (CashRegisterCashOutTransactionModel)row.Tag;
                    var saleRecordInList = this.CashRegisterTotalSales.Where(x => x.Id == saleRecord.Id).FirstOrDefault();

                    if (saleRecordInList != null)
                    {
                        var saleRecordTemp = JsonSerializer.Deserialize<CashRegisterCashOutTransactionModel>(JsonSerializer.Serialize(saleRecordInList));
                        selectedSalesRecords.Add(saleRecordTemp);
                    }
                }
            }

            return selectedSalesRecords;
        }

        public void ClearDGVEmployeeListForOverview()
        {
            this.DGVEmployeeListForOverview.Rows.Clear();
            this.PanelEmployeePayslipContainer.Controls.Clear();
        }

        public void DisplayEmployeeInOverviewTag(List<EmployeeModel> EmployeeList)
        {
            if (this.AttendanceHistory != null && EmployeeList != null)
            {
                ClearDGVEmployeeListForOverview();
                if (EmployeeList != null)
                {
                    this.DGVEmployeeListForOverview.ColumnCount = 2;

                    this.DGVEmployeeListForOverview.Columns[0].Name = "EmployeeNumber";
                    this.DGVEmployeeListForOverview.Columns[0].HeaderText = "Employee Number";
                    this.DGVEmployeeListForOverview.Columns[0].Visible = true;

                    this.DGVEmployeeListForOverview.Columns[1].Name = "Fullname2";
                    this.DGVEmployeeListForOverview.Columns[1].HeaderText = "Fullname";
                    this.DGVEmployeeListForOverview.Columns[1].Visible = true;

                    foreach (var employee in EmployeeList)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(this.DGVEmployeeListForOverview);

                        row.Cells[0].Value = employee.EmployeeNumber;
                        row.Cells[1].Value = employee.FullName;

                        row.Tag = employee;

                        this.DGVEmployeeListForOverview.Rows.Add(row);
                    }

                }
            }
        }


        private decimal GetActualLeaveValue (StaticData.LeaveDurationType leaveDuration)
        {
            decimal leaveValue = 0;
            switch (leaveDuration)
            {
                case StaticData.LeaveDurationType.FullDay:
                    leaveValue = 1;
                    break;

                case StaticData.LeaveDurationType.FirstHalfDay:
                    leaveValue = 0.5m;
                    break;

                case StaticData.LeaveDurationType.SecondHalfDay:
                    leaveValue = 0.5m;
                    break;

                default:
                    break;
            }

            return leaveValue;
        }


        public PaydaySalaryComputationPayslip GetEmployeeAttendanceRecordWithSalaryComputation(EmployeeModel employee)
        {
            if (this.AttendanceHistory != null && employee != null)
            {
                var currentEmpAttendanceRec = this.AttendanceHistory.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();
                decimal totalDays = currentEmpAttendanceRec.Where(x => x.OverTimeType == StaticData.OverTimeTypes.NA ||
                                                                        x.OverTimeType == StaticData.OverTimeTypes.OrdinaryDayOvertime)
                                                                .ToList().Count;
                decimal totalLeaveDays = 0;

                if (this.EmployeeLeaveHistory != null)
                {
                    var currentEmpLeave = this.EmployeeLeaveHistory.Where(x => x.EmployeeNumber == employee.EmployeeNumber).ToList();
                    totalLeaveDays = currentEmpLeave.Sum(x => this.GetActualLeaveValue(x.DurationType) * x.NumberOfDays);
                }
                totalDays += totalLeaveDays;

                if (employee.Position == null)
                    throw new Exception($"{employee.FullName} don't have position and salary rate. Kindly update employee details");


                var attendanceRecordWithOvertimeGrpByOTType = currentEmpAttendanceRec
                                                                        .Where(x => x.OverTimeType != StaticData.OverTimeTypes.NA &&
                                                                                    x.OverTimeType != StaticData.OverTimeTypes.OrdinaryDayOvertime)
                                                                        .ToList()
                                                                        .GroupBy(x => x.OverTimeType);

                var overTimeDaysWithRate = new Dictionary<StaticData.OverTimeTypes, OverTimeCounter>();
                if (attendanceRecordWithOvertimeGrpByOTType != null)
                {
                    foreach(var OTGrp in attendanceRecordWithOvertimeGrpByOTType)
                    {
                        overTimeDaysWithRate.Add(OTGrp.Key, 
                                new OverTimeCounter {
                                    // late and undertime is already deducted upon time-out computation
                                    TotalRate = OTGrp.Sum(x => x.OvertimeDailySalaryAdjustment), 
                                    NumberOfOvertime = OTGrp.Count(),
                                    Late = OTGrp.Sum(x => x.TotalLate).ToString() + "m",
                                    LateTotalDeduction = OTGrp.Sum(x => x.LateTotalDeduction),
                                    UnderTime = OTGrp.Sum(x => x.TotalUnderTime).ToString() + "m",
                                    UnderTimeTotalDeduction = OTGrp.Sum(x => x.UnderTimeTotalDeduction),
                                    OverTime = OTGrp.Sum(x => x.OverTimeMins).ToString() + "m",
                                    OverTimeTotalRate = OTGrp.Sum(x => x.OverTimeTotal),
                                });

                    }
                }

                decimal netBasicSalary = currentEmpAttendanceRec.Where(x => x.OverTimeType == StaticData.OverTimeTypes.NA ||
                                                                            x.OverTimeType == StaticData.OverTimeTypes.OrdinaryDayOvertime)
                                                                .Sum(x => x.TotalDailySalary);

                netBasicSalary += employee.Position.DailyRate * totalLeaveDays;


                string lateMins = currentEmpAttendanceRec.Where(x => x.OverTimeType == StaticData.OverTimeTypes.NA ||
                                                                x.OverTimeType == StaticData.OverTimeTypes.OrdinaryDayOvertime)
                                                            .Sum(x => x.TotalLate).ToString() + "m";

                decimal lateTotalDeduction = currentEmpAttendanceRec.Where(x => x.OverTimeType == StaticData.OverTimeTypes.NA ||
                                                                x.OverTimeType == StaticData.OverTimeTypes.OrdinaryDayOvertime)
                                                            .Sum(x => x.LateTotalDeduction);

                string underTimeMins = currentEmpAttendanceRec.Where(x => x.OverTimeType == StaticData.OverTimeTypes.NA ||
                                                                x.OverTimeType == StaticData.OverTimeTypes.OrdinaryDayOvertime)
                                                        .Sum(x => x.TotalUnderTime).ToString() + "m";

                decimal underTimeTotalDeduction = currentEmpAttendanceRec.Where(x => x.OverTimeType == StaticData.OverTimeTypes.NA ||
                                                                x.OverTimeType == StaticData.OverTimeTypes.OrdinaryDayOvertime)
                                                    .Sum(x => x.UnderTimeTotalDeduction);

                string overTimeMins = currentEmpAttendanceRec.Where(x => x.OverTimeType == StaticData.OverTimeTypes.NA ||
                                                                      x.OverTimeType == StaticData.OverTimeTypes.OrdinaryDayOvertime)
                                                            .Sum(x => x.OverTimeMins).ToString() + "m";

                decimal overTimeTotal = currentEmpAttendanceRec.Where(x => x.OverTimeType == StaticData.OverTimeTypes.NA ||
                                                                            x.OverTimeType == StaticData.OverTimeTypes.OrdinaryDayOvertime)
                                                                .Sum(x => x.OverTimeTotal);


                // no need to deduct this in netBasicSalary, since we already deduct late and undertime upon inserting the data in time-in and out terminal
                return new PaydaySalaryComputationPayslip
                {
                    Late = lateMins,
                    LateTotalDeduction = lateTotalDeduction,
                    UnderTime = underTimeMins,
                    UnderTimeTotalDeduction = underTimeTotalDeduction,
                    OverTime = overTimeMins,
                    OverTimeTotalRate = overTimeTotal,
                    NumberOfDays = totalDays.ToString() + "d",
                    NetBasicSalary = netBasicSalary,
                    OverTimeDaysWithRate = overTimeDaysWithRate
                };
            }

            return new PaydaySalaryComputationPayslip();
        }


        private List<EmployeePayslipGeneration> employeePayslipGenerations = new List<EmployeePayslipGeneration>();

        public List<EmployeePayslipGeneration> EmployeePayslipGenerations
        {
            get { return employeePayslipGenerations; }
            set { employeePayslipGenerations = value; }
        }


        public event EventHandler GenerateEmployeePayslip;
        protected virtual void OnGenerateEmployeePayslip(EventArgs e)
        {
            GenerateEmployeePayslip?.Invoke(this, e);
        }

        private void BtnGenerateEmployeePayslip_Click(object sender, EventArgs e)
        {
            try
            {
                var SelectedEmployeesForPayrollGeneration = this.GetSelectedEmployeeToGeneratePayslip();
                if (SelectedEmployeesForPayrollGeneration != null && SelectedEmployeesForPayrollGeneration.Count > 0)
                {
                    var SelectedGovtAgenciesForPayrollGeneration = this.GetSelectedGovtAgenciesToGeneratePayslip();
                    var SelectedBenefitsForPayrollGeneration = this.GetSelectedEmpBenefitsToGeneratePayslip();
                    var SelectedEmpCashAdvanceRequestsForPayrollGeneration = this.GetSelectedEmpCashAdvanceRequestToGeneratePayslip();
                    var SelectedDeductionsForPayrollGeneration = this.GetSelectedEmpDeductionsToGeneratePayslip();
                    var selectedSaleRecords = this.GetSelectedSalesRecordToGeneratePayslip();

                    EmployeePayslipGenerations = new List<EmployeePayslipGeneration>();

                    foreach (var selectedEmp in SelectedEmployeesForPayrollGeneration)
                    {
                        EmployeePayslipGenerations.Add(new EmployeePayslipGeneration
                        {
                            PayDate = this.PayDate,
                            ShiftStartDate = this.ShiftStartDate,
                            ShiftEndDate = this.ShiftEndDate,
                            Employee = selectedEmp,
                            PaydaySalaryComputation = this.GetEmployeeAttendanceRecordWithSalaryComputation(selectedEmp),
                            AttendanceHistory = this.AttendanceHistory != null ? this.AttendanceHistory.Where(x => x.EmployeeNumber == selectedEmp.EmployeeNumber).ToList() : null,
                            EmployeeLeaves = this.EmployeeLeaveHistory != null ? this.EmployeeLeaveHistory.Where(x => x.EmployeeNumber == selectedEmp.EmployeeNumber).ToList() : null,
                            SelectedGovContributions = SelectedGovtAgenciesForPayrollGeneration,
                            SelectedBenefits = SelectedBenefitsForPayrollGeneration,
                            SelectedEmpCashAdvanceRequests = SelectedEmpCashAdvanceRequestsForPayrollGeneration,
                            SelectedDeductions = SelectedDeductionsForPayrollGeneration,
                            SelectedSalesReport = selectedSaleRecords
                        });
                    }

                    OnGenerateEmployeePayslip(EventArgs.Empty);

                    this.DisplayEmployeeInOverviewTag(SelectedEmployeesForPayrollGeneration);
                }
                else
                {
                    MessageBox.Show("No selected employee for payslip generation.", "Get selected employees", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Generate payslip", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string selectedEmployeeNumberToViewPayslip;

        public string SelectedEmployeeNumberToViewPayslip
        {
            get { return selectedEmployeeNumberToViewPayslip; }
            set { selectedEmployeeNumberToViewPayslip = value; }
        }

        public event EventHandler ViewEmployeePayslip;
        protected virtual void OnViewEmployeePayslip(EventArgs e)
        {
            ViewEmployeePayslip?.Invoke(this, e);
        }

        private void DGVEmployeeListForOverview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (DGVEmployeeListForOverview.CurrentRow != null)
                {
                    SelectedEmployeeNumberToViewPayslip = DGVEmployeeListForOverview.CurrentRow.Cells[0].Value.ToString();
                    OnViewEmployeePayslip(EventArgs.Empty);
                }
            }
        }

        public void DisplayEmployeePayslip(EmployeeModel employee, EmployeePayslipModel payslip)
        {
            this.PanelEmployeePayslipContainer.Controls.Clear();
            var payslipItemControlObj = new PayslipItemControl { Employee = employee, Payslip = payslip};
            payslipItemControlObj.Location = new Point(this.PanelEmployeePayslipContainer.Width / 2 - payslipItemControlObj.Size.Width / 2, this.PanelEmployeePayslipContainer.Height / 2 - payslipItemControlObj.Size.Height / 2);
            payslipItemControlObj.Anchor = AnchorStyles.None;
            this.PanelEmployeePayslipContainer.Controls.Add(payslipItemControlObj);
        }


        public event EventHandler CancelAllEmployeePayslip;
        protected virtual void OnCancelAllEmployeePayslip(EventArgs e)
        {
            CancelAllEmployeePayslip?.Invoke(this, e);
        }

        private void BtnCancelAllEmployeePayslip_Click(object sender, EventArgs e)
        {
            OnCancelAllEmployeePayslip(EventArgs.Empty);
        }

        public event EventHandler CancelSelectedEmployeePayslip;
        protected virtual void OnCancelSelectedEmployeePayslip(EventArgs e)
        {
            CancelSelectedEmployeePayslip?.Invoke(this, e);
        }
        private void BtnCancelSelectedEmployeePayslip_Click(object sender, EventArgs e)
        {
            OnCancelSelectedEmployeePayslip(EventArgs.Empty);
        }

        public event EventHandler GeneratePayslipPDF;
        protected virtual void OnGeneratePayslipPDF(EventArgs e)
        {
            GeneratePayslipPDF?.Invoke(this, e);
        }
        private void BtnGeneratePayslipPDF_Click(object sender, EventArgs e)
        {
            OnGeneratePayslipPDF(EventArgs.Empty);
        }

    }
}
