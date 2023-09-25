using DapperGenericDataManager;
using EntitiesShared.OtherDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.OtherDataManagement.Contracts
{
    public interface IBranchData : IDataManagerCRUD<BranchModel>
    {
        List<BranchModel> GetAllNotDeleted();
        BranchModel GetByBranchName(string branchName);
        BranchModel GetByTellNo(string TellNo);
    }
}
