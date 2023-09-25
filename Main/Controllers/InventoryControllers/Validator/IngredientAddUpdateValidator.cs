using EntitiesShared.InventoryManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.Validator
{
    public class IngredientAddUpdateValidator : AbstractValidator<IngredientModel>
    {
        public IngredientAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.IngName).NotEmpty();
            RuleFor(x => x.UOM).NotNull();
        }
    }
}
