using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement.Models
{
    public class IngredientBreakDownForSalesReportModel
    {
        public long Id { get; set; }
        public string IngName { get; set; }

        public StaticData.UOM UOM { get; set; }

        public decimal RemainingQtyValue { get; set; }

        public string Category { get; set; }

        public decimal TotalDeductedQtyValue { get; set; }

    }
}
