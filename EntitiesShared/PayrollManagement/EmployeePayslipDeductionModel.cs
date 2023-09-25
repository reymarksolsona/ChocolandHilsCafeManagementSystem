using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.PayrollManagement
{
    [Table("EmployeePayslipDeductions")]
    public class EmployeePayslipDeductionModel : BaseLongModel
    {
        private long payslipId;

        public long PayslipId
        {
            get { return payslipId; }
            set { payslipId = value; }
        }


        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        private string deductionTitle;

        public string DeductionTitle
        {
            get { return deductionTitle; }
            set { deductionTitle = value; }
        }

        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public decimal EmployerGovtContributionAmount { get; set; }
    }
}
