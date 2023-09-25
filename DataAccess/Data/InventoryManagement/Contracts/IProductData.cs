using DapperGenericDataManager;
using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.InventoryManagement.Contracts
{
    public interface IProductData : IDataManagerCRUD<ProductModel>
    {
        bool MassUpdateProductCategory(long previousCategoryId, long newCategoryId);
        bool MassDeleteProductsByCategory(long categoryId);
        List<ProductModel> GetAllByCategory(long categoryId);
        List<ProductModel> GetAllNotDeleted();
    }
}
