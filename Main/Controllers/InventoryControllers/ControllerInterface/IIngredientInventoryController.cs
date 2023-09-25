using EntitiesShared.InventoryManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.ControllerInterface
{
    public interface IIngredientInventoryController
    {
        EntityResult<string> Delete(long ingredeintId, long inventoryId, string remarks);
        EntityResult<IngredientInventoryModel> Save(IngredientInventoryModel input, bool isNew, string remarks);
        EntityResult<IngredientInventoryModel> IncreaseQtyValue(long ingredientId, long inventoryId, decimal qtyValue, string remarks);
        EntityResult<IngredientInventoryModel> DecreaseQtyValue(long ingredientId, long inventoryId, decimal qtyValue, string remarks);
    }
}
