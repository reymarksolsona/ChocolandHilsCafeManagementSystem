using EntitiesShared.OtherDataManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.OtherDataController.Validator
{
    public class LeaveTypeAddUpdateValidator : AbstractValidator<LeaveTypeModel>
    {
        public LeaveTypeAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.LeaveType).NotEmpty();
            RuleFor(x => x.NumberOfDays).NotEmpty().NotEqual(0);
        }
    }
}
