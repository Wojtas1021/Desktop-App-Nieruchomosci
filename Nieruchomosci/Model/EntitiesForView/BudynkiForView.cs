using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nieruchomosci.Model.EntitiesForView
{
    class BudynkiForView
    {
        public int IdBudynku { get; set; }
        public string Kod { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string Numer { get; set; }
        public int? LiczbaKondygnacji { get; set; }
        public int? LiczbaLokali { get; set; }
        public string RodzajBudynku { get; set; }
        public string TypBudynku { get; set; }
        public string NumerDzialki { get; set; }
        public string Powierzchnia { get; set; }
        public string JednostkaMiarySumbol { get; set; }
        public DateTime? RokBudowy { get; set; }
        public DateTime? DataOddania { get; set; }
    }
}
