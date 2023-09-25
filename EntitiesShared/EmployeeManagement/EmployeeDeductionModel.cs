using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeDeductions")]
    public class EmployeeDeductionModel : BaseLongModel
    {
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
    }
}
