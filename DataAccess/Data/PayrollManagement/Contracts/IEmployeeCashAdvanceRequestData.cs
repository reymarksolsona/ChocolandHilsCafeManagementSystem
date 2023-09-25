using DapperGenericDataManager;
using EntitiesShared;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.PayrollManagement.Contracts
{
    public interface IEmployeeCashAdvanceRequestData : IDataManagerCRUD<EmployeeCashAdvanceRequestModel>
    {
        List<EmployeeCashAdvanceRequestModel> GetAllNotDeleted();
        List<EmployeeCashAdvanceRequestModel> GetAllNotDeletedByEmployee(string employeeNumber);
        List<EmployeeCashAdvanceRequestModel> GetAllNotDeletedByStatus(StaticData.EmployeeRequestApprovalStatus status);
        List<EmployeeCashAdvanceRequestModel> GetAllByCashReleaseDateRange(DateTime startDate, DateTime endDate);
    }
}
