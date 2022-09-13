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
    class WszyscyWlascicieleViewModel : WszystkieViewModel<WlascicieleForView>
    {
        #region Constructor
        public WszyscyWlascicieleViewModel()
            : base("Właściciele")
        {
        }
        #endregion
      #region sort and find
        public override void sort()
        {
            switch(SortField)
            {
                case "Imie":
                    List = new ObservableCollection<WlascicieleForView>(List.OrderBy(item => item.Imie));
                    break;
                case "Nazwisko":
                    List = new ObservableCollection<WlascicieleForView>(List.OrderBy(item => item.Nazwisko));
                    break;
            }
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> {"Imie", "Nazwisko"};
        }
        public override void find()
        {
            load();
            switch (FindField)
            {
                case "Imie":
                    List = new ObservableCollection<WlascicieleForView>(List.Where(item => item.Imie != null && item.Imie.StartsWith(FindTextBox)));
                    break;
                case "Nazwisko":
                    List = new ObservableCollection<WlascicieleForView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
                    break;
                case "Pesel":
                    List = new ObservableCollection<WlascicieleForView>(List.Where(item => item.Pesel != null && item.Pesel.StartsWith(FindTextBox)));
                    break;
                case "Nip":
                    List = new ObservableCollection<WlascicieleForView>(List.Where(item => item.Nip != null && item.Nip.StartsWith(FindTextBox)));
                    break;
                case "Telefon":
                    List = new ObservableCollection<WlascicieleForView>(List.Where(item => item.Telefon != null && item.Telefon.StartsWith(FindTextBox)));
                    break;
                case "Email":
                    List = new ObservableCollection<WlascicieleForView>(List.Where(item => item.Email != null && item.Email.StartsWith(FindTextBox)));
                    break;
            }
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Imie", "Nazwisko", "Pesel", "Nip", "Telefon", "Email"};
        }
        #endregion
        #region Helpers
        public override void load()
        {
            //to listy przekazuje z bazy danych wszystkie wspolnoty
            List = new ObservableCollection<WlascicieleForView>
                (
                    //nieruchomosciEntities.WspolnotyMieszkaniowe
                    from wlasciciele in nieruchomosciEntities.Wlasciciele
                    where wlasciciele.CzyAktywny == true
                    select new WlascicieleForView
                    {
                        IdWlasciciela = wlasciciele.IdWlasciciela,
                        Imie = wlasciciele.Imie,
                        Nazwisko = wlasciciele.Nazwisko,
                        Pesel = wlasciciele.Pesel,
                        Nip = wlasciciele.Nip,
                        Telefon = wlasciciele.Telefon,
                        Email = wlasciciele.Email,
                        Uwagi = wlasciciele.Uwagi
                    }
                );
        }
        #endregion
    }
}

