using EntitiesShared.UserManagement.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.UserManagementControllers.Validator
{
    public class UserAddUpdateValidator : AbstractValidator<UserAddUpdateModel>
    {
        public UserAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.FullName).NotEmpty();

            When(x => string.IsNullOrWhiteSpace(x.Password) == false, () =>
            {
                RuleFor(x => x.Password).MinimumLength(5);
            });
        }
    }
}
