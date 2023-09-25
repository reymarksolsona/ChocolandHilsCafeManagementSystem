using EntitiesShared.InventoryManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.ControllerInterface
{
    public interface IIngredientController
    {
        EntityResult<string> Delete(long ingredientId);
        EntityResult<IngredientModel> Save(IngredientModel input, bool isNew);
    }
}
