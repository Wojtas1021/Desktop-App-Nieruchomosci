using Nieruchomosci.Helpers;
using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using Nieruchomosci.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nieruchomosci.ViewModel
{
    //Wszystkie WspolnotyViewModel dziedziczy po WszytkieViewModel po typie generycznymm T
    public class WszystkieWspolnotyViewModel : WszystkieViewModel<WspolnotyForView>
    {
        #region Constructor
        public WszystkieWspolnotyViewModel()
            :base("Wspólnoty")
        {
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            switch(SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<WspolnotyForView>(List.OrderBy(item => item.Nazwa));
                    break;
                case "Kod":
                    List = new ObservableCollection<WspolnotyForView>(List.OrderBy(item => item.Kod));
                    break;
                case "Adres":
                    List = new ObservableCollection<WspolnotyForView>(List.OrderBy(item => item.AdresWspolnota));
                    break;
            }
            //if (SortField == "Nazwa")
            //    List = new ObservableCollection<WspolnotyForView>(List.OrderBy(item => item.Nazwa));
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> {"Kod", "Nazwa", "Adres"};
        }
        public override void find()
        {
            load();
            if(FindField =="Nazwa")
                List = new ObservableCollection<WspolnotyForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Kod")
                List = new ObservableCollection<WspolnotyForView>(List.Where(item => item.Kod != null && item.Kod.StartsWith(FindTextBox)));
            if (FindField == "Adres")
                List = new ObservableCollection<WspolnotyForView>(List.Where(item => item.AdresWspolnota != null && item.AdresWspolnota.StartsWith(FindTextBox)));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Kod", "Nazwa", "Adres"};
        }
        #endregion
        #region Helpers
        public override void load()
        {
            //to listy przekazuje z bazy danych wszystkie wspolnoty
            List = new ObservableCollection<WspolnotyForView>
                (
                //nieruchomosciEntities.WspolnotyMieszkaniowe
                    from wspolnotyMieszkaniowe in nieruchomosciEntities.WspolnotyMieszkaniowe
                    where wspolnotyMieszkaniowe.CzyAktywny == true
                    select new WspolnotyForView
                    {
                        IdWspolnotyMieszkaniowej = wspolnotyMieszkaniowe.IdWspolnotyMieszkaniowej,
                        Kod = wspolnotyMieszkaniowe.Kod,
                        Nazwa = wspolnotyMieszkaniowe.Nazwa,
                        AdresWspolnota = wspolnotyMieszkaniowe.Adresy.Miasto
                        +" ul."
                        +wspolnotyMieszkaniowe.Adresy.Ulica
                        +" "
                        +wspolnotyMieszkaniowe.Adresy.NumerDomu,
                        Nip = wspolnotyMieszkaniowe.Nip,
                        Regon = wspolnotyMieszkaniowe.Regon,
                        Krs = wspolnotyMieszkaniowe.Krs,
                        DataPowstania = wspolnotyMieszkaniowe.DataPowstania,
                        PoczatkowyRokKsiegowy = wspolnotyMieszkaniowe.PoczatkowyRokKsiegowy,
                        BiezacyRokKsiegowy = wspolnotyMieszkaniowe.BiezacyRokKsiegowy,
                    }
                );
        }
        #endregion
    }
}