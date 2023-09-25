using DapperGenericDataManager;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EntitiesShared.POSManagement.CustomModels;

namespace DataAccess.Data.POSManagement.Implementations
{
    public class SaleTransactionData : DataManagerCRUD<SaleTransactionModel>, ISaleTransactionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SaleTransactionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<SaleTransactionModel> GetActiveTransactionGreaterOrEqualToMaxTable(int maxTableNum)
        {
            string query = @"SELECT * FROM SalesTransactions 
                            WHERE isDeleted=false AND transStatus=@OngoingStatus AND tableNumber > @MaxTableNumber";

            return this.GetAll(query,
                new {
                    OngoingStatus = (int)StaticData.POSTransactionStatus.OnGoing,
                    MaxTableNumber = maxTableNum
                });
        }

        public List<SaleTransactionModel> GetAllByTransactionDate(DateTime transDate, StaticData.POSTransactionStatus POSTransactionStatus)
        {
            string query = @"SELECT * FROM SalesTransactions 
                            WHERE DATE(createdAt)=@TransactionDate AND transStatus=@TransStatus
                            ORDER BY id DESC";
            return this.GetAll(query,
                    new {
                        TransactionDate = transDate.ToString("yyyy-MM-dd"),
                        TransStatus = (int)POSTransactionStatus
                    });
        }

        public List<SaleTransactionModel> GetAllByTransactionDateRange(DateTime startDate, DateTime endDate, StaticData.POSTransactionStatus POSTransactionStatus)
        {
            endDate = endDate.AddDays(1);
            string query = @"SELECT * FROM SalesTransactions 
                            WHERE createdAt BETWEEN @StartDate AND @EndDate AND transStatus=@TransStatus
                            ORDER BY id DESC";
            return this.GetAll(query,
                new {
                    StartDate = startDate.ToString("yyyy-MM-dd"),
                    EndDate = endDate.ToString("yyyy-MM-dd"),
                    TransStatus = (int)POSTransactionStatus
                });
        }

        public List<SaleTransactionModel> GetSalesTransactionByStatusAndTransType(StaticData.POSTransactionStatus POSTransactionStatus, StaticData.POSTransactionType posTransactionType)
        {
            string query = @"SELECT * FROM SalesTransactions
                                WHERE isDeleted=false AND transactionType=@TransactionType AND transStatus=@TransStatus
                                ORDER BY id DESC";

            return this.GetAll(query, new {
                TransactionType = (int)posTransactionType,
                TransStatus = (int)POSTransactionStatus
            });
        }

        public List<SaleTransactionModel> GetSalesTransactionByTableNumberAndTransType(int tableNumber, StaticData.POSTransactionType posTransactionType)
        {
            string query = @"SELECT * FROM SalesTransactions
                                WHERE isDeleted=false AND transactionType=@TransactionType AND transStatus <> @TransStatus AND tableNumber=@TableNumber
                                ORDER BY id DESC";

            return this.GetAll(query, new
            {
                TransactionType = (int)posTransactionType,
                TableNumber = tableNumber,
                TransStatus = (int)StaticData.POSTransactionStatus.Cancelled
            });
        }

        public List<SaleTransactionModel> GetOngoingSalesTransactionWithCustomerNotYetDone(StaticData.POSTransactionType posTransactionType)
        {
            string query = @"SELECT * 
                            FROM SalesTransactions WHERE isDeleted=false AND IsCustomerDone=false AND 
                            transactionType=@TransactionType AND transStatus <> @TransStatus";

            return this.GetAll(query, new
            {
                TransactionType = (int)posTransactionType,
                TransStatus = (int)StaticData.POSTransactionStatus.Cancelled
            });
        }

        public bool MarkTableAsAvailable(int tableNum)
        {
            string query = @"UPDATE SalesTransactions SET IsCustomerDone=true 
                            WHERE tableNumber=@TableNumber";

            int rowsAffected = 0;
            using (var conn = _dbConnFactory.CreateConnection())
            {
                rowsAffected = conn.Execute(query,
                        new
                        {
                            TableNumber = tableNum
                        });
                conn.Close();
            }

            return rowsAffected > 0;
        }


        public List<SaleTransactionModel> GetSalesTransactionByStatus(StaticData.POSTransactionStatus POSTransactionStatus)
        {
            string query = @"SELECT * FROM SalesTransactions
                                WHERE isDeleted=false AND transStatus=@TransStatus";

            return this.GetAll(query, new { TransStatus = (int)POSTransactionStatus });
        }

        public decimal GetDayTotalSales (StaticData.POSTransactionStatus POSTransactionStatus, DateTime transDate)
        {
            string query = @"SELECT SUM(totalAmount) as totalSales 
                            FROM SalesTransactions
                            WHERE isDeleted=false AND isCashOut=false AND transStatus=@TransStatus AND DATE(createdAt)=@TransDate";

            return this.GetValue<decimal>(query,
                new { 
                    TransStatus = POSTransactionStatus, 
                    TransDate = transDate.ToString("yyyy-MM-dd") 
                });
        }

