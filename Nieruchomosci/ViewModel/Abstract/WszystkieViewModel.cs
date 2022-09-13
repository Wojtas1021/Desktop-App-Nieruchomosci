using GalaSoft.MvvmLight.Messaging;
using Nieruchomosci.Helpers;
using Nieruchomosci.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Nieruchomosci.ViewModel.Abstract
{
    // to jest klasa po której będą dziedziczyły wszystkie modele z wszystkie
    // klasa działa na typie generycznyn T pod którym w przypadku wyswietlania towarów wyswietlane sa towary, wspolnoty itp
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        // to jest dostęp do bazy danych
        protected readonly NieruchomosciEntities nieruchomosciEntities;
        // to jest komenda, która podepniemy pod przycisk i ona wywoła funkcję
        private BaseCommand _LoadCommand;
        private BaseCommand _AddCommand;
        private BaseCommand _SortCommand;
        private BaseCommand _FindCommand;
        private ObservableCollection<T> _List;
        #endregion
        #region Properties
        //podpinamy pod LoadCommand funckcje load
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }
                return _LoadCommand;
            }
        }
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null)
                    load();
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                {
                    _FindCommand = new BaseCommand(() => find()); // komenda FindCommand wywołuje metodę find
                }
                return _FindCommand;
            }
        }
        public string FindTextBox { get; set; } // to jest properties do zapisywania początku frazy do wyszukiwania 
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add()); // komenda AddCommand wywołuje metodę add
                }
                return _AddCommand;
            }
        }
        public string SortField { get; set; }
        // to jest właściwośc, która wypełnia elementy comboBoxa - czyli można sortować

        public List<string> SortComboboxItems
        {
            get
            {
                return getComboboxSortList(); //elementy po czym sortować będą pobrane z metody getComboboxSortList()
            }
        }
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                {
                    _SortCommand = new BaseCommand(() => sort()); // komenda SortCommand wywołuje metodę sort
                }
                return _SortCommand;
            }
        }
        public string FindField { get; set; }
        // to jest właściwośc, która wypełnia elementy comboBoxa - czyli można filtrowac

        public List<string> FindComboboxItems
        {
            get
            {
                return getComboboxFindList(); //elementy po czym sortować będą pobrane z metody getComboboxFindList()
            }
        }
        #endregion
        #region Constructor
        public WszystkieViewModel(String displayName)
        {
            base.DisplayName = displayName;
            //tworze baze danych
            this.nieruchomosciEntities = new NieruchomosciEntities();
        }
        #endregion
        #region Helpers
        // klasa wszystkieViewModel jest klasa abstakcyjna bo zawiera co najmniej 1 funkcje abstrakcyjna 
        public abstract void load();
        private void add()
        {
            // to jest Messenger z biblioteki MVVMLight, wysyła on komunikat DisplayName + add, który zostanie przejęty przez klase MainWindowViewModel
            Messenger.Default.Send(DisplayName + "Add");
        }
        public abstract void sort();
        //po czym sotrować decydował bede w klasie dziedziczącej
        public abstract List<string> getComboboxSortList();

        //jak szukać decydował będe dopiero w klasie dziedziczącej
        public abstract void find();
        //po czym szukać decydował bede w klasie dziedziczącej
        public abstract List<string> getComboboxFindList();
        #endregion
    }
}
