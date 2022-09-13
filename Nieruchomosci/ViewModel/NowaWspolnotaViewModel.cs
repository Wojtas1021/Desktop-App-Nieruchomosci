using GalaSoft.MvvmLight.Messaging;
using Nieruchomosci.Helpers;
using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using Nieruchomosci.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nieruchomosci.ViewModel
{
    class NowaWspolnotaViewModel : JedenViewModel<WspolnotyMieszkaniowe>
    {
        #region Fields
        private BaseCommand _ShowAdresy;
        #endregion
        #region Constructor
        public NowaWspolnotaViewModel()
            :base("Wspolnota")
        {
            item = new WspolnotyMieszkaniowe();
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
                if(item.Kod !=value)
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
        public string Krs
        {
            get
            {
                return item.Krs;
            }
            set
            {
                if (item.Krs != value)
                {
                    item.Krs = value;
                    base.OnPropertyChanged(() => Krs);
                }
            }
        }
        public DateTime? DataPowstania
        {
            get
            {
                return item.DataPowstania;
            }
            set
            {
                if (item.DataPowstania != value)
                {
                    item.DataPowstania = value;
                    base.OnPropertyChanged(() => DataPowstania);
                }
            }
        }
        public DateTime? PoczatkowyRokKsiegowy
        {
            get
            {
                return item.PoczatkowyRokKsiegowy;
            }
            set
            {
                if (item.PoczatkowyRokKsiegowy != value)
                {
                    item.PoczatkowyRokKsiegowy = value;
                    base.OnPropertyChanged(() => PoczatkowyRokKsiegowy);
                }
            }
        }
        public DateTime? BiezacyRokKsiegowy
        {
            get
            {
                return item.BiezacyRokKsiegowy;
            }
            set
            {
                if (item.BiezacyRokKsiegowy != value)
                {
                    item.BiezacyRokKsiegowy = value;
                    base.OnPropertyChanged(() => BiezacyRokKsiegowy);
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
                if (item.Uwagi!= value)
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
            nieruchomosciEntities.WspolnotyMieszkaniowe.Add(item);
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
