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
    class WszyscyKontrahenciViewModel : WszystkieViewModel<KontrahenciForView>
    {
        #region Constructor
        public WszyscyKontrahenciViewModel()
            : base("Kontrahenci")
        {
        }
        #endregion
        #region sort and find
        public override void sort()
        {
            switch (SortField)
            {
                case "Nazwa":
                    List = new ObservableCollection<KontrahenciForView>(List.OrderBy(item => item.Nazwa));
                    break;
                case "Adres":
                    List = new ObservableCollection<KontrahenciForView>(List.OrderBy(item => item.KontrahentAdres));
                    break;
            }
        }
        public override List<string> getComboboxSortList()
        {
            return new List<string> {"Nazwa", "Adres" };
        }
        public override void find()
        {
            load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<KontrahenciForView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Nip")
                List = new ObservableCollection<KontrahenciForView>(List.Where(item => item.Nip != null && item.Nip.StartsWith(FindTextBox)));
            if (FindField == "Adres")
                List = new ObservableCollection<KontrahenciForView>(List.Where(item => item.KontrahentAdres != null && item.KontrahentAdres.StartsWith(FindTextBox)));
            if (FindField == "Email")
                List = new ObservableCollection<KontrahenciForView>(List.Where(item => item.Emial != null && item.Emial.StartsWith(FindTextBox)));
            if (FindField == "Telefon1")
                List = new ObservableCollection<KontrahenciForView>(List.Where(item => item.Telefon1 != null && item.Telefon1.StartsWith(FindTextBox)));
            if (FindField == "Telefon2")
                List = new ObservableCollection<KontrahenciForView>(List.Where(item => item.Telefon2 != null && item.Telefon2.StartsWith(FindTextBox)));
        }
        public override List<string> getComboboxFindList()
        {
            return new List<string> { "Nip", "Nazwa", "Adres", "Email", "Telefon1", "Telefon2" };
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<KontrahenciForView>
                (
                    from kontrahenci in nieruchomosciEntities.AdresKontrahenta
                    where kontrahenci.CzyAktywny == true
                    select new KontrahenciForView
                    {
                        IdKontrahenta = kontrahenci.Kontrahenci.IdKontrahenta,
                        Nazwa = kontrahenci.Kontrahenci.Nazwa,
                        Nip = kontrahenci.Kontrahenci.Nip,
                        Regon = kontrahenci.Kontrahenci.Regon,
                        KontrahentAdres = kontrahenci.Kontrahenci.Adresy.Miasto
                        + " " + kontrahenci.Kontrahenci.Adresy.Ulica
                        + " /" + kontrahenci.Kontrahenci.Adresy.NumerDomu,
                        RodzajKontrahentaNazwa = kontrahenci.Kontrahenci.RodzajKontrahenta.Nazwa,
                        Telefon1 = kontrahenci.Kontrahenci.Telefon1,
                        Telefon2 = kontrahenci.Kontrahenci.Telefon2,
                        Emial = kontrahenci.Kontrahenci.Email,
                        Fax = kontrahenci.Kontrahenci.Fax,
                        Url = kontrahenci.Kontrahenci.Url,
                    }
                );
        }
        #endregion
    }
}