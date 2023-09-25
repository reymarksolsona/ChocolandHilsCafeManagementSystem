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
    public class StoreTableData : DataManagerCRUD<StoreTableModel>, IStoreTableData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public StoreTableData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public StoreTableModel GetTheLastTransaction()
        {
            string query = @"SELECT * FROM StoreTables WHERE isDeleted=false ORDER BY id DESC LIMIT 1";
            return this.GetFirstOrDefault(query, new { });
        }
    }
}
