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
    class WszystkieRachunkiBankoweViewModel : WszystkieViewModel<RachunkiBankoweForView>
    {
        #region Constructor
        public WszystkieRachunkiBankoweViewModel()
            : base("Rachunki bankowe")
        {
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            if (FindField == "Nazwa banku")
                List = new ObservableCollection<RachunkiBankoweForView>(List.OrderBy(item => item.NazwaBanku));
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa banku" };
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa banku")
                List = new ObservableCollection<RachunkiBankoweForView>(List.Where(item => item.NazwaBanku != null && item.NazwaBanku.StartsWith(FindTextBox)));
            if (FindField == "Numer rachunku")
                List = new ObservableCollection<RachunkiBankoweForView>(List.Where(item => item.NumerRachunku != null && item.NumerRachunku.Contains(FindTextBox)));

        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nazwa banku", "Numer rachunku"};
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<RachunkiBankoweForView>
                (
                    from rachunkiBankowe in nieruchomosciEntities.RachunkiBankowe
                    where rachunkiBankowe.CzyAktywny == true
                    select new RachunkiBankoweForView
                    {
                        IdRachunkuBankowego = rachunkiBankowe.IdRachunkuBankowego,
                        NazwaBanku = rachunkiBankowe.NazwaBanku,
                        NumerRachunku = rachunkiBankowe.NumerRachunku,
                        Komentarz = rachunkiBankowe.Komentarz,
                        Uwagi = rachunkiBankowe.Uwagi,
                    }
                );
        }
        #endregion
    }
}