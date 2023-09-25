using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovContributionCalculators.Models
{
    public class HDMFFirstFixedRate
    {
        public decimal EqualAndBelowTo { get; set; }
        public SharedContributionRate Rate { get; set; }
    }

    public class HDMFSecondFixedRate
    {
        public SharedBetweenAmount BetweenTo { get; set; }
        public SharedContributionRate Rate { get; set; }
    }

    public class PagIbigContributionSettings
    {
        public HDMFFirstFixedRate FirstFixedRate { get; set; }

        public HDMFSecondFixedRate SecondFixedRate { get; set; }
    }
}
