using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.EntitiesForView
{
    public class WspolnotyForView
    {
        public int IdWspolnotyMieszkaniowej { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public string AdresWspolnota { get; set; }
        //public string AdresKraj { get; set; }
        //public string AdresMiasto { get; set; }
        //public string AdresUlica { get; set; }
        //public string AdresNumer { get; set; }
        //public string AdresWojewodztwo { get; set; }
        //public string AdresPowiat { get; set; }
        //public string AdresGmina { get; set; }
        //public string AdresPoczta { get; set; }
        //public string AdresKodPocztowy { get; set; }
        public string Nip { get; set; }
        public string Regon { get; set; }
        public string Krs { get; set; }
        public DateTime? DataPowstania { get; set; }
        public DateTime? PoczatkowyRokKsiegowy { get; set; }
        public DateTime? BiezacyRokKsiegowy { get; set; }
    }
}
