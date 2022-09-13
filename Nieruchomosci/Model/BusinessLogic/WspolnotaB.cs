using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.BusinessLogic
{
    class WspolnotaB : DatabaseClass
    {
        #region
        public WspolnotaB(NieruchomosciEntities nieruchomosciEntities)
            : base(nieruchomosciEntities)
        {
        }
        #endregion
        #region GetDataFunction
        // ta funkcja pobiera wszystkie usługi z bazy danych i zwraca ich Id i Value w postaci nazwy i kodu w usługi
        public IQueryable<KeyAndValue> GetWspolnotyKeyAndValue()
        {
            return
                (
                    from wspolnota in nieruchomosciEntities.WspolnotyMieszkaniowe
                    select new KeyAndValue
                    {
                        Key = wspolnota.IdWspolnotyMieszkaniowej,
                        Value = wspolnota.Nazwa
                    }

                ).ToList().AsQueryable();
        }
        #endregion
    }
}
