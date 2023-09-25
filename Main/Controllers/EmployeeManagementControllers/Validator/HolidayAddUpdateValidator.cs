using EntitiesShared.EmployeeManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.Validator
{
    public class HolidayAddUpdateValidator : AbstractValidator<HolidayModel>
    {
        public HolidayAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Holiday).NotEmpty();
            RuleFor(x => x.MonthAbbr).NotEmpty();
            RuleFor(x => x.DayNum).NotEmpty().GreaterThan(0);
        }
    }
}
