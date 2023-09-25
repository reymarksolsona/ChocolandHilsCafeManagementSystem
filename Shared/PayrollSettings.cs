using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PayrollSettings
    {
        public int FirstPayDayOfTheMonth { get; set; }

        public int SecondPayDayOfTheMonth { get; set; }

        public string GeneratedPDFLoc { get; set; }

        public decimal SaleAmoutForADayToGetSpecialBonus { get; set; }

        public decimal EmployeeBonusFromSaleSpecialBonus { get; set; }

        public string GovernmentContributionTablesPath { get; set; }
    }
}
