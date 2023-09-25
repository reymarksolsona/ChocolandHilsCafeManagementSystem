using EntitiesShared.InventoryManagement;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.Validator
{
    public class ProductAddUpdateValidator : AbstractValidator<ProductModel>
    {
        public ProductAddUpdateValidator()
        {
            this.CascadeMode = CascadeMode.Stop;
            RuleFor(x => x.ProdName).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.PricePerOrder).NotEmpty();
        }
    }
}
