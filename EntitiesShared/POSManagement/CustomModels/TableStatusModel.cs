using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.POSManagement.CustomModels
{
    public class TableStatusModel
    {
        public long CurrentTransactionId { get; set; }

        public int TableNumber { get; set; }

        public string TableTitle { get; set; }

        public string CurrentCustomerName { get; set; }

        public StaticData.TableStatus Status { get; set; }
    }
}
