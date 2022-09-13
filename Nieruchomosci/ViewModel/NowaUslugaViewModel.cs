using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.Validator;
using Nieruchomosci.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.ViewModel
{
    class NowaUslugaViewModel : JedenViewModel<Uslugi>, IDataErrorInfo // do obsługi validacji konieczne dziedzicznie interfacu IDataError
    {
        #region Constructor
        public NowaUslugaViewModel()
            : base("Usługa")
        {
            //torzymy...
            item = new Uslugi();
        }
        #endregion
        #region Properties
        //dla każdego pola edytowalnego na inter...... 
        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (item.Kod != value)
                {
                    item.Kod = value;
                    base.OnPropertyChanged(() => Kod);
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    base.OnPropertyChanged(() => Opis);
                }
            }
        }
        public string Uwagi
        {
            get
            {
                return item.Uwagi;
            }
            set
            {
                if (item.Uwagi != value)
                {
                    item.Uwagi = value;
                    base.OnPropertyChanged(() => Uwagi);
                }
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            item.CzyAktywny = true;
            //do lokalnej kolekcji towarów dodajemy nowy towar
            nieruchomosciEntities.Uslugi.Add(item);
            //wysyłamy zmiany do bazy danych
            nieruchomosciEntities.SaveChanges();
        }
        #endregion
        #region Validatory
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Nazwa")
                {
                    komunikat = StringValidator.SprawdzCzyZaczynaSieOdDluzej(this.Nazwa);
                }
                return komunikat;
            }
        }
        //czy przepuścić dalej
        //tutaj dezydujemy, które elementy powinny być poprawne przed zapisem danych
        //jeżeli pomimo błedu chcemu umożliwić użytkownikowi na zapis, kasujemy 
        public override bool isValid()
        {
            if (this["Nazwa"] == null) return true;
            return false;
        }
        #endregion
    }
}
