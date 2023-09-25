using Dapper.Contrib.Extensions;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.POSManagement
{
    [Table("SalesTransactionProducts")]
    public class SaleTransactionProductModel : BaseLongModel
    {
        public long SalesTransId { get; set; }

        public long ProductId { get; set; }

        public decimal productCurrentPrice { get; set; }

        public int Qty { get; set; }

        public decimal totalAmount { get; set; }

        private ProductModel _product;
        [Write(false)]
        [Computed]
        public ProductModel Product
        {
            get { return _product; }
            set { _product = value; }
        }

    }
}
