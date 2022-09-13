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
    class WszystkieOplatyViewModel : WszystkieViewModel<OplatyForView>
    {
        #region Constructor
        public WszystkieOplatyViewModel()
            : base("Opłaty")
        {
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<OplatyForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> {"Nazwa"};
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<OplatyForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> {"Nazwa" };
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<OplatyForView>
                (
                    from oplaty in nieruchomosciEntities.Oplaty
                    where oplaty.CzyAktywny == true
                    select new OplatyForView
                    {
                        IdOplaty = oplaty.IdOplaty,
                        Nazwa = oplaty.Nazwa,
                    }
                );
        }
        #endregion
    }
}