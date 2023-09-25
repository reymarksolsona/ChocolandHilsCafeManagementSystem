using Dapper.Contrib.Extensions;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeLeaves")]
    public class EmployeeLeaveModel : BaseLongModel
    {
        private long leaveId;

        public long LeaveId
        {
            get { return leaveId; }
            set { leaveId = value; }
        }

        public StaticData.LeaveDurationType DurationType { get; set; }

        [Write(false)]
        [Computed]
        public decimal Duration
        {
            get
            {
                if (this.DurationType == StaticData.LeaveDurationType.FullDay)
                {
                    return 1;
                }

                return 0.5m;
            }
        }

        private LeaveTypeModel leaveType;

        [Write(false)]
        [Computed]
        public LeaveTypeModel LeaveType
        {
            get { return leaveType; }
            set { leaveType = value; }
        }


        private string employeeNumber;

        public string EmployeeNumber
        {
            get { return employeeNumber; }
            set { employeeNumber = value; }
        }

        private string reason;

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }


        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public decimal NumberOfDays 
        {
            get
            {
                if (this.StartDate == DateTime.MinValue && this.EndDate == DateTime.MinValue)
                {
                    return 0;
                }

                if (this.StartDate.Date == this.EndDate.Date)
                {
                    return 1;
                }

                TimeSpan timeSpan = this.EndDate.Subtract(this.StartDate);

                return timeSpan.Days;
            }
        }


        private decimal remainingDays;

        public decimal RemainingDays
        {
            get { return remainingDays; }
            set { remainingDays = value; }
        }


        private int currentYear;

        public int CurrentYear
        {
            get { return currentYear; }
            set { currentYear = value; }
        }

        public bool IsPaid { get; set; }


        private long payslipId;

        public long PayslipId
        {
            get { return payslipId; }
            set { payslipId = value; }
        }


        public StaticData.EmployeeRequestApprovalStatus ApprovalStatus { get; set; }

        public string EmployerRemarks { get; set; }
    }
}
