using Dapper;
using DapperGenericDataManager;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared;
using EntitiesShared.InventoryManagement;
using EntitiesShared.POSManagement;
using EntitiesShared.POSManagement.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Implementations
{
    public class SaleTransactionComboMealData : DataManagerCRUD<SaleTransactionComboMealModel>, ISaleTransactionComboMealData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SaleTransactionComboMealData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public IEnumerable<SaleTransactionComboMealModel> GetAllBySaleTranId (long saleTransactionId)
        {
            string query = @"SELECT *
                            FROM SalesTransactionComboMeals AS STComMl
                            JOIN ComboMeals AS ComMl ON STComMl.comboMealId = ComMl.id
                            WHERE STComMl.isDeleted=false AND STComMl.salesTransId=@SaleTransId";

            IEnumerable<SaleTransactionComboMealModel> results;

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<SaleTransactionComboMealModel, ComboMealModel, SaleTransactionComboMealModel>(query,
                    (STComMl, ComMl) => {
                        STComMl.ComboMeal = ComMl;
                        return STComMl;
                    }, new { SaleTransId = saleTransactionId });

                conn.Close();
            }

            return results;
        }

        public IEnumerable<ComboMealOrdersReport> GetComboMealOrdersReport(StaticData.POSTransactionStatus POSTransactionStatus, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT CMeals.title, SUM(STCMeals.totalAmount) As totalSales, COUNT(STCMeals.qty) AS qty, STCMeals.comboMealCurrentPrice
                            FROM SalesTransactionComboMeals AS STCMeals
                            JOIN ComboMeals AS CMeals ON CMeals.id = STCMeals.comboMealId
                            JOIN SalesTransactions AS ST ON ST.id = STCMeals.salesTransId
                            WHERE STCMeals.isDeleted=false AND ST.isDeleted=false AND ST.transStatus = @TransStatus AND ST.createdAt BETWEEN @StartDate AND @EndDate
                            ORDER BY STCMeals.comboMealId AND STCMeals.comboMealCurrentPrice";

            IEnumerable<ComboMealOrdersReport> results;

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<ComboMealOrdersReport>(query,
                    new
                    {
                        StartDate = startDate.ToString("yyyy-MM-dd"),
                        EndDate = endDate.ToString("yyyy-MM-dd"),
                        TransStatus = (int)POSTransactionStatus
                    });

                conn.Close();
            }

            return results;
        }
    }
}
