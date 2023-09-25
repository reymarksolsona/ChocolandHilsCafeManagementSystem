using DapperGenericDataManager;
using DataAccess.Data.UserManagement.Contracts;
using EntitiesShared.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntitiesShared.StaticData;

namespace DataAccess.Data.UserManagement.Implementations
{
    public class RoleData : DataManagerCRUD<RoleModel>, IRoleData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public RoleData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }


        public RoleModel GetByRolekey (UserRole roleKey)
        {
            string query = "SELECT * FROM Roles WHERE rolekey=@RoleKey";
            return this.GetFirstOrDefault(query, new { RoleKey = roleKey.ToString() });
        }
    }
}
