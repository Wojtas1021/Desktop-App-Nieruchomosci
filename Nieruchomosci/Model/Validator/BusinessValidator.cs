using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.Validator
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
        public static string SprawdzCzyLiczba(decimal? cena)
        {
            try
            {
                return null;
            }
            catch(Exception) { return "podana wartość nie jest liczbą"; };
        }
        public static string ValidateNip(string nip)
        {
            if (String.IsNullOrEmpty(nip))
                return "Proszę o wpisanie numeru nip.";
            else if (nip.Length < 10)
                return "Numer nip powinien zawierać conajmniej 10 liczb";
            else
                return String.Empty;
        }

    }
}

