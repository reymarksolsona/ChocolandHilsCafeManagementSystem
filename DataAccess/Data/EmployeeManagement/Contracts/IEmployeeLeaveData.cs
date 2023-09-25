using DapperGenericDataManager;
using EntitiesShared;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeLeaveData : IDataManagerCRUD<EmployeeLeaveModel>
    {
        List<EmployeeLeaveModel> GetAllByEmployeeNumberAndYear(string employeeNumber, int year);
        List<EmployeeLeaveModel> GetAllByEmployeeNumberAndLeaveId(string employeeNumber, long leaveId, int year);
        List<EmployeeLeaveModel> GetAllByStatus(StaticData.EmployeeRequestApprovalStatus status);
        List<EmployeeLeaveModel> GetAllByEmpAndStatus(string employeeNumber, StaticData.EmployeeRequestApprovalStatus status);
        //List<EmployeeLeaveModel> GetAllByEmployeeNumberAndDateRange(string employeeNumber, int year, DateTime startDate, DateTime endDate);
        List<EmployeeLeaveModel> GetAllByDateRange(int year, DateTime startDate, DateTime endDate);
        List<EmployeeLeaveModel> GetAllUnpaidByDateRange(int year, DateTime startDate, DateTime endDate);
        List<EmployeeLeaveModel> GetEmployeeLeavesByPayslipId(string employeeNumber, long payslipId);
    }
}
