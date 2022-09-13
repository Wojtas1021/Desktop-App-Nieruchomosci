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
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturyForView>
    {
        #region Constructor
        public WszystkieFakturyViewModel()
            : base("Faktury")
        {
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            switch (SortField)
            {
                case "Numer":
                    List = new ObservableCollection<FakturyForView>(List.OrderBy(item => item.Numer));
                    break;
                case "Data wystawienia":
                    List = new ObservableCollection<FakturyForView>(List.OrderBy(item => item.DataWystawienia));
                    break;
                case "Termin płatności":
                    List = new ObservableCollection<FakturyForView>(List.OrderBy(item => item.TerminPlatnosci));
                    break;
            }
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> { "Numer", "Data wystawienia", "Termin płatności", };
        }
        public override void find()
        {
            load();
            if (FindField == "Numer")
                List = new ObservableCollection<FakturyForView>(List.Where(item => item.Numer != null && item.Numer.StartsWith(FindTextBox)));
            if (FindField == "Kontrahent")
                List = new ObservableCollection<FakturyForView>(List.Where(item => item.KontrahentaNazwa != null && item.KontrahentaNazwa.StartsWith(FindTextBox)));
            if (FindField == "Data wystawienia")
                List = new ObservableCollection<FakturyForView>(List.Where(item => item.DataWystawienia != null && item.DataWystawienia.Equals(FindTextBox)));
            if (FindField == "Termin płatności")
                List = new ObservableCollection<FakturyForView>(List.Where(item => item.TerminPlatnosci != null && item.TerminPlatnosci.Equals(FindTextBox)));
            if (FindField == "Wspólnota mieszkaniowa")
                List = new ObservableCollection<FakturyForView>(List.Where(item => item.WspolnotaMieszkaniowaNazwa != null && item.WspolnotaMieszkaniowaNazwa.Equals(FindTextBox)));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Numer", "Kontrahent", "Data wystawienia", "Temin płatności", "Wspólnota mieszkaniowa" };
        }
        #endregion
        #region Helpers
        public override void load()
        {
           // to listy przekazuje z bazy danych wszystkie wspolnoty
            List = new ObservableCollection<FakturyForView> 
                (
                    from faktury in nieruchomosciEntities.Faktury
                    where faktury.CzyAktywny == true
                    select new FakturyForView
                    {
                        IdFaktury = faktury.IdFaktury,
                        Numer = faktury.Numer,
                        //zastosowanie linq z wypisaniem klucza obcego
                        WspolnotaMieszkaniowaNazwa = faktury.WspolnotyMieszkaniowe.Nazwa,
                        KontrahentaNazwa = faktury.AdresKontrahenta.Kontrahenci.Nazwa,
                        KontrahentaNip = faktury.AdresKontrahenta.Kontrahenci.Nip,
                        KontrahentaAdres = faktury.AdresKontrahenta.Kontrahenci.Adresy.Miasto
                            + " ul."
                            + faktury.AdresKontrahenta.Kontrahenci.Adresy.Ulica
                            + " "
                            + faktury.AdresKontrahenta.Kontrahenci.Adresy.NumerDomu,
                        DataWystawienia = faktury.DataWystawienia,
                        TerminPlatnosci = faktury.TerminPlatnosci,
                        SposobPlatnosciNazwa = faktury.SposobPlatnosci.Nazwa,
                    }
                );
        }
        #endregion
    }
}