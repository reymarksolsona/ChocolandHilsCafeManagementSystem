using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement
{
    [Table("WorkforceSchedules")]
    public class WorkforceScheduleModel : BaseLongModel
    {
        public string EmployeeNumber { get; set; }

        private EmployeeModel employee;


        [Write(false)]
        [Computed]
        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
        }


        public DateTime WorkDate { get; set; }

        public bool isDone { get; set; }
    }
}
