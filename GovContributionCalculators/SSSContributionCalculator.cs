using GovContributionCalculators.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GovContributionCalculators.GovContributionCalculator
{
    public class SSSContributionCalculator
    {
        public List<SSSContributionTableRow> GetContributionTable(string govContributionTablesPath)
        {
            string latestTableFileName = $"{DateTime.Now.Year}.json";

            string fullTablePath = $"{govContributionTablesPath}SSS\\{latestTableFileName}";

            if (File.Exists(fullTablePath) == false)
            {
                fullTablePath = $"{govContributionTablesPath}Default.json";
            }

            var jsonString = File.ReadAllText(fullTablePath);
            var sssContributionTable = JsonSerializer.Deserialize<List<SSSContributionTableRow>>(jsonString);

            return sssContributionTable;
        }

        public SharedContributionRate GetEEandERSharedContribution (List<SSSContributionTableRow> SSSContributionTables, decimal employeeMonthlySalary)
        {
            var contributionRow = SSSContributionTables.Where(x => x.salaryStart <= employeeMonthlySalary && x.salaryEnd >= employeeMonthlySalary).FirstOrDefault();

            if (contributionRow == null)
                return null;

            return new SharedContributionRate
            {
                ER = contributionRow.totalContributionEmployer,
                EE = contributionRow.totalContributionEmployee
            };
        }
    }
}
