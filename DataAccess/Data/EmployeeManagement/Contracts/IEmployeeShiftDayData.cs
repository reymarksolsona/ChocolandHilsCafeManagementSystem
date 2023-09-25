using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Contracts
{
    public interface IEmployeeShiftDayData : IDataManagerCRUD<EmployeeShiftDayModel>
    {
        List<EmployeeShiftDayModel> GetByShiftId(long shiftId);
    }
}
