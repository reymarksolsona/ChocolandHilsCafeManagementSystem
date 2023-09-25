using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.POSManagement
{
    [Table("SaleTranProdIngInvDeductionsRecords")]
    public class SaleTranProdIngInvDeductionsRecordModel : BaseLongModel
    {
        public long SaleTransProductId { get; set; }

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
