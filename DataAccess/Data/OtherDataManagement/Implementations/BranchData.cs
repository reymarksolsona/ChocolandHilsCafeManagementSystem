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
    public class BranchData : DataManagerCRUD<BranchModel>, IBranchData
    {
        private readonly IDbConnectionFactory _dbConnFactory;

        public BranchData(IDbConnectionFactory dbConnFactory) :
            base(DataManagerCRUDEnums.DatabaseAdapter.mysqlconnection, dbConnFactory)
        {
            _dbConnFactory = dbConnFactory;
        }

        public BranchModel GetByTellNo(string TellNo)
        {
            string query = "SELECT * FROM Branches WHERE isDeleted = false AND tellNo = @TellNo";

            return this.GetFirstOrDefault(query, new { TellNo = TellNo });
        }

        public BranchModel GetByBranchName (string branchName)
        {
            string query = "SELECT * FROM Branches WHERE isDeleted = false AND branchName = @BranchName";

            return this.GetFirstOrDefault(query, new { BranchName = branchName });
        }
        public List<BranchModel> GetAllNotDeleted()
        {
            string query = "SELECT * FROM Branches WHERE isDeleted = false";
            return this.GetAll(query);
        }
    }
}
