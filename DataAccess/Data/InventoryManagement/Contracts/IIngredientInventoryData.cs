using DapperGenericDataManager;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Contracts
{
    public interface IIngredientInventoryData : IDataManagerCRUD<IngredientInventoryModel>
    {
        decimal GetRemainingQtyValueByIngredient(long ingredientId);
        List<IngredientInventoryModel> GetAllByIngredient(long ingredientId);
        IngredientInventoryModel GetByIdAndIngredient(long ingredientId, long id);
        IngredientInventoryModel GetByIdAndIngredientIncludeDeletedAndSoldOut(long ingredientId, long id);
        List<IngredientInventoryModel> GetAllByExpirationDateRange(DateTime startDate, DateTime endDate);
        int GetCountOfIngredientInventoryByExpirationDate(DateTime startDate, DateTime endDate);
    }
}
