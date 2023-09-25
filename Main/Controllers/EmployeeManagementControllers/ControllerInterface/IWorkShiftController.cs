using EntitiesShared.EmployeeManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.ControllerInterface
{
    public interface IWorkShiftController
    {
        EntityResult<EmployeeShiftModel> Save(EmployeeShiftModel input, List<EmployeeShiftDayModel> shiftDays, bool isNew);
        EntityResult<string> Delete(long shiftId);

        EntityResult<EmployeeShiftModel> GetById(long Id);
        ListOfEntityResult<EmployeeShiftModel> GetAll();
    }
}
