using Nieruchomosci.Helpers;
using Nieruchomosci.Model.BusinessLogic;
using Nieruchomosci.Model.Entities;
using Nieruchomosci.Model.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nieruchomosci.ViewModel
{
    public class RaportUslugiViewModel : WorkspaceViewModel
    {
        #region Constructor
        public RaportUslugiViewModel()
        {
            base.DisplayName = "Raport usługi";
            nieruchomosciEntities = new NieruchomosciEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            RaportUsluga = 0;
            RaportFaktura = 0;
            RaportRazem = 0;
        }
        #endregion
        #region Fields and Properties
        //dla każdego pola istotnego w obliczenia tworzymy pola i właściwości
        private NieruchomosciEntities nieruchomosciEntities;
        private DateTime _DataOd;
        public DateTime DataOd
        {
            get
            {
                return _DataOd;
            }
            set
            {
                if (_DataOd != value)
                {
                    _DataOd = value;
                    OnPropertyChanged(() => DataOd);
                }
            }
        }
        private DateTime _DataDo;
        public DateTime DataDo
        {
            get
            {
                return _DataDo;
            }
            set
            {
                if (_DataDo != value)
                {
                    _DataDo = value;
                    OnPropertyChanged(() => DataDo);
                }
            }
        }
        private int _IdUslugi;
        public int IdUslugi
        {
            get
            {
                return _IdUslugi;
            }
            set
            {
                if (_IdUslugi != value)
                {
                    _IdUslugi = value;
                    OnPropertyChanged(() => IdUslugi);
                }
            }
        }
        private decimal? _RaportUsluga;
        public decimal? RaportUsluga
        {
            get
            {
                return _RaportUsluga;
            }
            set
            {
                if (_RaportUsluga != value)
                {
                    _RaportUsluga = value;
                    OnPropertyChanged(() => RaportUsluga);
                }
            }
        }
        private decimal? _RaportFaktura;
        public decimal? RaportFaktura
        {
            get
            {
                return _RaportFaktura;
            }
            set
            {
                if (_RaportFaktura != value)
                {
                    _RaportFaktura = value;
                    OnPropertyChanged(() => RaportFaktura);
                }
            }
        }
        private decimal? _RaportRazem;
        public decimal? RaportRazem
        {
            get
            {
                return _RaportRazem;
            }
            set
            {
                if (_RaportRazem != value)
                {
                    _RaportRazem = value;
                    OnPropertyChanged(() => RaportRazem);
                }
            }
        }
        private int _IdWspolnoty;
        public int IdWspolnoty
        {
            get
            {
                return _IdWspolnoty;
            }
            set
            {
                if (_IdWspolnoty != value)
                {
                    _IdWspolnoty = value;
                    OnPropertyChanged(() => IdWspolnoty);
                }
            }
        }
        private int _IdFaktury;
        public int IdFaktury
        {
            get
            {
                return _IdFaktury;
            }
            set
            {
                if (_IdFaktury != value)
                {
                    _IdFaktury = value;
                    OnPropertyChanged(() => IdFaktury);
                }
            }
        }
        //napiszemy teraz propertiec, który będzie dostarczał danych dla comboboxa służącego do wyboru usług
        public IQueryable<KeyAndValue> UslugiComboBoxItems
        {
            get
            {
                return new UslugaB(nieruchomosciEntities).GetUslugiKeyAndValue();
            }
        }
        public IQueryable<KeyAndValue> WspolnotyComboBoxItems
        {
            get
            {
                return new WspolnotaB(nieruchomosciEntities).GetWspolnotyKeyAndValue();
            }
        }
        public IQueryable<KeyAndValue> FakturyComboBoxItems
        {
            get
            {
                return new FakturaB(nieruchomosciEntities).GetFakturyKeyAndValue();
            }
        }
        #endregion

        #region Command
        //to jest komenda która zostanie podpieta pod przycisk oblicz i wywoła funkcje oblicz raport click
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(() => obliczRaportClick());
                return _ObliczCommand;
            }
        }
        private BaseCommand _ObliczCommand2;
        public ICommand ObliczCommand2
        {
            get
            {
                if (_ObliczCommand2 == null)
                    _ObliczCommand2 = new BaseCommand(() => sumaFaktury());
                return _ObliczCommand2;
            }
        }
        private BaseCommand _ObliczCommand3;
        public ICommand ObliczCommand3
        {
            get
            {
                if (_ObliczCommand3 == null)
                    _ObliczCommand3 = new BaseCommand(() => razemUslugi());
                return _ObliczCommand3;
            }
        }
        #endregion
        #region
        private void obliczRaportClick()
        {
            RaportUsluga = new RaportB(nieruchomosciEntities).RaportOkresUsluga(IdUslugi, IdWspolnoty, IdFaktury , DataOd, DataDo);
        }
        private void sumaFaktury()
        {
            RaportFaktura = new RaportB(nieruchomosciEntities).FakturaRazem(IdWspolnoty, IdFaktury);
        }
        private void razemUslugi()
        {
            RaportRazem = new RaportB(nieruchomosciEntities).UslugiRazem(IdWspolnoty);
        }
        #endregion
    }
}
