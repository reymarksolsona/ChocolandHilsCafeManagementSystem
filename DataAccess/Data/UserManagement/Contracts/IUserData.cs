using DapperGenericDataManager;
using EntitiesShared.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.UserManagement.Contracts
{
    public interface IUserData : IDataManagerCRUD<UserModel>
    {
        List<UserModel> GetAllNotDeleted();
        List<UserModel> Search(string searchStr);
        UserModel GetUserByUserName(string userName);
    }
}
