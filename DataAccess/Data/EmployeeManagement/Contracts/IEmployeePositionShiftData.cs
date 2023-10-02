using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using System.Collections.Generic;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeePositionShiftData : IDataManagerCRUD<EmployeePositionShiftModel>
    {
        List<EmployeePositionShiftModel> GetById(long id);
        void SavePositionsAndShifts(List<EmployeePositionShiftModel> positionShift);
        bool DeleteById(long id);
    }
}
