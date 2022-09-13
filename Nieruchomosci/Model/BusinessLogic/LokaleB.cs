using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.BusinessLogic
{
    class LokaleB : DatabaseClass
    {
        #region
        public LokaleB(NieruchomosciEntities nieruchomosciEntities)
            : base(nieruchomosciEntities)
        {
        }
        #endregion
        #region GetDataFunction
        // ta funkcja pobiera wszystkie usługi z bazy danych i zwraca ich Id i Value w postaci nazwy i kodu w usługi
        public IQueryable<KeyAndValue> GetLokaleKeyAndValue()
        {
            return
                (
                    from lokale in nieruchomosciEntities.Lokale
                    select new KeyAndValue
                    {
                        Key = lokale.IdLokalu,
                        Value = lokale.Budynki.Ulica +" "+lokale.Klatka +"/"+ lokale.NumerLokalu
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
