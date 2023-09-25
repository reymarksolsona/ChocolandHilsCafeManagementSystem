using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("IngredientInventory")]
    public class IngredientInventoryModel : BaseLongModel
    {
        public long IngredientId { get; set; }

        private IngredientModel _ingredient;
        [Write(false)]
        [Computed]
        public IngredientModel Ingredient
        {
            get { return _ingredient; }
            set { _ingredient = value; }
        }


        public decimal InitialQtyValue { get; set; }

        public decimal RemainingQtyValue { get; set; }

        public decimal UnitCost { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsSoldOut { get; set; }
    }
}
