using AutoMapper;
using DataAccess.Data.POSManagement.Contracts;
using EntitiesShared.POSManagement.CustomModels;
using Main.Controllers.POSControllers.ControllerInterface;
using Microsoft.Extensions.Logging;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesShared;
using EntitiesShared.POSManagement;
using Microsoft.Extensions.Options;

namespace Main.Controllers.POSControllers
{
    public class POSReadController : IPOSReadController
    {
        private readonly ILogger<POSReadController> _logger;
        private readonly IMapper _mapper;
        private readonly ISaleTransactionData _salesTransactionData;
        private readonly ISaleTransactionProductData _saleTransactionProductData;
        private readonly ISaleTransactionComboMealData _saleTransactionComboMealData;
        private readonly ICashRegisterCashOutTransactionData _cashRegisterCashOutTransactionData;
        private readonly IStoreTableData _storeTableData;
        private readonly OtherSettings _otherSettings;

        public POSReadController(ILogger<POSReadController> logger,
                                IMapper mapper,
                                ISaleTransactionData salesTransactionData,
                                ISaleTransactionProductData saleTransactionProductData,
                                ISaleTransactionComboMealData saleTransactionComboMealData,
                                ICashRegisterCashOutTransactionData cashRegisterCashOutTransactionData,
                                IStoreTableData storeTableData,
                                IOptions<OtherSettings> otherSettings)
        {
            _logger = logger;
            _mapper = mapper;
            _salesTransactionData = salesTransactionData;
            _saleTransactionProductData = saleTransactionProductData;
            _saleTransactionComboMealData = saleTransactionComboMealData;
            _cashRegisterCashOutTransactionData = cashRegisterCashOutTransactionData;
            _storeTableData = storeTableData;
            _otherSettings = otherSettings.Value;
        }

        public List<SaleTransactionModel> GetByDate (DateTime date, StaticData.POSTransactionStatus POSTransactionStatus)
        {
            return this._salesTransactionData.GetAllByTransactionDate(date, POSTransactionStatus);
        }

        public List<SaleTransactionModel> GetByDateRange(DateTime startDate, DateTime endDate, StaticData.POSTransactionStatus POSTransactionStatus)
        {
            return this._salesTransactionData.GetAllByTransactionDateRange(startDate, endDate, POSTransactionStatus);
        }

        public List<SaleTransactionModel> GetActiveDineInSalesTransactions()
        {
            var activeDineInSalesTrans = _salesTransactionData.GetSalesTransactionByStatusAndTransType(StaticData.POSTransactionStatus.OnGoing, StaticData.POSTransactionType.DineIn);
            return activeDineInSalesTrans;
        }

        public List<SaleTransactionModel> GetActiveSalesTransactions()
        {
            var activeDineInSalesTrans = _salesTransactionData.GetSalesTransactionByStatus(StaticData.POSTransactionStatus.OnGoing);
            return activeDineInSalesTrans;
        }

        public List<TableStatusModel> GetTableStatus()
        {
            var storeTable = _storeTableData.GetTheLastTransaction();
            decimal numberOfTables = storeTable == null ? 20 : storeTable.NumberOfTables;
            List<TableStatusModel> tables = new List<TableStatusModel>();

            var activeDineInSalesTrans = _salesTransactionData.GetOngoingSalesTransactionWithCustomerNotYetDone(StaticData.POSTransactionType.DineIn);
            //this.GetActiveDineInSalesTransactions();

            for (var tableNum=1; tableNum <= numberOfTables; tableNum++)
            {
                var activeDineInOnTheCurrentTable = activeDineInSalesTrans.Where(x => x.TableNumber == tableNum).FirstOrDefault();

                tables.Add(new TableStatusModel { 
                    CurrentTransactionId = activeDineInOnTheCurrentTable == null ? 0 : activeDineInOnTheCurrentTable.Id,
                    TableNumber = tableNum,
                    TableTitle = $"T-{tableNum}",
                    Status = activeDineInOnTheCurrentTable == null ? StaticData.TableStatus.Available : StaticData.TableStatus.Occupied
                });
            }

            return tables;
        }


        public IEnumerable<ProductOrdersReport> GetProductOrdersReportByDateRangeAndTransStatus(StaticData.POSTransactionStatus POSTransactionStatus, DateTime startDate, DateTime endDate)
        {
            return _saleTransactionProductData.GetProductOrdersReport(POSTransactionStatus, startDate, endDate);
        }

        public IEnumerable<ComboMealOrdersReport> GetComboMealOrdersReportByDateRangeAndTransStatus(StaticData.POSTransactionStatus POSTransactionStatus, DateTime startDate, DateTime endDate)
        {
            return _saleTransactionComboMealData.GetComboMealOrdersReport(POSTransactionStatus, startDate, endDate);
        }


        public IEnumerable<SaleTransactionProductModel> GetSaleTranProducts (long saleTransactionId)
        {
            return _saleTransactionProductData.GetAllBySaleTransId(saleTransactionId);
        }

        public IEnumerable<SaleTransactionComboMealModel> GetSaleTranComboMeals(long saleTransactionId)
        {
            return _saleTransactionComboMealData.GetAllBySaleTranId(saleTransactionId);
        }


        public decimal GetTotalSalesByDate (DateTime transDate)
        {
            return _salesTransactionData.GetDayTotalSales(StaticData.POSTransactionStatus.Paid, transDate);
        }

        public CashRegisterCashOutTransactionModel GetCashRegisterLastTransaction()
        {
            return _cashRegisterCashOutTransactionData.GetLastTransaction();
        }

        public List<CashRegisterCashOutTransactionModel> GetCashRegisterTransByDateRange(int numberOfDays, DateTime lastDate)
        {
            DateTime startDate = lastDate.AddDays(-numberOfDays);

            return _cashRegisterCashOutTransactionData.GetByDateRange(startDate, lastDate);
        }
    }
}
