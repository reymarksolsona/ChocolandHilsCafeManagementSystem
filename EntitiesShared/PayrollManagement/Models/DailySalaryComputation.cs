using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.PayrollManagement.Models
{
    public class DailySalaryComputation
    {
        public decimal LateTotalDeduction { get; set; }

        public decimal UnderTimeTotalDeduction { get; set; }

        public decimal OverTimeTotal { get; set; }

        public decimal TotalDailySalary { get; set; }

        public bool IsUserDayOffToday { get; set; }

        public bool IsHolidayToday { get; set; }

        public long HolidayId { get; set; }

        public decimal OvertimeHrlyRate { get; set; }

        public decimal OvertimeDailySalaryAdjustment { get; set; }

        public StaticData.OverTimeTypes OverTimeType { get; set; }
    }
}
