using EntitiesShared.InventoryManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.ControllerInterface
{
    public interface IComboMealController
    {
        EntityResult<string> Delete(long ingredientId);
        void SaveComboMealImageFileName(long comboMealId, string fileName);
        EntityResult<ComboMealModel> Save(ComboMealModel comboMeal, List<ComboMealProductModel> products, bool isNew);
    }
}
