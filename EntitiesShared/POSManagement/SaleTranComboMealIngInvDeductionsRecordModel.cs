using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.POSManagement
{
    [Table("SaleTranComboMealIngInvDeductionsRecords")]
    public class SaleTranComboMealIngInvDeductionsRecordModel : BaseLongModel
    {
        public long SaleTransComboMealId { get; set; }

        public long ProductId { get; set; }

        public long IngredientId { get; set; }

        public long IngredientInventoryId { get; set; }

        public StaticData.UOM IngredientUOM { get; set; }

        public int DeductionSequence { get; set; }

        public StaticData.UOM UsedUOM { get; set; }

        public decimal DeductedQtyValue { get; set; }

        public decimal IngInvCurrentUnitCost { get; set; }

        public decimal TotalCost { get; set; }
    }
}
