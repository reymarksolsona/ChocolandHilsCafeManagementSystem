using DapperGenericDataManager;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.Data.InventoryManagement.Implementations
{
    public class ComboMealProductData : DataManagerCRUD<ComboMealProductModel>, IComboMealProductData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public ComboMealProductData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<ComboMealProductModel> GetAllByComboMealPlain(long comboMealId)
        {
            string query = "SELECT * FROM ComboMealProducts WHERE comboMealId=@ComboMealId";
            return this.GetAll(query, new { ComboMealId = comboMealId });
        }

        public List<ComboMealProductModel> GetAllByComboMeal(long comboMealId)
        {
            string query = @"SELECT * 
                            FROM ComboMealProducts AS CMP
                            JOIN Products AS PRD ON CMP.productId=PRD.id
                            JOIN ProductCategories AS PRDCAT ON PRD.categoryId=PRDCAT.Id
                            WHERE CMP.isDeleted=false AND PRD.isDeleted=false AND CMP.comboMealId=@ComboMealId";

            var results = new List<ComboMealProductModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<ComboMealProductModel, ProductModel, ProductCategoryModel, ComboMealProductModel>(query,
                    (CMP, PRD, PRDCAT) =>
                    {
                        PRD.Category = PRDCAT;
                        CMP.Product = PRD;
                        return CMP;
                    }, new { ComboMealId = comboMealId }).ToList();
            }

            return results;
        }
    }
}
