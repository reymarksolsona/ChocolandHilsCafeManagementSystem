using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeePositionData : DataManagerCRUD<EmployeePositionModel>, IEmployeePositionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeePositionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeePositionModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM EmployeePositions WHERE isDeleted=false";

            return this.GetAll(query);
        }
    }
}
