using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.POSManagement
{
    [Table("SalesTransactions")]
    public class SaleTransactionModel : BaseLongModel
    {
        public StaticData.POSTransactionType TransactionType { get; set; }

        public string TicketNumber { get;set; }

        public int TakeOutNumber { get; set; }

        [Write(false)]
        [Computed]
        public string TakeOutNumberStr {
            get
            {
                return this.TakeOutNumber.ToString().PadLeft(4, '0');
            }
        }

        public string CurrentUser { get; set; }

        public string CustomerName { get; set; }

        public decimal SubTotalAmount { get; set; }

        public decimal DiscountAmount { get; set; }

        public bool DiscountIsPercentage { get; set; }

        public decimal DiscountPercent { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal CustomerCashAmount { get; set; }

        public decimal CustomerChangeAmount { get; set; }

        public decimal CustomerDueAmount { get; set; }

        public int TableNumber { get; set; }

        [Write(false)]
        [Computed]
        public string TableNumberStr
        {
            get
            {
                return $"T-{this.TableNumber}";
            }
        }

        public StaticData.POSTransactionStatus TransStatus { get; set; }

        public bool IsCashOut { get; set; }

        public bool IsCustomerDone { get; set; }
    }
}
