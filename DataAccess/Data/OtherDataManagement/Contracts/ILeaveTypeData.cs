using DapperGenericDataManager;
using EntitiesShared.EmployeeManagement;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.OtherDataManagement.Contracts
{
    public interface ILeaveTypeData : IDataManagerCRUD<LeaveTypeModel>
    {
        List<LeaveTypeModel> GetAllNotDeleted();
    }
}
