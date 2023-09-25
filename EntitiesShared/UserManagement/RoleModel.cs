using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntitiesShared.StaticData;

namespace EntitiesShared.UserManagement
{
    [Table("Roles")]
    public class RoleModel : BaseLongModel
    {
        public UserRole RoleKey { get; set; }
    }
}
