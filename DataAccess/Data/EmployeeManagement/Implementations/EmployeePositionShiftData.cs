using Dapper;
using DapperGenericDataManager;
using DataAccess.Data.EmployeeManagement.Contracts;
using EntitiesShared.EmployeeManagement;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.EmployeeManagement.Implementations
{
    public class EmployeePositionShiftData: DataManagerCRUD<EmployeePositionShiftModel>, IEmployeePositionShiftData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IEmployeeShiftDayData _employeeShiftDayData;

        public EmployeePositionShiftData(IDbConnectionFactory dbConnFactory, IEmployeeShiftDayData employeeShiftDayData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _employeeShiftDayData = employeeShiftDayData;
        }

        public void SavePositionsAndShifts(List<EmployeePositionShiftModel> positionShift)
        {

        }

        public List<EmployeePositionShiftModel> GetById(long id)
        {
            string query = @"select eps.id AS Id,eps.positionId as PositionId,ep.title  as Position,eps.shiftId as ShiftId, concat(es.shift, ' - from ', DATE_FORMAT(es.startTime,'%h:%i %p'), ' to ', DATE_FORMAT(es.endTime,'%h:%i %p')) as Shift, ep.dailyRate as DailyRate from employeepositionshift eps
                            join employeepositions ep on ep.id = eps.positionId
                            join employeeshifts es on es.id = eps.shiftId
                            WHERE eps.employeeId = @Id";

            var result = this.GetAll(query, new { Id = id });

            if (result.Any())
            {
                foreach (var item in result.ToList())
                {
                    item.WorkingDays = _employeeShiftDayData.GetByShiftId(item.ShiftId);
                }
            }

            return result;
        }

        public bool DeleteById(long id)
        {
            try
            {
                string query = @"DELETE FROM EmployeePositionShift WHERE EmployeeId = @Id";

                using (var conn = _dbConnFactory.CreateConnection())
                {
                    conn.Execute(query,param: new {Id = id});
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
