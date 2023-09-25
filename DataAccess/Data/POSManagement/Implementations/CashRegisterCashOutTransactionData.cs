using DapperGenericDataManager;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Implementations
{
    public class CashRegisterCashOutTransactionData : DataManagerCRUD<CashRegisterCashOutTransactionModel>, ICashRegisterCashOutTransactionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public CashRegisterCashOutTransactionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public CashRegisterCashOutTransactionModel GetLastTransaction()
        {
            string query = @"SELECT * FROM CashRegisterCashOutTransactions WHERE isDeleted=false ORDER By id DESC LIMIT 1";
            return this.GetFirstOrDefault(query, new { });
        }


        public List<CashRegisterCashOutTransactionModel> GetByDateRange (DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM CashRegisterCashOutTransactions 
                            WHERE isDeleted=false AND createdAt BETWEEN @StartDate AND @EndDate
                            ORDER BY id DESC";

            return this.GetAll(query, new { StartDate = startDate, EndDate = endDate });
        }

        public List<CashRegisterCashOutTransactionModel> GetByDateRange(decimal totalSales, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM CashRegisterCashOutTransactions 
                            WHERE isDeleted=false AND createdAt BETWEEN @StartDate AND @EndDate AND totalSales >= @TotalSales
                            ORDER BY id DESC";

            return this.GetAll(query, new { 
                StartDate = startDate, 
                EndDate = endDate,
                TotalSales = totalSales
            });
        }
    }
}
