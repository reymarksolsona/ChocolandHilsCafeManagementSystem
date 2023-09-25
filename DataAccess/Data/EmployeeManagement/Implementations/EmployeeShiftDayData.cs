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
    public class EmployeeShiftDayData : DataManagerCRUD<EmployeeShiftDayModel>, IEmployeeShiftDayData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public EmployeeShiftDayData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<EmployeeShiftDayModel> GetByShiftId(long shiftId)
        {
            string query = @"SELECT * FROM EmployeeShiftDays WHERE isDeleted=false AND shiftId=@ShiftId";
            return this.GetAll(query, new { ShiftId = shiftId });
        }
    }
}
