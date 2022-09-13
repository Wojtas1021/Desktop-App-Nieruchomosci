using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.BusinessLogic
{
    class FakturaB : DatabaseClass
    {
        #region
        public FakturaB(NieruchomosciEntities nieruchomosciEntities)
            : base(nieruchomosciEntities)
        {
        }
        #endregion
        #region GetDataFunction
        // ta funkcja pobiera wszystkie usługi z bazy danych i zwraca ich Id i Value w postaci nazwy i kodu w usługi
        public IQueryable<KeyAndValue> GetFakturyKeyAndValue()
        {
            return
                (
                    from faktura in nieruchomosciEntities.Faktury
                    select new KeyAndValue
                    {
                        Key = faktura.IdFaktury,
                        Value = faktura.Numer
                    }

                ).ToList().AsQueryable();
        }
        #endregion
    }
}
