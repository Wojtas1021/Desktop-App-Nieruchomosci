using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.EntitiesForView
{
    class StawkiVatForView
    {
        public int IdStawkiVat { get; set; }
        public string Symbol { get; set; }
        public decimal? Wartosc { get; set; }
        public string Uwagi { get; set; }
    }
}
