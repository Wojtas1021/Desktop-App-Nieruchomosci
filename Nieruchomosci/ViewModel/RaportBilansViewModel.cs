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
    class RaportBilansViewModel : WorkspaceViewModel
    {
        #region Constructor
        public RaportBilansViewModel()
        {
            base.DisplayName = "Bilans";
            nieruchomosciEntities = new NieruchomosciEntities();
            SumaFundusz = 0;
            SumaWydatki = 0;
        }
        #endregion
        #region Fields and Properties
        //dla każdego pola istotnego w obliczenia tworzymy pola i właściwości
        private NieruchomosciEntities nieruchomosciEntities;
        private decimal? _SumaWydatki;
        public decimal? SumaWydatki
        {
            get
            {
                return _SumaWydatki;
            }
            set
            {
                if (_SumaWydatki != value)
                {
                    _SumaWydatki = value;
                    OnPropertyChanged(() => SumaWydatki);
                }
            }
        }
        private decimal? _SumaFundusz;
        public decimal? SumaFundusz
        {
            get
            {
                return _SumaFundusz;
            }
            set
            {
                if (_SumaFundusz != value)
                {
                    _SumaFundusz = value;
                    OnPropertyChanged(() => _SumaFundusz);
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
        //napiszemy teraz propertiec, który będzie dostarczał danych dla comboboxa służącego do wyboru usług
        public IQueryable<KeyAndValue> WspolnotyComboBoxItems
        {
            get
            {
                return new WspolnotaB(nieruchomosciEntities).GetWspolnotyKeyAndValue();
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
                    _ObliczCommand = new BaseCommand(() => sumaFunduszRemontowy());
                return _ObliczCommand;
            }
        }
        private BaseCommand _ObliczCommand2;
        public ICommand ObliczCommand2
        {
            get
            {
                if (_ObliczCommand2 == null)
                    _ObliczCommand2 = new BaseCommand(() => sumaWydatkow());
                return _ObliczCommand2;
            }
        }
        #endregion
        #region
        private void sumaWydatkow()
        {
            SumaWydatki = new RaportBilans(nieruchomosciEntities).sumaWydatki(IdWspolnoty);
        }
        private void sumaFunduszRemontowy()
        {
            SumaFundusz = new RaportBilans(nieruchomosciEntities).sumaFundusz(IdWspolnoty);
        }
        #endregion
    }
}