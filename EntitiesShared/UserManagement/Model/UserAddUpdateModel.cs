using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntitiesShared.StaticData;

namespace EntitiesShared.UserManagement.Model
{
    public class UserAddUpdateModel
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public UserRole Role { get; set; }
    }
}
