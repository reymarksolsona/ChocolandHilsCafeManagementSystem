using DapperGenericDataManager;
using DataAccess.Data.PayrollManagement.Contracts;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Data.EmployeeManagement.Contracts;

namespace DataAccess.Data.PayrollManagement.Implementations
{
    public class EmployeePayslipData : DataManagerCRUD<EmployeePayslipModel>, IEmployeePayslipData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IEmployeeData _employeeData;
        private readonly IEmployeePayslipBenefitData _employeePayslipBenefitData;
        private readonly IEmployeePayslipDeductionData _employeePayslipDeductionData;
        private readonly IEmployeeGovernmentContributionData _employeeGovernmentContributionData;

        public EmployeePayslipData(IDbConnectionFactory dbConnFactory,
                                    IEmployeeData employeeData,
                                    IEmployeePayslipBenefitData employeePayslipBenefitData,
                                    IEmployeePayslipDeductionData employeePayslipDeductionData,
                                    IEmployeeGovernmentContributionData employeeGovernmentContributionData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _employeeData = employeeData;
            _employeePayslipBenefitData = employeePayslipBenefitData;
            _employeePayslipDeductionData = employeePayslipDeductionData;
            _employeeGovernmentContributionData = employeeGovernmentContributionData;
        }

        public List<EmployeePayslipModel> GetAllEmpPayslipByPaydate (DateTime paydate)
        {
            string query = @"SELECT * FROM EmployeePayslips WHERE isDeleted=false AND isCancel=false AND payDate=@PayDate";

            var payslipRecs = this.GetAll(query, new
            {
                PayDate = paydate.ToString("yyyy-MM-dd")
            });

            if (payslipRecs != null)
            {
                payslipRecs.ForEach(x =>
                {
                    x.Employee = _employeeData.GetByEmployeeNumber(x.EmployeeNumber);
                    x.Benefits = _employeePayslipBenefitData.GetAllByPayslipIdAndEmployeeNumber(x.Id, x.EmployeeNumber);
                    x.Deductions = _employeePayslipDeductionData.GetAllByPayslipIdAndEmployeeNumber(x.Id, x.EmployeeNumber);
                    x.EmployeeGovContributions = _employeeGovernmentContributionData.GetByPayslip(x.Id, x.EmployeeNumber);
                });
            }

            return payslipRecs;
        }


        public List<EmployeePayslipModel> GetAllEmpPayslipByMonth(int monthNum)
        {
            string query = @"SELECT * FROM EmployeePayslips WHERE isDeleted=false AND isCancel=false AND MONTH(payDate)=@Month";

            var payslipRecs = this.GetAll(query, new
            {
                Month = monthNum
            });

            if (payslipRecs != null)
            {
                payslipRecs.ForEach(x =>
                {
                    x.Employee = _employeeData.GetByEmployeeNumber(x.EmployeeNumber);
                    x.Benefits = _employeePayslipBenefitData.GetAllByPayslipIdAndEmployeeNumber(x.Id, x.EmployeeNumber);
                    x.Deductions = _employeePayslipDeductionData.GetAllByPayslipIdAndEmployeeNumber(x.Id, x.EmployeeNumber);
                    x.EmployeeGovContributions = _employeeGovernmentContributionData.GetByPayslip(x.Id, x.EmployeeNumber);
                });
            }

            return payslipRecs;
        }


        public EmployeePayslipModel GetEmployeePayslipRecordByPaydate(string employeeNumber, DateTime paydate)
        {
            string query = @"SELECT * FROM EmployeePayslips WHERE isDeleted=false AND isCancel=false AND employeeNumber=@EmployeeNumber AND payDate=@PayDate";

            var payslipRec = this.GetAll(query, new
            {
                EmployeeNumber = employeeNumber,
                PayDate = paydate.ToString("yyyy-MM-dd")
            });

            if (payslipRec != null)
            {
                payslipRec.ForEach(x =>
                {
                    x.Employee = _employeeData.GetByEmployeeNumber(x.EmployeeNumber);
                    x.Benefits = _employeePayslipBenefitData.GetAllByPayslipIdAndEmployeeNumber(x.Id, x.EmployeeNumber);
                    x.Deductions = _employeePayslipDeductionData.GetAllByPayslipIdAndEmployeeNumber(x.Id, x.EmployeeNumber);
                    x.EmployeeGovContributions = _employeeGovernmentContributionData.GetByPayslip(x.Id, x.EmployeeNumber);
                });
            }

            return payslipRec.FirstOrDefault();
        }


        public List<DateTime> GetEmployeePayslipPaydatesList(string employeeNumber)
        {
            string query = @"SELECT DISTINCT payDate FROM EmployeePayslips WHERE isDeleted=false AND isCancel=false AND employeeNumber=@EmployeeNumber ORDER BY payDate DESC";

            List<DateTime> results = new List<DateTime>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<DateTime>(query, new { EmployeeNumber = employeeNumber}).ToList();
                conn.Close();
            }

            return results;
        }

        public List<DateTime> GetPayslipPaydatesList()
        {
            string query = @"SELECT DISTINCT payDate FROM EmployeePayslips WHERE isDeleted=false AND isCancel=false ORDER BY payDate DESC";

            List<DateTime> results = new List<DateTime>();
            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<DateTime>(query).ToList();
                conn.Close();
            }

            return results;
        }
    }
}
