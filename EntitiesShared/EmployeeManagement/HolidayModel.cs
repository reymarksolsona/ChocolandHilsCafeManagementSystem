using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("Holidays")]
    public class HolidayModel : BaseLongModel
    {
        private string holiday;

        public string Holiday
        {
            get { return holiday; }
            set { holiday = value; }
        }


        private int dayNum;

        public int DayNum
        {
            get { return dayNum; }
            set { dayNum = value; }
        }

        private string monthAbbr;

        public string MonthAbbr
        {
            get { return monthAbbr; }
            set { monthAbbr = value; }
        }

        public int MonthNum { get; set; }

        public StaticData.HolidayTypes HolidayType { get; set; }

    }
}
