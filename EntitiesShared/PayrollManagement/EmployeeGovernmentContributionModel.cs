using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.PayrollManagement
{
    [Table("EmployeeGovernmentContributions")]
    public class EmployeeGovernmentContributionModel : BaseLongModel
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

        public string Agency { get; set; }

        public StaticData.GovContributions GovContributionEnumVal { get; set; }

        public string IdNumber { get; set; }

        public decimal EmployeeContribution { get; set; }

        public decimal EmployerContribution { get; set; }

        [Write(false)]
        [Computed]
        public decimal TotalContribution
        {
            get
            {
                return this.EmployeeContribution + this.EmployerContribution;
            }
        }
    }
}
