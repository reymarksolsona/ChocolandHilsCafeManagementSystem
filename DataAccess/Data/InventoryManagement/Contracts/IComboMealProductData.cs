using DapperGenericDataManager;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Contracts
{
    public interface IComboMealProductData : IDataManagerCRUD<ComboMealProductModel>
    {
        List<ComboMealProductModel> GetAllByComboMealPlain(long comboMealId);
        List<ComboMealProductModel> GetAllByComboMeal(long comboMealId);
    }
}
