using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.EmployeeManagement.Models
{
    public class WorkforceScheduling
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private Dictionary<DateTime, List<EmployeeModel>> workForceByDate;

        public Dictionary<DateTime, List<EmployeeModel>> WorkForceByDate
        {
            get { return workForceByDate; }
            set { workForceByDate = value; }
        }

        // Stored in our database
        // we need to add reference to it
        // so we can easily mark as delete when the admin edit the workforce schedule
        private List<WorkforceScheduleModel> workforceSchedules;

        public List<WorkforceScheduleModel> WorkforceSchedules
        {
            get { return workforceSchedules; }
            set { workforceSchedules = value; }
        }
    }
}
