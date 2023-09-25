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
    public class PagIbigContributionCalculator
    {
        public PagIbigContributionSettings GetContributionTable(string govContributionTablesPath)
        {
            string fullTablePath = $"{govContributionTablesPath}PagIbigContributionTable.json";

            if (File.Exists(fullTablePath) == false)
            {
                return null;
            }

            var jsonString = File.ReadAllText(fullTablePath);
            var pagIbigContributionTable = JsonSerializer.Deserialize<PagIbigContributionSettings>(jsonString);

            return pagIbigContributionTable;
        }

        public SharedContributionRate GetMonthlyContribution (PagIbigContributionSettings pagIbigContributionSettings, decimal monthSalary)
        {
            if (pagIbigContributionSettings == null)
                return null;

            if (monthSalary > 0 && monthSalary <= pagIbigContributionSettings.FirstFixedRate.EqualAndBelowTo)
            {
                var EEContPercentage = pagIbigContributionSettings.FirstFixedRate.Rate.EE / 100;
                var ERContPercentage = pagIbigContributionSettings.FirstFixedRate.Rate.ER / 100;

                decimal eeContTotal = monthSalary * EEContPercentage;
                decimal erContTotal = monthSalary * ERContPercentage;

                // fixed rate
                return new SharedContributionRate
                {
                    ER = erContTotal,
                    EE = eeContTotal
                };
            }

            if (monthSalary > 0 && monthSalary >= pagIbigContributionSettings.SecondFixedRate.BetweenTo.Min)
            {
                if (monthSalary > pagIbigContributionSettings.SecondFixedRate.BetweenTo.Max){
                    monthSalary = pagIbigContributionSettings.SecondFixedRate.BetweenTo.Max;
                }

                var EEContPercentage = pagIbigContributionSettings.SecondFixedRate.Rate.EE / 100;
                var ERContPercentage = pagIbigContributionSettings.SecondFixedRate.Rate.ER / 100;

                decimal eeContTotal = monthSalary * EEContPercentage;
                decimal erContTotal = monthSalary * ERContPercentage;

                // fixed rate
                return new SharedContributionRate
                {
                    ER = erContTotal,
                    EE = eeContTotal
                };
            }

            return new SharedContributionRate
            {
                ER = 0,
                EE = 0
            };
        }
    }
}
