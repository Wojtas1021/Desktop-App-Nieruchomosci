using Nieruchomosci.Helpers;
using Nieruchomosci.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nieruchomosci.ViewModel.Abstract
{
    // to jest klasa z której będą dziedziczyły wszytkie klasy np dodające rekordy
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        //to jest obiekt który służy do wszelkich operacji na bazie danych
        protected private NieruchomosciEntities nieruchomosciEntities;
        //to jest obiekt który bede dodawał
        protected T item;
        #endregion
        #region Properties
        #endregion
        #region Constructor
        public JedenViewModel(String displayName)
        {
            base.DisplayName = displayName;
            nieruchomosciEntities = new NieruchomosciEntities();
        }
        #endregion
        #region Command
        //to jest która zostanie podpieta pod button zapisz do zapisywania nowego towaru
        private BaseCommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                    _SaveCommand = new BaseCommand(() => saveAndClose());//podepniemy komendę która wywoła funkcję
                return _SaveCommand;
            }
        }
        #endregion
        #region Validatory
        //domyślnie każdy formularz walidujemy pozytywnie, chyba że przy klasie dizedziczącej nadpiszemy ta funkcję
        public virtual bool isValid()
        {
            return true;
        }
        #endregion
        #region Helpers
        public abstract void Save();
        private void saveAndClose()
        {
            if (isValid())
            {
                Save();
                //zamykanie zakładki
                base.OnRequestClose();
            }
            else
                ShowMessageBox("Popraw błędy");
        }
        #endregion
    }
}
