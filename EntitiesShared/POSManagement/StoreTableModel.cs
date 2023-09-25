using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.POSManagement
{
    [Table("StoreTables")]
    public class StoreTableModel : BaseLongModel
    {
        public decimal NumberOfTables { get; set; }
    }
}
