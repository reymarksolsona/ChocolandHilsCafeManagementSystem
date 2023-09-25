using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.OtherDataManagement
{
    [Table("NumberOfWorkingDaysInMonth")]
    public class NumberOfWorkingDaysInAMonthModel
    {
        [Key]
        public int Id { get; set; }

        public decimal NumberOfDays { get; set; }
    }
}
