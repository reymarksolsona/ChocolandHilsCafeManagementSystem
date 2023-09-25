using DapperGenericDataManager;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EntitiesShared.InventoryManagement;
using EntitiesShared.POSManagement.CustomModels;
using EntitiesShared;

namespace DataAccess.Data.POSManagement.Implementations
{
    public class SaleTransactionProductData : DataManagerCRUD<SaleTransactionProductModel>, ISaleTransactionProductData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SaleTransactionProductData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public IEnumerable<SaleTransactionProductModel> GetAllBySaleTransId (long saleTransactionId)
        {
            string query = @"SELECT *
                            FROM SalesTransactionProducts AS STPrd
                            JOIN Products AS Prd ON STPrd.productId=Prd.id
                            WHERE STPrd.isDeleted=false AND STPrd.salesTransId=@SaleTransId";

            IEnumerable<SaleTransactionProductModel> results;

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<SaleTransactionProductModel, ProductModel, SaleTransactionProductModel>(query,
                    (STPrd, Prd) => {
                        STPrd.Product = Prd;
                        return STPrd;
                    }, new { SaleTransId = saleTransactionId });

                conn.Close();
            }

            return results;
        }

        public IEnumerable<ProductOrdersReport> GetProductOrdersReport (StaticData.POSTransactionStatus POSTransactionStatus, DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddDays(1);
            string query = @"SELECT Prd.prodName, PrdCat.prodCategory, SUM(STPrd.totalAmount) AS totalSales, COUNT(STPrd.qty) as qty, STPrd.productCurrentPrice
                            FROM SalesTransactionProducts AS STPrd
                            JOIN SalesTransactions AS ST ON ST.id = STPrd.salesTransId
                            JOIN Products AS Prd ON Prd.id=STPrd.productId
                            JOIN ProductCategories AS PrdCat ON PrdCat.id = Prd.categoryId
                            WHERE STPrd.isDeleted=false AND ST.isDeleted=false AND ST.transStatus = @TransStatus AND ST.createdAt BETWEEN @StartDate AND @EndDate
                            GROUP BY STPrd.productId, STPrd.productCurrentPrice";

            IEnumerable<ProductOrdersReport> results;

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<ProductOrdersReport>(query, 
                    new {
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
