using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovContributionCalculators.Models
{
    public class SSSContributionTableRow
    {
        public decimal salaryStart { get; set; }

        public decimal salaryEnd { get; set; }

        public decimal monthlySalaryCredit { get; set; }

        public decimal totalContributionEmployer { get; set; }

        public decimal totalContributionEmployee { get; set; }

        public decimal totalContribution { get; set; }
    }
}
