using DapperGenericDataManager;
using DataAccess.Data.UserManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EntitiesShared.UserManagement;

namespace DataAccess.Data.UserManagement.Implementations
{
    public class UserRoleData : DataManagerCRUD<UserRoleModel>, IUserRoleData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public UserRoleData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public UserRoleModel GetUserRole(long userId)
        {
            string query = @"SELECT *
                            FROM UserRoles AS UR
                            JOIN Roles AS R ON R.id = UR.roleId
                            WHERE UR.isDeleted=False AND UR.userId=@UserId
                            ORDER BY UR.id DESC LIMIT 1";

            UserRoleModel results = new UserRoleModel();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<UserRoleModel, RoleModel, UserRoleModel>(query,
                        (UR, R) => {
                            UR.Role = R;
                            return UR;
                        }, 
                        new { UserId = userId }).ToList().FirstOrDefault();
                conn.Close();
            }

            return results;
        }
    }
}
