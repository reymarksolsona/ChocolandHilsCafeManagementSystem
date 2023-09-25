using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeShifts")]
    public class EmployeeShiftModel : BaseLongModel
    {
        private string shift;

        public string Shift
        {
            get { return shift; }
            set { shift = value; }
        }

        // create new class that will inherit this class

        private DateTime startTime;

        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }


        private DateTime endTime;

        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        private decimal numberOfHrs;

        public decimal NumberOfHrs
        {
            get { return numberOfHrs; }
            set { numberOfHrs = value; }
        }

        private DateTime breakTime;

        public DateTime BreakTime
        {
            get { return breakTime; }
            set { breakTime = value; }
        }


        private decimal breakTimeHrs;

        public decimal BreakTimeHrs
        {
            get { return breakTimeHrs; }
            set { breakTimeHrs = value; }
        }


        private DateTime earlyTimeOut;

        public DateTime EarlyTimeOut
        {
            get { return earlyTimeOut; }
            set { earlyTimeOut = value; }
        }

        private DateTime lateTimeIn;

        public DateTime LateTimeIn
        {
            get { return lateTimeIn; }
            set { lateTimeIn = value; }
        }


        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }


        private List<EmployeeShiftDayModel> shiftDays;

        [Write(false)]
        [Computed]
        public List<EmployeeShiftDayModel> ShiftDays
        {
            get { return shiftDays; }
            set { shiftDays = value; }
        }

    }
}
