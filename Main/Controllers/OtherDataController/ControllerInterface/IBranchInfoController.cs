using EntitiesShared.OtherDataManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.OtherDataController.ControllerInterface
{
    public interface IBranchInfoController
    {
        EntityResult<string> Delete(long branchId);
        EntityResult<BranchModel> Save(BranchModel input, bool isNew);
    }
}
