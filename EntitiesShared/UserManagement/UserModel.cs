using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.UserManagement
{
    [Table("Users")]
    public class UserModel : BaseLongModel
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string PasswordSha512 { get; set; }

        [Write(false)]
        [Computed]
        public UserRoleModel Role { get; set; }

        public bool IsActive { get; set; }
    }
}
