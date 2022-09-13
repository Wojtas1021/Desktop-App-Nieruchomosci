using Nieruchomosci.Model.Entities;
using Nieruchomosci.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.ViewModel
{
    public class NowyAdresViewModel : JedenViewModel<Adresy>
    {
        #region Constructor
        public NowyAdresViewModel()
        : base("Adres")
        {
            item = new Adresy();
        }
        #endregion
        #region Properties
        public string Kraj
        {
            get
            {
                return item.Kraj;
            }
            set
            {
                if (item.Kraj != value)
                {
                    item.Kraj = value;
                    base.OnPropertyChanged(() => Kraj);
                }
            }
        }
        public string Miasto
        {
            get
            {
                return item.Miasto;
            }
            set
            {
                if (item.Miasto != value)
                {
                    item.Miasto = value;
                    base.OnPropertyChanged(() => Miasto);
                }
            }
        }
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                if (item.Ulica != value)
                {
                    item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string NumerDomu
        {
            get
            {
                return item.NumerDomu;
            }
            set
            {
                if (item.NumerDomu != value)
                {
                    item.NumerDomu = value;
                    base.OnPropertyChanged(() => NumerDomu);
                }
            }
        }
        public string Wojewodztwo
        {
            get
            {
                return item.Wojewodztwo;
            }
            set
            {
                if (item.Wojewodztwo != value)
                {
                    item.Wojewodztwo = value;
                    base.OnPropertyChanged(() => Wojewodztwo);
                }
            }
        }
        public string Powiat
        {
            get
            {
                return item.Powiat;
            }
            set
            {
                if (item.Powiat != value)
                {
                    item.Powiat = value;
                    base.OnPropertyChanged(() => Powiat);
                }
            }
        }
        public string Gmina
        {
            get
            {
                return item.Gmina;
            }
            set
            {
                if (item.Gmina != value)
                {
                    item.Gmina = value;
                    base.OnPropertyChanged(() => Gmina);
                }
            }
        }
        public string Poczta
        {
            get
            {
                return item.Poczta;
            }
            set
            {
                if (item.Poczta != value)
                {
                    item.Poczta = value;
                    base.OnPropertyChanged(() => Poczta);
                }
            }
        }
        public string KodPocztowy
        {
            get
            {
                return item.KodPocztowy;
            }
            set
            {
                if (item.KodPocztowy != value)
                {
                    item.KodPocztowy = value;
                    base.OnPropertyChanged(() => KodPocztowy);
                }
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            item.CzyAktywny = true;
            //do lokalnej kolekcji wspolnot dodajemy nową wspolnotę
            nieruchomosciEntities.Adresy.Add(item);
            //wysylamy zmiany do bazy danych
            nieruchomosciEntities.SaveChanges();
        }
        #endregion
    }
}