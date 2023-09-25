using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.PayrollManagement
{
    [Table("EmployeePayslipBenefits")]
    public class EmployeePayslipBenefitModel : BaseLongModel
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

        private string benefitTitle;

        public string BenefitTitle
        {
            get { return benefitTitle; }
            set { benefitTitle = value; }
        }

        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public StaticData.DisplayTypes DisplayType { get; set; }

        public string Multiplier { get; set; }

    }
}
