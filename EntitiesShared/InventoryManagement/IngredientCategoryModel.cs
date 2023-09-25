using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("IngredientCategories")]
    public class IngredientCategoryModel : BaseLongModel
    {
        public string Category { get; set; }
    }
}
