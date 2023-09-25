using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("SpecificEmployeeDeductions")]
    public class SpecificEmployeeDeductionModel : BaseLongModel
    {
        public string EmployeeNumber
        {
            get; set;
        }

        public string EmployeeName { get; set; }

        public string DeductionTitle
        {
            get; set;
        }


        public decimal Amount
        {
            get;set;
        }

        public bool IsDeducted { get; set; }

        public DateTime DeductedDate { get; set; }

        public long PayslipId { get; set; }
    }
}
