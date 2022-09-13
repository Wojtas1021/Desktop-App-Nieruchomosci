using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.EntitiesForView
{
    class KontrahenciForView
    {
        public int IdKontrahenta { get; set; }
        public string Nazwa { get; set; }
        public string Nip { get; set; }
        public string Regon { get; set; }
        public string RodzajKontrahentaNazwa { get; set; }
        public string KontrahentAdres { get; set; }
        public string Telefon1 { get; set; }
        public string Telefon2 { get; set; }
        public string Emial{ get; set; }
        public string Fax { get; set; }
        public string Url{ get; set; }

    }
}
