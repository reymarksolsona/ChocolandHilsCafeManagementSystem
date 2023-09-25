using DapperGenericDataManager;
using DataAccess.Data.PayrollManagement.Contracts;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.PayrollManagement.Implementations
{
    public class EmployeeGovernmentContributionData : DataManagerCRUD<EmployeeGovernmentContributionModel>, IEmployeeGovernmentContributionData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeGovernmentContributionData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeGovernmentContributionModel> GetByPayslip(long payslipId, string employeeNumber)
        {
            string query = @"SELECT * FROM EmployeeGovernmentContributions 
                            WHERE isDeleted=false AND payslipId=@PayslipId AND employeeNumber=@EmployeeNumber";

            return this.GetAll(query, new { 
                    PayslipId = payslipId,
                    EmployeeNumber = employeeNumber
            });
        }
    }
}
