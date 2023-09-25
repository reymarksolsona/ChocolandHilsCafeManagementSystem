using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovContributionCalculators.Models
{
    public class PHICFirstFixedRate
    {
        public decimal EqualAndBelowTo { get; set; }
        public SharedContributionRate Rate { get; set; }
    }

    public class PHICSecondFixedRate
    {
        public decimal EqualOrAboveTo { get; set; }
        public SharedContributionRate Rate { get; set; }
    }

    public class PhilHealthContributionSettings
    {
        public PHICFirstFixedRate FirstFixedRate { get; set; }

        public decimal PercentageForInBetween { get; set; }

        public PHICSecondFixedRate SecondFixedRate { get; set; }
    }
}
