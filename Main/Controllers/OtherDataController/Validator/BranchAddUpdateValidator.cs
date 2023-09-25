using EntitiesShared.OtherDataManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.OtherDataController.Validator
{
    public class BranchAddUpdateValidator : AbstractValidator<BranchModel>
    {
        public BranchAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.BranchName).NotEmpty();
            RuleFor(x => x.TellNo).NotEmpty().MinimumLength(11).MaximumLength(13);
            RuleFor(x => x.Address).NotEmpty();
        }
    }
}
