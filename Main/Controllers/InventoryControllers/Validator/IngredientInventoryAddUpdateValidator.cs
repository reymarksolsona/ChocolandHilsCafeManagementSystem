using EntitiesShared.InventoryManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.Validator
{
    public class IngredientInventoryAddUpdateValidator : AbstractValidator<IngredientInventoryModel>
    {
        public IngredientInventoryAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.IngredientId).NotNull().NotEmpty();
            RuleFor(x => x.InitialQtyValue).NotNull().NotEmpty();
            RuleFor(x => x.RemainingQtyValue).NotNull().NotEmpty();
            RuleFor(x => x.UnitCost).NotNull().NotEmpty();
            RuleFor(x => x.ExpirationDate).NotNull().NotEmpty();
        }
    }
}
