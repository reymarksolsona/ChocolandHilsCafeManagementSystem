using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovContributionCalculators.Models
{
    public class SharedContributionRate
    {
        /// <summary>
        /// Employee contribution rate
        /// </summary>
        public decimal EE { get; set; }

        /// <summary>
        /// Employer contribution rate
        /// </summary>
        public decimal ER { get; set; }
    }
}
