using EntitiesShared.EmployeeManagement;
using EntitiesShared.PayrollManagement;
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
    public partial class PayslipItemControl : UserControl
    {
        public PayslipItemControl()
        {
            InitializeComponent();
        }

        public EmployeeModel Employee { get; set; }

        public EmployeePayslipModel Payslip { get; set; }


        private void PayslipItemControl_Load(object sender, EventArgs e)
        {
            if (Employee != null)
            {
                this.LblEmployeeName.Text = Employee.FullName;
                this.LblEmployeeNumber.Text = Employee.EmployeeNumber;
            }

            if (Payslip != null)
            {
                this.LblTotalIncome.Text = Payslip.TotalIncome.ToString();
                this.LblTotalDeductions.Text = Payslip.DeductionTotal.ToString();
                this.LblTotalNetTakeHomePay.Text = Payslip.NetTakeHomePay.ToString();

                this.LblShiftStartDate.Text = Payslip.StartShiftDate.ToShortDateString();
                this.LblShiftEndDate.Text = Payslip.EndShiftDate.ToShortDateString();

                var positionsDistinctList = Employee.PositionShift.Select(s => s.PositionId).Distinct();
                List<EmployeePositionShiftModel> positionList = new List<EmployeePositionShiftModel>();
                foreach (var item in positionsDistinctList)
                {
                    var position = Employee.PositionShift.Where(x => x.PositionId == item).FirstOrDefault();
                    positionList.Add(position);
                }

                if (positionList.Count() > 1)
                {
                    foreach (var item in positionList)
                    {
                        var dailyRate = new ListViewItem(new string[] {
                            "Daily Rate " + item.Position, "", item.DailyRate.ToString()
                        });
                        this.LVPayslipEarnings.Items.Add(dailyRate);
                    }
                } else {
                    var dailyRate = new ListViewItem(new string[] {
                            "Daily Rate", "", positionList[0].DailyRate.ToString()
                        });
                    this.LVPayslipEarnings.Items.Add(dailyRate);
                }

                if (Payslip.LateTotalDeduction > 0)
                {
                    var lessLate = new ListViewItem(new string[] {
                        "Less Late", Payslip.Late, $"-{Payslip.LateTotalDeduction}"
                    });
                    this.LVPayslipEarnings.Items.Add(lessLate);
                }

                if (Payslip.UnderTimeTotalDeduction > 0)
                {
                    var underTime = new ListViewItem(new string[] {
                        "Less Undertime", Payslip.UnderTime, $"-{Payslip.UnderTimeTotalDeduction}"
                    });
                    this.LVPayslipEarnings.Items.Add(underTime);
                }

                var netBasicSalary = new ListViewItem(new string[] {
                    "Net Basic salary", Payslip.NumOfDays.ToString(), Payslip.NetBasicSalary.ToString()
                });
                this.LVPayslipEarnings.Items.Add(netBasicSalary);

                if (this.Payslip.Benefits != null)
                {
                    foreach(var benefit in this.Payslip.Benefits)
                    {
                        var benefitItem = new ListViewItem(new string[] { 
                            benefit.BenefitTitle, "", benefit.Amount.ToString()
                        });
                        this.LVPayslipEarnings.Items.Add(benefitItem);
                    }
                }

                if (this.Payslip.EmployeeGovContributions != null)
                {
                    foreach (var contrib in this.Payslip.EmployeeGovContributions)
                    {
                        var contribItem = new ListViewItem(new string[] {
                            contrib.GovContributionEnumVal.ToString(), $"-{contrib.EmployeeContribution}"
                        });
                        this.LVPayslipDeductions.Items.Add(contribItem);
                    }
                }

                if (this.Payslip.Deductions != null)
                {
                    foreach(var deduction in this.Payslip.Deductions)
                    {
                        var deductionItem = new ListViewItem(new string[] {
                            deduction.DeductionTitle, deduction.Amount.ToString()
                        });
                        this.LVPayslipDeductions.Items.Add(deductionItem);
                    }
                }

                
            }
        }
    }
}
