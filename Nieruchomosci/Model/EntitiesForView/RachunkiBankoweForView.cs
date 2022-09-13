using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.EntitiesForView
{
    class RachunkiBankoweForView
    {
        public int IdRachunkuBankowego { get; set; }
        public string NazwaBanku { get; set; }
        public string NumerRachunku { get; set; }
        public string Komentarz { get; set; }
        public string Uwagi { get; set; }
    }
}
