using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement.Models
{
    public class ProductIngredientInventoryDeduction
    {
        public int DeductionSequence { get; set; }

        public long IngredientId { get; set; }

        public long IngredientInventoryid { get; set; }

        public decimal DeductQtyValue { get; set; }

        public StaticData.UOM UsedUOM { get; set; }

        public decimal Cost { get; set; }
    }
}
