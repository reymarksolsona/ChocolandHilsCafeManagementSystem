﻿using DapperGenericDataManager;
using EntitiesShared.POSManagement;
using EntitiesShared.POSManagement.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Contracts
{
    public interface ISaleTranProdIngInvDeductionsRecordData : IDataManagerCRUD<SaleTranProdIngInvDeductionsRecordModel>
    {
        List<SaleTranProdIngInvDeductionsRecordModel> GetAllBySaleTranProductId(long saleTranProdId, long ingredientId);

        YearCostReportModel GetTotalCostByYear(int year);
        MonthCostReportModel GetTotalCostByYearAndMonth(int year, int monthNum);
        WeekCostReportModel GetTotalCostByYearAndWeek(int year, int weekNum);

        List<YearCostReportModel> GetYearlyCostReport();
        List<YearCostReportModel> GetYearlyCostReport(int[] yearList);
        List<MonthCostReportModel> GetMonthlyCostReport(int year);
        List<WeekCostReportModel> GetWeeklyCostReportByYear(int year);
    }
}
