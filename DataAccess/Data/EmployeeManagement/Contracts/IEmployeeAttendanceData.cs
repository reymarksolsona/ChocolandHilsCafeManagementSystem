using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeAttendanceData : IDataManagerCRUD<EmployeeAttendanceModel>
    {
        List<EmployeeAttendanceModel> GetAllAttendanceRecordByWorkDate(DateTime workDate);
        List<EmployeeAttendanceModel> GetAllAttendanceRecordByWorkDateRange(string employeeNumber, DateTime startDate, DateTime endDate);
        List<EmployeeAttendanceModel> GetAllUnpaidAttendanceRecordByWorkDateRange(string employeeNumber, DateTime startDate, DateTime endDate);

        List<EmployeeAttendanceModel> GetAllAttendanceRecordByWorkDateRange(DateTime startDate, DateTime endDate);
        List<EmployeeAttendanceModel> GetAllUnpaidAttendanceRecordByWorkDateRange(DateTime startDate, DateTime endDate);
        EmployeeAttendanceModel GetEmployeeAttendanceByWorkDate(string employeeNumber, DateTime workDate);
        List<EmployeeAttendanceModel> GetEmployeeAttendanceByPayslipId(string employeeNumber, long payslipId);
    }
}
