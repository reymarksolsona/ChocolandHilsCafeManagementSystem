using DapperGenericDataManager;
using DataAccess.Data.PayrollManagement.Contracts;
using EntitiesShared.PayrollManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EntitiesShared.EmployeeManagement;
using EntitiesShared;

namespace DataAccess.Data.PayrollManagement.Implementations
{
    public class EmployeeCashAdvanceRequestData : DataManagerCRUD<EmployeeCashAdvanceRequestModel>, IEmployeeCashAdvanceRequestData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeCashAdvanceRequestData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeCashAdvanceRequestModel> GetAllNotDeleted()
        {
            string query = @"SELECT * FROM EmployeeCashAdvanceRequests AS REQ
                            JOIN Employees AS EMP ON EMP.employeeNumber=REQ.employeeNumber
                            WHERE REQ.isDeleted=false AND YEAR(REQ.createdAt) = @Year ORDER BY REQ.needOnDate ASC";

            var results = new List<EmployeeCashAdvanceRequestModel>();

            using(var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeCashAdvanceRequestModel, EmployeeModel, EmployeeCashAdvanceRequestModel>(query,
                    (REQ, EMP) =>
                    {
                        REQ.Employee = EMP;
                        return REQ;
                    }, new {
                        Year = DateTime.Now.Year
                    }).ToList();

                conn.Close();
            }
            return results;
        }


        public List<EmployeeCashAdvanceRequestModel> GetAllNotDeletedByStatus(StaticData.EmployeeRequestApprovalStatus status)
        {
            string query = @"SELECT * FROM EmployeeCashAdvanceRequests  AS REQ
                            JOIN Employees AS EMP ON EMP.employeeNumber=REQ.employeeNumber
                            WHERE REQ.isDeleted=false AND REQ.approvalStatus=@Status
                            ORDER BY REQ.needOnDate ASC";

            var results = new List<EmployeeCashAdvanceRequestModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeCashAdvanceRequestModel, EmployeeModel, EmployeeCashAdvanceRequestModel>(query,
                    (REQ, EMP) =>
                    {
                        REQ.Employee = EMP;
                        return REQ;
                    }, new
                    {
                        Status = (int)status
                    }).ToList();

                conn.Close();
            }
            return results;
        }

        public List<EmployeeCashAdvanceRequestModel> GetAllByCashReleaseDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * FROM EmployeeCashAdvanceRequests  AS REQ
                            JOIN Employees AS EMP ON EMP.employeeNumber=REQ.employeeNumber
                            WHERE REQ.isDeleted=false AND REQ.approvalStatus=@Status AND
                                REQ.cashReleaseDate BETWEEN @StartDate AND @EndDate
                            ORDER BY REQ.needOnDate ASC";

            var results = new List<EmployeeCashAdvanceRequestModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeCashAdvanceRequestModel, EmployeeModel, EmployeeCashAdvanceRequestModel>(query,
                    (REQ, EMP) =>
                    {
                        REQ.Employee = EMP;
                        return REQ;
                    }, new
                    {
                        Status = (int)StaticData.EmployeeRequestApprovalStatus.Approved,
                        StartDate = startDate.ToString("yyyy-MM-dd"),
                        EndDate = endDate.ToString("yyyy-MM-dd")
                    }).ToList();

                conn.Close();
            }
            return results;
        }

        public List<EmployeeCashAdvanceRequestModel> GetAllNotDeletedByEmployee(string employeeNumber)
        {
            string query = @"SELECT * FROM EmployeeCashAdvanceRequests 
                            WHERE isDeleted=false AND employeeNumber=@EmployeeNumber AND YEAR(createdAt) = @Year ORDER BY id DESC";

            return this.GetAll(query, 
                new { 
                    EmployeeNumber = employeeNumber,
                    Year = DateTime.Now.Year
                });
        }
    }
}
