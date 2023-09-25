using DapperGenericDataManager;
using EntitiesShared;
using EntitiesShared.POSManagement;
using EntitiesShared.POSManagement.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Contracts
{
    public interface ISaleTransactionData : IDataManagerCRUD<SaleTransactionModel>
    {
        List<SaleTransactionModel> GetActiveTransactionGreaterOrEqualToMaxTable(int maxTableNum);
        List<SaleTransactionModel> GetAllByTransactionDate(DateTime transDate, StaticData.POSTransactionStatus POSTransactionStatus);
        List<SaleTransactionModel> GetAllByTransactionDateRange(DateTime startDate, DateTime endDate, StaticData.POSTransactionStatus POSTransactionStatus);
        List<SaleTransactionModel> GetSalesTransactionByStatusAndTransType(StaticData.POSTransactionStatus POSTransactionStatus, StaticData.POSTransactionType posTransactionType);
        List<SaleTransactionModel> GetSalesTransactionByStatus(StaticData.POSTransactionStatus POSTransactionStatus);
        List<SaleTransactionModel> GetOngoingSalesTransactionWithCustomerNotYetDone(StaticData.POSTransactionType posTransactionType);
        List<SaleTransactionModel> GetSalesTransactionByTableNumberAndTransType(int tableNumber, StaticData.POSTransactionType posTransactionType);

        decimal GetDayTotalSales(StaticData.POSTransactionStatus POSTransactionStatus, DateTime transDate);
        bool MassSalesTransactionSalesCashout(StaticData.POSTransactionStatus POSTransactionStatus, DateTime transDate);
        bool MarkTableAsAvailable(int tableNum);

        long GetNumberOfValidTransactionsByYear(int year, StaticData.POSTransactionStatus POSTransactionStatus);

        List<YearSalesReportModel> GetYearlySalesReport();
        List<YearSalesReportModel> GetYearlySalesReport(int[] yearList);
        YearSalesReportModel GetSalesReportByYear(int year);

        List<MonthSalesReportModel> GetMonthlySalesReport(int year);
        MonthSalesReportModel GetSalesReportYearAndMonth(int year, int month);

        WeekSalesReportModel GetWeeklySalesReportByYearAndWeek(int year, int week);
        List<WeekSalesReportModel> GetWeeklySalesReportByYear(int year);
    }
}
