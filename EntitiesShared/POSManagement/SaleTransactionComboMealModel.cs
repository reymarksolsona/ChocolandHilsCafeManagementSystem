using Dapper.Contrib.Extensions;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.POSManagement
{
    [Table("SalesTransactionComboMeals")]
    public class SaleTransactionComboMealModel : BaseLongModel
    {
        public long SalesTransId { get; set; }

        public long ComboMealId { get; set; }

        public decimal ComboMealCurrentPrice { get; set; }

        public int Qty { get; set; }

        public decimal totalAmount { get; set; }


        private ComboMealModel _comboMeal;
        [Write(false)]
        [Computed]
        public ComboMealModel ComboMeal
        {
            get { return _comboMeal; }
            set { _comboMeal = value; }
        }
    }
}
