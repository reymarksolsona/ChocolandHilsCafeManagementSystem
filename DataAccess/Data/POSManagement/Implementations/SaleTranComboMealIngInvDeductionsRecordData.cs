using DapperGenericDataManager;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement;
using EntitiesShared.POSManagement.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Implementations
{
    public class SaleTranComboMealIngInvDeductionsRecordData : DataManagerCRUD<SaleTranComboMealIngInvDeductionsRecordModel>, ISaleTranComboMealIngInvDeductionsRecordData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SaleTranComboMealIngInvDeductionsRecordData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<SaleTranComboMealIngInvDeductionsRecordModel> GetAllBySaleTranComboMealId(long saleTranComboMealId, long productId, long ingredientId)
        {
            string query = @"SELECT * 
                            FROM SaleTranComboMealIngInvDeductionsRecords
                            WHERE isDeleted=false AND saleTransComboMealId=@SaleTranComboMealId 
                            AND productId=@ProductId AND ingredientId=@IngredientId";

            return this.GetAll(query, new
            {
                SaleTranComboMealId = saleTranComboMealId,
                ProductId = productId,
                IngredientId = ingredientId
            });
        }

        public YearCostReportModel GetTotalCostByYear(int year)
        {
            string query = @"SELECT SUM(totalCost) AS totalCost, YEAR(createdAt) AS Yr
                            FROM SaleTranComboMealIngInvDeductionsRecords
                            WHERE isDeleted=false AND YEAR(createdAt) = @Year";

            return this.GetFirstOrDefault<YearCostReportModel>(query, new { Year = year });
        }

        public MonthCostReportModel GetTotalCostByYearAndMonth(int year, int monthNum)
        {
            string query = @"SELECT SUM(totalCost) AS totalCost, MONTH(createdAt) AS Mnth
                            FROM SaleTranComboMealIngInvDeductionsRecords
                            WHERE isDeleted=false AND YEAR(createdAt) = @Year AND MONTH(createdAt) = @Month";

            return this.GetFirstOrDefault<MonthCostReportModel>(query, new { Year = year, Month = monthNum });
        }

        public WeekCostReportModel GetTotalCostByYearAndWeek(int year, int weekNum)
        {
            string query = @"SELECT SUM(totalCost) AS totalCost, WEEK(createdAt) AS Wk
                            FROM SaleTranComboMealIngInvDeductionsRecords
                            WHERE isDeleted=false AND YEAR(createdAt) = @Year AND WEEK(createdAt) = @Week";

            return this.GetFirstOrDefault<WeekCostReportModel>(query, new { Year = year, Week = weekNum });
        }


        public List<YearCostReportModel> GetYearlyCostReport()
        {
            string query = @"SELECT SUM(totalCost) AS totalCost, YEAR(createdAt) as yr
                            FROM SaleTranComboMealIngInvDeductionsRecords
                            WHERE isDeleted=false
                            GROUP BY YEAR(createdAt)";

            return this.GetAll<YearCostReportModel>(query);
        }

        public List<YearCostReportModel> GetYearlyCostReport(int[] yearList)
        {
            string query = @"SELECT SUM(totalCost) AS totalCost, YEAR(createdAt) as yr
                            FROM SaleTranComboMealIngInvDeductionsRecords
                            WHERE isDeleted=false AND YEAR(createdAt) IN @YearList
                            GROUP BY YEAR(createdAt)";

            return this.GetAll<YearCostReportModel>(query, new { YearList = yearList });
        }

        public List<MonthCostReportModel> GetMonthlyCostReport(int year)
        {
            string query = @"SELECT SUM(totalCost) AS totalCost, MONTH(createdAt) as Mnth
                            FROM SaleTranComboMealIngInvDeductionsRecords
                            WHERE isDeleted=false AND YEAR(createdAt) = @Year
                            GROUP BY MONTH(createdAt)";

            return this.GetAll<MonthCostReportModel>(query, new { Year = year });
        }

        public List<WeekCostReportModel> GetWeeklyCostReportByYear(int year)
        {
            string query = @"SELECT SUM(totalCost) AS totalCost, WEEK(createdAt) as Wk
                            FROM SaleTranComboMealIngInvDeductionsRecords
                            WHERE isDeleted=false AND YEAR(createdAt) = @Year
                            GROUP BY WEEK(createdAt)";

            return this.GetAll<WeekCostReportModel>(query, new { Year = year });
        }
    }
}
