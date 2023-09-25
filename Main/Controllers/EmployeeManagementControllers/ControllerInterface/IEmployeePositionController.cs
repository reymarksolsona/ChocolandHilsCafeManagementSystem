using EntitiesShared.EmployeeManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.ControllerInterface
{
    public interface IEmployeePositionController
    {
        EntityResult<string> UpdateNumberOfWorkingDaysInAMonth(decimal newNumberOfDays);
        EntityResult<string> Delete(long positionId);
        EntityResult<EmployeePositionModel> Save(EmployeePositionModel input, bool isNew);
    }
}
