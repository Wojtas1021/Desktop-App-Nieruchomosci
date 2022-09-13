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
    class JednostkiMiaryViewModel : WszystkieViewModel<JednostkiMiaryForView>
    {
        #region Constructor
        public JednostkiMiaryViewModel()
            : base("Jednostki miary")
        {
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            switch (SortField)
            {
                case "Symbol":
                    List = new ObservableCollection<JednostkiMiaryForView>(List.OrderBy(item => item.Symbol));
                    break;
                case "Opis":
                    List = new ObservableCollection<JednostkiMiaryForView>(List.OrderBy(item => item.Opis));
                    break;
            }
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Symbol", "Opis" };
        }
        public override void find()
        {
            load();
            switch (FindField)
            {
                case "Symbol":
                    List = new ObservableCollection<JednostkiMiaryForView>(List.Where(item => item.Symbol != null && item.Symbol.StartsWith(FindTextBox)));
                    break;
                case "Opis":
                    List = new ObservableCollection<JednostkiMiaryForView>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
                    break;
            }
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Symbol", "Opis" };
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<JednostkiMiaryForView>
                (
                    from jednostkiMiary in nieruchomosciEntities.JednostkaMiary
                    where jednostkiMiary.CzyAktywny == true
                    select new JednostkiMiaryForView
                    {
                        IdJednostkiMiary = jednostkiMiary.IdJednostkiMiary,
                        Symbol = jednostkiMiary.Symbol,
                        Opis = jednostkiMiary.Opis,
                        Uwagi = jednostkiMiary.Uwagi,
                    }
                );
        }
        #endregion
    }
}