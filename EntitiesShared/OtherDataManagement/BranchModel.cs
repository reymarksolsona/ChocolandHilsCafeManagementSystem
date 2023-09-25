using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.OtherDataManagement
{
    [Table("Branches")]
    public class BranchModel : BaseLongModel
    {
        public string BranchName { get; set; }
        public string TellNo { get; set; }

        public string Address { get; set; }
    }
}
