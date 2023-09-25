using DapperGenericDataManager;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.PayrollManagement.Contracts
{
    public interface IEmployeePayslipData : IDataManagerCRUD<EmployeePayslipModel>
    {
        List<EmployeePayslipModel> GetAllEmpPayslipByMonth(int monthNum);
        List<EmployeePayslipModel> GetAllEmpPayslipByPaydate(DateTime paydate);
        EmployeePayslipModel GetEmployeePayslipRecordByPaydate(string employeeNumber, DateTime paydate);
        List<DateTime> GetEmployeePayslipPaydatesList(string employeeNumber);

        List<DateTime> GetPayslipPaydatesList();
    }
}
