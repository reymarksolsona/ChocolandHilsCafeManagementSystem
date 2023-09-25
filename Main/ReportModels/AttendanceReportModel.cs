using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.ReportModels
{
    public class AttendanceReportModel
    {
        private EmployeeModel employee;

        public EmployeeModel Employee
        {
            get { return employee; }
            set { employee = value; }
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


        private List<HolidayModel> holidays;

        public List<HolidayModel> Holidays
        {
            get { return holidays; }
            set { holidays = value; }
        }

        private List<EmployeeLeaveModel> employeeLeaves;

        public List<EmployeeLeaveModel> EmployeeLeaves
        {
            get { return employeeLeaves; }
            set { employeeLeaves = value; }
        }

        private List<EmployeeAttendanceModel> attendance;

        public List<EmployeeAttendanceModel> Attendance
        {
            get { return attendance; }
            set { attendance = value; }
        }

    }
}
