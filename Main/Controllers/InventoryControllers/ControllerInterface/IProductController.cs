using EntitiesShared.InventoryManagement;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Controllers.InventoryControllers.ControllerInterface
{
    public interface IProductController
    {
        void SaveProductImageFileName(long productId, string fileName);
        EntityResult<ProductModel> Save(List<ProductIngredientModel> ingredients, ProductModel product, bool isNew);
    }
}
