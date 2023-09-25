using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EntitiesShared.OtherDataManagement;
using EntitiesShared;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeLeaveData : DataManagerCRUD<EmployeeLeaveModel>, IEmployeeLeaveData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeLeaveData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeLeaveModel> GetAllByEmployeeNumberAndLeaveId(string employeeNumber, long leaveId, int year)
        {
            string query = @"SELECT * FROM EmployeeLeaves AS EL
                            JOIN LeaveTypes AS LT ON EL.leaveId = LT.id
                            WHERE EL.isDeleted=false AND EL.leaveId=@LeaveId AND
                            EL.employeeNumber=@EmployeeNumber AND EL.currentYear=@Year
                            ORDER BY EL.id DESC";

            List<EmployeeLeaveModel> results = new List<EmployeeLeaveModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeLeaveModel, LeaveTypeModel, EmployeeLeaveModel>(query,
                        (EL, LT) => {
                            EL.LeaveType = LT;
                            return EL;
                        }, new
                        {
                            LeaveId = leaveId,
                            EmployeeNumber = employeeNumber,
                            Year = year
                        }).ToList();
                conn.Close();
            }

            return results;
        }

        public List<EmployeeLeaveModel> GetAllByEmployeeNumberAndYear(string employeeNumber, int year)
        {
            string query = @"SELECT * 
                            FROM EmployeeLeaves AS EL
                            JOIN LeaveTypes AS LT ON EL.leaveId = LT.id
                            WHERE EL.isDeleted=false AND EL.employeeNumber=@EmployeeNumber AND EL.currentYear=@Year AND EL.approvalStatus<>@Status
                            ORDER BY EL.id DESC";

            List<EmployeeLeaveModel> results = new List<EmployeeLeaveModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeLeaveModel, LeaveTypeModel, EmployeeLeaveModel>(query,
                        (EL, LT) => {
                            EL.LeaveType = LT;
                            return EL;
                        }, new
                        {
                            EmployeeNumber = employeeNumber,
                            Year = year,
                            Status = (int)StaticData.EmployeeRequestApprovalStatus.Pending
                        }).ToList();
                conn.Close();
            }

            return results;
        }


        public List<EmployeeLeaveModel> GetAllByStatus(StaticData.EmployeeRequestApprovalStatus status)
        {
            string query = @"SELECT * 
                            FROM EmployeeLeaves AS EL
                            JOIN LeaveTypes AS LT ON EL.leaveId = LT.id
                            WHERE EL.isDeleted=false AND EL.approvalStatus=@Status
                            ORDER BY EL.id DESC";

            List<EmployeeLeaveModel> results = new List<EmployeeLeaveModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeLeaveModel, LeaveTypeModel, EmployeeLeaveModel>(query,
                        (EL, LT) => {
                            EL.LeaveType = LT;
                            return EL;
                        }, new
                        {
                            Status = (int)status
                        }).ToList();
                conn.Close();
            }

            return results;
        }

        public List<EmployeeLeaveModel> GetAllByEmpAndStatus(string employeeNumber, StaticData.EmployeeRequestApprovalStatus status)
        {
            string query = @"SELECT * 
                            FROM EmployeeLeaves AS EL
                            JOIN LeaveTypes AS LT ON EL.leaveId = LT.id
                            WHERE EL.isDeleted=false AND EL.approvalStatus=@Status AND EL.employeeNumber=@EmployeeNumber
                            ORDER BY EL.id DESC";

            List<EmployeeLeaveModel> results = new List<EmployeeLeaveModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeLeaveModel, LeaveTypeModel, EmployeeLeaveModel>(query,
                        (EL, LT) => {
                            EL.LeaveType = LT;
                            return EL;
                        }, new
                        {
                            EmployeeNumber = employeeNumber,
                            Status = (int)status
                        }).ToList();
                conn.Close();
            }

            return results;
        }

        public List<EmployeeLeaveModel> GetAllByDateRange(int year, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * 
                            FROM EmployeeLeaves AS EL
                            JOIN LeaveTypes AS LT ON EL.leaveId = LT.id
                            WHERE EL.isDeleted=false AND EL.currentYear=@Year AND 
                            EL.startDate BETWEEN @StartDate AND @EndDate AND EL.endDate BETWEEN @StartDate
                            ORDER BY EL.id DESC";

            List<EmployeeLeaveModel> results = new List<EmployeeLeaveModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeLeaveModel, LeaveTypeModel, EmployeeLeaveModel>(query,
                        (EL, LT) => {
                            EL.LeaveType = LT;
                            return EL;
                        }, new
                        {
                            Year = year,
                            StartDate = startDate,
                            EndDate = endDate
                        }).ToList();
                conn.Close();
            }

            return results;
        }


        public List<EmployeeLeaveModel> GetAllUnpaidByDateRange(int year, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * 
                            FROM EmployeeLeaves AS EL
                            JOIN LeaveTypes AS LT ON EL.leaveId = LT.id
                            WHERE EL.isDeleted=false AND EL.isPaid=false AND EL.currentYear=@Year AND 
                            EL.startDate BETWEEN @StartDate AND @EndDate AND EL.endDate BETWEEN @StartDate AND @EndDate AND EL.approvalStatus=@Status
                            ORDER BY EL.id DESC";

            List<EmployeeLeaveModel> results = new List<EmployeeLeaveModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeLeaveModel, LeaveTypeModel, EmployeeLeaveModel>(query,
                        (EL, LT) => {
                            EL.LeaveType = LT;
                            return EL;
                        }, new
                        {
                            Year = year,
                            StartDate = startDate,
                            EndDate = endDate,
                            Status = (int)StaticData.EmployeeRequestApprovalStatus.Approved
                        }).ToList();
                conn.Close();
            }

            return results;
        }


        public List<EmployeeLeaveModel> GetEmployeeLeavesByPayslipId (string employeeNumber, long payslipId)
        {
            string query = @"SELECT * FROM EmployeeLeaves WHERE isDeleted=false AND payslipId=@PayslipId AND employeeNumber=@EmployeeNumber";
            return this.GetAll(query, new { PayslipId = payslipId, EmployeeNumber = employeeNumber });
        }

        //public List<EmployeeLeaveModel> GetAllByEmployeeNumberAndDateRange(string employeeNumber, int year, DateTime startDate, DateTime endDate)
        //{
        //    string query = @"SELECT * 
        //                    FROM EmployeeLeaves AS EL
        //                    JOIN LeaveTypes AS LT ON EL.leaveId = LT.id
        //                    WHERE EL.isDeleted=false AND EL.employeeNumber=@EmployeeNumber AND EL.currentYear=@Year AND
        //                    EL.startDate BETWEEN @StartDate AND @EndDate AND EL.endDate BETWEEN @StartDate AND @EndDate
        //                    ORDER BY EL.id DESC";

        //    List<EmployeeLeaveModel> results = new List<EmployeeLeaveModel>();

        //    using (var conn = _dbConnFactory.CreateConnection())
        //    {
        //        results = conn.Query<EmployeeLeaveModel, LeaveTypeModel, EmployeeLeaveModel>(query,
        //                (EL, LT) => {
        //                    EL.LeaveType = LT;
        //                    return EL;
        //                }, new
        //                {
        //                    EmployeeNumber = employeeNumber,
        //                    Year = year,
        //                    StartDate = startDate,
        //                    EndDate = endDate
        //                }).ToList();
        //        conn.Close();
        //    }

        //    return results;
        //}
    }
}
