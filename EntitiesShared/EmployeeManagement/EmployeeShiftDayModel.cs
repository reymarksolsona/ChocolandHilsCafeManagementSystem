using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeeShiftDays")]
    public class EmployeeShiftDayModel : BaseLongModel
    {
        private long shiftId;

        public long ShiftId
        {
            get { return shiftId; }
            set { shiftId = value; }
        }

        private string dayName;

        public string DayName
        {
            get { return dayName; }
            set { dayName = value; }
        }

        private int orderNum;

        public int OrderNum
        {
            get { return orderNum; }
            set { orderNum = value; }
        }



        // below properties is used as flag on WorkShiftCRUDControl
        // to mark the day if need to update (if the user needs to delete)
        // or add new on existing list
        [Write(false)]
        [Computed]
        public bool IsNeedToUpdate { get; set; } = false;


        [Write(false)]
        [Computed]
        public bool IsNeedToAdd { get; set; } = false;

    }
}
