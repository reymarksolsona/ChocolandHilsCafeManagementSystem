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
    public class EmployeeShiftData : DataManagerCRUD<EmployeeShiftModel>, IEmployeeShiftData
    {
        private readonly IDbConnectionFactory _dbConnFactory;
        private readonly IEmployeeShiftDayData _employeeShiftDayData;

        public EmployeeShiftData(IDbConnectionFactory dbConnFactory, IEmployeeShiftDayData employeeShiftDayData) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
            _employeeShiftDayData = employeeShiftDayData;
        }

        public EmployeeShiftModel GetById(long id)
        {
            string query = "SELECT * FROM EmployeeShifts WHERE isDeleted=false AND id=@Id";

            var shiftDetails = this.GetFirstOrDefault(query, new { Id = id });

            if (shiftDetails != null)
            {
                shiftDetails.ShiftDays = _employeeShiftDayData.GetByShiftId(shiftDetails.Id);
            }
            return shiftDetails;
        }

        public List<EmployeeShiftModel> GetAllNotDeleted ()
        {
            string query = @"SELECT * FROM EmployeeShifts WHERE isDeleted=false";
            return this.GetAll(query);
        }
    }
}
