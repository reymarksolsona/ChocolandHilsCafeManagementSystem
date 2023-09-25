using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("ComboMealProducts")]
    public class ComboMealProductModel : BaseLongModel
    {
        public long ComboMealId { get; set; }

        public long ProductId { get; set; }

        private ProductModel product;
        [Write(false)]
        [Computed]
        public ProductModel Product
        {
            get { return product; }
            set { product = value; }
        }

        public int Quantity { get; set; }
    }
}