        public bool MassSalesTransactionSalesCashout(StaticData.POSTransactionStatus POSTransactionStatus, DateTime transDate)
        {
            string query = @"UPDATE SalesTransactions SET isCashOut=true 
                            WHERE isDeleted=false AND isCashOut=false AND transStatus=@TransStatus AND DATE(createdAt)=@TransDate";

            int rowsAffected = 0;
            using (var conn = _dbConnFactory.CreateConnection())
            {
                rowsAffected = conn.Execute(query,
                        new { 
                            TransStatus = POSTransactionStatus, 
                            TransDate = transDate.ToString("yyyy-MM-dd") 
                        });
                conn.Close();
            }

            return rowsAffected > 0;
        }


        public long GetNumberOfValidTransactionsByYear (int year, StaticData.POSTransactionStatus POSTransactionStatus)
        {
            string query = @"SELECT COUNT(id) as counter FROM SalesTransactions 
                            WHERE YEAR(createdAt) = @Year AND transStatus=@TransStatus";

            return this.GetValue<long>(query, new { Year = year, TransStatus = POSTransactionStatus });
        }


        public List<YearSalesReportModel> GetYearlySalesReport()
        {
            string query = @"SELECT SUM(totalSales) as totalSales, YEAR(createdAt) as yr
                            FROM CashRegisterCashOutTransactions
                            WHERE isDeleted=false
                            GROUP BY YEAR(createdAt)";

            var results = new List<YearSalesReportModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<YearSalesReportModel>(query).ToList();
                conn.Close();
            }

            return results;
        }

        public List<YearSalesReportModel> GetYearlySalesReport(int[] yearList)
        {
            string query = @"SELECT SUM(totalSales) as totalSales, YEAR(createdAt) as yr
                            FROM CashRegisterCashOutTransactions
                            WHERE isDeleted=false AND YEAR(createdAt) IN @YearList
                            GROUP BY YEAR(createdAt)";

            var results = new List<YearSalesReportModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<YearSalesReportModel>(query, new { YearList = yearList }).ToList();
                conn.Close();
            }

            return results;
        }

        public YearSalesReportModel GetSalesReportByYear(int year)
        {
            string query = @"SELECT SUM(totalSales) as totalSales, YEAR(createdAt) as yr
                            FROM CashRegisterCashOutTransactions
                            WHERE isDeleted=false AND YEAR(createdAt) = @Year
                            GROUP BY YEAR(createdAt)";

            var results = new YearSalesReportModel();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.QueryFirstOrDefault<YearSalesReportModel>(query, new
                {
                    Year = year
                });
                conn.Close();
            }

            return results;
        }

        public List<MonthSalesReportModel> GetMonthlySalesReport(int year)
        {
            string query = @"SELECT SUM(totalSales) as TotalSales, MONTH(createdAt) as Mnth
                                FROM CashRegisterCashOutTransactions
                                WHERE isDeleted=false AND YEAR(createdAt) = @Year
                                GROUP BY MONTH(createdAt)";

            var results = new List<MonthSalesReportModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<MonthSalesReportModel>(query, new { Year = year }).ToList();
                conn.Close();
            }

            return results;
        }

        public MonthSalesReportModel GetSalesReportYearAndMonth(int year, int month)
        {
            string query = @"SELECT SUM(totalSales) as TotalSales, MONTH(createdAt) as Mnth
                                FROM CashRegisterCashOutTransactions
                                WHERE isDeleted=false AND YEAR(createdAt) = @Year AND MONTH(createdAt) = @Month
                                GROUP BY MONTH(createdAt)";

            var results = new MonthSalesReportModel();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.QueryFirstOrDefault<MonthSalesReportModel>(query, 
                        new {
                            Year = year,
                            Month = month
                        });
                conn.Close();
            }
            return results;
        }

        public WeekSalesReportModel GetWeeklySalesReportByYearAndWeek(int year, int week)
        {
            string query = @"SELECT SUM(totalSales) as TotalSales, WEEK(createdAt) as wk
                            FROM CashRegisterCashOutTransactions
                            WHERE isDeleted=false AND YEAR(createdAt) = @Year AND WEEK(createdAt) = @Week
                            GROUP BY WEEK(createdAt)";

            var results = new WeekSalesReportModel();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.QueryFirstOrDefault<WeekSalesReportModel>(query, new { Year = year, Week = week });
                conn.Close();
            }

            return results;
        }

        public List<WeekSalesReportModel> GetWeeklySalesReportByYear (int year)
        {
            string query = @"SELECT SUM(totalSales) as TotalSales, WEEK(createdAt) as wk
                            FROM CashRegisterCashOutTransactions
                            WHERE isDeleted=false AND YEAR(createdAt) = @Year
                            GROUP BY WEEK(createdAt)";

            var results = new List<WeekSalesReportModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<WeekSalesReportModel>(query, new { Year = year }).ToList();
                conn.Close();
            }

            return results;
        }
    }
}
