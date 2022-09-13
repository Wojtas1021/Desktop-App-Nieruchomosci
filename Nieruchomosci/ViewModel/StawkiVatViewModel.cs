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
    class StawkiVatViewModel : WszystkieViewModel<StawkiVatForView>
    {
        #region Constructor
        public StawkiVatViewModel()
            : base("StawkaVat")
        {
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            switch (SortField)
            {
                case "Uwagi":
                    List = new ObservableCollection<StawkiVatForView>(List.OrderBy(item => item.Uwagi));
                    break;
                case "Wartosc rosnąco":
                    List = new ObservableCollection<StawkiVatForView>(List.OrderBy(item => item.Wartosc));
                    break;
                case "Symbol":
                    List = new ObservableCollection<StawkiVatForView>(List.OrderBy(item => item.Symbol));
                    break;
                case "Cena malejąco":
                    List = new ObservableCollection<StawkiVatForView>(List.OrderByDescending(item => item.Wartosc));
                    break;
            }
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Symbol", "Uwagi", "Wartość rosnąco", "Watrość malejąco" };
        }
        public override void find()
        {
            load();
            if (FindField == "Symbol")
                List = new ObservableCollection<StawkiVatForView>(List.Where(item => item.Symbol != null && item.Symbol.StartsWith(FindTextBox)));
            if (FindField == "Watrosc")
                List = new ObservableCollection<StawkiVatForView>(List.Where(item => item.Wartosc != null && item.Wartosc.Equals(FindTextBox)));
            if (FindField == "Uwagi")
                List = new ObservableCollection<StawkiVatForView>(List.Where(item => item.Uwagi != null && item.Uwagi.StartsWith(FindTextBox)));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Symbol", "Wartosc", "Uwagi" };
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<StawkiVatForView>
                (
                    from stawkiVat in nieruchomosciEntities.StawkiVat
                    where stawkiVat.CzyAktywny == true
                    select new StawkiVatForView
                    {
                        IdStawkiVat = stawkiVat.IdStawkiVat,
                        Symbol = stawkiVat.Symbol,
                        Wartosc = stawkiVat.Wartosc,
                        Uwagi = stawkiVat.Uwagi,
                    }
                );
        }
        #endregion
    }
}

