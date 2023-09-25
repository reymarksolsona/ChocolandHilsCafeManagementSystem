using EntitiesShared.EmployeeManagement;
using EntitiesShared.OtherDataManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.OtherDataController.ControllerInterface
{
    public interface ILeaveTypeController
    {
        EntityResult<LeaveTypeModel> Save(LeaveTypeModel input, bool isNew);
        EntityResult<string> Delete(long leaveTypeId);

        EntityResult<LeaveTypeModel> GetById(long Id);
        ListOfEntityResult<LeaveTypeModel> GetAll();
    }
}
