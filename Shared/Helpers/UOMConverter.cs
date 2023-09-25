using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Helpers
{
    public class UOMConverter
    {

        public decimal kg_to_gram (decimal kg)
        {
            return kg * 1000;
        }

        public decimal gram_to_kg (decimal grams)
        {
            return grams / 1000;
        }

        public decimal ml_to_L (decimal ml)
        {
            return ml / 1000;
        }

        public decimal L_to_ml(decimal liter)
        {
            return liter * 1000;
        }

        public string gram_to_kg_format (decimal grams)
        {
            if (grams < 1000)
            {
                return $"{grams} g";
            }

            decimal kg = gram_to_kg(grams);

            return $"{kg} kg";
        }

        public string ml_to_L_format(decimal ml)
        {
            if (ml < 1000)
            {
                return $"{ml} ml";
            }

            decimal L = ml_to_L(ml);

            return $"{L} L";
        }

        public string pc_format(decimal pcs)
        {
            if (pcs < 1)
            {
                return "0";
            }

            if (pcs == 1)
            {
                return "1 pc";
            }

            return $"{pcs} pcs";
        }
    }
}
