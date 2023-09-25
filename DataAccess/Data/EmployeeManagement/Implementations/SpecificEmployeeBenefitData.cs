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
    public class SpecificEmployeeBenefitData : DataManagerCRUD<SpecificEmployeeBenefitModel>, ISpecificEmployeeBenefitData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public SpecificEmployeeBenefitData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<SpecificEmployeeBenefitModel> GetAllUnpaid()
        {
            string query = @"SELECT * FROM SpecificEmployeeBenefits WHERE isDeleted=false AND isPaid=false";
            return this.GetAll(query);
        }

        public List<SpecificEmployeeBenefitModel> GetAllByEmployeeAndSubmissionDateRange(string employeeNumber, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * 
                            FROM SpecificEmployeeBenefits 
                            WHERE isDeleted=false AND isPaid=false AND employeeNumber=@EmployeeNumber AND createdAt BETWEEN @StartDate AND @EndDate";

            endDate = endDate.AddDays(1);

            return this.GetAll(query, new
            {
                EmployeeNumber = employeeNumber,
                StartDate = startDate.ToString("yyyy-MM-dd"),
                EndDate = endDate.ToString("yyyy-MM-dd")
            });
        }

        public List<SpecificEmployeeBenefitModel> GetAllByEmployeeAndPayslipId(string employeeNumber, long payslipId)
        {
            string query = @"SELECT * 
                            FROM SpecificEmployeeBenefits 
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber AND payslipId=@PayslipId";

            return this.GetAll(query, new
            {
                EmployeeNumber = employeeNumber,
                PayslipId = payslipId
            });
        }

    }
}
