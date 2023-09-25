using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeData : IDataManagerCRUD<EmployeeModel>
    {
        List<EmployeeModel> GetByPosition(long positionId);
        List<EmployeeModel> GetAllNotDeleted();
        long GetCountByEmpNumYear(DateTime dateHire);
        EmployeeModel GetByEmployeeNumber(string employeeNumber);
        EmployeeModel GetByEmployeeMobileNumber(string mobileNum);
        EmployeeModel GetByEmployeeEmail(string email);
        List<EmployeeModel> GetAllByDateHire(DateTime dateHire);
        List<EmployeeModel> Search(string search);

        bool MoveEmployeesIntoNewShift(long previousShiftId, long newShiftId);
        bool MoveEmployeesIntoOtherBranch(long previousBranchId, long newBranchId);
        bool MoveEmployeesIntoOtherPosition(long previousPositionId, long newPositionId);
    }
}
