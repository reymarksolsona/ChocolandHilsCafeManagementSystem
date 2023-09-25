using DapperGenericDataManager;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.PayrollManagement.Contracts
{
    public interface IEmployeePayslipDeductionData : IDataManagerCRUD<EmployeePayslipDeductionModel>
    {
        List<EmployeePayslipDeductionModel> GetAllByPayslipId(long payslipId);
        List<EmployeePayslipDeductionModel> GetAllByPayslipIdAndEmployeeNumber(long payslipId, string employeeNumber);
    }
}
