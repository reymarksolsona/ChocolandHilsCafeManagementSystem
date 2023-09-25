using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeAttendance")]
    public class EmployeeAttendanceModel : BaseLongModel
    {
        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        private EmployeeModel employee;
        [Write(false)]
        [Computed]
        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }


        private long shiftId;

        public long ShiftId
        {
            get { return shiftId; }
            set { shiftId = value; }
        }

        private EmployeeShiftModel shift;
        [Write(false)]
        [Computed]
        public EmployeeShiftModel Shift
        {
            get { return shift; }
            set { shift = value; }
        }


        private DateTime workDate;

        public DateTime WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }

        private DateTime firstTimeIn;

        public DateTime FirstTimeIn
        {
            get { return firstTimeIn; }
            set { firstTimeIn = value; }
        }

        private DateTime firstTimeOut;

        public DateTime FirstTimeOut
        {
            get { return firstTimeOut; }
            set { firstTimeOut = value; }
        }

        private decimal firstHalfHrs;

        public decimal FirstHalfHrs
        {
            get { return firstHalfHrs; }
            set { firstHalfHrs = value; }
        }

        private decimal firstHalfLateMins;

        public decimal FirstHalfLateMins
        {
            get { return firstHalfLateMins; }
            set { firstHalfLateMins = value; }
        }

        private decimal firstHalfUnderTimeMins;

        public decimal FirstHalfUnderTimeMins
        {
            get { return firstHalfUnderTimeMins; }
            set { firstHalfUnderTimeMins = value; }
        }



        private DateTime secondTimeIn;

        public DateTime SecondTimeIn
        {
            get { return secondTimeIn; }
            set { secondTimeIn = value; }
        }

        private DateTime secondTimeOut;

        public DateTime SecondTimeOut
        {
            get { return secondTimeOut; }
            set { secondTimeOut = value; }
        }

        private decimal secondHalfHrs;

        public decimal SecondHalfHrs
        {
            get { return secondHalfHrs; }
            set { secondHalfHrs = value; }
        }


        private decimal secondHalfLateMins;

        public decimal SecondHalfLateMins
        {
            get { return secondHalfLateMins; }
            set { secondHalfLateMins = value; }
        }

        private decimal secondHalfUnderTimeMins;

        public decimal SecondHalfUnderTimeMins
        {
            get { return secondHalfUnderTimeMins; }
            set { secondHalfUnderTimeMins = value; }
        }

        private decimal overTimeMins;

        public decimal OverTimeMins
        {
            get { return overTimeMins; }
            set { overTimeMins = value; }
        }

        [Write(false)]
        [Computed]
        public decimal TotalHrs { // in minutes
            get
            {
                return this.FirstHalfHrs + this.SecondHalfHrs;
            }
        }

        [Write(false)]
        [Computed]
        public decimal TotalLate
        {
            get
            {
                return this.FirstHalfLateMins + this.SecondHalfLateMins;
            }
        }

        [Write(false)]
        [Computed]
        public decimal TotalUnderTime
        {
            get
            {
                return this.FirstHalfUnderTimeMins + this.SecondHalfUnderTimeMins;
            }
        }

        private bool isTimeOutProvided;

        public bool IsTimeOutProvided
        {
            get { return isTimeOutProvided; }
            set { isTimeOutProvided = value; }
        }

        private decimal lateTotalDeduction;

        public decimal LateTotalDeduction
        {
            get { return lateTotalDeduction; }
            set { lateTotalDeduction = value; }
        }

        private decimal underTimeTotalDeduction;

        public decimal UnderTimeTotalDeduction
        {
            get { return underTimeTotalDeduction; }
            set { underTimeTotalDeduction = value; }
        }

        private decimal overTimeTotal;

        public decimal OverTimeTotal
        {
            get { return overTimeTotal; }
            set { overTimeTotal = value; }
        }


        private decimal totalDailySalary;

        public decimal TotalDailySalary
        {
            get { return totalDailySalary; }
            set { totalDailySalary = value; }
        }


        private bool isPaid;

        public bool IsPaid
        {
            get { return isPaid; }
            set { isPaid = value; }
        }

        private long payslipId;

        public long PayslipId
        {
            get { return payslipId; }
            set { payslipId = value; }
        }

        public bool IsUserDayOffToday { get; set; }

        public bool IsHolidayToday { get; set; }

        public long HolidayId { get; set; }

        public decimal OvertimeHrlyRate { get; set; }

        public decimal OvertimeDailySalaryAdjustment { get; set; }

        public StaticData.OverTimeTypes OverTimeType { get; set; }

    }
}
