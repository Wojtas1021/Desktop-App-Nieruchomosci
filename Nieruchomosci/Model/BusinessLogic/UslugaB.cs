using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.BusinessLogic
{
    //wtej klasie beda znajdowały sie wszsytkie funkcję obliczjące lub pobierajace dane w oparciu głównie o tabele usługi
    public class UslugaB : DatabaseClass
    {
        #region
        public UslugaB(NieruchomosciEntities nieruchomosciEntities)
            :base(nieruchomosciEntities)
        {
        }
        #endregion
        #region GetDataFunction
        // ta funkcja pobiera wszystkie usługi z bazy danych i zwraca ich Id i Value w postaci nazwy i kodu w usługi
        public IQueryable<KeyAndValue> GetUslugiKeyAndValue()
        {
            return
                (
                    from usluga in nieruchomosciEntities.Uslugi
                    select new KeyAndValue
                    {
                        Key = usluga.IdUslugi,
                        Value = usluga.Nazwa
                    }

                ).ToList().AsQueryable();
        }
        #endregion
    }
}
