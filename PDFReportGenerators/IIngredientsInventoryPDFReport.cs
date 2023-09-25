using EntitiesShared.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFReportGenerators
{
    public interface IIngredientsInventoryPDFReport
    {
        void GenerateIngredientInventoryReport(List<IngredientModel> ingredients);
    }
}
