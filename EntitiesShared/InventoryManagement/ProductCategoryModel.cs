using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("ProductCategories")]
    public class ProductCategoryModel : BaseLongModel
    {
        public string ProdCategory { get; set; }
    }
}
