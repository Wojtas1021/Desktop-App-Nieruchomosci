using GalaSoft.MvvmLight.Messaging;
using Nieruchomosci.Helpers;
using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using Nieruchomosci.ViewModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nieruchomosci.ViewModel
{
    public class NowyBudynekViewModel : JedenViewModel<Budynki>
    {
        #region Fields
        private BaseCommand _ShowJednostkiMiary;
        #endregion
        #region Constructor
        public NowyBudynekViewModel()
            : base("Budynek")
        {
            item = new Budynki();
            Messenger.Default.Register<JednostkiMiaryForView>(this, getWybranaJednostkaMiary);
        }
        #endregion
        #region Command
        public ICommand ShowJednostkiMiary
        {
            get
            {
                if (_ShowJednostkiMiary == null)
                    _ShowJednostkiMiary = new BaseCommand(() => Messenger.Default.Send("JenostkiMiaryShow"));
                return _ShowJednostkiMiary;
            }
        }
        public IQueryable<JednostkaMiary> JednostkaMiaryComboboxItem
        {
            get
            {
                return
                    (
                    from jednostkaMiary in nieruchomosciEntities.JednostkaMiary
                    where jednostkaMiary.CzyAktywny == true
                    select jednostkaMiary
                ).ToList().AsQueryable();
            }
        }
        #endregion
        #region Properties
        //dla każdego pola edytowalnego na interface.. tworzymy propertiesa
        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (item.Kod != value)
                {
                    item.Kod = value;
                    base.OnPropertyChanged(() => Kod);
                }
            }
        }
        public string Miasto
        {
            get
            {
                return item.Miasto;
            }
            set
            {
                if (item.Miasto != value)
                {
                    item.Miasto = value;
                    base.OnPropertyChanged(() => Miasto);
                }
            }
        }
        public string Ulica
        {
            get
            {
                return item.Ulica;
            }
            set
            {
                if (item.Ulica != value)
                {
                    item.Ulica = value;
                    base.OnPropertyChanged(() => Ulica);
                }
            }
        }
        public string Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (item.Numer != value)
                {
                    item.Numer = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }
        public int? LiczbaKondygnacji
        {
            get
            {
                return item.LiczbaKondygnacji;
            }
            set
            {
                if (item.LiczbaKondygnacji != value)
                {
                    item.LiczbaKondygnacji = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }
        public int? LiczbaLokali
        {
            get
            {
                return item.LiczbaLokali;
            }
            set
            {
                if (item.LiczbaLokali != value)
                {
                    item.LiczbaLokali = value;
                    base.OnPropertyChanged(() => LiczbaLokali);
                }
            }
        }
        public string RodzajBudynku
        {
            get
            {
                return item.RodzajBudynku;
            }
            set
            {
                if (item.RodzajBudynku != value)
                {
                    item.RodzajBudynku = value;
                    base.OnPropertyChanged(() => RodzajBudynku);
                }
            }
        }
        public string TypBudynku
        {
            get
            {
                return item.TypBudynku;
            }
            set
            {
                if (item.TypBudynku != value)
                {
                    item.TypBudynku = value;
                    base.OnPropertyChanged(() => TypBudynku);
                }
            }
        }
        public string NumerDzialki
        {
            get
            {
                return item.NumerDzialki;
            }
            set
            {
                if (item.NumerDzialki != value)
                {
                    item.NumerDzialki = value;
                    base.OnPropertyChanged(() => NumerDzialki);
                }
            }
        }
        public string PowierzchniaUzytkowa
        {
            get
            {
                return item.PowierzchniaUzytkowa;
            }
            set
            {
                if (item.PowierzchniaUzytkowa != value)
                {
                    item.PowierzchniaUzytkowa = value;
                    base.OnPropertyChanged(() => PowierzchniaUzytkowa);
                }
            }
        }
        public int? IdJednostkiMiary
        {
            get
            {
                return item.IdJednostkiMiary;
            }
            set
            {
                if (item.IdJednostkiMiary != value)
                {
                    item.IdJednostkiMiary = value;
                    base.OnPropertyChanged(() => IdJednostkiMiary);
                }
            }
        }
        public string _JednostkaMiarySymbol;
        public string JednostkaMiarySymbol
        {
            get
            {
                return _JednostkaMiarySymbol;
            }
            set
            {
                if (_JednostkaMiarySymbol != value)
                {
                    _JednostkaMiarySymbol = value;
                    base.OnPropertyChanged(() => JednostkaMiarySymbol);
                }
            }
        }
        public DateTime? RokBudowy
        {
            get
            {
                return item.RokBudowy;
            }
            set
            {
                if (item.RokBudowy != value)
                {
                    item.RokBudowy = value;
                    base.OnPropertyChanged(() => RokBudowy);
                }
            }
        }
        public DateTime? DataOddania
        {
            get
            {
                return item.DataOddania;
            }
            set
            {
                if (item.DataOddania != value)
                {
                    item.DataOddania = value;
                    base.OnPropertyChanged(() => DataOddania);
                }
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            item.CzyAktywny = true;
            //do lokalnej kolekcji wspolnot dodajemy nową wspolnotę
            nieruchomosciEntities.Budynki.Add(item);
            //wysylamy zmiany do bazy danych
            nieruchomosciEntities.SaveChanges();
        }
        private void getWybranaJednostkaMiary(JednostkiMiaryForView jm)
        {
            IdJednostkiMiary = jm.IdJednostkiMiary;
            JednostkaMiarySymbol = jm.Symbol;
        }
        #endregion
    }
}
