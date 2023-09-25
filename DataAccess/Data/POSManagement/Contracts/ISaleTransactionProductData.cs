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
    public interface ISaleTransactionProductData : IDataManagerCRUD<SaleTransactionProductModel>
    {
        IEnumerable<SaleTransactionProductModel> GetAllBySaleTransId(long saleTransactionId);
        IEnumerable<ProductOrdersReport> GetProductOrdersReport(StaticData.POSTransactionStatus POSTransactionStatus, DateTime startDate, DateTime endDate);
    }
}
