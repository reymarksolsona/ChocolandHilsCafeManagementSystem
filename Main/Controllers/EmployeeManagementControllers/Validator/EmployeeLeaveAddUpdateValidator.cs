using EntitiesShared.EmployeeManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.Validator
{
    public class EmployeeLeaveAddUpdateValidator : AbstractValidator<EmployeeLeaveModel>
    {
        public EmployeeLeaveAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.LeaveId).NotEmpty();
            RuleFor(x => x.EmployeeNumber).NotEmpty();
            RuleFor(x => x.Reason).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
            RuleFor(x => x.NumberOfDays).NotEmpty().NotEqual(0).GreaterThan(0);
            RuleFor(x => x.RemainingDays).NotEmpty();
            RuleFor(x => x.CurrentYear).NotEmpty().NotEqual(0).GreaterThan(0);
        }
    }
}
