using EntitiesShared.PayrollManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.RequestControllers.Validators
{
    public class EmployeeCashAdvanceRequestValidator : AbstractValidator<EmployeeCashAdvanceRequestModel>
    {
        public EmployeeCashAdvanceRequestValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(e => e.EmployeeNumber).NotEmpty();
            RuleFor(e => e.Amount).NotEmpty().NotEqual(0);
            RuleFor(e => e.EmployeeRemarks).NotEmpty();
            RuleFor(e => e.NeedOnDate).NotEmpty();
            RuleFor(e => e.ApprovalStatus).NotNull();
        }
    }
}
