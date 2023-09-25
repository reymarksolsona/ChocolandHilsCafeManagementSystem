using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface ISpecificEmployeeDeductionData : IDataManagerCRUD<SpecificEmployeeDeductionModel>
    {
        List<SpecificEmployeeDeductionModel> GetAllPending();
        List<SpecificEmployeeDeductionModel> GetAllByEmployeeAndSubmissionDateRange(string employeeNumber, DateTime startDate, DateTime endDate);
        List<SpecificEmployeeDeductionModel> GetAllByEmployeeAndPayslipId(string employeeNumber, long payslipId);
    }
}
