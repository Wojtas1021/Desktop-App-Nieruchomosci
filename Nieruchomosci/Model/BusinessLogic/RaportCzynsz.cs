using Nieruchomosci.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.BusinessLogic
{
    class RaportCzynsz : DatabaseClass
    {
        #region
        public RaportCzynsz(NieruchomosciEntities nieruchomosciEntities)
            : base(nieruchomosciEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public decimal? liczOplate(int idWspolnoty, int idLokalu, int idOplaty, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                    from czynsze in nieruchomosciEntities.Czynsze
                    where
                        czynsze.WspolnotyMieszkaniowe.IdWspolnotyMieszkaniowej == idWspolnoty &&
                        czynsze.Lokale.IdLokalu == idLokalu &&
                        czynsze.Oplaty.IdOplaty == idOplaty &&
                        czynsze.OdKiedy >= dataOd &&
                        czynsze.DoKiedy <= dataDo
                    select czynsze.Ilosc * ((czynsze.StawkiVat.Wartosc * czynsze.KwotaNetto) + czynsze.KwotaNetto)
                ).Sum();
        }
        public decimal? sumaCzynsz(int idWspolnoty, int idLokalu, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                    from czynsze in nieruchomosciEntities.Czynsze
                    where
                        czynsze.WspolnotyMieszkaniowe.IdWspolnotyMieszkaniowej == idWspolnoty &&
                        czynsze.IdLokalu == idLokalu &&
                        czynsze.OdKiedy >= dataOd &&
                        czynsze.DoKiedy <= dataDo
                    select czynsze.Ilosc * ((czynsze.StawkiVat.Wartosc * czynsze.KwotaNetto) + czynsze.KwotaNetto)
                ).Sum();
        }
        public decimal? sumaCzynsze(int idWspolnoty, DateTime dataOd, DateTime dataDo)
        {
            return
                (
                    from czynsze in nieruchomosciEntities.Czynsze
                    where
                        czynsze.WspolnotyMieszkaniowe.IdWspolnotyMieszkaniowej == idWspolnoty &&
                        czynsze.OdKiedy >= dataOd &&
                        czynsze.DoKiedy <= dataDo
                    select czynsze.Ilosc * ((czynsze.StawkiVat.Wartosc * czynsze.KwotaNetto) + czynsze.KwotaNetto)
                ).Sum();
        }
        #endregion
    }
}