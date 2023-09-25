using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.UserManagement
{
    [Table("UserRoles")]
    public class UserRoleModel : BaseLongModel
    {
        private long userId;

        public long UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private long roleId;

        public long RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }


        private RoleModel role;

        [Write(false)]
        [Computed]
        public RoleModel Role
        {
            get { return role; }
            set { role = value; }
        }
    }
}
