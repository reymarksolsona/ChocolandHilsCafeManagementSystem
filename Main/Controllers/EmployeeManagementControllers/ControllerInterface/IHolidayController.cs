using EntitiesShared.EmployeeManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.ControllerInterface
{
    public interface IHolidayController
    {
        EntityResult<HolidayModel> Save(HolidayModel input, bool isNew);
        EntityResult<string> Delete(long holidayId);
    }
}
