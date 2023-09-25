using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesShared.POSManagement.CustomModels
{
    public class ProductOrdersReport
    {
        public string ProdName { get; set; }

        public string ProdCategory { get; set; }

        public decimal TotalSales { get; set; }

        public int Qty { get; set; }

        public decimal ProductCurrentPrice { get; set; }
    }
}
