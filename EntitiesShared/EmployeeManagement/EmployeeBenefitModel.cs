using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeBenefits")]
    public class EmployeeBenefitModel : BaseLongModel
    {
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
    }
}
