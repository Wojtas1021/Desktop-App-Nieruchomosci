using Nieruchomosci.Model.Entities;
using Nieruchomosci.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.ViewModel
{
    public class DodajWlascicielaViewModel : JedenViewModel<Wlasciciele>
    {
        #region Constructor
        public DodajWlascicielaViewModel()
        : base("Właściciel")
        {
            item = new Wlasciciele();
        }
        #endregion
        #region Properties
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    base.OnPropertyChanged(() => Imie);
                }
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    base.OnPropertyChanged(() => Nazwisko);
                }
            }
        }
        public string Pesel
        {
            get
            {
                return item.Pesel;
            }
            set
            {
                if (item.Pesel != value)
                {
                    item.Pesel = value;
                    base.OnPropertyChanged(() => Pesel);
                }
            }
        }
        public string Nip
        {
            get
            {
                return item.Nip;
            }
            set
            {
                if (item.Nip != value)
                {
                    item.Nip = value;
                    base.OnPropertyChanged(() => Nip);
                }
            }
        }
        public string Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                if (item.Telefon != value)
                {
                    item.Telefon = value;
                    base.OnPropertyChanged(() => Telefon);
                }
            }
        }
        public string Email
        {
            get
            {
                return item.Email;
            }
            set
            {
                if (item.Email != value)
                {
                    item.Email = value;
                    base.OnPropertyChanged(() => Email);
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
            //do lokalnej kolekcji wspolnot dodajemy nową wspolnotę
            nieruchomosciEntities.Wlasciciele.Add(item);
            //wysylamy zmiany do bazy danych
            nieruchomosciEntities.SaveChanges();
        }
        #endregion
    }
}