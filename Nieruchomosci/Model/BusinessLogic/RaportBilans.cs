using Nieruchomosci.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.BusinessLogic
{
    class RaportBilans : DatabaseClass
    {
        #region
        public RaportBilans(NieruchomosciEntities nieruchomosciEntities)
            : base(nieruchomosciEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public decimal? sumaFundusz(int idWspolnoty)
        {
            return
                (
                    from czynsze in nieruchomosciEntities.Czynsze
                    where
                        czynsze.WspolnotyMieszkaniowe.IdWspolnotyMieszkaniowej == idWspolnoty &&
                        czynsze.IdOplaty == 8
                    select czynsze.Ilosc * ((czynsze.StawkiVat.Wartosc * czynsze.KwotaNetto) + czynsze.KwotaNetto)
                ).Sum();
        }
        public decimal? sumaWydatki(int idWspolnoty)
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