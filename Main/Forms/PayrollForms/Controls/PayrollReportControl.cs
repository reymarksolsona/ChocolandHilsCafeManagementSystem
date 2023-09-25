using EntitiesShared;
using EntitiesShared.PayrollManagement;
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

namespace Main.Forms.PayrollForms.Controls
{
    public partial class PayrollReportControl : UserControl
    {
        public PayrollReportControl()
        {
            InitializeComponent();
        }

        private List<DateTime> payslipDateList;

        public List<DateTime> PayslipDateList
        {
            get { return payslipDateList; }
            set { payslipDateList = value; }
        }

        private void PayrollReportControl_Load(object sender, EventArgs e)
        {
            DisplayPayslipPaydateList();

            ComboboxItem item;
            foreach (int i in Enum.GetValues(typeof(StaticData.Months)))
            {
                item = new ComboboxItem();
                item.Value = i;
                item.Text = Enum.GetName(typeof(StaticData.Months), i);
                this.CboxMonths.Items.Add(item);
            }
        }

        public void DisplayPayslipPaydateList()
        {
            // Work shifts load in combo box
            if (this.PayslipDateList != null)
            {
                ComboboxItem item;
                foreach (var paydate in this.PayslipDateList)
                {
                    item = new ComboboxItem();
                    item.Text = paydate.ToShortDateString();
                    item.Value = paydate;
                    this.CBoxPayslipDates.Items.Add(item);
                }
            }
        }

        public DateTime SelectedPayslipPayDate { get; set; }

        public event EventHandler RetrieveEmployeePayslips;
        protected virtual void OnRetrieveEmployeePayslips(EventArgs e)
        {
            RetrieveEmployeePayslips?.Invoke(this, e);
        }

        private void BtnFilterPayrollHistory_Click(object sender, EventArgs e)
        {
            var selectedPaydate = this.CBoxPayslipDates.SelectedItem as ComboboxItem;
            if (selectedPaydate != null)
            {
                SelectedPayslipPayDate = DateTime.Parse(selectedPaydate.Value.ToString());
                OnRetrieveEmployeePayslips(EventArgs.Empty);
            }
        }


        private List<EmployeePayslipModel> employeePayslipsByPaydate;

        public List<EmployeePayslipModel> EmployeePayslipsByPaydate
        {
            get { return employeePayslipsByPaydate; }
            set { employeePayslipsByPaydate = value; }
        }

        public void DisplayPayslipHistory()
        {
            this.LVEmployeePayslipsHistory.Items.Clear();
            if (this.EmployeePayslipsByPaydate != null)
            {
                decimal totalPayment = 0;
                decimal totalGovContributionForCurrentEmp = 0;
                decimal empTotalGovContribution = 0;
                decimal emprTotalGovContribution = 0;

                foreach (var payslip in this.EmployeePayslipsByPaydate)
                {
                    totalGovContributionForCurrentEmp = payslip.EmployeeGovContributions.Sum(x => x.TotalContribution);
                    empTotalGovContribution = payslip.EmployeeGovContributions.Sum(x => x.EmployeeContribution);
                    emprTotalGovContribution = payslip.EmployeeGovContributions.Sum(x => x.EmployerContribution);

                    string[] item = new string[] {
                        payslip.EmployeeNumber,
                        payslip.Employee.FullName,
                        $"{payslip.StartShiftDate.ToString("dd/MM")}-{payslip.EndShiftDate.ToString("dd/MM")}",
                        payslip.DailyRate.ToString(),
                        payslip.Late,
                        payslip.LateTotalDeduction.ToString(),
                        payslip.UnderTime,
                        payslip.UnderTimeTotalDeduction.ToString(),
                        payslip.NetBasicSalary.ToString(),
                        payslip.BenefitsTotal.ToString(),
                        payslip.DeductionTotal.ToString(),
                        payslip.NetTakeHomePay.ToString(),
                        payslip.NumOfDays,
                        empTotalGovContribution.ToString(),
                        emprTotalGovContribution.ToString(),
                        totalGovContributionForCurrentEmp.ToString()
                    };

                    totalPayment += payslip.NetTakeHomePay;
                    //totalPayment += payslip.EmployerGovtContributionTotal;

                    var listViewItem = new ListViewItem(item);

                    this.LVEmployeePayslipsHistory.Items.Add(listViewItem);
                }

                this.LblTotalPayment.Text = totalPayment.ToString();
            }
        }

        public event EventHandler GeneratePDFEmployeePayslipsReport;
        protected virtual void OnGeneratePDFEmployeePayslipsReport(EventArgs e)
        {
            GeneratePDFEmployeePayslipsReport?.Invoke(this, e);
        }
        private void BtnGenerateEmployeePayslipsReportPDF_Click(object sender, EventArgs e)
        {
            OnGeneratePDFEmployeePayslipsReport(EventArgs.Empty);
        }

        public event EventHandler GeneratePDFEmployeeGovtContribReport;
        protected virtual void OnGeneratePDFEmployeeGovtContribReport(EventArgs e)
        {
            GeneratePDFEmployeeGovtContribReport?.Invoke(this, e);
        }

        public int SelectedMonthForEmpGovtContribReport { get; set; }

        private void BtnGenerateEmpGovContributionReport_Click(object sender, EventArgs e)
        {
            var selectedMonth = this.CboxMonths.SelectedItem as ComboboxItem;
            if (selectedMonth != null)
            {
                SelectedMonthForEmpGovtContribReport = int.Parse(selectedMonth.Value.ToString());
                OnGeneratePDFEmployeeGovtContribReport(EventArgs.Empty);
            }

        }
    }
}
