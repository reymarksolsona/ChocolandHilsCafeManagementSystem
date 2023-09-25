using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeBenefitData : DataManagerCRUD<EmployeeBenefitModel>, IEmployeeBenefitData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeBenefitData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeBenefitModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM EmployeeBenefits WHERE isDeleted=false";
            return this.GetAll(query);
        }

    }
}
