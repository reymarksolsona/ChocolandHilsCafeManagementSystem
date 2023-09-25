using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.POSManagement
{
    [Table("CashRegisterCashOutTransactions")]
    public class CashRegisterCashOutTransactionModel : BaseLongModel
    {
        public decimal TotalSales { get; set; }

        public decimal CashOut { get; set; }

        public decimal RemainingCash { get; set; }

        public string CurrentUser { get; set; }
    }
}
