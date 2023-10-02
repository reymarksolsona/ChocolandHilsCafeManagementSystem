using EntitiesShared.EmployeeManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.EmployeeManagementControllers.Validator
{
    public class EmployeeAddUpdateValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(e => e.EmployeeNumber).NotEmpty();
            RuleFor(e => e.FirstName).NotEmpty();
            RuleFor(e => e.MiddleName).NotEmpty();
            RuleFor(e => e.LastName).NotEmpty();
            RuleFor(e => e.Address).NotEmpty();
            RuleFor(e => e.MobileNumber).NotEmpty()
                   .MinimumLength(11)
                   .MaximumLength(11)
                   .WithMessage("Mobile number must be 11 numbers");

            When(x => string.IsNullOrEmpty(x.EmailAddress) == false, () =>
            {
                RuleFor(e => e.EmailAddress).EmailAddress();
            });

            RuleFor(e => e.BirthDate).NotEmpty();
            //RuleFor(e => e.BranchAssign).NotEmpty();
            RuleFor(e => e.DateHire).NotEmpty();
            RuleFor(e => e.BranchId).NotEmpty();
            //RuleFor(e => e.PositionId).NotEmpty();
        }
    }
}
