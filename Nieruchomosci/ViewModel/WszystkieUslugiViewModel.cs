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
    class WszystkieUslugiViewModel : WszystkieViewModel<UslugiForView>
    {
        #region Constructor
        public WszystkieUslugiViewModel()
            : base("Uslugi")
        {
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<UslugiForView>(List.OrderBy(item => item.Nazwa));
            if (FindField == "Kod")
                List = new ObservableCollection<UslugiForView>(List.OrderBy(item => item.Kod));
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Nazwa", "Kod" };
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<UslugiForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Kod")
                List = new ObservableCollection<UslugiForView>(List.Where(item => item.Kod != null && item.Kod.Equals(FindTextBox)));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Kod", "Nazwa"};
        }
        #endregion
        #region Helpers
        public override void load()
        {
            //to listy przekazuje z bazy danych wszystkie wspolnoty
            List = new ObservableCollection<UslugiForView>
                (
                    //nieruchomosciEntities.WspolnotyMieszkaniowe
                    from uslugi in nieruchomosciEntities.Uslugi
                    where uslugi.CzyAktywny == true
                    select new UslugiForView
                    {
                        IdUslugi = uslugi.IdUslugi,
                        Kod = uslugi.Kod,
                        Nazwa = uslugi.Nazwa,
                        Opis = uslugi.Opis,
                        Uwagi = uslugi.Uwagi
                    }
                );
        }
        #endregion
    }
}

