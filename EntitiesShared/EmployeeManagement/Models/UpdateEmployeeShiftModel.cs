using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement.Models
{
    public class UpdateEmployeeShiftModel
    {
        public long ShiftId { get; set; }

        private List<string> employeeNumbers = new List<string>();

        public List<string> EmployeeNumbers
        {
            get { return employeeNumbers; }
            set { employeeNumbers = value; }
        }

    }
}
