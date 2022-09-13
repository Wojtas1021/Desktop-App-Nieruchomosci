using GalaSoft.MvvmLight.Messaging;
using Nieruchomosci.Helpers;
using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using Nieruchomosci.ViewModel.Abstract;
using System;
using System.Linq;
using System.Windows.Input;

namespace Nieruchomosci.ViewModel
{
    public class NowaFakturaViewModel : JedenViewModel<Faktury>
    {
        #region Fields
        private BaseCommand _ShowKontrahenci;
        #endregion
        #region Konstruktor
        public NowaFakturaViewModel()
            : base("Faktura")
        {
            item = new Faktury();
            DataWystawienia = DateTime.Now;
            TerminPlatnosci = DateTime.Now;
            Messenger.Default.Register<KontrahenciForView>(this, getWybranyKontrahent);
        }
        #endregion
        #region Command
        public ICommand ShowKontrahenci
        {
            get
            {
                if (_ShowKontrahenci == null)
                    _ShowKontrahenci = new BaseCommand(() => Messenger.Default.Send("KontrahenciShow"));
                return _ShowKontrahenci;
            }
        }
        #endregion
        #region Properties
        //dla każdego pola istotnego do dodania faktury należy stworzyć propertiesea
        public string Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (item.Numer != value)
                {
                    item.Numer = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }
        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                if (item.DataWystawienia != value)
                {
                    item.DataWystawienia = value;
                    base.OnPropertyChanged(() => DataWystawienia);
                }
            }
        }
        public int? IdKontrakenta
        {
            get
            {
                return item.IdAdresuKontrahenta;
            }
            set
            {
                if (item.IdAdresuKontrahenta != value)
                {
                    item.IdAdresuKontrahenta = value;
                    base.OnPropertyChanged(() => IdKontrakenta);
                }
            }
        }
        private string _KontrahentNip;
        public string KontrahentNip
        {
            get
            {
                return _KontrahentNip;
            }
            set
            {
                if (_KontrahentNip != value)
                {
                    _KontrahentNip = value;
                    base.OnPropertyChanged(() => KontrahentNip);
                }
            }
        }
        private string _KontrahentNazwa;
        public string KontrahentNazwa
        {
            get
            {
                return _KontrahentNazwa;
            }
            set
            {
                if (_KontrahentNazwa != value)
                {
                    _KontrahentNazwa = value;
                    base.OnPropertyChanged(() => KontrahentNazwa);
                }
            }
        }
        private string _KontrahentAdres;
        public string KontrahentAdres
        {
            get
            {
                return _KontrahentAdres;
            }
            set
            {
                if (_KontrahentAdres != value)
                {
                    _KontrahentAdres = value;
                    base.OnPropertyChanged(() => KontrahentAdres);
                }
            }
        }
        //jeżeli w comboboxie przy rozwinięciu listy chcemy wyświetlić kilka pól jednoczeście do należy zastosowac klasę KeyAndValue
        //public IQueryable<KeyAndValue> KontrachenciComboboxItem
        //{
        //    get
        //    {
        //        return
        //            (
        //            from kontrahent in nieruchomosciEntities.Kontrahenci
        //            where kontrahent.CzyAktywny == true
        //            select new KeyAndValue
        //            {
        //                Key = kontrahent.IdKontrahenta,
        //                Value = kontrahent.Nazwa + " " + kontrahent.Nip + " " + kontrahent.Adres.Miejscowosc
        //            }
        //        ).ToList().AsQueryable();
        //    }
        //}
        public DateTime? TerminPlatnosci
        {
            get
            {
                return item.TerminPlatnosci;
            }
            set
            {
                if (item.TerminPlatnosci != value)
                {
                    item.TerminPlatnosci = value;
                    base.OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }
        public int? IdSposobuPlatnosci
        {
            get
            {
                return item.IdSposobuPlatnosci;
            }
            set
            {
                if (item.IdSposobuPlatnosci != value)
                {
                    item.IdSposobuPlatnosci = value;
                    base.OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }
        //to jest properties zeby działał combo box ze sposobami platnosci
        public IQueryable<SposobPlatnosci> SposobyPlantosciComboboxItem
        {
            get
            {
                return
                    (
                    from sposboPlatnosci in nieruchomosciEntities.SposobPlatnosci
                    where sposboPlatnosci.CzyAktywny == true
                    select sposboPlatnosci
                ).ToList().AsQueryable();
            }
        }
        public bool? CzyAktywny
        {
            get
            {
                return item.CzyAktywny;
            }
            set
            {
                if (item.CzyAktywny != value)
                {
                    item.CzyAktywny = value;
                    base.OnPropertyChanged(() => CzyAktywny);
                }
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            item.CzyAktywny = true;
            //do lokalnej kolekcji faktur dodajemy nowy fakturę
            nieruchomosciEntities.Faktury.Add(item);
            //wysyłamy zmiany do bazy danych
            nieruchomosciEntities.SaveChanges();
        }
        private void getWybranyKontrahent(KontrahenciForView kontrahent)
        {
            IdKontrakenta = kontrahent.IdKontrahenta;
            KontrahentNip = kontrahent.Nip;
            KontrahentNazwa = kontrahent.Nazwa;
            KontrahentAdres = kontrahent.KontrahentAdres;
        }
        #endregion 
    }
}
