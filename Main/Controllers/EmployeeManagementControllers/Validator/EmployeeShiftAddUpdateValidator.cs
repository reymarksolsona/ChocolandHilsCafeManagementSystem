using EntitiesShared.EmployeeManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.Validator
{
    public class EmployeeShiftAddUpdateValidator : AbstractValidator<EmployeeShiftModel>
    {
        public EmployeeShiftAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Shift).NotEmpty();
            RuleFor(x => x.StartTime).NotEmpty();
            RuleFor(x => x.NumberOfHrs).NotEmpty().NotEqual(0);
            RuleFor(x => x.BreakTime).NotEmpty();
            RuleFor(x => x.BreakTimeHrs).NotEmpty().NotEqual(0);

            When(x => x.NumberOfHrs != 0 && x.StartTime != DateTime.MinValue, () => {
                RuleFor(x => x.EndTime).NotEmpty();
            });
        }
    }
}
