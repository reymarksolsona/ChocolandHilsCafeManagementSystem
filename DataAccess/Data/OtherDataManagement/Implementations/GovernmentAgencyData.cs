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
    public class GovernmentAgencyData : DataManagerCRUD<GovernmentAgencyModel>, IGovernmentAgencyData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public GovernmentAgencyData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<GovernmentAgencyModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM GovernmentAgencies WHERE isDeleted=false";
            return this.GetAll(query);
        }
    }
}
