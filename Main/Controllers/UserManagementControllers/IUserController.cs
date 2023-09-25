using EntitiesShared.UserManagement;
using EntitiesShared.UserManagement.Model;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.UserManagementControllers
{
    public interface IUserController
    {
        EntityResult<UserModel> SignIn(string username, string password);

        EntityResult<UserModel> Save(UserAddUpdateModel input, bool isNew);
        EntityResult<string> Delete(long userId);

        ListOfEntityResult<UserModel> Search(string searchStr);

        EntityResult<UserModel> GetById(long userId);
        EntityResult<UserModel> GetByUsername(string userName);
        ListOfEntityResult<UserModel> GetAll();
        List<RoleModel> GetAllRoles();
    }
}
