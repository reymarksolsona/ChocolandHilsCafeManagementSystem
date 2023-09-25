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
    public class ProductCategoryData : DataManagerCRUD<ProductCategoryModel>, IProductCategoryData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public ProductCategoryData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<ProductCategoryModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM ProductCategories WHERE isDeleted=false";
            return this.GetAll(query);
        }
    }
}
