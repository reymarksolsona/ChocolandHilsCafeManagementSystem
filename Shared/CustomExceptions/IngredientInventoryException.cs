using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CustomExceptions
{
    public class IngredientInventoryException : Exception
    {
        public IngredientInventoryException()
        {

        }

        public IngredientInventoryException(string errors) : base(String.Format("Ingredient inventory: {0}", errors))
        {

        }
    }
}
