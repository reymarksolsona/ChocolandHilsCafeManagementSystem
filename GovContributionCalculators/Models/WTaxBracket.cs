using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovContributionCalculators.Models
{
    public class WTaxBracket
    {
        public decimal CompensationMinLevel { get; set; }
        public decimal CompensationMaxLevel { get; set; }
        public decimal Percentage { get; set; }
        public decimal FixedTax { get; set; }
    }
}
