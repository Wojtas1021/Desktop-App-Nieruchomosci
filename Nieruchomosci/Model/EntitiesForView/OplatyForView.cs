using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.EntitiesForView
{
    public class OplatyForView
    {
        public int IdOplaty { get; set; }
        public string Nazwa { get; set; }
        public string JednostkaMiarySymbol { get; set; }
        public decimal? CenaNetto { get; set; }
        public decimal? StawkaVatWartosc { get; set; }

    }
}