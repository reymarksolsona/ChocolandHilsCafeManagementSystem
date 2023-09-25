using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.POSManagement.CustomModels
{
    public class ComboMealOrdersReport
    {
        public string Title { get; set; }

        public decimal TotalSales { get; set; }

        public int Qty { get; set; }

        public decimal ComboMealCurrentPrice { get; set; }
    }
}
