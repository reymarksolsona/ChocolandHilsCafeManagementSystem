using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("SpecificEmployeeBenefits")]
    public class SpecificEmployeeBenefitModel : BaseLongModel
    {
        public string EmployeeNumber
        {
            get;set;
        }

        public string EmployeeName { get; set; }

        public string BenefitTitle
        {
            get;set;
        }

        public decimal Amount
        {
            get;set;
        }

        public bool IsPaid { get; set; }

        public DateTime PaymentDate { get; set; }
        public long PayslipId { get; set; }
    }
}
