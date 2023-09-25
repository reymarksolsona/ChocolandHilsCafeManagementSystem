using Dapper.Contrib.Extensions;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.PayrollManagement
{
    [Table("EmployeePayslips")]
    public class EmployeePayslipModel : BaseLongModel
    {
        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }


        private EmployeeModel employee;
        [Write(false)]
        [Computed]
        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }


        private DateTime startShiftDate;

        public DateTime StartShiftDate
        {
            get { return startShiftDate; }
            set { startShiftDate = value; }
        }

        private DateTime endShiftDate;

        public DateTime EndShiftDate
        {
            get { return endShiftDate; }
            set { endShiftDate = value; }
        }


        private DateTime payDate;

        public DateTime PayDate
        {
            get { return payDate; }
            set { payDate = value; }
        }


        private decimal dailyRate;

        public decimal DailyRate
        {
            get { return dailyRate; }
            set { dailyRate = value; }
        }

        private string numOfDays;

        public string NumOfDays
        {
            get { return numOfDays; }
            set { numOfDays = value; }
        }


        public string Late { get; set; }

        public decimal LateTotalDeduction { get; set; }


        public string UnderTime { get; set; }

        public decimal UnderTimeTotalDeduction { get; set; }

        public string OverTime { get; set; }

        public decimal OverTimeTotalRate { get; set; }

        private decimal netBasicSalary;

        public decimal NetBasicSalary
        {
            get { return netBasicSalary; }
            set { netBasicSalary = value; }
        }

        private decimal benefitsTotal;

        public decimal BenefitsTotal
        {
            get { return benefitsTotal; }
            set { benefitsTotal = value; }
        }


        private List<EmployeePayslipBenefitModel> benefits;
        [Write(false)]
        [Computed]
        public List<EmployeePayslipBenefitModel> Benefits
        {
            get { return benefits; }
            set { benefits = value; }
        }

        public decimal TotalIncome { get; set; }


        private decimal deductionTotal;

        public decimal DeductionTotal
        {
            get { return deductionTotal; }
            set { deductionTotal = value; }
        }

        private List<EmployeePayslipDeductionModel> deductions;
        [Write(false)]
        [Computed]
        public List<EmployeePayslipDeductionModel> Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }

        private List<EmployeeGovernmentContributionModel> employeeGovContributions;
        [Write(false)]
        [Computed]
        public List<EmployeeGovernmentContributionModel> EmployeeGovContributions
        {
            get { return employeeGovContributions; }
            set { employeeGovContributions = value; }
        }


        public decimal NetTakeHomePay { get; set; }

        public bool IsCancel { get; set; }

    }
}
