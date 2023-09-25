using EntitiesShared.EmployeeManagement;
using EntitiesShared.EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFReportGenerators
{
    public interface IAttendancePDFReport
    {
        void GenerateAttendanceReportPDF(Dictionary<DateTime, AttendanceRecord> attendanceToDisplay, EmployeeModel employee);
    }
}
