using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.Validator
{
    class StringValidator : Validator
    {
        //Wszystkie nasze funkcje będą zwracały komunikat z błędem jak ten błąd znajdą lub nulla gdy tego błędu nie będzie
        public static string SprawdzCzyZaczynaSieOdDluzej(string wartosc)
        {
            try
            {
                if (!char.IsUpper(wartosc, 0))
                {
                    return "Rozpocznij dużą literą";
                }
            }
            catch (Exception) { return "Niepoprawny string"; };
            return null;
        }
    }
}
