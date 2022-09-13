using Nieruchomosci.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.BusinessLogic
{
    public class RaportB : DatabaseClass
    {
        #region
        public RaportB(NieruchomosciEntities nieruchomosciEntities)
            : base(nieruchomosciEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public decimal? RaportOkresUsluga(int idUslugi, int idWspolnoty, int idFaktury, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                    from pozycja in nieruchomosciEntities.PozycjeFaktury
                    where
                        pozycja.IdUslugi == idUslugi &&
                        pozycja.Faktury.WspolnotyMieszkaniowe.IdWspolnotyMieszkaniowej == idWspolnoty &&
                        pozycja.IdFaktury == idFaktury &&
                        pozycja.Faktury.DataWystawienia >= dataOd &&
                        pozycja.Faktury.DataWystawienia <= dataDo
                    select pozycja.Ilosc * ((pozycja.StawkiVat.Wartosc * pozycja.CenaNetto) + pozycja.CenaNetto)
                ).Sum();
        }
        public decimal? FakturaRazem(int idWspolnoty, int idFaktury)
        {
            return
                (
                    from pozycja in nieruchomosciEntities.PozycjeFaktury
                    where
                        pozycja.Faktury.WspolnotyMieszkaniowe.IdWspolnotyMieszkaniowej == idWspolnoty &&
                        pozycja.IdFaktury == idFaktury
                    select pozycja.Ilosc * ((pozycja.StawkiVat.Wartosc * pozycja.CenaNetto) + pozycja.CenaNetto)
                ).Sum();
        }
        public decimal? UslugiRazem(int idWspolnoty )
        {
            return
                (
                    from pozycja in nieruchomosciEntities.PozycjeFaktury
                    where
                        pozycja.Faktury.WspolnotyMieszkaniowe.IdWspolnotyMieszkaniowej == idWspolnoty
                    select pozycja.CenaBrutto * pozycja.Ilosc
                ).Sum();
        }
        #endregion
    }
}
