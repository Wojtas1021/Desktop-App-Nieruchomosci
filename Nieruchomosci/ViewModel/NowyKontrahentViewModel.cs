using GalaSoft.MvvmLight.Messaging;
using Nieruchomosci.Helpers;
using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using Nieruchomosci.Model.Validator;
using Nieruchomosci.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nieruchomosci.ViewModel
{
    public class NowyKontrahentViewModel : JedenViewModel<Kontrahenci>, IDataErrorInfo
    {
    #region Fields
    private BaseCommand _ShowAdresy;
    #endregion
    #region Constructor
    public NowyKontrahentViewModel()
        : base("Kontrahent")
    {
        item = new Kontrahenci();
        Messenger.Default.Register<AdresForView>(this, getWybranyAdres);
    }
    #endregion
    #region Command
    public ICommand ShowAdresy
    {
        get
        {
            if (_ShowAdresy == null)
                _ShowAdresy = new BaseCommand(() => Messenger.Default.Send("AdresyShow"));
            return _ShowAdresy;
        }
    }
        public IQueryable<RodzajKontrahenta> RodzajeKontrahentaComboboxItem
        {
            get
            {
                return
                    (
                    from rodzajeKontrahtent in nieruchomosciEntities.RodzajKontrahenta
                    where rodzajeKontrahtent.CzyAktywny == true
                    select rodzajeKontrahtent
                ).ToList().AsQueryable();
            }
        }
        #endregion
        #region Properties
        //dla każdego pola edytowalnego na interface.. tworzymy propertiesa
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
        public int? IdAdresu
        {
            get
            {
                return item.IdAdresu;
            }
            set
            {
                if (item.IdAdresu != value)
                {
                    item.IdAdresu = value;
                    base.OnPropertyChanged(() => IdAdresu);
                }
            }
        }
        public int? IdRodzajuKontrahenta
        {
            get
            {
                return item.IdRodzajuKontrahenta;
            }
            set
            {
                if (item.IdRodzajuKontrahenta != value)
                {
                    item.IdRodzajuKontrahenta = value;
                    base.OnPropertyChanged(() => IdRodzajuKontrahenta);
                }
            }
        }
        public string _KontrahentRodzajNazwa;
        public string KontrahentRodzajNazwa
    {
        get
        {
            return _KontrahentRodzajNazwa;
        }
        set
        {
            if (_KontrahentRodzajNazwa != value)
            {
                _KontrahentRodzajNazwa = value;
                base.OnPropertyChanged(() => KontrahentRodzajNazwa);
            }
        }
    }
    public string _AdresKraj;
    public string AdresKraj
    {
        get
        {
            return _AdresKraj;
        }
        set
        {
            if (_AdresKraj != value)
            {
                _AdresKraj = value;
                base.OnPropertyChanged(() => AdresKraj);
            }
        }
    }
    public string _AdresMiasto;
    public string AdresMiasto
    {
        get
        {
            return _AdresMiasto;
        }
        set
        {
            if (_AdresMiasto != value)
            {
                _AdresMiasto = value;
                base.OnPropertyChanged(() => AdresMiasto);
            }
        }
    }
    public string _AdresUlica;
    public string AdresUlica
    {
        get
        {
            return _AdresUlica;
        }
        set
        {
            if (_AdresUlica != value)
            {
                _AdresUlica = value;
                base.OnPropertyChanged(() => AdresUlica);
            }
        }
    }
    public string _AdresNumer;
    public string AdresNumer
    {
        get
        {
            return _AdresNumer;
        }
        set
        {
            if (_AdresNumer != value)
            {
                _AdresNumer = value;
                base.OnPropertyChanged(() => AdresNumer);
            }
        }
    }
    public string _AdresWojewodztwo;
    public string AdresWojewodztwo
    {
        get
        {
            return _AdresWojewodztwo;
        }
        set
        {
            if (_AdresWojewodztwo != value)
            {
                _AdresWojewodztwo = value;
                base.OnPropertyChanged(() => AdresWojewodztwo);
            }
        }
    }
    public string _AdresPowiat;
    public string AdresPowiat
    {
        get
        {
            return _AdresPowiat;
        }
        set
        {
            if (_AdresPowiat != value)
            {
                _AdresPowiat = value;
                base.OnPropertyChanged(() => AdresPowiat);
            }
        }
    }
    public string _AdresGmina;
    public string AdresGmina
    {
        get
        {
            return _AdresGmina;
        }
        set
        {
            if (_AdresGmina != value)
            {
                _AdresGmina = value;
                base.OnPropertyChanged(() => AdresGmina);
            }
        }
    }
    public string _AdresPoczta;
    public string AdresPoczta
    {
        get
        {
            return _AdresPoczta;
        }
        set
        {
            if (_AdresPoczta != value)
            {
                _AdresPoczta = value;
                base.OnPropertyChanged(() => AdresPoczta);
            }
        }
    }
    public string _AdresKodPocztowy;
    public string AdresKodPocztowy
    {
        get
        {
            return _AdresKodPocztowy;
        }
        set
        {
            if (_AdresKodPocztowy != value)
            {
                _AdresKodPocztowy = value;
                base.OnPropertyChanged(() => AdresKodPocztowy);
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
    public string Regon
    {
        get
        {
            return item.Regon;
        }
        set
        {
            if (item.Regon != value)
            {
                item.Regon = value;
                base.OnPropertyChanged(() => Regon);
            }
        }
    }
    public string Fax
    {
        get
        {
            return item.Fax;
        }
        set
        {
            if (item.Fax != value)
            {
                item.Fax = value;
                base.OnPropertyChanged(() => Fax);
            }
        }
    }
    public  string Email
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
    public string Url
    {
        get
        {
            return item.Url;
        }
        set
        {
            if (item.Url != value)
            {
                item.Url = value;
                base.OnPropertyChanged(() => Url);
            }
        }
    }
    public string Dokument
    {
        get
        {
            return item.Dokument;
        }
        set
        {
            if (item.Dokument != value)
            {
                item.Dokument = value;
                base.OnPropertyChanged(() => Dokument);
            }
        }
    }
        public string Telefon1
        {
            get
            {
                return item.Telefon1;
            }
            set
            {
                if (item.Telefon1 != value)
                {
                    item.Telefon1 = value;
                    base.OnPropertyChanged(() => Telefon1);
                }
            }
        }
        public string Telefon2
        {
            get
            {
                return item.Telefon2;
            }
            set
            {
                if (item.Telefon2 != value)
                {
                    item.Telefon2 = value;
                    base.OnPropertyChanged(() => Telefon2);
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
                if (name == "Nip")
                {
                  // komunikat = BusinessValidator.ValidateNip(this.Nip);
                }
                if (name == "Regon")
                {
                  //  komunikat = BusinessValidator.IsValidREGON(this.Regon); 
                }
                return komunikat;
            }
        }
        //czy przepuścić dalej
        //tutaj dezydujemy, które elementy powinny być poprawne przed zapisem danych
        //jeżeli pomimo błedu chcemu umożliwić użytkownikowi na zapis, kasujemy 
        public override bool isValid()
        {
            if (this["Nip"] == null && this["Regon"] == null)
                return true;
            return false;
        }
        #endregion
        #region Helpers
        public override void Save()
    {
        item.CzyAktywny = true;
        //do lokalnej kolekcji wspolnot dodajemy nową wspolnotę
        nieruchomosciEntities.Kontrahenci.Add(item);
        //wysylamy zmiany do bazy danych
        nieruchomosciEntities.SaveChanges();
    }
    private void getWybranyAdres(AdresForView adres)
    {
        IdAdresu = adres.IdAdresu;
        AdresKraj = adres.Kraj;
        AdresMiasto = adres.Miasto;
        AdresUlica = adres.Ulica;
        AdresNumer = adres.NumerDomu;
        AdresWojewodztwo = adres.Wojewodztwo;
        AdresPowiat = adres.Powiat;
        AdresGmina = adres.Gmina;
        AdresPoczta = adres.Poczta;
        AdresKodPocztowy = adres.KodPocztowy;

    }
    #endregion
    }
}
