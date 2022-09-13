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
    class WszystkieBudynkiViewModel : WszystkieViewModel<BudynkiForView>
    {
        #region Constructor
        public WszystkieBudynkiViewModel()
            : base("Budynki")
        {
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            switch (SortField)
            {
                case "Miasto":
                    List = new ObservableCollection<BudynkiForView>(List.OrderBy(item => item.Miasto));
                    break;
                case "Ulica":
                    List = new ObservableCollection<BudynkiForView>(List.OrderBy(item => item.Ulica));
                    break;
                case "Kod":
                    List = new ObservableCollection<BudynkiForView>(List.OrderBy(item => item.Kod));
                    break;
            }
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Kod", "Miasto", "Ulica" };
        }
        public override void find()
        {
            load();
            if (FindField == "Kod")
                List = new ObservableCollection<BudynkiForView>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
            if (FindField == "Miasto")
                List = new ObservableCollection<BudynkiForView>(List.Where(item => item.Miasto != null && item.Miasto.StartsWith(FindTextBox)));
            if (FindField == "Ulica")
                List = new ObservableCollection<BudynkiForView>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
            if (FindField == "Numer")
                List = new ObservableCollection<BudynkiForView>(List.Where(item => item.Numer != null && item.Numer.StartsWith(FindTextBox)));
            if (FindField == "RokBudowy")
                List = new ObservableCollection<BudynkiForView>(List.Where(item => item.RokBudowy != null && item.RokBudowy.Equals(FindTextBox)));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Kod", "Miasto", "Ulica", "Numer", "RokBudowy"};
        }
        #endregion
        #region Helpers
        public override void load()
        {
            //to listy przekazuje z bazy danych wszystkie wspolnoty
            List = new ObservableCollection<BudynkiForView>
                (
                    //nieruchomosciEntities.WspolnotyMieszkaniowe
                    from budynki in nieruchomosciEntities.Budynki
                    where budynki.CzyAktywny == true
                    select new BudynkiForView
                    {
                        IdBudynku = budynki.IdBudynku,
                        Kod = budynki.Kod,
                        Miasto = budynki.Miasto,
                        Ulica = budynki.Ulica,
                        Numer = budynki.Numer,
                        LiczbaKondygnacji = budynki.LiczbaKondygnacji,
                        LiczbaLokali = budynki.LiczbaLokali,
                        RodzajBudynku = budynki.RodzajBudynku,
                        TypBudynku = budynki.TypBudynku,
                        NumerDzialki = budynki.NumerDzialki,
                        Powierzchnia = budynki.PowierzchniaUzytkowa,
                        JednostkaMiarySumbol = budynki.JednostkaMiary.Symbol,
                        RokBudowy = budynki.RokBudowy,
                        DataOddania = budynki.DataOddania,
                    }
                );
        }
        #endregion
    }
}