using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeeAttendanceData : DataManagerCRUD<EmployeeAttendanceModel>, IEmployeeAttendanceData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IEmployeeShiftDayData _employeeShiftDayData;

        public EmployeeAttendanceData(IDbConnectionFactory dbConnFactory, IEmployeeShiftDayData employeeShiftDayData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _employeeShiftDayData = employeeShiftDayData;
        }


        private void ProvideShiftDays(List<EmployeeAttendanceModel> attendance)
        {
            if (attendance != null)
            {
                foreach(var record in attendance)
                {
                    if (record.Shift != null)
                        record.Shift.ShiftDays = _employeeShiftDayData.GetByShiftId(record.Shift.Id);
                }
            }
        }

        public List<EmployeeAttendanceModel> GetAllAttendanceRecordByWorkDate (DateTime workDate)
        {
            string query = @"SELECT * 
                                FROM EmployeeAttendance AS EA
                                JOIN EmployeeShifts AS ES ON EA.shiftId=ES.id
                                JOIN Employees AS E ON EA.employeeNumber=E.employeeNumber
                                WHERE EA.workDate=@WorkDate ORDER BY EA.id DESC";

            List<EmployeeAttendanceModel> results = new List<EmployeeAttendanceModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeAttendanceModel, EmployeeShiftModel, EmployeeModel, EmployeeAttendanceModel>(query,
                        (EA, ES, E) => {

                            EA.Shift = ES;
                            EA.Employee = E;

                            return EA;
                        }, new { WorkDate = workDate.ToString("yyyy-MM-dd") }).ToList();
                conn.Close();
            }

            this.ProvideShiftDays(results);

            return results;
        }


        public List<EmployeeAttendanceModel> GetAllAttendanceRecordByWorkDateRange(string employeeNumber, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * 
                                FROM EmployeeAttendance AS EA
                                JOIN EmployeeShifts AS ES ON EA.shiftId=ES.id
                                JOIN Employees AS E ON EA.employeeNumber=E.employeeNumber
                                WHERE EA.employeeNumber=@EmployeeNumber AND EA.workDate BETWEEN @StartDate AND @EndDate
                                ORDER BY EA.id DESC";

            List<EmployeeAttendanceModel> results = new List<EmployeeAttendanceModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeAttendanceModel, EmployeeShiftModel, EmployeeModel, EmployeeAttendanceModel>(query,
                        (EA, ES, E) => {

                            EA.Shift = ES;
                            EA.Employee = E;

                            return EA;
                        }, 
                        new { 
                            EmployeeNumber = employeeNumber,
                            StartDate = startDate.ToString("yyyy-MM-dd"), 
                            EndDate = endDate.ToString("yyyy-MM-dd") 
                        }).ToList();
                conn.Close();
            }

            this.ProvideShiftDays(results);

            return results;
        }

        public List<EmployeeAttendanceModel> GetAllUnpaidAttendanceRecordByWorkDateRange(string employeeNumber, DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * 
                                FROM EmployeeAttendance AS EA
                                JOIN EmployeeShifts AS ES ON EA.shiftId=ES.id
                                JOIN Employees AS E ON EA.employeeNumber=E.employeeNumber
                                WHERE EA.employeeNumber=@EmployeeNumber AND EA.workDate BETWEEN @StartDate AND @EndDate AND EA.isPaid=false
                                ORDER BY EA.id DESC";

            List<EmployeeAttendanceModel> results = new List<EmployeeAttendanceModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeAttendanceModel, EmployeeShiftModel, EmployeeModel, EmployeeAttendanceModel>(query,
                        (EA, ES, E) => {

                            EA.Shift = ES;
                            EA.Employee = E;

                            return EA;
                        },
                        new
                        {
                            EmployeeNumber = employeeNumber,
                            StartDate = startDate.ToString("yyyy-MM-dd"),
                            EndDate = endDate.ToString("yyyy-MM-dd")
                        }).ToList();
                conn.Close();
            }

            this.ProvideShiftDays(results);

            return results;
        }

        public List<EmployeeAttendanceModel> GetAllAttendanceRecordByWorkDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * 
                                FROM EmployeeAttendance AS EA
                                JOIN EmployeeShifts AS ES ON EA.shiftId=ES.id
                                JOIN Employees AS E ON EA.employeeNumber=E.employeeNumber
                                WHERE EA.workDate BETWEEN @StartDate AND @EndDate
                                ORDER BY EA.id DESC";

            List<EmployeeAttendanceModel> results = new List<EmployeeAttendanceModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeAttendanceModel, EmployeeShiftModel, EmployeeModel, EmployeeAttendanceModel>(query,
                        (EA, ES, E) => {

                            EA.Shift = ES;
                            EA.Employee = E;

                            return EA;
                        },
                        new
                        {
                            StartDate = startDate.ToString("yyyy-MM-dd"),
                            EndDate = endDate.ToString("yyyy-MM-dd")
                        }).ToList();
                conn.Close();
            }


            this.ProvideShiftDays(results);

            return results;
        }


        public List<EmployeeAttendanceModel> GetAllUnpaidAttendanceRecordByWorkDateRange(DateTime startDate, DateTime endDate)
        {
            string query = @"SELECT * 
                                FROM EmployeeAttendance AS EA
                                JOIN EmployeeShifts AS ES ON EA.shiftId=ES.id
                                JOIN Employees AS E ON EA.employeeNumber=E.employeeNumber
                                WHERE EA.workDate BETWEEN @StartDate AND @EndDate AND EA.isPaid=false
                                ORDER BY EA.id DESC";

            List<EmployeeAttendanceModel> results = new List<EmployeeAttendanceModel>();

            using (var conn = _dbConnFactory.CreateConnection())
            {
                results = conn.Query<EmployeeAttendanceModel, EmployeeShiftModel, EmployeeModel, EmployeeAttendanceModel>(query,
                        (EA, ES, E) => {

                            EA.Shift = ES;
                            EA.Employee = E;

                            return EA;
                        },
                        new
                        {
                            StartDate = startDate.ToString("yyyy-MM-dd"),
                            EndDate = endDate.ToString("yyyy-MM-dd")
                        }).ToList();
                conn.Close();
            }

            this.ProvideShiftDays(results);

            return results;
        }

        public EmployeeAttendanceModel GetEmployeeAttendanceByWorkDate(string employeeNumber, DateTime workDate)
        {
            string query = @"SELECT * FROM EmployeeAttendance 
                                WHERE employeeNumber=@EmployeeNumber AND workDate=@WorkDate";

            return this.GetFirstOrDefault(query, new { EmployeeNumber = employeeNumber, WorkDate = workDate.ToString("yyyy-MM-dd") });
        }


        public List<EmployeeAttendanceModel> GetEmployeeAttendanceByPayslipId(string employeeNumber, long payslipId)
        {
            string query = "SELECT * FROM EmployeeAttendance WHERE isDeleted=false AND payslipId=@PayslipId AND employeeNumber=@EmployeeNumber";

            return this.GetAll(query, new {
                PayslipId = payslipId,
                EmployeeNumber = employeeNumber
            });
        }
    }
}
