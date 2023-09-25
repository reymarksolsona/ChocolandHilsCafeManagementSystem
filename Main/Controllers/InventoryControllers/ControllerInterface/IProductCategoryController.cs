using EntitiesShared.InventoryManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.ControllerInterface
{
    public interface IProductCategoryController
    {
        EntityResult<string> Delete(long categoryId);
        EntityResult<ProductCategoryModel> Save(ProductCategoryModel input, bool isNew);
    }
}
