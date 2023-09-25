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
    public interface ISaleTransactionComboMealData : IDataManagerCRUD<SaleTransactionComboMealModel>
    {
        IEnumerable<SaleTransactionComboMealModel> GetAllBySaleTranId(long saleTransactionId);
        IEnumerable<ComboMealOrdersReport> GetComboMealOrdersReport(StaticData.POSTransactionStatus POSTransactionStatus, DateTime startDate, DateTime endDate);
    }
}
