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
    public class ProductData : DataManagerCRUD<ProductModel>, IProductData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public ProductData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public bool MassUpdateProductCategory (long previousCategoryId, long newCategoryId)
        {
            var productsUnderPrevCategory = this.GetAllByCategory(previousCategoryId);

            if (productsUnderPrevCategory == null)
                return true;

            if (productsUnderPrevCategory != null && productsUnderPrevCategory.Count == 0)
            {
                return true;
            }

            string query = @"UPDATE Products SET categoryId=@NewCategoryId 
                            WHERE isDeleted=false AND categoryId=@PreviousCategoryId";

            int rowsAffected = 0;
            using (var conn = _dbConnFactory.CreateConnection())
            {
                rowsAffected = conn.Execute(query,
                        new
                        {
                            NewCategoryId = newCategoryId,
                            PreviousCategoryId = previousCategoryId
                        });
                conn.Close();
            }

            return rowsAffected > 0;
        }

        public bool MassDeleteProductsByCategory(long categoryId)
        {
            string query = @"UPDATE Products SET isDeleted=true 
                            WHERE isDeleted=false AND categoryId=@Categoryid";

            int rowsAffected = 0;
            using (var conn = _dbConnFactory.CreateConnection())
            {
                rowsAffected = conn.Execute(query,
                        new
                        {
                            Categoryid = categoryId
                        });
                conn.Close();
            }

            return rowsAffected > 0;
        }


        public List<ProductModel> GetAllByCategory(long categoryId)
        {
           
            string query = @"SELECT *
                            FROM Products AS P
                            JOIN ProductCategories AS PC ON P.categoryId = PC.id
                            WHERE P.isDeleted=false AND P.categoryId=@CategoryId";

            List<ProductModel> results = new List<ProductModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<ProductModel, ProductCategoryModel, ProductModel>(query,
                    (P, PC) =>
                    {
                        P.Category = PC;
                        return P;
                    }, new { CategoryId = categoryId }).ToList();
            }

            return results;
        }

        public List<ProductModel> GetAllNotDeleted()
        {
            string query = @"SELECT *
                            FROM Products AS P
                            JOIN ProductCategories AS PC ON P.categoryId = PC.id
                            WHERE P.isDeleted=false";

            List<ProductModel> results = new List<ProductModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<ProductModel, ProductCategoryModel, ProductModel>(query,
                    (P, PC) =>
                    {
                        P.Category = PC;
                        return P;
                    }).ToList();
            }

            return results;
        }

    }
}
