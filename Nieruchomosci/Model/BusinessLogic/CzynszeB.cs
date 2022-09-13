using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.BusinessLogic
{
    class CzynszeB : DatabaseClass
    {
        #region
        public CzynszeB(NieruchomosciEntities nieruchomosciEntities)
            : base(nieruchomosciEntities)
        {
        }
        #endregion
        #region GetDataFunction
        // ta funkcja pobiera wszystkie usługi z bazy danych i zwraca ich Id i Value w postaci nazwy i kodu w usługi
        public IQueryable<KeyAndValue> GetCzynszeKeyAndValue()
        {
            return
                (
                    from czynsze in nieruchomosciEntities.Czynsze
                    select new KeyAndValue
                    {
                        Key = czynsze.IdCzynszu,
                        Value = czynsze.WspolnotyMieszkaniowe.Nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
