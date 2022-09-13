using Nieruchomosci.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.BusinessLogic
{
    //to jest klasa z któtrej będą dziedziczyły wszystkie klasy logigi biznesowej używającej bazy danych
    public class DatabaseClass
    {
        #region Fields and Properties
        private NieruchomosciEntities _nieruchomosciEntities;
        public NieruchomosciEntities nieruchomosciEntities
        {
            get
            {
                return _nieruchomosciEntities;
            }
            set
            {
                if (_nieruchomosciEntities != value)
                    _nieruchomosciEntities = value;
            }
        }
        #endregion
        #region Constructor
        public DatabaseClass(NieruchomosciEntities nieruchomosciEntities)
        {
            this.nieruchomosciEntities = nieruchomosciEntities;
        }
        #endregion
    }
}
