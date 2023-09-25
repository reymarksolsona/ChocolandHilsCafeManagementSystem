using EntitiesShared.EmployeeManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.Validator
{
    public class EmployeePositionAddUpdateValidator : AbstractValidator<EmployeePositionModel>
    {
        public EmployeePositionAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(e => e.Title).NotEmpty();
            RuleFor(e => e.DailyRate).NotEmpty();
        }
    }
}
