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
    public class EmployeeDeductionData : DataManagerCRUD<EmployeeDeductionModel>, IEmployeeDeductionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeDeductionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeDeductionModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM EmployeeDeductions WHERE isDeleted=false";
            return this.GetAll(query);
        }
    }
}
