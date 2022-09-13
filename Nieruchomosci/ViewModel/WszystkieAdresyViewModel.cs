using GalaSoft.MvvmLight.Messaging;
using Nieruchomosci.Model.EntitiesForView;
using Nieruchomosci.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.ViewModel
{
    class WszystkieAdresyViewModel : WszystkieViewModel<AdresForView>
    {
        #region Constructor
        public WszystkieAdresyViewModel()
            : base("Adresy")
        {
        }
        #endregion
        #region Properties
        private AdresForView _WybranyAdres;
        public AdresForView WybranyAdres
        {
            get
            {
                return _WybranyAdres;
            }
            set
            {
                _WybranyAdres = value;
                // w tym miejscu wysyłam adres do okna wspolnota
                Messenger.Default.Send(_WybranyAdres);
                // zamykanie zakładki
                OnRequestClose();
            }
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            switch (SortField)
            {
                case "Kraj":
                    List = new ObservableCollection<AdresForView>(List.OrderBy(item => item.Kraj));
                    break;
                case "Miasto":
                    List = new ObservableCollection<AdresForView>(List.OrderBy(item => item.Miasto));
                    break;
                case "Ulica":
                    List = new ObservableCollection<AdresForView>(List.OrderBy(item => item.Ulica));
                    break;
            }
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Miasto", "Kraj", "Ulica"};
        }
        public override void find()
        {
            load();
            switch (FindField)
            {
                case "Kraj":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.Kraj != null && item.Kraj.StartsWith(FindTextBox)));
                    break;
                case "Miasto":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.Miasto != null && item.Miasto.StartsWith(FindTextBox)));
                    break;
                case "Ulica":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
                    break;
                case "NumerDomu":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.NumerDomu != null && item.NumerDomu.StartsWith(FindTextBox)));
                    break;
                case "Wojewodztwo":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.Wojewodztwo != null && item.Wojewodztwo.StartsWith(FindTextBox)));
                    break;
                case "Powiat":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.Powiat != null && item.Powiat.StartsWith(FindTextBox)));
                    break;
                case "KodPocztowy":
                    List = new ObservableCollection<AdresForView>(List.Where(item => item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
                    break;
            }
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Kraj", "Miasto", "Ulica", "NumerDomu", "Wojewodztwo", "Powiat", "KodPocztowy" };
        }
        #endregion
        #region Helpers
        public override void load()
        {
            //to listy przekazuje z bazy danych wszystkie wspolnoty
            List = new ObservableCollection<AdresForView>
                (
                    //nieruchomosciEntities.WspolnotyMieszkaniowe
                    from adresy in nieruchomosciEntities.Adresy
                    where adresy.CzyAktywny == true
                    select new AdresForView
                    {
                        IdAdresu = adresy.IdAdresu,
                        Kraj = adresy.Kraj,
                        Miasto = adresy.Miasto,
                        Ulica = adresy.Ulica,
                        NumerDomu = adresy.NumerDomu,
                        Wojewodztwo = adresy.Wojewodztwo,
                        Powiat = adresy.Powiat,
                        Gmina = adresy.Gmina,
                        Poczta = adresy.Poczta,
                        KodPocztowy = adresy.KodPocztowy,
                    }
                );
        }
        #endregion
    }
}

