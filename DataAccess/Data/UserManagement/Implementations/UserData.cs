using DapperGenericDataManager;
using DataAccess.Data.UserManagement.Contracts;
using EntitiesShared.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.UserManagement.Implementations
{
    public class UserData : DataManagerCRUD<UserModel>, IUserData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public UserData(IDbConnectionFactory dbConnFactory) : 
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<UserModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM Users WHERE isDeleted=False";

            return this.GetAll(query);
        }

        public List<UserModel> Search(string searchStr)
        {
            string query = @"SELECT * FROM Users 
                            WHERE isDeleted=False AND 
                                    (userName LIKE @SearchStr OR fullName LIKE @SearchStr)";

            return this.GetAll(query, new { SearchStr = $"%{searchStr}%" });
        }

        public UserModel GetUserByUserName(string userName)
        {
            string query = @"SELECT * FROM Users 
                            WHERE isDeleted=False AND userName=@UserName";

            return this.GetFirstOrDefault(query, new { UserName = userName });
        }
    }
}
