using DapperGenericDataManager;
using DataAccess.Data.OtherDataManagement.Contracts;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.OtherDataManagement.Implementations
{
    public class LeaveTypeData : DataManagerCRUD<LeaveTypeModel>, ILeaveTypeData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public LeaveTypeData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public List<LeaveTypeModel> GetAllNotDeleted()
        {
            string query = "SELECT * FROM LeaveTypes WHERE isDeleted=False";
            return this.GetAll(query);
        }
    }
}
