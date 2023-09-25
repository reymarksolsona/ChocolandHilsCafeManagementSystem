using EntitiesShared;
using EntitiesShared.InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers
{
    public interface IIngredientInventoryManager
    {
        decimal GetActualCostByIngredientQtyValueAndUnitCost(StaticData.UOM uom, decimal ingredientUnitCost);
        decimal GetProductIngredientCost(long ingredientId, decimal prodIngredientQtyValue, StaticData.UOM prodIngredientUOM);
        Tuple<StaticData.UOM, decimal> GetProperQtyValAndUOM(StaticData.UOM uom, decimal qtyValue);


        decimal GetProductIngredientActualQtyValueNeedToDeduct(StaticData.UOM uom, decimal qtyValue);
        List<ProductIngredientInventoryDeduction> GetWhereInventoryThisProductIngredientToDeduct(long ingredientId, decimal prodIngredientRequireQtyValue, StaticData.UOM prodIngredientRequireUOM);

        string CheckIfEnoughInventory(long ingredientId, decimal prodIngredientRequireQtyValue, StaticData.UOM prodIngredientRequireUOM);
    }
}
