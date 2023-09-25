using DapperGenericDataManager;
using EntitiesShared.POSManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.POSManagement.Contracts
{
    public interface ICashRegisterCashOutTransactionData : IDataManagerCRUD<CashRegisterCashOutTransactionModel>
    {
        CashRegisterCashOutTransactionModel GetLastTransaction();
        List<CashRegisterCashOutTransactionModel> GetByDateRange(DateTime startDate, DateTime endDate);
        List<CashRegisterCashOutTransactionModel> GetByDateRange(decimal totalSales, DateTime startDate, DateTime endDate);
    }
}
