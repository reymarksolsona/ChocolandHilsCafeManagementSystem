using DapperGenericDataManager;
using DataAccess.Data.InventoryManagement.Contracts;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EntitiesShared.InventoryManagement.Models;
using EntitiesShared;

namespace DataAccess.Data.InventoryManagement.Implementations
{
    public class IngredientData : DataManagerCRUD<IngredientModel>, IIngredientData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IIngredientCategoryData _ingredientCategoryData;
        private readonly IIngredientInventoryData _ingredientInventoryData;

        public IngredientData(IDbConnectionFactory dbConnFactory, 
                                IIngredientCategoryData ingredientCategoryData,
                                IIngredientInventoryData ingredientInventoryData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _ingredientCategoryData = ingredientCategoryData;
            _ingredientInventoryData = ingredientInventoryData;
        }

        public bool MassUpdateIngredientsCategory (long previousCategoryId, long newCategoryId)
        {
            var ingredientsUnderPrevCategory = this.GetAllByCategory(previousCategoryId);

            if (ingredientsUnderPrevCategory == null)
                return true;

            if (ingredientsUnderPrevCategory != null && ingredientsUnderPrevCategory.Count == 0)
            {
                return true;
            }

            string query = @"UPDATE Ingredients SET categoryId=@NewCategoryId 
                            WHERE isDeleted=false AND categoryId=@PreviousCategoryId";

            int rowsAffected = 0;
            using (var conn = _dbConnFactory.CreateConnection())
            {
                rowsAffected = conn.Execute(query, 
                        new { 
                            NewCategoryId = newCategoryId, 
                            PreviousCategoryId = previousCategoryId
                        });
                conn.Close();
            }

            return rowsAffected > 0;
        }


        public bool MassDeleteIngredientsByCategory(long categoryId)
        {
            string query = @"UPDATE Ingredients SET isDeleted=true 
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

        public List<IngredientModel> GetAllByCategory (long categoryId)
        {
            string query = @"SELECT * FROM Ingredients WHERE isDeleted=false AND categoryId=@CategoryId";

            return this.GetAll(query, new { CategoryId = categoryId });
        }

        public List<IngredientModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM Ingredients WHERE isDeleted=false";

            var ingredients = this.GetAll(query);

            foreach(var ing in ingredients)
            {
                ing.Category = _ingredientCategoryData.Get(ing.CategoryId);
                ing.RemainingQtyValue = _ingredientInventoryData.GetRemainingQtyValueByIngredient(ing.Id);
            }

            return ingredients;
        }


        public List<IngredientModel> GetAllNotDeletedWithInventory()
        {
            string query = @"SELECT * 
                            FROM Ingredients AS ING
                            JOIN IngredientCategories AS CAT ON CAT.id = ING.categoryId
                            JOIN IngredientInventory AS INGINV ON ING.id = INGINV.ingredientId
                            WHERE ING.isDeleted = false AND INGINV.isDeleted = false AND INGINV.isSoldOut = false";

            List<IngredientModel> results = new();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<IngredientModel, IngredientCategoryModel, IngredientInventoryModel, IngredientModel>(query, 
                    (ING, CAT, INGINV) =>
                    {
                        ING.Category = CAT;
                        ING.Inventory = INGINV;

                        return ING;
                    }).ToList();
                conn.Close();
            }

            return results;
        }


        public IEnumerable<IngredientBreakDownForSalesReportModel> GetBreakDownForSalesReport(StaticData.POSTransactionStatus POSTransactionStatus, DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddDays(1);
            string query = @"SELECT ING.id, ING.ingName, ING.uom, INGCAT.category, SUM(ProdIngDeduction.deductedQtyValue) AS TotalDeductedQtyValue
                                FROM SaleTranProdIngInvDeductionsRecords as ProdIngDeduction
                                JOIN SalesTransactionProducts AS STProd ON STProd.id = ProdIngDeduction.saleTransProductId
                                JOIN SalesTransactions AS ST ON ST.id = STProd.salesTransId
                                JOIN Ingredients AS ING ON ING.id = ProdIngDeduction.ingredientId
                                JOIN IngredientCategories AS INGCAT ON INGCAT.id = ING.categoryId
                                WHERE STProd.isDeleted=false AND ST.isDeleted=false AND ST.transStatus = @TransStatus AND ST.createdAt BETWEEN @StartDate AND @EndDate
                                GROUP BY ProdIngDeduction.ingredientId";

            IEnumerable<IngredientBreakDownForSalesReportModel> results;

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<IngredientBreakDownForSalesReportModel>(query,
                    new
                    {
                        StartDate = startDate.ToString("yyyy-MM-dd"),
                        EndDate = endDate.ToString("yyyy-MM-dd"),
                        TransStatus = (int)POSTransactionStatus
                    });

                conn.Close();
            }

            foreach (var ing in results)
            {
                ing.RemainingQtyValue = _ingredientInventoryData.GetRemainingQtyValueByIngredient(ing.Id);
            }

            return results;
        }

    }
}
