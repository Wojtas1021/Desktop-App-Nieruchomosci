using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Validator
{
    class BusinessValidator : Validator
    {
        public static string SprawdzVat(decimal? vat)
        {
            try
            {
                if (vat < 0 || vat > 23)
                    return "Vat powinien być z przedziału od 0 do 23";
            }
            catch (Exception) { return "Zły vat"; };
            return null;
        }
    }
}
