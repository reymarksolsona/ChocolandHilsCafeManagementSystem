using DapperGenericDataManager;
using DataAccess.Data.OtherDataManagement.Contracts;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.OtherDataManagement.Implementations
{
    public class NumberOfWorkingDaysInAMonthData : DataManagerCRUD<NumberOfWorkingDaysInAMonthModel>, INumberOfWorkingDaysInAMonthData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public NumberOfWorkingDaysInAMonthData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public NumberOfWorkingDaysInAMonthModel GetLatestValue()
        {
            string query = @"SELECT * FROM NumberOfWorkingDaysInMonth ORDER BY id DESC LIMIT 1";
            return this.GetFirstOrDefault(query, new { });
        }
    }
}
