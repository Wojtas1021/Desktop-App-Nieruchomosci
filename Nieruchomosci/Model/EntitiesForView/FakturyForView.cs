using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.EntitiesForView
{
    public class FakturyForView
    {
        public int IdFaktury { get; set; }
        public string Numer { get; set; }
        public string WspolnotaMieszkaniowaNazwa { get; set; }
        //te pola są zamiast klucza obcego
        public string KontrahentaNazwa { get; set; }
        public string KontrahentaNip{ get; set; }
        public string KontrahentaAdres { get; set; }
        public DateTime? DataWystawienia { get; set; }

        public DateTime? TerminPlatnosci { get; set; }
        //to pole jest zamiast idSposobuPlatnosci
        public string SposobPlatnosciNazwa { get; set; }
    }
}
