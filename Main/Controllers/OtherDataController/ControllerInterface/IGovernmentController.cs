using EntitiesShared.OtherDataManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.OtherDataController.ControllerInterface
{
    public interface IGovernmentController
    {
        EntityResult<GovernmentAgencyModel> Save(GovernmentAgencyModel input, bool isNew);
        EntityResult<string> Delete(long agencyId);

        EntityResult<GovernmentAgencyModel> GetById(long Id);
        ListOfEntityResult<GovernmentAgencyModel> GetAll();
    }
}
