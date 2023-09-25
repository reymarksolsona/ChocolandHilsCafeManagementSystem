using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.OtherDataManagement
{
    [Table("LeaveTypes")]
    public class LeaveTypeModel : BaseLongModel
    {
        private string leaveType;

        public string LeaveType
        {
            get { return leaveType; }
            set { leaveType = value; }
        }


        private int numberOfDays;

        public int NumberOfDays
        {
            get { return numberOfDays; }
            set { numberOfDays = value; }
        }


        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }
}
