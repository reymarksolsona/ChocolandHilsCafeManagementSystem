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
    public class EmployeePayslipBenefitData : DataManagerCRUD<EmployeePayslipBenefitModel>, IEmployeePayslipBenefitData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeePayslipBenefitData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeePayslipBenefitModel> GetAllByPayslipId(long payslipId)
        {
            string query = @"SELECT * FROM EmployeePayslipBenefits 
                            WHERE isDeleted=false AND payslipId=@PayslipId";

            return this.GetAll(query, new { PayslipId = payslipId });
        }

        public List<EmployeePayslipBenefitModel> GetAllByPayslipIdAndEmployeeNumber(long payslipId, string employeeNumber)
        {
            string query = @"SELECT * FROM EmployeePayslipBenefits 
                            WHERE isDeleted=false AND payslipId=@PayslipId AND employeeNumber=@EmployeeNumber";

            return this.GetAll(query, new { PayslipId = payslipId, EmployeeNumber = employeeNumber });
        }
    }
}
