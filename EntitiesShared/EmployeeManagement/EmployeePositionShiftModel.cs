using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace EntitiesShared.EmployeeManagement
{
    [Table("EmployeePositionShift")]
    public class EmployeePositionShiftModel
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long PositionId { get; set; }
        public long ShiftId { get; set; }
        [Write(false)]
        [Computed]
        public string Position { get; set; }
        [Write(false)]
        [Computed]
        public string Shift { get; set; }
        [Write(false)]
        [Computed]
        public List<EmployeeShiftDayModel> WorkingDays { get; set; }
        [Write(false)]
        [Computed]
        public decimal DailyRate { get; set; }
    }
}
