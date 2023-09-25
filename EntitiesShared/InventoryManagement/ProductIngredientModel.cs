using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.InventoryManagement
{
    [Table("ProductIngredients")]
    public class ProductIngredientModel : BaseLongModel
    {
        public long ProductId { get; set; }


        private ProductModel _product;
        [Write(false)]
        [Computed]
        public ProductModel Product
        {
            get { return _product; }
            set { _product = value; }
        }


        public long IngredientId { get; set; }


        private IngredientModel _ingredient;
        [Write(false)]
        [Computed]
        public IngredientModel Ingredient
        {
            get { return _ingredient; }
            set { _ingredient = value; }
        }


        public StaticData.UOM UOM { get; set; }

        public decimal QtyValue { get; set; }
    }
}
