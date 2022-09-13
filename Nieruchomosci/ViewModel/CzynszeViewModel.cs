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
    public class CzynszeViewModel : WorkspaceViewModel
    {
        #region Constructor
        public CzynszeViewModel()
        {
            base.DisplayName = "Opłaty - Czynsze";
            nieruchomosciEntities = new NieruchomosciEntities();
            DataOd = DateTime.Now;
            DataDo = DateTime.Now;
            CzynszLokal = 0;
            CzynszWspolnota = 0;
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
        private int _IdCzynszu;
        public int IdCzynszu
        {
            get
            {
                return _IdCzynszu;
            }
            set
            {
                if (_IdCzynszu != value)
                {
                    _IdCzynszu = value;
                    OnPropertyChanged(() => IdCzynszu);
                }
            }
        }
        private decimal? _CzynszWspolnota;
        public decimal? CzynszWspolnota
        {
            get
            {
                return _CzynszWspolnota;
            }
            set
            {
                if (_CzynszWspolnota != value)
                {
                    _CzynszWspolnota = value;
                    OnPropertyChanged(() => CzynszWspolnota);
                }
            }
        }
        private decimal? _CzynszLokal;
        public decimal? CzynszLokal
        {
            get
            {
                return _CzynszLokal;
            }
            set
            {
                if (_CzynszLokal != value)
                {
                    _CzynszLokal = value;
                    OnPropertyChanged(() => CzynszLokal);
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
        private int _IdOplaty;
        public int IdOplaty
        {
            get
            {
                return _IdOplaty;
            }
            set
            {
                if (_IdOplaty != value)
                {
                    _IdOplaty = value;
                    OnPropertyChanged(() => IdOplaty);
                }
            }
        }
        private int _IdLokalu;
        public int IdLokalu
        {
            get
            {
                return _IdLokalu;
            }
            set
            {
                if (_IdLokalu != value)
                {
                    _IdLokalu = value;
                    OnPropertyChanged(() => IdLokalu);
                }
            }
        }
        //napiszemy teraz propertiec, który będzie dostarczał danych dla comboboxa służącego do wyboru usług
        public IQueryable<KeyAndValue> OplatyComboBoxItems
        {
            get
            {
                return new OplatyB(nieruchomosciEntities).GetOplatyKeyAndValue();
            }
        }
        public IQueryable<KeyAndValue> WspolnotyComboBoxItems
        {
            get
            {
                return new WspolnotaB(nieruchomosciEntities).GetWspolnotyKeyAndValue();
            }
        }
        public IQueryable<KeyAndValue> LokaleComboBoxItems
        {
            get
            {
                return new LokaleB(nieruchomosciEntities).GetLokaleKeyAndValue();
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
                    _ObliczCommand = new BaseCommand(() => obliczOplate());
                return _ObliczCommand;
            }
        }
        private BaseCommand _ObliczCommand2;
        public ICommand ObliczCommand2
        {
            get
            {
                if (_ObliczCommand2 == null)
                    _ObliczCommand2 = new BaseCommand(() => sumaCzynszu());
                return _ObliczCommand2;
            }
        }
        private BaseCommand _ObliczCommand3;
        public ICommand ObliczCommand3
        {
            get
            {
                if (_ObliczCommand3 == null)
                    _ObliczCommand3 = new BaseCommand(() => sumaCzynszy());
                return _ObliczCommand3;
            }
        }
        #endregion
        #region
        private void obliczOplate()
        {
           CzynszLokal = new RaportCzynsz(nieruchomosciEntities).liczOplate(IdWspolnoty, IdLokalu , IdOplaty, DataOd, DataDo);
        }
        private void sumaCzynszu()
        {
            CzynszWspolnota = new RaportCzynsz(nieruchomosciEntities).sumaCzynsz(IdWspolnoty, IdLokalu, DataOd, DataDo);
        }
        private void sumaCzynszy()
        {
            RaportRazem = new RaportCzynsz(nieruchomosciEntities).sumaCzynsze(IdWspolnoty, DataOd, DataDo);
        }
        #endregion
    }
}
