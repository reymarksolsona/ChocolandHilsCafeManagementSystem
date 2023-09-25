using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntitiesShared.StaticData;

namespace EntitiesShared.EmployeeManagement.Models
{
    public class AttendanceRecord
    {
        public DateTime WorkDate { get; set; }

        public string[] record { get; set; }

        public AttendanceRecordType recordType { get; set; }
    }
}
