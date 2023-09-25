using EntitiesShared.InventoryManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.Validator
{
    public class ProductIngredientAddUpdateValidator : AbstractValidator<ProductIngredientModel>
    {
        public ProductIngredientAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            //RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.IngredientId).NotEmpty();
            RuleFor(x => x.UOM).NotNull();
            RuleFor(x => x.QtyValue).NotEmpty();
        }
    }
}
