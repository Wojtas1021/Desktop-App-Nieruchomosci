using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.EntitiesForView
{
    class AdresForView
    {
        public int IdAdresu { get; set; }
        public string Kraj { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string NumerDomu { get; set; }
        public string Wojewodztwo { get; set; }
        public string Powiat { get; set; }
        public string Gmina { get; set; }
        public string Poczta { get; set; }
        public string KodPocztowy { get; set; }
    }
}
