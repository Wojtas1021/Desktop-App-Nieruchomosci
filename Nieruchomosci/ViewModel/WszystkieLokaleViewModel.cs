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
    class WszystkieLokaleViewModel : WszystkieViewModel<LokalForAllView>
    {
        #region Constructor
        public WszystkieLokaleViewModel()
            : base("Lokale")
        {
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            switch (SortField)
            {
                case "Miasto":
                    List = new ObservableCollection<LokalForAllView>(List.OrderBy(item => item.BudynekMiasto));
                    break;
                case "Ulica":
                    List = new ObservableCollection<LokalForAllView>(List.OrderBy(item => item.BudynekUlica));
                    break;
                case "Numer":
                    List = new ObservableCollection<LokalForAllView>(List.OrderBy(item => item.BudynekNumer));
                    break;
            }
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Miasto", "Ulica", "Numer"};
        }
        public override void find()
        {
            load();
            switch (FindField)
            {
                case "Miasto":
                    List = new ObservableCollection<LokalForAllView>(List.Where(item => item.BudynekMiasto != null && item.BudynekMiasto.StartsWith(FindTextBox)));
                    break;
                case "Ulica":
                    List = new ObservableCollection<LokalForAllView>(List.Where(item => item.BudynekUlica != null && item.BudynekUlica.StartsWith(FindTextBox)));
                    break;
                case "Numer":
                    List = new ObservableCollection<LokalForAllView>(List.Where(item => item.BudynekNumer != null && item.BudynekNumer.StartsWith(FindTextBox)));
                    break;
                case "Imię":
                    List = new ObservableCollection<LokalForAllView>(List.Where(item => item.WlascicielImie != null && item.WlascicielImie.StartsWith(FindTextBox)));
                    break;
                case "Nazwisko":
                    List = new ObservableCollection<LokalForAllView>(List.Where(item => item.WlascicielNazwisko != null && item.WlascicielNazwisko.StartsWith(FindTextBox)));
                    break;
                case "Wspólnota mieszkaniowa":
                    List = new ObservableCollection<LokalForAllView>(List.Where(item => item.WspolnotaNazwa != null && item.WspolnotaNazwa.StartsWith(FindTextBox)));
                    break;
            }
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Miasto", "Ulica", "Numer", "Imie", "Nazwisko", "Wspólnota mieszkaniowa" };
        }
        #endregion
        #region Helpers
        public override void load()
        {
            //to listy przekazuje z bazy danych wszystkie wspolnoty
            List = new ObservableCollection<LokalForAllView>
                (
                    //nieruchomosciEntities.WspolnotyMieszkaniowe
                    from lokale in nieruchomosciEntities.LokaleWspolnoty
                    where lokale.CzyAktywny == true
                    select new LokalForAllView
                    {
                        IdLokaluWspolnoty = lokale.IdLokaluWspolnoty,
                        WspolnotaNazwa = lokale.WspolnotyMieszkaniowe.Nazwa,
                        BudynekMiasto = lokale.Lokale.Budynki.Miasto,
                        BudynekUlica = lokale.Lokale.Budynki.Ulica,
                        BudynekNumer = lokale.Lokale.Budynki.Numer,
                        WlascicielImie = lokale.Wlasciciele.Imie,
                        WlascicielNazwisko = lokale.Wlasciciele.Nazwisko,
                        LokalKlatka = lokale.Lokale.Klatka,
                        LokalNumer = lokale.Lokale.NumerLokalu,
                        LokalUdzial = lokale.Lokale.Udzialy,
                        LokalPowierzchnia = lokale.Lokale.Powierzchnia,
                        JednostkaMiarySymbol = lokale.Lokale.JednostkaMiary.Symbol
                    }
                );
        }
        #endregion
    }
}