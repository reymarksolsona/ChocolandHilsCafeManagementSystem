using DapperGenericDataManager;
using EntitiesShared.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntitiesShared.StaticData;

namespace DataAccess.Data.UserManagement.Contracts
{
    public interface IRoleData : IDataManagerCRUD<RoleModel>
    {
        RoleModel GetByRolekey(UserRole roleKey);
    }
}
