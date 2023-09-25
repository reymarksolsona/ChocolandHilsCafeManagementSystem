using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("Ingredients")]
    public class IngredientModel : BaseLongModel
    {
        public long CategoryId { get; set; }

        private IngredientCategoryModel _category;
        [Write(false)]
        [Computed]
        public IngredientCategoryModel Category
        {
            get { return _category; }
            set { _category = value; }
        }


        public string IngName { get; set; }

        public StaticData.UOM UOM { get; set; }


        [Write(false)]
        [Computed]
        public decimal RemainingQtyValue 
        {
            get;set;
        }


        private IngredientInventoryModel _inventory;
        [Write(false)]
        [Computed]
        public IngredientInventoryModel Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

    }
}
