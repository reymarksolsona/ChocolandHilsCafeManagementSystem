using DapperGenericDataManager;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Implementations
{
    public class IngredientCategoryData : DataManagerCRUD<IngredientCategoryModel>, IIngredientCategoryData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public IngredientCategoryData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<IngredientCategoryModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM IngredientCategories WHERE isDeleted=false";
            return this.GetAll(query);
        }
    }
}
