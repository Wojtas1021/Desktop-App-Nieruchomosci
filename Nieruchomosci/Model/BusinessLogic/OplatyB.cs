using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.BusinessLogic
{
    class OplatyB : DatabaseClass
    {
        #region
        public OplatyB(NieruchomosciEntities nieruchomosciEntities)
            : base(nieruchomosciEntities)
        {
        }
        #endregion
        #region GetDataFunction
        // ta funkcja pobiera wszystkie usługi z bazy danych i zwraca ich Id i Value w postaci nazwy i kodu w usługi
        public IQueryable<KeyAndValue> GetOplatyKeyAndValue()
        {
            return
                (
                    from oplaty in nieruchomosciEntities.Oplaty
                    select new KeyAndValue
                    {
                        Key = oplaty.IdOplaty,
                        Value = oplaty.Nazwa
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
